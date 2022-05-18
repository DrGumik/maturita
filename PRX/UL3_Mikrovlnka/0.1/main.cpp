#include <stdio.h>
#include <dos.h>
#include <time.h>

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

/*
	btnPressed = 1  ==> MODE
	btnPressed = 2  ==> sipka nahoru
	btnPressed = 3  ==> sipka dolu
	btnPressed = 4  ==> SET
*/

int main()
{
	while(true) {
		temp = inportb(0x301);
		doorState = temp & masks[1];

		if (doorState != 0) {
			// Obsluha tlačítek a displeje
			i = 0;
			for (int segment : positions) {
				i++;
				outportb(0x301, segment);	// Přečtení tlačítka
				temp = inportb(0x301);

				if ((temp & masks[3]) == 0) btnPressed = i;

				outportb(0x300, dispData[i-1]);	// Odeslání symbolu na displej
				delay(2);
			}

			// Obsluha/nastavení mikrovlnky
			switch(state)
				case 0: // DEFAULT STATE
					// Nastavení slova ZAPn na displeji
					i = 0;
					for (int data : onDisp) {
						dispData[i] = data;
						i++;
					}

					// POSTUP DO NASTAVENI TEMP
					if (btnPressed == 1) {
						btnPressed = 0;
						state++;
					}

					// Otevreni dveri
					if (btnPressed == 4) {
						temp = segment1 & maska_dvere
						outportb(0x301, )
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
						timeCounter*10 -> reálný čas
						tempCounter*10 -> reálná teplota
					*/

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

		void PWM() {
			
		}
	}
}


