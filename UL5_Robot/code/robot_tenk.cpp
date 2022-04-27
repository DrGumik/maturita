/* Dokumentace
  Zapojeni zavor (P3IN) dle bin. vzoru 0b0000_IR4_IR3_IR2_IR1
  Zapojeni vystupu (motoru, smeru, kmitoctu...) (P1OUT) dle bin. vzoru 0b00_KMITOCET_SMER_RAMENO-S-CHAPADLEM_CHAPADLO_HL-RAMENO_ZAKLADNA
  
  Dec. hodnoty pro posunuti motoru:
    ZAKLADNA - (<<) 30 ; 14 (>>)
    HL RAMENO - (UP) 13 ; 29 (DOWN)
    CHAPADLO - (<->) 11 ; 27 (>-<)
    RAMENO S CHAPADLEM - (UP) 23 ; 7 (DOWN)
  Smer otaceni:
    Otaceni zaklady = log. 1 po smeru hod. ruc
	  Hlavni rameno = log. 1 dolu
	  Chapadlo = log. 1 zavrit
	  Rameno s chapadlem = log. 1 nahoru
  MODE:
    1 = posun hl. ramena
	  2 = posun ramena s chapadlem
*/
#include <stdio.h>
#include <dos.h>
#include <time.h>
#include <conio.h>
#include <ctype.h>

#define P1OUT 0x300
#define P3IN 0x300

int canMove(char pressedKey, int mode)
{
  int result = 1;
  int data = ~inportb(P3IN);

  // Overi zda je dana zavora sepnuta ci rozepnuta dle toho vyhodnoti zda se robot muze pohnout do daneho smeru
  if (((data & 1) == 1) && (pressedKey == 'd')) // IR1 - zakladna
    result = 0;
  if (((data & 2) == 2) && (pressedKey == 'w') && (mode == 1)) // IR2 - hlavni rameno
    result = 0;
  if (((data & 4) == 4) && (pressedKey == 'w') && (mode == 2)) // IR3 - rameno s chapadlem
    result = 0;
  if (((data & 8) == 8) && (pressedKey == 'q')) // IR4 - chapadlo
    result = 0;

  // Pokud neni zadna zavora sepnuta, vrat 1
  result = data > 15 ? 1 : 0;

  return result;
}

void step(char pressedKey, int speed, int mode, int& robotCoordsX, int& robotCoordsY, int& robotCoordsRotateDegree)
{
  int data = 0; // Data, kde se doplni jaky motor se ma pohybovat a jakym smerem
  const int baseDataToggleOn = 32; // Zakladni vzor pro pohyb (0b001 + data)
  const int baseDataToggleOff = 0; // Zakladni vzor pro zastaveni (0b000 + data)

  const int motorBaseClockwise = 30; // Data pro jednotlive motory
  const int motorBaseAntiClockwise = 14;
  const int motorMainArmUp = 13;
  const int motorSecondArmUp = 23;
  const int motorMainArmDown = 29;
  const int motorSecondArmDown = 7;
  const int motorHandOpen = 11;
  const int motorHandClose = 27;

  // Dle zmackle klavesnice nahraje hodnotu do promenne data a posune se na souradnicich
  switch(pressedKey)
  {
    case 'a':
      robotCoordsRotateDegree++;

      data = motorBaseClockwise;
      break;
    case 'd':
      robotCoordsRotateDegree--;

      data = motorBaseAntiClockwise;
      break;
    case 'w':
      robotCoordsY++;
      robotCoordsX++;

      data = mode == 1 ? motorMainArmUp : motorSecondArmUp;
      break;
    case 's':
      robotCoordsY--;
      robotCoordsX--;

      data = mode == 1 ? motorMainArmDown : motorSecondArmDown;
      break;
    case 'q':
      data = motorHandOpen;
      break;
    case 'e':
      data = motorHandClose;
      break;
  }

  // Odesilani hodnot na port P1OUT (10x kroku motoru pri jednom zmacknuti klavesy, rychlost pohybu udava promenna speed)
  for (int i = 0; i < 10; i++)
  {
    outportb(P1OUT, baseDataToggleOn+data);
    delay(speed);
    outportb(P1OUT, baseDataToggleOff+data);
    delay(speed);
  }
}

