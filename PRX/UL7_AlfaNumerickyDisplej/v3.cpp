/*
Alfanumerický displej
	Zpracujte program v programovacím jazyce C ovládající alfanumerický displej tak, aby obsahoval nejménì tyto funkce:
	1) volbu druhu displeje (7segmentový/14segmentový)
	2) zobrazení vhodnì zvolené množiny znakù pro každý typ displeje
	3) vhodnì zvolená datová a programová struktura

Zapojeni:
	P1OUT (0x300)  0 bit = CLK, 1 bit = DATA
*/

#include <stdio.h>
#include <conio.h>
#include <time.h>
#include <ctype.h>

#define P1OUT 0x300

char text[1000]; // Pole pro zadavany text s velkym nadimenzovanim
int outputData = 0; // Promenna s daty pro odesilani

// Prelozi pozadovany znak na hex. cislo, pro zadany displej (7/14 segmentovy)
int charToHex(int dispType, char wantedChar)
{
	if (dispType == 0) {
		switch (wantedChar)
		{
			case '0':
				return(0x3F);
			case '1':
				return(0x06);
			case '2':
				return(0x5B);
			case '3':
				return(0x4F);
			case '4':
				return(0x66);
			case '5':
				return(0x6D);
			case '6':
				return(0x7D);
			case '7':
				return(0x07);
			case '8':
				return(0x7F);
			case '9':
				return(0x6F);
			default:
				return(0x00);
		}
	}
	else 
	{
		switch (wantedChar)
		{
			case 'A':
				return(0x1137);
			case 'B':
				return(0x054F);
			case 'C':
				return(0x0039);
			case 'D':
				return(0x044F);
			case 'E':
				return(0x1139);
			case 'F':
				return(0x1131);
			case 'G':
				return(0x013D);
			case 'H':
				return(0x1136);
			case 'I':
				return(0x0449);
			case 'J':
				return(0x001E);
			case 'K':
				return(0x12B0);
			case 'L':
				return(0x0038);
			case 'M':
				return(0x20B6);
			case 'N':
				return(0x2236);
			case 'O':
				return(0x003F);
			case 'P':
				return(0x1133);
			case 'Q':
				return(0x023F);
			case 'R':
				return(0x1333);
			case 'S':
				return(0x112D);
			case 'T':
				return(0x0441);
			case 'U':
				return(0x003E);
			case 'V':
				return(0x2206);
			case 'W':
				return(0x0A36);
			case 'X':
				return(0x2A80);
			case 'Y':
				return(0x2480);
			case 'Z':
				return(0x0889);
			case '0':
				return(0x003F);
			case '1':
				return(0x0006);
			case '2':
				return(0x111B);
			case '3':
				return(0x110F);
			case '4':
				return(0x1126);
			case '5':
				return(0x112D);
			case '6':
				return(0x113C);
			case '7':
				return(0x1981);
			case '8':
				return(0x113F);
			case '9':
				return(0x1127);
			default:
				return(0x0000);
		}
	}
}


// Hodiny pro seriovy displej
void clock()
{
	// SW DELAY
	int delay = 0;
	
	for (delay = 0; delay < 3000; delay++);	// Delay - delay(1)
		outputData |= 0x01;

	outportb(P1OUT, outputData);		// Nahodime clock

	for (delay = 0; delay < 6000; delay++);	// Delay - delay(1)
		outputData &= 0xFE;

	outportb(P1OUT, outputData);     // Shodime clock

	for (delay = 0; delay < 3000; delay++);    // Delay - delay(1)
}

// Odesilani start-bitu / vyplne na seriovku
void writeCommonData(int data)
{
	if (data)
		outputData |= 0x02;
	else
		outputData &= 0xFD;

	outportb(P1OUT, outputData);
}

