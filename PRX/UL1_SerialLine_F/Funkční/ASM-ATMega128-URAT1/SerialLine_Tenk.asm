; >>               						<<
; >>   S�riov� linka  +  displej        <<
; >>   Vytvo�il Jakub Tenk         	 	<<
; >>   Ulo�eno na: github.com/DrGumik   <<
; >>               					 	<<

.nolist
.include "m128def.inc"
.list

.def temp = R16
.def sec_temp = R17

.equ portDisp = portB
.equ ddrDisp = ddrB
.equ portPos = portD
.equ ddrPos = ddrD
.equ bps_9600 = 103

.org 0x0000 jmp start
.org 0x003C jmp get_key		; >> USART1_RXC p�eru�en�

start:						; >> Inicializace
	ldi temp, LOW(RAMEND)	; >> Nastaven� z�sobn�ku
	out SPL, temp
	ldi temp, HIGH(RAMEND)
	out SPH, temp

	ldi temp, 0xFF			; >> Nastaven� port� pro displej a multiplex
	out ddrDisp, temp
	out ddrPos, temp

	call init_usart			; >> Podprogram pro inicializaci s�riov� linky
	call init_timer0		; >> Podprogram pro inicializaci timeru 0
	
	clr R18					; >> Vynulov�n� registr� R18-R25
	clr R19
	clr R20
	clr R21
	clr R22
	clr R23
	clr R24
	clr R25

	sei						; >> Glob�ln� povolen� p�eru�en�
	
	jmp main				; >> Skok do hlavn�ho k�du

main:
	ldi temp, 0b00000_011
	out portPos, temp 		; >> 1. pos displeje
	out portDisp, R18	
	call delay		

	ldi temp, 0b00000_010
	out portPos, temp 		; >> 2. pos displeje
	out portDisp, R19	
	call delay		

	ldi temp, 0b00000_001
	out portPos, temp 		; >> 3. pos displeje
	out portDisp, R20	
	call delay		
	
	ldi temp, 0b00000_000
	out portPos, temp 		; >> 4. pos displeje
	out portDisp, R21	
	call delay

	ldi temp, 0b00000_100
	out portPos, temp 		; >> 5. pos displeje
	out portDisp, R22	
	call delay

	ldi temp, 0b00000_101
	out portPos, temp 		; >> 6. pos displeje
	out portDisp, R23	
	call delay

	ldi temp, 0b00000_110
	out portPos, temp 		; >> 7. pos displeje
	out portDisp, R24	
	call delay

	ldi temp, 0b00000_111
	out portPos, temp 		; >> 8. pos displeje
	out portDisp, R25	
	call delay

	rjmp main

init_usart:
							; >> Nastaven� p�enosov� rychlosti (9600b/s)
	ldi temp, HIGH(bps_9600)
	sts UBRR1H, temp

	ldi temp, LOW(bps_9600)
	sts UBRR1L, temp
							; >> Povolen� RX a RXC p�eru�en�
	ldi temp, (1<<RXCIE1)|(1<<RXEN1)
	sts UCSR1B, temp
							; >> Nastaven� 1 stop bitu, velikosti framu 8 bit� a nastaven� async m�du
	ldi temp, (1<<UCSZ10|1<<UCSZ11)
	sts UCSR1C, temp

	ret 


init_timer0: 				; >> HW Delay (+- 2ms)
	ldi temp, 0b00001101 	; >> Hodnota pro nastaven� p�edd�li�ky
	out TCCR0, temp  		; >> Nastaven� p�edd�li�ky
	ldi temp, 255       	; >> Hodnota pro kompara�n� registr 
	out OCR0, temp  		; >> Na�ten� kompara�n� hodnoty
	ret

get_key:
	lds temp, UDR1			; >> P�e�ten� data z UDR1 do reg. temp
	
	mov R25, R24			; >> Posunut� "znaku na displeji" sm�rem do prava
	mov R24, R23
	mov R23, R22
	mov R22, R21
	mov R21, R20
	mov R20, R19
	mov R19, R18
	mov R18, temp

	reti

delay:
	out TIFR, temp
compare_time:  
	in temp,TIFR  			; >> Na�ten� hodnoty z TIFR do registru temp
	sbrs temp, 1		  	; >> Pokud hodnota OCF0 == 1, tak program presko�� instrukci jmp compare
	jmp compare_time
	out TIFR, temp			; >> Vynulov�n� TIFR
	ret
