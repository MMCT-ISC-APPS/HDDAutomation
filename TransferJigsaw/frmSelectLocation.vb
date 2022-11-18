Public Class frmSelectLocation

    Private iX As Integer
    Private iY As Integer
    Private bOk As Boolean
    Private iMaxPcs As Integer
    Private iBlockNo As Integer

    Private dsTmp As DataTable

    Public Property DataBuffer() As DataTable
        Get
            Return dsTmp
        End Get
        Set(ByVal value As DataTable)
            dsTmp = value
        End Set
    End Property
    Public Property BlockNo() As Integer
        Get
            Return iBlockNo
        End Get
        Set(ByVal value As Integer)
            iBlockNo = value
        End Set
    End Property

    Public Property MaxPcs() As Integer
        Get
            Return iMaxPcs
        End Get
        Set(ByVal value As Integer)
            iMaxPcs = value
        End Set
    End Property

    Public Property Ok() As Boolean
        Get
            Return bOk
        End Get
        Set(ByVal value As Boolean)
            bOk = value
        End Set
    End Property

    Public Property PixelY() As Integer
        Get
            Return iY
        End Get
        Set(ByVal value As Integer)
            iY = value
        End Set
    End Property


    Public Property PixelX() As Integer
        Get
            Return iX
        End Get
        Set(ByVal value As Integer)
            iX = value
        End Set
    End Property

    Private Sub frmSelectLocation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim iCount As Integer = 0

        Try
            txtX.Text = iX
            txtY.Text = iY
            cboBlock.Items.Clear()

            For iCount = 0 To dsTmp.Rows.Count - 1
                cboBlock.Items.Add(iCount + 1)
            Next

            cboBlock.SelectedIndex = 0

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        Dim iCount As Integer = 0
        Dim dsRow As DataRow = Nothing

        For iCount = 0 To dsTmp.Rows.Count - 1
            dsRow = dsTmp.Rows(iCount)
            If cboBlock.SelectedItem = dsRow.Item("blockno") Then
                dsRow(1) = iX
                dsRow(2) = iY
                Exit For
            End If
        Next

        bOk = True
        iBlockNo = cboBlock.SelectedItem
        Me.Close()

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

End Class