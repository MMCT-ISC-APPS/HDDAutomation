Public Class ClsSQLCon
    Public Function getSQLCon() As String
        Dim sCon As String = "Data Source= prdsvr;Initial Catalog=CenterConOra;User ID=sa;Password=P@ssw0rd"

        Return sCon

        ''Dim dsTmp As Data.DataTable = Nothing
        ''Dim sql = "select * from mmt_application_config where app_id=3 and app_name='Auto Packing(Dflex)' and Enable=1"
        ''sql = Sql.Replace("'", "''")
        ''sql = "select * From openquery(PROD,'" & sql & "')"

        ''Dim objSQL As sQLDB = New sQLDB(SQLConStr)

        ''Dim dtTmp As DataTable = objSQL.GetSQLDataTable(sql)



        ''If dsTmp Is Nothing Then
        ''    Return ""
        ''Else
        ''    Dim sCon As String = "Data Source=" + dsTmp.Rows(0).Item("SERVERNAME") + ";Initial Catalog=" + dsTmp.Rows(0).Item("CATALOG_NAME") + ";User ID=" + _
        ''        dsTmp.Rows(0).Item("USERNAME") + ";Password=" + dsTmp.Rows(0).Item("PASSWORD")
        ''    Return sCon
        ''End If

    End Function


End Class