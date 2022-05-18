/*
	clickedBtnPosition = 1  ==> MODE
	clickedBtnPosition = 2  ==> sipka nahoru
	clickedBtnPosition = 3  ==> sipka dolu
	clickedBtnPosition = 4  ==> SET

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

int door_btn_masks[2] = { 0x02, 0x01 }; // Masky - dvere senzor, btn
int segments_masks[4] = { 0x7E, 0x7D, 0x7B, 0x77 }; // 1. segment, 2. segment, 3. segment, 4. segment
int pwmMasks[4] = { 0x5F, 0x7F, 0x1F, 0x3F }; // PWM masky - MOTOR ON, MOTOR OFF i ZAROVKA OFF, ZAROVKA ON i MOTOR ON, ZAROVKA ON

// Funkce pro konverzi znaku na cislo pro displej
int getChar(char wantedChar) {
	switch (wantedChar) {
		case '1':
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
		default:
			return 0x00;
	}
}

void splitIntToThreeDigits(int number, int& digit1, int& digit2, int& digit3) {
    digit3 = number % 10;
    number /= 10;

    digit2 = number % 10;
    number /= 10;

    digit1 = number % 10;
    number /= 10;
}

// Obsluha tlačítek a displeje
int controlDisplayBtns(int clickedBtnPosition, int& segmentDelayCounter, int& isSegmentOn, int& position) {
	if (position < 4) {
		if (isSegmentOn) {
			outportb(P1OUT, segments_masks[position]);	// Přečtení tlačítka
			outportb(P2OUT, dispData[position]);	// Odeslání symbolu na displej

			if (segmentDelayCounter > 0) segmentDelayCounter--; else isSegmentOn = 0;
		} else {
			int tmp = inportb(P3IN);			
			position++;

			if ((tmp &= door_btn_masks[1]) == 1) clickedBtnPosition = position;

			isSegmentOn = 1;
			segmentDelayCounter = 2;
		}
	} else position = 0;

	return clickedBtnPosition;
}


// PWM - otaceni motoru
int toggleMotor(int shiftMotor, int isMotorOn, int& motorToggleCounter) {
	int tmp;

	if (isMotorOn) {
		tmp = pwmMasks[1];
		
		if (motorToggleCounter > 0) motorToggleCounter--; 
		else {
			isMotorOn = 0;
			motorToggleCounter = shiftMotor;
		}
	} else {
		tmp = pwmMasks[0];
		isMotorOn = 1;
	}

	outportb(P1OUT, tmp);

	return isMotorOn;
}

// PWM - sviceni zarovky
int toggleBulb(int shiftBulb, int isBulbOn, int isMotorOn, int& bulbToggleCounter) {
	int tmp;

	if (isBulbOn) {
		tmp = pwmMasks[1];
		
		if (bulbToggleCounter > 0) bulbToggleCounter--;
		else {
			isBulbOn = 0;
			bulbToggleCounter = shiftBulb;
		}
	} else {
		if (isMotorOn) tmp = pwmMasks[3];
		else tmp = pwmMasks[2];

		isBulbOn = 1;
	}

	outportb(P1OUT, tmp);

	return isBulbOn;
}

int toggleBuzzer(int isBuzzerOn) {
	int tmp;

	if (isBuzzerOn) {
		isBuzzerOn = 0;

		// Dodelat masku pro buzzer on
		//tmp = pwmMasks[0];
		//outportb(P1OUT, tmp);
	} else {
		isBuzzerOn = 1;

		// Dodelat masku pro buzzer off
		//tmp = pwmMasks[1];
		//outportb(P1OUT, tmp);
	}

	return isBuzzerOn;
}


// Kontrola stavu dvirek
int checkDoor(void) {
	int tmp = inportb(P3IN);

	if ((tmp &= door_btn_masks[0]) == 1) return 0;
	else return 1;
}

// Otevreni dvirek (maska 0x6F)
void openDoor(void) {
	printf("\n\rDvirka mirkovlnky otevreny!");
	outportb(P1OUT, 0x6F); 
}

// IDK asi test
void inActivePort(int portNumber) {
	if (portNumber == 1) outportb(P1OUT, 0x7F);
}

// Kontrola stavu klavesnice u PC
int checkKeyboard(int shiftMotor, char& pressedKey) {
	if (kbhit())
	{
		pressedKey = getch();
		switch (pressedKey) {
			case 'w':
				if (shiftMotor <= 50 && shiftMotor >= 10) {
					shiftMotor -= 5;
					printf("\n\r\n\rRychlost otaceni zvysena o 10%");
					printf("\n\rAktualni rychlost: %i%", 110-shiftMotor*2);
					printf("\n\rAktualni strida: %ims", shiftMotor);
				} else printf("\n\r!! Nelze zvysit rychlost otaceni !!");
				break;
			case 's':
				if (shiftMotor <= 45 && shiftMotor >= 5) {
					shiftMotor += 5;
					printf("\n\r\n\rRychlost otaceni snizena o 10%");
					printf("\n\rAktualni rychlost: %i%", 110-shiftMotor*2);
					printf("\n\rAktualni strida: %ims", shiftMotor);
				} else printf("\n\r!! Nelze snizit rychlost otaceni !!");
				break;
			default:
				printf("\n\r!! Stiskl jsi nepovolenou klavesu !!");
				break;
		}
	}

	return shiftMotor;
}


// Hlavní cyklus programu, delta T = +-1ms
int main()
{
	int settingsState = 0; // Stav programu
	int timeCounter = 0; // Counter casu
	int tempCounter = 3; // Counter teploty (3 moznosti teploty - HIGH, MED, LOW)
	int realTime; // Realny cas prepocitany z timeCounter

	int shiftMotor = 5; // Strida PWMka motoru, ze zacatku 5ms (100%)
	int isMotorOn = 0; // Stav motoru
	int motorToggleCounter = 0; // Counter pro zapinani/vypinani motoru

	int shiftBulb = 5; // Strida PWMka svetla, ze zacatku 5ms (100%)
	int isBulbOn = 0;
	int bulbToggleCounter = 0;
	
	int isBuzzerOn = 0; // Stav buzzeru

	int segmentDelayCounter = 0; // Counter pro zapinani/vypinani segmentu
	int isSegmentOn = 0;
	int position = 0;

	char pressedKey;


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
		int doorState = checkDoor();
		// Obsluha tlačítek a displeje
		int clickedBtnPosition = controlDisplayBtns(clickedBtnPosition, segmentDelayCounter, isSegmentOn, position);
		// Zjištění stavu klávesnice
		shiftMotor = checkKeyboard(shiftMotor, pressedKey);


		if (doorState == 0) {

			// Obsluha/nastavení mikrovlnky
			switch(settingsState) {
				case 0: // Základní stav
					// Nastavení slova ZAPn na displeji
					dispData[0] = getChar('.');
					dispData[1] = getChar('H');
					dispData[2] = getChar('I');
					dispData[3] = getChar('.');

					// Vynulovani casu
					realTime = 0;
					timeCounter = 0;
					// POSTUP DO NASTAVENI CASU
					if (clickedBtnPosition == 1) {
						printf("\n\rPrechod na nastaveni doby ohrevu!");
						clickedBtnPosition = 0;
						settingsState++;
					}

					// Otevreni dveri
					if (clickedBtnPosition == 4) {
						openDoor();						
						clickedBtnPosition = 0;
					}

					break;
				case 1: // STAV NASTAVENI CASU         DISP1:  DISP2:  DISP3:  DISP4:
					// CAS++
					if (clickedBtnPosition == 2 && timeCounter < 1000) {
						timeCounter += 10;
					}

					// CAS--
					if (clickedBtnPosition == 3 && timeCounter > 20) {
						timeCounter -= 10;
					}

					int digit1, digit2, digit3;
					splitIntToThreeDigits(timeCounter, digit1, digit2, digit3);
					
					dispData[0] = getChar('0');
					dispData[1] = getChar(48+digit1);
					dispData[2] = getChar(48+digit2);
					dispData[3] = getChar(48+digit3);

					// POTVRZENI CASU -> POKRACUJE NA NASTAVENI TEPLOTY (settingsState = 2)
					if (clickedBtnPosition == 1) {
						printf("\n\rNastavena doba ohrevu byla potvrzena, presun na nastaveni teploty.");
						realTime = timeCounter*1000; // Realny cas v ms
						settingsState++;
					}

					// ZRUSENI OPERACE -> POKRACUJE NA ZACATEK (settingsState = 0)
					if (clickedBtnPosition == 4) {
						printf("\n\rNastavovani doby ohrevu bylo zruseno, mikrovlnka ceka na interakci s uzivatelem.");
						settingsState--;
					}

					break;
				case 2: // STAV NASTAVENI TEPLOTY
					// temp++
					if (clickedBtnPosition == 2 && tempCounter > 1) {
						tempCounter--;
					}

					// temp--
					if (clickedBtnPosition == 3 && tempCounter < 3) {
						tempCounter++;
					}

					switch(tempCounter) {
						case 1: // Vypis HIGH
							dispData[0] = getChar('H');
							dispData[1] = getChar('I');
							dispData[2] = getChar('G');
							dispData[3] = getChar('H');
							shiftBulb = 5;
							break;
						case 2: // Vypis MED
							dispData[0] = getChar('N');
							dispData[1] = getChar('N');
							dispData[2] = getChar('E');
							dispData[3] = getChar('D');
							shiftBulb = 15;
							break;
						case 3: // Vypis LOW
							dispData[0] = getChar('L');
							dispData[1] = getChar('O');
							dispData[2] = getChar('U');
							dispData[3] = getChar('U');
							shiftBulb = 25;
							break;
					}

					// POTVRZENI TEPLOTY -> POKRACUJE NA SPUSTENI PROCESU OHREVU (settingsState = 3)
					if (clickedBtnPosition == 1) {
						printf("\n\rNastavena teplota byla potvrzena, zacina ohrev pokrmu.");
						tempCounter = tempCounter * 10 + 50;
						settingsState++;
					}

					// ZRUSENI OPERACE -> POKRACUJE NA ZACATEK (settingsState = 0)
					if (clickedBtnPosition == 4) {
						printf("\n\rNastavovani teploty bylo zruseno, mikrovlnka ceka na interakci s uzivatelem.");
						settingsState = 0;
					}
					break;
				case 3: // STAV PROCESU OHREVU
					if (realTime > 0) {
						if (clickedBtnPosition == 4) {
							realTime = 0;
							settingsState = 0;
						}

						realTime -= 1;
						isMotorOn = toggleMotor(shiftMotor, isMotorOn, motorToggleCounter);
						isBulbOn = toggleBulb(shiftBulb, isBulbOn, isMotorOn, bulbToggleCounter);

						if ((realTime % 1000) == 0) {
							int remainingTime = realTime / 1000; // 30000ms => 30sec .... 10000ms => 10sec

							printf("\n\rZbyvajici cas ohrevu je %i sekund.", remainingTime);
						
							int digit1, digit2, digit3;
							splitIntToThreeDigits(remainingTime, digit1, digit2, digit3);
							

							dispData[0] = getChar('0');
							dispData[1] = getChar(48+digit1);
							dispData[2] = getChar(48+digit2);
							dispData[3] = getChar(48+digit3);
						}

					} else {
						realTime = 2000;
						settingsState = 4;
					}

					break;
				case 4: // STAV ZKONCENI PROCESU OHREVU (PIPANI A VYPIS GOOD)
					dispData[0] = getChar('G');
					dispData[1] = getChar('O');
					dispData[2] = getChar('O');
					dispData[3] = getChar('D');

					if (realTime > 0) {
						if (clickedBtnPosition == 4) {
							realTime = 0;
							settingsState = 0;
						}
						realTime -= 1;
						if ((realTime % 500) == 0) {
							toggleBuzzer(isBuzzerOn);
						}

					} else {
						realTime = 0;
						settingsState = 0;
					}

					break;
			}
		} 
		else {
			// DVIRKA OTEVRENA, NA DISPLEJI TEXT OPEN
			inActivePort(1);
			settingsState = 0;

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

