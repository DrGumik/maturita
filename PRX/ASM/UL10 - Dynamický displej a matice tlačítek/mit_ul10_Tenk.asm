; >>                     									<<
; >>         Obsluha matice tlaèítek 4x4 a Displeje         <<
; >> 				  Vytvoøil Jakub Tenk 				    <<
; >> 		   		   github.com/DrGumik					<<
; >>                     									<<

.nolist 						; >> Vypne debug
.include "m128def.inc"			; >> Pøiøazení jmen registru
.list 							; >> Zapne debug

.dseg
.org 0x200						; >> Interní RAM - poèáteèní adresa
	
.cseg
.org 0x0000						; >> Zaèátek pamìti flash

.def poc_opak = R22				; >> Definování promìnných
.def poc_key = R17				; >> Registr pro poèet tlaèítek ve sloupci
.def temp = R23					; >> Temporary registr
.def regKey = R15				; >> Registr pro vzorce tlaèítek
.def regDisp = R16				; >> Registr pro vzor èísla pro dislpej na rozsvícení
.equ portKey = PORTB			; >> Port klávesnice
.equ portDisp = PORTA			; >> Port k rozsvícení displeje
.equ portPos = PORTC			; >> Port k multiplexu displeje
.equ ddrKey = DDRB
.equ ddrDisp = DDRA
.equ ddrPos = DDRC

	ldi temp,LOW(RAMEND)		; >> Inicializace zásobníku, portù...
	out SPL, temp
	ldi temp,HIGH(RAMEND)
	out SPH, temp

	ldi temp, 0x0F					
	out ddrKey, temp
	ldi temp, 0xFF						
	out ddrDisp, temp				
	out ddrPos, temp
	
	ldi XL, 0x00
    ldi XH, 0x01

	ldi poc_opak, 2*(tb_sloupce_end-tb_sloupce_beg)
	ldi ZL, LOW(tb_sloupce_beg<<1)			
	ldi ZH, HIGH(tb_sloupce_beg<<1)

	clr R18
	clr R19
	clr R20
	clr R21

load_tb:					; >> Naètení tabulky tb_sloupce
	lpm temp, Z+			; >> z pamìti programu do datové pamìti
	st X+, temp				
	dec poc_opak		
	brne load_tb

main:						; >> Zaèátek hlavního programu
	ldi XL, 0x00
    ldi XH, 0x01

	ldi ZL, LOW(tb_key_beg<<1)			
	ldi ZH, HIGH(tb_key_beg<<1)
    ldi poc_opak, (tb_sloupce_end-tb_sloupce_beg) 
										
loop:						; >> Kontrola celého jednoho sloupce
	ld regKey, X+
	ld poc_key, X+
	out portKey, regKey
	call delay			
key_id:
	lpm regKey, Z+			; >> Naètení vzorce tlaèítka a displeje
	lpm regDisp, Z+
	in temp, pinB
	cp temp, regKey			; >> Pokud regKey == hodnota z portuB, skoèí na output
	brne continue
	jmp output
continue:
	ldi R16, 0b00000_000
	out portPos, R16 		; >> 1. pos displeje
	out portDisp, R18	
	call delaydisp		

	ldi R16, 0b00000_001
	out portPos, R16 		; >> 2. pos displeje
	out portDisp, R19	
	call delaydisp		

	ldi R16, 0b00000_010
	out portPos, R16 		; >> 3. pos displeje
	out portDisp, R20	
	call delaydisp		
	
	ldi R16, 0b00000_011
	out portPos, R16 		; >> 4. pos displeje
	out portDisp, R21	
	call delaydisp	

	dec poc_key
	brne key_id							
	dec poc_opak
	brne loop
	jmp main

output:						; >> Rozsvícení displejù
	cp R18, regDisp			; >> a posunutí do prava
	breq continue			; >> Podmínka cp = kontroluje, že tlaèítko mùže být stisknuto
							; >> jen jednou po sobì (tudíž se na displejinevypíše napøíklad 1111)
	mov R21, R20
	mov R20, R19
	mov R19, R18
	mov R18, regDisp
	jmp continue



delay: 						; >> HW Delay (+- 0,78ms)
	ldi temp, 0b00001101	; >> Hodnota pro nastavení pøeddìlièky
set_timer: 
	out TCCR0, temp  		; >> Nastavení pøeddìlièky
	ldi temp, 96       		; >> Hodnota pro komparaèní registr 
	out OCR0, temp  		; >> Naètení komparaèní hodnoty
compare: 
	in temp,TIFR  			; >> Naètení hodnoty z TIFR do registru temp
	sbrs temp, 1		  	; >> Pokud hodnota OCF0 == 1, tak program preskoèí instrukci jmp compare
	jmp compare
	out TIFR, temp			; >> Vynulování TIFR
	ret						; >> Vrací se do hlavního programu

delaydisp: 					; >> HW Delay (+- 2ms)
	ldi temp, 0b00001101 	; >> Hodnota pro nastavení pøeddìlièky
set_timer_disp: 
	out TCCR0, temp  		; >> Nastavení pøeddìlièky
	ldi temp, 255       	; >> Hodnota pro komparaèní registr 
	out OCR0, temp  		; >> Naètení komparaèní hodnoty
comparedisp: 
	in temp,TIFR  			; >> Naètení hodnoty z TIFR do registru temp
	sbrs temp, 1		  	; >> Pokud hodnota OCF0 == 1, tak program preskoèí instrukci jmp compare
	jmp comparedisp
	out TIFR, temp			; >> Vynulování TIFR
	ret	


tb_sloupce_beg:
	.db 0b1111_1110, 3 ; >> 1. sloupec, pocet kláves
	.db 0b1111_1101, 4 ; >> 2. sloupec, pocet kláves
	.db 0b1111_1011, 3 ; >> 3. sloupec, pocet kláves
tb_sloupce_end:

tb_key_beg:  ; >> Key_ID , DISP_VZOR / Key_ID2, DISP_VZOR...
	.db 0b1110_1110, 0b0110_0000, 0b1101_1110, 0b0110_0110, 0b1011_1110, 0b1110_0000
	.db 0b1110_1101, 0b1101_1010, 0b1101_1101, 0b1011_0110, 0b1011_1101, 0b1111_1110, 0b0111_1101, 0b1111_1100
	.db 0b1110_1011, 0b1111_0010, 0b1101_1011, 0b1011_1110, 0b1011_1011, 0b1111_0110
tb_key_end:


