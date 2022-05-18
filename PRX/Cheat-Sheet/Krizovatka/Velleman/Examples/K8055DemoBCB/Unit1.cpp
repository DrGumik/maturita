//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "Unit1.h"
#include "K8055D.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"
TForm1 *Form1;
  int n=8;
//---------------------------------------------------------------------------

__fastcall TForm1::TForm1(TComponent* Owner)
        : TForm(Owner)
{

}
//---------------------------------------------------------------------------

void __fastcall TForm1::Connect1Click(TObject *Sender)
{
  int CardAddr = 3 - (int(CheckBox1->Checked) + int(CheckBox2->Checked) * 2);
  int h = OpenDevice(CardAddr);
  switch (h) 
  {
    case  0:
    case  1:
    case  2:
    case  3: 
      Label1->Caption = "Card " + IntToStr(h) + " connected";
      Timer1->Enabled = true;
      break;
    case  -1 :
      Label1->Caption = "Card " + IntToStr(CardAddr) + " not found";
	  break;
  }
}
//---------------------------------------------------------------------------

void __fastcall TForm1::FormClose(TObject *Sender, TCloseAction &Action)
{
  CloseDevice() ;
}
//---------------------------------------------------------------------------


void __fastcall TForm1::SetAllDigital1Click(TObject *Sender)
{
  SetAllDigital();
  CheckBox8->Checked = true;
  CheckBox9->Checked = true;
  CheckBox10->Checked = true;
  CheckBox11->Checked = true;
  CheckBox12->Checked = true;
  CheckBox13->Checked = true;
  CheckBox14->Checked = true;
  CheckBox15->Checked = true;
}
//---------------------------------------------------------------------------


void __fastcall TForm1::ClearAllDigital1Click(TObject *Sender)
{
  ClearAllDigital();
  CheckBox8->Checked = false;
  CheckBox9->Checked = false;
  CheckBox10->Checked = false;
  CheckBox11->Checked = false;
  CheckBox12->Checked = false;
  CheckBox13->Checked = false;
  CheckBox14->Checked = false;
  CheckBox15->Checked = false;
}
//---------------------------------------------------------------------------

void __fastcall TForm1::SetAllAnalog1Click(TObject *Sender)
{
  SetAllAnalog();
  DAC1->Position = 0;
  DAC2->Position = 0;
}
//---------------------------------------------------------------------------

void __fastcall TForm1::ClearAllAnalog1Click(TObject *Sender)
{
  ClearAllAnalog();
  DAC1->Position = 255;
  DAC2->Position = 255;
}
//---------------------------------------------------------------------------

void __fastcall TForm1::DAC1Change(TObject *Sender)
{
  OutputAnalogChannel(1, 255-DAC1->Position);
  Label2->Caption = 255 - DAC1->Position;
}
//---------------------------------------------------------------------------

void __fastcall TForm1::DAC2Change(TObject *Sender)
{
  OutputAnalogChannel(2, 255-DAC2->Position);
  Label3->Caption = 255 - DAC2->Position;
}
//---------------------------------------------------------------------------

void __fastcall TForm1::Timer1Timer(TObject *Sender)
{
  Timer1->Enabled = false;
  int Data1;
  int Data2;
  int i;
  ReadAllAnalog(&Data1, &Data2);
  AD1->Position = Data1;
  AD2->Position = Data2;
  Label4->Caption = IntToStr(Data1);
  Label5->Caption = IntToStr(Data2);
  Counter1->Text = IntToStr(ReadCounter(1));
  Counter2->Text = IntToStr(ReadCounter(2));
  i = ReadAllDigital();
  CheckBox3->Checked = (i & 1)>0;
  CheckBox4->Checked = (i & 2)>0;
  CheckBox5->Checked = (i & 4)>0;
  CheckBox6->Checked = (i & 8)>0;
  CheckBox7->Checked = (i & 16)>0;
  Timer1->Enabled = true;
}
//---------------------------------------------------------------------------

void __fastcall TForm1::ResetCounter1Click(TObject *Sender)
{
  ResetCounter(1);
}
//---------------------------------------------------------------------------

void __fastcall TForm1::ResetCounter2Click(TObject *Sender)
{
  ResetCounter(2);
}
//---------------------------------------------------------------------------

void __fastcall TForm1::DebounceTime1Click(TObject *Sender)
{
  int t1;
   switch (DebounceTime1->ItemIndex) {
    case  0 : t1 = 0;
      break;
    case  1 : t1 = 2;
      break;
    case  2 : t1 = 10;
      break;
    case  3 : t1 = 1000;
   }
  SetCounterDebounceTime(1,t1);
}
//---------------------------------------------------------------------------

