#include <stdio.h>
#include <dos.h>
#include <time.h>
#include <conio.h>
#include <ctype.h>

#define P1OUT 0x300
#define P3IN 0x300

int canMove(char pressedKey, int mode)
{
  // ZAPOJENI -> 0b0000_IR4_IR3_IR2_IR1
  int result = 0;
  int tmp = inportb(P3IN);
  
  // Overi zda je dana zavora sepnuta ci rozepnuta dle toho vyhodnoti zda se robot muze pohnout do daneho smeru
  if ((tmp & 1) && (pressedKey == 'a' || pressedKey == 'd')) // IR1 - zakladna
    result = 1;
  if ((tmp & 2) && (pressedKey == 'w' || pressedKey == 's') && (mode == 1)) // IR2 - hlavni rameno
    result = 1;      
  if ((tmp & 4) && (pressedKey == 'w' || pressedKey == 's') && (mode == 2)) // IR3 - rameno s chapadlem
    result = 1;
  if ((tmp & 8) && (pressedKey == 'q' || pressedKey == 'e')) // IR4 - chapadlo
    result = 1;
  
  return result;
}

void step(char pressedKey, int speed, int mode, int& robotCoordsX, int& robotCoordsY)
{
  /*
    P1OUT -> 0b00_KMITOCET_SMER_RAMENO-S-CHAPADLEM_CHAPADLO_HL-RAMENO_ZAKLADNA
    (
      DEC:
        ZAKLADNA = <- 17 ; 1 ->
        HL RAMENO = 2 <- 2 ; 18 ->
        CHAPADLO = 4 <- 4 ; 20 ->
        RAMENO S CHAPADLEM = 8 <- 24 ; 8 ->

    )
    SMER -> Otaceni zaklady = log. 1 po smeru hod. ruc
            Hlavni rameno = log. 1 dolu
            Chapadlo = log. 1 zavrit
            Rameno s chapadlem = log. 1 nahoru    
    MODE -> 1 = posun hl. ramena
            2 = posun ramena s chapadlem
  */
  int tmp = 0;
  
  // Dle zmackle klavesnice nahraje hodnotu do promenne tmp
  switch(pressedKey)
  {
    case 'a':
      robotCoordsX += speed;
      tmp = 17;
      break;
    case 'd':
      robotCoordsX -= speed;
      tmp = 1;
      break;
    case 'w':
      robotCoordsY += speed;

      if (mode == 1)
        tmp = 2;
      else if (mode == 2)
        tmp = 24;
      break;
    case 's':
      robotCoordsY -= speed;
      
      if (mode == 1)
        tmp = 18;
      else if (mode == 2)
        tmp = 8;
      break;
    case 'q':
      tmp = 4;
      break;
    case 'e':
      tmp = 20;
      break;
  }

  // Odesilani hodnot na port P1OUT
  for (int i = 0; i < speed; i++)
  {
    outportb(P1OUT, 32+tmp); // Secteni hodnoty z tmp a 32 dle nadefinovani zapojeni = 0b00/KMITOCET/SMER/RAMENO_S_CHAPADLEM/CHAPADLO/HL_RAMENO/ZAKLADNA
    delay(2);
    outportb(P1OUT, 0+tmp);
    delay(2);
  }

}

int main() 
{
  char pressedKey;
  int robotCoordsX = 0, robotCoordsY = 0, speed = 1, mode = 1, start = 1;
  
  printf("\x1B[2J\x1B[H"); // Vymazani obrazovky
	printf("\n\r[######################################################]");
	printf("\n\r Zapinani programu Robot NISA 600, vytvoril Jakub Tenk");
	printf("\n\r[------------------------------------------------------]");
	printf("\n\r Zakladni ovladani: ");
	printf("\n\r   Stisk klavesy W nebo w  ->  pohyb po svisle ose nahoru");
	printf("\n\r   Stisk klavesy S nebo s  ->  pohyb po svisle ose dolu");
	printf("\n\r   Stisk klavesy A nebo a  ->  pohyb po vodorovne ose do leva");
	printf("\n\r   Stisk klavesy D nebo d  ->  pohyb po vodorovne ose do prava");
	printf("\n\r   Stisk klavesy Q nebo q  ->  otevreni chapadla");  
	printf("\n\r   Stisk klavesy E nebo e  ->  zavreni chapadla");   
	printf("\n\r   Stisk klavesy B nebo b  ->  vypnuti programu");  
	printf("\n\r[------------------------------------------------------]");
	printf("\n\r Cekani na interakci uzivatele s robotem.");
  printf("\n\r Aktualni poloha robota: X: %i, Y: %i", robotCoordsX, robotCoordsY);
	printf("\n\r[######################################################]");

  // Pri startu programu najede robot do zakladni polohy  
  while(start) {
    if (canMove('d', 1))
      step('d', 1, 1, robotCoordsX, robotCoordsY);
    if (canMove('s', 1))
      step('s', 1, 1, robotCoordsX, robotCoordsY);
    if (canMove('s', 2))
      step('s', 1, 2, robotCoordsX, robotCoordsY);
    if (canMove('e', 1))
      step('e', 1, 1, robotCoordsX, robotCoordsY);

    if (canMove('d', 1) && canMove('s', 1) && canMove('s', 2) && canMove('e', 1))
      start = 0;
  }
  
  // Hlavni program
  while(pressedKey != 'b')
  {
    pressedKey = '0';

    if(kbhit())
      pressedKey = tolower(getch());
    
    switch(pressedKey)
    {        
      case 'r': // Zvysovani rychlosti
        if (speed < 5)
        {
          speed++;
          printf("\n\rRychlost zvysena na %i %", speed*20);
        }
        else
          printf("\n\rVetsi rychlost nelze nastavit!");
        break;
      case 'f': // Snizovani rychlosti
        if (speed > 1)
        {
          speed--;
          printf("\n\rRychlost snizena na %i %", speed*20);
        }
        else
          printf("\n\rMensi rychlost nelze nastavit!");
        break;
      case '1':
        mode = 1; // Slouzi pro otaceni hlavniho ramena
        printf("\n\rPrepnut mod na ovladani osy Y hlavniho ramene.");
        break;
      case '2':
        mode = 2; // Slouzi pro otaceni ramena s chapadlem
        printf("\n\rPrepnut mod na ovladani osy Y ramene s chapadlem.");
        break;
      default:
        if (pressedKey == 'w' || pressedKey == 's' || pressedKey == 'a' || pressedKey == 'd' || pressedKey == 'q' || pressedKey == 'e')
        {
          printf("\x1B[2J\x1B[H"); // Vymazani obrazovky

          if (canMove(pressedKey, mode)) // Podminka zda se muze robot na dany smer pohybovat, pokud ano tak se pohne
            step(pressedKey, speed, mode, robotCoordsX, robotCoordsY);
          else
            printf("\n\rNelze se pohybovat!");
          
          printf("\n\rAktualni poloha robota: X: %i, Y: %i", robotCoordsX, robotCoordsY);
        }
        else if (pressedKey != '0')
          printf("\n\rKlavesa %i neni podporovana!", pressedKey);
        break;
    }
    delay(100);
  }
  
  printf("\n\r\n\r[################################]");
  printf("\n\r Vypinani programu Robot NISA 600");
  printf("\n\r[################################]");
  delay(1000);
  
  return 0;
}