int main()
{
  char pressedKey;
  int robotCoordsX = 0, robotCoordsY = 0, robotCoordsRotateDegree = 0, speed = 1, mode = 1, startState = 1;

  // Vymazani obrazovky + vypis zakladnich informaci k ovladani 
  printf("\x1B[2J\x1B[H");
  printf("\n\r[######################################################]");
  printf("\n\r Zapinani programu Robot NISA 600, vytvoril Jakub Tenk");
  printf("\n\r[------------------------------------------------------]");
  printf("\n\r Zakladni ovladani: ");
  printf("\n\r   Stisk klavesy W nebo w  ->  pohyb po svisle ose nahoru");
  printf("\n\r   Stisk klavesy S nebo s  ->  pohyb po svisle ose dolu");
  printf("\n\r   Stisk klavesy A nebo a  ->  pohyb po vodorovne ose po smeru hod. rucicek");
  printf("\n\r   Stisk klavesy D nebo d  ->  pohyb po vodorovne ose proti smeru hod. rucicek");
  printf("\n\r   Stisk klavesy Q nebo q  ->  otevreni chapadla");
  printf("\n\r   Stisk klavesy E nebo e  ->  zavreni chapadla");
  printf("\n\r   Stisk klavesy R nebo r  ->  zvyseni rychlosti pohybu");
  printf("\n\r   Stisk klavesy F nebo f  ->  snizeni rychlosti pohybu");
  printf("\n\r   Stisk klavesy 1         ->  prepnuti modu pro posun hl. ramena");
  printf("\n\r   Stisk klavesy 2         ->  prepnuti modu pro posun ramena s chapadlem");
  printf("\n\r   Stisk klavesy B nebo b  ->  vypnuti programu");
  printf("\n\r[------------------------------------------------------]");
  printf("\n\r Serizovani robota do startovaciho bodu...");
  printf("\n\r[------------------------------------------------------]");

  // Pri startu programu najede robot do zakladniho bodu, pokud se stlaci klavesa B tak se cely program zastavi
  while(startState && pressedKey != 'b') {
    if(kbhit())
      pressedKey = tolower(getch());

    if (canMove('w', 1))
      step('w', speed, 1, robotCoordsX, robotCoordsY, robotCoordsRotateDegree);
    if (canMove('w', 2))
      step('w', speed, 2, robotCoordsX, robotCoordsY, robotCoordsRotateDegree);
    if (canMove('q', 1))
      step('q', speed, 1, robotCoordsX, robotCoordsY, robotCoordsRotateDegree);
    if (canMove('d', 1))
      step('d', speed, 1, robotCoordsX, robotCoordsY, robotCoordsRotateDegree);

    if (!canMove('w', 2) && !canMove('w', 1) && !canMove('q', 1) && !canMove('d', 1))
    {
      startState = 0, robotCoordsX = 0, robotCoordsY = 0, robotCoordsRotateDegree = 0;
      printf("\n\r Robot uspesne serizen do startovaciho bodu!");
      printf("\n\r Aktualni poloha robota: X: %i, Y: %i, STUP: %i", robotCoordsX, robotCoordsY, robotCoordsRotateDegree);
      printf("\n\r[######################################################]");
    }
  }

  // Hlavni program
  while(pressedKey != 'b')
  {
    pressedKey = ' ';

    if(kbhit())
      pressedKey = tolower(getch());

    switch(pressedKey)
    {
      case 'r': // Zvysovani rychlosti
        if (speed > 1)
        {
          speed--;
          printf("\n\rRychlost zvysena na %i %", (11-speed)*10);
        }
        else
          printf("\n\rVetsi rychlost nelze nastavit!");
        break;
      case 'f': // Snizovani rychlosti
        if (speed < 10)
        {
          speed++;
          printf("\n\rRychlost snizena na %i %", (11-speed)*10);
        }
        else
          printf("\n\rMensi rychlost nelze nastavit!");
        break;
      case '1':
        mode = 1; // Slouzi pro otaceni hlavniho ramena
        printf("\n\rPrepnut mod na ovladani hlavniho ramene.");
        break;
      case '2':
        mode = 2; // Slouzi pro otaceni ramena s chapadlem
        printf("\n\rPrepnut mod na ovladani ramene s chapadlem.");
        break;
      case 'b':
        break;
      default:
        if (pressedKey == 'w' || pressedKey == 's' || pressedKey == 'a' || pressedKey == 'd' || pressedKey == 'q' || pressedKey == 'e')
        {
          if (canMove(pressedKey, mode)) // Podminka zda se muze robot na dany smer pohybovat, pokud ano tak se pohne
            step(pressedKey, speed, mode, robotCoordsX, robotCoordsY, robotCoordsRotateDegree);
          else
            printf("\n\rNelze se pohybovat!");

          printf("\n\rAktualni poloha robota: X: %i, Y: %i, STUP: %i", robotCoordsX, robotCoordsY, robotCoordsRotateDegree);
        }
        else if (pressedKey != ' ')
          printf("\n\rKlavesa %i neni podporovana!", pressedKey);
        break;
    }
  }

  printf("\n\r\n\r[################################]");
  printf("\n\r Vypinani programu Robot NISA 600");
  printf("\n\r[################################]");
  delay(1000);

  return 0;
}
