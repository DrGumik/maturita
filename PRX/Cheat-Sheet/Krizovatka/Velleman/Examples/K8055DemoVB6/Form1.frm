VERSION 5.00
Begin VB.Form Form1 
   Caption         =   "K8055 Demo"
   ClientHeight    =   4950
   ClientLeft      =   60
   ClientTop       =   345
   ClientWidth     =   10890
   LinkTopic       =   "Form1"
   ScaleHeight     =   4950
   ScaleWidth      =   10890
   StartUpPosition =   3  'Windows Default
   Begin VB.Frame Frame10 
      Caption         =   "Multicard Commands"
      Height          =   4815
      Left            =   9060
      TabIndex        =   53
      Top             =   60
      Width           =   1755
      Begin VB.CommandButton Command2 
         Caption         =   "DLL Version"
         Height          =   375
         Left            =   120
         TabIndex        =   59
         Top             =   3900
         Width           =   1515
      End
      Begin VB.CommandButton Command1 
         Caption         =   "Search Devices"
         Height          =   375
         Left            =   120
         TabIndex        =   58
         Top             =   3120
         Width           =   1515
      End
      Begin VB.OptionButton Option3 
         Caption         =   "Device 3"
         Enabled         =   0   'False
         Height          =   255
         Index           =   3
         Left            =   300
         TabIndex        =   57
         Top             =   2460
         Width           =   1215
      End
      Begin VB.OptionButton Option3 
         Caption         =   "Device 2"
         Enabled         =   0   'False
         Height          =   255
         Index           =   2
         Left            =   300
         TabIndex        =   56
         Top             =   1980
         Width           =   1155
      End
      Begin VB.OptionButton Option3 
         Caption         =   "Device 1"
         Enabled         =   0   'False
         Height          =   255
         Index           =   1
         Left            =   300
         TabIndex        =   55
         Top             =   1500
         Width           =   1215
      End
      Begin VB.OptionButton Option3 
         Caption         =   "Device 0"
         Enabled         =   0   'False
         Height          =   255
         Index           =   0
         Left            =   300
         TabIndex        =   54
         Top             =   1020
         Width           =   1095
      End
      Begin VB.Label Label5 
         Caption         =   "- - -"
         Height          =   195
         Left            =   180
         TabIndex        =   61
         Top             =   4440
         Width           =   1395
      End
      Begin VB.Label Label2 
         Caption         =   "Set Current Device"
         Height          =   375
         Left            =   180
         TabIndex        =   60
         Top             =   540
         Width           =   1395
      End
   End
   Begin VB.Frame Frame9 
      Caption         =   "Counter2"
      Height          =   2595
      Left            =   7320
      TabIndex        =   45
      Top             =   2280
      Width           =   1635
      Begin VB.TextBox Text2 
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   8.25
            Charset         =   0
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   285
         Left            =   180
         TabIndex        =   21
         Text            =   "0"
         Top             =   300
         Width           =   1275
      End
      Begin VB.OptionButton Option2 
         Caption         =   "0ms"
         Height          =   195
         Index           =   0
         Left            =   180
         TabIndex        =   22
         Top             =   1320
         Width           =   675
      End
      Begin VB.OptionButton Option2 
         Caption         =   "2ms"
         Height          =   195
         Index           =   1
         Left            =   180
         TabIndex        =   23
         Top             =   1620
         Value           =   -1  'True
         Width           =   675
      End
      Begin VB.OptionButton Option2 
         Caption         =   "10ms"
         Height          =   195
         Index           =   2
         Left            =   180
         TabIndex        =   48
         Top             =   1920
         Width           =   795
      End
      Begin VB.OptionButton Option2 
         Caption         =   "1000ms"
         Height          =   195
         Index           =   3
         Left            =   180
         TabIndex        =   47
         Top             =   2220
         Width           =   855
      End
      Begin VB.CommandButton Reset2 
         Caption         =   "Reset"
         Height          =   315
         Left            =   180
         TabIndex        =   46
         Top             =   660
         Width           =   1275
      End
      Begin VB.Label Label11 
         Caption         =   "Debounce Time"
         Height          =   195
         Left            =   180
         TabIndex        =   24
         Top             =   1080
         Width           =   1215
      End
   End
   Begin VB.CheckBox Check4 
      Caption         =   "Output Test"
      Height          =   375
      Left            =   120
      Style           =   1  'Graphical
      TabIndex        =   37
      Top             =   4440
      Width           =   1635
   End
   Begin VB.Timer Timer2 
      Enabled         =   0   'False
      Interval        =   100
      Left            =   1560
      Top             =   1860
   End
   Begin VB.CommandButton ClearAllAnalog1 
      Caption         =   "Clear All Analog"
      Height          =   375
      Left            =   120
      TabIndex        =   36
      Top             =   3960
      Width           =   1635
   End
   Begin VB.CommandButton SetAllAnalog1 
      Caption         =   "Set All Analog"
      Height          =   375
      Left            =   120
      TabIndex        =   35
      Top             =   3480
      Width           =   1635
   End
   Begin VB.Frame Frame8 
      Caption         =   "Counter1"
      Height          =   2595
      Left            =   5400
      TabIndex        =   34
      Top             =   2280
      Width           =   1635
      Begin VB.CommandButton Reset1 
         Caption         =   "Reset"
         Height          =   315
         Left            =   180
         TabIndex        =   43
         Top             =   660
         Width           =   1215
      End
      Begin VB.OptionButton Option1 
         Caption         =   "1000ms"
         Height          =   195
         Index           =   3
         Left            =   180
         TabIndex        =   42
         Top             =   2220
         Width           =   855
      End
      Begin VB.OptionButton Option1 
         Caption         =   "10ms"
         Height          =   195
         Index           =   2
         Left            =   180
         TabIndex        =   41
         Top             =   1920
         Width           =   795
      End
      Begin VB.OptionButton Option1 
         Caption         =   "2ms"
         Height          =   195
         Index           =   1
         Left            =   180
         TabIndex        =   40
         Top             =   1620
         Value           =   -1  'True
         Width           =   675
      End
      Begin VB.OptionButton Option1 
         Caption         =   "0ms"
         Height          =   195
         Index           =   0
         Left            =   180
         TabIndex        =   39
         Top             =   1320
         Width           =   675
      End
      Begin VB.TextBox Text1 
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   8.25
            Charset         =   0
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   285
         Left            =   180
         TabIndex        =   38
         Text            =   "0"
         Top             =   300
         Width           =   1275
      End
      Begin VB.Label Label10 
         Caption         =   "Debounce Time"
         Height          =   195
         Left            =   180
         TabIndex        =   44
         Top             =   1080
         Width           =   1215
      End
   End
   Begin VB.Frame Frame7 
      Caption         =   "Outputs"
      Height          =   735
      Left            =   5400
      TabIndex        =   25
      Top             =   960
      Width           =   3555
      Begin VB.CheckBox Check3 
         Caption         =   "8"
         Height          =   255
         Index           =   7
         Left            =   3060
         TabIndex        =   33
         Top             =   300
         Width           =   375
      End
      Begin VB.CheckBox Check3 
         Caption         =   "7"
         Height          =   255
         Index           =   6
         Left            =   2640
         TabIndex        =   32
         Top             =   300
         Width           =   375
      End
      Begin VB.CheckBox Check3 
         Caption         =   "6"
         Height          =   255
         Index           =   5
         Left            =   2220
         TabIndex        =   31
         Top             =   300
         Width           =   375
      End
      Begin VB.CheckBox Check3 
         Caption         =   "5"
         Height          =   255
         Index           =   4
         Left            =   1800
         TabIndex        =   30
         Top             =   300
         Width           =   375
      End
      Begin VB.CheckBox Check3 
         Caption         =   "4"
         Height          =   255
         Index           =   3
         Left            =   1380
         TabIndex        =   29
         Top             =   300
         Width           =   375
      End
      Begin VB.CheckBox Check3 
         Caption         =   "3"
         Height          =   255
         Index           =   2
         Left            =   960
         TabIndex        =   28
         Top             =   300
         Width           =   375
      End
      Begin VB.CheckBox Check3 
         Caption         =   "2"
         Height          =   255
         Index           =   1
         Left            =   540
         TabIndex        =   27
         Top             =   300
         Width           =   375
      End
      Begin VB.CheckBox Check3 
         Caption         =   "1"
         Height          =   255
         Index           =   0
         Left            =   120
         TabIndex        =   26
         Top             =   300
         Width           =   375
      End
   End
   Begin VB.Timer Timer1 
      Enabled         =   0   'False
      Interval        =   50
      Left            =   1020
      Top             =   1860
   End
   Begin VB.Frame Frame6 
      Caption         =   "Inputs"
      Height          =   735
      Left            =   5400
      TabIndex        =   15
      Top             =   60
      Width           =   2355
      Begin VB.CheckBox Check2 
         Caption         =   "5"
         Height          =   255
         Index           =   4
         Left            =   1860
         TabIndex        =   20
         Top             =   300
         Width           =   435
      End
      Begin VB.CheckBox Check2 
         Caption         =   "4"
         Height          =   255
         Index           =   3
         Left            =   1380
         TabIndex        =   19
         Top             =   300
         Width           =   495
      End
      Begin VB.CheckBox Check2 
         Caption         =   "3"
         Height          =   255
         Index           =   2
         Left            =   960
         TabIndex        =   18
         Top             =   300
         Width           =   495
      End
      Begin VB.CheckBox Check2 
         Caption         =   "2"
         Height          =   255
         Index           =   1
         Left            =   540
         TabIndex        =   17
         Top             =   300
         Width           =   495
      End
      Begin VB.CheckBox Check2 
         Caption         =   "1"
         Height          =   255
         Index           =   0
         Left            =   120
         TabIndex        =   16
         Top             =   300
         Width           =   495
      End
   End
   Begin VB.CommandButton ClearAllDig 
      Caption         =   "Clear All Digital"
      Height          =   375
      Left            =   120
      TabIndex        =   14
      Top             =   3000
      Width           =   1635
   End
   Begin VB.CommandButton SetAllDig 
      Caption         =   "Set All Digital"
      Height          =   375
      Left            =   120
      TabIndex        =   13
      Top             =   2520
      Width           =   1635
   End
   Begin VB.Frame Frame5 
      Caption         =   "AD2"
      Height          =   4815
      Left            =   4440
      TabIndex        =   11
      Top             =   60
      Width           =   615
      Begin VB.VScrollBar VScroll4 
         Height          =   4155
         Left            =   180
         Max             =   0
         Min             =   255
         TabIndex        =   52
         Top             =   300
         Width           =   255
      End
      Begin VB.Label Label9 
         Caption         =   "00"
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   8.25
            Charset         =   0
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   195
         Left            =   180
         TabIndex        =   12
         Top             =   4560
         Width           =   315
      End
   End
   Begin VB.Frame Frame4 
      Caption         =   "AD1"
      Height          =   4815
      Left            =   3720
      TabIndex        =   9
      Top             =   60
      Width           =   615
      Begin VB.VScrollBar VScroll3 
         Height          =   4155
         Left            =   180
         Max             =   0
         Min             =   255
         TabIndex        =   51
         Top             =   300
         Width           =   255
      End
      Begin VB.Label Label7 
         Caption         =   "00"
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   8.25
            Charset         =   0
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   195
         Left            =   180
         TabIndex        =   10
         Top             =   4560
         Width           =   375
      End
   End
   Begin VB.Frame Frame3 
      Caption         =   "DA2"
      Height          =   4815
      Left            =   2880
      TabIndex        =   7
      Top             =   60
      Width           =   615
      Begin VB.VScrollBar VScroll2 
         Height          =   4155
         Left            =   180
         Max             =   0
         Min             =   255
         TabIndex        =   50
         Top             =   300
         Width           =   255
      End
      Begin VB.Label Label4 
         Caption         =   "00"
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   8.25
            Charset         =   0
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   195
         Left            =   180
         TabIndex        =   8
         Top             =   4560
         Width           =   375
      End
   End
   Begin VB.Frame Frame2 
      Caption         =   "DA1"
      Height          =   4815
      Left            =   2100
      TabIndex        =   5
      Top             =   60
      Width           =   615
      Begin VB.VScrollBar VScroll1 
         Height          =   4155
         Left            =   180
         Max             =   0
         Min             =   255
         TabIndex        =   49
         Top             =   300
         Width           =   255
      End
      Begin VB.Label Label3 
         Caption         =   "00"
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   8.25
            Charset         =   0
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   195
         Left            =   180
         TabIndex        =   6
         Top             =   4560
         Width           =   375
      End
   End
   Begin VB.CommandButton Connect 
      Caption         =   "Connect"
      Height          =   375
      Left            =   120
      TabIndex        =   3
      Top             =   960
      Width           =   1635
   End
   Begin VB.Frame Frame1 
      Caption         =   "Card Address"
      Height          =   735
      Left            =   120
      TabIndex        =   0
      Top             =   60
      Width           =   1635
      Begin VB.CheckBox Check1 
         Caption         =   "SK6"
         Height          =   255
         Index           =   1
         Left            =   900
         TabIndex        =   2
         Top             =   300
         Value           =   1  'Checked
         Width           =   615
      End
      Begin VB.CheckBox Check1 
         Caption         =   "SK5"
         Height          =   255
         Index           =   0
         Left            =   180
         TabIndex        =   1
         Top             =   300
         Value           =   1  'Checked
         Width           =   615
      End
   End
   Begin VB.Label Label1 
      Caption         =   "- - -"
      Height          =   195
      Left            =   180
      TabIndex        =   4
      Top             =   1440
      Width           =   1755
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit
Dim n As Integer
Private Declare Sub ReadAll Lib "k8055d.dll" (data As Long)
Private Declare Function Version Lib "k8055d.dll" () As Long
Private Declare Function SearchDevices Lib "k8055d.dll" () As Long
Private Declare Function SetCurrentDevice Lib "k8055d.dll" (ByVal CardAddress As Long) As Long
Private Declare Function OpenDevice Lib "k8055d.dll" (ByVal CardAddress As Long) As Long
Private Declare Sub CloseDevice Lib "k8055d.dll" ()
Private Declare Function ReadAnalogChannel Lib "k8055d.dll" (ByVal Channel As Long) As Long
Private Declare Sub ReadAllAnalog Lib "k8055d.dll" (Data1 As Long, Data2 As Long)
Private Declare Sub OutputAnalogChannel Lib "k8055d.dll" (ByVal Channel As Long, ByVal data As Long)
Private Declare Sub OutputAllAnalog Lib "k8055d.dll" (ByVal Data1 As Long, ByVal Data2 As Long)
Private Declare Sub ClearAnalogChannel Lib "k8055d.dll" (ByVal Channel As Long)
Private Declare Sub SetAllAnalog Lib "k8055d.dll" ()
Private Declare Sub ClearAllAnalog Lib "k8055d.dll" ()
Private Declare Sub SetAnalogChannel Lib "k8055d.dll" (ByVal Channel As Long)
Private Declare Sub WriteAllDigital Lib "k8055d.dll" (ByVal data As Long)
Private Declare Sub ClearDigitalChannel Lib "k8055d.dll" (ByVal Channel As Long)
Private Declare Sub ClearAllDigital Lib "k8055d.dll" ()
Private Declare Sub SetDigitalChannel Lib "k8055d.dll" (ByVal Channel As Long)
Private Declare Sub SetAllDigital Lib "k8055d.dll" ()
Private Declare Function ReadDigitalChannel Lib "k8055d.dll" (ByVal Channel As Long) As Boolean
Private Declare Function ReadAllDigital Lib "k8055d.dll" () As Long
Private Declare Function ReadCounter Lib "k8055d.dll" (ByVal CounterNr As Long) As Long
Private Declare Sub ResetCounter Lib "k8055d.dll" (ByVal CounterNr As Long)
Private Declare Sub SetCounterDebounceTime Lib "k8055d.dll" (ByVal CounterNr As Long, ByVal DebounceTime As Long)

