/*
	btnPressed = 1  ==> MODE
	btnPressed = 2  ==> sipka nahoru
	btnPressed = 3  ==> sipka dolu
	btnPressed = 4  ==> SET

	Do pameti znaku
	bit 1  - P2 0
	bit 2  - P2 1
	bit 3  - P2 2
	bit 4  - P2 3
	bit 5  - P2 4

	Klavesnice/multiplex
	bit 8  - P1 0
	bit 9  - P1 1
	bit 10 - P1 2
	bit 11 - P1 3
	bit 12 - P3 0

	Zámek
	bit 20 - P1 4

	Motor
	bit 19 - P1 5

	Žárovka
	bit 16 - P1 6

	Zvuk
	bit 15 - P1 7

	Dvirka zaverna?
	bit 7  - P3 1

	Snimac teploty
	bit 14 - P3 2
	

*/

#include <stdio.h>
#include <dos.h>
#include <time.h>
#include <conio.h>

#define P2OUT 0x300
#define P4IN 0x300
#define P1OUT 0x301
#define P3IN 0x301

int dispData[4] = { 0x1C, 0x11, 0x01, 0x1C }; // Data pro displej (defaultne = .HI.)

int state = 0; // Stav programu
int doorState = 0; // Stav dveri
int timeCounter = 0; // Counter casu
int tempCounter = 3; // Counter teploty (3 moznosti teploty - HIGH, MED, LOW)
int realTime; // Realny cas prepocitany z timeCounter
int btnPressed = 0; // Stav tlacitka
int shift_motor = 5; // Strida PWMka motoru
int shift_bulb = 5; // Strida PWMka svetla
int shift_buzzer = 5; // Strida PWMka svetla

int door_btn_masks[2] = { 0x02, 0x01 }; // Masky - dvere senzor, btn
int segments_masks[4] = { 0x7E, 0x7D, 0x7B, 0x77 }; // 1. segment, 2. segment, 3. segment, 4. segment
int pwmMasks[4] = { 0x5F, 0x7F, 0x1F, 0x3F }; // PWM masky - MOTOR ON, MOTOR OFF i ZAROVKA OFF, ZAROVKA ON i MOTOR ON, ZAROVKA ON
int pwm_motor_on = 0;
int pwm_motor_counter = 0;
int pwm_bulb_on = 0;
int pwm_bulb_counter = 0;
int pwm_buzzer_on = 0;
int open_door_mask = 0x6F; // Otevreni dvirek
char pressedKey;

int displayDelayCounter = 0; // Časovač pro zobrazení
int segmentDelayCounter = 0; // Časovač pro aktivovani segmentu
int position = 0;
int displayOn = 0;
int segmentOn = 0;

int tmp; // Proměnná tmp
int i; // Proměnná i

/*/ Simulace
void printIntToChar(char key) {
	printf("\r\n%c", key);
}
/*/

// Funkce pro konverzi znaku na cislo pro displej
int getChar(char wantedChar) {
	switch (wantedChar) {
		case ('1' || 1):
			return 0x01;
		case '2':
			return 0x02;
		case '3':
			return 0x03;
		case '4':
			return 0x04;
		case '5':
			return 0x05;
		case '6': 
			return 0x06;
		case '7':
			return 0x07;
		case '8':
			return 0x08;
		case '9':
			return 0x09;
		case '0':
			return 0x00;
		case 'A':
			return 0x0A;
		case 'B':
			return 0x0B;
		case 'C':
			return 0x0C;
		case 'D':
			return 0x0D;
		case 'E':
			return 0x0E;
		case 'F':
			return 0x0F;
		case 'G':
			return 0x10;
		case 'H':
			return 0x11;
		case 'J':
			return 0x12;
		case 'L':
			return 0x13;
		case 'N':
			return 0x14;
		case 'n':
			return 0x15;
		case 'O':
			return 0x00;
		case 'P':
			return 0x16;
		case 'R':
			return 0x17;
		case 'T':
			return 0x18;
		case 'U':
			return 0x19;
		case 'Y':
			return 0x1A;
		case '.':
			return 0x1C;
	}
	return 0x00;
}


// Obsluha tlačítek a displeje
void controlDisplayBtns(void) {
	if (position < 4) {
		if (segmentOn) {
			outportb(P1OUT, segments_masks[position]);	// Přečtení tlačítka
			outportb(P2OUT, dispData[position]);	// Odeslání symbolu na displej
			if (segmentDelayCounter > 0) segmentDelayCounter--; else segmentOn = 0;
		} else {
			tmp = inportb(P3IN);
			if ((tmp &= door_btn_masks[1]) == 1) btnPressed = i+1;
			
			position++;
			segmentOn = 1;
			segmentDelayCounter = 2;
		}
	} else position = 0;
}


