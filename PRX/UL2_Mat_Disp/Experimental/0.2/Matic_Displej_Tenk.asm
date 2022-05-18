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

.equ portDisp = PORTC
.equ ddrDisp = DDRC

.equ portKey = PORTD
.equ ddrKey = DDRD
.equ pinKey = PIND

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
	cpi regKeyId, 99
	brne key_pushed_cont 				; >> Pokracuje na ulozeni data (dato je cislo pozice, kde se nachazi vzory pro displej urcene dane klavese)
	jmp start_display					; >> Povoli promitani na displeji a zakaze zaznamenavani klaves do doby nez se promitani ukonci
key_pushed_cont:
	st Y+, regKeyId
	inc counterPKs
	jmp continue
start_display:
	ldi XL, 0x00
	ldi XL, 0x03

	ldi YL, 0x02   						;... posune na pattern kde jsou 0b0_1111111, aby ze zacatku nesvitil displej
	ldi YH, 0x04

	inc counterPKs
	ldi canStart, 1
	jmp main



; >>        Timer0 preruseni        << ;
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

	ldi counter, 4
tick:
	; >> Reset display
	ldi temp, 0b1_0000000
	out portDisp, temp
	dec counter
	brne tick

	; >> Move pointer to next patterns
	ld temp, X+
	mov R28, temp ; >> set YL
	ldi YH, 0x04

	ldi counter, 5
	dec counterPKs
	brne int_return
	ldi canStart, 0
	ldi YL, 0x00
	ldi YH, 0x03
	reti
int_return:
	reti






; >>        Podprogramy        << ;

; >> Inicializace timeru 0 a 1
init_timer0:
	ldi temp, (1<<WGM01) | (1<<CS02) | (1<<CS00)
										; >> Hodnota pro nastaveni preddelicky
	out TCCR0, temp  					; >> Nastaveni preddelicky
	ldi temp, 185       				; >> Hodnota pro komparacni registr 
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
	ldi XH, 0x04
	ldi ZL, LOW(patterns__disp_beg<<1)
	ldi ZH, HIGH(patterns__disp_beg<<1)
	ldi counter, 10 ; .. doplnit vzorec
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
	ldi ZL, LOW(patterns_key_beg<<1)
	ldi ZH, HIGH(patterns_key_beg<<1)
	ldi counter, (patterns_key_column_end-patterns_key_column_beg)
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




patterns__disp_beg: ; >> 2. sloupec / 3. sloupec / 4. sloupec / 5. sloupec / 1. sloupec
	.db 0b0_1111000, 0b0_0001111, 0b0_1111000, 0b0_0001111, 0b0_1111000 ; >> Vzor 1
	.db 0b0_0001111, 0b0_1111000, 0b0_0001111, 0b0_1111000, 0b0_0001111 ; >> Vzor 2...
patterns__disp_end:

patterns_key_column_beg:
	.db 0b1111_1110, 3 ; >> 1. sloupec, pocet klaves ve sloupci
	.db 0b1111_1101, 4 ; >> 2. sloupec, pocet klaves ve sloupci
	.db 0b1111_1011, 3 ; >> 3. sloupec, pocet klaves ve sloupci
patterns_key_column_end:

patterns_key_beg:  ; >> Key_Pattern1, Key_Value1 / Key_Pattern4, Key_Value4 / Key_Pattern7, Key_Value7 ...
	.db 0b1110_1110, 0x00, 0b1101_1110, 0x05, 0b1011_1110, 10
	.db 0b1110_1101, 15, 0b1101_1101, 20, 0b1011_1101, 25, 0b0111_1101, 30
	.db 0b1110_1011, 35, 0b1101_1011, 40, 0b1011_1011, 45
patterns_key_end:
