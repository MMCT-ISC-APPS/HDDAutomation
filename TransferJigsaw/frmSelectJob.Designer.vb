<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSelectJob
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
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtJobno = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtEn = New System.Windows.Forms.TextBox()
        Me.lblJobName = New System.Windows.Forms.Label()
        Me.btnConfirm = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.txtModel = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboMode = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Verdana", 15.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Maroon
        Me.Label5.Location = New System.Drawing.Point(22, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(233, 25)
        Me.Label5.TabIndex = 41
        Me.Label5.Text = "Select Job Number"
        '
        'txtJobno
        '
        Me.txtJobno.Font = New System.Drawing.Font("Tahoma", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtJobno.Location = New System.Drawing.Point(27, 72)
        Me.txtJobno.Name = "txtJobno"
        Me.txtJobno.Size = New System.Drawing.Size(313, 43)
        Me.txtJobno.TabIndex = 43
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(24, 49)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(252, 16)
        Me.Label1.TabIndex = 42
        Me.Label1.Text = "Please enter job number to process..."
        '
        'txtEn
        '
        Me.txtEn.Font = New System.Drawing.Font("Tahoma", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEn.Location = New System.Drawing.Point(124, 213)
        Me.txtEn.Name = "txtEn"
        Me.txtEn.Size = New System.Drawing.Size(216, 43)
        Me.txtEn.TabIndex = 44
        '
        'lblJobName
        '
        Me.lblJobName.AutoSize = True
        Me.lblJobName.Font = New System.Drawing.Font("Verdana", 15.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblJobName.Location = New System.Drawing.Point(36, 224)
        Me.lblJobName.Name = "lblJobName"
        Me.lblJobName.Size = New System.Drawing.Size(44, 25)
        Me.lblJobName.TabIndex = 51
        Me.lblJobName.Text = "EN"
        '
        'btnConfirm
        '
        Me.btnConfirm.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConfirm.Location = New System.Drawing.Point(86, 269)
        Me.btnConfirm.Name = "btnConfirm"
        Me.btnConfirm.Size = New System.Drawing.Size(142, 32)
        Me.btnConfirm.TabIndex = 53
        Me.btnConfirm.Text = "Confirm"
        Me.btnConfirm.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Location = New System.Drawing.Point(241, 269)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(142, 32)
        Me.btnClose.TabIndex = 54
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'txtModel
        '
        Me.txtModel.Font = New System.Drawing.Font("Tahoma", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtModel.Location = New System.Drawing.Point(125, 123)
        Me.txtModel.Name = "txtModel"
        Me.txtModel.ReadOnly = True
        Me.txtModel.Size = New System.Drawing.Size(216, 43)
        Me.txtModel.TabIndex = 55
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 15.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(37, 134)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 25)
        Me.Label2.TabIndex = 56
        Me.Label2.Text = "Model"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 15.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(36, 177)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(75, 25)
        Me.Label3.TabIndex = 57
        Me.Label3.Text = "Mode"
        '
        'cboMode
        '
        Me.cboMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMode.Font = New System.Drawing.Font("Verdana", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMode.FormattingEnabled = True
        Me.cboMode.Items.AddRange(New Object() {"X3 (<= 3)", "X4 (>=4)", "None"})
        Me.cboMode.Location = New System.Drawing.Point(125, 172)
        Me.cboMode.Name = "cboMode"
        Me.cboMode.Size = New System.Drawing.Size(216, 33)
        Me.cboMode.TabIndex = 58
        '
        'frmSelectJob
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Goldenrod
        Me.ClientSize = New System.Drawing.Size(395, 327)
        Me.ControlBox = False
        Me.Controls.Add(Me.cboMode)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtModel)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnConfirm)
        Me.Controls.Add(Me.lblJobName)
        Me.Controls.Add(Me.txtEn)
        Me.Controls.Add(Me.txtJobno)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label5)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSelectJob"
        Me.Text = "Select Job"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label5 As Label
    Friend WithEvents txtJobno As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtEn As TextBox
    Friend WithEvents lblJobName As Label
    Friend WithEvents btnConfirm As Button
    Friend WithEvents btnClose As Button
    Friend WithEvents txtModel As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents cboMode As ComboBox
End Class
