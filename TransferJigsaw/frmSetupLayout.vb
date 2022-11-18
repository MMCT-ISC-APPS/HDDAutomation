Imports MMCTWIPDLL
Imports MachineDLL.Entities

Public Class frmSetupLayout
    Private iLayoutX As Integer
    Private iLayoutY As Integer
    Private dsData As DataTable
    Private objPanel As PanelInfoM
    'Private objTraceability As FPTraceability

    Private Sub btnImage_Click(sender As Object, e As EventArgs) Handles btnImage.Click
        If FileDi.ShowDialog() = DialogResult.OK Then
            lblImagePath.Text = FileDi.FileName
        End If
    End Sub

    Private Sub btnPreview_Click(sender As Object, e As EventArgs) Handles btnPreview.Click
        Try
            If txtPanelType.Text = "" Then
                Throw New Exception("ไม่สามารถโหลดรูปได้เนื่องจากยังไม่ได้ใส่ Panel Type")
            End If
            PicPanel.Image = Image.FromFile(lblImagePath.Text)
            objPanel.ImagePanel = Image.FromFile(lblImagePath.Text)
            objPanel.PanelType = txtPanelType.Text
            PicPanel.Image = objPanel.ImagePanel
            PicPanel.Width = Me.Width - grpPanelInfo.Width - 50
            PicPanel.Height = Me.Height - PicPanel.Top - 50
            PicPanel.SizeMode = PictureBoxSizeMode.StretchImage

        Catch ex As Exception
            MsgBox("Error:" & ex.Message)
        End Try
    End Sub

    Private Sub PicPanel_MouseClick(sender As Object, e As MouseEventArgs) Handles PicPanel.MouseClick
        If e.Button = MouseButtons.Left Then
            iLayoutX = e.Location.X
            iLayoutY = e.Location.Y
            txtX.Text = iLayoutX
            txtY.Text = iLayoutY
        End If
    End Sub

    Private Sub AddToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddToolStripMenuItem.Click
        Dim frmSelect As New frmSelectLocation
        Dim dsRow As DataRow
        Dim iCount As Integer
        Dim iMax As Integer
        Dim Label As Label

        Try
            If txtPcs.Text <> "" Then
                If iLayoutX = 0 Then
                    Throw New Exception("ยังไม่ได้เลือกตำแหน่งที่จะวาง")
                End If

                If iLayoutY = 0 Then
                    Throw New Exception("ยังไม่ได้เลือกตำแหน่งที่จะวาง")
                End If

                frmSelect.PixelX = iLayoutX
                frmSelect.PixelY = iLayoutY
                frmSelect.MaxPcs = txtPcs.Text

                If dsData.Rows.Count = 0 Then
                    iMax = txtPcs.Text
                    For iCount = 0 To iMax - 1
                        dsRow = dsData.NewRow
                        dsRow(0) = iCount + 1
                        dsData.Rows.Add(dsRow)
                        dsRow = Nothing
                    Next
                End If

                frmSelect.DataBuffer = dsData

                frmSelect.ShowDialog()

                If frmSelect.Ok = True Then

                    If ExisingLabelControl(frmSelect.BlockNo) = False Then
                        Label = New Label()
                        Label.Location = New Point(frmSelect.PixelX, frmSelect.PixelY)
                        Label.Size = New Size(40, 40)
                        Label.ForeColor = Color.White
                        Label.BackColor = Color.Green

                        Label.Text = frmSelect.BlockNo

                        AddHandler Label.Click, AddressOf myClickHandler

                        PicPanel.Controls.Add(Label)

                        iLayoutX = 0 : iLayoutY = 0

                    End If

                    grdView.DataSource = dsData
                    grdView.Refresh()

                End If
            Else
                Throw New Exception("ยังไม่ได้ใส่จำนวน Panel Per Sheet")
            End If
        Catch ex As Exception
            MsgBox("Error:" & ex.Message)
        End Try
    End Sub

    Private Function ExisingLabelControl(ByVal sText As String) As Boolean
        Dim Label As Label
        Dim bHave As Boolean

        bHave = False
        For Each Label In PicPanel.Controls
            If Label.Text = sText Then
                bHave = True
                Exit For
            Else
                bHave = False
            End If
        Next

        Return bHave

    End Function
    Private Sub myClickHandler(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim clickedLabel As Label = DirectCast(sender, Label)

        Try

        Catch ex As Exception

        End Try
    End Sub
    Private Sub frmSetupLayout_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ClearBuffer()
            Me.WindowState = FormWindowState.Maximized
            Me.Text = "HHG Remove V." & Application.ProductVersion
            grpPanelInfo.Left = Me.Width - grpPanelInfo.Width - 30
            lbPCName.Text = Environment.MachineName
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ClearBuffer()
        dsData = Nothing
        iLayoutX = 0
        iLayoutY = 0
        txtX.Text = iLayoutX
        txtY.Text = iLayoutY

        'objTraceability = New FPTraceability

        dsData = New DataTable

        dsData.Columns.Add("blockno")
        dsData.Columns.Add("pixelx")
        dsData.Columns.Add("pixely")

        txtMiniSheet.Text = 0

        objPanel = New PanelInfoM

    End Sub

    Private Sub grdView_CellMouseEnter(sender As Object, e As DataGridViewCellEventArgs) Handles grdView.CellMouseEnter
        grdView.RowsDefaultCellStyle.SelectionBackColor = Color.BlanchedAlmond
        If e.RowIndex > -1 Then
            grdView.Rows(e.RowIndex).Selected = True
        End If
    End Sub

    Private Sub grdView_CellMouseLeave(sender As Object, e As DataGridViewCellEventArgs) Handles grdView.CellMouseLeave
        grdView.RowsDefaultCellStyle.SelectionBackColor = Color.DimGray
    End Sub

    Private Sub Edit_Click(sender As Object, e As EventArgs) Handles Edit.Click

    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim lbl As Label
        Dim objCon As New ClsSQLCon
        Dim objCAvity As CavityM
        Dim sTmp As String
        Dim iCount As Integer = 0


        Try
            If PicPanel.Controls.Count = txtPcs.Text Then
                If objPanel.Cavity.Count = 0 Then
                    For Each lbl In PicPanel.Controls
                        objCAvity = New CavityM
                        objCAvity.CavityNo = lbl.Text
                        objCAvity.PixelX = lbl.Location.X
                        objCAvity.PixelY = lbl.Location.Y
                        objPanel.Cavity.Add(iCount, objCAvity)
                        iCount = iCount + 1
                        objCAvity = Nothing
                    Next
                Else
                    For Each lbl In PicPanel.Controls
                        objCAvity = objPanel.Cavity(iCount)
                        objCAvity.CavityNo = lbl.Text
                        objCAvity.PixelX = lbl.Location.X
                        objCAvity.PixelY = lbl.Location.Y
                        iCount = iCount + 1
                    Next
                End If

                objPanel.MiniSheet = txtMiniSheet.Text

                'sTmp = objTraceability.SavePanelLayout(objPanel)

                If sTmp <> "OK" Then
                    Throw New Exception(sTmp)
                Else
                    MsgBox("Completed Layout")
                End If

            Else
                Throw New Exception("ยัง setup ตำแหน่ง Layout ไม่ครบตามที่กำหนด")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnOpen_Click(sender As Object, e As EventArgs) Handles btnOpen.Click
        'Dim objPanel As PanelInfoM
        Dim iCount As Integer
        Dim Label As Label

        Try
            If txtPanelType.Text = "" Then
                Throw New Exception("ยังไม่ได้ใส่ Panel Type")
            End If

            'objPanel = objTraceability.getPanelLayout(txtPanelType.Text)
            objPanel.PanelType = txtPanelType.Text

            PicPanel.Image = objPanel.ImagePanel
            PicPanel.Width = Me.Width - grpPanelInfo.Width - 50
            PicPanel.Height = Me.Height - PicPanel.Top - 50
            PicPanel.SizeMode = PictureBoxSizeMode.StretchImage

            objPanel.Width = PicPanel.Width
            objPanel.Height = PicPanel.Height

            objPanel.Aspecratio = PicPanel.Width / PicPanel.Height

            txtMiniSheet.Text = objPanel.MiniSheet

            For iCount = 0 To objPanel.Cavity.Count - 1

                Label = New Label()
                Label.Location = New Point(objPanel.Cavity(iCount).PixelX, objPanel.Cavity(iCount).PixelY)
                Label.Size = New Size(20, 20)
                Label.ForeColor = Color.White
                Label.BackColor = Color.Green

                Label.Text = objPanel.Cavity(iCount).CavityNo

                AddHandler Label.Click, AddressOf myClickHandler

                PicPanel.Controls.Add(Label)

                Label = Nothing

            Next iCount

            txtPcs.Text = objPanel.Cavity.Count

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub txtPanelType_TextChanged(sender As Object, e As EventArgs) Handles txtPanelType.TextChanged

    End Sub

    Private Sub PicPanel_Click(sender As Object, e As EventArgs) Handles PicPanel.Click

    End Sub

    Private Sub DeleteMenu_Click(sender As Object, e As EventArgs) Handles DeleteMenu.Click

    End Sub
End Class