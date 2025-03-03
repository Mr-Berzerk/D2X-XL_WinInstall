'The install class is used to do the actuall installing of the D2X-Files, and depending on the options
'passed, the procedures called install the different options chosen by the user.
Public Class Install
    Public Sub D1(ByVal sourcepath As String, ByVal InstallPath As String, ByVal UseD1inst As Boolean, ByVal Progressbar As ProgressBar)
        'sourcepath as a string is the location containing the files to be copied
        'InstallPath as a string is the location to copy the files to.
        'UseD1Inst as boolean indicates to the process that it is copying from an old install of Descent
        'Progressbar as Progressbar is for updating the install progressbar as this process executes.
        'Process 'D1' copies all descent 1 files to the D2X folders
        'Prepare the progressbar for this step
        Dim OldStep As Integer = Progressbar.Step
        Progressbar.Step = Progressbar.Step / 13
        'Create a wildcard copy instance 
        Dim WildCard As New WildCard
        'Set copy source if using a old Descent 1 Install
        If UseD1inst = False Then
            sourcepath = sourcepath & "\descent\"
        End If
        'Make Destination Folder
        If Not My.Computer.FileSystem.DirectoryExists(InstallPath & "missions\Descent\") Then
            MkDir(InstallPath & "missions\Descent\")
        End If
        'Copy necessart files
        WildCard.EXTSearchAndCopy(sourcepath, ".msn", InstallPath & "missions\Descent\")
        Progressbar.PerformStep()
        WildCard.EXTSearchAndCopy(sourcepath, ".rdl", InstallPath & "missions\Descent\")
        Progressbar.PerformStep()
        WildCard.EXTSearchAndCopy(sourcepath, ".hog", InstallPath & "missions\Descent\")
        Progressbar.PerformStep()
        WildCard.EXTSearchAndCopy(sourcepath, ".pig", InstallPath & "data\")
        Progressbar.PerformStep()
        WildCard.EXTSearchAndCopy(sourcepath, ".dem", InstallPath & "demos\")
        Progressbar.PerformStep()
        WildCard.EXTSearchAndCopy(sourcepath, ".sg", InstallPath & "savegames\Descent")
        Progressbar.PerformStep()
        WildCard.EXTSearchAndCopy(sourcepath, ".eff", InstallPath & "profiles\Descent")
        Progressbar.PerformStep()
        WildCard.EXTSearchAndCopy(sourcepath, ".plr", InstallPath & "profiles\Descent")
        Progressbar.PerformStep()
        WildCard.EXTSearchAndCopy(sourcepath, ".plx", InstallPath & "profiles\Descent")
        Progressbar.PerformStep()
        'My.Computer.FileSystem.CopyFile(sourcepath & "\descent2.adv", InstallPath & "data\descent2.adv", True)
        'SetAttr(InstallPath & "data\descent2.adv", vbNormal)
        'Progressbar.PerformStep()
        My.Computer.FileSystem.CopyFile(sourcepath & "\descentr.exe", InstallPath & "descentr.exe", True)
        SetAttr(InstallPath & "descentr.exe", vbNormal)
        Progressbar.PerformStep()
        'My.Computer.FileSystem.CopyFile(sourcepath & "\descent.b50", InstallPath & "data\descent.b50", True)
        'SetAttr(InstallPath & "data\descent.b50", vbNormal)
        'Progressbar.PerformStep()
        'My.Computer.FileSystem.CopyFile(sourcepath & "\descent.m50", InstallPath & "data\descent.m50", True)
        'SetAttr(InstallPath & "data\descent.m50", vbNormal)
        'Progressbar.PerformStep()
        My.Computer.FileSystem.CopyFile(sourcepath & "\descent.cfg", InstallPath & "config\descent.cfg", True)
        If My.Computer.FileSystem.FileExists(InstallPath & "config\Descent\descentg.cfg") Then
            SetAttr(InstallPath & "config\Descent\descent.cfg", vbNormal)
        End If
        Progressbar.PerformStep()
        My.Computer.FileSystem.CopyFile(sourcepath & "\descentg.ini", InstallPath & "config\descentg.ini", True)
        If My.Computer.FileSystem.FileExists(InstallPath & "config\Descent\descentg.ini") Then
            SetAttr(InstallPath & "config\Descent\descentg.ini", vbNormal)
        End If
        Progressbar.PerformStep()
        My.Computer.FileSystem.MoveFile(InstallPath & "missions\Descent\descent.hog", InstallPath & "data\descent.hog", True)
        Progressbar.PerformStep()
        'Restore Progress bar and finish
        Progressbar.Step = OldStep
    End Sub
    Public Sub DLOTW(ByVal sourcepath As String, ByVal InstallPath As String, ByVal Progressbar As ProgressBar)
        Dim OldStep As Integer = Progressbar.Step
        Progressbar.Step = Progressbar.Step / 3
        Dim WildCard As New WildCard
        MkDir(InstallPath & "missions\Descent\Levels of the World\")
        WildCard.EXTSearchAndCopy(sourcepath, ".msn", InstallPath & "missions\Descent\Levels of the World\")
        Progressbar.PerformStep()
        WildCard.EXTSearchAndCopy(sourcepath, ".rdl", InstallPath & "missions\Descent\Levels of the World\")
        Progressbar.PerformStep()
        WildCard.EXTSearchAndCopy(sourcepath, ".hog", InstallPath & "missions\Descent\Levels of the World\")
        Progressbar.PerformStep()
        Progressbar.Step = OldStep
    End Sub
    Private Sub D2Old(ByVal sourcepath As String, ByVal InstallPath As String, ByVal Progressbar As ProgressBar)
        Dim WildCard As New WildCard
        Dim OldStep As Integer = Progressbar.Step
        Progressbar.Step = Progressbar.Step / 21
        My.Computer.FileSystem.CopyDirectory(sourcepath & "missions\", InstallPath & "missions\Descent II\", True)
        Progressbar.PerformStep()
        SetAttr(InstallPath & "missions\Descent II\PANIC.HOG", vbNormal)
        SetAttr(InstallPath & "missions\Descent II\PANIC.MN2", vbNormal)
        If My.Computer.FileSystem.FileExists(sourcepath & "HOARD.HAM") Then
            My.Computer.FileSystem.MoveFile(InstallPath & "missions\Descent II\D2X.HOG", InstallPath & "missions\D2X.HOG", True)
            My.Computer.FileSystem.MoveFile(InstallPath & "missions\Descent II\D2X.MN2", InstallPath & "missions\D2X.MN2", True)
            Progressbar.PerformStep()
        End If
        My.Computer.FileSystem.CopyDirectory(sourcepath & "demos\", InstallPath & "demos\", True)
        Progressbar.PerformStep()
        WildCard.EXTSearchAndCopy(sourcepath, ".mvl", InstallPath & "movies\")
        Progressbar.PerformStep()
        WildCard.EXTSearchAndCopy(sourcepath, ".cfg", InstallPath & "config\Descent II\")
        Progressbar.PerformStep()
        WildCard.EXTSearchAndCopy(sourcepath, ".pcx", InstallPath & "screenshots\")
        Progressbar.PerformStep()
        WildCard.EXTSearchAndCopy(sourcepath, ".plr", InstallPath & "profiles\Descent II\")
        Progressbar.PerformStep()
        WildCard.EXTSearchAndCopy(sourcepath, ".sg", InstallPath & "savegames\Descent II\")
        Progressbar.PerformStep()
        My.Computer.FileSystem.CopyFile(sourcepath & "DESCENTG.INI", InstallPath & "config\Descent II\DESCENTG.INI", True)
        SetAttr(InstallPath & "config\Descent II\DESCENTG.INI", vbNormal)
        Progressbar.PerformStep()
        My.Computer.FileSystem.CopyFile(sourcepath & "DESCENT2.HAM", InstallPath & "data\DESCENT2.HAM", True)
        SetAttr(InstallPath & "data\DESCENT2.HAM", vbNormal)
        Progressbar.PerformStep()
        If My.Computer.FileSystem.FileExists(sourcepath & "HOARD.HAM") Then
            My.Computer.FileSystem.CopyFile(sourcepath & "HOARD.HAM", InstallPath & "data\HOARD.HAM", True)
            SetAttr(InstallPath & "data\HOARD.HAM", vbNormal)
        End If
        Progressbar.PerformStep()
        My.Computer.FileSystem.CopyFile(sourcepath & "DESCENT2.HOG", InstallPath & "data\DESCENT2.HOG", True)
        SetAttr(InstallPath & "data\DESCENT2.HOG", vbNormal)
        Progressbar.PerformStep()
        My.Computer.FileSystem.CopyFile(sourcepath & "ALIEN1.PIG", InstallPath & "data\ALIEN1.PIG", True)
        SetAttr(InstallPath & "data\ALIEN1.PIG", vbNormal)
        Progressbar.PerformStep()
        My.Computer.FileSystem.CopyFile(sourcepath & "ALIEN2.PIG", InstallPath & "data\ALIEN2.PIG", True)
        SetAttr(InstallPath & "data\ALIEN2.PIG", vbNormal)
        Progressbar.PerformStep()
        My.Computer.FileSystem.CopyFile(sourcepath & "FIRE.PIG", InstallPath & "data\FIRE.PIG", True)
        SetAttr(InstallPath & "data\FIRE.PIG", vbNormal)
        Progressbar.PerformStep()
        My.Computer.FileSystem.CopyFile(sourcepath & "GROUPA.PIG", InstallPath & "data\GROUPA.PIG", True)
        SetAttr(InstallPath & "data\GROUPA.PIG", vbNormal)
        Progressbar.PerformStep()
        My.Computer.FileSystem.CopyFile(sourcepath & "WATER.PIG", InstallPath & "data\WATER.PIG", True)
        SetAttr(InstallPath & "data\WATER.PIG", vbNormal)
        Progressbar.PerformStep()
        My.Computer.FileSystem.CopyFile(sourcepath & "ICE.PIG", InstallPath & "data\ICE.PIG", True)
        SetAttr(InstallPath & "data\ICE.PIG", vbNormal)
        Progressbar.PerformStep()
        My.Computer.FileSystem.CopyFile(sourcepath & "DESCENT2.S11", InstallPath & "data\DESCENT2.S11", True)
        SetAttr(InstallPath & "data\DESCENT2.S11", vbNormal)
        Progressbar.PerformStep()
        My.Computer.FileSystem.CopyFile(sourcepath & "DESCENT2.S22", InstallPath & "data\DESCENT2.S22", True)
        SetAttr(InstallPath & "data\DESCENT2.S22", vbNormal)
        Progressbar.PerformStep()
        My.Computer.FileSystem.CopyFile(sourcepath & "DESCENT2.EXE", InstallPath & "DESCENT2.EXE", True)
        SetAttr(InstallPath & "DESCENT2.EXE", vbNormal)
        Progressbar.PerformStep()
        Progressbar.Step = OldStep
    End Sub
    Private Sub D2New(ByVal ProcessD As Process, ByVal sourcepath As String, ByVal InstallPath As String, ByVal Progressbar As ProgressBar)
        'this procedure just copies the descent 2 files from the cd, or old install path as necessary
        Dim OldStep As Integer = Progressbar.Step
        Progressbar.Step = Progressbar.Step / 8
        'copy *.hog *.mn2
        ProcessD.StartInfo.Arguments = " x -y -o" & Chr(34) & InstallPath & "missions\Descent II\" & Chr(34) & " " & Chr(34) & sourcepath & "D2DATA\DESCENT2.SOW" & Chr(34) & " *.hog *.mn2"
        ProcessD.Start()
        While Not ProcessD.HasExited
        End While
        My.Computer.FileSystem.MoveFile(InstallPath & "missions\Descent II\descent2.hog", InstallPath & "data\descent2.hog", True)
        Progressbar.PerformStep()
        'copy *.pcx
        ProcessD.StartInfo.Arguments = "x -y -o" & Chr(34) & InstallPath & "screenshots\" & Chr(34) & " " & Chr(34) & sourcepath & "d2data\descent2.sow" & Chr(34) & " *.pcx"
        ProcessD.Start()
        While Not ProcessD.HasExited
        End While
        Progressbar.PerformStep()
        'copy *.ham *.pig *.s11 *.s22
        ProcessD.StartInfo.Arguments = "x -y -o" & Chr(34) & InstallPath & "data\" & Chr(34) & " " & Chr(34) & sourcepath & "d2data\descent2.sow" & Chr(34) & " *.pig *.ham *.s11 *.s22"
        ProcessD.Start()
        While Not ProcessD.HasExited
        End While
        Progressbar.PerformStep()
        'copy descentg.ini
        ProcessD.StartInfo.Arguments = "x -y -o" & Chr(34) & InstallPath & "config\Descent II\" & Chr(34) & " " & Chr(34) & sourcepath & "d2data\descent2.sow" & Chr(34) & " descentg.ini"
        ProcessD.Start()
        While Not ProcessD.HasExited
        End While
        Progressbar.PerformStep()
        'copy descent2.exe
        ProcessD.StartInfo.Arguments = "x -y -o" & Chr(34) & InstallPath & Chr(34) & " " & Chr(34) & sourcepath & "d2data\descent2.sow" & Chr(34) & " descent2.exe"
        ProcessD.Start()
        While Not ProcessD.HasExited
        End While
        Progressbar.PerformStep()
        'copy *.mvl
        My.Computer.FileSystem.CopyFile(sourcepath & "d2data\INTRO-H.MVL", InstallPath & "movies\INTRO-H.MVL", True)
        SetAttr(InstallPath & "movies\INTRO-H.MVL", vbNormal)
        Progressbar.PerformStep()
        My.Computer.FileSystem.CopyFile(sourcepath & "d2data\OTHER-H.MVL", InstallPath & "movies\OTHER-H.MVL", True)
        SetAttr(InstallPath & "movies\OTHER-H.MVL", vbNormal)
        Progressbar.PerformStep()
        My.Computer.FileSystem.CopyFile(sourcepath & "d2data\ROBOTS-H.MVL", InstallPath & "movies\ROBOTS-H.MVL", True)
        SetAttr(InstallPath & "movies\ROBOTS-H.MVL", vbNormal)
        Progressbar.PerformStep()
        Progressbar.Step = OldStep
    End Sub
    Public Sub D2V(ByVal sourcepath As String, ByVal InstallPath As String, ByVal Progressbar As ProgressBar)
        'copies the Descent 2 Vertigo files from the CD to the D2X folder
        Dim OldStep As Integer = Progressbar.Step
        Progressbar.Step = Progressbar.Step / 10
        My.Computer.FileSystem.CopyDirectory(sourcepath & "vertigo\missions\", InstallPath & "missions\Descent II\", True)
        SetAttr(InstallPath & "missions\Descent II\Panic.hog", vbNormal)
        Progressbar.PerformStep()
        My.Computer.FileSystem.CopyFile(sourcepath & "vertigo\d2x.hog", InstallPath & "missions\d2x.hog", True)
        SetAttr(InstallPath & "missions\d2x.hog", vbNormal)
        Progressbar.PerformStep()
        My.Computer.FileSystem.CopyFile(sourcepath & "vertigo\d2x.mn2", InstallPath & "missions\d2x.mn2", True)
        SetAttr(InstallPath & "missions\d2x.mn2", vbNormal)
        Progressbar.PerformStep()
        My.Computer.FileSystem.CopyFile(sourcepath & "vertigo\d2x-h.mvl", InstallPath & "movies\d2x-h.mvl", True)
        SetAttr(InstallPath & "movies\d2x-h.mvl", vbNormal)
        Progressbar.PerformStep()
        My.Computer.FileSystem.CopyFile(sourcepath & "vertigo\d2x-l.mvl", InstallPath & "movies\d2x-l.mvl", True)
        SetAttr(InstallPath & "movies\d2x-l.mvl", vbNormal)
        Progressbar.PerformStep()
        My.Computer.FileSystem.CopyFile(sourcepath & "vertigo\descent2.exe", InstallPath & "descent2.exe", True)
        SetAttr(InstallPath & "descent2.exe", vbNormal)
        Progressbar.PerformStep()
        My.Computer.FileSystem.CopyFile(sourcepath & "vertigo\descent2.hog", InstallPath & "data\descent2.hog", True)
        SetAttr(InstallPath & "data\descent2.hog", vbNormal)
        Progressbar.PerformStep()
        My.Computer.FileSystem.CopyFile(sourcepath & "vertigo\descent2.ham", InstallPath & "data\descent2.ham", True)
        SetAttr(InstallPath & "data\descent2.ham", vbNormal)
        Progressbar.PerformStep()
        My.Computer.FileSystem.CopyFile(sourcepath & "vertigo\hoard.ham", InstallPath & "data\hoard.ham", True)
        SetAttr(InstallPath & "data\hoard.ham", vbNormal)
        Progressbar.PerformStep()
        My.Computer.FileSystem.CopyFile(sourcepath & "vertigo\descent.cfg", InstallPath & "config\Descent II\descent.cfg", True)
        SetAttr(InstallPath & "config\Descent II\descent.cfg", vbNormal)
        Progressbar.PerformStep()
        Progressbar.Step = OldStep
    End Sub
    Public Sub D2X(ByVal sourcepath As String, ByVal InstallPath As String, ByVal D2XLocation() As String, ByVal UseD2Inst As Boolean, ByVal HiRes As Boolean, ByVal Progressbar As ProgressBar, ByVal ProcessD As Process)
        'This procedure install the Descent 2 portion as well as the core D2X files
        Dim OldStep As Integer = Progressbar.Step
        Progressbar.Step = Progressbar.Step / 3
        'create the install folder
        On Error Resume Next
        MkDir(InstallPath)
        On Error Resume Next
        MkDir(InstallPath & "movies")
        On Error Resume Next
        MkDir(InstallPath & "missions\Single")
        On Error Resume Next
        MkDir(InstallPath & "profiles\Descent")
        On Error Resume Next
        MkDir(InstallPath & "profiles\Descent II")
        On Error Resume Next
        MkDir(InstallPath & "savegames\Descent")
        On Error Resume Next
        MkDir(InstallPath & "savegames\Descent II")
        On Error Resume Next
        MkDir(InstallPath & "screenshots")
        On Error Resume Next
        MkDir(InstallPath & "config\Descent")
        On Error Resume Next
        MkDir(InstallPath & "config\Descent II")
        Progressbar.PerformStep()
        'extract the D2X files from the RAR file
        ProcessD.StartInfo.Arguments = " x -y -o" & Chr(34) & InstallPath & Chr(34) & " " & Chr(34) & D2XLocation(1) & Chr(34)
        ProcessD.Start()
        While Not ProcessD.HasExited
        End While
        Progressbar.PerformStep()
        'begin installing Descent 2 core files
        If UseD2Inst = True Then
            'otherwise it copies from the older install
            D2Old(sourcepath, InstallPath, Progressbar)
        Else
            'if the user selected to install from a cd then it copies from the cd
            D2New(ProcessD, sourcepath, InstallPath, Progressbar)
        End If
        Progressbar.PerformStep()
        SetAttr(InstallPath & "config\Descent\descent.cfg", vbNormal)
        SetAttr(InstallPath & "config\Descent II\descent.cfg", vbNormal)
        Progressbar.Step = OldStep
    End Sub
    Public Sub HQSFX(ByVal sourcepath As String, ByVal InstallPath As String, ByVal Progressbar As ProgressBar, ByVal ProcessD As Process)
        'extract all SFX into right folders.
        ProcessD.StartInfo.Arguments = "x -y -o" & Chr(34) & InstallPath & Chr(34) & " " & Chr(34) & sourcepath & Chr(34)
        ProcessD.Start()
        While Not ProcessD.HasExited
        End While
        Progressbar.PerformStep()
    End Sub
End Class
