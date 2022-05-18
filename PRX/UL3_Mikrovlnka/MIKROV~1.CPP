#include <stdio.h>
#include <dos.h>
#include <time.h>
#include <conio.h>

#define P2OUT 0x301
#define P4IN 0x301
#define P1OUT 0x300
#define P3IN 0x300

int dispData[4] = { 0x02, 0x0A, 0x16, 0x14 }; // Data pro displej
int onDisp[4] = { 0x02, 0x0a, 0x16, 0x14 }; // Text "ZAPN" pro displej
int openedDoorDisp[4] = { 0x00, 0x18, 0x0E, 0x19 }; // Text "OTEV" pro displej
int tempDisp[12] = { 0x11, 0x01, 0x10, 0x11, 0x14, 0x14, 0x0E, 0x0D, 0x13, 0x00, 0x19, 0x19 }; // text "HIGH", "MED", "LOW" pro displej

int counterData[11][4] = {
	{ 0x00, 0x00, 0x00, 0x00 }, // 0sec
	{ 0x00, 0x00, 0x03, 0x00 }, // 30sec
	{ 0x00, 0x00, 0x06, 0x00 }, // 60sec
	{ 0x00, 0x00, 0x09, 0x00 }, // 90sec
	{ 0x00, 0x01, 0x02, 0x00 }, // 120sec
	{ 0x00, 0x01, 0x05, 0x00 }, // 150sec
	{ 0x00, 0x01, 0x08, 0x00 }, // 180sec
	{ 0x00, 0x02, 0x01, 0x00 }, // 210sec
	{ 0x00, 0x02, 0x04, 0x00 }, // 240sec
	{ 0x00, 0x02, 0x07, 0x00 }, // 270sec
	{ 0x00, 0x03, 0x00, 0x00 }  // 300sec
};

int state = 0; // Stav programu
int doorState = 0; // Stav dveří
int timeCounter = 0; // Real time se počíta timerCounter*10
int tempCounter = 3; // Real tmp se počíta tempCounter*10
int realTime; // Reálný nastavený čas
int realTemp; // Reálná nastavená teplota
int btnPressed = 0; // Stav tlačítka
int shift_motor = 80; // Střída PWMka motoru
int tmp; // Proměnná tmp
int i; // Proměnná i
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

	int door_btn_masks[2] = { 0x02, 0x01 }; // Masky - dveře senzor, btn
	int segments_masks[4] = { 0x7E, 0x7D, 0x7B, 0x77 }; // 1. segment, 2. segment, 3. segment, 4. segment
	int pwmMasks[4] = { 0x5F, 0x7F, 0x1F, 0x3F }; // PWM masky - MOTOR ON, MOTOR OFF i ZAROVKA OFF, ZAROVKA ON i MOTOR ON, ZAROVKA ON
	int pwm_motor_on = 0;
	int pwm_motor_counter = 0;
	int pwm_bulb_on = 0;
	int pwm_bulb_counter = 0;
	int open_door_mask = 0x6F; // Otevreni dvirek
	int inactive_all_port = 0x7F; // Vypnuti celeho portu
	char pressedKey;

class Obsluha {
public:
	// Obsluha tlačítek a displeje
	void displejTlacitka(void) {
		//i = 0;
		int a;
		for (a=0; a<5; a++) {
			int segment = segments_masks[a];
			//i++;
			outportb(P1OUT, segment);	// Přečtení tlačítka
			delay(2);

			tmp = inportb(P3IN);
			if ((tmp &= door_btn_masks[1]) == 1) btnPressed = a+1;
			printf("TEST Tlacitka: %i", btnPressed);

			outportb(P2OUT, dispData[a]);	// Odeslání symbolu na displej
			delay(2);
		};
	};

	// PWM - otaceni motoru
	void PWM_motor(int pwm_motor_counter) {
		if (pwm_motor_on) {
			tmp = pwmMasks[1];
			if (pwm_motor_counter > 0) pwm_motor_counter--;
			else pwm_motor_on = 0;
		} else {
			tmp = pwmMasks[0];
			pwm_motor_on = 1;
		};
		outportb(P1OUT, tmp);
	};

	// PWM - sviceni zarovky
	void PWM_bulb(int pwm_bulb_counter) {
		if (pwm_bulb_on) {
			tmp = pwmMasks[1];
			if (pwm_bulb_counter > 0) pwm_bulb_counter--;
			else pwm_bulb_on = 0;
		} else {
			if (tmp == pwmMasks[0]) tmp = pwmMasks[2];
			else tmp = pwmMasks[3];

			tmp = pwmMasks[2];
			pwm_bulb_on = 1;
		};
		outportb(P1OUT, tmp);
	};

	// Proces vaření,  delta T = +-17ms
	void runProcess(int shift_motor, int shift_bulb, int realTime) {
		pwm_motor_counter = shift_motor / 10;
		pwm_bulb_counter = shift_bulb / 10;

		while (realTime > 0) {
			if (btnPressed == 4) {
				realTime = 0;
				state = 0;
			};

			if ((realTime % 1000) == 0) {
				tmp = realTime / 1000; // 30000ms => 30sec .... 10000ms => 10sec

				printf("\n\rZbyvajici cas ohrevu je %i sekund.", tmp);

				// Vymyslet algoritmus promitani casu
			};

			if (pwm_motor_counter <= 0) pwm_motor_counter = shift_motor / 10;
			if (pwm_bulb_counter <= 0) pwm_bulb_counter = shift_bulb / 10;

			displejTlacitka();
			PWM_motor(pwm_motor_counter);
			PWM_bulb(pwm_bulb_counter);
			delay(1);
			realTime -= 17;
		};
		state = 0;
	};

