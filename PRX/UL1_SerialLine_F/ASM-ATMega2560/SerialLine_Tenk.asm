; >>               					 	<<
; >>   S�riov� linka  +  displej      	<<
; >>   Vytvo�il: Jakub Tenk      	 	<<
; >>   Ulo�eno na: github.com/DrGumik   <<
; >>               				        <<

; >>   TEST JENOM S LED PRO ATMEGA2560  <<

.nolist
.include "m2560def.inc"
.list

.def temp = R16
.def sec_temp = R17

.equ portDisp = portB
.equ ddrDisp = ddrB

.org 0x0000 jmp start
.org 0x0032 jmp get_key

start:
	ldi temp, LOW(RAMEND)
	out SPL, temp
	ldi temp, HIGH(RAMEND)
	out SPH, temp

	ldi temp, 0xFF
	out ddrDisp, temp

	call init_usart
	call init_timer0
	
	clr R20
	out portDisp, R20

	sei
	
	rjmp main

main:
	jmp main

get_key:
	lds R20, UDR0
	out portDisp, R20
	reti


init_usart:
	ldi temp, 103
	sts UBRR0H, temp

	ldi temp, 0
	sts UBRR0L, temp
							; >> Povolen� RX, TX a RXC p�eru�en�
	ldi temp, (1<<RXCIE0)|(1<<RXEN0)
	sts UCSR0B, temp
							; >> Nastaven� 1 stop bitu, velikosti framu 8 bit� a nastaven� async m�du
	ldi temp, (1<<UCSZ00|1<<UCSZ01)
	sts UCSR0C, temp
	ret 


init_timer0: 				; >> HW Delay (+- 2ms)
	ldi temp, 0b00001101 	; >> Hodnota pro nastaven� p�edd�li�ky
	out TCCR0A, temp  		; >> Nastaven� p�edd�li�ky
	ldi temp, 255       	; >> Hodnota pro kompara�n� registr 
	out OCR0A, temp  		; >> Na�ten� kompara�n� hodnoty
	ret

delay:
	out TIFR0, temp
compare_time:  
	in temp,TIFR0 			; >> Na�ten� hodnoty z TIFR do registru temp
	sbrs temp, 1		  	; >> Pokud hodnota OCF0 == 1, tak program presko�� instrukci jmp compare
	jmp compare_time
	out TIFR0, temp			; >> Vynulov�n� TIFR
	ret
