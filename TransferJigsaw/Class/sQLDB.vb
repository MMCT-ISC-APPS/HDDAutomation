Imports System.Data.SqlClient
Public Class sQLDB
    Dim sQLCon As String
    Public Sub New(sQLConStr As String)
        sQLCon = sQLConStr
    End Sub
    Public Function ConnectionOK() As Boolean
        Using dsCon = New SqlConnection(sQLCon)
            Try
                dsCon.Open()
                dsCon.Close()
                Return True
            Catch ex As Exception
                Throw New Exception("Error Connect To SQL : " + ex.Message)
                Return False
            End Try
        End Using
    End Function
    Public Function ExecQuery(ByVal QueryString As String) As Boolean
        Using dsCon = New SqlConnection(sQLCon)

            Try
                dsCon.Open()

                Dim myCMD As New SqlCommand

                myCMD.Connection = dsCon
                myCMD.CommandText = QueryString
                myCMD.CommandType = CommandType.Text
                myCMD.ExecuteNonQuery()

                dsCon.Close()
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Using
    End Function
    Public Function GetSQLDataTable(ByVal QueryString As String) As DataTable
        Using dsCon = New SqlConnection(sQLCon)
            Try
                dsCon.Open()
                Dim dsTmp As New DataTable
                Dim daData As SqlDataAdapter
                daData = New SqlDataAdapter(QueryString, dsCon)

                daData.Fill(dsTmp)

                If Not daData Is Nothing Then
                    daData.Dispose()
                    daData = Nothing
                End If

                Return dsTmp
                dsCon.Close()
            Catch ex As Exception
                Return Nothing
            End Try
        End Using

    End Function
    Public Function GetSQLData(ByVal QueryString As String) As DataTable
        Using dsCon = New SqlConnection(sQLCon)

            Try
                dsCon.Open()
                Dim dsTmp As New DataTable
                Dim myCMD As SqlCommand = New SqlCommand
                Dim sqlDataRead As SqlDataReader
                myCMD.Connection = dsCon
                myCMD.CommandText = QueryString
                myCMD.CommandType = CommandType.Text

                sqlDataRead = myCMD.ExecuteReader
                sqlDataRead.Read()
                dsTmp.Load(sqlDataRead)


                

                Return dsTmp
                dsCon.Close()
            Catch ex As Exception
                Return Nothing
            End Try
        End Using

    End Function

End Class