void __fastcall TForm1::DebounceTime2Click(TObject *Sender)
{
  int t2;
   switch (DebounceTime2->ItemIndex) {
    case  0 : t2 = 0;
      break;
    case  1 : t2 = 2;
      break;
    case  2 : t2 = 10;
      break;
    case  3 : t2 = 1000;
   }
  SetCounterDebounceTime(2,t2);
}
//---------------------------------------------------------------------------

void __fastcall TForm1::OutputTest1Click(TObject *Sender)
{
    Timer2->Enabled = OutputTest1->Down;
}
//---------------------------------------------------------------------------

void __fastcall TForm1::Timer2Timer(TObject *Sender)
{
  ClearDigitalChannel(n);
  n++;
  if (n == 9)
    n = 1;
  SetDigitalChannel(n);
}
//---------------------------------------------------------------------------

void __fastcall TForm1::Button1Click(TObject *Sender)
{
  int k;
  bool CardFound = false;
  Timer1->Enabled = false;
  RadioButton1->Enabled = false;
  RadioButton1->Checked = false;
  RadioButton2->Enabled = false;
  RadioButton2->Checked = false;
  RadioButton3->Enabled = false;
  RadioButton3->Checked = false;
  RadioButton4->Enabled = false;
  RadioButton4->Checked = false;
  k = SearchDevices();					
  if (k) 
        Timer1->Enabled = true;
  if (k & 1)
  {
        RadioButton1->Enabled = true;
        if (!CardFound)
        {
                RadioButton1->Checked = true;
                SetCurrentDevice (0);
                CardFound = true;
        }
  }
  if (k & 2)
  {
        RadioButton2->Enabled = true;
        if (!CardFound)
        {
                RadioButton2->Checked = true;
                SetCurrentDevice (1);
                CardFound = true;
        }
  }
  if (k & 4)
  {
        RadioButton3->Enabled = true;
        if (!CardFound)
        {
                RadioButton3->Checked = true;
                SetCurrentDevice (2);
                CardFound = true;
        }
  }
  if (k & 8)
  {
        RadioButton4->Enabled = true;
        if (!CardFound)
        {
                RadioButton4->Checked = true;
                SetCurrentDevice (3);
        }
  } 
}
//---------------------------------------------------------------------------

void __fastcall TForm1::RadioButton1Click(TObject *Sender)
{
  SetCurrentDevice (0);               // Set the current device command
}
//---------------------------------------------------------------------------

void __fastcall TForm1::RadioButton2Click(TObject *Sender)
{
  SetCurrentDevice (1);               // Set the current device command
}
//---------------------------------------------------------------------------

void __fastcall TForm1::RadioButton3Click(TObject *Sender)
{
  SetCurrentDevice (2);               // Set the current device command  
}
//---------------------------------------------------------------------------

void __fastcall TForm1::RadioButton4Click(TObject *Sender)
{
  SetCurrentDevice (3);               // Set the current device command
}
//---------------------------------------------------------------------------

void __fastcall TForm1::Button2Click(TObject *Sender)
{
        int ver = Version();
        Label7->Caption = IntToStr(ver >> 24)+"."+IntToStr((ver >> 16) & 0xFF)+"."
        +IntToStr((ver >> 8) & 0xFF)+"."+IntToStr(ver & 0xFF);
}
//---------------------------------------------------------------------------
 
void __fastcall TForm1::CheckBox8Click(TObject *Sender)
{
       CheckBox8->Checked ? SetDigitalChannel(1): ClearDigitalChannel(1);
}
//---------------------------------------------------------------------------

void __fastcall TForm1::CheckBox9Click(TObject *Sender)
{
       CheckBox9->Checked ? SetDigitalChannel(2): ClearDigitalChannel(2);
}
//---------------------------------------------------------------------------

void __fastcall TForm1::CheckBox10Click(TObject *Sender)
{
       CheckBox10->Checked ? SetDigitalChannel(3): ClearDigitalChannel(3);
}
//---------------------------------------------------------------------------

void __fastcall TForm1::CheckBox11Click(TObject *Sender)
{
       CheckBox11->Checked ? SetDigitalChannel(4): ClearDigitalChannel(4);
}
//---------------------------------------------------------------------------

void __fastcall TForm1::CheckBox12Click(TObject *Sender)
{
       CheckBox12->Checked ? SetDigitalChannel(5): ClearDigitalChannel(5);
}
//---------------------------------------------------------------------------

void __fastcall TForm1::CheckBox13Click(TObject *Sender)
{
       CheckBox13->Checked ? SetDigitalChannel(6): ClearDigitalChannel(6);
}
//---------------------------------------------------------------------------

void __fastcall TForm1::CheckBox14Click(TObject *Sender)
{
       CheckBox14->Checked ? SetDigitalChannel(7): ClearDigitalChannel(7);
}
//---------------------------------------------------------------------------

void __fastcall TForm1::CheckBox15Click(TObject *Sender)
{
       CheckBox15->Checked ? SetDigitalChannel(8): ClearDigitalChannel(8);
}
//---------------------------------------------------------------------------

