; >>                                   << ;
; >>   Maticovy displej s klavesnici   << ;
; >>        Vytvo?il Jakub Tenk       << ;
; >>                                   << ;

.nolist
.include "m128def.inc"
.list

.def temp = R16
.def counter = R17 		; >> Hlavni counter
.def regKeyPat = R18 	; >> Vzor tlacitka
.def regKeyId = R19 	; >> Hodnota tlacitka
.def canStart = R20 	; >> Stav promitani na displeji (1 = start promitani, 0 = zakaz promitani)
.def counterPKs = R21 	; >> Pocet stisknutych klaves
.def counterTL = R22	; >> Counter poctu tlacitek

.def changePattern = R22

.equ portDisp = PORTE
.equ ddrDisp = DDRE

.equ portKey = PORTB
.equ ddrKey = DDRB
.equ pinKey = PINB

.org 0x0000 jmp start
.org 0x0012 jmp timer2_int
.org 0x001E jmp timer0_int

; >>        Inicializace        << ;
start:
	ldi temp, LOW(RAMEND)	; >> Nastaveni zasobniku
	out SPL, temp
	ldi temp, HIGH(RAMEND)
	out SPH, temp

	ldi temp, 0xFF			; >> Nastaveni portu pro displej a klavesnici
	out ddrDisp, temp
	ldi temp, 0x0F
	out ddrKey, temp

	call init_timer0
	call init_disp_patterns
	call init_key_patterns

	ldi YL, 0x00
	ldi YH, 0x03

	clr counterPKs
	clr canStart

	sei
	jmp main
	
; >>        Hlavni program        << ;
main:
	sbrc canStart, 0					; >> Pokud je zapnute promitani na displej tak skoci znovu na main
	jmp main

	ldi XL, 0x00						; >> Nastaveni ukazatele X na data se vzory klaves klavesnice
    ldi XH, 0x01

	ldi ZL, LOW(patterns_key_beg<<1)	; >> Nastaveni ukazatele Z na data se sloupci klavesnice 
	ldi ZH, HIGH(patterns_key_beg<<1)
    ldi counter, (patterns_key_column_end-patterns_key_column_beg) 	; >> Vypocet poctu klaves						
loop:
	ld regKeyPat, X+					; >> Aktivuje sloupec a nahraje dany pocet klaves ve sloupci
	ld counterTL, X+
	out portKey, regKeyPat
	call delay
key_id:
	lpm regKeyPat, Z+					; >> Nacte vzor klavesy, jeji hodnotu a precte port pinKey
	lpm regKeyId, Z+
	in temp, pinKey
	cp temp, regKeyPat					; >> Pokud regKey == hodnota z pinKey, skok na navesti key_pushed, jinak pokracuje na navesti continue
	brne continue
	jmp key_pushed
continue:
	dec counterTL
	brne key_id
	dec counter
	brne loop
	jmp main

; >> Vykonani rutiny, kdyz je klavesa stisknuta
key_pushed:
	cpi regKeyId, 0x99
	brne key_pushed_cont 	; >> Pokracuje na ulozeni data (dato je cislo pozice, kde se nachazi vzory pro displej urcene dane klavese)
	jmp start_display		; >> Povoli promitani na displeji a zakaze zaznamenavani klaves do doby nez se promitani ukonci
key_pushed_cont:
	st Y+, regKeyId
	inc counterPKs
	jmp continue
start_display:
	ldi XL, 0x00
	ldi XH, 0x03

	ldi YL, 0x2D   			; >> posune na pattern kde jsou 0b0_1111111, aby ze zacatku nesvitil displej
	ldi YH, 0x05

	ldi canStart, 1
	ldi counter, 5
	ldi changePattern, 122

	jmp main

; >>        Timer 1 a 2 - preruseni        << ;
timer0_int:
	; >> Posunut? ukazatele na dal?? sadu vzor?
	sbrs canStart, 0
	jmp int_return
	
	dec changePattern
	brne int_return

	ldi changePattern, 122

	ld temp, X+
	dec counterPKs
	brne int_return
	; >> Pokud counterPKs == 0, tak se zastavi promitani na displeji a prejde se zpet na kontrolu tlacitek
	ldi canStart, 0
	clr counterPKs

	jmp int_return

timer2_int:
	; >> Pokud canStart == 1 (slouzi pro zahajeni promitani)
	sbrs canStart, 0
	jmp int_return

	; >> Promitani na displeji
	ldi temp, 0b1_0000000
	out portDisp, temp
	nop

	ld temp, Y+
	out portDisp, temp
	nop

	dec counter
	brne int_return

	ldi counter, 5
tick:
	;>> Reset displeje
	ldi temp, 0b1_0000000
	out portDisp, temp
	dec counter
	brne tick

	; >> Nastav? ukazatel na za??tek sady vzor?
	ld temp, X
	mov R28, temp ; >> set YL
	ldi YH, 0x05

	ldi counter, 5
	jmp int_return

int_return:
	reti

; >>        Podprogramy        << ;