// Odesilani samotneho znaku na seriovku
void writeCharData(int character, int dispType)
{
	if (dispType)
	{
		for (int i = 0; i < 15; i++)			// Smycka pro serializaci dolnich 15 bitu promenne digit
		{
			writeCommonData(character & 0x01);  // Maskovany LSB bit z digit a nastaveny jako DATA
			clock();							// Vyslani clock impulsu
			character = character >> 1;			// Posunuti na dalsi bit daneho data (characteru)
		}
	}
	else
	{
		for (int i = 0; i < 7; i++)         // Smycka pro serializaci dolnich 7 bitu promenne digit
		{
			if ((character & 0x01) != 0)
				writeCommonData(1);
			else
				writeCommonData(0);			// Maskovany LSB bit z digit a nastaveny jako DATA

			clock();						// Vyslani clock impulsu
			character = character >> 1;     // Bitovy posun vpravo v promenne digit (posunuti na dalsi bit)
		}
	}
}

// Zahajeni odesilani (tato funkce resi kompletni odeslani dat)
int startSerialWriting(int allowedNumOfChars, int dispType)
{
	printf("\n\rVypisovani textu: %s", text);

	if (dispType)
	{
		// START BIT
		writeCommonData(1);
		clock();

		// 2 a 4 CHARACTER
		writeCharData(charToHex(dispType, text[1]), dispType);
		writeCharData(charToHex(dispType, text[3]), dispType);

		// PREPNUTI NA LEVY TRANZISTOR
		writeCommonData(0);
		clock();
		writeCommonData(1);
		clock();

		// VYPLN NEPOTREBNYCH BITU
		writeCommonData(1);
		clock();
		clock();
		clock();

		// START BIT
		writeCommonData(1);
		clock();

		// 1 a 3 CHARACTER
		writeCharData(charToHex(dispType, text[0]), dispType);
		writeCharData(charToHex(dispType, text[2]), dispType);

		// PREPNUTI NA PRAVY TRANZISTOR
		writeCommonData(1);
		clock();
		writeCommonData(0);
		clock();

		// VYPLN NEPOTREBNYCH BITU
		writeCommonData(1);
		clock();
		clock();
		clock();
	}
	else
	{
		// START BIT
		writeCommonData(1);
		clock();

		for (int i = 0; i < allowedNumOfChars; i++)
		{
			writeCharData(charToHex(dispType, text[i]), dispType);
		}
	}

	return 1;
}

// Hlavni funkce programu
int main()
{
	outport(P1OUT, 0x00);

	char pressedKey;
	int stateOfControl = 0, allowedNumOfChars = 5; // stav zda zadavame text nebo odesilame; maximalni delka displeje
	int dispType = 0; // 0 = 7segmentovy, 1 = 14segmentovy

	printf("\x1B[2J\x1B[H");
	printf("\n\r[###########################################################]");
	printf("\n\r   Zapinani programu AlfaNum displej, vytvoril Jakub Tenk    ");
	printf("\n\r[-----------------------------------------------------------]");
	printf("\n\r Zakladni ovladani: ");
	printf("\n\r  Stisk klavesy TAB  ->  zmena typu displeje 7/14 segmentovy ");
	printf("\n\r  Stisk klavesy `    ->  zadavani textu / odeslani textu     ");
	printf("\n\r             (ASCII 96)                                      ");
	printf("\n\r[###########################################################]");

	while (pressedKey != 27) // ESC
	{
		pressedKey = 92; // SPACE

		if (kbhit())
			pressedKey = getch();

		switch (pressedKey)
		{
		case 9: // TAB
			dispType = dispType ? 0 : 1;
			allowedNumOfChars = dispType ? 4 : 5;

			printf("\n\rZmenen typ displeje na: %s", dispType ? "14segmentovy" : "7segmentovy");
			printf("\n\rMaximalni pocet znaku pro zadavani textu: %d\n\r", allowedNumOfChars);
			break;
		case 96: // `
			if (stateOfControl)
			{
				int complete = 0;
				stateOfControl = 0;

				printf("\n\rOdesilani textu na displej...");
				complete = startSerialWriting(allowedNumOfChars, dispType);
				
				if(complete)
					printf("\n\rOdeslani textu probehlo uspesne!\n\r");
				else
					printf("\n\rPri odesilani textu doslo k chybe!\n\r");
			}
			else
			{
				stateOfControl = 1;

				printf("\n\rZadejte text: ");
				scanf("%5s", text);
			}

			break;
		}
	}
}