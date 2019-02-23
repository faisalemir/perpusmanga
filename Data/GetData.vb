Imports Model
Imports System.Data.SqlClient
Imports System.Data

Module GetData
    Function get_dtTable(ByVal sql As String) As DataTable
        Try
            koneksidatabase()
            konek.Open()
            cmd = New SqlCommand(sql, konek)
            dtAdapter = New SqlDataAdapter
            dtAdapter.SelectCommand = cmd

            Dim dtTable = New DataTable
            dtAdapter.Fill(dtTable)
            Return dtTable
        Catch ex As Exception
            Return dtTable
        Finally
            konek.Close()
        End Try
    End Function

    Function CRUD_data(ByVal sql As String)
        Dim nilaiku As String = ""
        Try
            koneksidatabase()
            konek.Open()
            cmd = New SqlCommand(sql, konek)
            cmd.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            Return False
        Finally
            konek.Close()
        End Try
    End Function

    Function get_kdDenda(ByVal sql As String)
        Dim tmp As String = Nothing
        Try
            koneksidatabase()
            konek.Open()
            cmd = New SqlCommand(sql, konek)
            tmp = cmd.ExecuteScalar
            Return tmp
        Catch ex As Exception
            konek.Close()
            Return False
        Finally
            konek.Close()
        End Try
    End Function

    Function Find_Number(ByVal ket As String, ByVal tipe As Integer)
        Dim tmp As String = Nothing
        Try
            koneksidatabase()
            konek.Open()
            cmd.Connection = konek
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "FindNumber"
            cmd.Parameters.AddWithValue("@kd_trans", ket)
            cmd.Parameters.AddWithValue("@jenis", tipe)
            tmp = cmd.ExecuteScalar()
            Return tmp
        Catch ex As Exception
            konek.Close()
            Return False
        Finally
            konek.Close()
        End Try
    End Function

    Function Generate_Number(ByVal ket As String, ByVal tipe As Integer)
        Try
            koneksidatabase()
            konek.Open()
            cmd.Connection = konek
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "GenerateNumber"
            cmd.Parameters.AddWithValue("@kd_trans", ket)
            cmd.Parameters.AddWithValue("@jenis", tipe)
            cmd.ExecuteScalar()
            Return True
        Catch ex As Exception
            konek.Close()
            Return False
        Finally
            konek.Close()
        End Try
    End Function
End Module
