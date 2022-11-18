Imports MBTSdb_dll.MBTS_dbFunction
Public Class clsFinal
    Dim SQLConStr As String

    Public Sub New()
        Call ConnectDatabase()
    End Sub

    Public Function ConnectDatabase() As String

        Dim sqLCon As ClsSQLCon = New ClsSQLCon
        SQLConStr = sqLCon.getSQLCon()

        Dim sqLDb As sQLDB = New sQLDB(SQLConStr)
        Try
            If sqLDb.ConnectionOK Then

                Return "OK"
            Else
                Return "Error Connect to SQL Server"
            End If

        Catch e As Exception
            Return e.Message
        End Try

    End Function
    Public Function GetModel(ByVal PanelID As String) As String

        Dim sQL As String = "select c.segment1 model from "
        sQL = sQL & " MMT_PANEL_2D_COF_DETAIL a , wip_entities b , mtl_system_items c "
        sQL = sQL & " where a.WIP_ENTITY_ID = b.WIP_ENTITY_ID and b.PRIMARY_ITEM_ID = c.inventory_item_id "
        sQL = sQL & " and b.ORGANIZATION_ID = c.ORGANIZATION_ID "
        sQL = sQL & " and a.PANEL_SERIAL ='" & PanelID & "'"
        sQL = sQL.Replace("'", "''")
        sQL = "select * From openquery(PROD,'" & sQL & "')"

        Dim objSQL As sQLDB = New sQLDB(SQLConStr)
        Try
            Dim dt As DataTable = objSQL.GetSQLDataTable(sQL)

            If dt.Rows.Count = 0 Then
                Return "N/A"
            Else
                Return dt.Rows(0).Item(0)
            End If

        Catch e As Exception

            Throw New Exception(e.Message)

        End Try
    End Function

    Public Sub SaveFinalInspec(ByVal sPanelID As String, ByVal seq As Integer, ByVal sDefectCode As String)
        Dim dsTmp As Data.DataTable = Nothing
        Dim sSql As String = ""
        Dim objSQL As sQLDB = New sQLDB(SQLConStr)

        Try
            dsTmp = getFinalInspec(sPanelID, seq)

            If dsTmp Is Nothing Then
                sSql = " insert into [dflex].[dbo].[as_final_inspection] ([panelID],[seq],[defect_code],[inspec_date],[inspec_by]) values"
                sSql = sSql & " ('" & sPanelID.Trim.ToUpper & "' , " & seq & " ,'" & sDefectCode & "', getdate() , '')"

                objSQL.ExecQuery(sSql)

            Else

            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Public Function getFinalInspec(ByVal sPanelId As String, ByVal iseq As Integer) As DataTable
        Dim sQL As String = "SELECT  [panelID], [seq], [defect_code]"
        sQL = sQL & " ,[inspec_date],[inspec_by] "
        sQL = sQL & " From [dflex].[dbo].[as_final_inspection] "
        sQL = sQL & " WHERE [panelID] = '" & Trim(sPanelId) & "' and [seq] = '" & iseq & "' "

        Dim objSQL As sQLDB = New sQLDB(SQLConStr)

        Try
            Dim dt As DataTable = objSQL.GetSQLDataTable(sQL)

            If dt.Rows.Count = 0 Then
                Return Nothing
            Else
                Return dt
            End If

        Catch e As Exception
            Throw New Exception(e.Message)
        End Try
    End Function

    Public Function getFinalInspec(ByVal sPanelId As String) As DataTable
        Dim sQL As String = "SELECT  [panelID], [seq], [defect_code]"
        sQL = sQL & " ,[inspec_date],[inspec_by] "
        sQL = sQL & " From [dflex].[dbo].[as_final_inspection] "
        sQL = sQL & " WHERE [panelID] = '" & Trim(sPanelId) & "'"

        Dim objSQL As sQLDB = New sQLDB(SQLConStr)

        Try
            Dim dt As DataTable = objSQL.GetSQLDataTable(sQL)

            If dt.Rows.Count = 0 Then
                Return Nothing
            Else
                Return dt
            End If

        Catch e As Exception
            Throw New Exception(e.Message)
        End Try
    End Function

    Public Function DeleteDefectPP(ByVal sPanelId As String, ByVal iSeq As Integer) As DataTable
        Dim sQL As String
        sQL = " delete From [dflex].[dbo].[as_final_inspection] "
        sQL = sQL & " WHERE [panelID] = '" & Trim(sPanelId) & "' and seq  = " & iSeq

        Dim objSQL As sQLDB = New sQLDB(SQLConStr)

        Try
            Dim dt As DataTable = objSQL.GetSQLDataTable(sQL)

            If dt.Rows.Count = 0 Then
                Return Nothing
            Else
                Return dt
            End If

        Catch e As Exception
            Throw New Exception(e.Message)
        End Try
    End Function

    Public Function getPanelLayout(ByVal PanelSize As Integer, ByVal sType As String) As DataTable
        Dim sQL As String = "Select [id],[panel_size],[panel_type] "
        sQL = sQL & " ,[location_id],[table_row] "
        sQL = sQL & " ,[table_col],[pixel_x],[pixel_y] "
        sQL = sQL & " FROM [dflex].[dbo].[panel_location_matrix] "
        sQL = sQL & " where [panel_size] = " & PanelSize
        sQL = sQL & " and panel_type = '" & Trim(sType) & "'"
        sQL = sQL & " order by [location_id] "

        Dim objSQL As sQLDB = New sQLDB(SQLConStr)

        Try
            Dim dt As DataTable = objSQL.GetSQLDataTable(sQL)

            If dt.Rows.Count = 0 Then
                Return Nothing
            Else
                Return dt
            End If

        Catch e As Exception
            Throw New Exception(e.Message)
        End Try
    End Function

    Public Function getDefectiveLayout() As DataTable
        Dim sQL As String = "Select [defectcode],[seq],[enable]"
        sQL = sQL & "   FROM [dflex].[dbo].[m_defect_code] "
        sQL = sQL & " where enable = '1' and process = 'PP' "
        sQL = sQL & " order by seq "

        Dim objSQL As sQLDB = New sQLDB(SQLConStr)

        Try
            Dim dt As DataTable = objSQL.GetSQLDataTable(sQL)

            If dt.Rows.Count = 0 Then
                Return Nothing
            Else
                Return dt
            End If

        Catch e As Exception
            Throw New Exception(e.Message)
        End Try
    End Function

    Public Function GetPanelInfo(PanelId As String, ByVal IsTop As Boolean) As DataTable
        Dim sModel As String



        sModel = GetModel(PanelId)


        'Dim dt As DataTable
        'dt = ErrIq.DT_DataTable
        'dt.Columns.Add("FinalResult")
        'Dim arrResult As String() = ErrIq.StringArray
        'Dim i As Integer
        'For i = 1 To arrResult.Length - 1
        '    Dim dr As DataRow()

        '    If IsTop = True Then
        '        dr = dt.Select("IsTopSide=True  and SequenceID = " & i.ToString())
        '    Else
        '        dr = dt.Select("IsTopSide=False  and SequenceID = " & i.ToString())
        '    End If

        '    If arrResult(i) <> "" Then
        '        dr(0)("FinalResult") = "True"
        '    Else
        '        dr(0)("FinalResult") = "False"
        '    End If
        'Next
        'Return dt        


    End Function
    'Public Function SaveResultToBMSvr(dt As DataTable, EN As String, ByVal sModel As String) As Boolean
    '    'Dim Sub_Program As New MBTSdb_dll.MBTS_dbFunction
    '    'Dim BM_Data As BadMark_QueryData = Nothing
    '    ''Dim ErrIi As ReturnErrorStage_InsertData = Sub_Program.ForceEquipmentID(CenterMachineNameTop(CenterMachineNameTopCode.ManualPP_Center_Top), "12345")
    '    ''If ErrIi.ErrorCode <> -1 Then
    '    ''    Throw New Exception(ErrIi.ErrorDescription)
    '    ''End If

    '    Dim ManualPPdata(150) As BadMark_InsertData

    '    Dim dr As DataRow() = dt.Select("IsTopSide=True")
    '    Dim I As Integer
    '    For I = 0 To dr.Count - 1
    '        If IsDBNull(dr(I)("Confirm-NG")) Then ' Update last status(before final) to BMSvr
    '            ManualPPdata(dr(I)("sequenceid")).BadMarkEndResult = dr(I)("FinalResult")
    '        Else
    '            ' Result of Final Inspection
    '            ManualPPdata(dr(I)("sequenceid")).InspectionMethodType = 2

    '            ManualPPdata(dr(I)("sequenceid")).BadMarkEndResult = dr(I)("Confirm-NG")
    '            ManualPPdata(dr(I)("sequenceid")).Detail = dr(I)("Defective-Code")
    '        End If
    '    Next

    '    Dim ErrI As ReturnErrorStage_InsertData = Sub_Program.Insert_BadMarkData_ManualPP(dt.Rows(0)("panelid"), sModel, EN, EN, ManualPPdata)

    '    If ErrI.ErrorCode <> -1 Then
    '        Throw New Exception(ErrI.ErrorDescription)
    '    Else
    '        Return True

    '    End If

    'End Function
End Class
