; >>                                 <<
; >> Souèet více jednobytových èísel <<
; >>      Vytvoøil Jakub Tenk        <<
; >>                                 <<

.nolist ;neprovádí výpis na obrazovku (debug)
.include "m128def.inc"
.list  ;po include zacne znovu výpis na obrazovku (debug)

.def poc_opak = R22
.def clear_bl = R23

.cseg

        ldi XL, 0x00    ; >> Definování 1. bloku pro ukládání mezivýsledkù a koneèného vysledku
        ldi XH, 0x01    ; >> 
        ldi YL, 0x00    ; >> Definování 2. bloku pro ukládání naètených èísel z programové pamìti
        ldi YH, 0x02    ; >> 
        ldi poc_opak, 5    ; >> Nastavení hodnoty poètu opakování (3x)
		ldi clear_bl, 0x00 ; >> Nastavení hodnoty, která se nastaví na zaèátku v pamìti na adrese 100
		st X,clear_bl	; >> Nastavení hodnoty 0 v pamìti na drese 100



        ldi ZL, LOW(cislo<<1)    ; >> odkázání ukazatele Z do programové pamìti
        ldi ZH, HIGH(cislo<<1) ; >> na místo (adresa) kde se nachází cislo1
                                
skok1:     
		lpm R16, Z+
        st Y+,R16        ; >> Zápis 1. èísla do 1. bloku
        dec poc_opak
        brne skok1

        ; >> Resetování hodnoty poètu opakování, nastavení na 3
        clr poc_opak
        ldi poc_opak,5
        ; >>


        ldi YL, 0x00    ; >> Znovu definování 2. bloku pro ukládání naèítání èísel
        ldi YH, 0x02    ; >> 

soucet:  
        ld R16, Y+      ; >> naètení èísla
        ld R17, X       ; >> naètení mezivýsledku z pamìti na adrese 100 (pøi zaèátku programu je hodnota 0)

        add R17, R16    ; >> R17 = R17+R16
        st X,R17        ; >> Uložení souètu do pamìti na adresu 100

        dec poc_opak
        brne soucet



cislo: .db 0x01, 0x02, 0x03, 0x04, 0x05
konec:	rjmp konec
