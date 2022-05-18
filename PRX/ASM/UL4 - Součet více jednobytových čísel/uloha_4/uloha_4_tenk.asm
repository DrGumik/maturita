; >>                                 <<
; >> Sou�et v�ce jednobytov�ch ��sel <<
; >>      Vytvo�il Jakub Tenk        <<
; >>                                 <<

.nolist ;neprov�d� v�pis na obrazovku (debug)
.include "m128def.inc"
.list  ;po include zacne znovu v�pis na obrazovku (debug)

.def poc_opak = R22
.def clear_bl = R23

.cseg

        ldi XL, 0x00    ; >> Definov�n� 1. bloku pro ukl�d�n� meziv�sledk� a kone�n�ho vysledku
        ldi XH, 0x01    ; >> 
        ldi YL, 0x00    ; >> Definov�n� 2. bloku pro ukl�d�n� na�ten�ch ��sel z programov� pam�ti
        ldi YH, 0x02    ; >> 
        ldi poc_opak, 5    ; >> Nastaven� hodnoty po�tu opakov�n� (3x)
		ldi clear_bl, 0x00 ; >> Nastaven� hodnoty, kter� se nastav� na za��tku v pam�ti na adrese 100
		st X,clear_bl	; >> Nastaven� hodnoty 0 v pam�ti na drese 100



        ldi ZL, LOW(cislo<<1)    ; >> odk�z�n� ukazatele Z do programov� pam�ti
        ldi ZH, HIGH(cislo<<1) ; >> na m�sto (adresa) kde se nach�z� cislo1
                                
skok1:     
		lpm R16, Z+
        st Y+,R16        ; >> Z�pis 1. ��sla do 1. bloku
        dec poc_opak
        brne skok1

        ; >> Resetov�n� hodnoty po�tu opakov�n�, nastaven� na 3
        clr poc_opak
        ldi poc_opak,5
        ; >>


        ldi YL, 0x00    ; >> Znovu definov�n� 2. bloku pro ukl�d�n� na��t�n� ��sel
        ldi YH, 0x02    ; >> 

soucet:  
        ld R16, Y+      ; >> na�ten� ��sla
        ld R17, X       ; >> na�ten� meziv�sledku z pam�ti na adrese 100 (p�i za��tku programu je hodnota 0)

        add R17, R16    ; >> R17 = R17+R16
        st X,R17        ; >> Ulo�en� sou�tu do pam�ti na adresu 100

        dec poc_opak
        brne soucet



cislo: .db 0x01, 0x02, 0x03, 0x04, 0x05
konec:	rjmp konec
