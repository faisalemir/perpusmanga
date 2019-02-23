Imports Model

Public Class DataKategori
    Public Function FindNumber() As String
        Return Find_Number("KT", 1)
    End Function

    Public Function GenerateNumber() As String
        Return Generate_Number("KT", 1)
    End Function

    Public Function insert(ByVal modelktg As ModelKategori) As Boolean
        sql = "INSERT INTO Kategori VALUES ('" & modelktg.kd_kategori & "', '" & modelktg.nama & "', '" & modelktg.created_by & "', GETDATE(), NULL,  NULL, 'false')"
        Return CRUD_data(sql)
    End Function

    Public Function update(ByVal modelktg As ModelKategori) As Boolean
        sql = "UPDATE Kategori SET nama='" & modelktg.nama & "', modified_by='" & modelktg.modified_by & "', modified_date=GETDATE() " & _
              "WHERE kd_kategori='" & modelktg.kd_kategori & "'"
        Return CRUD_data(sql)
    End Function

    Public Function delete(ByVal modelktg As ModelKategori) As Boolean
        sql = "UPDATE Kategori SET is_deleted='True', modified_by='" & modelktg.modified_by & "', modified_date=GETDATE() WHERE kd_kategori = '" & modelktg.kd_kategori & "'"
        Return CRUD_data(sql)
    End Function

    Public Function selectall() As List(Of ModelKategori)
        Dim modelktg As List(Of ModelKategori)
        Dim datadtl As New DataDetailKategori
        sql = "SELECT * FROM Kategori WHERE is_deleted='False' ORDER BY nama ASC"
        dtTable = get_dtTable(sql)

        modelktg = (From row As DataRow In dtTable.Rows
                  Select New ModelKategori() With
                         {.kd_kategori = row("kd_kategori").ToString,
                          .nama = row("nama").ToString,
                          .created_by = row("created_by").ToString,
                          .created_date = row("created_date")
                         }
                ).ToList
        Return modelktg
    End Function

    Public Function selectbykode(ByVal kode As String) As ModelKategori
        Dim modelktg As New ModelKategori
        Dim datadtl As New DataDetailKategori

        sql = "SELECT * FROM Kategori WHERE kd_kategori='" & kode & "'"
        dtTable = get_dtTable(sql)

        If Not dtTable.Rows.Count = 0 Then
            With modelktg
                .kd_kategori = dtTable.Rows.Item(0).Item("kd_kategori")
                .nama = dtTable.Rows.Item(0).Item("nama")
                .created_by = dtTable.Rows.Item(0).Item("created_by")
                .created_date = dtTable.Rows.Item(0).Item("created_date")
                If Not IsDBNull(dtTable.Rows.Item(0).Item("modified_by")) Then
                    .modified_by = dtTable.Rows.Item(0).Item("modified_by")
                    .modified_date = dtTable.Rows.Item(0).Item("modified_date")
                End If
            End With
        End If
        Return modelktg
    End Function

    Public Function pencarian(ByVal kode As String) As List(Of ModelKategori)
        Dim modelktg As List(Of ModelKategori)
        Dim datadtl As New DataDetailKategori

        sql = "SELECT * FROM Kategori WHERE nama LIKE '%" & kode & "%' AND is_deleted='False' ORDER BY nama ASC"
        dtTable = get_dtTable(sql)

        modelktg = (From row As DataRow In dtTable.Rows
                  Select New ModelKategori() With
                         {.kd_kategori = row("kd_kategori").ToString,
                          .nama = row("nama").ToString,
                          .created_by = row("created_by").ToString,
                          .created_date = row("created_date")
                         }
                ).ToList
        Return modelktg
    End Function

End Class