// PWM - otaceni motoru
void PWM_motor(void) {
	if (pwm_motor_on) {
		tmp = pwmMasks[1];
		if (pwm_motor_counter > 0) pwm_motor_counter--; 
		else {
			pwm_motor_on = 0;
			pwm_motor_counter = shift_motor;
		}
	} else {
		tmp = pwmMasks[0];
		pwm_motor_on = 1;
	}

	outportb(P1OUT, tmp);
}

// PWM - sviceni zarovky
void PWM_bulb(void) {
	if (pwm_bulb_on) {
		tmp = pwmMasks[1];
		if (pwm_bulb_counter > 0) pwm_bulb_counter--;
		else {
			pwm_bulb_on = 0;
			pwm_bulb_counter = shift_bulb;
		}
	} else {
		if (tmp == pwmMasks[0]) tmp = pwmMasks[2];
		else tmp = pwmMasks[3];

		tmp = pwmMasks[2];
		pwm_bulb_on = 1;
	}
	outportb(P1OUT, tmp);
}

void PWM_buzzer(void) {
	if (pwm_buzzer_on) {
		pwm_buzzer_on = 0;

		// Dodelat masku pro buzzer on
		//tmp = pwmMasks[0];
		//outportb(P1OUT, tmp);
	} else {
		pwm_buzzer_on = 1;

		// Dodelat masku pro buzzer off
		//tmp = pwmMasks[1];
		//outportb(P1OUT, tmp);
	}
}


// Kontrola stavu dvirek
int checkDoor(void) {
	tmp = inportb(P3IN);

	if ((tmp &= door_btn_masks[0]) == 1) return 0;
	else return 1;
}

// Otevreni dvirek
void openDoor(void) {
	printf("\n\rDvirka mirkovlnky otevreny!");
	outportb(P1OUT, open_door_mask);
}

// IDK asi test
void inActivePort(int portNumber) {
	if (portNumber == 1) outportb(P1OUT, 0x7F);
}

// Kontrola stavu klavesnice u PC
void checkKeyboard(void) {
	if (kbhit())
	{
		pressedKey = getch();
		if (pressedKey == 'w') {
			if (shift_motor <= 50 && shift_motor >= 10) {
				shift_motor -= 5;
				printf("\n\r\n\rRychlost otaceni zvysena o 10%");
				printf("\n\rAktualni rychlost: %i%", 110-shift_motor*2);
				printf("\n\rAktualni strida: %ims", shift_motor);
			} else printf("\n\r!! Nelze zvysit rychlost otaceni !!");
		} 
		if (pressedKey == 's') {
			if (shift_motor <= 45 && shift_motor >= 5) {
				shift_motor += 5;
				printf("\n\r\n\rRychlost otaceni snizena o 10%");
				printf("\n\rAktualni rychlost: %i%", 110-shift_motor*2);
				printf("\n\rAktualni strida: %ims", shift_motor);
			} else printf("\n\r!! Nelze snizit rychlost otaceni !!");
		}
	}
}


