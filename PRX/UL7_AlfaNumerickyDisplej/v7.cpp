
/*
	P1OUT (0x300)  0 bit = DATA
	P3OUT (0x301)  0 bit = CLK
*/

#include <stdio.h>
#include <conio.h>
#include <time.h>
#include <ctype.h>
#include <dos.h>

#define P1OUT 0x300
#define P3OUT 0x301

char text[1000]; // Pole pro zadavany text s velkym nadimenzovanim

// Prelozi pozadovany znak na hex. cislo, pro zadany displej (7/14 segmentovy)
int charToHex(int dispType, char wantedChar)
{
	wantedChar = toupper(wantedChar);

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
void clk()
{
	outportb(P3OUT, 0x01);

	for (int time = 0; time < 5000; time++) // hack-fix
	{}

	outportb(P3OUT, 0x00);
}

// Odesilani start-bitu / vyplne na seriovku
void writeData(int data)
{
	int outputData = 0x00;

	outputData = data ? 0x01 : 0x00;

	outportb(P1OUT, outputData);
	clk();
}

// Odesilani samotneho znaku na seriovku
void writeCharData(int character, int dispType)
{
	int numOfCycles = 15;

	numOfCycles = dispType ? 15 : 7;

	for (int i = 0; i < numOfCycles; i++)
	{
		writeData(character);
		character = character >> 1;     	// Bitovy posun vpravo v promenne digit (posunuti na dalsi bit)
	}
}

// Zahajeni odesilani (tato funkce resi kompletni odeslani dat)
void startSerialWriting(int allowedNumOfChars, int dispType)
{
	if (dispType)
	{

		while (!kbhit())
		{
			// START BIT
			writeData(1);

			// Odesle znaky
			for (int i = 0; i < 4; i++)
				writeCharData(charToHex(dispType, text[i]), dispType);

			// Prepnuti tranzistoru (levy)
			writeData(0);
			writeData(1);
			
			// Vypln zbylich bitu (bit 33-36)
			for (i = 0; i < 4; i++)
				writeData(0);

			delay(1);

			// START BIT
			writeData(1);

			// Odesle znaky
			for (i = 0; i < 4; i++)
				writeCharData(charToHex(dispType, text[i]), dispType);

			// Prepnuti tranzistoru (pravy)
			writeData(1);
			writeData(0);
			
			// Vypln zbylich bitu (bit 33-36)
			for (i = 0; i < 4; i++)
				writeData(0);

			delay(1);
		}
	}
	else
	{
		// START BIT
		writeData(1);

		for (int i = 0; i < allowedNumOfChars; i++)
		{
			writeCharData(charToHex(dispType, text[i]), dispType);
		}
	}
}

// Hlavni funkce programu
int main()
{
	outport(P1OUT, 0x00);

	char pressedKey;
	int allowedNumOfChars = 5; // stav zda zadavame text nebo odesilame; maximalni delka displeje
	int dispType = 0; // 0 = 7segmentovy, 1 = 14segmentovy

	printf("\x1B[2J\x1B[H");
	printf("\n\r[###########################################################]");
	printf("\n\r   Zapinani programu AlfaNum displej, vytvoril Jakub Tenk    ");
	printf("\n\r[-----------------------------------------------------------]");
	printf("\n\r Zakladni ovladani: ");
	printf("\n\r  Stisk klavesy TAB  ->  zmena typu displeje 7/14 segmentovy ");
	printf("\n\r  Stisk klavesy `    ->  zadavani textu / odeslani textu     ");
	printf("\n\r  Stisk klavesy ESC  ->  vypnuti programu 					 ");
	printf("\n\r[###########################################################]\n\r");

	while (pressedKey != 27)
	{
		pressedKey = 92; // SPACE

		if (kbhit())
			pressedKey = getch();

		switch (pressedKey)
		{
		case 9: // Klavesa TAB
			dispType = dispType ? 0 : 1;
			allowedNumOfChars = dispType ? 4 : 5;

			printf("\n\rZmenen typ displeje na: %s", dispType ? "14segmentovy" : "7segmentovy");
			printf("\n\rMaximalni delka textu zmenen na: %d\n\r", allowedNumOfChars);
			break;
		case 96: // Klavesa `
			printf("\n\rZadejte text s maximalni delkou %d znaku:\n\r", allowedNumOfChars);

			scanf("%s", text);

			printf("\n\rOdesilani textu na displej...\n\r");

			startSerialWriting(allowedNumOfChars, dispType);

			printf("\n\rOdeslani textu probehlo uspesne!\n\r");

			break;
		}
	}

	printf("\n\r[######################################]");
	printf("\n\r   Vypinani programu AlfaNum displej    ");
	printf("\n\r[######################################]");

	delay(1000);

	return 0;
}