Private Sub Connect_Click()
    Dim CardAddress As Long
    Dim h As Long
    CardAddress = 3 - (Check1(0).Value + Check1(1).Value * 2)
    h = OpenDevice(CardAddress)
    Select Case h
        Case 0, 1, 2, 3
            Label1.Caption = "Card " + Str(h) + " connected"
        Case -1
            Label1.Caption = "Card " + Str(CardAddress) + " not found"
    End Select
    If h >= 0 Then Timer1.Enabled = True
End Sub
Private Sub Form_Terminate()
    CloseDevice
End Sub
Private Sub Timer1_Timer()
    Timer1.Enabled = False
    Dim Data1 As Long
    Dim Data2 As Long
    Dim i As Long
    i = ReadAllDigital
    Check2(0).Value = (i And 1)
    Check2(1).Value = (i And 2) \ 2
    Check2(2).Value = (i And 4) \ 4
    Check2(3).Value = (i And 8) \ 8
    Check2(4).Value = (i And 16) \ 16
    ReadAllAnalog Data1, Data2
    VScroll3.Value = Data1
    VScroll4.Value = Data2
    Label7.Caption = Data1
    Label9.Caption = Data2
    Text1.Text = ReadCounter(1)
    Text2.Text = ReadCounter(2)
    Timer1.Enabled = True
