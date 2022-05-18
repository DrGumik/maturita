.nolist ;neprovádí výpis na obrazovku (debug)
.include "m128def.inc"
.list  ;po include zacne znovu výpis na obrazovku (debug)

.def poc_opak = R20

.cseg
			ldi R16,0x01 ; Vstupni hodnota 1 blok
			ldi R17,0x03 ; Vstupni hodnota 3 blok
			ldi R18,0x0A ; Vstupni hodnota 10 blok
			ldi poc_opak,10 ; Nastavení hodnoty poètu opakování

			ldi XL,0x00 ; Blok 1. min.
			ldi XH,0x01 ; Blok 1. max.

			ldi YL,0x20 ; Blok 2. min.
			ldi YH,0x01 ; Blok 2. max.

			ldi ZL,0x40 ; Blok 3. min.
			ldi ZH,0x01 ; Blok 3. max.

			; Uloha c.2 A)			

cyklus1:	st X+,R16
			inc R16 ; krok +1

			dec poc_opak
			brne cyklus1
			
			; >> Resetování hodnoty poètu opakování
			clr poc_opak
			ldi poc_opak,10
			; >>

cyklus2:	st Y+,R17
			add R17, R16 ; krok + R16 (cislo z cyklu 1)

			dec poc_opak
			brne cyklus2
			
			; >> Resetování hodnoty poètu opakování
			clr poc_opak
			ldi poc_opak,10
			; >>

cyklus3:	st Z+,R18
			dec R18 ; krok -1

			dec poc_opak
			brne cyklus3


			; Uloha c.2 A)
	
			ldi XL,0x00 ; Blok 1. min.
			ldi XH,0x01 ; Blok 1. max.

			ldi YL,0x20 ; Blok 2. min.
			ldi YH,0x01 ; Blok 2. max.

			ldi ZL,0x40 ; Blok 3. min.
			ldi ZH,0x01 ; Blok 3. max.

			; >> Resetování hodnoty poètu opakování
			clr poc_opak
			ldi poc_opak,10
			; >>


cyklus4:	ld R21,X ; nacteni hodnot
			ld R22,Y
			ld R23,Z

			st X+,R23 ; ukladani novych hodnot
			st Y+,R21
			st Z+,R22

			dec poc_opak
			brne cyklus4
			
konec:		rjmp konec ; konec
			
	
	



