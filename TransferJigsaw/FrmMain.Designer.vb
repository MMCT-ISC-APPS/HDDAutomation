<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMain))
        Me.PicPanel = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtPanel = New System.Windows.Forms.TextBox()
        Me.grpPanelInfo = New System.Windows.Forms.GroupBox()
        Me.txtJigsaw = New System.Windows.Forms.TextBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.lblRemoveSts = New System.Windows.Forms.Label()
        Me.SkipXray = New System.Windows.Forms.CheckBox()
        Me.SkipAOI = New System.Windows.Forms.CheckBox()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.LbXray = New System.Windows.Forms.Label()
        Me.LbAOI = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblModel = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblJobname = New System.Windows.Forms.Label()
        Me.lblPanelNo = New System.Windows.Forms.Label()
        Me.btnCompleted = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lbPCName = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.pDefect = New System.Windows.Forms.Panel()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtCurrDefect = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtCurrSeq = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.grpDefect = New System.Windows.Forms.GroupBox()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.txtXrayDate = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtXrayResult = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtTestDateAOI = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtAOIResult = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtSeq = New System.Windows.Forms.TextBox()
        Me.lbFailQty = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.tmrMonitor = New System.Windows.Forms.Timer(Me.components)
        Me.bgSVR = New System.ComponentModel.BackgroundWorker()
        CType(Me.PicPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpPanelInfo.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pDefect.SuspendLayout()
        Me.grpDefect.SuspendLayout()
        Me.SuspendLayout()
        '
        'PicPanel
        '
        Me.PicPanel.Location = New System.Drawing.Point(9, 19)
        Me.PicPanel.Name = "PicPanel"
        Me.PicPanel.Size = New System.Drawing.Size(671, 476)
        Me.PicPanel.TabIndex = 2
        Me.PicPanel.TabStop = False
        Me.PicPanel.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(27, 252)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(267, 16)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Please enter panel number to process..."
        '
        'txtPanel
        '
        Me.txtPanel.Font = New System.Drawing.Font("Tahoma", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPanel.Location = New System.Drawing.Point(26, 275)
        Me.txtPanel.Name = "txtPanel"
        Me.txtPanel.Size = New System.Drawing.Size(296, 43)
        Me.txtPanel.TabIndex = 9
        '
        'grpPanelInfo
        '
        Me.grpPanelInfo.Controls.Add(Me.txtJigsaw)
        Me.grpPanelInfo.Controls.Add(Me.Button3)
        Me.grpPanelInfo.Controls.Add(Me.lblRemoveSts)
        Me.grpPanelInfo.Controls.Add(Me.SkipXray)
        Me.grpPanelInfo.Controls.Add(Me.SkipAOI)
        Me.grpPanelInfo.Controls.Add(Me.Button5)
        Me.grpPanelInfo.Controls.Add(Me.Button2)
        Me.grpPanelInfo.Controls.Add(Me.LbXray)
        Me.grpPanelInfo.Controls.Add(Me.LbAOI)
        Me.grpPanelInfo.Controls.Add(Me.Label8)
        Me.grpPanelInfo.Controls.Add(Me.lblModel)
        Me.grpPanelInfo.Controls.Add(Me.Label6)
        Me.grpPanelInfo.Controls.Add(Me.Label4)
        Me.grpPanelInfo.Controls.Add(Me.Label3)
        Me.grpPanelInfo.Controls.Add(Me.Label2)
        Me.grpPanelInfo.Controls.Add(Me.lblJobname)
        Me.grpPanelInfo.Controls.Add(Me.lblPanelNo)
        Me.grpPanelInfo.Controls.Add(Me.btnCompleted)
        Me.grpPanelInfo.Controls.Add(Me.Label5)
        Me.grpPanelInfo.Controls.Add(Me.lbPCName)
        Me.grpPanelInfo.Controls.Add(Me.PictureBox1)
        Me.grpPanelInfo.Controls.Add(Me.txtPanel)
        Me.grpPanelInfo.Controls.Add(Me.Label1)
        Me.grpPanelInfo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpPanelInfo.Location = New System.Drawing.Point(696, 8)
        Me.grpPanelInfo.Name = "grpPanelInfo"
        Me.grpPanelInfo.Size = New System.Drawing.Size(408, 678)
        Me.grpPanelInfo.TabIndex = 11
        Me.grpPanelInfo.TabStop = False
        '
        'txtJigsaw
        '
        Me.txtJigsaw.Font = New System.Drawing.Font("Tahoma", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtJigsaw.Location = New System.Drawing.Point(27, 330)
        Me.txtJigsaw.Name = "txtJigsaw"
        Me.txtJigsaw.Size = New System.Drawing.Size(296, 43)
        Me.txtJigsaw.TabIndex = 102
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(78, 87)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(46, 42)
        Me.Button3.TabIndex = 101
        Me.Button3.Text = "Button3"
        Me.Button3.UseVisualStyleBackColor = True
        Me.Button3.Visible = False
        '
        'lblRemoveSts
        '
        Me.lblRemoveSts.AutoSize = True
        Me.lblRemoveSts.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRemoveSts.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblRemoveSts.Location = New System.Drawing.Point(32, 607)
        Me.lblRemoveSts.Name = "lblRemoveSts"
        Me.lblRemoveSts.Size = New System.Drawing.Size(80, 23)
        Me.lblRemoveSts.TabIndex = 100
        Me.lblRemoveSts.Text = "Status"
        '
        'SkipXray
        '
        Me.SkipXray.AutoSize = True
        Me.SkipXray.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SkipXray.ForeColor = System.Drawing.Color.DeepPink
        Me.SkipXray.Location = New System.Drawing.Point(190, 497)
        Me.SkipXray.Name = "SkipXray"
        Me.SkipXray.Size = New System.Drawing.Size(141, 23)
        Me.SkipXray.TabIndex = 99
        Me.SkipXray.Text = "By Pass XRAY"
        Me.SkipXray.UseVisualStyleBackColor = True
        '
        'SkipAOI
        '
        Me.SkipAOI.AutoSize = True
        Me.SkipAOI.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SkipAOI.ForeColor = System.Drawing.Color.DarkSlateBlue
        Me.SkipAOI.Location = New System.Drawing.Point(24, 497)
        Me.SkipAOI.Name = "SkipAOI"
        Me.SkipAOI.Size = New System.Drawing.Size(126, 23)
        Me.SkipAOI.TabIndex = 98
        Me.SkipAOI.Text = "By Pass AOI"
        Me.SkipAOI.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(30, 78)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(46, 42)
        Me.Button5.TabIndex = 48
        Me.Button5.Text = "Button5"
        Me.Button5.UseVisualStyleBackColor = True
        Me.Button5.Visible = False
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(0, 53)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(46, 42)
        Me.Button2.TabIndex = 47
        Me.Button2.Text = "Button2"
        Me.Button2.UseVisualStyleBackColor = True
        Me.Button2.Visible = False
        '
        'LbXray
        '
        Me.LbXray.AutoSize = True
        Me.LbXray.Font = New System.Drawing.Font("Verdana", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LbXray.Location = New System.Drawing.Point(23, 572)
        Me.LbXray.Name = "LbXray"
        Me.LbXray.Size = New System.Drawing.Size(118, 18)
        Me.LbXray.TabIndex = 97
        Me.LbXray.Text = "XRAY TIME :"
        '
        'LbAOI
        '
        Me.LbAOI.AutoSize = True
        Me.LbAOI.Font = New System.Drawing.Font("Verdana", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LbAOI.Location = New System.Drawing.Point(23, 543)
        Me.LbAOI.Name = "LbAOI"
        Me.LbAOI.Size = New System.Drawing.Size(101, 18)
        Me.LbAOI.TabIndex = 96
        Me.LbAOI.Text = "AOI Time :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.White
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(62, 461)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(125, 16)
        Me.Label8.TabIndex = 95
        Me.Label8.Text = "Skip AOI and Xray"
        '
        'lblModel
        '
        Me.lblModel.AutoSize = True
        Me.lblModel.Font = New System.Drawing.Font("Verdana", 15.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblModel.Location = New System.Drawing.Point(19, 207)
        Me.lblModel.Name = "lblModel"
        Me.lblModel.Size = New System.Drawing.Size(90, 25)
        Me.lblModel.TabIndex = 94
        Me.lblModel.Text = "Model:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Green
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(241, 433)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(42, 16)
        Me.Label6.TabIndex = 93
        Me.Label6.Text = "PASS"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Red
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(201, 433)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 16)
        Me.Label4.TabIndex = 92
        Me.Label4.Text = "Both"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Red
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(132, 433)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 16)
        Me.Label3.TabIndex = 91
        Me.Label3.Text = "Fail Xray"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Yellow
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(62, 433)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 16)
        Me.Label2.TabIndex = 90
        Me.Label2.Text = "FAIL AOI"
        '
        'lblJobname
        '
        Me.lblJobname.AutoSize = True
        Me.lblJobname.Font = New System.Drawing.Font("Verdana", 15.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblJobname.Location = New System.Drawing.Point(19, 171)
        Me.lblJobname.Name = "lblJobname"
        Me.lblJobname.Size = New System.Drawing.Size(129, 25)
        Me.lblJobname.TabIndex = 89
        Me.lblJobname.Text = "JobName:"
        '
        'lblPanelNo
        '
        Me.lblPanelNo.AutoSize = True
        Me.lblPanelNo.Font = New System.Drawing.Font("Verdana", 15.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPanelNo.Location = New System.Drawing.Point(23, 132)
        Me.lblPanelNo.Name = "lblPanelNo"
        Me.lblPanelNo.Size = New System.Drawing.Size(143, 25)
        Me.lblPanelNo.TabIndex = 88
        Me.lblPanelNo.Text = "Fixture No:"
        '
        'btnCompleted
        '
        Me.btnCompleted.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCompleted.Location = New System.Drawing.Point(32, 388)
        Me.btnCompleted.Name = "btnCompleted"
        Me.btnCompleted.Size = New System.Drawing.Size(142, 32)
        Me.btnCompleted.TabIndex = 53
        Me.btnCompleted.Text = "Completed"
        Me.btnCompleted.UseVisualStyleBackColor = True
        Me.btnCompleted.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Verdana", 15.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Maroon
        Me.Label5.Location = New System.Drawing.Point(109, 35)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(258, 25)
        Me.Label5.TabIndex = 40
        Me.Label5.Text = "HHG Jigsaw Transfer"
        '
        'lbPCName
        '
        Me.lbPCName.AutoSize = True
        Me.lbPCName.Font = New System.Drawing.Font("Verdana", 15.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbPCName.Location = New System.Drawing.Point(109, 70)
        Me.lbPCName.Name = "lbPCName"
        Me.lbPCName.Size = New System.Drawing.Size(110, 25)
        Me.lbPCName.TabIndex = 39
        Me.lbPCName.Text = "PCName"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(11, 20)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(92, 91)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 38
        Me.PictureBox1.TabStop = False
        '
        'pDefect
        '
        Me.pDefect.AutoScroll = True
        Me.pDefect.Controls.Add(Me.Label15)
        Me.pDefect.Controls.Add(Me.txtCurrDefect)
        Me.pDefect.Controls.Add(Me.Label16)
        Me.pDefect.Controls.Add(Me.txtCurrSeq)
        Me.pDefect.Controls.Add(Me.Label17)
        Me.pDefect.Location = New System.Drawing.Point(770, 18)
        Me.pDefect.Name = "pDefect"
        Me.pDefect.Size = New System.Drawing.Size(338, 585)
        Me.pDefect.TabIndex = 44
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Verdana", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label15.Location = New System.Drawing.Point(25, 94)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(205, 16)
        Me.Label15.TabIndex = 48
        Me.Label15.Text = "Please select defect code..."
        '
        'txtCurrDefect
        '
        Me.txtCurrDefect.BackColor = System.Drawing.Color.Maroon
        Me.txtCurrDefect.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCurrDefect.Font = New System.Drawing.Font("Tahoma", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCurrDefect.ForeColor = System.Drawing.Color.White
        Me.txtCurrDefect.Location = New System.Drawing.Point(191, 48)
        Me.txtCurrDefect.Name = "txtCurrDefect"
        Me.txtCurrDefect.Size = New System.Drawing.Size(126, 43)
        Me.txtCurrDefect.TabIndex = 52
        Me.txtCurrDefect.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Verdana", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label16.Location = New System.Drawing.Point(186, 16)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(101, 16)
        Me.Label16.TabIndex = 51
        Me.Label16.Text = "Defect Code:"
        '
        'txtCurrSeq
        '
        Me.txtCurrSeq.BackColor = System.Drawing.Color.Teal
        Me.txtCurrSeq.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCurrSeq.Font = New System.Drawing.Font("Tahoma", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCurrSeq.ForeColor = System.Drawing.Color.White
        Me.txtCurrSeq.Location = New System.Drawing.Point(30, 48)
        Me.txtCurrSeq.Name = "txtCurrSeq"
        Me.txtCurrSeq.Size = New System.Drawing.Size(126, 43)
        Me.txtCurrSeq.TabIndex = 50
        Me.txtCurrSeq.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Verdana", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label17.Location = New System.Drawing.Point(25, 16)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(103, 16)
        Me.Label17.TabIndex = 49
        Me.Label17.Text = "Sequence ID:"
        '
        'grpDefect
        '
        Me.grpDefect.Controls.Add(Me.btnClose)
        Me.grpDefect.Controls.Add(Me.txtXrayDate)
        Me.grpDefect.Controls.Add(Me.Label9)
        Me.grpDefect.Controls.Add(Me.txtXrayResult)
        Me.grpDefect.Controls.Add(Me.Label11)
        Me.grpDefect.Controls.Add(Me.txtTestDateAOI)
        Me.grpDefect.Controls.Add(Me.Label7)
        Me.grpDefect.Controls.Add(Me.txtAOIResult)
        Me.grpDefect.Controls.Add(Me.Label10)
        Me.grpDefect.Controls.Add(Me.txtSeq)
        Me.grpDefect.Controls.Add(Me.lbFailQty)
        Me.grpDefect.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpDefect.Location = New System.Drawing.Point(752, 651)
        Me.grpDefect.Name = "grpDefect"
        Me.grpDefect.Size = New System.Drawing.Size(334, 447)
        Me.grpDefect.TabIndex = 45
        Me.grpDefect.TabStop = False
        '
        'btnClose
        '
        Me.btnClose.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Location = New System.Drawing.Point(185, 402)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(142, 32)
        Me.btnClose.TabIndex = 55
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'txtXrayDate
        '
        Me.txtXrayDate.BackColor = System.Drawing.Color.Teal
        Me.txtXrayDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtXrayDate.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtXrayDate.ForeColor = System.Drawing.Color.White
        Me.txtXrayDate.Location = New System.Drawing.Point(21, 338)
        Me.txtXrayDate.Name = "txtXrayDate"
        Me.txtXrayDate.ReadOnly = True
        Me.txtXrayDate.Size = New System.Drawing.Size(296, 33)
        Me.txtXrayDate.TabIndex = 54
        Me.txtXrayDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Verdana", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label9.Location = New System.Drawing.Point(22, 314)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(86, 16)
        Me.Label9.TabIndex = 53
        Me.Label9.Text = "Xray Date:"
        '
        'txtXrayResult
        '
        Me.txtXrayResult.BackColor = System.Drawing.Color.Teal
        Me.txtXrayResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtXrayResult.Font = New System.Drawing.Font("Tahoma", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtXrayResult.ForeColor = System.Drawing.Color.White
        Me.txtXrayResult.Location = New System.Drawing.Point(22, 266)
        Me.txtXrayResult.Name = "txtXrayResult"
        Me.txtXrayResult.ReadOnly = True
        Me.txtXrayResult.Size = New System.Drawing.Size(296, 43)
        Me.txtXrayResult.TabIndex = 52
        Me.txtXrayResult.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Verdana", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label11.Location = New System.Drawing.Point(23, 246)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(97, 16)
        Me.Label11.TabIndex = 51
        Me.Label11.Text = "Xray Result:"
        '
        'txtTestDateAOI
        '
        Me.txtTestDateAOI.BackColor = System.Drawing.Color.Teal
        Me.txtTestDateAOI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTestDateAOI.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTestDateAOI.ForeColor = System.Drawing.Color.White
        Me.txtTestDateAOI.Location = New System.Drawing.Point(21, 197)
        Me.txtTestDateAOI.Name = "txtTestDateAOI"
        Me.txtTestDateAOI.ReadOnly = True
        Me.txtTestDateAOI.Size = New System.Drawing.Size(293, 33)
        Me.txtTestDateAOI.TabIndex = 50
        Me.txtTestDateAOI.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Verdana", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label7.Location = New System.Drawing.Point(19, 171)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(78, 16)
        Me.Label7.TabIndex = 49
        Me.Label7.Text = "AOI Date:"
        '
        'txtAOIResult
        '
        Me.txtAOIResult.BackColor = System.Drawing.Color.Teal
        Me.txtAOIResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAOIResult.Font = New System.Drawing.Font("Tahoma", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAOIResult.ForeColor = System.Drawing.Color.White
        Me.txtAOIResult.Location = New System.Drawing.Point(19, 124)
        Me.txtAOIResult.Name = "txtAOIResult"
        Me.txtAOIResult.ReadOnly = True
        Me.txtAOIResult.Size = New System.Drawing.Size(298, 43)
        Me.txtAOIResult.TabIndex = 46
        Me.txtAOIResult.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Verdana", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label10.Location = New System.Drawing.Point(14, 101)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(89, 16)
        Me.Label10.TabIndex = 45
        Me.Label10.Text = "AOI Result:"
        '
        'txtSeq
        '
        Me.txtSeq.BackColor = System.Drawing.Color.Teal
        Me.txtSeq.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSeq.Font = New System.Drawing.Font("Tahoma", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSeq.ForeColor = System.Drawing.Color.White
        Me.txtSeq.Location = New System.Drawing.Point(19, 51)
        Me.txtSeq.Name = "txtSeq"
        Me.txtSeq.Size = New System.Drawing.Size(126, 43)
        Me.txtSeq.TabIndex = 44
        Me.txtSeq.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lbFailQty
        '
        Me.lbFailQty.AutoSize = True
        Me.lbFailQty.Font = New System.Drawing.Font("Verdana", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbFailQty.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.lbFailQty.Location = New System.Drawing.Point(14, 19)
        Me.lbFailQty.Name = "lbFailQty"
        Me.lbFailQty.Size = New System.Drawing.Size(103, 16)
        Me.lbFailQty.TabIndex = 43
        Me.lbFailQty.Text = "Sequence ID:"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(682, 7)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(46, 42)
        Me.Button1.TabIndex = 46
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'tmrMonitor
        '
        '
        'bgSVR
        '
        Me.bgSVR.WorkerReportsProgress = True
        Me.bgSVR.WorkerSupportsCancellation = True
        '
        'FrmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightCyan
        Me.ClientSize = New System.Drawing.Size(1020, 681)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.grpDefect)
        Me.Controls.Add(Me.grpPanelInfo)
        Me.Controls.Add(Me.pDefect)
        Me.Controls.Add(Me.PicPanel)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmMain"
        Me.Text = "HHG Transfer Jigsaw V"
        Me.TransparencyKey = System.Drawing.Color.Gold
        CType(Me.PicPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpPanelInfo.ResumeLayout(False)
        Me.grpPanelInfo.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pDefect.ResumeLayout(False)
        Me.pDefect.PerformLayout()
        Me.grpDefect.ResumeLayout(False)
        Me.grpDefect.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PicPanel As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtPanel As System.Windows.Forms.TextBox
    Friend WithEvents grpPanelInfo As System.Windows.Forms.GroupBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents lbPCName As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents pDefect As Panel
    Friend WithEvents Label15 As Label
    Friend WithEvents txtCurrDefect As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents txtCurrSeq As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents btnCompleted As Button
    Friend WithEvents lblPanelNo As Label
    Friend WithEvents lblJobname As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents grpDefect As GroupBox
    Friend WithEvents txtXrayDate As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtXrayResult As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents txtTestDateAOI As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtAOIResult As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents txtSeq As TextBox
    Friend WithEvents lbFailQty As Label
    Friend WithEvents lblModel As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents btnClose As Button
    Friend WithEvents LbXray As Label
    Friend WithEvents LbAOI As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents SkipXray As CheckBox
    Friend WithEvents SkipAOI As CheckBox
    Friend WithEvents lblRemoveSts As Label
    Friend WithEvents Button3 As Button
    Friend WithEvents txtJigsaw As TextBox
    Private WithEvents tmrMonitor As Timer
    Public WithEvents bgSVR As System.ComponentModel.BackgroundWorker
End Class