End Sub

Private Sub Timer2_Timer()
    ClearDigitalChannel n + 1
    Check3(n).Value = 0
    n = n + 1
    If n = 8 Then n = 0
    SetDigitalChannel n + 1
    Check3(n).Value = 1
End Sub

Private Sub SetAllDig_Click()
    SetAllDigital
    Dim i As Long
    For i = 0 To 7
        Check3(i).Value = 1
    Next
End Sub

Private Sub ClearAllDig_Click()
    Dim i As Long
    ClearAllDigital
    For i = 0 To 7
        Check3(i).Value = 0
    Next
End Sub

Private Sub SetAllAnalog1_Click()
    SetAllAnalog
    VScroll1.Value = 255
    VScroll2.Value = 255
    Label3.Caption = 255
    Label4.Caption = 255
End Sub

Private Sub ClearAllAnalog1_Click()
    ClearAllAnalog
    VScroll1.Value = 0
    VScroll2.Value = 0
    Label3.Caption = 0
    Label4.Caption = 0
End Sub

Private Sub Check4_Click()
    If Check4.Value = 1 Then Timer2.Enabled = True Else Timer2.Enabled = False
End Sub

Private Sub VScroll1_Scroll()
    Label3.Caption = VScroll1.Value
    OutputAnalogChannel 1, VScroll1.Value
