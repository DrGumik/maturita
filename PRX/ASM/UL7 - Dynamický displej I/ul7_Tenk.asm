; >>                     									  <<
; >>                       �loha �. 7						  <<
; >>                  Dynamick� displej I                     <<
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
.def temp = R23
.def regPos = R16
.def regVal = R17
.equ portPos = PORTB
.equ portVal = PORTD

	ldi temp,LOW(RAMEND)					; >> Inicializace z�sobn�ku
	out SPL, temp
	ldi temp,HIGH(RAMEND)
	out SPH, temp

	ldi temp, 0xFF							; >> Nastaven� portu portPos a portVal jako v�stupn�
	out portPos, temp
	out portVal, temp

main:
	ldi ZL, LOW(tb_dis_beg<<1)				; >> Odk�z�n� ukazatele Z do programov� pam�ti na adresu, kde se nach�z� tb_dis_beg
	ldi ZH, HIGH(tb_dis_beg<<1)
    ldi poc_opak, (tb_dis_end-tb_dis_beg)	; >> Nastaven� hodnoty po�tu opakov�n� 
											; >> (pou�it zkr�cen� vzorec, obecn� vzorec - 2*(tb_dis_end-tb_dis_beg)/2 )
loop:
	lpm regPos, Z+							; >> Na�te hodnoty pro pozici a vzor, n�sledn� ode�le na ur�en� porty
	lpm regVal, Z+							; >> Z se n�sledn� v�dy inkrementuje
	out portPos, regPos
	out portVal, regVal
	call delay								; >> Zavol�n� podprogramu jm�nem delay
	dec poc_opak							; >> Ode�te pr�b�h cyklem
	brne loop								; >> Pokud poc_opak == 0 pokra�uje d�l, jinak sko�� na n�v�t� loop
	rjmp main								; >> Skok na n�v�t� main


delay: 										; >> HW Delay (+- 2ms)
	ldi temp, 0b00001101 					; >> Hodnota pro nastaven� p�edd�li�ky
set_timer: 
	out TCCR0, temp  						; >> Nastaven� p�edd�li�ky
	ldi temp, 255       					; >> Hodnota pro kompara�n� registr 
	out OCR0, temp  						; >> Na�ten� kompara�n� hodnoty
compare: 
	in temp,TIFR  							; >> Na�ten� hodnoty z TIFR do registru temp
	sbrs temp, 1		  					; >> Pokud hodnota OCF0 == 1, tak program presko�� instrukci jmp compare
	jmp compare
	out TIFR, temp							; >> Vynulov�n� TIFR
	ret										; >> Vrac� se do hlavn�ho programu


tb_dis_beg: 
			.db 0b00000_000, 0b0000_0110	; >> 1. pos / 1
			.db 0b00000_001, 0b0101_1011	; >> 2. pos / 2
			.db 0b00000_010, 0b0100_1111	; >> 3. pos / 3
			.db 0b00000_011, 0b0110_0100	; >> 4. pos / 4
			.db 0b00000_100, 0b0111_0111	; >> 5. pos / A
			.db 0b00000_101, 0b0111_1100	; >> 6. pos / B
			.db 0b00000_110, 0b0011_1001	; >> 7. pos / C
			.db 0b00000_111, 0b0101_1110	; >> 8. pos / D
tb_dis_end:











