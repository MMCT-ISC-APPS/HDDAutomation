Imports MMCTWIPDLL

Public Class frmSelectJob



    Private iJobQty As Integer = 0
    Private sEn As String


    Private iPanelPerSheet As Integer = 0
    Private bOk As Boolean = False
    Private sJobName As String
    Private sModel As String
    Private iMode As Integer

    Public Property Mode As Integer
        Get
            Return iMode
        End Get
        Set(value As Integer)
            iMode = value
        End Set
    End Property

    Public Property JobName As String
        Get
            Return sJobName
        End Get
        Set(value As String)
            sJobName = value
        End Set
    End Property

    Public Property Model As String
        Get
            Return sModel
        End Get
        Set(value As String)
            sModel = value
        End Set
    End Property

    Public Property EmployeeNo As String
        Get
            Return sEn
        End Get
        Set(value As String)
            sEn = value
        End Set
    End Property

    Public Property Ok As Boolean
        Get
            Return bOk
        End Get
        Set(value As Boolean)
            bOk = value
        End Set
    End Property

    Public Property PanelPerSheetQty As Integer
        Get
            Return iPanelPerSheet
        End Get
        Set(value As Integer)
            iPanelPerSheet = value
        End Set
    End Property

    Public Property JobQty As Integer
        Get
            Return iJobQty
        End Get
        Set(value As Integer)
            iJobQty = value
        End Set
    End Property

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub frmSelectJob_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cboMode.SelectedIndex = 0
        txtJobno.Focus()
    End Sub

    Private Sub txtJobno_KeyDown(sender As Object, e As KeyEventArgs) Handles txtJobno.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                If txtJobno.Text = "" Then
                    Throw New Exception("ยังไม่ได้ใส่เบอร์ job")
                End If

                'Dim Arr() As String = objFP.IsValidJob(txtJobno.Text.Trim())

                'txtModel.Text = Arr(1)
                'iJobQty = Arr(2)
                'iPanelPerSheet = Arr(4)

                txtEn.Focus()

            End If

        Catch ex As Exception
            MsgBox("Err:" & ex.Message)
        End Try
    End Sub

    Private Sub btnConfirm_Click(sender As Object, e As EventArgs) Handles btnConfirm.Click
        bOk = True
        sJobName = txtJobno.Text
        sEn = txtEn.Text
        sModel = txtModel.Text
        iMode = cboMode.SelectedIndex
        Me.Close()
    End Sub

    Private Sub txtEn_KeyDown(sender As Object, e As KeyEventArgs) Handles txtEn.KeyDown
        If e.KeyCode = Keys.Enter Then
            Ok = True
            sJobName = txtJobno.Text
            sEn = txtEn.Text
            sModel = txtModel.Text
            iMode = cboMode.SelectedIndex
            Me.Close()
        End If
    End Sub

    Private Sub txtJobno_TextChanged(sender As Object, e As EventArgs) Handles txtJobno.TextChanged

    End Sub
End Class