; >> Inicializace timeru 0 a 2
init_timer0: ; >> Timer cca 2s
	ldi temp, (1<<WGM01) | (1<<CS00) | (1<<CS01) | (1<<CS02)
										; >> Hodnota pro nastaveni preddelicky
	out TCCR0, temp  					; >> Nastaveni preddelicky
	ldi temp, 255       				; >> Hodnota pro komparacni registr 
	out OCR0, temp  					; >> Nacteni komparacni hodnoty
	ldi temp, (1<<OCIE0)
	jmp init_timer2

init_timer2: ; >> Timer cca 2ms
	ldi temp, (1<<WGM21) | (1<<CS22) | (1<<CS20)
										; >> Hodnota pro nastaveni preddelicky
	out TCCR2, temp  					; >> Nastaveni preddelicky
	ldi temp, 185       				; >> Hodnota pro komparacni registr 
	out OCR2, temp  					; >> Nacteni komparacni hodnoty
	
	ldi temp, (1<<OCIE0) |(1<<OCIE2)	; >> Povoleni preruseni timeru 0 a 2
	out TIMSK, temp
	ret


; >> Prekopirovani vzoru pro displej z programove pameti do datove pameti
init_disp_patterns:
	ldi XL, 0x00
	ldi XH, 0x05
	ldi ZL, LOW(patterns__disp_beg<<1)
	ldi ZH, HIGH(patterns__disp_beg<<1)
	ldi counter, 50
loading_disp:
	lpm temp, Z+
	st X+, temp
	dec counter
	brne loading_disp
	ret

; >> Prekopirovani vzoru klaves klavesnice z programove pameti do datove pameti
init_key_patterns:
	ldi XL, 0x00
	ldi XH, 0x01
	ldi ZL, LOW(patterns_key_column_beg<<1)
	ldi ZH, HIGH(patterns_key_column_beg<<1)
	ldi counter, 2*(patterns_key_column_end-patterns_key_column_beg)
loading_key:
	lpm temp, Z+
	st X+, temp
	dec counter
	brne loading_key
	ret

; >> Delay ~ 1,5ms
delay: 
	ldi  r23, 42
    ldi  r24, 142
L1: dec  r24
    brne L1
    dec  r23
    brne L1
    nop
	ret


; >> Sady vzor? pro displej, sada obsahuje 5 bin. ??sel
; >> Dat. struktura: vzor_1a, vzor_1b, vzor_1c, vzor_1d, vzor_1e / vzor_2a, vzor_2b, vzor_2c, vzor_2d, vzor_2e
; >> a = prvn? sloupec, b = druh? sloupec ...
patterns__disp_beg:
	.db 0b0_1111011, 0b0_1111101, 0b0_0000000, 0b0_1111111, 0b0_1111111, 0b0_0111001, 0b0_0011110, 0b0_0101110, 0b0_0110110, 0b0_0111001 ; >> Vzor 1 / Vzor 2
	.db 0b0_1011101, 0b0_0110110, 0b0_0110110, 0b0_0110110, 0b0_1001001, 0b0_1110011, 0b0_1110101, 0b0_0000000, 0b0_1110111, 0b0_1110111 ; >> Vzor 3 / Vzor 4
	.db 0b0_1010000, 0b0_0110110, 0b0_0110110, 0b0_0110110, 0b0_1001110, 0b0_1000001, 0b0_0110110, 0b0_0110110, 0b0_0110110, 0b0_1001101 ; >> Vzor 5 / Vzor 6
	.db 0b0_0111110, 0b0_1011110, 0b0_1101110, 0b0_1110110, 0b0_1111000, 0b0_1001001, 0b0_0110110, 0b0_0110110, 0b0_0110110, 0b0_1001001 ; >> Vzor 7 / Vzor 8
	.db 0b0_1011001, 0b0_0110110, 0b0_0110110, 0b0_0110110, 0b0_1000001, 0b0_1111111, 0b0_1111111, 0b0_1111111, 0b0_1111111, 0b0_1111111 ; >> Vzor 9 / Vzor 10
patterns__disp_end:

; >> Vzory pro dan? sloupec kl?vesnice s po?tem kl?ves ve sloupci
patterns_key_column_beg:
	.db 0b1111_1110, 3 ; >> 1. sloupec
	.db 0b1111_1101, 4 ; >> 2. sloupec
	.db 0b1111_1011, 3 ; >> 3. sloupec
patterns_key_column_end:

; >> Podporovan? tla??tka: 1, 2, 3, 4, 5, 6, 7, 8, 9
; >> Tla??tko 9 spou?t? prom?t?n? na displeji
; >> Dat. struktura: Key_Pattern1, Key_Value1 / Key_Pattern4, Key_Value4 / Key_Pattern7, Key_Value7 ...
patterns_key_beg:
	.db 0b1110_1110, 0x00, 0b1101_1110, 0x05, 0b1011_1110, 0x0A
	.db 0b1110_1101, 0x0F, 0b1101_1101, 0x14, 0b1011_1101, 0x19
	.db 0b1110_1011, 0x23, 0b1101_1011, 0x28, 0b1011_1011, 0x99
patterns_key_end:
