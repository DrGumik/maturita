; >> 								<<
; >> Sou�et dvou v�cebytov�ch ��sel <<
; >>      Vytvo�il Jakub Tenk       <<
; >> 								<<

.nolist ;neprov�d� v�pis na obrazovku (debug)
.include "m128def.inc"
.list  ;po include zacne znovu v�pis na obrazovku (debug)

.def poc_opak = R22

.cseg

		ldi XL, 0x00	; >> Definov�n� 1. bloku pro ukl�d�n� prvn�ch ��sel
		ldi XH, 0x01	; >> 
		ldi YL, 0x00	; >> Definov�n� 2. bloku pro ukl�d�n� druh�ch ��sel
		ldi YH, 0x02	; >> 
		ldi poc_opak, 3	; >> Nastaven� hodnoty po�tu opakov�n� (3x)



    	ldi ZL, LOW(cislo1<<1)	; >> odk�z�n� ukazatele Z do programov� pam�ti
    	ldi ZH, HIGH(cislo1<<1) ; >> na m�sto (adresa) kde se nach�z� cislo1
                            	

skok1: 	lpm R16, Z+

		st X+,R16 		; >> Z�pis 1. ��sla do 1. bloku
		dec poc_opak
		brne skok1

    	; >> Resetov�n� hodnoty po�tu opakov�n�, nastaven� na 3
		clr poc_opak
		ldi poc_opak,3
		; >>


		ldi ZL, LOW(cislo2<<1) 	; >> odk�z�n� ukazatele Z do programov� pam�ti
    	ldi ZH, HIGH(cislo2<<1) ; >> na m�sto (adresa) kde se nach�z� cislo2

skok2: 	lpm R17, Z+

		st Y+,R17		; >> Z�pis 2. ��sla do 2. bloku

		dec poc_opak
		brne skok2

		; >> Resetov�n� hodnoty po�tu opakov�n�, nastaven� na 3
		clr poc_opak
		ldi poc_opak,3
		; >>

		ldi XL, 0x00	; >> Znovu definov�n� 1. bloku
		ldi XH, 0x01	; >> 
		ldi YL, 0x00	; >> Znovu definov�n� 2. bloku
		ldi YH, 0x02	; >> 
		ldi ZL, 0x20	; >> Definov�n� 3. bloku kam budeme ukl�dat v�po�ty
		ldi ZH, 0x01	; >>

soucet:	
		ld R16, X+		; >> na�ten� prvn�ch ��sel hodnot
		ld R17, Y+		; >> na�ten� druh�ch ��sel hodnot

		adc R17, R16	; >> R17 = R17+R16+C
		st Z+,R17		; >> Ulo�en� sou�tu na adresy v pam�ti od 120

		dec poc_opak
		brne soucet



cislo1: .db 0x1A, 0x2B, 0x3C
cislo2: .db 0x4D, 0x5E, 0x6F

konec: 	rjmp konec
	
	



