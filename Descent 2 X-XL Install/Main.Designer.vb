<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        Me.FLDR_01 = New System.Windows.Forms.FolderBrowserDialog
        Me.CHKB_01 = New System.Windows.Forms.CheckBox
        Me.CHKB_02 = New System.Windows.Forms.CheckBox
        Me.CHKB_03 = New System.Windows.Forms.CheckBox
        Me.CHKB_04 = New System.Windows.Forms.CheckBox
        Me.CHKB_05 = New System.Windows.Forms.CheckBox
        Me.CHKB_06 = New System.Windows.Forms.CheckBox
        Me.CHKB_07 = New System.Windows.Forms.CheckBox
        Me.CHKB_08 = New System.Windows.Forms.CheckBox
        Me.RBTN_01 = New System.Windows.Forms.RadioButton
        Me.RBTN_02 = New System.Windows.Forms.RadioButton
        Me.BTTN_Previous = New System.Windows.Forms.Button
        Me.BTTN_Next = New System.Windows.Forms.Button
        Me.TXTB_InstallPath = New System.Windows.Forms.TextBox
        Me.GRPB_Common = New System.Windows.Forms.GroupBox
        Me.CHKB_09 = New System.Windows.Forms.CheckBox
        Me.BTTN_Browse = New System.Windows.Forms.Button
        Me.LABL_InstallPath = New System.Windows.Forms.Label
        Me.RTXT_Common = New System.Windows.Forms.RichTextBox
        Me.ProgressBar = New System.Windows.Forms.ProgressBar
        Me.Open_01 = New System.Windows.Forms.OpenFileDialog
        Me.GRPB_Common.SuspendLayout()
        Me.SuspendLayout()
        '
        'CHKB_01
        '
        Me.CHKB_01.AutoSize = True
        Me.CHKB_01.Location = New System.Drawing.Point(5, 18)
        Me.CHKB_01.Name = "CHKB_01"
        Me.CHKB_01.Size = New System.Drawing.Size(102, 17)
        Me.CHKB_01.TabIndex = 0
        Me.CHKB_01.Text = "Install Descent I"
        Me.CHKB_01.UseVisualStyleBackColor = True
        Me.CHKB_01.Visible = False
        '
        'CHKB_02
        '
        Me.CHKB_02.AutoSize = True
        Me.CHKB_02.Location = New System.Drawing.Point(5, 41)
        Me.CHKB_02.Name = "CHKB_02"
        Me.CHKB_02.Size = New System.Drawing.Size(144, 17)
        Me.CHKB_02.TabIndex = 1
        Me.CHKB_02.Text = "Install Descent II: Vertigo"
        Me.CHKB_02.UseVisualStyleBackColor = True
        Me.CHKB_02.Visible = False
        '
        'CHKB_03
        '
        Me.CHKB_03.AutoSize = True
        Me.CHKB_03.Location = New System.Drawing.Point(5, 65)
        Me.CHKB_03.Name = "CHKB_03"
        Me.CHKB_03.Size = New System.Drawing.Size(136, 17)
        Me.CHKB_03.TabIndex = 2
        Me.CHKB_03.Text = "Install High Quality SFX"
        Me.CHKB_03.UseVisualStyleBackColor = True
        Me.CHKB_03.Visible = False
        '
        'CHKB_04
        '
        Me.CHKB_04.AutoSize = True
        Me.CHKB_04.Location = New System.Drawing.Point(5, 88)
        Me.CHKB_04.Name = "CHKB_04"
        Me.CHKB_04.Size = New System.Drawing.Size(201, 17)
        Me.CHKB_04.TabIndex = 4
        Me.CHKB_04.Text = "Install Descent - 'Levels of the World'"
        Me.CHKB_04.UseVisualStyleBackColor = True
        Me.CHKB_04.Visible = False
        '
        'CHKB_05
        '
        Me.CHKB_05.AutoSize = True
        Me.CHKB_05.Enabled = False
        Me.CHKB_05.Location = New System.Drawing.Point(168, 19)
        Me.CHKB_05.Name = "CHKB_05"
        Me.CHKB_05.Size = New System.Drawing.Size(168, 17)
        Me.CHKB_05.TabIndex = 5
        Me.CHKB_05.Text = "Use Previous Descent I Install"
        Me.CHKB_05.UseVisualStyleBackColor = True
        Me.CHKB_05.Visible = False
        '
        'CHKB_06
        '
        Me.CHKB_06.AutoSize = True
        Me.CHKB_06.Location = New System.Drawing.Point(168, 41)
        Me.CHKB_06.Name = "CHKB_06"
        Me.CHKB_06.Size = New System.Drawing.Size(171, 17)
        Me.CHKB_06.TabIndex = 6
        Me.CHKB_06.Text = "Use Previous Descent II Install"
        Me.CHKB_06.UseVisualStyleBackColor = True
        Me.CHKB_06.Visible = False
        '
        'CHKB_07
        '
        Me.CHKB_07.AutoSize = True
        Me.CHKB_07.Checked = True
        Me.CHKB_07.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CHKB_07.Enabled = False
        Me.CHKB_07.Location = New System.Drawing.Point(168, 65)
        Me.CHKB_07.Name = "CHKB_07"
        Me.CHKB_07.Size = New System.Drawing.Size(130, 17)
        Me.CHKB_07.TabIndex = 7
        Me.CHKB_07.Text = "Save Previous Installs"
        Me.CHKB_07.UseVisualStyleBackColor = True
        Me.CHKB_07.Visible = False
        '
        'CHKB_08
        '
        Me.CHKB_08.AutoSize = True
        Me.CHKB_08.Enabled = False
        Me.CHKB_08.Location = New System.Drawing.Point(5, 111)
        Me.CHKB_08.Name = "CHKB_08"
        Me.CHKB_08.Size = New System.Drawing.Size(163, 17)
        Me.CHKB_08.TabIndex = 3
        Me.CHKB_08.Text = "Install Updates as Necessary"
        Me.CHKB_08.UseVisualStyleBackColor = True
        Me.CHKB_08.Visible = False
        '
        'RBTN_01
        '
        Me.RBTN_01.AutoSize = True
        Me.RBTN_01.Enabled = False
        Me.RBTN_01.Location = New System.Drawing.Point(6, 43)
        Me.RBTN_01.Name = "RBTN_01"
        Me.RBTN_01.Size = New System.Drawing.Size(135, 17)
        Me.RBTN_01.TabIndex = 1
        Me.RBTN_01.Text = "Install High Resolustion"
        Me.RBTN_01.UseVisualStyleBackColor = True
        '
        'RBTN_02
        '
        Me.RBTN_02.AutoSize = True
        Me.RBTN_02.Checked = True
        Me.RBTN_02.Location = New System.Drawing.Point(6, 18)
        Me.RBTN_02.Name = "RBTN_02"
        Me.RBTN_02.Size = New System.Drawing.Size(128, 17)
        Me.RBTN_02.TabIndex = 0
        Me.RBTN_02.TabStop = True
        Me.RBTN_02.Text = "Install Low Resolution"
        Me.RBTN_02.UseVisualStyleBackColor = True
        '
        'BTTN_Previous
        '
        Me.BTTN_Previous.Enabled = False
        Me.BTTN_Previous.Location = New System.Drawing.Point(267, 341)
        Me.BTTN_Previous.Name = "BTTN_Previous"
        Me.BTTN_Previous.Size = New System.Drawing.Size(75, 23)
        Me.BTTN_Previous.TabIndex = 10
        Me.BTTN_Previous.Text = "Previous"
        Me.BTTN_Previous.UseVisualStyleBackColor = True
        '
        'BTTN_Next
        '
        Me.BTTN_Next.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BTTN_Next.Location = New System.Drawing.Point(528, 341)
        Me.BTTN_Next.Name = "BTTN_Next"
        Me.BTTN_Next.Size = New System.Drawing.Size(75, 23)
        Me.BTTN_Next.TabIndex = 11
        Me.BTTN_Next.Text = "Next"
        Me.BTTN_Next.UseVisualStyleBackColor = True
        '
        'TXTB_InstallPath
        '
        Me.TXTB_InstallPath.Location = New System.Drawing.Point(348, 315)
        Me.TXTB_InstallPath.Name = "TXTB_InstallPath"
        Me.TXTB_InstallPath.Size = New System.Drawing.Size(174, 20)
        Me.TXTB_InstallPath.TabIndex = 8
        '
        'GRPB_Common
        '
        Me.GRPB_Common.BackColor = System.Drawing.SystemColors.MenuBar
        Me.GRPB_Common.Controls.Add(Me.CHKB_09)
        Me.GRPB_Common.Controls.Add(Me.CHKB_01)
        Me.GRPB_Common.Controls.Add(Me.CHKB_02)
        Me.GRPB_Common.Controls.Add(Me.CHKB_05)
        Me.GRPB_Common.Controls.Add(Me.CHKB_03)
        Me.GRPB_Common.Controls.Add(Me.CHKB_04)
        Me.GRPB_Common.Controls.Add(Me.CHKB_06)
        Me.GRPB_Common.Controls.Add(Me.CHKB_07)
        Me.GRPB_Common.Controls.Add(Me.RBTN_02)
        Me.GRPB_Common.Controls.Add(Me.CHKB_08)
        Me.GRPB_Common.Controls.Add(Me.RBTN_01)
        Me.GRPB_Common.Location = New System.Drawing.Point(284, 162)
        Me.GRPB_Common.Name = "GRPB_Common"
        Me.GRPB_Common.Size = New System.Drawing.Size(345, 134)
        Me.GRPB_Common.TabIndex = 13
        Me.GRPB_Common.TabStop = False
        '
        'CHKB_09
        '
        Me.CHKB_09.AutoSize = True
        Me.CHKB_09.Checked = True
        Me.CHKB_09.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CHKB_09.Location = New System.Drawing.Point(168, 111)
        Me.CHKB_09.Name = "CHKB_09"
        Me.CHKB_09.Size = New System.Drawing.Size(124, 17)
        Me.CHKB_09.TabIndex = 8
        Me.CHKB_09.Text = "Create Desktop Icon"
        Me.CHKB_09.UseVisualStyleBackColor = True
        Me.CHKB_09.Visible = False
        '
        'BTTN_Browse
        '
        Me.BTTN_Browse.Location = New System.Drawing.Point(528, 312)
        Me.BTTN_Browse.Name = "BTTN_Browse"
        Me.BTTN_Browse.Size = New System.Drawing.Size(75, 23)
        Me.BTTN_Browse.TabIndex = 9
        Me.BTTN_Browse.Text = "Browse"
        Me.BTTN_Browse.UseVisualStyleBackColor = True
        '
        'LABL_InstallPath
        '
        Me.LABL_InstallPath.AutoSize = True
        Me.LABL_InstallPath.Location = New System.Drawing.Point(345, 299)
        Me.LABL_InstallPath.Name = "LABL_InstallPath"
        Me.LABL_InstallPath.Size = New System.Drawing.Size(145, 13)
        Me.LABL_InstallPath.TabIndex = 99
        Me.LABL_InstallPath.Text = "Location of D2X-XL RAR file."
        '
        'RTXT_Common
        '
        Me.RTXT_Common.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.RTXT_Common.Location = New System.Drawing.Point(30, 221)
        Me.RTXT_Common.Name = "RTXT_Common"
        Me.RTXT_Common.ReadOnly = True
        Me.RTXT_Common.Size = New System.Drawing.Size(207, 75)
        Me.RTXT_Common.TabIndex = 100
        Me.RTXT_Common.TabStop = False
        Me.RTXT_Common.Text = "Welcome to the Descent II - X XL Installer." & Global.Microsoft.VisualBasic.ChrW(10) & "Plese select you install type."
        '
        'ProgressBar
        '
        Me.ProgressBar.AccessibleName = ""
        Me.ProgressBar.Location = New System.Drawing.Point(348, 341)
        Me.ProgressBar.Name = "ProgressBar"
        Me.ProgressBar.Size = New System.Drawing.Size(174, 23)
        Me.ProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.ProgressBar.TabIndex = 100
        Me.ProgressBar.Visible = False
        '
        'Open_01
        '
        Me.Open_01.FileName = "*.rar"
        Me.Open_01.Multiselect = True
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(632, 453)
        Me.Controls.Add(Me.ProgressBar)
        Me.Controls.Add(Me.RTXT_Common)
        Me.Controls.Add(Me.LABL_InstallPath)
        Me.Controls.Add(Me.BTTN_Browse)
        Me.Controls.Add(Me.GRPB_Common)
        Me.Controls.Add(Me.TXTB_InstallPath)
        Me.Controls.Add(Me.BTTN_Next)
        Me.Controls.Add(Me.BTTN_Previous)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(640, 480)
        Me.MinimumSize = New System.Drawing.Size(640, 480)
        Me.Name = "Main"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Descent 2 X-XL Install"
        Me.TransparencyKey = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GRPB_Common.ResumeLayout(False)
        Me.GRPB_Common.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents FLDR_01 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents CHKB_01 As System.Windows.Forms.CheckBox
    Friend WithEvents CHKB_02 As System.Windows.Forms.CheckBox
    Friend WithEvents CHKB_03 As System.Windows.Forms.CheckBox
    Friend WithEvents CHKB_04 As System.Windows.Forms.CheckBox
    Friend WithEvents CHKB_05 As System.Windows.Forms.CheckBox
    Friend WithEvents CHKB_06 As System.Windows.Forms.CheckBox
    Friend WithEvents CHKB_07 As System.Windows.Forms.CheckBox
    Friend WithEvents CHKB_08 As System.Windows.Forms.CheckBox
    Friend WithEvents RBTN_01 As System.Windows.Forms.RadioButton
    Friend WithEvents RBTN_02 As System.Windows.Forms.RadioButton
    Friend WithEvents BTTN_Previous As System.Windows.Forms.Button
    Friend WithEvents BTTN_Next As System.Windows.Forms.Button
    Friend WithEvents TXTB_InstallPath As System.Windows.Forms.TextBox
    Friend WithEvents GRPB_Common As System.Windows.Forms.GroupBox
    Friend WithEvents BTTN_Browse As System.Windows.Forms.Button
    Friend WithEvents LABL_InstallPath As System.Windows.Forms.Label
    Friend WithEvents RTXT_Common As System.Windows.Forms.RichTextBox
    Friend WithEvents ProgressBar As System.Windows.Forms.ProgressBar
    Friend WithEvents Open_01 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents CHKB_09 As System.Windows.Forms.CheckBox
End Class
