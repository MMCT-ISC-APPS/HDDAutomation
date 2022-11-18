Imports MMCTWIPDLL
Imports System.Threading
Imports System.Text.RegularExpressions
Imports System.Net
Imports System.Net.Sockets
Imports System.Text
Imports System.IO
Imports System.IO.Ports
Imports System.ComponentModel
Imports MachineDLL
Imports MachineDLL.Entities

Public Class FrmMain

    Private dsEcheckLayout As DataTable
    Private DtBeforeSave As DataTable
    'Private dsFixtureInfo As DataTable
    Private objHHGTraceability As HHGTraceability
    Private sModel As String

    Private sProduction As String = "HHG"
    Private sProgramName As String = "HHG Automation Transfer Jigsaw"
    Private sBackupTmp As String
    Private Const MonitorPath As String = "c:\MonitorPath\"
    Private Const sBackup As String = "c:\MonitorBackup\"
    Private sCurrentFileName As String = ""
    Private sCurrentPAthFileName As String = ""

    Private objPanel As PanelInfoM

    Private Labels() As Label

    Delegate Sub SetTextCallback(text As String)

    Delegate Sub SetJigSawCallback(text As String)

    Delegate Sub SetMsgTextCallback(text As String)

    Private iPanelPerSheet As Integer

    'Private sBarcode As String

    Private bNewJob As Boolean
    Private bAddJob As Boolean
    Private sFixtureNo As String
    Private sJigsaw As String

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
    End Sub

    Public Function getVersion() As String
        Dim ProjectAssembly As Reflection.Assembly
        ProjectAssembly = Reflection.Assembly.GetExecutingAssembly()

        For Each attr As Attribute In ProjectAssembly.GetCustomAttributes(False)
            If TypeOf attr Is Reflection.AssemblyFileVersionAttribute Then
                Dim FileVerAttr As Reflection.AssemblyFileVersionAttribute = attr
                Return FileVerAttr.Version
            End If
        Next
        Throw New Reflection.TargetInvocationException(
        New KeyNotFoundException(
            "Cannot find custom attribute 'AssemblyFileVersionAttribute'"))
    End Function


    Private Sub frmPacking_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

            objHHGTraceability = New HHGTraceability(False)

            Me.Text = sProgramName + "(SW V" + getVersion() + " , DLL v" + objHHGTraceability.GetVersion() + " , WS " + objHHGTraceability.GetWebServiceVersion() + ")"

            ClearData()

            bNewJob = False

            Me.WindowState = FormWindowState.Maximized

            grpPanelInfo.Left = Me.Width - grpPanelInfo.Width - 30
            grpDefect.Left = grpPanelInfo.Left
            grpDefect.Visible = False
            'gView.Left = grpPanelInfo.Left

            pDefect.Visible = False
            txtPanel.Focus()
            lbPCName.Text = Environment.MachineName

            Dim sDate As String = DateTime.Now.ToString("yyyyMMdd")

            sBackupTmp = sBackup + "\" + sDate

            Dim di As New DirectoryInfo(sBackupTmp)

            If di.Exists = False Then
                di.Create()
            End If

            di = Nothing

            tmrMonitor.Enabled = True

        Catch ex As Exception
            MsgBox("Err Desc:" & ex.Message, MsgBoxStyle.Critical)
        Finally
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            ClearData()
        End Try

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        Dim textbox1 As New TextBox
        textbox1.Name = "txtFail1"
        textbox1.Size = New Size(60, 20)
        textbox1.Location = New Point(500, 500)
        textbox1.BackColor = Color.Red
        textbox1.ForeColor = Color.White
        textbox1.Font = New Font("Tahoma", 10, FontStyle.Regular)
        textbox1.Text = "FAIL[10]"
        textbox1.TextAlign = HorizontalAlignment.Center
        PicPanel.Controls.Add(textbox1)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs)
        Dim textbox1 As New TextBox
        textbox1.Name = "txtPass1"
        textbox1.Size = New Size(60, 20)
        textbox1.Location = New Point(600, 600)
        textbox1.BackColor = Color.Green
        textbox1.ForeColor = Color.White
        textbox1.Font = New Font("Tahoma", 10, FontStyle.Regular)
        textbox1.Text = "PASS[1]"
        textbox1.TextAlign = HorizontalAlignment.Center
        PicPanel.Controls.Add(textbox1)
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs)
        Dim text1 As TextBox = CType(PicPanel.Controls("txtFail1"), TextBox)
        PicPanel.Controls.Remove(text1)
        Dim text2 As TextBox = CType(PicPanel.Controls("txtPass1"), TextBox)
        PicPanel.Controls.Remove(text2)
        txtPanel.Text = ""
        PicPanel.Image = Nothing
    End Sub

    Private Sub ClearData()
        Try
            dsEcheckLayout = Nothing
            PicPanel.Image = Nothing
            PicPanel.Controls.Clear()
            LbAOI.Text = "AOI Time : "
            LbXray.Text = "XRAY Time : "
            If pDefect.Controls.Count > 5 Then
                For Each btn In pDefect.Controls.OfType(Of Button)()
                    btn.Dispose()
                Next
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs)
        PicPanel.Image = Image.FromFile(My.Application.Info.DirectoryPath() & "\S_4538912661735.jpg")
        If PicPanel.Image.Width > (Me.Width - grpPanelInfo.Width - 30) Then
            PicPanel.Width = Me.Width - grpPanelInfo.Width - 50
            PicPanel.Height = Me.Height - PicPanel.Top - 50
            PicPanel.SizeMode = PictureBoxSizeMode.StretchImage
        Else
            PicPanel.SizeMode = PictureBoxSizeMode.AutoSize
        End If
        PicPanel.Visible = True
        'LoadPanelLayout()
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs)
        PicPanel.Image = Image.FromFile(My.Application.Info.DirectoryPath() & "\S_4538913151501.jpg")
        PicPanel.SizeMode = PictureBoxSizeMode.AutoSize
    End Sub

    Private Sub btnCompleted_Click(sender As Object, e As EventArgs) Handles btnCompleted.Click
        Try
            tmrMonitor.Enabled = False
            If txtPanel.Text <> "" And txtJigsaw.Text <> "" Then
                TransferFixturetoJigsaw(txtPanel.Text, txtJigsaw.Text)
                txtPanel.Text = ""
                txtJigsaw.Text = ""
                lblRemoveSts.Tag = "Waiting"
            End If
            tmrMonitor.Enabled = True
            btnCompleted.Visible = False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Private Sub txtPanel_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPanel.KeyDown
        Dim sError As String = ""
        Dim sModel As String = ""
        Dim sJobname As String = ""

        If e.KeyCode = Keys.Enter Then
            Try
                If txtPanel.Text = "" Then
                    Throw New Exception("ยังไม่ได้ยิงเบอร์ Fixture")
                End If

                'If sBarcode <> txtPanel.Text Then
                ShowPanelInfo()
                'End If

            Catch ex As Exception
                MsgBox(ex.Message)
                txtPanel.SelectAll()
            End Try


        End If
    End Sub

    Private Sub LoadIntailPictureInBuffer(ByVal sModel As String)
        Try
            LoadPanelResult()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Private Sub LoadPanelLayout24()
        Dim dtImg As DataTable
        dtImg = objPanel.ImageData  'objHHGTraceability.GetPanelImg(sLayout)
        Dim ImgTop As Bitmap
        Dim ImgTopGreen As Bitmap
        Dim ImgTopYellow As Bitmap
        Dim ImgTopRed As Bitmap
        Dim ImgTopGrey As Bitmap
        Dim ImgBottom As Bitmap
        Dim ImgBottomGreen As Bitmap
        Dim ImgBottomYellow As Bitmap
        Dim ImgBottomRed As Bitmap
        Dim ImgBottomGrey As Bitmap
        Dim ImgBorder As Bitmap

        Try
            For Each r As DataRow In dtImg.Rows
                Select Case r("layout_name")
                    Case "Top"
                        ImgTop = StreamImg(r)
                    Case "Top-Green"
                        ImgTopGreen = StreamImg(r)
                    Case "Top-Yellow"
                        ImgTopYellow = StreamImg(r)
                    Case "Top-Red"
                        ImgTopRed = StreamImg(r)
                    Case "Top-Grey"
                        ImgTopGrey = StreamImg(r)
                    Case "Bottom"
                        ImgBottom = StreamImg(r)
                    Case "Bottom-Green"
                        ImgBottomGreen = StreamImg(r)
                    Case "Bottom-Yellow"
                        ImgBottomYellow = StreamImg(r)
                    Case "Bottom-Red"
                        ImgBottomRed = StreamImg(r)
                    Case "Bottom-Grey"
                        ImgBottomGrey = StreamImg(r)
                    Case "Border"
                        ImgBorder = StreamImg(r)
                End Select
            Next
            Dim bmpdest As Bitmap = New Bitmap(1000, 1000)
            'Dim bmpdest As Bitmap = New Bitmap(800, 800)
            Dim g As Graphics = Graphics.FromImage(bmpdest)
            Dim iCount As Integer
            Dim pixelX As Integer
            Dim pixelY As Integer = 50
            Dim RowNum As Integer = 1
            Dim RowEven As Boolean
            Dim resultRemove As String
            Dim NotFocusAOI As Boolean = SkipAOI.Checked
            Dim NotFocusXray As Boolean = SkipXray.Checked
            Dim IsSkipXray As Boolean
            Dim xrayDate As DateTime
            Dim diffmin As Integer
            Dim bValid As Boolean
            Dim bHaveRemove As Boolean

            ClearData()

            PicPanel.Width = Me.Width - grpPanelInfo.Width - 50
            PicPanel.Height = Me.Height - PicPanel.Top - 50
            PicPanel.Image = bmpdest
            PicPanel.Visible = True
            ReDim Labels(24)

            bValid = False

            objPanel.FixtureInfoData.DefaultView.RowFilter = " fixtureno = '" & Trim(txtPanel.Text.Trim()) & "' and xraydate is not null"

            If objPanel.FixtureInfoData.DefaultView.Count = 0 Then
                IsSkipXray = True
                objPanel.FixtureInfoData.DefaultView.RowFilter = " fixtureno = '" & Trim(txtPanel.Text.Trim()) & "' and aoidate is not null"
                If objPanel.FixtureInfoData.DefaultView.Count = 0 Then
                    bValid = False
                    LbAOI.Text = "AOI Time : Skip AOI!!!"
                    LbXray.Text = "XRAY Time : Skip Xray!!!"
                Else
                    bValid = False
                    LbAOI.Text = "AOI Time : " + objPanel.FixtureInfoData.DefaultView.Item(0).Item("aoidate").ToString()
                    LbXray.Text = "XRAY Time : Skip Xray!!!"
                End If
            Else
                IsSkipXray = False
                xrayDate = objPanel.FixtureInfoData.DefaultView.Item(0).Item("xraydate")
                objPanel.FixtureInfoData.DefaultView.RowFilter = " fixtureno = '" & Trim(txtPanel.Text.Trim()) & "' and aoidate is not null"
                LbXray.Text = "XRAY Time : " + xrayDate.ToString()
                If objPanel.FixtureInfoData.DefaultView.Count = 0 Then
                    bValid = False
                    LbAOI.Text = "AOI Time : Skip AOI!!!"
                Else
                    bValid = True
                    LbAOI.Text = "AOI Time : " + objPanel.FixtureInfoData.DefaultView.Item(0).Item("aoidate").ToString()
                End If
            End If


            For iCount = 1 To 24
                'Labels(iCount).Location = New Point(objPanel.Cavity(iCount).PixelX, objPanel.Cavity(iCount).PixelY)
                If RowNum Mod 2 = 0 Then
                    RowEven = True
                    'pixelX = (iCount - 5 * (RowNum - 1)) * 150 - 130
                    'pixelX = (iCount - 6 * (RowNum - 1)) * 150 - 130
                    pixelX = (iCount - 6 * (RowNum - 1)) * 120 - 120
                Else
                    RowEven = False
                    'pixelX = (iCount - 5 * (RowNum - 1)) * 150 - 80
                    'pixelX = (iCount - 6 * (RowNum - 1)) * 150 - 80
                    pixelX = (iCount - 6 * (RowNum - 1)) * 120 - 80
                End If

                Labels(iCount - 1) = New Label()
                Labels(iCount - 1).Font = New Font("Comic Sans MS", 14, FontStyle.Bold)

                Labels(iCount - 1).Parent = PicPanel
                Labels(iCount - 1).Size = New Size(40, 40)
                Labels(iCount - 1).Text = iCount.ToString()
                Labels(iCount - 1).BackColor = Color.Transparent

                Labels(iCount - 1).BringToFront()
                Labels(iCount - 1).Location = New Point(pixelX + 15, pixelY + 50)

                If NotFocusAOI And NotFocusXray Then
                    g.DrawImage(IIf(RowEven, ImgBottomGreen, ImgTopGreen), New Point(pixelX, pixelY))
                Else
                    objPanel.FixtureInfoData.DefaultView.RowFilter = " fixtureno = '" & Trim(txtPanel.Text.Trim()) & "' and position = " & iCount.ToString()

                    If NotFocusXray Then
                        diffmin = DateDiff("n", objPanel.FixtureInfoData.DefaultView.Item(0).Item("aoidate"), Date.Now())
                        'If diffmin > 90 Then
                        'bValid = False
                        'g.DrawImage(IIf(RowEven, ImgBottomGrey, ImgTopGrey), New Point(pixelX, pixelY))
                        'Else
                        If objPanel.FixtureInfoData.DefaultView.Item(0).Item("aoiresult").ToString().Contains("PASS") Then
                                g.DrawImage(IIf(RowEven, ImgBottomGreen, ImgTopGreen), New Point(pixelX, pixelY)) 'No result xray but aoi pass show green
                            Else
                                g.DrawImage(IIf(RowEven, ImgBottomYellow, ImgTopYellow), New Point(pixelX, pixelY))  'No result xray but aoi fail show yellow
                            End If
                        'End If
                    Else
                        If NotFocusAOI Then
                            If IsSkipXray Then
                                g.DrawImage(IIf(RowEven, ImgBottomGrey, ImgTopGrey), New Point(pixelX, pixelY))
                            Else
                                'diffmin = DateDiff("n", xrayDate, Date.Now())
                                'If diffmin > 90 Then
                                'bValid = False
                                'g.DrawImage(IIf(RowEven, ImgBottomGrey, ImgTopGrey), New Point(pixelX, pixelY))
                                'Else
                                If objPanel.FixtureInfoData.DefaultView.Item(0).Item("xrayresult").ToString().Contains("FAILED") Then
                                        g.DrawImage(IIf(RowEven, ImgBottomRed, ImgTopRed), New Point(pixelX, pixelY)) 'xray fail show red not care aoi result
                                    Else
                                        g.DrawImage(IIf(RowEven, ImgBottomGreen, ImgTopGreen), New Point(pixelX, pixelY))
                                    End If
                                'End If
                            End If
                        Else
                            If IsSkipXray Then
                                g.DrawImage(IIf(RowEven, ImgBottomGrey, ImgTopGrey), New Point(pixelX, pixelY))
                            Else
                                'diffmin = DateDiff("n", xrayDate, objPanel.FixtureInfoData.DefaultView.Item(0).Item("aoidate"))
                                'If diffmin > 30 Or diffmin < 0 Then
                                'bValid = False
                                'g.DrawImage(IIf(RowEven, ImgBottomGrey, ImgTopGrey), New Point(pixelX, pixelY))
                                'Else
                                'diffmin = DateDiff("n", objPanel.FixtureInfoData.DefaultView.Item(0).Item("aoidate"), Date.Now())
                                ' If diffmin > 90 Then
                                'bValid = False
                                'g.DrawImage(IIf(RowEven, ImgBottomGrey, ImgTopGrey), New Point(pixelX, pixelY))
                                'Else
                                If objPanel.FixtureInfoData.DefaultView.Item(0).Item("xrayresult").ToString().Contains("FAILED") Then
                                            g.DrawImage(IIf(RowEven, ImgBottomRed, ImgTopRed), New Point(pixelX, pixelY)) 'xray fail show red not care aoi result
                                        Else
                                            If objPanel.FixtureInfoData.DefaultView.Item(0).Item("aoiresult").ToString().Contains("PASS") Then
                                                g.DrawImage(IIf(RowEven, ImgBottomGreen, ImgTopGreen), New Point(pixelX, pixelY)) 'No result xray but aoi pass show green
                                            Else
                                                g.DrawImage(IIf(RowEven, ImgBottomYellow, ImgTopYellow), New Point(pixelX, pixelY))
                                            End If

                                        End If

                                    'End If
                                End If

                            'End If
                        End If
                    End If
                End If

                If iCount Mod 6 = 0 Then
                    RowNum = RowNum + 1
                    If iCount Mod 2 = 0 Then
                        pixelY = pixelY + 200
                    Else
                        pixelY = pixelY + 50
                    End If

                End If

                'If iCount Mod 5 = 0 Then
                '    RowNum = RowNum + 1
                '    If iCount Mod 2 = 0 Then
                '        pixelY = pixelY + 250
                '    Else
                '        pixelY = pixelY + 100
                '    End If

                'End If

            Next iCount

            'g.DrawImage(ImgBorder, 0, 0, 820 + 150, 760 + 150)
            g.DrawImage(ImgBorder, 0, 0, 820, 760 + 150)

            g.Dispose()

            If bValid = True Then
                lblRemoveSts.Text = "Transfer Jigsaw"
                lblRemoveSts.Tag = "OK"
            Else
                lblRemoveSts.Text = "Skip Process"
                lblRemoveSts.Tag = "SKIP"
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try


    End Sub
    Private Sub LoadLayout20()
        Dim dtImg As DataTable
        dtImg = objPanel.ImageData 'objHHGTraceability.GetPanelImg(sLayout)
        Dim ImgTop As Bitmap
        Dim ImgTopGreen As Bitmap
        Dim ImgTopYellow As Bitmap
        Dim ImgTopRed As Bitmap
        Dim ImgTopGrey As Bitmap
        Dim ImgBottom As Bitmap
        Dim ImgBottomGreen As Bitmap
        Dim ImgBottomYellow As Bitmap
        Dim ImgBottomRed As Bitmap
        Dim ImgBottomGrey As Bitmap
        Dim ImgBorder As Bitmap

        Try
            For Each r As DataRow In dtImg.Rows
                Select Case r("layout_name")
                    Case "Top"
                        ImgTop = StreamImg(r)
                    Case "Top-Green"
                        ImgTopGreen = StreamImg(r)
                    Case "Top-Yellow"
                        ImgTopYellow = StreamImg(r)
                    Case "Top-Red"
                        ImgTopRed = StreamImg(r)
                    Case "Top-Grey"
                        ImgTopGrey = StreamImg(r)
                    Case "Bottom"
                        ImgBottom = StreamImg(r)
                    Case "Bottom-Green"
                        ImgBottomGreen = StreamImg(r)
                    Case "Bottom-Yellow"
                        ImgBottomYellow = StreamImg(r)
                    Case "Bottom-Red"
                        ImgBottomRed = StreamImg(r)
                    Case "Bottom-Grey"
                        ImgBottomGrey = StreamImg(r)
                    Case "Border"
                        ImgBorder = StreamImg(r)
                End Select
            Next
            Dim bmpdest As Bitmap = New Bitmap(1000, 1000)
            Dim g As Graphics = Graphics.FromImage(bmpdest)
            Dim iCount As Integer
            Dim pixelX As Integer
            Dim pixelY As Integer = 50
            Dim RowNum As Integer = 1
            Dim RowEven As Boolean
            Dim resultRemove As String
            Dim NotFocusAOI As Boolean = SkipAOI.Checked
            Dim NotFocusXray As Boolean = SkipXray.Checked
            Dim IsSkipXray As Boolean
            Dim xrayDate As DateTime
            Dim diffmin As Integer
            Dim bValid As Boolean
            Dim bHaveRemove As Boolean

            ClearData()

            PicPanel.Width = Me.Width - grpPanelInfo.Width - 50
            PicPanel.Height = Me.Height - PicPanel.Top - 50
            PicPanel.Image = bmpdest
            PicPanel.Visible = True
            ReDim Labels(20)

            bValid = False

            objPanel.FixtureInfoData.DefaultView.RowFilter = " fixtureno = '" & Trim(txtPanel.Text.Trim()) & "' and xraydate is not null"

            If objPanel.FixtureInfoData.DefaultView.Count = 0 Then
                IsSkipXray = True
                objPanel.FixtureInfoData.DefaultView.RowFilter = " fixtureno = '" & Trim(txtPanel.Text.Trim()) & "' and aoidate is not null"
                If objPanel.FixtureInfoData.DefaultView.Count = 0 Then
                    bValid = False
                    LbAOI.Text = "AOI Time : Skip AOI!!!"
                    LbXray.Text = "XRAY Time : Skip Xray!!!"
                Else
                    bValid = False
                    LbAOI.Text = "AOI Time : " + objPanel.FixtureInfoData.DefaultView.Item(0).Item("aoidate").ToString()
                    LbXray.Text = "XRAY Time : Skip Xray!!!"
                End If
            Else
                IsSkipXray = False
                'xrayDate = Format(objPanel.FixtureInfoData.DefaultView.Item(0).Item("xraydate"), "dd/MM/yyyy HH:mm tt")
                objPanel.FixtureInfoData.DefaultView.RowFilter = " fixtureno = '" & Trim(txtPanel.Text.Trim()) & "' and aoidate is not null"
                LbXray.Text = "XRAY Time : " + objPanel.FixtureInfoData.DefaultView.Item(0).Item("xraydate") '+ xrayDate.ToString()
                If objPanel.FixtureInfoData.DefaultView.Count = 0 Then
                    bValid = False
                    LbAOI.Text = "AOI Time : Skip AOI!!!"
                Else
                    bValid = True
                    LbAOI.Text = "AOI Time : " + objPanel.FixtureInfoData.DefaultView.Item(0).Item("aoidate").ToString()
                End If
            End If


            For iCount = 1 To 20
                'Labels(iCount).Location = New Point(objPanel.Cavity(iCount).PixelX, objPanel.Cavity(iCount).PixelY)
                If RowNum Mod 2 = 0 Then
                    RowEven = True
                    pixelX = (iCount - 5 * (RowNum - 1)) * 150 - 130
                    'pixelX = (iCount - 6 * (RowNum - 1)) * 150 - 130
                Else
                    RowEven = False
                    pixelX = (iCount - 5 * (RowNum - 1)) * 150 - 80
                    'pixelX = (iCount - 6 * (RowNum - 1)) * 150 - 80
                End If

                Labels(iCount - 1) = New Label()
                Labels(iCount - 1).Font = New Font("Comic Sans MS", 14, FontStyle.Bold)

                Labels(iCount - 1).Parent = PicPanel
                Labels(iCount - 1).Size = New Size(40, 40)
                Labels(iCount - 1).Text = iCount.ToString()
                Labels(iCount - 1).BackColor = Color.Transparent

                Labels(iCount - 1).BringToFront()
                Labels(iCount - 1).Location = New Point(pixelX + 15, pixelY + 50)

                If NotFocusAOI And NotFocusXray Then
                    g.DrawImage(IIf(RowEven, ImgBottomGreen, ImgTopGreen), New Point(pixelX, pixelY))
                Else
                    objPanel.FixtureInfoData.DefaultView.RowFilter = " fixtureno = '" & Trim(txtPanel.Text.Trim()) & "' and position = " & iCount.ToString()

                    If NotFocusXray Then
                        'diffmin = DateDiff("n", objPanel.FixtureInfoData.DefaultView.Item(0).Item("aoidate"), Date.Now())
                        'If diffmin > 90 Then
                        'g.DrawImage(IIf(RowEven, ImgBottomGrey, ImgTopGrey), New Point(pixelX, pixelY))
                        'Else
                        If objPanel.FixtureInfoData.DefaultView.Item(0).Item("aoiresult").ToString().Contains("PASS") Then
                            g.DrawImage(IIf(RowEven, ImgBottomGreen, ImgTopGreen), New Point(pixelX, pixelY)) 'No result xray but aoi pass show green
                        Else
                            g.DrawImage(IIf(RowEven, ImgBottomYellow, ImgTopYellow), New Point(pixelX, pixelY))  'No result xray but aoi fail show yellow
                        End If
                        'End If
                    Else
                        If NotFocusAOI Then
                            If IsSkipXray Then
                                g.DrawImage(IIf(RowEven, ImgBottomGrey, ImgTopGrey), New Point(pixelX, pixelY))
                            Else
                                'diffmin = DateDiff("n", xrayDate, Date.Now())
                                'If diffmin > 90 Then
                                'g.DrawImage(IIf(RowEven, ImgBottomGrey, ImgTopGrey), New Point(pixelX, pixelY))
                                'Else
                                If objPanel.FixtureInfoData.DefaultView.Item(0).Item("xrayresult").ToString().Contains("FAILED") Then
                                    g.DrawImage(IIf(RowEven, ImgBottomRed, ImgTopRed), New Point(pixelX, pixelY)) 'xray fail show red not care aoi result
                                Else
                                    g.DrawImage(IIf(RowEven, ImgBottomGreen, ImgTopGreen), New Point(pixelX, pixelY))
                                End If
                                'End If
                            End If
                        Else
                            If IsSkipXray Then
                                g.DrawImage(IIf(RowEven, ImgBottomGrey, ImgTopGrey), New Point(pixelX, pixelY))
                            Else
                                diffmin = DateDiff("n", xrayDate, objPanel.FixtureInfoData.DefaultView.Item(0).Item("aoidate"))
                                'If diffmin > 30 Or diffmin < 0 Then
                                '    bValid = False
                                '    g.DrawImage(IIf(RowEven, ImgBottomGrey, ImgTopGrey), New Point(pixelX, pixelY))
                                'Else
                                'diffmin = DateDiff("n", objPanel.FixtureInfoData.DefaultView.Item(0).Item("aoidate"), Date.Now())
                                'If diffmin > 90 Then
                                'bValid = False
                                'g.DrawImage(IIf(RowEven, ImgBottomGrey, ImgTopGrey), New Point(pixelX, pixelY))
                                'Else
                                If objPanel.FixtureInfoData.DefaultView.Item(0).Item("xrayresult").ToString().Contains("FAILED") Then
                                    g.DrawImage(IIf(RowEven, ImgBottomRed, ImgTopRed), New Point(pixelX, pixelY)) 'xray fail show red not care aoi result
                                Else
                                    If objPanel.FixtureInfoData.DefaultView.Item(0).Item("aoiresult").ToString().Contains("PASS") Then
                                        g.DrawImage(IIf(RowEven, ImgBottomGreen, ImgTopGreen), New Point(pixelX, pixelY)) 'No result xray but aoi pass show green
                                    Else
                                        g.DrawImage(IIf(RowEven, ImgBottomYellow, ImgTopYellow), New Point(pixelX, pixelY))
                                    End If

                                End If

                                ' End If
                                'End If

                            End If

                        End If
                    End If
                End If

                'If iCount Mod 6 = 0 Then
                '    RowNum = RowNum + 1
                '    If iCount Mod 2 = 0 Then
                '        pixelY = pixelY + 200
                '    Else
                '        pixelY = pixelY + 50
                '    End If

                'End If

                If iCount Mod 5 = 0 Then
                    RowNum = RowNum + 1
                    If iCount Mod 2 = 0 Then
                        pixelY = pixelY + 250
                    Else
                        pixelY = pixelY + 100
                    End If

                End If

            Next iCount

            g.DrawImage(ImgBorder, 0, 0, 820 + 150, 760 + 150)

            g.Dispose()

            If bValid = True Then
                lblRemoveSts.Text = "Transfer Jigsaw"
                lblRemoveSts.Tag = "OK"
            Else
                lblRemoveSts.Text = "Skip Process"
                lblRemoveSts.Tag = "SKIP"
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Private Sub LoadPanelResult()
        Try
            If objPanel.FixtureInfoData.Rows.Count = 20 Then
                LoadLayout20()
            ElseIf objPanel.FixtureInfoData.Rows.Count = 24 Then
                LoadPanelLayout24()
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Private Function StreamImg(rImg As DataRow) As Image
        Dim pic() As Byte
        Try
            pic = DirectCast(rImg("layout_img"), Byte())
            Dim mem As New System.IO.MemoryStream(pic)
            Return Image.FromStream(mem)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        grpDefect.Visible = False
        grpPanelInfo.Visible = True
    End Sub

    Private Sub ShowPanelInfo()
        Dim bValid As Boolean

        lblPanelNo.Text = "FixtureNo:" + txtPanel.Text
        bValid = False

        Try
            If objHHGTraceability.IsValid2D(txtPanel.Text, objPanel) = True Then
                lblJobname.Text = "JobName:" + objPanel.JobName
                lblModel.Text = "Model:" + objPanel.ModelName
                LoadIntailPictureInBuffer(objPanel.ModelName)
            Else
                If objPanel.ErrorMsg <> "OK" Then
                    lblJobname.Text = "JobName:Error!!!"
                    lblModel.Text = "Model:Error!!!"
                End If
            End If
        Catch e As Exception
            MsgBox(e.Message)
        End Try
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ShowPanelInfo()
    End Sub

    Private Sub Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim btn As Button

        For Each btn In pDefect.Controls.OfType(Of Button)()
            If (btn.Text = "Confirm") Or (btn.Text = "Close") Then
                '* Skip               ด
            Else
                btn.BackColor = Color.Green
                btn.ForeColor = Color.White
            End If
        Next

        txtCurrDefect.Text = CType(CType(sender, System.Windows.Forms.Button).Text, String)
        CType(sender, System.Windows.Forms.Button).BackColor = Color.Brown
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        txtPanel.Text = "LA2-SETA016" + Chr(4)
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub


    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        txtPanel.Text = "LA2-SETA021" + Chr(4)
    End Sub

    Private Sub SetText(text As String)
        ' InvokeRequired required compares the thread ID of the
        ' calling thread to the thread ID of the creating thread.
        ' If these threads are different, it returns true.        

        Try
            If Me.txtPanel.InvokeRequired Then
                Dim d As New SetTextCallback(AddressOf SetText)
                Me.Invoke(d, New Object() {text})
            Else
                'sBarcode = barcode
                'If Not (text.Contains("ERROR")) Then
                If text.ToUpper.Trim() <> txtPanel.Text.ToUpper.Trim() Then
                    Application.DoEvents()
                    'ClearData()
                    txtPanel.Text = text
                    ShowPanelInfo()
                    txtPanel.SelectAll()

                    'E'nd If
                End If

            End If
            'End If

        Catch ex As Exception
            MsgBox("Err Desc:" & ex.Message)
        End Try
    End Sub

    Private Sub SetMsgText(text As String)
        Try
            If Me.lblRemoveSts.InvokeRequired Then
                Dim d As New SetTextCallback(AddressOf SetMsgText)
                Me.Invoke(d, New Object() {text})
            Else
                'sBarcode = barcode
                Application.DoEvents()
                lblRemoveSts.Text = text
            End If

        Catch ex As Exception
            MsgBox("Err Desc:" & ex.Message)
        End Try
    End Sub

    Private Sub SetJigSaw(text As String)
        ' InvokeRequired required compares the thread ID of the
        ' calling thread to the thread ID of the creating thread.
        ' If these threads are different, it returns true.        

        Try
            If Me.txtJigsaw.InvokeRequired Then
                Dim d As New SetJigSawCallback(AddressOf SetJigSaw)
                Me.Invoke(d, New Object() {text})
            Else
                'If Not (text.Contains("ERROR")) Then
                If text.ToUpper.Trim() <> txtJigsaw.Text.ToUpper.Trim() Then
                    Application.DoEvents()
                    'ClearData()                    
                    txtJigsaw.Text = text
                    txtJigsaw.SelectAll()
                End If

            End If
            'End If

        Catch ex As Exception
            MsgBox("Err Desc:" & ex.Message)
        End Try
    End Sub

    Private Sub SkipAOI_CheckedChanged(sender As Object, e As EventArgs) Handles SkipAOI.CheckedChanged
        If txtPanel.Text <> "" Then
            ShowPanelInfo()
        End If
    End Sub

    Private Sub SkipXray_CheckedChanged(sender As Object, e As EventArgs) Handles SkipXray.CheckedChanged
        If txtPanel.Text <> "" Then
            ShowPanelInfo()
        End If
    End Sub

    Private Sub grpPanelInfo_Enter(sender As Object, e As EventArgs) Handles grpPanelInfo.Enter

    End Sub

    Private Sub txtPanel_MouseDown(sender As Object, e As MouseEventArgs) Handles txtPanel.MouseDown

    End Sub

    Private Sub tmrMonitor_Tick(sender As Object, e As EventArgs) Handles tmrMonitor.Tick
        'lblStatus.Text = "Staring !!!!!"
        bgSVR.WorkerReportsProgress = True
        bgSVR.WorkerSupportsCancellation = True
        If Not bgSVR.IsBusy Then
            bgSVR.RunWorkerAsync()
        End If
    End Sub

    Private Sub bgSVR_DoWork(sender As Object, e As DoWorkEventArgs) Handles bgSVR.DoWork
        Try
            tmrMonitor.Enabled = False

            Dim DiTmp As DirectoryInfo = New DirectoryInfo(MonitorPath)
            Dim FileTemp As FileInfo() = DiTmp.GetFiles("*.txt")
            Dim MonitorData As String()
            Dim sTmp As String()
            'Dim sFixtureNo As String = ""
            Dim i As Int16 = 0

            For i = 0 To FileTemp.Length - 1
                If bgSVR.CancellationPending = True Then
                    e.Cancel = True
                    Exit For
                Else
                    If FileTemp(i).Name = "barcode.txt" Then

                        MonitorData = System.IO.File.ReadAllLines(FileTemp(i).FullName.ToString().Trim())

                        sCurrentFileName = FileTemp(i).Name.ToString().Trim()
                        sCurrentPAthFileName = FileTemp(i).FullName.ToString().Trim()

                        sTmp = MonitorData(i).Split(",")
                        sFixtureNo = sTmp(0)
                        'sJigsaw = sTmp(1)
                        SetText(sFixtureNo)
                        SetJigSaw(sTmp(1))

                        System.Threading.Thread.Sleep(100)

                        bgSVR.ReportProgress(i)

                    End If


                End If
            Next

        Catch ex As Exception
            e.Cancel = True
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Private Sub TransferFixturetoJigsaw(ByVal sFixtureNo As String, ByVal sJigsaw As String)
        Dim sTmp As String = ""

        Try
            Dim objFile = New FileInfo(sCurrentPAthFileName)

            File.Delete(objFile.FullName.ToString().Trim())

            sTmp = objHHGTraceability.TransferToJigsaw(sFixtureNo, sJigsaw)

            ' Dim objFile = New FileInfo(sBackupTmp + "\" + sCurrentFileName)
            'If objFile.Exists = False Then
            '    'File.Move(sCurrentPAthFileName, sBackupTmp + "\" + objFile.Name.ToString().Trim())
            'Else
            '    File.Delete(objFile.FullName.ToString().Trim())
            'End If

            If sTmp = "OK" Then
                lblRemoveSts.ForeColor = Color.Green
                lblRemoveSts.Text = "Transfer Completed"
            Else
                lblRemoveSts.ForeColor = Color.Red
                lblRemoveSts.Text = sTmp
            End If

        Catch ex As Exception
            lblRemoveSts.ForeColor = Color.Red
            lblRemoveSts.Text = ex.Message
        End Try

    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs)

    End Sub

    Private Sub txtPanel_MouseCaptureChanged(sender As Object, e As EventArgs) Handles txtPanel.MouseCaptureChanged

    End Sub

    Private Sub bgSVR_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bgSVR.RunWorkerCompleted
        Try
            If e.Cancelled = True Then
                bgSVR.CancelAsync()
                lblRemoveSts.Text = "Canceled!" + e.Error.Message
            Else
                If lblRemoveSts.Tag = "OK" Then
                    If txtPanel.Text = "" Then
                        bgSVR.CancelAsync()
                        lblRemoveSts.Text = "หา Fixture เบอร์นี้ไม่เจอในระบบ"
                    End If

                    If txtJigsaw.Text = "" Then
                        bgSVR.CancelAsync()
                        lblRemoveSts.Text = "หา Jigsaw เบอร์นี้ไม่เจอในระบบ"
                    End If

                    If txtPanel.Text <> "" And txtJigsaw.Text <> "" Then

                        TransferFixturetoJigsaw(txtPanel.Text, txtJigsaw.Text)

                        txtPanel.Text = ""
                        txtJigsaw.Text = ""

                        lblRemoveSts.Tag = "Waiting"

                    End If
                Else
                    lblRemoveSts.Text = "Waiting(Skip Process)"
                    lblRemoveSts.ForeColor = Color.Red
                    bgSVR.CancelAsync()
                End If
            End If

            tmrMonitor.Enabled = True

        Catch ex As Exception
            btnCompleted.Visible = True
            lblRemoveSts.Text = ex.Message
        End Try
    End Sub

    Private Sub txtJigsaw_TextChanged(sender As Object, e As EventArgs) Handles txtJigsaw.TextChanged

    End Sub

    Private Sub txtPanel_TextChanged(sender As Object, e As EventArgs) Handles txtPanel.TextChanged

    End Sub
End Class
