; >>                     <<
; >>     Blik�n� LED     <<
; >> Vytvo�il Jakub Tenk <<
; >>                     <<


.nolist ;vypne debug
.include "m128def.inc"
.list ;zapne debug

; >> 3 -> 2 LED sv�t� - 1. a posledn� a "b��"sm�rem do prost�ed. V�dy sv�t� pouze dv� LED
; >> �as rychlosti blik�n� - 250ms


.def temp = R23

.dseg
.org 0x100

.cseg
.org 0x0000
		ldi temp,LOW(RAMEND) 	; >> Inicializace z�sobn�ku
		out SPL, temp
		ldi temp,HIGH(RAMEND)
		out SPH, temp	

prog:
		ldi R16, 0xFF			; >> Nastaven� hodnoty do registru R16
		out DDRB, R16			; >> Ur�en� sm�ru toku dat na v�stup z mikrokontrol�ru
		ldi R16, 0b01111110		; >> Nastaven� hodnoty do registru R16
		out PORTB, R16			; >> Odesl�n� hodnoty R16 do portu B

		call delay 				; >> Vyvol� podprogram delay (zpo�d�n� 250ms)
		
		ldi R16, 0b10111101		; >> Nastaven� hodnoty do registru R16
		out PORTB, R16			; >> Odesl�n� hodnoty R16 do portu B

		call delay				; >> Vyvol� podprogram delay (zpo�d�n� 250ms)
		
		ldi R16, 0b11011011		; >> Nastaven� hodnoty do registru R16
		out PORTB, R16			; >> Odesl�n� hodnoty R16 do portu B

		call delay				; >> Vyvol� podprogram delay (zpo�d�n� 250ms)
		
		ldi R16, 0b11100111		; >> Nastaven� hodnoty do registru R16
		out PORTB, R16			; >> Odesl�n� hodnoty R16 do portu B

		call delay				; >> Vyvol� podprogram delay (zpo�d�n� 250ms)
		
		rjmp prog				; >> Skok na za��tek hlavn�ho programu (t�mto program pojede dokola)

delay:							
    	ldi  r18, 21			; >> Nastaven� po�tu 1. opakov�n�
    	ldi  r19, 75			; >> Nastaven� po�tu 2. opakov�n�
    	ldi  r20, 191			; >> Nastaven� po�tu 3. opakov�n�
d1: 	dec  r20				; >> Sni�uje po�et 3. opakov�n� o 1
    	brne d1					; >> Skok do cyklu d1
    	dec  r19				; >> Sni�uje po�et 2. opakov�n� o 1
    	brne d1					; >> Skok do cyklu d1
    	dec  r18				; >> Sni�uje po�et 1. opakov�n� o 1
    	brne d1					; >> Skok do cyklu d1
    	nop						; >> Zavol�n� pr�zdn� instrukce
		ret						; >> N�vrat z podprogramu
