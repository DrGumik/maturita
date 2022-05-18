; >>                     									  <<
; >>                       Úloha è. 7						  <<
; >>                  Dynamický displej I                     <<
; >> 				  Vytvoøil Jakub Tenk 					  <<
; >>                     									  <<

.nolist 									; >> Vypne debug
.include "m128def.inc"						; >> Pøiøazení jmen registru
.list 										; >> Zapne debug

.dseg
.org 0x200									; >> Interní RAM - poèáteèní adresa
	
.cseg
.org 0x0000									; >> Zaèátek pamìti flash

.def poc_opak = R22							; >> Definování promìnných
.def temp = R23
.def regPos = R16
.def regVal = R17
.equ portPos = PORTB
.equ portVal = PORTD

	ldi temp,LOW(RAMEND)					; >> Inicializace zásobníku
	out SPL, temp
	ldi temp,HIGH(RAMEND)
	out SPH, temp

	ldi temp, 0xFF							; >> Nastavení portu portPos a portVal jako výstupní
	out portPos, temp
	out portVal, temp

main:
	ldi ZL, LOW(tb_dis_beg<<1)				; >> Odkázání ukazatele Z do programové pamìti na adresu, kde se nachází tb_dis_beg
	ldi ZH, HIGH(tb_dis_beg<<1)
    ldi poc_opak, (tb_dis_end-tb_dis_beg)	; >> Nastavení hodnoty poètu opakování 
											; >> (použit zkrácený vzorec, obecný vzorec - 2*(tb_dis_end-tb_dis_beg)/2 )
loop:
	lpm regPos, Z+							; >> Naète hodnoty pro pozici a vzor, následnì odešle na urèené porty
	lpm regVal, Z+							; >> Z se následnì vždy inkrementuje
	out portPos, regPos
	out portVal, regVal
	call delay								; >> Zavolání podprogramu jménem delay
	dec poc_opak							; >> Odeète prùbìh cyklem
	brne loop								; >> Pokud poc_opak == 0 pokraèuje dál, jinak skoèí na návìští loop
	rjmp main								; >> Skok na návìští main


delay: 										; >> HW Delay (+- 2ms)
	ldi temp, 0b00001101 					; >> Hodnota pro nastavení pøeddìlièky
set_timer: 
	out TCCR0, temp  						; >> Nastavení pøeddìlièky
	ldi temp, 255       					; >> Hodnota pro komparaèní registr 
	out OCR0, temp  						; >> Naètení komparaèní hodnoty
compare: 
	in temp,TIFR  							; >> Naètení hodnoty z TIFR do registru temp
	sbrs temp, 1		  					; >> Pokud hodnota OCF0 == 1, tak program preskoèí instrukci jmp compare
	jmp compare
	out TIFR, temp							; >> Vynulování TIFR
	ret										; >> Vrací se do hlavního programu


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











