; >>               						<<
; >>      Obsluha krokového motoru      <<
; >>        Vytvoøil Jakub Tenk         <<
; >> 		 github.com/DrGumik			<<
; >>               						<<

.nolist
.include "m128def.inc"
.list

.def temp = R16
.def rotL = R17
.def rotR = R18
.def poc_opak = R19
.def speed = R20
.def rotates = R21
.def direction = R22
.def dataDIP = R23
.equ portKM = portD		; >> Port krokového motoru
.equ ddrKM = ddrD
.equ portDIP = portB
.equ ddrDIP = ddrB		; >> Port DIP spínaèe
.equ pinDIP = pinB

	ldi temp, LOW(RAMEND)
	out SPL, temp
	ldi temp, HIGH(RAMEND)
	out SPH, temp

	ldi temp, 0x0F
	out ddrKM, temp

	ldi temp, 0x00
	out ddrDIP, temp

start:
	ldi direction, 1			; >> Základní nastavení -> otáèení vlevo, rychlé otáèení, 2 otáèky
	ldi rotates, 0x32
	
	in temp, pinDIP				; >> Pøeètení portu s DIP spínaèem

	cp temp, dataDIP
	breq start

	sbrs temp, 0				; >> Zmìna smìru, 1 = vlevo, 2 = vpravo
	ldi direction, 2
	sbrs temp, 2				; >> Zmìna poètu otáèek, 0x32 = 2 otáèky, 0x64 = 4 otáèky, 
	ldi rotates, 0x64
	jmp direct

direct:							; >> Rozpoznání smìru otáèení
	cpi direction, 1
	breq rotateL
	jmp rotateR

rotateL:						; >> Naètení programové pamìti s daty pro otáèení na levou stranu
	ldi ZL, LOW(tb_rotL<<1)
	ldi ZH, HIGH(tb_rotL<<1)
	jmp process
rotateR:						; >> Naètení programové pamìti s daty pro otáèení na pravou stranu
	ldi ZL, LOW(tb_rotR<<1)
	ldi ZH, HIGH(tb_rotR<<1)
	jmp process

process:						; >> Proces otáèení motoru
	lpm temp, Z+
	out portKM, temp
	call delay

	lpm temp, Z+
	out portKM, temp
	call delay

	lpm temp, Z+
	out portKM, temp
	call delay

	lpm temp, Z
	out portKM, temp
	call delay

	dec rotates
	brne direct
	in dataDIP, pinDIP
	jmp start

delay:							; >> Podprogram delay - dvì rychlosti (øídí se èísly 2 a 4)
	in temp, pinDIP				; >> Pøeètení portu s DIP spínaèem
	ldi speed, 4
	sbrs temp, 1				; >> Zmìna rychlosti, 4 = rychle, 6 = pomalu
	ldi speed, 6
set_timer:
	ldi temp, 0b0000_1101
	out TCCR0, temp
	ldi temp, 255
	out OCR0, temp
compare:
	in temp, TIFR
	sbrs temp, 1
	jmp compare
	out TIFR, temp
	dec speed
	brne set_timer
	ret

tb_rotL:	; >> Data pro otáèení motoru na levou stranu
.db 0b0000_0001, 0b0000_0100, 0b0000_0010, 0b0000_1000

tb_rotR:	; >> Data pro otáèení motoru na pravou stranu
.db 0b0000_1000, 0b0000_0010, 0b0000_0100, 0b0000_0001
