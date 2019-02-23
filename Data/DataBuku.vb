Imports Model

Public Class DataBuku
    Public Function FindNumber() As String
        Return Find_Number("BK", 1)
    End Function

    Public Function GenerateNumber() As String
        Return Generate_Number("BK", 1)
    End Function

    Public Function insert(ByVal modelbku As ModelBuku) As Boolean
        sql = "INSERT INTO Buku VALUES('" & modelbku.kd_buku & "', '" & modelbku.kd_gambar & "', '" & modelbku.nama & "', '" & modelbku.tahun & "', " & _
              "'" & modelbku.pengarang & "', '" & modelbku.penulis & "', '" & modelbku.sinopsis & "', '" & modelbku.created_by & "', GETDATE(), NULL, NULL, 'False')"
        Return CRUD_data(sql)
    End Function

    Public Function update(ByVal modelbku As ModelBuku) As Boolean
        sql = "UPDATE Buku SET kd_gambar='" & modelbku.kd_gambar & "', nama='" & modelbku.nama & "', tahun='" & modelbku.tahun & "', pengarang='" & modelbku.pengarang & "', penulis='" & modelbku.penulis & "', " & _
              "sinopsis='" & modelbku.sinopsis & "', modified_by='" & modelbku.modified_by & "', modified_date=GETDATE() WHERE kd_buku='" & modelbku.kd_buku & "'"
        Return CRUD_data(sql)
    End Function

    Public Function delete(ByVal modelbku As ModelBuku) As Boolean
        sql = "UPDATE Buku SET is_deleted='True', modified_by='" & modelbku.modified_by & "', modified_date=GETDATE() WHERE kd_buku = '" & modelbku.kd_buku & "'"
        Return CRUD_data(sql)
    End Function

    Public Function truedelete(ByVal modelbku As ModelBuku) As Boolean
        sql = "DELETE Buku WHERE kd_buku = '" & modelbku.kd_buku & "'"
        Return CRUD_data(sql)
    End Function

    Public Function selectall() As List(Of ModelBuku)
        Dim modelbku As List(Of ModelBuku)
        Dim datagbr As New DataGambar

        sql = "SELECT * FROM Buku WHERE is_deleted='False'"
        dtTable = get_dtTable(sql)

        modelbku = (From row As DataRow In dtTable.Rows
                  Select New ModelBuku() With
                         {.kd_buku = row("kd_buku").ToString,
                          .kd_gambar = row("kd_gambar").ToString,
                          .nama = row("nama").ToString,
                          .tahun = Val(row("tahun")),
                          .pengarang = row("pengarang").ToString,
                          .penulis = row("penulis").ToString,
                          .sinopsis = row("sinopsis").ToString,
                          .created_by = row("created_by").ToString,
                          .created_date = row("created_date"),
                          .gambar = datagbr.selectbykode(.kd_gambar)
                         }
                ).ToList
        Return modelbku
    End Function

    Public Function selectbykode(ByVal kode As String) As ModelBuku
        Dim modelbku As New ModelBuku
        Dim datagbr As New DataGambar

        sql = "SELECT * FROM Buku WHERE kd_buku='" & kode & "' AND is_deleted='False'"
        dtTable = get_dtTable(sql)

        If Not dtTable.Rows.Count = 0 Then
            modelbku.kd_buku = dtTable.Rows.Item(0).Item("kd_buku")
            modelbku.kd_gambar = dtTable.Rows.Item(0).Item("kd_gambar")
            modelbku.nama = dtTable.Rows.Item(0).Item("nama")
            modelbku.tahun = Val(dtTable.Rows.Item(0).Item("tahun"))
            modelbku.pengarang = dtTable.Rows.Item(0).Item("pengarang")
            modelbku.penulis = dtTable.Rows.Item(0).Item("penulis")
            modelbku.sinopsis = dtTable.Rows.Item(0).Item("sinopsis")
            modelbku.created_by = dtTable.Rows.Item(0).Item("created_by")
            modelbku.created_date = dtTable.Rows.Item(0).Item("created_date")
            If Not IsDBNull(dtTable.Rows.Item(0).Item("modified_by")) Then
                modelbku.modified_by = dtTable.Rows.Item(0).Item("modified_by")
                modelbku.modified_date = dtTable.Rows.Item(0).Item("modified_date")
            End If
            modelbku.gambar = datagbr.selectbykode(modelbku.kd_gambar)
        End If
        Return modelbku
    End Function

    Public Function pencarian(ByVal kode As String) As List(Of ModelBuku)
        Dim modelbku As List(Of ModelBuku)
        Dim datagbr As New DataGambar

        sql = "SELECT * FROM Buku WHERE nama LIKE '%" & kode & "%' AND is_deleted='False'"
        dtTable = get_dtTable(sql)

        modelbku = (From row As DataRow In dtTable.Rows
                  Select New ModelBuku() With
                         {.kd_buku = row("kd_buku").ToString,
                          .kd_gambar = row("kd_gambar").ToString,
                          .nama = row("nama").ToString,
                          .tahun = Val(row("tahun")),
                          .pengarang = row("pengarang").ToString,
                          .penulis = row("penulis").ToString,
                          .sinopsis = row("sinopsis").ToString,
                          .created_by = row("created_by").ToString,
                          .created_date = row("created_date"),
                          .gambar = datagbr.selectbykode(.kd_gambar)
                         }
                ).ToList
        Return modelbku
    End Function
End Class
