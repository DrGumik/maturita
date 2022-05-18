;Zpracujte program v programovac�m jazyce JSA ATMega128 ovl�daj�c� ur�en� p�ipojen� maticov� displej a kl�vesnici tak, aby obsahoval nejm�n� tyto funkce:
;1) stisknut� tla��tko kl�vesnice se ulo�� do pam�ti modulu MB-ATmega128, minim�ln� 5
;kl�ves, maxim�ln� 15 kl�ves
;2) ka�d� kl�vese bude p�i�azen vhodn� zobrazovan� symbol
;3) rozpozn�n� stavu vkl�d�n� znak� a stavu p�ehr�v�n� vlo�en�ch znak� ovl�dan�ch pomoc�
;maticov� kl�vesnice kl�vesnice
;4) p�ep�n�n� mezi t�mito re�imy
;5) vyu�it� v�ech vhodn�ch HW mo�nost� p��pravku MB-ATmega128.


; Alg. v1
; 1) Inicializace
; 2) Zapne <i> radek klavesnice
; 3) Precte <i> radek klavesnice a ulozi to promenne key
; 4) Dekrementuje <i>
; 5) Pokud se <i> nerovna nule pokracuje bodem 2. jinak bodem 6.
; 6) Vytahne z pole ... X+ ... 2 hodnoty (temp, sec_temp?) a porovna 1. hodnotu s hodnotou tlacitka
; 7) Pokud key == hodnota z X pokracuje bodem 9. jinak bodem 8
; 8) Dekrementace counteru
; 9) Nastavi ukazatel do datove pameti se vzory pro displej dle hodnoty sec_temp
; 10) Prehraje vzory na displeji
; 11) Pokracuje bodem 2
;
; Alg. v2
; 1) Inicializace
; 2) Zapne <i> radek klavesnice
; 3) Precte <i> radek klavesnice a ulozi to promenne key
; 4) Vytahne z pole ... X+ ... 2 hodnoty (temp, sec_temp?) a porovna 1. hodnotu s hodnotou tlacitka
; 5) Pokud key == temp pokracuje bodem 7. jinak bodem 6 NEBO key == DEF. BTN pokracuje bodem 8
; 6) Dekrementuje <i> + skok na bod 2.
; 7) Nahraje sec_temp do Y+, sec_counter++, skok na bod 2.
; 8) Nastavi ukazatel do datove pameti se vzory pro displej dle hodnoty sec_temp
; 9) Prehraje vzor na displeji (5x)
; 10) dec sec_counter
; 11) brne bod 8
; 12) jmp bod 2
;
; Celej displej 1 port -> 0b1_0000000  - 0bCLK_VZOR
; CLK - 0 = neposune; 1 = posune "sloupec"
;
; Alg v3:
;	Main:
; 	1) Inicializace
; 	2) Zapne <i> radek klavesnice
; 	3) Precte <i> radek klavesnice a ulozi to promenne key
; 	4) Vytahne z pole ... X+ ... 2 hodnoty (temp, sec_temp?) a porovna 1. hodnotu s hodnotou tlacitka
; 	5) Pokud key == temp pokracuje bodem 7. jinak bodem 6 NEBO key == DEF. BTN pokracuje bodem 8
; 	6) Dekrementuje <i> + skok na bod 2.
; 	7) Nahraje sec_temp do Y+, sec_counter++, skok na bod 2.
; 	8) Nastavi ukazatel do datove pameti se vzory pro displej dle hodnoty sec_temp
; 	9) Pokracuje bodem 2.
;
;  Int_timer0:
;	1) Ode�le na portDisp 0
;	2) Na�te hodnotu z Y+ do temp
;	3) Ode�le na portDisp hodnotu z temp
;	4) Ode�le na portDisp byte kde D7 je 1
;	5) Dekrementace counteruDisp
;	6) Pokud counterDisp == 0
;		a) ANO = pokracuj bodem 7.
;		b) NE = RETI