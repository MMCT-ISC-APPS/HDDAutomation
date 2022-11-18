<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSetupLayout
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSetupLayout))
        Me.PicPanel = New System.Windows.Forms.PictureBox()
        Me.Menu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AddToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblModel = New System.Windows.Forms.Label()
        Me.txtPanelType = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblImagePath = New System.Windows.Forms.Label()
        Me.btnImage = New System.Windows.Forms.Button()
        Me.btnPreview = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.FileDi = New System.Windows.Forms.OpenFileDialog()
        Me.grpPanelInfo = New System.Windows.Forms.GroupBox()
        Me.btnOpen = New System.Windows.Forms.Button()
        Me.lbPCName = New System.Windows.Forms.Label()
        Me.txtModel = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtMiniSheet = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.grdView = New System.Windows.Forms.DataGridView()
        Me.Delete = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Edit = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtY = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtX = New System.Windows.Forms.TextBox()
        Me.txtPcs = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.PicPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Menu.SuspendLayout()
        Me.grpPanelInfo.SuspendLayout()
        CType(Me.grdView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Delete.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PicPanel
        '
        Me.PicPanel.ContextMenuStrip = Me.Menu
        Me.PicPanel.Location = New System.Drawing.Point(9, 12)
        Me.PicPanel.Name = "PicPanel"
        Me.PicPanel.Size = New System.Drawing.Size(755, 476)
        Me.PicPanel.TabIndex = 3
        Me.PicPanel.TabStop = False
        '
        'Menu
        '
        Me.Menu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddToolStripMenuItem})
        Me.Menu.Name = "Menu"
        Me.Menu.Size = New System.Drawing.Size(97, 26)
        Me.Menu.Text = "Add"
        '
        'AddToolStripMenuItem
        '
        Me.AddToolStripMenuItem.Name = "AddToolStripMenuItem"
        Me.AddToolStripMenuItem.Size = New System.Drawing.Size(96, 22)
        Me.AddToolStripMenuItem.Text = "Add"
        '
        'lblModel
        '
        Me.lblModel.AutoSize = True
        Me.lblModel.Font = New System.Drawing.Font("Verdana", 15.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblModel.Location = New System.Drawing.Point(20, 126)
        Me.lblModel.Name = "lblModel"
        Me.lblModel.Size = New System.Drawing.Size(141, 25)
        Me.lblModel.TabIndex = 54
        Me.lblModel.Text = "Panel Type"
        '
        'txtPanelType
        '
        Me.txtPanelType.Font = New System.Drawing.Font("Tahoma", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPanelType.Location = New System.Drawing.Point(27, 154)
        Me.txtPanelType.Name = "txtPanelType"
        Me.txtPanelType.Size = New System.Drawing.Size(263, 43)
        Me.txtPanelType.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Verdana", 15.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Maroon
        Me.Label5.Location = New System.Drawing.Point(122, 20)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(168, 25)
        Me.Label5.TabIndex = 55
        Me.Label5.Text = "Layout Setup"
        '
        'lblImagePath
        '
        Me.lblImagePath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblImagePath.Location = New System.Drawing.Point(33, 291)
        Me.lblImagePath.Name = "lblImagePath"
        Me.lblImagePath.Size = New System.Drawing.Size(215, 24)
        Me.lblImagePath.TabIndex = 56
        Me.lblImagePath.Text = "Image Path"
        '
        'btnImage
        '
        Me.btnImage.Location = New System.Drawing.Point(255, 291)
        Me.btnImage.Name = "btnImage"
        Me.btnImage.Size = New System.Drawing.Size(41, 29)
        Me.btnImage.TabIndex = 4
        Me.btnImage.Text = "..."
        Me.btnImage.UseVisualStyleBackColor = True
        '
        'btnPreview
        '
        Me.btnPreview.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPreview.Location = New System.Drawing.Point(15, 372)
        Me.btnPreview.Name = "btnPreview"
        Me.btnPreview.Size = New System.Drawing.Size(142, 32)
        Me.btnPreview.TabIndex = 5
        Me.btnPreview.Text = "Preview"
        Me.btnPreview.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Location = New System.Drawing.Point(174, 372)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(142, 32)
        Me.btnSave.TabIndex = 6
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'FileDi
        '
        Me.FileDi.FileName = "FileDi"
        '
        'grpPanelInfo
        '
        Me.grpPanelInfo.Controls.Add(Me.btnOpen)
        Me.grpPanelInfo.Controls.Add(Me.lbPCName)
        Me.grpPanelInfo.Controls.Add(Me.txtModel)
        Me.grpPanelInfo.Controls.Add(Me.Label4)
        Me.grpPanelInfo.Controls.Add(Me.txtMiniSheet)
        Me.grpPanelInfo.Controls.Add(Me.Label6)
        Me.grpPanelInfo.Controls.Add(Me.grdView)
        Me.grpPanelInfo.Controls.Add(Me.Label1)
        Me.grpPanelInfo.Controls.Add(Me.txtY)
        Me.grpPanelInfo.Controls.Add(Me.Label3)
        Me.grpPanelInfo.Controls.Add(Me.txtX)
        Me.grpPanelInfo.Controls.Add(Me.txtPcs)
        Me.grpPanelInfo.Controls.Add(Me.Label2)
        Me.grpPanelInfo.Controls.Add(Me.Label5)
        Me.grpPanelInfo.Controls.Add(Me.btnSave)
        Me.grpPanelInfo.Controls.Add(Me.PictureBox1)
        Me.grpPanelInfo.Controls.Add(Me.btnPreview)
        Me.grpPanelInfo.Controls.Add(Me.lblModel)
        Me.grpPanelInfo.Controls.Add(Me.btnImage)
        Me.grpPanelInfo.Controls.Add(Me.txtPanelType)
        Me.grpPanelInfo.Controls.Add(Me.lblImagePath)
        Me.grpPanelInfo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpPanelInfo.Location = New System.Drawing.Point(770, 3)
        Me.grpPanelInfo.Name = "grpPanelInfo"
        Me.grpPanelInfo.Size = New System.Drawing.Size(334, 650)
        Me.grpPanelInfo.TabIndex = 60
        Me.grpPanelInfo.TabStop = False
        '
        'btnOpen
        '
        Me.btnOpen.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOpen.Location = New System.Drawing.Point(15, 410)
        Me.btnOpen.Name = "btnOpen"
        Me.btnOpen.Size = New System.Drawing.Size(142, 32)
        Me.btnOpen.TabIndex = 72
        Me.btnOpen.Text = "Open"
        Me.btnOpen.UseVisualStyleBackColor = True
        '
        'lbPCName
        '
        Me.lbPCName.AutoSize = True
        Me.lbPCName.Font = New System.Drawing.Font("Verdana", 15.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbPCName.Location = New System.Drawing.Point(122, 60)
        Me.lbPCName.Name = "lbPCName"
        Me.lbPCName.Size = New System.Drawing.Size(110, 25)
        Me.lbPCName.TabIndex = 71
        Me.lbPCName.Text = "PCName"
        '
        'txtModel
        '
        Me.txtModel.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtModel.Location = New System.Drawing.Point(113, 259)
        Me.txtModel.Name = "txtModel"
        Me.txtModel.Size = New System.Drawing.Size(176, 22)
        Me.txtModel.TabIndex = 3
        Me.txtModel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(26, 261)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 16)
        Me.Label4.TabIndex = 69
        Me.Label4.Text = "Model :"
        '
        'txtMiniSheet
        '
        Me.txtMiniSheet.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMiniSheet.Location = New System.Drawing.Point(114, 231)
        Me.txtMiniSheet.Name = "txtMiniSheet"
        Me.txtMiniSheet.Size = New System.Drawing.Size(176, 22)
        Me.txtMiniSheet.TabIndex = 2
        Me.txtMiniSheet.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(27, 233)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(84, 16)
        Me.Label6.TabIndex = 67
        Me.Label6.Text = "Mini Sheet :"
        '
        'grdView
        '
        Me.grdView.BackgroundColor = System.Drawing.Color.DarkOrange
        Me.grdView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdView.ContextMenuStrip = Me.Delete
        Me.grdView.GridColor = System.Drawing.SystemColors.MenuHighlight
        Me.grdView.Location = New System.Drawing.Point(15, 445)
        Me.grdView.MultiSelect = False
        Me.grdView.Name = "grdView"
        Me.grdView.ReadOnly = True
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Gold
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdView.RowHeadersDefaultCellStyle = DataGridViewCellStyle1
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Gold
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        Me.grdView.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.grdView.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdView.Size = New System.Drawing.Size(308, 174)
        Me.grdView.TabIndex = 66
        '
        'Delete
        '
        Me.Delete.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Edit, Me.DeleteMenu})
        Me.Delete.Name = "Menu"
        Me.Delete.Size = New System.Drawing.Size(153, 70)
        Me.Delete.Text = "Add"
        '
        'Edit
        '
        Me.Edit.Name = "Edit"
        Me.Edit.Size = New System.Drawing.Size(152, 22)
        Me.Edit.Text = "Edit"
        '
        'DeleteMenu
        '
        Me.DeleteMenu.Name = "DeleteMenu"
        Me.DeleteMenu.Size = New System.Drawing.Size(152, 22)
        Me.DeleteMenu.Text = "Delete"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 15.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(154, 330)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(27, 25)
        Me.Label1.TabIndex = 65
        Me.Label1.Text = "Y"
        '
        'txtY
        '
        Me.txtY.Font = New System.Drawing.Font("Tahoma", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtY.Location = New System.Drawing.Point(190, 324)
        Me.txtY.Name = "txtY"
        Me.txtY.ReadOnly = True
        Me.txtY.Size = New System.Drawing.Size(80, 43)
        Me.txtY.TabIndex = 64
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 15.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(26, 331)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(28, 25)
        Me.Label3.TabIndex = 63
        Me.Label3.Text = "X"
        '
        'txtX
        '
        Me.txtX.Font = New System.Drawing.Font("Tahoma", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtX.Location = New System.Drawing.Point(62, 323)
        Me.txtX.Name = "txtX"
        Me.txtX.ReadOnly = True
        Me.txtX.Size = New System.Drawing.Size(80, 43)
        Me.txtX.TabIndex = 62
        '
        'txtPcs
        '
        Me.txtPcs.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPcs.Location = New System.Drawing.Point(114, 203)
        Me.txtPcs.Name = "txtPcs"
        Me.txtPcs.Size = New System.Drawing.Size(176, 22)
        Me.txtPcs.TabIndex = 1
        Me.txtPcs.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(27, 205)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(85, 16)
        Me.Label2.TabIndex = 60
        Me.Label2.Text = "Pcs/Sheet :"
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
        'frmSetupLayout
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Goldenrod
        Me.ClientSize = New System.Drawing.Size(1112, 665)
        Me.Controls.Add(Me.grpPanelInfo)
        Me.Controls.Add(Me.PicPanel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmSetupLayout"
        Me.Text = "Layout"
        CType(Me.PicPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Menu.ResumeLayout(False)
        Me.grpPanelInfo.ResumeLayout(False)
        Me.grpPanelInfo.PerformLayout()
        CType(Me.grdView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Delete.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PicPanel As PictureBox
    Friend WithEvents lblModel As Label
    Friend WithEvents txtPanelType As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents lblImagePath As Label
    Friend WithEvents btnImage As Button
    Friend WithEvents btnPreview As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents FileDi As OpenFileDialog
    Friend WithEvents grpPanelInfo As GroupBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents txtPcs As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Menu As ContextMenuStrip
    Friend WithEvents AddToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Label1 As Label
    Friend WithEvents txtY As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtX As TextBox
    Friend WithEvents grdView As DataGridView
    Friend WithEvents Delete As ContextMenuStrip
    Friend WithEvents Edit As ToolStripMenuItem
    Friend WithEvents DeleteMenu As ToolStripMenuItem
    Friend WithEvents txtMiniSheet As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtModel As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents lbPCName As Label
    Friend WithEvents btnOpen As Button
End Class
