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
.def counter = R18

.equ portDisp = portB
.equ ddrDisp = ddrB
.equ portPos = portD
.equ ddrPos = ddrD
.equ bps_9600 = 103

.org 0x0000 jmp start
.org ... jmp timer0_int
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
	
	sei						; >> Glob�ln� povolen� p�eru�en�
	
	jmp main				; >> Skok do smy�ky

main:
	jmp main

timer0_int:
	lpm temp, Z+
	out portPos, temp
	ld temp, X+
	out portDisp, temp
	dec counter
	brne ret_int

	ldi counter, 8
	ldi ZL, LOW(mp_pat_beg<<1)			
	ldi ZH, HIGH(mp_pat_beg<<1)

	ldi XL,LOW(disp_pat_beg<<1)
	ldi XH,HIGH(disp_pat_beg<<1)
	reti

ret_int:
	reti

init_usart:
							; >> Nastaven� rychlosti p�enosu (9600b/s)
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
	ldi temp, 0b00001101
	out TCCR0, temp
	ldi temp, 255
	out OCR0, temp
	ret

get_key:					; >> Posune data na displeji do leva, p�e�te dato ze s�riov� linky a ulo�� ho na 1. pozici
	ldi XL,LOW(disp_pat_beg<<1)
	ldi XH,HIGH(disp_pat_beg<<1)
	ldi YL,LOW(disp_pat_beg<<2)
	ldi YH,HIGH(disp_pat_beg<<2)
	ldi counter, 8
pattern_move:
	ld temp,X
	ld sec_temp,Y
	st X+,sec_temp
	st Y+,temp
	dec counter
	brne pattern_move

	lds temp, UDR1			; >> P�e�te data z UDR1
	
	ldi XL,LOW(disp_pat_beg<<1)
	ldi XH,HIGH(disp_pat_beg<<1)
	st X, temp

	ldi counter, 8
	ldi ZL, LOW(mp_pat_beg<<1)			
	ldi ZH, HIGH(mp_pat_beg<<1)

	reti

mp_pat_beg:
.db 0b00000_011, 0b00000_010, 0b00000_001, 0b00000_000, 0b00000_100, 0b00000_101, 0b00000_110, 0b00000_111
mp_pat_end:

disp_pat_beg:
.ds 0x00, 0x00
.ds 0x00, 0x00
.ds 0x00, 0x00
.ds 0x00, 0x00
disp_pat_end:
