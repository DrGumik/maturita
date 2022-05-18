// priklad pouziti cteni byte z portu
#include<stdio.h>
#include<dos.h>
#include<conio.h>

int main(void)
{
  unsigned char result;
  int port =  0x300; // cislo portu
  while(!kbhit())
  {
    result = inportb(port);
    printf("\n\rByte read from port 0x%X = 0x%X",port,result);
    // zapis vysledek na vystup
    outportb(port,result);
  }
  //while(!kbhit());
  return 0;
}