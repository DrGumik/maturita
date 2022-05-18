unit K8055;

interface

uses
  Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms, Dialogs,
  StdCtrls, ExtCtrls, ComCtrls, Math, Buttons;

type
  TForm1 = class(TForm)
    GroupBox1: TGroupBox;
    SK6: TCheckBox;
    SK5: TCheckBox;
    Timer1: TTimer;
    Button3: TButton;
    Label12: TLabel;
    GroupBox2: TGroupBox;
    CheckBox1: TCheckBox;
    CheckBox2: TCheckBox;
    CheckBox3: TCheckBox;
    GroupBox3: TGroupBox;
    CheckBox4: TCheckBox;
    CheckBox5: TCheckBox;
    CheckBox6: TCheckBox;
    CheckBox7: TCheckBox;
    CheckBox8: TCheckBox;
    CheckBox9: TCheckBox;
    CheckBox10: TCheckBox;
    CheckBox11: TCheckBox;
    CheckBox12: TCheckBox;
    CheckBox13: TCheckBox;
    GroupBox4: TGroupBox;
    Edit1: TEdit;
    Button1: TButton;
    GroupBox5: TGroupBox;
    Edit2: TEdit;
    Button2: TButton;
    RadioGroup1: TRadioGroup;
    RadioGroup2: TRadioGroup;
    Button4: TButton;
    Button5: TButton;
    Button6: TButton;
    Button7: TButton;
    Timer2: TTimer;
    SpeedButton1: TSpeedButton;
    GroupBox6: TGroupBox;
    TrackBar1: TTrackBar;
    Label10: TLabel;
    GroupBox7: TGroupBox;
    TrackBar2: TTrackBar;
    Label7: TLabel;
    GroupBox8: TGroupBox;
    ProgressBar1: TProgressBar;
    Label14: TLabel;
    GroupBox9: TGroupBox;
    ProgressBar2: TProgressBar;
    Label16: TLabel;
    GroupBox10: TGroupBox;
    Button8: TButton;
    Button9: TButton;
    Label1: TLabel;
    Label2: TLabel;
    RadioButton1: TRadioButton;
    RadioButton2: TRadioButton;
    RadioButton3: TRadioButton;
    RadioButton4: TRadioButton;
    procedure Button3Click(Sender: TObject);
    procedure Timer1Timer(Sender: TObject);
    procedure Button1Click(Sender: TObject);
    procedure TrackBar1Change(Sender: TObject);
    procedure TrackBar2Change(Sender: TObject);
    procedure Button2Click(Sender: TObject);
    procedure RadioGroup1Click(Sender: TObject);
    procedure RadioGroup2Click(Sender: TObject);
    procedure Button4Click(Sender: TObject);
    procedure Button5Click(Sender: TObject);
    procedure Button6Click(Sender: TObject);
    procedure Button7Click(Sender: TObject);
    procedure DigitalOut(Sender: TObject);
    procedure Timer2Timer(Sender: TObject);
    procedure SpeedButton1Click(Sender: TObject);
    procedure FormClose(Sender: TObject; var Action: TCloseAction);
    procedure Button8Click(Sender: TObject);
    procedure RadioButton1Click(Sender: TObject);
    procedure RadioButton2Click(Sender: TObject);
    procedure RadioButton3Click(Sender: TObject);
    procedure RadioButton4Click(Sender: TObject);
    procedure Button9Click(Sender: TObject);
    procedure CheckBox6Click(Sender: TObject);
    procedure CheckBox7Click(Sender: TObject);
    procedure CheckBox8Click(Sender: TObject);
    procedure CheckBox9Click(Sender: TObject);
    procedure CheckBox10Click(Sender: TObject);
    procedure CheckBox11Click(Sender: TObject);
    procedure CheckBox12Click(Sender: TObject);
    procedure CheckBox13Click(Sender: TObject);
  
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;
  n:integer;

implementation

{$R *.DFM}
function SetCurrentDevice(CardAddress: integer): integer; stdcall; external 'K8055d.dll';
function OpenDevice(CardAddress: integer): integer; stdcall; external 'K8055d.dll';
function SearchDevices: integer; stdcall; external 'K8055d.dll';
function Version: integer; stdcall; external 'K8055d.dll';
procedure CloseDevice; stdcall; external 'K8055d.dll';
function ReadAnalogChannel(Channel: integer):integer; stdcall; external 'K8055d.dll';
procedure ReadAllAnalog(var Data1, Data2: integer); stdcall; external 'K8055d.dll';
procedure OutputAnalogChannel(Channel: integer; Data: integer); stdcall; external 'K8055d.dll';
procedure OutputAllAnalog(Data1: integer; Data2: integer); stdcall; external 'K8055d.dll';
procedure ClearAnalogChannel(Channel: integer); stdcall; external 'K8055d.dll';
procedure ClearAllAnalog; stdcall; external 'K8055d.dll';
procedure SetAnalogChannel(Channel: integer); stdcall; external 'K8055d.dll';
procedure SetAllAnalog; stdcall; external 'K8055d.dll';
procedure WriteAllDigital(Data: integer);stdcall;  external 'K8055d.dll';
procedure ClearDigitalChannel(Channel: integer); stdcall; external 'K8055d.dll';
procedure ClearAllDigital; stdcall; external 'K8055d.dll';
procedure SetDigitalChannel(Channel: integer); stdcall; external 'K8055d.dll';
procedure SetAllDigital; stdcall; external 'K8055d.dll';
function ReadDigitalChannel(Channel: integer): Boolean; stdcall; external 'K8055d.dll';
function ReadAllDigital: integer; stdcall; external 'K8055d.dll';
function ReadCounter(CounterNr: integer): integer; stdcall; external 'K8055d.dll';
procedure ResetCounter(CounterNr: integer); stdcall; external 'K8055d.dll';
procedure SetCounterDebounceTime(CounterNr, DebounceTime:integer); stdcall; external 'K8055d.dll';

