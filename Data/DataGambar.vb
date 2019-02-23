Imports Model

Public Class DataGambar
    Public Function FindNumber() As String
        Return Find_Number("GB", 0)
    End Function

    Public Function GenerateNumber() As String
        Return Generate_Number("GB", 0)
    End Function

    Public Function insert(ByVal modelgbr As ModelGambar) As Boolean
        sql = "INSERT INTO Gambar VALUES('" & modelgbr.kd_gambar & "', '" & modelgbr.nama & "', '" & modelgbr.created_by & "', GETDATE(), NULL, NULL, 'False')"
        Return CRUD_data(sql)
    End Function

    Public Function update(ByVal modelgbr As ModelGambar) As Boolean
        sql = "UPDATE Gambar SET nama='" & modelgbr.nama & "', modified_by='" & modelgbr.modified_by & "', modified_date=GETDATE() WHERE kd_gambar='" & modelgbr.kd_gambar & "'"
        Return CRUD_data(sql)
    End Function

    Public Function delete(ByVal modelgbr As ModelGambar) As Boolean
        sql = "UPDATE Gambar SET is_deleted='True', modified_by='" & modelgbr.modified_by & "', modified_date=GETDATE() WHERE kd_Gambar = '" & modelgbr.kd_gambar & "'"
        Return CRUD_data(sql)
    End Function

    Public Function undelete(ByVal modelgbr As ModelGambar) As Boolean
        sql = "UPDATE Gambar SET is_deleted='False', modified_by='" & modelgbr.modified_by & "', modified_date=GETDATE() WHERE kd_Gambar = '" & modelgbr.kd_gambar & "'"
        Return CRUD_data(sql)
    End Function

    Public Function truedelete(ByVal modelgbr As ModelGambar) As Boolean
        sql = "DELETE Gambar WHERE kd_Gambar = '" & modelgbr.kd_gambar & "'"
        Return CRUD_data(sql)
    End Function

    Public Function selectall() As List(Of ModelGambar)
        Dim modelgbr As List(Of ModelGambar)

        sql = "SELECT * FROM Gambar WHERE is_deleted='False'"
        dtTable = get_dtTable(sql)

        modelgbr = (From row As DataRow In dtTable.Rows
                  Select New ModelGambar() With
                         {.kd_gambar = row("kd_gambar").ToString,
                          .nama = row("nama").ToString,
                          .created_by = row("created_by").ToString,
                          .created_date = row("created_date").ToString,
                          .modified_by = row("modified_by").ToString,
                          .modified_date = row("modified_date")
                         }
                ).ToList

        konek.Close()
        Return modelgbr
    End Function

    Public Function selectbykode(ByVal kode As String) As ModelGambar
        Dim modelgbr As New ModelGambar

        sql = "SELECT * FROM Gambar WHERE kd_Gambar='" & kode & "' AND is_deleted='False'"
        dtTable = get_dtTable(sql)

        If Not dtTable.Rows.Count = 0 Then
            With modelgbr
                .kd_gambar = dtTable.Rows.Item(0).Item("kd_gambar")
                .nama = dtTable.Rows.Item(0).Item("nama").ToString
                .created_by = dtTable.Rows.Item(0).Item("created_by")
                .created_date = dtTable.Rows.Item(0).Item("created_date")
                If Not IsDBNull(dtTable.Rows.Item(0).Item("modified_by")) Then
                    .modified_by = dtTable.Rows.Item(0).Item("modified_by")
                    .modified_date = dtTable.Rows.Item(0).Item("modified_date")
                End If
            End With
        End If
        Return modelgbr
    End Function
End Class