// Hlavní cyklus programu, delta T = +-1ms
int main()
{
	int a = 0;
	int b = 0;
	int c = 0;

	printf("\n\r[##################################################]");
	printf("\n\r Zapinani programu Mikrovlnka, vytvoril Jakub Tenk");
	delay(450);
	printf("\n\r[--------------------------------------------------]");
	printf("\n\r Zakladni ovladani: ");
	printf("\n\r   Stisk klavesy W nebo w  ->  zvysi rychlost otaceni talire o 10% ");
	printf("\n\r   Stisk klavesy S nebo s  ->  snizi rychlost otaceni talire o 10% ");
	printf("\n\r   Stisk klavesy Q nebo q  ->  ukonci program ");
	printf("\n\r[--------------------------------------------------]");
	delay(450);
	printf("\n\r Cekani na interakci uzivatele s mikrovlnkou.");
	printf("\n\r[##################################################]\n\r");


	while(pressedKey != 'q' && pressedKey != 'Q') {	
		// Zjišteni stavu dvířek
		doorState = checkDoor();
		// Obsluha tlačítek a displeje
		controlDisplayBtns();
		// Zjištění stavu klávesnice
		checkKeyboard();


		if (doorState == 0) {

			// Obsluha/nastavení mikrovlnky
			switch(state) {
				case 0: // Základní stav
					// Nastavení slova ZAPn na displeji
					dispData[0] = getChar('.');
					dispData[1] = getChar('H');
					dispData[2] = getChar('I');
					dispData[3] = getChar('.');

					// Vynulovani casu
					realTime = 0;
					a = 0;
					b = 0;
					c = 0;
					// POSTUP DO NASTAVENI CASU
					if (btnPressed == 1) {
						printf("\n\rPrechod na nastaveni doby ohrevu!");
						btnPressed = 0;
						state++;
					}

					// Otevreni dveri
					if (btnPressed == 4) {
						openDoor();						
						btnPressed = 0;
					}

					break;
				case 1: // STAV NASTAVENI CASU         DISP1:  DISP2:  DISP3:  DISP4:
					// CAS++
					if (btnPressed == 2 && c < 9) {

						if (a < 10) a++;
						else if (b < 10) {
							b++;
							a = 0;
						} else if (c < 10) {
							c++;
							b = 0;
							a = 0;
						}
					}

					// CAS--
					if (btnPressed == 3 && a > 1) {

						if (a > 0) a--;
						else if (b > 0) {
							b--;
							a = 9;
						} else if (c > 0) {
							c--;
							b = 9;
							a = 9;
						}
					}

					dispData[0] = getChar('0');
					dispData[1] = getChar(48+a);
					dispData[2] = getChar(48+b);
					dispData[3] = getChar(48+c);

					// POTVRZENI CASU -> POKRACUJE NA NASTAVENI TEPLOTY (STATE = 2)
					if (btnPressed == 1) {
						printf("\n\rNastavena doba ohrevu byla potvrzena, presun na nastaveni teploty.");
						realTime = (a+b*10+c*100)*1000; // Realny cas v ms
						state++;
					}

					// ZRUSENI OPERACE -> POKRACUJE NA ZACATEK (STATE = 0)
					if (btnPressed == 4) {
						printf("\n\rNastavovani doby ohrevu bylo zruseno, mikrovlnka ceka na interakci s uzivatelem.");
						state--;
					}

					break;
				case 2: // STAV NASTAVENI TEPLOTY
					// temp++
					if (btnPressed == 2 && tempCounter > 1) {
						tempCounter--;
					}

					// temp--
					if (btnPressed == 3 && tempCounter < 3) {
						tempCounter++;
					}

					switch(tempCounter) {
						case 1: // Vypis HIGH
							dispData[0] = getChar('H');
							dispData[1] = getChar('I');
							dispData[2] = getChar('G');
							dispData[3] = getChar('H');
							shift_bulb = 5;
							break;
						case 2: // Vypis MED
							dispData[0] = getChar('N');
							dispData[1] = getChar('N');
							dispData[2] = getChar('E');
							dispData[3] = getChar('D');
							shift_bulb = 15;
							break;
						case 3: // Vypis LOW
							dispData[0] = getChar('L');
							dispData[1] = getChar('O');
							dispData[2] = getChar('U');
							dispData[3] = getChar('U');
							shift_bulb = 25;
							break;
					}

					// POTVRZENI TEPLOTY -> POKRACUJE NA SPUSTENI PROCESU OHREVU (STATE = 3)
					if (btnPressed == 1) {
						printf("\n\rNastavena teplota byla potvrzena, zacina ohrev pokrmu.");
						tempCounter = tempCounter * 10 + 50;
						state++;
					}

					// ZRUSENI OPERACE -> POKRACUJE NA ZACATEK (STATE = 0)
					if (btnPressed == 4) {
						printf("\n\rNastavovani teploty bylo zruseno, mikrovlnka ceka na interakci s uzivatelem.");
						state = 0;
					}
					break;
				case 3: // STAV PROCESU OHREVU
					if (realTime > 0) {
						if (btnPressed == 4) {
							realTime = 0;
							state = 0;
						}

						realTime -= 1;
						PWM_motor();
						PWM_bulb();

						if ((realTime % 1000) == 0) {
							tmp = realTime / 1000; // 30000ms => 30sec .... 10000ms => 10sec

							printf("\n\rZbyvajici cas ohrevu je %i sekund.", tmp);
						
							if (a > 0) a--;
							else if (b > 0) {
								b--;
								a = 9;
							} else if (c > 0) {
								c--;
								b = 9;
								a = 9;
							}

							dispData[0] = getChar('0');
							dispData[1] = getChar(48+a);
							dispData[2] = getChar(48+b);
							dispData[3] = getChar(48+c);
						}

					} else {
						realTime = 2000;
						state = 4;
					}

					break;
				case 4: // STAV ZKONCENI PROCESU OHREVU (PIPANI A VYPIS GOOD)
					dispData[0] = getChar('G');
					dispData[1] = getChar('O');
					dispData[2] = getChar('O');
					dispData[3] = getChar('D');

					if (realTime > 0) {
						if (btnPressed == 4) {
							realTime = 0;
							state = 0;
						}
						realTime -= 1;
						if ((realTime % 500) == 0) {
							PWM_buzzer();
						}

					} else {
						realTime = 0;
						state = 0;
					}

					break;
			}
		} 
		else {
			// DVIRKA OTEVRENA, NA DISPLEJI TEXT OPEN
			inActivePort(1);
			state = 0;

			dispData[0] = getChar('O');
			dispData[1] = getChar('P');
			dispData[2] = getChar('E');
			dispData[3] = getChar('N');
		}

		delay(1); // Zajisti zpozdeni 1ms (tudiz delta T = +-1ms i s instrukcemi)
	}

	printf("\n\r\n\r[#############################]");
	printf("\n\r Vypinani programu Mikrovlnka");
	printf("\n\r[#############################]\n\r");
	delay(1000);
	return 0x00;
}

