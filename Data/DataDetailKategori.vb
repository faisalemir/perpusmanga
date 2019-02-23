Imports Model

Public Class DataDetailKategori
    Public Function insert(ByVal modeldkg As ModelDetailKategori) As Boolean
        sql = "INSERT INTO Detail_Kategori VALUES ('" & modeldkg.kd_buku & "', '" & modeldkg.kd_kategori & "', " & _
              "'" & modeldkg.created_by & "', GETDATE(), NULL,  NULL, 'False')"
        Return CRUD_data(sql)
    End Function

    Public Function update(ByVal modeldkg As ModelDetailKategori) As Boolean
        sql = "UPDATE Detail_Kategori SET is_deleted='False', modified_by='" & modeldkg.modified_by & "', modified_date=GETDATE() " & _
              "WHERE kd_buku='" & modeldkg.kd_buku & "' AND kd_kategori='" & modeldkg.kd_kategori & "'"
        Return CRUD_data(sql)
    End Function

    Public Function delete(ByVal modeldkg As ModelDetailKategori) As Boolean
        sql = "UPDATE Detail_Kategori SET is_deleted='True', modified_by='" & modeldkg.modified_by & "', modified_date=GETDATE() " & _
              "WHERE kd_buku='" & modeldkg.kd_buku & "'"
        Return CRUD_data(sql)
    End Function

    Public Function undelete(ByVal modeldkg As ModelDetailKategori) As Boolean
        sql = "UPDATE Detail_Kategori SET is_deleted='False', modified_by='" & modeldkg.modified_by & "', modified_date=GETDATE() " & _
              "WHERE kd_buku='" & modeldkg.kd_buku & "'"
        Return CRUD_data(sql)
    End Function

    Public Function selectall() As List(Of ModelDetailKategori)
        Dim dataktg As New DataKategori
        Dim databku As New DataBuku
        Dim modeldkg As List(Of ModelDetailKategori)
        sql = "SELECT * FROM Detail_Kategori WHERE is_deleted='False'"
        dtTable = get_dtTable(sql)

        modeldkg = (From row As DataRow In dtTable.Rows
                  Select New ModelDetailKategori() With
                         {.kd_buku = row("kd_buku").ToString,
                          .kd_kategori = row("kd_kategori").ToString,
                          .created_by = row("created_by").ToString,
                          .created_date = row("created_date"),
                          .buku = databku.selectbykode(.kd_buku),
                          .kategori = dataktg.selectbykode(.kd_kategori)
                         }
                ).ToList
        Return modeldkg
    End Function

    Public Function selectbykode(ByVal kd_buku As String, ByVal kd_kategori As String) As ModelDetailKategori
        Dim dataktg As New DataKategori
        Dim databku As New DataBuku
        Dim modeldkg As New ModelDetailKategori

        sql = "SELECT * FROM Detail_Kategori WHERE kd_buku='" & modeldkg.kd_buku & "' AND kd_kategori='" & modeldkg.kd_kategori & "' AND is_deleted='False'"
        dtTable = get_dtTable(sql)

        If Not dtTable.Rows.Count = 0 Then
            With modeldkg
                .kd_buku = dtTable.Rows.Item(0).Item("kd_buku")
                .kd_kategori = dtTable.Rows.Item(0).Item("kd_kategori")
                .created_by = dtTable.Rows.Item(0).Item("created_by")
                .created_date = dtTable.Rows.Item(0).Item("created_date")
                If Not IsDBNull(dtTable.Rows.Item(0).Item("modified_by")) Then
                    .modified_by = dtTable.Rows.Item(0).Item("modified_by")
                    .modified_date = dtTable.Rows.Item(0).Item("modified_date")
                End If
                .kategori = dataktg.selectbykode(.kd_kategori)
                .buku = databku.selectbykode(.kd_buku)
            End With
        End If

        Return modeldkg
    End Function

    Public Function selectbyKategori(ByVal kd_kategori As String) As List(Of ModelDetailKategori)
        Dim dataktg As New DataKategori
        Dim databku As New DataBuku
        Dim modeldkg As List(Of ModelDetailKategori)
        sql = "SELECT * FROM Detail_Kategori WHERE kd_kategori='" & kd_kategori & "' AND is_deleted='False'"
        dtTable = get_dtTable(sql)

        modeldkg = (From row As DataRow In dtTable.Rows
                  Select New ModelDetailKategori() With
                         {.kd_buku = row("kd_buku").ToString,
                          .kd_kategori = row("kd_kategori").ToString,
                          .created_by = row("created_by").ToString,
                          .created_date = row("created_date").ToString,
                          .buku = databku.selectbykode(.kd_buku),
                          .kategori = dataktg.selectbykode(.kd_kategori)
                         }
                ).ToList
        Return modeldkg
    End Function

    Public Function selectbyBuku(ByVal kd_buku As String) As List(Of ModelDetailKategori)
        Dim modeldkg As List(Of ModelDetailKategori)
        Dim dataktg As New DataKategori
        Dim databku As New DataBuku

        sql = "SELECT * FROM Detail_Kategori WHERE kd_buku='" & kd_buku & "' AND is_deleted='False'"
        dtTable = get_dtTable(sql)

        modeldkg = (From row As DataRow In dtTable.Rows
                  Select New ModelDetailKategori() With
                         {.kd_buku = row("kd_buku").ToString,
                          .kd_kategori = row("kd_kategori").ToString,
                          .created_by = row("created_by").ToString,
                          .created_date = row("created_date"),
                          .buku = databku.selectbykode(.kd_buku),
                          .kategori = dataktg.selectbykode(.kd_kategori)
                         }
                ).ToList

        Return modeldkg
    End Function
End Class
