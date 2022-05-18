Public Class Form1
    Dim n As Integer
    Private Declare Function OpenDevice Lib "k8055d.dll" (ByVal CardAddress As Integer) As Integer
    Private Declare Sub CloseDevice Lib "k8055d.dll" ()
    Private Declare Function Version Lib "k8055d.dll" () As Integer
    Private Declare Function SearchDevices Lib "k8055d.dll" () As Integer
    Private Declare Function SetCurrentDevice Lib "k8055d.dll" (ByVal CardAddress As Integer) As Integer
    Private Declare Function ReadAnalogChannel Lib "k8055d.dll" (ByVal Channel As Integer) As Integer
    Private Declare Sub ReadAllAnalog Lib "k8055d.dll" (ByRef Data1 As Integer, ByRef Data2 As Integer)
    Private Declare Sub OutputAnalogChannel Lib "k8055d.dll" (ByVal Channel As Integer, ByVal Data As Integer)
    Private Declare Sub OutputAllAnalog Lib "k8055d.dll" (ByVal Data1 As Integer, ByVal Data2 As Integer)
    Private Declare Sub ClearAnalogChannel Lib "k8055d.dll" (ByVal Channel As Integer)
    Private Declare Sub SetAllAnalog Lib "k8055d.dll" ()
    Private Declare Sub ClearAllAnalog Lib "k8055d.dll" ()
    Private Declare Sub SetAnalogChannel Lib "k8055d.dll" (ByVal Channel As Integer)
    Private Declare Sub WriteAllDigital Lib "k8055d.dll" (ByVal Data As Integer)
    Private Declare Sub ClearDigitalChannel Lib "k8055d.dll" (ByVal Channel As Integer)
    Private Declare Sub ClearAllDigital Lib "k8055d.dll" ()
    Private Declare Sub SetDigitalChannel Lib "k8055d.dll" (ByVal Channel As Integer)
    Private Declare Sub SetAllDigital Lib "k8055d.dll" ()
    Private Declare Function ReadDigitalChannel Lib "k8055d.dll" (ByVal Channel As Integer) As Boolean
    Private Declare Function ReadAllDigital Lib "k8055d.dll" () As Integer
    Private Declare Function ReadCounter Lib "k8055d.dll" (ByVal CounterNr As Integer) As Integer
    Private Declare Sub ResetCounter Lib "k8055d.dll" (ByVal CounterNr As Integer)
    Private Declare Sub SetCounterDebounceTime Lib "k8055d.dll" (ByVal CounterNr As Integer, ByVal DebounceTime As Integer)


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim CardAddress As Integer
        Dim h As Integer
        CardAddress = 3
        If CheckBox1.Checked Then CardAddress = CardAddress - 1
        If CheckBox2.Checked Then CardAddress = CardAddress - 2
        h = OpenDevice(CardAddress)
        Select Case h
            Case 0, 1, 2, 3
                Label1.Text = "Card " + Str(h) + " connected"
            Case -1
                Label1.Text = "Card " + Str(CardAddress) + " not found"
        End Select
        If h >= 0 Then Timer1.Enabled = True
    End Sub

    Private Sub Form1_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        CloseDevice()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Dim i As Integer
        Dim Data1 As Integer
        Dim Data2 As Integer
        Timer1.Enabled = False
        i = ReadAllDigital
        CheckBox4.Checked = i And 1
        CheckBox5.Checked = (i >> 1) And 1
        CheckBox6.Checked = (i >> 2) And 1
        CheckBox7.Checked = (i >> 3) And 1
        CheckBox8.Checked = (i >> 4) And 1
        ReadAllAnalog(Data1, Data2)
        VScrollBar3.Value = 255 - Data1
        VScrollBar4.Value = 255 - Data2
        Label6.Text = CStr(Data1)
        Label7.Text = CStr(Data2)
        TextBox1.Text = CStr(ReadCounter(1))
        TextBox2.Text = CStr(ReadCounter(2))
        Timer1.Enabled = True
    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        ClearDigitalChannel(n)
        n = n + 1
        If n = 9 Then n = 1
        SetDigitalChannel(n)
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        SetAllDigital()
        CheckBox9.Checked = True
        CheckBox10.Checked = True
        CheckBox11.Checked = True
        CheckBox12.Checked = True
        CheckBox13.Checked = True
        CheckBox14.Checked = True
        CheckBox15.Checked = True
        CheckBox16.Checked = True
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        ClearAllDigital()
        CheckBox9.Checked = False
        CheckBox10.Checked = False
        CheckBox11.Checked = False
        CheckBox12.Checked = False
        CheckBox13.Checked = False
        CheckBox14.Checked = False
        CheckBox15.Checked = False
        CheckBox16.Checked = False
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        SetAllAnalog()
        VScrollBar1.Value = 0
        VScrollBar2.Value = 0
        Label4.Text = "255"
        Label5.Text = "255"
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        ClearAllAnalog()
        VScrollBar1.Value = 255
        VScrollBar2.Value = 255
        Label4.Text = "0"
        Label5.Text = "0"
    End Sub

    Private Sub CheckBox3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox3.CheckedChanged
        If CheckBox3.Checked Then
            Timer2.Enabled = True
        Else
            Timer2.Enabled = False
            ClearAllDigital()
            CheckBox9.Checked = False
            CheckBox10.Checked = False
            CheckBox11.Checked = False
            CheckBox12.Checked = False
            CheckBox13.Checked = False
            CheckBox14.Checked = False
            CheckBox15.Checked = False
            CheckBox16.Checked = False
        End If

    End Sub

    Private Sub VScrollBar1_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles VScrollBar1.Scroll
        Label4.Text = CStr(255 - VScrollBar1.Value)
        OutputAnalogChannel(1, 255 - VScrollBar1.Value)
    End Sub

    Private Sub VScrollBar2_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles VScrollBar2.Scroll
        Label5.Text = CStr(255 - VScrollBar2.Value)
        OutputAnalogChannel(2, 255 - VScrollBar2.Value)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        ResetCounter(1)
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        ResetCounter(2)
    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        SetCounterDebounceTime(1, 0)
    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        SetCounterDebounceTime(1, 2)
    End Sub

    Private Sub RadioButton3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton3.CheckedChanged
        SetCounterDebounceTime(1, 10)
    End Sub

    Private Sub RadioButton4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton4.CheckedChanged
        SetCounterDebounceTime(1, 1000)
    End Sub

    Private Sub RadioButton5_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton5.CheckedChanged
        SetCounterDebounceTime(2, 0)
    End Sub

    Private Sub RadioButton6_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton6.CheckedChanged
        SetCounterDebounceTime(2, 2)
    End Sub

    Private Sub RadioButton7_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton7.CheckedChanged
        SetCounterDebounceTime(2, 10)
    End Sub

    Private Sub RadioButton8_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton8.CheckedChanged
        SetCounterDebounceTime(2, 1000)
    End Sub

    Private Sub CheckBox9_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox9.CheckedChanged
        If CheckBox9.Checked Then SetDigitalChannel(1) Else ClearDigitalChannel(1)
    End Sub

    Private Sub CheckBox10_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox10.CheckedChanged
        If CheckBox10.Checked Then SetDigitalChannel(2) Else ClearDigitalChannel(2)
    End Sub

    Private Sub CheckBox11_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox11.CheckedChanged
        If CheckBox11.Checked Then SetDigitalChannel(3) Else ClearDigitalChannel(3)
    End Sub

    Private Sub CheckBox12_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox12.CheckedChanged
        If CheckBox12.Checked Then SetDigitalChannel(4) Else ClearDigitalChannel(4)
    End Sub

    Private Sub CheckBox13_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox13.CheckedChanged
        If CheckBox13.Checked Then SetDigitalChannel(5) Else ClearDigitalChannel(5)
    End Sub

    Private Sub CheckBox14_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox14.CheckedChanged
        If CheckBox14.Checked Then SetDigitalChannel(6) Else ClearDigitalChannel(6)
    End Sub

    Private Sub CheckBox15_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox15.CheckedChanged
        If CheckBox15.Checked Then SetDigitalChannel(7) Else ClearDigitalChannel(7)
    End Sub

    Private Sub CheckBox16_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox16.CheckedChanged
        If CheckBox16.Checked Then SetDigitalChannel(8) Else ClearDigitalChannel(8)
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Dim k As Integer
        Dim CardFound As Boolean
        CardFound = False
        Timer1.Enabled = False
        RadioButton9.Enabled = False
        RadioButton9.Checked = False
        RadioButton10.Enabled = False
        RadioButton10.Checked = False
        RadioButton11.Enabled = False
        RadioButton11.Checked = False
        RadioButton12.Enabled = False
        RadioButton12.Checked = False
        k = SearchDevices()
        If k Then Timer1.Enabled = True
        If (k And 1) Then
            CardFound = True
            RadioButton9.Enabled = True
            RadioButton9.Checked = True
            SetCurrentDevice(0)
        End If
        If (k And 2) Then
            RadioButton10.Enabled = True
            If Not CardFound Then
                CardFound = True
                RadioButton10.Checked = True
                SetCurrentDevice(1)
            End If
        End If
        If (k And 4) Then
            RadioButton11.Enabled = True
            If Not CardFound Then
                CardFound = True
                RadioButton11.Checked = True
                SetCurrentDevice(2)
            End If
        End If
        If (k And 8) Then
            RadioButton12.Enabled = True
            If Not CardFound Then
                RadioButton12.Checked = True
                SetCurrentDevice(3)
            End If
        End If
    End Sub

    Private Sub RadioButton9_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton9.CheckedChanged
        SetCurrentDevice(0)
    End Sub

    Private Sub RadioButton10_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton10.CheckedChanged
        SetCurrentDevice(1)
    End Sub

    Private Sub RadioButton11_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton11.CheckedChanged
        SetCurrentDevice(2)
    End Sub

    Private Sub RadioButton12_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton12.CheckedChanged
        SetCurrentDevice(3)
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Dim ver As Integer
        ver = Version()
        Label9.Text = CStr(ver >> 24) + "." + CStr(&HFF And (ver >> 16)) _
            + "." + CStr(&HFF And (ver >> 8)) + "." + CStr(&HFF And ver)
    End Sub
End Class
