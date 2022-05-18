; >>                     <<
; >>     Blikání LED     <<
; >> Vytvoøil Jakub Tenk <<
; >>                     <<


.nolist ;vypne debug
.include "m128def.inc"
.list ;zapne debug

; >> 3 -> 2 LED svítí - 1. a poslední a "bìží"smìrem do prostøed. Vždy svítí pouze dvì LED
; >> èas rychlosti blikání - 250ms


.def temp = R23

.dseg
.org 0x100

.cseg
.org 0x0000
		ldi temp,LOW(RAMEND) 	; >> Inicializace zásobníku
		out SPL, temp
		ldi temp,HIGH(RAMEND)
		out SPH, temp	

prog:
		ldi R16, 0xFF			; >> Nastavení hodnoty do registru R16
		out DDRB, R16			; >> Urèení smìru toku dat na výstup z mikrokontroléru
		ldi R16, 0b01111110		; >> Nastavení hodnoty do registru R16
		out PORTB, R16			; >> Odeslání hodnoty R16 do portu B

		call delay 				; >> Vyvolá podprogram delay (zpoždìní 250ms)
		
		ldi R16, 0b10111101		; >> Nastavení hodnoty do registru R16
		out PORTB, R16			; >> Odeslání hodnoty R16 do portu B

		call delay				; >> Vyvolá podprogram delay (zpoždìní 250ms)
		
		ldi R16, 0b11011011		; >> Nastavení hodnoty do registru R16
		out PORTB, R16			; >> Odeslání hodnoty R16 do portu B

		call delay				; >> Vyvolá podprogram delay (zpoždìní 250ms)
		
		ldi R16, 0b11100111		; >> Nastavení hodnoty do registru R16
		out PORTB, R16			; >> Odeslání hodnoty R16 do portu B

		call delay				; >> Vyvolá podprogram delay (zpoždìní 250ms)
		
		rjmp prog				; >> Skok na zaèátek hlavního programu (tímto program pojede dokola)

delay:							
    	ldi  r18, 21			; >> Nastavení poètu 1. opakování
    	ldi  r19, 75			; >> Nastavení poètu 2. opakování
    	ldi  r20, 191			; >> Nastavení poètu 3. opakování
d1: 	dec  r20				; >> Snižuje poèet 3. opakování o 1
    	brne d1					; >> Skok do cyklu d1
    	dec  r19				; >> Snižuje poèet 2. opakování o 1
    	brne d1					; >> Skok do cyklu d1
    	dec  r18				; >> Snižuje poèet 1. opakování o 1
    	brne d1					; >> Skok do cyklu d1
    	nop						; >> Zavolání prázdné instrukce
		ret						; >> Návrat z podprogramu
