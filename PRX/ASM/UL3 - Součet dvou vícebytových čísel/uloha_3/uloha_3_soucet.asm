; >> 								<<
; >> Souèet dvou vícebytových èísel <<
; >>      Vytvoøil Jakub Tenk       <<
; >> 								<<

.nolist ;neprovádí výpis na obrazovku (debug)
.include "m128def.inc"
.list  ;po include zacne znovu výpis na obrazovku (debug)

.def poc_opak = R22

.cseg

		ldi XL, 0x00	; >> Definování 1. bloku pro ukládání prvních èísel
		ldi XH, 0x01	; >> 
		ldi YL, 0x00	; >> Definování 2. bloku pro ukládání druhých èísel
		ldi YH, 0x02	; >> 
		ldi poc_opak, 3	; >> Nastavení hodnoty poètu opakování (3x)



    	ldi ZL, LOW(cislo1<<1)	; >> odkázání ukazatele Z do programové pamìti
    	ldi ZH, HIGH(cislo1<<1) ; >> na místo (adresa) kde se nachází cislo1
                            	

skok1: 	lpm R16, Z+

		st X+,R16 		; >> Zápis 1. èísla do 1. bloku
		dec poc_opak
		brne skok1

    	; >> Resetování hodnoty poètu opakování, nastavení na 3
		clr poc_opak
		ldi poc_opak,3
		; >>


		ldi ZL, LOW(cislo2<<1) 	; >> odkázání ukazatele Z do programové pamìti
    	ldi ZH, HIGH(cislo2<<1) ; >> na místo (adresa) kde se nachází cislo2

skok2: 	lpm R17, Z+

		st Y+,R17		; >> Zápis 2. èísla do 2. bloku

		dec poc_opak
		brne skok2

		; >> Resetování hodnoty poètu opakování, nastavení na 3
		clr poc_opak
		ldi poc_opak,3
		; >>

		ldi XL, 0x00	; >> Znovu definování 1. bloku
		ldi XH, 0x01	; >> 
		ldi YL, 0x00	; >> Znovu definování 2. bloku
		ldi YH, 0x02	; >> 
		ldi ZL, 0x20	; >> Definování 3. bloku kam budeme ukládat výpoèty
		ldi ZH, 0x01	; >>

soucet:	
		ld R16, X+		; >> naètení prvních èísel hodnot
		ld R17, Y+		; >> naètení druhých èísel hodnot

		adc R17, R16	; >> R17 = R17+R16+C
		st Z+,R17		; >> Uložení souètu na adresy v pamìti od 120

		dec poc_opak
		brne soucet



cislo1: .db 0x1A, 0x2B, 0x3C
cislo2: .db 0x4D, 0x5E, 0x6F

konec: 	rjmp konec
	
	



