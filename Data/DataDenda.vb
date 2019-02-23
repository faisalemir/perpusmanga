Imports Model
Imports System.Data
Imports System.Data.SqlClient

Public Class DataDenda
    Public Function FindNumber() As String
        Return Find_Number("DD", 1)
    End Function

    Public Function GenerateNumber() As String
        Return Generate_Number("DD", 1)
    End Function

    Public Function insert(ByVal modeldnd As ModelDenda) As Boolean
        sql = "INSERT INTO denda VALUES ('" & modeldnd.kd_denda & "',  '" & modeldnd.denda & "', '" & modeldnd.created_by & "', GETDATE(), NULL, NULL, 'False');"
        Return CRUD_data(sql)
    End Function

    Public Function update(ByVal modeldnd As ModelDenda) As Boolean
        sql = "UPDATE denda SET modified_by='" & modeldnd.modified_by & "', modified_date=GETDATE(), is_deleted='True' WHERE kd_denda='" & get_kdDenda("SELECT kd_denda FROM Denda WHERE is_deleted='False'") & "'"
        Return CRUD_data(sql)
    End Function

    Public Function rollback(ByVal modeldnd As ModelDenda) As Boolean
        sql = "UPDATE denda SET modified_by='" & modeldnd.modified_by & "', modified_date=GETDATE(), is_deleted='False' WHERE kd_denda='" & get_kdDenda("SELECT kd_denda FROM Denda WHERE is_deleted='False'") & "'"
        Return CRUD_data(sql)
    End Function

    Public Function truedelete(ByVal modeldnd As ModelDenda) As Boolean
        sql = "DELETE denda WHERE kd_denda='" & modeldnd.kd_denda & "'"
        Return CRUD_data(sql)
    End Function

    Public Function selectFalse() As ModelDenda
        Dim modeldnd As New ModelDenda
        sql = "SELECT * FROM Denda WHERE is_deleted='False'"
        dtTable = get_dtTable(sql)

        With modeldnd
            .kd_denda = dtTable.Rows.Item(0).Item("kd_denda").ToString
            .denda = Val(dtTable.Rows.Item(0).Item("denda"))
            .created_by = dtTable.Rows.Item(0).Item("created_by").ToString
            .created_date = dtTable.Rows.Item(0).Item("created_date")
            Try
                .modified_by = dtTable.Rows.Item(0).Item("modified_by").ToString
                .modified_date = dtTable.Rows.Item(0).Item("modified_date")
            Catch ex As Exception

            End Try
        End With
        Return modeldnd
    End Function

    Public Function selectbykode(ByVal kode As String) As ModelDenda
        Dim modeldnd As New ModelDenda
        sql = "SELECT * FROM Denda WHERE kd_denda='" & kode & "'"
        dtTable = get_dtTable(sql)

        With modeldnd
            .kd_denda = dtTable.Rows.Item(0).Item("kd_denda").ToString
            .denda = Val(dtTable.Rows.Item(0).Item("denda"))
            .created_by = dtTable.Rows.Item(0).Item("created_by").ToString
            .created_date = dtTable.Rows.Item(0).Item("created_date")
            Try
                .modified_by = dtTable.Rows.Item(0).Item("modified_by").ToString
                .modified_date = dtTable.Rows.Item(0).Item("modified_date")
            Catch ex As Exception

            End Try
        End With
        Return modeldnd
    End Function
End Class