procedure TForm1.Button3Click(Sender: TObject);
var h,CardAddr:integer;
begin
  CardAddr:= 3-(integer(sk5.Checked) + integer(sk6.Checked) * 2);
  h:= OpenDevice(CardAddr);
  case h of
    0..3: label12.caption:='Card '+ inttostr(h)+' connected';
    -1: label12.caption:='Card '+ inttostr(CardAddr)+' not found';
  end;
  if h>=0 then Timer1.Enabled:=True;
end;
 
procedure TForm1.FormClose(Sender: TObject; var Action: TCloseAction);
begin
  CloseDevice;
end;

procedure TForm1.Timer1Timer(Sender: TObject);
var i, Data1, Data2: integer;
begin
  timer1.enabled:=false;
  Edit1.text:=inttostr(ReadCounter(1));
  Edit2.text:=inttostr(ReadCounter(2));
  ReadAllAnalog(Data1,Data2);
  ProgressBar1.Position:=Data1;
  ProgressBar2.Position:=Data2;
  Label14.caption:=inttostr(Data1);
  Label16.caption:=inttostr(Data2);
  i:=ReadAllDigital;
  CheckBox1.checked:=(i and 1)>0;
  CheckBox2.checked:=(i and 2)>0;
  CheckBox3.checked:=(i and 4)>0;
  CheckBox4.checked:=(i and 8)>0;
  CheckBox5.checked:=(i and 16)>0;
  timer1.enabled:=true;
end;


procedure TForm1.Timer2Timer(Sender: TObject);
begin
    ClearDigitalChannel(n);
    TCheckBox(Form1.FindComponent('CheckBox'+inttostr(n+5))).checked:=false;
    inc(n);
    if n=9 then n:=1;
    TCheckBox(Form1.FindComponent('CheckBox'+inttostr(n+5))).checked:=true;
    SetDigitalChannel(n);
end;

procedure TForm1.Button4Click(Sender: TObject);
begin
  SetAllDigital;
  CheckBox6.checked:=true;
  CheckBox7.checked:=true;
  CheckBox8.checked:=true;
  CheckBox9.checked:=true;
  CheckBox10.checked:=true;
  CheckBox11.checked:=true;
  CheckBox12.checked:=true;
  CheckBox13.checked:=true;
end;

procedure TForm1.Button6Click(Sender: TObject);
begin
  ClearAllDigital;
  CheckBox6.checked:=false;
  CheckBox7.checked:=false;
  CheckBox8.checked:=false;
  CheckBox9.checked:=false;
  CheckBox10.checked:=false;
  CheckBox11.checked:=false;
  CheckBox12.checked:=false;
  CheckBox13.checked:=false;
end;

procedure TForm1.Button5Click(Sender: TObject);
begin
  SetAllAnalog;
  TrackBar1.position:=0;
  TrackBar2.position:=0;
end;

procedure TForm1.Button7Click(Sender: TObject);
begin
  ClearAllAnalog;
  TrackBar1.position:=255;
  TrackBar2.position:=255;
end;

procedure TForm1.SpeedButton1Click(Sender: TObject);
begin
  timer2.enabled:=SpeedButton1.Down;
end;

procedure TForm1.Button1Click(Sender: TObject);
begin
  ResetCounter(1);
end;

procedure TForm1.Button2Click(Sender: TObject);
begin
  ResetCounter(2);
end;

procedure TForm1.RadioGroup1Click(Sender: TObject);
var t1:integer;
begin
  case RadioGroup1.ItemIndex of
    0: t1:=0;
    1: t1:=2;
    2: t1:=10;
    3: t1:=1000;
  end;
  SetCounterDebounceTime(1,t1);
end;

procedure TForm1.RadioGroup2Click(Sender: TObject);
var t2:integer;
begin
  case RadioGroup2.ItemIndex of
    0: t2:=0;
    1: t2:=2;
    2: t2:=10;
    3: t2:=1000;
  end;
  SetCounterDebounceTime(2,t2);
end;

procedure TForm1.TrackBar1Change(Sender: TObject);
begin
  OutputAnalogChannel(1,255-TrackBar1.position);
  Label10.caption:=inttostr(255-TrackBar1.position);
end;

procedure TForm1.TrackBar2Change(Sender: TObject);
begin
  OutputAnalogChannel(2,255-TrackBar2.position);
  Label7.caption:=inttostr(255-TrackBar2.position);
end;

procedure TForm1.DigitalOut(Sender: TObject);
begin
  if CheckBox6.checked then SetDigitalChannel(1)
    else ClearDigitalChannel(1);
  if CheckBox7.checked then SetDigitalChannel(2)
    else ClearDigitalChannel(2);
  if CheckBox8.checked then SetDigitalChannel(3)
    else ClearDigitalChannel(3);
  if CheckBox9.checked then SetDigitalChannel(4)
    else ClearDigitalChannel(4);
  if CheckBox10.checked then SetDigitalChannel(5)
    else ClearDigitalChannel(5);
  if CheckBox11.checked then SetDigitalChannel(6)
    else ClearDigitalChannel(6);
  if CheckBox12.checked then SetDigitalChannel(7)
    else ClearDigitalChannel(7);
  if CheckBox13.checked then SetDigitalChannel(8)
    else ClearDigitalChannel(8);
end;

procedure TForm1.Button8Click(Sender: TObject);
var k: integer;
CardFound: boolean;
begin
  CardFound:=False;
  Timer1.Enabled:= False;
  RadioButton1.Enabled:=False;
  RadioButton2.Enabled:=False;
  RadioButton3.Enabled:=False;
  RadioButton4.Enabled:=False;   
  k:=SearchDevices;
  if k > 0 then Timer1.Enabled:=True;
  if (k and 1)>0 then
  begin
    CardFound:=True;
    RadioButton1.Enabled:=True;
    RadioButton1.Checked:=True;
    SetCurrentDevice(0);
  end;
  if (k and 2)>0 then
  begin
    RadioButton2.Enabled:=True;
    if not CardFound then
    begin
      CardFound:=True;
      RadioButton2.Checked:=True;
      SetCurrentDevice(1);
    end;
  end;
  if (k and 4)>0 then
  begin
    RadioButton3.Enabled:=True;
    if not CardFound then
    begin
      CardFound:=True;
      RadioButton3.Checked:=True;
      SetCurrentDevice(2);
    end;
  end;
  if (k and 8)>0 then
  begin
    RadioButton4.Enabled:=True;
    if not CardFound then
    begin
      RadioButton4.Checked:=True;
      SetCurrentDevice(3)
    end;
  end; 
end;

procedure TForm1.RadioButton1Click(Sender: TObject);
begin
  SetCurrentDevice(0);
end;

procedure TForm1.RadioButton2Click(Sender: TObject);
begin
  SetCurrentDevice(1);
end;

procedure TForm1.RadioButton3Click(Sender: TObject);
begin
  SetCurrentDevice(2);
end;

procedure TForm1.RadioButton4Click(Sender: TObject);
begin
  SetCurrentDevice(3);
end;

procedure TForm1.Button9Click(Sender: TObject);
var ver:integer;
begin
  ver:=Version;
  Label1.Caption:=inttostr(ver shr 24)+'.'+inttostr($FF and (ver shr 16))
    +'.'+inttostr($FF and (ver shr 8))+'.'+inttostr($FF and ver);
end;

procedure TForm1.CheckBox6Click(Sender: TObject);
begin
  if CheckBox6.checked then SetDigitalChannel(1)
    else ClearDigitalChannel(1);
end;

procedure TForm1.CheckBox7Click(Sender: TObject);
begin
  if CheckBox7.checked then SetDigitalChannel(2)
    else ClearDigitalChannel(2);
end;

procedure TForm1.CheckBox8Click(Sender: TObject);
begin
  if CheckBox8.checked then SetDigitalChannel(3)
    else ClearDigitalChannel(3);
end;

procedure TForm1.CheckBox9Click(Sender: TObject);
begin
  if CheckBox9.checked then SetDigitalChannel(4)
    else ClearDigitalChannel(4);
end;

procedure TForm1.CheckBox10Click(Sender: TObject);
begin
  if CheckBox10.checked then SetDigitalChannel(5)
    else ClearDigitalChannel(5);
end;

procedure TForm1.CheckBox11Click(Sender: TObject);
begin
  if CheckBox11.checked then SetDigitalChannel(6)
    else ClearDigitalChannel(6);
end;

procedure TForm1.CheckBox12Click(Sender: TObject);
begin
  if CheckBox12.checked then SetDigitalChannel(7)
    else ClearDigitalChannel(7);
end;

procedure TForm1.CheckBox13Click(Sender: TObject);
begin
  if CheckBox13.checked then SetDigitalChannel(8)
    else ClearDigitalChannel(8);
end;

end.
