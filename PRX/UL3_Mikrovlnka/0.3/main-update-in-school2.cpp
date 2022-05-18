#include <stdio.h>
#include <dos.h>
#include <time.h>

#define P2OUT 0x300
#define P4IN 0x300
#define P1OUT 0x301
#define P3IN 0x301

int positions[4] = { 0x7F, 0xBF, 0xDF, 0xEF } // 1. pos - 2. pos - 3. pos - 4. pos
int masks[3] = { 0x40, 0xf7, 0x80 } // Masky - dveře senzor, otevření dveří, btn
int dispData[4] = { 0, 0, 0, 0 };
int onDisp[4] = { 0x02, 0x0a, 0x16, 0x15 };
int openDisp[4] = { 0x00, 0x18, 0x0E, 0x19 };
int counterData[11][4] = {
	{ 0x00, 0x00, 0x00, 0x00 }, // 0sec
	{ 0x00, 0x00, 0x01, 0x00 }, // 10sec
	{ 0x00, 0x00, 0x02, 0x00 }, // 20sec
	{ 0x00, 0x00, 0x03, 0x00 }, // 30sec
	{ 0x00, 0x00, 0x04, 0x00 }, // 40sec
	{ 0x00, 0x00, 0x05, 0x00 }, // 50sec
	{ 0x00, 0x00, 0x06, 0x00 }, // 60sec
	{ 0x00, 0x00, 0x07, 0x00 }, // 70sec
	{ 0x00, 0x00, 0x08, 0x00 }, // 80sec
	{ 0x00, 0x00, 0x09, 0x00 }, // 90sec
	{ 0x00, 0x01, 0x00, 0x00 }  // 100sec
}
int state, doorState = 0, 0;
int i;
int timeCounter; // Real time se počíta timerCounter*10
int tempCounter; // Real temp se počíta tempCounter*10
int realTime;
int realTemp;
int temp;
int btnPressed = 0;
int segmask = 0;

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

class Obsluha {
public:
	// Obsluha tlačítek a displeje
	void displejTlacitka() {
		i = 0;
		for (int segment : positions) {
			i++;

			temp = inportb(P3IN);
			segmask = temp & segment;

			outportb(P1OUT, segment);	// Přečtení tlačítka
			delay(2);
			temp = inportb(P3IN);

			if ((temp & masks[3]) == 0) btnPressed = i;

			outportb(P2OUT, dispData[i - 1]);	// Odeslání symbolu na displej
			delay(2);
		}
	}

	// PWM - otaceni motoru a sviceni
	void PWM(strida) {

	}

	// Proces vaření
	void runProcess() {

		while (realTime > 0) {
			if (btnPressed == 4) {
				realTime = 0;
				status = 0;
			}

			temp = realTime / 10 / 1000;
			switch(temp)
				case 1:
					for (int data : counterData[timeCounter]) {
						dispData[i] = data;
					}
					break;
				case 2:
					for (int data : counterData[timeCounter]) {
						dispData[i] = data;
					}
					break;
				case 3:
					for (int data : counterData[timeCounter]) {
						dispData[i] = data;
					}
					break;
				case 4:
					for (int data : counterData[timeCounter]) {
						dispData[i] = data;
					}
					break;
				case 5:
					for (int data : counterData[timeCounter]) {
						dispData[i] = data;
					}
					break;
				case 6:
					for (int data : counterData[timeCounter]) {
						dispData[i] = data;
					}
					break;
				case 7:
					for (int data : counterData[timeCounter]) {
						dispData[i] = data;
					}
					break;
				case 9:
					for (int data : counterData[timeCounter]) {
						dispData[i] = data;
					}
					break;
				case 10:
					for (int data : counterData[timeCounter]) {
						dispData[i] = data;
					}
					break;

			Obsluha.displejTlacitka(dispData);
			Obsluha.PWM(80);
			delay(1);
			realTime -= 1;
		} else {
			state = 0;
		}
	}
};

int main()
{
	while(1) {
		temp = inportb(P3IN);
		doorState = temp & masks[1];

		if (doorState != 0) {
			// Obsluha tlačítek a displeje
			Obsluha.displejTlacitka(dispData);

			// Obsluha/nastavení mikrovlnky
			switch(state)
				case 0: // DEFAULT STATE
					// Nastavení slova ZAPn na displeji
					i = 0;
					for (int data : onDisp) {
						dispData[i] = data;
						i++;
					}

					// POSTUP DO NASTAVENI CASU
					if (btnPressed == 1) {
						btnPressed = 0;
						state++;
					}

					// Otevreni dveri
					if (btnPressed == 4) {
						temp = inportb(P3IN);
						temp = temp & maska_dvere
						outportb(P1OUT, temp)
						btnPressed = 0;
					}

					break;
				case 1: // NASTAVENI CASU
					// Nastavení 0 na displeji
					i = 0;
					for (int data : counterData[0]) {
						dispData[i] = data;
						i++;
					}

					// CAS++
					if (btnPressed == 2 && timeCounter < 11) {
						timeCounter++;

						// Nastaví daný čas na displeji
						i = 0;
						for (int data : counterData[timeCounter]) {
							dispData[i] = data;
						}
					}

					// CAS--
					if (btnPressed == 3 && timeCounter > 1) {
						timeCounter--;

						// Nastaví daný čas na displeji
						i = 0;
						for (int data : counterData[timeCounter]) {
							dispData[i] = data;
						}
					}

					// POTVRZENI CASU -> POKRACUJE NA NASTAVENI TEPLOTY (STATE = 2)
					if (btnPressed == 1) {
						state++;
					}

					// ZRUSENI OPERACE -> POKRACUJE NA ZACATEK (STATE = 0)
					if (btnPressed == 4) {
						state--;
					}

					break;
				case 2: // NASTAVENI TEPLOTY
					// Nastavení 0 na displeji
					i = 0;
					for (int data : counterData[0]) {
						dispData[i] = data;
						i++;
					}

					// TEMP++
					if (btnPressed == 2 && tempCounter < 10) {
						tempCounter++;

						// Nastaví danou teplotu na displeji
						i = 0;
						for (int data : counterData[tempCounter]) {
							dispData[i] = data;
						}
					}

					// TEMP--
					if (btnPressed == 3 && tempCounter > 1) {
						tempCounter--;

						// Nastaví danou teplotu na displeji
						i = 0;
						for (int data : counterData[tempCounter]) {
							dispData[i] = data;
						}
					}

					// POTVRZENI TEPLOTY -> POKRACUJE NA SPUSTENI PROCESU OHREVU (STATE = 3)
					if (btnPressed == 1) {
						state++;
					}

					// ZRUSENI OPERACE -> POKRACUJE NA ZACATEK (STATE = 0)
					if (btnPressed == 4) {
						state = 0;
					}
					break;
				case 3: // SPUSTENI PROCESU OHREVU
					/* DATA
						timeCounter*10 -> reálný čas v ms
						tempCounter*10 -> reálná teplota
					*/
					realTime = timeCounter * 10*100;
					realTemp = tempCounter * 10;

					Obsluha.runProcess();

					break;

		}
		else {
			state = 0;
			// ZAVRIT DVERE TEXT NA DISP
			i = 0;
			for (int data : openDisp) {
				dispData[i] = data;
			}
		}
	}
}


