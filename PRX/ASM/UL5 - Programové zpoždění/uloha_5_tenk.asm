; >>                     <<
; >> Programov� zpo�d�n� <<
; >> Vytvo�il Jakub Tenk <<
; >>                     <<

.nolist ;vypne debug
.include "m128def.inc" 
.list ;zapne debug

.def temp = R16
.dseg
.org 0x100
.cseg
.org 0x0000

        ldi temp,LOW(RAMEND) ; >> Inicializace z�sobn�ku
        out SPL,temp 
        ldi temp,HIGH(RAMEND) 
        out SPH,temp 

prog: 
        call delay1 	; >> 1. podprogram zpo�d�n� - 100us (provede 1600 cykl�)
        call delay2 	; >> 2. podprogram zpo�d�n� - 10ms (provede 160000 cykl�)
        call delay3 	; >> 3. podprogram zpo�d�n� - 100ms  (provede 1600000 cykl�)
konec:  rjmp konec

delay1: ldi  r18, 200 	; >> Nastaven� po�tu opakov�n�
d1:     dec  r18		; >> Sni�uje po�et opakov�n� o 1
		nop				; >> Zavol�n� pr�zdn� instrukce
		nop
		nop
        nop
		nop
        brne d1			; >> Skok do cyklu d1
        ret				; >> N�vrat z podprogramu

delay2: ldi  r18, 208 	; >> Nastaven� po�tu opakov�n�
        ldi  r19, 202 	; >> Nastaven� po�tu opakov�n�
d2:     dec  r19		; >> Sni�uje po�et opakov�n� o 1
        brne d2			; >> Skok do cyklu d2
        dec  r18		; >> Sni�uje po�et opakov�n� o 1
        brne d2			; >> Skok do cyklu d2
        nop				; >> Zavol�n� pr�zdn� instrukce
		ret				; >> N�vrat z podprogramu

delay3: ldi  r18, 9		; >> Nastaven� po�tu opakov�n�
    	ldi  r19, 30	; >> Nastaven� po�tu opakov�n�
    	ldi  r20, 229	; >> Nastaven� po�tu opakov�n�
d3: 	dec  r20		; >> Sni�uje po�et opakov�n� o 1
    	brne d3			; >> Skok do cyklu d3
    	dec  r19		; >> Sni�uje po�et opakov�n� o 1
    	brne d3			; >> Skok do cyklu d3
    	dec  r18		; >> Sni�uje po�et opakov�n� o 1
    	brne d3			; >> Skok do cyklu d3
    	ret				; >> N�vrat z podprogramu