	int checkDoor(void) {
		tmp = inportb(P3IN);

		if ((tmp &= door_btn_masks[0]) == 1) {
			printf("\n\rKontrola dvirek: zavřené!");
			return 0;
		};
		else {
			printf("\n\rKontrola dvirek: otevřené!");
			return 1;
		};
	};

	void openDoor(void) {
		printf("\n\rDvirka mirkovlnky otevreny!");
		outportb(P1OUT, open_door_mask);
	};

	void inActivePort(int portNumber) {
		if (portNumber == 3) outportb(P1OUT, inactive_all_port);
	};

	void checkKeyboard(void) {
		if (kbhit())
		{
			pressedKey = getch();
			if (pressedKey == 'w') {
				if (shift_motor <= 95 && shift_motor >= 20) {
					shift_motor += 5;
					printf("\n\rRychlost otaceni zvysena o 5%");
					printf("\n\rAktualni rychlost: %i", shift_motor);
				}
				else printf("\n\rNelze zvysit rychlost otaceni!");
			}
			if (pressedKey == 's') {
				if (shift_motor <= 100 && shift_motor >= 20) {
					shift_motor = shift_motor - 5;
					printf("\n\rRychlost otaceni snizena o 5%");
					printf("\n\rAktualni rychlost: %i", shift_motor);
				} else printf("\n\rNelze snizit rychlost otaceni!");
			};

		};
	};

} Obsluha;

// Hlavní cyklus programu, delta T = +-16ms
int main()
{
	printf("\n\rCekani na interakci uzivatele s mikrovlnkou.");

	while (1) {
		// Zjišteni stavu dvířek
		doorState = Obsluha.checkDoor();
		// Obsluha tlačítek a displeje
		Obsluha.displejTlacitka();
		// Zjištění stavu klávesnice
		Obsluha.checkKeyboard();


		if (doorState == 0) {

			// Obsluha/nastavení mikrovlnky
			switch (state)
			{
				case 0: // Základní stav
					// Nastavení slova ZAPn na displeji
					i = 0;
					for (i=0; i<4; i++) {
						dispData[i] = onDisp[i];
						i++;
					}

					// POSTUP DO NASTAVENI CASU
					if (btnPressed == 1) {
						printf("\n\rNastaveni doby ohrevu!");
						btnPressed = 0;
						state++;
					}

					// Otevreni dveri
					if (btnPressed == 4) {
						Obsluha.openDoor();
						btnPressed = 0;
					}

					break;
				case 1: // STAV NASTAVENI CASU
					// CAS++
					if (btnPressed == 2 && timeCounter < 11) {
						timeCounter++;
						realTime += 30;

						// Nastaví daný čas na displeji
						i = 0;
						for (i=0; i<4; i++) {
							dispData[i] = counterData[i][i];
						};
					};

					// CAS--
					if (btnPressed == 3 && timeCounter > 1) {
						timeCounter--;
						realTime -= 30;

						// Nastaví daný čas na displeji
						i = 0;
						for (int data : counterData[timeCounter]) {
							dispData[i] = data;
						};
					};

					// POTVRZENI CASU -> POKRACUJE NA NASTAVENI TEPLOTY (STATE = 2)
					if (btnPressed == 1) {
						printf("\n\rNastavena doba ohrevu byla potvrzena, presun na nastaveni teploty.");
						state++;
					};

					// ZRUSENI OPERACE -> POKRACUJE NA ZACATEK (STATE = 0)
					if (btnPressed == 4) {
						printf("\n\rNastavovani doby ohrevu bylo zruseno, mikrovlnka ceka na interakci s uzivatelem.");
						state--;
					};

					break;
				case 2: // STAV NASTAVENI TEPLOTY
					// temp++
					if (btnPressed == 2 && tempCounter > 1) {
						tempCounter--;
					};

					// temp--
					if (btnPressed == 3 && tempCounter < 3) {
						tempCounter++;
					};


					if (tempCounter == 1) { // Vypis HIGH
						dispData[0] = tempDisp[0];
						dispData[1] = tempDisp[1];
						dispData[2] = tempDisp[2];
						dispData[3] = tempDisp[3];
					};
					if (tempCounter == 2) { // Vypis MED
						dispData[0] = tempDisp[4];
						dispData[1] = tempDisp[5];
						dispData[2] = tempDisp[6];
						dispData[3] = tempDisp[7];
					};
					if (tempCounter == 3) { // Vypis LOW
						dispData[0] = tempDisp[8];
						dispData[1] = tempDisp[9];
						dispData[2] = tempDisp[10];
						dispData[3] = tempDisp[11];
					};

						// POTVRZENI TEPLOTY -> POKRACUJE NA SPUSTENI PROCESU OHREVU (STATE = 3)
						if (btnPressed == 1) {
							printf("\n\rNastavena teplota byla potvrzena, zacina ohrev pokrmu.");
							state++;
						};

						// ZRUSENI OPERACE -> POKRACUJE NA ZACATEK (STATE = 0)
						if (btnPressed == 4) {
							printf("\n\rNastavovani teploty bylo zruseno, mikrovlnka ceka na interakci s uzivatelem.");
							state = 0;
						};
						break;
				case 3: // STAV SPUSTENI PROCESU OHREVU
					realTime = realTime * 1000;
					tempCounter = tempCounter * 10 + 50;
					Obsluha.runProcess(shift_motor, tempCounter, realTime);
					break;
				};

				} else {
					// DVIRKA OTEVRENA, NA DISPLEJI TEXT OPEN
					Obsluha.inActivePort(1);
					state = 0;
					i = 0;
					for (i=0; i<4; i++) {
						dispData[i] = openedDoorDisp[i];
					};
				};

		};
	};
};
