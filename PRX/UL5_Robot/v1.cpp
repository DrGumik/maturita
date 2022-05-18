/*
Zpracujte program v programovacím jazyce C ovládající robotickou ruku tak, aby obsahoval
nejméně tyto funkce:
1) ovládání pohybu jednotlivých pohybových os robota pomocí zvolených kláves klávesnice
počítače
2) hlídání mezních poloh pohybu robota (a to jak s využitím HW senzorů, tak i SW)
3) sledování chybových stavů
4) vhodná indikace stavu a polohy robotické ruky na monitoru počítače
*/

#include <stdio.h>
#include <dos.h>
#include <time.h>
#include <conio.h>
#include <ctype.h>

#define P1OUT 0x300
#define P3IN 0x300

int canMove(char pressedKey)
{
  // ZAPOJENI -> 0b0000_IR4_IR3_IR2_IR1
  int result = 0;
  
  int tmp = inport(P3IN);
  
  switch(tmp)
  {
    case 1:
      
      break;
    case 2:
      
      break;
    case 3:
      
      break;
    case 4:
      
      break;      
  }  
  
  return result;
}

void step(char pressedKey, int speed, int mode)
{
  /*
    P1OUT -> 0b00_KMITOCET_SMER_RAMENO-S-CHAPADLEM_CHAPADLO_HL-RAMENO_ZAKLADNA
    SMER -> Otaceni zaklady = log. 1 po smeru hod. ruc
            Hlavni rameno = log. 1 dolu
            Chapadlo = log. 1 zavrit
            Rameno s chapadlem = log. 1 nahoru    
    MODE -> 1 = posun hl. ramena
            2 = posun ramena s chapadlem
  */
  
  for(i = 0; i < speed; i++)
  {
    switch(pressedKey)
    {
      // Otaceni zakladny po/proti smeru hod. ruc.
      case 'a':
        outportb(P1OUT, 0b00110001);
        break;
      case 'b':
        outportb(P1OUT, 0b00100001);
        break;
      case 'w':
        if (mode == 1)
          outportb(P1OUT, 0b00100010);
        else if (mode == 2)
          outportb(P1OUT, 0b00111000);
        break;
      case 's':
        if (mode == 1)
          outportb(P1OUT, 0b00110010);
        else if (mode == 2)
          outportb(P1OUT, 0b00101000);
        break;
      case 'q':
        outportb(P1OUT, 0b00100100);
        break;
      case 'e':
        outportb(P1OUT, 0b00110100);
        break;
    }
  }
}

int main() 
{
  char pressedKey;
  int robotCoords = 0, speed = 1, mode = 1;
  
  printf("\x1B[2J\x1B[H"); // Vymazani obrazovky
	printf("\n\r[######################################################]");
	printf("\n\r Zapinani programu Robot NISA 600, vytvoril Jakub Tenk");
	printf("\n\r[------------------------------------------------------]");
	printf("\n\r Zakladni ovladani: ");
	printf("\n\r   Stisk klavesy W nebo w  ->  pohyb po svisle ose nahoru");
	printf("\n\r   Stisk klavesy S nebo s  ->  pohyb po svisle ose dolu");
	printf("\n\r   Stisk klavesy A nebo a  ->  pohyb po vodorovne ose do leva");
	printf("\n\r   Stisk klavesy D nebo d  ->  pohyb po vodorovne ose do prava");
	printf("\n\r   Stisk klavesy Q nebo q  ->  vypnuti programu");  
	printf("\n\r[------------------------------------------------------]");
	printf("\n\r Cekani na interakci uzivatele s robotem.");
	printf("\n\r[######################################################]");
  
  while(pressedKey != 'b')
  {
    if(kbhit())
      pressedKey = tolower(getch());
    
    switch(pressedKey)
    {
      case ('w' || 's' || 'a' || 'd' || 'q' || 'e'):
        if (canMove(pressedKey))
          step(pressedKey, speed, mode);
        else
          printf("\n\rRobot se nemuze pohnout, protoze dosahl maximalniho rozmeru pohybu");
          // IDK pak prepsat tuto hlasku
        
        break;
        
      case 'r':
        if (speed <= 5)
        {
          speed++;
          printf("\n\rRychlost zvysena o 20%, aktualni rychlost je %i%", speed*20);
        }
        else
          printf("\n\rVetsi rychlost nelze nastavit!");
        
        break;
        
      case 'f':
        if (speed > 1)
        {
          speed--;
          printf("\n\rRychlost snizena o 20%, aktualni rychlost je %i%", speed*20);
        }
        else
          printf("\n\rMensi rychlost nelze nastavit!");
        break;
        
      case ('1' || '+'):
        mode = 1;
        break;
        
      case ('2' || 'ě'):
        mode = 2;
        break;
        
      default:
        if(pressedKey != 'b')
          printf("\n\rKlavesa '%i%'neni podporovana!", pressedKey);
        break;   
          
    }
    
    pressedKey = '';
  }
  
  printf("\n\r\n\r[################################]");
  printf("\n\r Vypinani programu Robot NISA 600");
  printf("\n\r[################################]");
  
  return 0;
{
