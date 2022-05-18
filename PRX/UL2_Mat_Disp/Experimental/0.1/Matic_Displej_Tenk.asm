;Zpracujte program v programovacím jazyce JSA ATMega128 ovládající urèený pøipojený maticový displej a klávesnici tak, aby obsahoval nejménì tyto funkce:
;1) stisknuté tlaèítko klávesnice se uloží do pamìti modulu MB-ATmega128, minimálnì 5
;kláves, maximálnì 15 kláves
;2) každé klávese bude pøiøazen vhodný zobrazovaný symbol
;3) rozpoznání stavu vkládání znakù a stavu pøehrávání vložených znakù ovládaných pomocí
;maticové klávesnice klávesnice
;4) pøepínání mezi tìmito režimy
;5) využití všech vhodných HW možností pøípravku MB-ATmega128.


; Alg. v1
; 1) Inicializace
; 2) Zapne <i> radek klavesnice
; 3) Precte <i> radek klavesnice a ulozi to promenne key
; 4) Dekrementuje <i>
; 5) Pokud se <i> nerovna nule pokracuje bodem 2. jinak bodem 6.
; 6) Vytahne z pole ... X+ ... 2 hodnoty (temp, sec_temp?) a porovna 1. hodnotu s hodnotou tlacitka
; 7) Pokud key == hodnota z X pokracuje bodem 9. jinak bodem 8
; 8) Dekrementace counteru
; 9) Nastavi ukazatel do datove pameti se vzory pro displej dle hodnoty sec_temp
; 10) Prehraje vzory na displeji
; 11) Pokracuje bodem 2
;
; Alg. v2
; 1) Inicializace
; 2) Zapne <i> radek klavesnice
; 3) Precte <i> radek klavesnice a ulozi to promenne key
; 4) Vytahne z pole ... X+ ... 2 hodnoty (temp, sec_temp?) a porovna 1. hodnotu s hodnotou tlacitka
; 5) Pokud key == temp pokracuje bodem 7. jinak bodem 6 NEBO key == DEF. BTN pokracuje bodem 8
; 6) Dekrementuje <i> + skok na bod 2.
; 7) Nahraje sec_temp do Y+, sec_counter++, skok na bod 2.
; 8) Nastavi ukazatel do datove pameti se vzory pro displej dle hodnoty sec_temp
; 9) Prehraje vzor na displeji (5x)
; 10) dec sec_counter
; 11) brne bod 8
; 12) jmp bod 2
;
; Celej displej 1 port -> 0b1_0000000  - 0bCLK_VZOR
; CLK - 0 = neposune; 1 = posune "sloupec"
;
; Alg v3:
;	Main:
; 	1) Inicializace
; 	2) Zapne <i> radek klavesnice
; 	3) Precte <i> radek klavesnice a ulozi to promenne key
; 	4) Vytahne z pole ... X+ ... 2 hodnoty (temp, sec_temp?) a porovna 1. hodnotu s hodnotou tlacitka
; 	5) Pokud key == temp pokracuje bodem 7. jinak bodem 6 NEBO key == DEF. BTN pokracuje bodem 8
; 	6) Dekrementuje <i> + skok na bod 2.
; 	7) Nahraje sec_temp do Y+, sec_counter++, skok na bod 2.
; 	8) Nastavi ukazatel do datove pameti se vzory pro displej dle hodnoty sec_temp
; 	9) Pokracuje bodem 2.
;
;  Int_timer0:
;	1) Odešle na portDisp 0
;	2) Naète hodnotu z Y+ do temp
;	3) Odešle na portDisp hodnotu z temp
;	4) Odešle na portDisp byte kde D7 je 1
;	5) Dekrementace counteruDisp
;	6) Pokud counterDisp == 0
;		a) ANO = pokracuj bodem 7.
;		b) NE = RETI


.nolist
.include "m128def.inc"
.list

.def temp = R16
.def key = R17
.def counter = R18
.equ portDisp = PORTC
.equ portKey = PORTD

.equ ddrDisp = DDRC
.equ ddrKey = DDRD

.org 0x0000 jmp start

start:
	ldi temp, LOW(RAMEND)	; >> Nastavení zásobníku
	out SPL, temp
	ldi temp, HIGH(RAMEND)
	out SPH, temp

	ldi temp, 0xFF			; >> Nastavení portù pro displej a multiplex
	out ddrDisp, temp
	ldi temp, 0x0F
	out ddrKey, temp

	call init_timer
	call init_patterns

	sei
	jmp main
	
main:
	ldi ZL, LOW(patterns_beg<<1)
	ldi ZH, HIGH(patterns_beg<<1)
	ldi counter, 5










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







	
timer0_int:
	ldi temp, 0b0_0000000
	out portDisp, temp
	nop

	lpm temp, Y+
	out portDisp, temp
	call delay

	ldi temp, 0b1_0000000
	out portDisp, temp
	nop

	dec counter
	brne disp

	ldi counter, 5
tick:	
	ldi temp, 0b1_0000000
	out portDisp, temp
	dec counter
	brne tick

	ldi YL	LOW(initTable)
	ldi YH, HIGH(initTable)
	reti











	
init_timer:
	ldi temp, 0b00001101 	; >> Hodnota pro nastavení pøeddìlièky
	out TCCR0, temp  		; >> Nastavení pøeddìlièky
	ldi temp, 185       	; >> Hodnota pro komparaèní registr 
	out OCR0, temp  		; >> Naètení komparaèní hodnoty
	ret

init_patterns:
	ldi XL, 0x00
	ldi XH, 0x02
	ldi ZL, LOW(patterns_beg<<1)
	ldi ZH, HIGH(patterns_beg<<1)
	ldi counter, 10
loading:
	lpm temp, Z+
	st X+, temp
	dec counter
	brne loading
	ret


delay:
	out TIFR, temp
compare_time:  
	in temp,TIFR  			; >> Naètení hodnoty z TIFR do registru temp
	sbrs temp, 1		  	; >> Pokud hodnota OCF0 == 1, tak program preskoèí instrukci jmp compare
	jmp compare_time
	out TIFR, temp			; >> Vynulování TIFR
	ret


initTable: .ds 2

patterns_beg:
	.db 0b0_1111000, 0b0_0001111, 0b0_1111000, 0b0_0001111, 0b0_1111000 ; >> Vzor 1
	.db 0b0_0001111, 0b0_1111000, 0b0_0001111, 0b0_1111000, 0b0_0001111 ; >> Vzor 2...
patterns_end:

tb_sloupce_beg:
	.db 0b1111_1110, 3 ; >> 1. sloupec, pocet kláves
	.db 0b1111_1101, 4 ; >> 2. sloupec, pocet kláves
	.db 0b1111_1011, 3 ; >> 3. sloupec, pocet kláves
tb_sloupce_end:

tb_key_beg:  ; >> Key_ID , DISP_VZOR / Key_ID2, DISP_VZOR...
	.db 0b1110_1110, 1, 0b1101_1110, 0b0110_0110, 0b1011_1110, 0b1110_0000
	.db 0b1110_1101, 0b1101_1010, 0b1101_1101, 0b1011_0110, 0b1011_1101, 0b1111_1110, 0b0111_1101, 0b1111_1100
	.db 0b1110_1011, 0b1111_0010, 0b1101_1011, 0b1011_1110, 0b1011_1011, 0b1111_0110
tb_key_end:
