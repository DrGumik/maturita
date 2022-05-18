; >>                     <<
; >> Programové zpoždìní <<
; >> Vytvoøil Jakub Tenk <<
; >>                     <<

.nolist ;vypne debug
.include "m128def.inc" 
.list ;zapne debug

.def temp = R16
.dseg
.org 0x100
.cseg
.org 0x0000

        ldi temp,LOW(RAMEND) ; >> Inicializace zásobníku
        out SPL,temp 
        ldi temp,HIGH(RAMEND) 
        out SPH,temp 

prog: 
        call delay1 	; >> 1. podprogram zpoždìní - 100us (provede 1600 cyklù)
        call delay2 	; >> 2. podprogram zpoždìní - 10ms (provede 160000 cyklù)
        call delay3 	; >> 3. podprogram zpoždìní - 100ms  (provede 1600000 cyklù)
konec:  rjmp konec

delay1: ldi  r18, 200 	; >> Nastavení poètu opakování
d1:     dec  r18		; >> Snižuje poèet opakování o 1
		nop				; >> Zavolání prázdné instrukce
		nop
		nop
        nop
		nop
        brne d1			; >> Skok do cyklu d1
        ret				; >> Návrat z podprogramu

delay2: ldi  r18, 208 	; >> Nastavení poètu opakování
        ldi  r19, 202 	; >> Nastavení poètu opakování
d2:     dec  r19		; >> Snižuje poèet opakování o 1
        brne d2			; >> Skok do cyklu d2
        dec  r18		; >> Snižuje poèet opakování o 1
        brne d2			; >> Skok do cyklu d2
        nop				; >> Zavolání prázdné instrukce
		ret				; >> Návrat z podprogramu

delay3: ldi  r18, 9		; >> Nastavení poètu opakování
    	ldi  r19, 30	; >> Nastavení poètu opakování
    	ldi  r20, 229	; >> Nastavení poètu opakování
d3: 	dec  r20		; >> Snižuje poèet opakování o 1
    	brne d3			; >> Skok do cyklu d3
    	dec  r19		; >> Snižuje poèet opakování o 1
    	brne d3			; >> Skok do cyklu d3
    	dec  r18		; >> Snižuje poèet opakování o 1
    	brne d3			; >> Skok do cyklu d3
    	ret				; >> Návrat z podprogramu

