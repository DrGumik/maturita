; >>                     									  <<
; >>            Obsluha matice tla��tek 4x4 a LED             <<
; >> 				  Vytvo�il Jakub Tenk 					  <<
; >>                     									  <<

.nolist 									; >> Vypne debug
.include "m128def.inc"						; >> P�i�azen� jmen registru
.list 										; >> Zapne debug

.dseg
.org 0x200									; >> Intern� RAM - po��te�n� adresa
	
.cseg
.org 0x0000									; >> Za��tek pam�ti flash

.def poc_opak = R22							; >> Definov�n� prom�nn�ch
.def poc_key = R18	
.def temp = R23
.def regKey = R16
.def regLed = R17
.equ portKey = PORTB
.equ portLed = PORTE
.equ ddrKey = DDRB
.equ ddrLed = DDRE

	ldi temp,LOW(RAMEND)					; >> Inicializace, nastaven� port�...
	out SPL, temp
	ldi temp,HIGH(RAMEND)
	out SPH, temp

	ldi temp, 0x0F
	out ddrKey, temp
	ldi temp, 0xFF						
	out ddrLed, temp
	ldi temp , 0xFF				
	out portLed, temp
	
	ldi XL, 0x00
    ldi XH, 0x01

	ldi poc_opak, 6
	ldi ZL, LOW(tb_sloupce_beg<<1)			
	ldi ZH, HIGH(tb_sloupce_beg<<1)

load_tb:									; >> Na�ten� tabulky tb_sloupce z pam�ti programu do datov� pam�ti
	lpm temp, Z+		
	st X+, temp				
	dec poc_opak		
	brne load_tb

main:										; >> Za��tek hlavn�ho programu
	ldi XL, 0x00
    ldi XH, 0x01

	ldi ZL, LOW(tb_key_beg<<1)			
	ldi ZH, HIGH(tb_key_beg<<1)
    ldi poc_opak, 3
										
loop:										; >> Kontrola cel�ho jednoho sloupce
	ld regKey, X+			
	ld poc_key, X+
	out portKey, regKey
	call delay			
key_id:
	lpm regKey, Z+
	lpm regLed, Z+
	in temp, pinB
	cp temp, regKey							; >> Pokud regKey == hodnota z portuB, sko�� na output
	brne continue
	jmp output
continue:
	dec poc_key
	brne key_id							
	dec poc_opak
	brne loop
	jmp main

output:										; >> Rozsv�cen� ledek
	out portLed, regLed
	jmp continue


delay: 										; >> HW Delay (+- 0,78ms)
	ldi temp, 0b00001101 					; >> Hodnota pro nastaven� p�edd�li�ky
set_timer: 
	out TCCR0, temp  						; >> Nastaven� p�edd�li�ky
	ldi temp, 96       						; >> Hodnota pro kompara�n� registr 
	out OCR0, temp  						; >> Na�ten� kompara�n� hodnoty
compare: 
	in temp,TIFR  							; >> Na�ten� hodnoty z TIFR do registru temp
	sbrs temp, 1		  					; >> Pokud hodnota OCF0 == 1, tak program presko�� instrukci jmp compare
	jmp compare
	out TIFR, temp							; >> Vynulov�n� TIFR
	ret										; >> Vrac� se do hlavn�ho programu


tb_sloupce_beg:
	.db 0b1111_1110, 3 ; >> 1. sloupec, pocet polozek
	.db 0b1111_1101, 4 ; >> 2. sloupec, pocet polozek
	.db 0b1111_1011, 3 ; >> 3. sloupec, pocet polozek
tb_sloupce_end:

tb_key_beg: 
	.db 0b1110_1110, 0b1111_1110, 0b1101_1110, 0b1111_0111, 0b1011_1110, 0b1011_1111 ; >> 1. sloupec - 1, LED1, 4, LED4, 7, LED7
	.db 0b1110_1101, 0b1111_1101, 0b1101_1101, 0b1110_1111, 0b1011_1101, 0b0111_1111, 0b0111_1101, 0b1111_1111 ; >> 2. sloupec - 2-LED2, 5-LED5, 8-LED8, 0-LED_OFF
	.db 0b1110_1011, 0b1111_1011, 0b1101_1011, 0b1101_1111, 0b1011_1011, 0b0000_0000 ; >> 3. sloupec - 3, 6, 9
tb_key_end:












