Imports System.Windows.Forms
Imports System.IO
Imports IWshRuntimeLibrary


Public Class Main
    'Variable Declaration'
    Dim Hires As Boolean
    Dim DeskIcon As Boolean = True
    Dim BttnState As Integer = 0
    Dim InstallPath As String = "C:\Program Files\D2X-XL\"
    Dim D2XLocation(2) As String
    Dim InstD1 As Boolean = False
    Dim InstVertigo As Boolean = False
    Dim HQSFX As Boolean = False
    Dim InstDLOTW As Boolean = False
    Dim DownloadUp As Boolean = False
    Dim UseD1Inst As Boolean = False
    Dim UseD2Inst As Boolean = False
    Dim SaveInst As Boolean = True
    Dim D1UpToDate As Boolean = False
    Dim D2UpToDate As Boolean = False
    Dim D2XUpToDate As Boolean = False
    Dim HQSFXUpToDate As Boolean = False
    Dim HiResTexUptoDate As Boolean = False
    Dim Install As New Install
    Dim TempString As String
    Dim Divisor As Integer = 1
    Dim MsgBoxBtn As Integer
    Dim ProcessD As New Process
    Private Sub BTTN_NEXT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTTN_Next.Click
        'This procedure finds out where the user is in the install, and determines what to do next, when'
        'the next button is pressed'
        'Button State 0 is the intial install screen, so if BttnState = 0 is pressed, then the installer needs to'
        'Load up the "Install Options" check boxes and text"'
        If BttnState = 0 Then
            If My.Computer.FileSystem.FileExists(D2XLocation(1)) Then
                'Determine if the user wanted to install hi resolution textures'
                If RBTN_01.Checked = True Then
                    Hires = True
                Else
                    Hires = False
                End If
                'Setting install state 1'
                BttnState = 1
                BTTN_Previous.Enabled = True
                RBTN_01.Visible = False
                RBTN_02.Visible = False
                CHKB_01.Visible = True
                CHKB_02.Visible = True
                CHKB_03.Visible = True
                CHKB_04.Visible = True
                CHKB_05.Visible = True
                CHKB_06.Visible = True
                CHKB_07.Visible = True
                CHKB_08.Visible = True
                CHKB_09.Visible = True
                LABL_InstallPath.Text = "Install Path"
                TXTB_InstallPath.Text = InstallPath
                RTXT_Common.Text = "Please select the install options that you wish to use."
                GRPB_Common.Text = "Install Options"
            End If
        ElseIf BttnState = 1 Then
            'verify that the D2x-xl.exe file is in the archive selected.
            If My.Computer.FileSystem.DirectoryExists(My.Computer.FileSystem.SpecialDirectories.ProgramFiles & " (x86)") Then
                ProcessD.StartInfo.FileName = "7z64.exe"
            Else
                ProcessD.StartInfo.FileName = "7z.exe"
            End If
            ProcessD.StartInfo.Arguments = " x " & Chr(34) & D2XLocation(1) & Chr(34) & " -y -o" & Chr(34) & InstallPath & Chr(34) & " d2x-xl.exe"
            ProcessD.Start()
            While Not ProcessD.HasExited
            End While
            If My.Computer.FileSystem.FileExists(InstallPath & "D2x-xl.exe") Then
                'BttnState -1 is the cancel state indicating that if the user presses cancel before state is set
                'back to a positive state then the program will go through the cancel procedure
                BttnState = -1
                GRPB_Common.Visible = False
                BTTN_Previous.Enabled = False
                BTTN_Next.Text = "Cancel"
                TXTB_InstallPath.Enabled = False
                BTTN_Browse.Visible = False
                ProgressBar.Visible = True
                'Sets how the progress bar will increment
                ProgressBar.Step = (100 \ Divisor)
                'gets all the install paths from the user and installs the files
                GetPaths()
                If DeskIcon = True Then
                    Dim WshShell As WshShellClass = New WshShellClass
                    Dim D2XShortcut As IWshRuntimeLibrary.IWshShortcut
                    D2XShortcut = CType(WshShell.CreateShortcut(My.Computer.FileSystem.SpecialDirectories.Desktop & "\D2X-XL.lnk"), IWshRuntimeLibrary.IWshShortcut)
                    D2XShortcut.TargetPath = InstallPath & "\d2x-xl.exe"
                    D2XShortcut.IconLocation = D2XShortcut.TargetPath
                    D2XShortcut.Save()
                End If
                BttnState = 2
                ProgressBar.PerformStep()
                MsgBox("Installation of Descent 2 X-XL is complete.", MsgBoxStyle.OkOnly, "Installation Complete")
                BTTN_Next.Text = "Finish"
            Else
                MsgBox("Can not find D2X-Files in archive!" & vbCrLf & "Please select a different archive.")
                BTTN_Previous_Click(Me, e)
            End If
        ElseIf BttnState = -1 Or BttnState = 2 Then
            End
        End If
    End Sub
    Private Sub HQSFXPath()
        TempString = My.Computer.FileSystem.CurrentDirectory
        MsgBox("Please select the archive file which contains the High Quality SFX")
        Dim HQSFXLocation As String
        Open_01.Reset()
        Open_01.ShowDialog()
        If Open_01.FileName <> "" Then
            HQSFXLocation = Open_01.FileName
            My.Computer.FileSystem.CurrentDirectory = TempString
            If My.Computer.FileSystem.FileExists(HQSFXLocation) Then
                ProcessD.StartInfo.Arguments = " x -y -o" & Chr(34) & InstallPath & Chr(34) & " " & Chr(34) & HQSFXLocation & Chr(34) & " sounds1\vulcan.wav"
                ProcessD.Start()
                While Not ProcessD.HasExited
                End While
            End If
            While Not My.Computer.FileSystem.FileExists(InstallPath & "sounds1\vulcan.wav")
                MsgBox("That archive did not contain the High Quality SFX. Please Select again.")
                Open_01.Reset()
                Open_01.ShowDialog()
                If Open_01.FileName <> "" Then
                    CancelInstall(0)
                End If
                HQSFXLocation = Open_01.FileName
                My.Computer.FileSystem.CurrentDirectory = TempString
                If My.Computer.FileSystem.FileExists(HQSFXLocation) Then
                    ProcessD.StartInfo.Arguments = " x -y -o" & Chr(34) & InstallPath & Chr(34) & " " & Chr(34) & HQSFXLocation & Chr(34) & " sounds1\vulcan.wav"
                    ProcessD.Start()
                    While Not ProcessD.HasExited
                    End While
                End If
            End While
            Install.HQSFX(HQSFXLocation, InstallPath, ProgressBar, ProcessD)
        Else
            CancelInstall(0)
        End If
    End Sub
    Private Sub FileCheck(ByVal textbox As String, ByVal file As String, ByVal number As Integer)
        Do While Not (My.Computer.FileSystem.FileExists(FLDR_01.SelectedPath & file))
            MessageBox.Show(textbox)
            FLDR_01.Reset()
            FLDR_01.ShowDialog()
            If FLDR_01.SelectedPath = "" Then
                CancelInstall(number)
            End If
        Loop
    End Sub
    Private Sub D2Path()
        If UseD2Inst = True Then
            MessageBox.Show("Please specify the folder where Descent II is installed.")
        Else
            MessageBox.Show("Please specify the drive which holds your Descent II CD.")
        End If
        FLDR_01.Reset()
        FLDR_01.ShowDialog()
        If FLDR_01.SelectedPath <> "" Then
            If UseD2Inst = True Then
                FileCheck(("The folder did not contain the Descent II files, please select another."), ("\DESCENT2.HOG"), 1)
            Else
                FileCheck(("That drive does not contain the Descent II files. Please make sure the CD is in the drive and try again."), ("\D2DATA\DESCENT2.SOW"), 1)
            End If
        Else
            CancelInstall(0)
        End If
        'Install Descent II & D2X Portion
        FLDR_01.SelectedPath = FLDR_01.SelectedPath & "\"
        Install.D2X(FLDR_01.SelectedPath, InstallPath, D2XLocation, UseD2Inst, Hires, ProgressBar, ProcessD)
        'If using an old Descent II install, and not saving the old install, then Delete the old install.
        If SaveInst = False And UseD2Inst = True Then
            My.Computer.FileSystem.DeleteDirectory(FLDR_01.SelectedPath, FileIO.DeleteDirectoryOption.DeleteAllContents)
        End If
    End Sub
    Private Sub D2VPath()
        'if d2x.hog exists in the installed descent 2 folder, then there is no need to ask for the vertigo path
        If UseD2Inst = True And My.Computer.FileSystem.FileExists(FLDR_01.SelectedPath & "\missions\d2x.hog") And My.Computer.FileSystem.FileExists(FLDR_01.SelectedPath & "\missions\d2x.mn2") And My.Computer.FileSystem.FileExists(FLDR_01.SelectedPath & "\hoard.ham") Then
        Else
            MessageBox.Show("Please specify the drive which holds your Descent II: Vertigo CD.")
            FLDR_01.Reset()
            FLDR_01.ShowDialog()
            If FLDR_01.SelectedPath <> "" Then
                FileCheck(("That drive does not contain the Descent 2: Vertigo files, please make sure the CD is in the drive and choose again."), ("\vertigo\d2x.hog"), 2)

            Else
                CancelInstall(2)
            End If
            Install.D2V(FLDR_01.SelectedPath, (InstallPath), ProgressBar)
        End If
    End Sub
    Private Sub D1Path()
        If UseD1Inst = True Then
            MessageBox.Show("Please specify the folder where Descent I is installed.")
        Else
            MessageBox.Show("Please specify the drive which holds your Descent I CD.")
        End If
        FLDR_01.Reset()
        FLDR_01.ShowDialog()
        If FLDR_01.SelectedPath <> "" Then
            If UseD1Inst = True Then
                FileCheck("That folder does not contain the Descent files, please choose again.", "\DESCENT.hog", 3)
            Else
                FileCheck("That drive does not contain the Descent files, please choose again.", "\descent\DESCENT.hog", 3)
            End If
        Else
            CancelInstall(3)
        End If
        Install.D1(FLDR_01.SelectedPath, InstallPath, UseD1Inst, ProgressBar)
        If SaveInst = False And UseD1Inst = True Then
            My.Computer.FileSystem.DeleteDirectory(FLDR_01.SelectedPath, FileIO.DeleteDirectoryOption.DeleteAllContents)
        End If
        'Gets the path for the Descent levels of the world files if the user has chosen that option'
        If InstDLOTW = True Then
            If Not My.Computer.FileSystem.FileExists(FLDR_01.SelectedPath & "dlotw\dlow.exe") Then
                'It is assumed that if the user wishes to install DLOTW, that he does not have it in an existing path
                MessageBox.Show("Please specify the drive which holds your Descent Levels of the World CD")
                FLDR_01.Reset()
                FLDR_01.ShowDialog()
                If FLDR_01.SelectedPath <> "" Then
                    FileCheck("That drive does not contain the Levels of the World files, please choose again.", "dlotw\dlow.exe", 4)
                Else
                    CancelInstall(4)
                End If
            End If
                Install.DLOTW(FLDR_01.SelectedPath & "DLOTW\", InstallPath, ProgressBar)
        End If
    End Sub
    Private Sub GetPaths()
        'Get path for High Quality SFX archive.
        If HQSFX = True Then
            HQSFXPath()
        End If
        'Gets path for the Descent II files from the user.
        D2Path()
        'Gets the path for the Descent II Vertigo files if the user has chosen that option'
        If InstVertigo = True Then
            D2VPath()
        End If
        'Gets the path for the Descent I files if the user has chosen that option'
        If InstD1 = True Then
            D1Path()
        End If
    End Sub
    Private Sub BTTN_Previous_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTTN_Previous.Click
        'This procedure works in the reverse of BTTN_Next
        If BttnState = 1 Then
            'Return to install state 0'
            If Hires = True Then
                RBTN_01.Checked = True
            Else
                RBTN_02.Checked = True
            End If
            'Setting install state 1'
            BttnState = 0
            BTTN_Previous.Enabled = False
            RBTN_01.Visible = True
            RBTN_02.Visible = True
            CHKB_01.Visible = False
            CHKB_02.Visible = False
            CHKB_03.Visible = False
            CHKB_04.Visible = False
            CHKB_05.Visible = False
            CHKB_06.Visible = False
            CHKB_07.Visible = False
            CHKB_08.Visible = False
            CHKB_09.Visible = False
            LABL_InstallPath.Text = "Location of D2X-XL RAR file."
            RTXT_Common.Text = "Welcome to the Descent II - X XL Installer." + vbCrLf + "Plese select you install type."
            GRPB_Common.Text = "Install Type"
            InstallPath = "C:\Program Files\D2X-XL\"
            TXTB_InstallPath.Text = D2XLocation(1)
        ElseIf BttnState = 2 Then
        End If
    End Sub
    Private Sub CHKB_01_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKB_01.CheckedChanged
        If BttnState = 1 Then
            If CHKB_01.Checked = True Then
                InstD1 = True
                Divisor = Divisor + 1
            Else
                InstD1 = False
                Divisor = Divisor - 1
            End If
            If CHKB_05.Enabled = False Then
                CHKB_05.Enabled = True
            ElseIf CHKB_05.Enabled = True Then
                CHKB_05.Enabled = False
                CHKB_05.Checked = False
            End If
        End If
    End Sub
    Private Sub CHKB_02_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKB_02.CheckedChanged
        If BttnState = 1 Then
            If CHKB_02.Checked = True Then
                InstVertigo = True
                Divisor = Divisor + 1
            Else
                InstVertigo = False
                Divisor = Divisor - 1
            End If
        End If
    End Sub
    Private Sub CHKB_03_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKB_03.CheckedChanged
        If BttnState = 1 Then
            If CHKB_03.Checked = True Then
                HQSFX = True
                Divisor = Divisor + 1
            Else
                HQSFX = False
                Divisor = Divisor - 1
            End If
        End If
    End Sub
    Private Sub CHKB_04_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKB_04.CheckedChanged
        If BttnState = 1 Then
            If CHKB_04.Checked = True Then
                InstDLOTW = True
                Divisor = Divisor + 1
            Else
                InstDLOTW = False
                Divisor = Divisor - 1
            End If
        End If
    End Sub
    Private Sub CHKB_05_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKB_05.CheckedChanged
        If BttnState = 1 Then
            If CHKB_05.Checked = True Then
                CHKB_07.Enabled = True
                UseD1Inst = True
            Else
                UseD1Inst = False
                If CHKB_06.Checked = False Then
                    CHKB_07.Checked = True
                    CHKB_07.Enabled = False
                End If
            End If
        End If
    End Sub
    Private Sub CHKB_06_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKB_06.CheckedChanged
        If BttnState = 1 Then
            If CHKB_06.Checked = True Then
                UseD2Inst = True
                CHKB_07.Enabled = True
            Else
                UseD2Inst = False
                If CHKB_05.Checked = False Then
                    CHKB_07.Checked = True
                    CHKB_07.Enabled = False
                End If
            End If
        End If
    End Sub
    Private Sub CHKB_07_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKB_07.CheckedChanged
        If BttnState = 1 Then
            If CHKB_07.Checked = True Then
                SaveInst = True
            Else
                SaveInst = False
                MsgBoxBtn = MsgBox("Warning, unchecking this box means that your old install files WILL be deleted!" + vbCrLf + "Are you sure?" + vbCrLf + "Note: All files in the 'missions' and 'demos' folders will  be copied to the new install." + vbCrLf + "          Not necessarily all files in the Descent II root directory will be copied", MsgBoxStyle.OkCancel, "Do you really want to delete those files?")
                If MsgBoxBtn = 2 Then
                    CHKB_07.Checked = True
                End If
            End If
        End If
    End Sub
    Private Sub CHKB_08_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKB_08.CheckedChanged
        If BttnState = 1 Then
            If CHKB_08.Checked = True Then
                DownloadUp = True
            Else
                DownloadUp = False
            End If
        End If
    End Sub
    Private Sub CHKB_09_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKB_09.CheckedChanged
        If BttnState = 1 Then
            If CHKB_08.Checked = True Then
                DeskIcon = True
            Else
                DeskIcon = False
            End If
        End If
    End Sub
    Private Sub BTTN_Browse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTTN_Browse.Click
        If BttnState = 0 Then
            TempString = My.Computer.FileSystem.CurrentDirectory
            Open_01.Reset()
            Open_01.Filter = "RAR Archives *.RAR|*.RAR|ZIP Archives *.ZIP|*.ZIP|Auto Extract ZIP Archives *.EXE|*.EXE|ARJ Archives *.ARJ|*.ARJ"
            Open_01.ShowDialog()
            If Open_01.FileName <> "" Then
                D2XLocation(1) = Open_01.FileName
                D2XLocation(2) = Open_01.SafeFileName
                TXTB_InstallPath.Text = D2XLocation(1)
                My.Computer.FileSystem.CurrentDirectory = TempString
            End If
        Else
            FLDR_01.Reset()
            FLDR_01.ShowDialog()
            If FLDR_01.SelectedPath <> "" Then
                InstallPath = FLDR_01.SelectedPath & "\"
                TXTB_InstallPath.Text = InstallPath
            End If
        End If
        Open_01.Reset()
        FLDR_01.Reset()
    End Sub
    Private Sub Main_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LostFocus
        Me.Focus()
    End Sub
    Private Sub CancelInstall(ByVal CancelStep As Integer)
        Select Case CancelStep
            Case 0, 1
                End
            Case 2
                CancelStep = MsgBox("Cancel 'just' the installation of Descent II Virge?", MsgBoxStyle.YesNoCancel)
                If CancelStep = 7 Then
                    CancelInstall(CancelStep)
                ElseIf CancelStep = 8 Then

                Else

                End If
            Case 3
            Case 4
            Case Else
        End Select
    End Sub
End Class
