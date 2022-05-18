/*
Alfanumerický displej
	Zpracujte program v programovacím jazyce C ovládající alfanumerický displej tak, aby obsahoval nejméně tyto funkce:
	1) volbu druhu displeje (7segmentový/14segmentový)
	2) zobrazení vhodně zvolené množiny znaků pro každý typ displeje
	3) vhodně zvolená datová a programová struktura
*/

#include <stdio.h>
#include <conio.h>
#include <time.h>
#include <ctype.h>

#define P1OUT 0x300

char text[10];
int outputData = 0;

// Prelozi pozadovany znak na hex. cislo, pro zadany displej (7/14 segmentovy)
int charToHex(int dispType, char wantedChar)
{
	if(dispType == 0) {
		switch(wantedChar)
		{
			case '0': return(0x3F);
			case '1': return(0x06);
			case '2': return(0x5B);
			case '3': return(0x4F);
			case '4': return(0x66);
			case '5': return(0x6D);
			case '6': return(0x7D);
			case '7': return(0x07);
			case '8': return(0x7F);
			case '9': return(0x6F);
			default: return(0x08);
		}
	}
	else {
		switch(wantedChar)
		{
			case 'A': return(0x1137);
			case 'B': return(0x054F);
			case 'C': return(0x0039);
			case 'D': return(0x044F);
			case 'E': return(0x1139);
			case 'F': return(0x1131);
			case 'G': return(0x013D);
			case 'H': return(0x1136);
			case 'I': return(0x0449);
			case 'J': return(0x001E);
			case 'K': return(0x12B0);
			case 'L': return(0x0038);
			case 'M': return(0x20B6);
			case 'N': return(0x2236);
			case 'O': return(0x003F);
			case 'P': return(0x1133);
			case 'Q': return(0x023F);
			case 'R': return(0x1333);
			case 'S': return(0x112D);
			case 'T': return(0x0441);
			case 'U': return(0x003E);
			case 'V': return(0x2206);
			case 'W': return(0x0A36);
			case 'X': return(0x2A80);
			case 'Y': return(0x2480);
			case 'Z': return(0x0889);
			case '0': return(0x003F);
			case '1': return(0x0006);
			case '2': return(0x111B);
			case '3': return(0x110F);
			case '4': return(0x1126);
			case '5': return(0x112D);
			case '6': return(0x113C);
			case '7': return(0x1981);
			case '8': return(0x113F);
			case '9': return(0x1127);
			default: return(0x3B80); // Znak hvezdicka
		}
	}
}


// Hodiny pro seriovy displej
void Clock()
{
	int dl = 0;
	for (dl = 0; dl < 3000; dl++);	// Cekame
		outputData |= 0x01;
	
	outportb(0x301, outputData);		// Nahodime Clock
	
	for (dl = 0; dl < 6000; dl++);	// Cekame
		outputData &= ~(0x01);
	
	outportb(0x301, outputData);     // Shodime Clock
	
	for (dl = 0; dl < 3000; dl++);    // Pockame
}

void Data(int d)                 // Funkce pro nastaveni datoveho bitu na hodnotu podle parametru
{
	if (d == 0) outputData &= ~(0x02);  // Kdyz ma byt nulovy, shod bit 1 na portu
	if (d == 1) outputData |= 0x02;  // Kdyz ma byt jednickovy, nahod bit 1 na portu
	outportb(0x301, outputData);      // Vystav hodnotu fyzicky na port
									 // Vytvor impuls na casovacim bitu (bit 0)
}

void serialWrite(int character, int dispType)
{
	if(dispType)
	{
		for (int i = 0; i < 15; i++)         // Smycka pro serializaci dolnich 15 bitu promenne digit
		{
			Data(character & 0x01);      // Maskovany LSB bit z digit a nastaveny jako DATA
			Clock();                   // Vyslani Clock impulsu
			character = character >> 1;      // Bitovy posun vpravo v promenne digit (posunuti na dalsi bit)
		}
	}
	else
	{
		for (int i = 0; i < 7; i++)          // Smycka pro serializaci dolnich 7 bitu promenne digit
		{
			if ((character & 0x01) != 0) 
				Data(1); 
			else 
				Data(0);	// Maskovany LSB bit z digit a nastaveny jako DATA

			Clock();                   // Vyslani Clock impulsu
			character = character >> 1;      // Bitovy posun vpravo v promenne digit (posunuti na dalsi bit)
		}
	}	
}

void startSerialWriting(int allowedNumOfChars, int dispType)
{
	printf("\n\r%s", text);

	if(dispType)
	{
		// START BIT
		Data(1);
		Clock();

		// 2 a 4 CHARACTER
		serialWrite(charToHex(dispType, text[1]), dispType);
		serialWrite(charToHex(dispType, text[3]), dispType);

		// PREPNUTI NA LEVY TRANZISTOR
		Data(0);
		Clock();
		Data(1);
		Clock();

		// VYPLN NEPOTREBNYCH BITU
		Data(1);
		Clock();
		Clock();
		Clock();

		// START BIT
		Data(1);
		Clock();

		// 1 a 3 CHARACTER
		serialWrite(charToHex(dispType, text[0]), dispType);
		serialWrite(charToHex(dispType, text[2]), dispType);

		// PREPNUTI NA PRAVY TRANZISTOR
		Data(1);
		Clock();
		Data(0);
		Clock();

		// VYPLN NEPOTREBNYCH BITU
		Data(1);
		Clock();
		Clock();
		Clock();
	}
	else
	{
		// START BIT
		Data(1);
		Clock();

		for(int i = 0; i < allowedNumOfChars; i++)
		{
			serialWrite(charToHex(dispType, text[i]), dispType);
		}
	}
}

int main()
{
  outport(P1OUT, 0x00);
	
  char pressedKey;
  int stateOfControl = 0, allowedNumOfChars = 5;
  int dispType = 0; // 0 = 7segmentovy, 1 = 14segmentovy

  printf("\x1B[2J\x1B[H");
  printf("\n\r[###########################################################]");
  printf("\n\r   Zapinani programu AlfaNum displej, vytvoril Jakub Tenk    ");
  printf("\n\r[-----------------------------------------------------------]");
  printf("\n\r Zakladni ovladani: ");
  printf("\n\r  Stisk klavesy TAB  ->  zmena typu displeje 7/14 segmentovy ");
  printf("\n\r  Stisk klavesy `    ->  zadavani textu / zobrazeni textu    ");
  printf("\n\r             (ASCII 96)                                      ");
  printf("\n\r[###########################################################]");
	
  while(pressedKey != 27)
  {
	pressedKey = 92;

	if (kbhit())
		pressedKey = getch();
	
	switch(pressedKey)
	{
	case 9:
		dispType = dispType ? 0 : 1;
		allowedNumOfChars = dispType ? 4 : 5;

		printf("\n\rZmenen typ displeje na: %s", dispType ? "14segmentovy" : "7segmentovy");
		printf("\n\rMaximalni pocet znaku pro zadavani textu: %d\n\r", allowedNumOfChars);
		break;
	case 96:
		if(stateOfControl)
		{
			stateOfControl = 0;

			printf("\n\rOdesilani textu na displej...");
			serialWrite(allowedNumOfChars, dispType);
			printf("\n\rOdeslani textu probehlo uspesne!\n\r");
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
