//---------------------------------------------------------------------------

#ifndef Unit1H
#define Unit1H
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
#include <ComCtrls.hpp>
#include <Buttons.hpp>
#include <ExtCtrls.hpp>
//---------------------------------------------------------------------------
class TForm1 : public TForm
{
__published:	// IDE-managed Components
        TGroupBox *GroupBox1;
        TCheckBox *CheckBox1;
        TCheckBox *CheckBox2;
  TButton *Connect1;
        TLabel *Label1;
        TGroupBox *GroupBox2;
        TLabel *Label2;
  TTrackBar *DAC1;
        TGroupBox *GroupBox3;
        TLabel *Label3;
  TTrackBar *DAC2;
        TGroupBox *GroupBox4;
        TLabel *Label4;
  TProgressBar *AD1;
  TSpeedButton *OutputTest1;
  TButton *SetAllDigital1;
  TButton *ClearAllDigital1;
  TButton *SetAllAnalog1;
        TButton *ClearAllAnalog1;
        TGroupBox *GroupBox5;
        TLabel *Label5;
  TProgressBar *AD2;
        TGroupBox *GroupBox6;
        TGroupBox *GroupBox7;
        TGroupBox *GroupBox8;
  TEdit *Counter1;
  TButton *ResetCounter1;
  TRadioGroup *DebounceTime1;
        TGroupBox *GroupBox9;
  TEdit *Counter2;
  TButton *ResetCounter2;
  TRadioGroup *DebounceTime2;
        TTimer *Timer1;
        TTimer *Timer2;
  TCheckBox *CheckBox3;
  TCheckBox *CheckBox4;
  TCheckBox *CheckBox5;
  TCheckBox *CheckBox6;
  TCheckBox *CheckBox7;
  TGroupBox *GroupBox10;
  TRadioButton *RadioButton1;
  TRadioButton *RadioButton2;
  TRadioButton *RadioButton3;
  TRadioButton *RadioButton4;
  TLabel *Label6;
  TButton *Button1;
  TButton *Button2;
        TCheckBox *CheckBox8;
        TCheckBox *CheckBox9;
        TCheckBox *CheckBox10;
        TCheckBox *CheckBox11;
        TCheckBox *CheckBox12;
        TCheckBox *CheckBox13;
        TCheckBox *CheckBox14;
        TCheckBox *CheckBox15;
        TLabel *Label7;
        void __fastcall Connect1Click(TObject *Sender);
  void __fastcall FormClose(TObject *Sender, TCloseAction &Action);
  void __fastcall SetAllDigital1Click(TObject *Sender);
  void __fastcall ClearAllDigital1Click(TObject *Sender);
  void __fastcall SetAllAnalog1Click(TObject *Sender);
  void __fastcall DAC1Change(TObject *Sender);
  void __fastcall DAC2Change(TObject *Sender);
  void __fastcall ClearAllAnalog1Click(TObject *Sender);
  void __fastcall Timer1Timer(TObject *Sender);
  void __fastcall ResetCounter1Click(TObject *Sender);
  void __fastcall ResetCounter2Click(TObject *Sender);
  void __fastcall DebounceTime1Click(TObject *Sender);
  void __fastcall DebounceTime2Click(TObject *Sender);
  void __fastcall OutputTest1Click(TObject *Sender);
  void __fastcall Timer2Timer(TObject *Sender);
  void __fastcall Button1Click(TObject *Sender);
  void __fastcall RadioButton1Click(TObject *Sender);
  void __fastcall RadioButton2Click(TObject *Sender);
  void __fastcall RadioButton3Click(TObject *Sender);
  void __fastcall RadioButton4Click(TObject *Sender);
  void __fastcall Button2Click(TObject *Sender);
        void __fastcall CheckBox8Click(TObject *Sender);
        void __fastcall CheckBox9Click(TObject *Sender);
        void __fastcall CheckBox10Click(TObject *Sender);
        void __fastcall CheckBox11Click(TObject *Sender);
        void __fastcall CheckBox12Click(TObject *Sender);
        void __fastcall CheckBox13Click(TObject *Sender);
        void __fastcall CheckBox14Click(TObject *Sender);
        void __fastcall CheckBox15Click(TObject *Sender);
private:	// User declarations

public:		// User declarations
        __fastcall TForm1(TComponent* Owner);
};
//---------------------------------------------------------------------------
extern PACKAGE TForm1 *Form1;
//---------------------------------------------------------------------------
#endif
