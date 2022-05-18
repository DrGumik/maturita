; >>                     									  <<
; >>                       Úloha è. 6						  <<
; >> Rozsvícení sekvence vzorù LED podle stisknutého tlaèítka <<
; >> 				  Vytvoøil Jakub Tenk 					  <<
; >>                     									  <<

.nolist 					; >> Vypne debug
.include "m128def.inc"		; >> Pøiøazení jmen registru
.list 						; >> Zapne debug

.dseg
.org 0x200					; >> Interní RAM - poèáteèní adresa

.cseg
.org 0x0000					; >> Zaèátek pamìti flash

.def poc_opak = R22			; >> Definování promìnných (poc_opak, temp)
.def temp = R23

	ldi temp,LOW(RAMEND)	; >> Inicializace zásobníku
	out SPL, temp
	ldi temp,HIGH(RAMEND)
	out SPH, temp

	ldi poc_opak, 32		; >> Nastavení hodnoty poètu opakování na 32

	ldi XL, 0x00			; >> Nastavení dolního bajtu adresy X
    ldi XH, 0x04			; >> Nastavení horního bajtu adresy X

	ldi R16, 0xFF			; >> Nastavení portu B jako výstupní a portu D jako vstupní
	ldi R17, 0x00
	out DDRB, R16
	out DDRD, R17
	ldi R16, 0b11111111		; >> Nastavení hodnoty, která zhasne všechny ledky do R16
	out PORTB, R16			; >> Odeslání hodnoty pro zhasnutí ledek na port B

	ldi ZL, LOW(tb_tlac<<1)	; >> Odkázání ukazatele Z do programové pamìti na adresu, kde se nachází tb_tlac
	ldi ZH, HIGH(tb_tlac<<1)

load_tb:
	lpm R16, Z+				; >> Pøesun hodnoty z pamìti programu z adresy uložené v registru Z do registru R16 s následnou inkrementací
	st X+, R16				; >> Zkopírování hodnoty z R16 do datové pamìti na adresu uloženou v registru X s následnou inkrementací
	dec poc_opak			; >> Snížení poètu opakování o 1
	brne load_tb			; >> Skok na návìští load_tb pokud poc_opak > 0

main:
    ldi poc_opak,8			; >> Nastavení hodnoty poètu opakování na 8
	ldi XL, 0x00			; >> Nastavení dolního bajtu adresy X
    ldi XH, 0x04			; >> Nastavení horního bajtu adresy X	
	in R17, pinD			; >> Pøeètení hodnoty z portu D a uložení do R17
loop:
	ld R18, X+				; >> Zkopírování hodnoty z datové pamìti do registru R18 s následnou inkrementací
	ld R19, X+				; >> Zkopírování hodnoty z datové pamìti do registru R19 s následnou inkrementací
	ld R20, X+				; >> Zkopírování hodnoty z datové pamìti do registru R20 s následnou inkrementací
	ld R21, X+				; >> Zkopírování hodnoty z datové pamìti do registru R21 s následnou inkrementací
	mov R30, R19			; >> Odkázání ukazatele Z do programové pamìti na adresu, kde se nachází daná tabulka led vzorù
	mov R31, R20

	cp R17, R18				; >> Porovnání vstupní hodnoty z portu D se vzorem tlaèítka
	breq output				; >> Pokud se hodnoty rovnají skoèí na návìští output

	dec poc_opak			; >> Snížení poètu opakování o 1
	brne loop				; >> Skok na návìští loop pokud poc_opak > 0		
	rjmp main				; >> Skok do hlavního programu

output:	
	lpm R16, Z+				; >> Naètení vzoru ledek do registru R16 s následnou inkrementací
	out PORTB, R16			; >> Odešle hodnotu z R16 na port B
	lpm R16, Z+				; >> Naètení vzoru ledek do registru R16 s následnou inkrementací (tento vzor se nepoužívá, slouží jen k tomu, aby ukazatel poskoèil znovu o 1)
	call delay				; >> Zavolání podprogramu jménem delay
	dec R21					; >> Snížení hodnoty registru R21 o 1
	brne output				; >> Skok na návìští output pokud R21 > 0
	
	ldi temp, 0b11111111	; >> Nastavení hodnoty do promìnné temp
	out PORTB, temp			; >> Odeslání hodnoty uložené v promìnné temp (slouží k zhasnutí ledek, po dokonèení sekvence)
	rjmp main				; >> Skok na zaèátek hlavního programu (návìští main)

delay: 						; >> HW Delay (+- 300ms)
	ldi temp, 0b00001110 	; >> Hodnota pro nastavení pøeddìlièky
	ldi R24,75   			; >> Zpoždìní se bude opakovat 75x -> 75x4ms=300ms 

set_timer: 
	out TCCR0, temp  		; >> Nastavení pøeddìlièky
	ldi R25,250       		; >> Hodnota pro komparaèní registr 
	out OCR0,R25  			; >> Naètení komparaèní hodnoty

compare: 
	in R25,TIFR  			; >> Naètení hodnoty z TIFR0 do registru R25
	cpi R25,0x02		  	; >> Porovní hodnot
	brne compare	 		; >> Pokud hodnoty TIFR0 a 0x07 nejsou stejné, tak skoèí na návìští compare
	out TIFR, R25			; >> Vynulování TIFR0
	dec R24   				; >> Odeètení cyklu
	brne set_timer	 		; >> Pokud registr s odeèítáním cyklu není roven 0 skoèí na návìští set_timer
	ret						; >> Vrací se do hlavního programu



; >> Tabulky led vzorù a tlaèítek
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












