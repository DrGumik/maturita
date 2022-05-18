; >>                                   << ;
; >>   Maticovy displej s klavesnici   << ;
; >>        Vytvořil Jakub Tenk       << ;
; >>                                   << ;

.nolist
.include "m128def.inc"
.list

.def temp = R16 ; >> Temporary
.def counter = R17 ; >> Main counter
.def regKeyPat = R18 ; >> Key pattern
.def regKeyId = R19 ; >> Key value
.def canStart = R20 ; >> If btn start displaying is pushed -> start displaying and lock pushing all keys until displaying end
.def counterPKs = R21 ; >> Counter of pushed keys
.def counterTL = R22

.equ portDisp = PORTE
.equ ddrDisp = DDRE

.equ portKey = PORTB
.equ ddrKey = DDRB
.equ pinKey = PINB

.org 0x0000 jmp start
.org 0x0012 jmp timer2_int

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
	brne key_pushed_cont 				; >> Pokracuje na ulozeni data (dato je cislo pozice, kde se nachazi vzory pro displej urcene dane klavese)
	jmp start_display					; >> Povoli promitani na displeji a zakaze zaznamenavani klaves do doby nez se promitani ukonci
key_pushed_cont:
	st Y+, regKeyId
	inc counterPKs
	jmp continue
start_display:
	ldi XL, 0x00
	ldi XH, 0x03

	ldi YL, 0x2D   						;... posune na pattern kde jsou 0b0_1111111, aby ze zacatku nesvitil displej
	ldi YH, 0x04

	;inc counterPKs
	ldi canStart, 1
	ldi counter, 5

	jmp main



; >>        Timer2 preruseni        << ;
timer2_int:
	; >> If displaying set to 1
	sbrs canStart, 0
	jmp int_return

	; >> Displaying routine
	ldi temp, 0b1_0000000
	out portDisp, temp
	nop

	ld temp, Y+
	out portDisp, temp

	dec counter
	brne int_return
	
	; TEST
	ld temp, X
	mov R28, temp
	ldi YH, 0x04
	
	dec R22
	brne int_return
	ldi R22, 255

	ldi counter, 4
tick:
	;>> Reset display
	ldi temp, 0b1_0000000
	out portDisp, temp
	dec counter
	brne tick

	; >> Move pointer to next patterns	
	ld temp, X+
	mov R28, temp ; >> set YL
	ldi YH, 0x05

	ldi counter, 5
	dec counterPKs
	brne int_return
	ldi canStart, 0
	ldi YL, 0x00
	ldi YH, 0x03
	reti
int_return:
	reti

timer3_int: ; po 1sec
	






; >>        Podprogramy        << ;

; >> Inicializace timeru 0 a 2
init_timer0:
	ldi temp, (1<<WGM01) | (1<<CS02) | (1<<CS00)
										; >> Hodnota pro nastaveni preddelicky
	out TCCR0, temp  					; >> Nastaveni preddelicky
	ldi temp, 255       				; >> Hodnota pro komparacni registr 
	out OCR0, temp  					; >> Nacteni komparacni hodnoty
	jmp init_timer2
init_timer2:
	ldi temp, (1<<WGM21) | (1<<CS22) | (1<<CS20)
										; >> Hodnota pro nastaveni preddelicky
	out TCCR2, temp  					; >> Nastaveni preddelicky
	ldi temp, 185       				; >> Hodnota pro komparacni registr 
	out OCR2, temp  					; >> Nacteni komparacni hodnoty
	ldi temp, (1<<OCIE2)
	out TIMSK, temp
	ret

; >> Prekopirovani vzoru pro displej z programove pameti do datove pameti
init_disp_patterns:
	ldi XL, 0x00
	ldi XH, 0x05
	ldi ZL, LOW(patterns__disp_beg<<1)
	ldi ZH, HIGH(patterns__disp_beg<<1)
	ldi counter, 50 ; .. doplnit vzorec
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
	out TIFR, temp
compare_time:  
	in temp, TIFR 						; >> Nastaveni hodnoty z TIFR do registru temp
	sbrs temp, 1		  				; >> Pokud hodnota OCF1 == 1, tak program preskoci instrukci jmp compare
	jmp compare_time
	out TIFR, temp						; >> Vynulovani TIFR
	ret

delay_test: ; test
	out TIFR, temp
compare_time_test:  
	in temp, TIFR 						; >> Nastaveni hodnoty z TIFR do registru temp
	sbrs temp, 1		  				; >> Pokud hodnota OCF1 == 1, tak program preskoci instrukci jmp compare
	jmp compare_time_test
	dec counter
	brne delay_test
	ret


patterns__disp_beg: ; >> 2. sloupec / 3. sloupec / 4. sloupec / 5. sloupec / 1. sloupec
	.db 0b0_1111110, 0b0_1111110, 0b0_1111110, 0b0_1111110, 0b0_1111110, 0b0_0111111, 0b0_0111111, 0b0_0111111, 0b0_0111111, 0b0_0111111 ; >> Vzor 1 / Vzor 2
	.db 0b0_1111100, 0b0_1111100, 0b0_1111100, 0b0_1111100, 0b0_1111100, 0b0_0011111, 0b0_0011111, 0b0_0011111, 0b0_0011111, 0b0_0011111 ; >> Vzor 3 / Vzor 4
	.db 0b0_1111000, 0b0_1111000, 0b0_1111000, 0b0_1111000, 0b0_1111000, 0b0_0001111, 0b0_0001111, 0b0_0001111, 0b0_0001111, 0b0_0001111 ; >> Vzor 5 / Vzor 6
	.db 0b0_1110000, 0b0_1110000, 0b0_1110000, 0b0_1110000, 0b0_1110000, 0b0_0000111, 0b0_0000111, 0b0_0000111, 0b0_0000111, 0b0_0000111 ; >> Vzor 7 / Vzor 8
	.db 0b0_1100000, 0b0_1100000, 0b0_1100000, 0b0_1100000, 0b0_1100000, 0b0_1111111, 0b0_1111111, 0b0_1111111, 0b0_1111111, 0b0_1111111 ; >> Vzor 9 / Vzor 10
patterns__disp_end:

patterns_key_column_beg:
	.db 0b1111_1110, 3 ; >> 1. sloupec, pocet klaves ve sloupci
	.db 0b1111_1101, 4 ; >> 2. sloupec, pocet klaves ve sloupci
	.db 0b1111_1011, 3 ; >> 3. sloupec, pocet klaves ve sloupci
patterns_key_column_end:

patterns_key_beg:  ; >> Key_Pattern1, Key_Value1 / Key_Pattern4, Key_Value4 / Key_Pattern7, Key_Value7 ...
	.db 0b1110_1110, 0x00, 0b1101_1110, 0x05, 0b1011_1110, 0x0A
	.db 0b1110_1101, 0x0F, 0b1101_1101, 0x14, 0b1011_1101, 0x19
	.db 0b1110_1011, 0x23, 0b1101_1011, 0x28, 0b1011_1011, 0x99
patterns_key_end:
