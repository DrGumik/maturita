; >>                     									  <<
; >>                       �loha �. 6						  <<
; >> Rozsv�cen� sekvence vzor� LED podle stisknut�ho tla��tka <<
; >> 				  Vytvo�il Jakub Tenk 					  <<
; >>                     									  <<

.nolist 					; >> Vypne debug
.include "m128def.inc"		; >> P�i�azen� jmen registru
.list 						; >> Zapne debug

.dseg
.org 0x200					; >> Intern� RAM - po��te�n� adresa

.cseg
.org 0x0000					; >> Za��tek pam�ti flash

.def poc_opak = R22			; >> Definov�n� prom�nn�ch (poc_opak, temp)
.def temp = R23

	ldi temp,LOW(RAMEND)	; >> Inicializace z�sobn�ku
	out SPL, temp
	ldi temp,HIGH(RAMEND)
	out SPH, temp

	ldi poc_opak, 32		; >> Nastaven� hodnoty po�tu opakov�n� na 32

	ldi XL, 0x00			; >> Nastaven� doln�ho bajtu adresy X
    ldi XH, 0x04			; >> Nastaven� horn�ho bajtu adresy X

	ldi R16, 0xFF			; >> Nastaven� portu B jako v�stupn� a portu D jako vstupn�
	ldi R17, 0x00
	out DDRB, R16
	out DDRD, R17
	ldi R16, 0b11111111		; >> Nastaven� hodnoty, kter� zhasne v�echny ledky do R16
	out PORTB, R16			; >> Odesl�n� hodnoty pro zhasnut� ledek na port B

	ldi ZL, LOW(tb_tlac<<1)	; >> Odk�z�n� ukazatele Z do programov� pam�ti na adresu, kde se nach�z� tb_tlac
	ldi ZH, HIGH(tb_tlac<<1)

load_tb:
	lpm R16, Z+				; >> P�esun hodnoty z pam�ti programu z adresy ulo�en� v registru Z do registru R16 s n�slednou inkrementac�
	st X+, R16				; >> Zkop�rov�n� hodnoty z R16 do datov� pam�ti na adresu ulo�enou v registru X s n�slednou inkrementac�
	dec poc_opak			; >> Sn�en� po�tu opakov�n� o 1
	brne load_tb			; >> Skok na n�v�t� load_tb pokud poc_opak > 0

main:
    ldi poc_opak,8			; >> Nastaven� hodnoty po�tu opakov�n� na 8
	ldi XL, 0x00			; >> Nastaven� doln�ho bajtu adresy X
    ldi XH, 0x04			; >> Nastaven� horn�ho bajtu adresy X	
	in R17, pinD			; >> P�e�ten� hodnoty z portu D a ulo�en� do R17
loop:
	ld R18, X+				; >> Zkop�rov�n� hodnoty z datov� pam�ti do registru R18 s n�slednou inkrementac�
	ld R19, X+				; >> Zkop�rov�n� hodnoty z datov� pam�ti do registru R19 s n�slednou inkrementac�
	ld R20, X+				; >> Zkop�rov�n� hodnoty z datov� pam�ti do registru R20 s n�slednou inkrementac�
	ld R21, X+				; >> Zkop�rov�n� hodnoty z datov� pam�ti do registru R21 s n�slednou inkrementac�
	mov R30, R19			; >> Odk�z�n� ukazatele Z do programov� pam�ti na adresu, kde se nach�z� dan� tabulka led vzor�
	mov R31, R20

	cp R17, R18				; >> Porovn�n� vstupn� hodnoty z portu D se vzorem tla��tka
	breq output				; >> Pokud se hodnoty rovnaj� sko�� na n�v�t� output

	dec poc_opak			; >> Sn�en� po�tu opakov�n� o 1
	brne loop				; >> Skok na n�v�t� loop pokud poc_opak > 0		
	rjmp main				; >> Skok do hlavn�ho programu

output:	
	lpm R16, Z+				; >> Na�ten� vzoru ledek do registru R16 s n�slednou inkrementac�
	out PORTB, R16			; >> Ode�le hodnotu z R16 na port B
	lpm R16, Z+				; >> Na�ten� vzoru ledek do registru R16 s n�slednou inkrementac� (tento vzor se nepou��v�, slou�� jen k tomu, aby ukazatel posko�il znovu o 1)
	call delay				; >> Zavol�n� podprogramu jm�nem delay
	dec R21					; >> Sn�en� hodnoty registru R21 o 1
	brne output				; >> Skok na n�v�t� output pokud R21 > 0
	
	ldi temp, 0b11111111	; >> Nastaven� hodnoty do prom�nn� temp
	out PORTB, temp			; >> Odesl�n� hodnoty ulo�en� v prom�nn� temp (slou�� k zhasnut� ledek, po dokon�en� sekvence)
	rjmp main				; >> Skok na za��tek hlavn�ho programu (n�v�t� main)

delay: 						; >> HW Delay (+- 300ms)
	ldi temp, 0b00001110 	; >> Hodnota pro nastaven� p�edd�li�ky
	ldi R24,75   			; >> Zpo�d�n� se bude opakovat 75x -> 75x4ms=300ms 

set_timer: 
	out TCCR0, temp  		; >> Nastaven� p�edd�li�ky
	ldi R25,250       		; >> Hodnota pro kompara�n� registr 
	out OCR0,R25  			; >> Na�ten� kompara�n� hodnoty

compare: 
	in R25,TIFR  			; >> Na�ten� hodnoty z TIFR0 do registru R25
	cpi R25,0x02		  	; >> Porovn� hodnot
	brne compare	 		; >> Pokud hodnoty TIFR0 a 0x07 nejsou stejn�, tak sko�� na n�v�t� compare
	out TIFR, R25			; >> Vynulov�n� TIFR0
	dec R24   				; >> Ode�ten� cyklu
	brne set_timer	 		; >> Pokud registr s ode��t�n�m cyklu nen� roven 0 sko�� na n�v�t� set_timer
	ret						; >> Vrac� se do hlavn�ho programu



; >> Tabulky led vzor� a tla��tek
beg_led1: 
		  .db 0b01111111
		  .db 0b10111111
		  .db 0b11011111
		  .db 0b11101111
		  .db 0b11110111
		  .db 0b11111011
end_led1:

beg_led2: 
		  .db 0b11111110
		  .db 0b11111101
		  .db 0b11111011
		  .db 0b11110111
end_led2:

beg_led3: 
		  .db 0b10011001
		  .db 0b10111101
end_led3:

beg_led4:
		  .db 0b10101010
		  .db 0b01010101
		  .db 0b00100100
end_led4:

beg_led5:
		  .db 0b01111110
		  .db 0b10111101
		  .db 0b11011011
		  .db 0b11100111
		  .db 0b11011011
end_led5:

beg_led6:
		  .db 0b11110000
		  .db 0b00001111
end_led6:

beg_led7:
		  .db 0b11001100
		  .db 0b00110011
		  .db 0b10111101
end_led7:

beg_led8:
		  .db 0b11100001
		  .db 0b11000011
		  .db 0b10000111
		  .db 0b11000011
		  .db 0b11100001
end_led8:

tb_tlac: 
         .db 0b01111111, low(beg_led1<<1), high(beg_led1<<1), (end_led1-beg_led1)
		 .db 0b10111111, low(beg_led2<<1), high(beg_led2<<1), (end_led2-beg_led2)
		 .db 0b11011111, low(beg_led3<<1), high(beg_led3<<1), (end_led3-beg_led3)
		 .db 0b11101111, low(beg_led4<<1), high(beg_led4<<1), (end_led4-beg_led4)
		 .db 0b11110111, low(beg_led5<<1), high(beg_led5<<1), (end_led5-beg_led5)
		 .db 0b11111011, low(beg_led6<<1), high(beg_led6<<1), (end_led6-beg_led6)
		 .db 0b11111101, low(beg_led7<<1), high(beg_led7<<1), (end_led7-beg_led7)
		 .db 0b11111110, low(beg_led8<<1), high(beg_led8<<1), (end_led8-beg_led8)












