<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProfiler
    Inherits System.Windows.Forms.UserControl

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmProfiler))
        Me.cboINPUT = New System.Windows.Forms.ComboBox()
        Me.cmdRefresh = New System.Windows.Forms.Button()
        Me.cboDEM = New System.Windows.Forms.ComboBox()
        Me.cmdSubmit = New System.Windows.Forms.Button()
        Me.txtOUTPUT = New System.Windows.Forms.TextBox()
        Me.cmdBrowse = New System.Windows.Forms.Button()
        Me.txtCirclePoints = New System.Windows.Forms.TextBox()
        Me.lblINPUT = New System.Windows.Forms.Label()
        Me.lblDEM = New System.Windows.Forms.Label()
        Me.lblOUTPUT = New System.Windows.Forms.Label()
        Me.grpSettings = New System.Windows.Forms.GroupBox()
        Me.lblResolution = New System.Windows.Forms.Label()
        Me.lblInterval = New System.Windows.Forms.Label()
        Me.lblMax = New System.Windows.Forms.Label()
        Me.lblMin = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtResolution = New System.Windows.Forms.TextBox()
        Me.txtInterval = New System.Windows.Forms.TextBox()
        Me.txtMin = New System.Windows.Forms.TextBox()
        Me.txtMax = New System.Windows.Forms.TextBox()
        Me.lblCirclePoints = New System.Windows.Forms.Label()
        Me.grpProfile = New System.Windows.Forms.GroupBox()
        Me.optLongitudinal = New System.Windows.Forms.RadioButton()
        Me.optTransversal = New System.Windows.Forms.RadioButton()
        Me.lblVersion = New System.Windows.Forms.Label()
        Me.lblSeparator = New System.Windows.Forms.Label()
        Me.cboSeparator = New System.Windows.Forms.ComboBox()
        Me.grpSettings.SuspendLayout()
        Me.grpProfile.SuspendLayout()
        Me.SuspendLayout()
        '
        'cboINPUT
        '
        Me.cboINPUT.FormattingEnabled = True
        Me.cboINPUT.Location = New System.Drawing.Point(20, 151)
        Me.cboINPUT.Name = "cboINPUT"
        Me.cboINPUT.Size = New System.Drawing.Size(184, 21)
        Me.cboINPUT.TabIndex = 2
        '
        'cmdRefresh
        '
        Me.cmdRefresh.Image = CType(resources.GetObject("cmdRefresh.Image"), System.Drawing.Image)
        Me.cmdRefresh.Location = New System.Drawing.Point(170, 178)
        Me.cmdRefresh.Name = "cmdRefresh"
        Me.cmdRefresh.Size = New System.Drawing.Size(34, 37)
        Me.cmdRefresh.TabIndex = 3
        Me.cmdRefresh.UseVisualStyleBackColor = True
        '
        'cboDEM
        '
        Me.cboDEM.FormattingEnabled = True
        Me.cboDEM.Location = New System.Drawing.Point(19, 231)
        Me.cboDEM.Name = "cboDEM"
        Me.cboDEM.Size = New System.Drawing.Size(184, 21)
        Me.cboDEM.TabIndex = 5
        '
        'cmdSubmit
        '
        Me.cmdSubmit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSubmit.Location = New System.Drawing.Point(69, 596)
        Me.cmdSubmit.Name = "cmdSubmit"
        Me.cmdSubmit.Size = New System.Drawing.Size(80, 39)
        Me.cmdSubmit.TabIndex = 14
        Me.cmdSubmit.Text = "SUBMIT"
        Me.cmdSubmit.UseVisualStyleBackColor = True
        '
        'txtOUTPUT
        '
        Me.txtOUTPUT.Location = New System.Drawing.Point(20, 519)
        Me.txtOUTPUT.Name = "txtOUTPUT"
        Me.txtOUTPUT.Size = New System.Drawing.Size(183, 20)
        Me.txtOUTPUT.TabIndex = 10
        '
        'cmdBrowse
        '
        Me.cmdBrowse.Location = New System.Drawing.Point(147, 544)
        Me.cmdBrowse.Name = "cmdBrowse"
        Me.cmdBrowse.Size = New System.Drawing.Size(55, 23)
        Me.cmdBrowse.TabIndex = 11
        Me.cmdBrowse.Text = "Browse"
        Me.cmdBrowse.UseVisualStyleBackColor = True
        '
        'txtCirclePoints
        '
        Me.txtCirclePoints.Location = New System.Drawing.Point(147, 446)
        Me.txtCirclePoints.Name = "txtCirclePoints"
        Me.txtCirclePoints.Size = New System.Drawing.Size(40, 20)
        Me.txtCirclePoints.TabIndex = 8
        Me.txtCirclePoints.Text = "360"
        Me.txtCirclePoints.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblINPUT
        '
        Me.lblINPUT.AutoSize = True
        Me.lblINPUT.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblINPUT.Location = New System.Drawing.Point(43, 135)
        Me.lblINPUT.Name = "lblINPUT"
        Me.lblINPUT.Size = New System.Drawing.Size(127, 13)
        Me.lblINPUT.TabIndex = 1
        Me.lblINPUT.Text = "Select layer of points"
        '
        'lblDEM
        '
        Me.lblDEM.AutoSize = True
        Me.lblDEM.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDEM.Location = New System.Drawing.Point(66, 215)
        Me.lblDEM.Name = "lblDEM"
        Me.lblDEM.Size = New System.Drawing.Size(74, 13)
        Me.lblDEM.TabIndex = 4
        Me.lblDEM.Text = "Select DEM"
        '
        'lblOUTPUT
        '
        Me.lblOUTPUT.AutoSize = True
        Me.lblOUTPUT.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOUTPUT.Location = New System.Drawing.Point(66, 503)
        Me.lblOUTPUT.Name = "lblOUTPUT"
        Me.lblOUTPUT.Size = New System.Drawing.Size(81, 13)
        Me.lblOUTPUT.TabIndex = 9
        Me.lblOUTPUT.Text = "Output folder"
        '
        'grpSettings
        '
        Me.grpSettings.Controls.Add(Me.lblResolution)
        Me.grpSettings.Controls.Add(Me.lblInterval)
        Me.grpSettings.Controls.Add(Me.lblMax)
        Me.grpSettings.Controls.Add(Me.lblMin)
        Me.grpSettings.Controls.Add(Me.Label4)
        Me.grpSettings.Controls.Add(Me.Label3)
        Me.grpSettings.Controls.Add(Me.Label2)
        Me.grpSettings.Controls.Add(Me.Label1)
        Me.grpSettings.Controls.Add(Me.txtResolution)
        Me.grpSettings.Controls.Add(Me.txtInterval)
        Me.grpSettings.Controls.Add(Me.txtMin)
        Me.grpSettings.Controls.Add(Me.txtMax)
        Me.grpSettings.Location = New System.Drawing.Point(19, 273)
        Me.grpSettings.Name = "grpSettings"
        Me.grpSettings.Size = New System.Drawing.Size(184, 150)
        Me.grpSettings.TabIndex = 6
        Me.grpSettings.TabStop = False
        Me.grpSettings.Text = "Segment settings"
        '
        'lblResolution
        '
        Me.lblResolution.AutoSize = True
        Me.lblResolution.Location = New System.Drawing.Point(33, 112)
        Me.lblResolution.Name = "lblResolution"
        Me.lblResolution.Size = New System.Drawing.Size(57, 13)
        Me.lblResolution.TabIndex = 9
        Me.lblResolution.Text = "Resolution"
        '
        'lblInterval
        '
        Me.lblInterval.AutoSize = True
        Me.lblInterval.Location = New System.Drawing.Point(33, 86)
        Me.lblInterval.Name = "lblInterval"
        Me.lblInterval.Size = New System.Drawing.Size(42, 13)
        Me.lblInterval.TabIndex = 6
        Me.lblInterval.Text = "Interval"
        '
        'lblMax
        '
        Me.lblMax.AutoSize = True
        Me.lblMax.Location = New System.Drawing.Point(33, 60)
        Me.lblMax.Name = "lblMax"
        Me.lblMax.Size = New System.Drawing.Size(59, 13)
        Me.lblMax.TabIndex = 3
        Me.lblMax.Text = "Max length"
        '
        'lblMin
        '
        Me.lblMin.AutoSize = True
        Me.lblMin.Location = New System.Drawing.Point(33, 35)
        Me.lblMin.Name = "lblMin"
        Me.lblMin.Size = New System.Drawing.Size(56, 13)
        Me.lblMin.TabIndex = 0
        Me.lblMin.Text = "Min length"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(148, 112)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(15, 13)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "m"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(148, 86)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(15, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "m"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(148, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(15, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "m"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(148, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(15, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "m"
        '
        'txtResolution
        '
        Me.txtResolution.Location = New System.Drawing.Point(101, 109)
        Me.txtResolution.Name = "txtResolution"
        Me.txtResolution.Size = New System.Drawing.Size(40, 20)
        Me.txtResolution.TabIndex = 10
        Me.txtResolution.Text = "1"
        Me.txtResolution.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtInterval
        '
        Me.txtInterval.Location = New System.Drawing.Point(101, 83)
        Me.txtInterval.Name = "txtInterval"
        Me.txtInterval.Size = New System.Drawing.Size(40, 20)
        Me.txtInterval.TabIndex = 7
        Me.txtInterval.Text = "10"
        Me.txtInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtMin
        '
        Me.txtMin.Location = New System.Drawing.Point(102, 32)
        Me.txtMin.Name = "txtMin"
        Me.txtMin.Size = New System.Drawing.Size(40, 20)
        Me.txtMin.TabIndex = 1
        Me.txtMin.Text = "10"
        Me.txtMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtMax
        '
        Me.txtMax.Location = New System.Drawing.Point(101, 57)
        Me.txtMax.Name = "txtMax"
        Me.txtMax.Size = New System.Drawing.Size(40, 20)
        Me.txtMax.TabIndex = 4
        Me.txtMax.Text = "100"
        Me.txtMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblCirclePoints
        '
        Me.lblCirclePoints.AutoSize = True
        Me.lblCirclePoints.Location = New System.Drawing.Point(34, 449)
        Me.lblCirclePoints.Name = "lblCirclePoints"
        Me.lblCirclePoints.Size = New System.Drawing.Size(92, 13)
        Me.lblCirclePoints.TabIndex = 7
        Me.lblCirclePoints.Text = "Nr. of circle points"
        '
        'grpProfile
        '
        Me.grpProfile.Controls.Add(Me.optLongitudinal)
        Me.grpProfile.Controls.Add(Me.optTransversal)
        Me.grpProfile.Location = New System.Drawing.Point(20, 29)
        Me.grpProfile.Name = "grpProfile"
        Me.grpProfile.Size = New System.Drawing.Size(183, 80)
        Me.grpProfile.TabIndex = 0
        Me.grpProfile.TabStop = False
        Me.grpProfile.Text = "Profile type"
        '
        'optLongitudinal
        '
        Me.optLongitudinal.AutoSize = True
        Me.optLongitudinal.Location = New System.Drawing.Point(35, 51)
        Me.optLongitudinal.Name = "optLongitudinal"
        Me.optLongitudinal.Size = New System.Drawing.Size(82, 17)
        Me.optLongitudinal.TabIndex = 1
        Me.optLongitudinal.Text = "Longitudinal"
        Me.optLongitudinal.UseVisualStyleBackColor = True
        '
        'optTransversal
        '
        Me.optTransversal.AutoSize = True
        Me.optTransversal.Checked = True
        Me.optTransversal.Location = New System.Drawing.Point(35, 28)
        Me.optTransversal.MaximumSize = New System.Drawing.Size(100, 100)
        Me.optTransversal.MinimumSize = New System.Drawing.Size(20, 20)
        Me.optTransversal.Name = "optTransversal"
        Me.optTransversal.Size = New System.Drawing.Size(78, 20)
        Me.optTransversal.TabIndex = 0
        Me.optTransversal.TabStop = True
        Me.optTransversal.Text = "Transverse"
        Me.optTransversal.UseVisualStyleBackColor = True
        '
        'lblVersion
        '
        Me.lblVersion.AutoSize = True
        Me.lblVersion.Location = New System.Drawing.Point(29, 658)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(88, 13)
        Me.lblVersion.TabIndex = 15
        Me.lblVersion.Text = "Vers. 2015-04-01"
        '
        'lblSeparator
        '
        Me.lblSeparator.AutoSize = True
        Me.lblSeparator.Location = New System.Drawing.Point(22, 549)
        Me.lblSeparator.Name = "lblSeparator"
        Me.lblSeparator.Size = New System.Drawing.Size(75, 13)
        Me.lblSeparator.TabIndex = 12
        Me.lblSeparator.Text = "CSV separator"
        '
        'cboSeparator
        '
        Me.cboSeparator.FormattingEnabled = True
        Me.cboSeparator.Location = New System.Drawing.Point(95, 546)
        Me.cboSeparator.Name = "cboSeparator"
        Me.cboSeparator.Size = New System.Drawing.Size(38, 21)
        Me.cboSeparator.TabIndex = 13
        '
        'frmProfiler
        '
        Me.Controls.Add(Me.cboSeparator)
        Me.Controls.Add(Me.lblSeparator)
        Me.Controls.Add(Me.lblVersion)
        Me.Controls.Add(Me.grpProfile)
        Me.Controls.Add(Me.lblCirclePoints)
        Me.Controls.Add(Me.grpSettings)
        Me.Controls.Add(Me.txtCirclePoints)
        Me.Controls.Add(Me.cmdBrowse)
        Me.Controls.Add(Me.txtOUTPUT)
        Me.Controls.Add(Me.cmdSubmit)
        Me.Controls.Add(Me.cboDEM)
        Me.Controls.Add(Me.cmdRefresh)
        Me.Controls.Add(Me.cboINPUT)
        Me.Controls.Add(Me.lblINPUT)
        Me.Controls.Add(Me.lblDEM)
        Me.Controls.Add(Me.lblOUTPUT)
        Me.Name = "frmProfiler"
        Me.Size = New System.Drawing.Size(224, 685)
        Me.grpSettings.ResumeLayout(False)
        Me.grpSettings.PerformLayout()
        Me.grpProfile.ResumeLayout(False)
        Me.grpProfile.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cboINPUT As System.Windows.Forms.ComboBox
    Friend WithEvents cmdRefresh As System.Windows.Forms.Button
    Friend WithEvents cboDEM As System.Windows.Forms.ComboBox
    Friend WithEvents cmdSubmit As System.Windows.Forms.Button
    Friend WithEvents txtOUTPUT As System.Windows.Forms.TextBox
    Friend WithEvents cmdBrowse As System.Windows.Forms.Button
    Friend WithEvents txtCirclePoints As System.Windows.Forms.TextBox
    Friend WithEvents lblINPUT As System.Windows.Forms.Label
    Friend WithEvents lblDEM As System.Windows.Forms.Label
    Friend WithEvents lblOUTPUT As System.Windows.Forms.Label
    Friend WithEvents grpSettings As System.Windows.Forms.GroupBox
    Friend WithEvents txtResolution As System.Windows.Forms.TextBox
    Friend WithEvents txtInterval As System.Windows.Forms.TextBox
    Friend WithEvents txtMin As System.Windows.Forms.TextBox
    Friend WithEvents txtMax As System.Windows.Forms.TextBox
    Friend WithEvents lblResolution As System.Windows.Forms.Label
    Friend WithEvents lblInterval As System.Windows.Forms.Label
    Friend WithEvents lblMax As System.Windows.Forms.Label
    Friend WithEvents lblMin As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblCirclePoints As System.Windows.Forms.Label
    Friend WithEvents grpProfile As System.Windows.Forms.GroupBox
    Friend WithEvents optLongitudinal As System.Windows.Forms.RadioButton
    Friend WithEvents optTransversal As System.Windows.Forms.RadioButton
    Friend WithEvents lblVersion As System.Windows.Forms.Label
    Friend WithEvents lblSeparator As System.Windows.Forms.Label
    Friend WithEvents cboSeparator As System.Windows.Forms.ComboBox

End Class