End Sub

Private Sub VScroll2_Scroll()
    Label4.Caption = VScroll2.Value
    OutputAnalogChannel 2, VScroll2.Value
End Sub

Private Sub Reset1_Click()
    ResetCounter 1
End Sub

Private Sub Reset2_Click()
    ResetCounter 2
End Sub

Private Sub Option1_Click(Index As Integer)
Dim t1 As Long
    Select Case Index
    Case 0
        t1 = 0
    Case 1
        t1 = 2
    Case 2
        t1 = 10
    Case 3
        t1 = 1000
    End Select
    SetCounterDebounceTime 1, t1
End Sub

Private Sub Option2_Click(Index As Integer)
Dim t2 As Long
    Select Case Index
    Case 0
        t2 = 0
    Case 1
        t2 = 2
    Case 2
        t2 = 10
    Case 3
        t2 = 1000
    End Select
    SetCounterDebounceTime 2, t2
End Sub

Private Sub Check3_Click(Index As Integer)
    Dim i As Long
    Dim n As Long
    If Check3(Index).Value = 1 Then
        SetDigitalChannel Index + 1
    Else
        ClearDigitalChannel Index + 1
    End If
    
End Sub

Private Sub Command1_Click()
    Dim i As Long
    Dim Checked As Boolean
    Dim Devices As Long
    Checked = False
    Timer1.Enabled = False
    Devices = SearchDevices
    If Devices Then
        Timer1.Enabled = True
        For i = 0 To 3
            If (Devices And 2 ^ i) Then
                Option3(i).Enabled = True
                If Not Checked Then
                    Option3(i).Value = True
                    SetCurrentDevice i
                    Checked = True
                End If
            Else
                Option3(i).Value = False
                Option3(i).Enabled = False
            End If
        Next i
    End If
End Sub

Private Sub Option3_Click(Index As Integer)
    SetCurrentDevice Index
End Sub

Private Sub Command2_Click()
    Dim ver As Long
        ver = Version()
        Label5.Caption = CStr(ver \ 2 ^ 24) + "." + CStr(&HFF And (ver \ 2 ^ 16)) _
            + "." + CStr(&HFF And (ver \ 2 ^ 8)) + "." + CStr(&HFF And ver)
End Sub






