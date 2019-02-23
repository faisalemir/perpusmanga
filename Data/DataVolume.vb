Imports Model

Public Class DataVolume
    Public Function FindNumber() As String
        Return Find_Number("VL", 1)
    End Function

    Public Function GenerateNumber() As String
        Return Generate_Number("VL", 1)
    End Function

    Public Function insert(ByVal modelvol As ModelVolume) As Boolean
        sql = "INSERT INTO Volume VALUES('" & modelvol.kd_volume & "','" & modelvol.kd_buku & "', '" & modelvol.judul & "', '" & modelvol.volume & "', '" & modelvol.jumlah & "', " & _
              "'" & modelvol.jumlah & "', '" & modelvol.created_by & "', GETDATE(), NULL, NULL, 'False')"
        Return CRUD_data(sql)
    End Function

    Public Function update(ByVal modelvol As ModelVolume) As Boolean
        sql = "UPDATE Volume SET judul='" & modelvol.judul & "', volume='" & modelvol.volume & "', jumlah='" & modelvol.jumlah & "', stok='" & modelvol.stok & "', " & _
              "modified_by='" & modelvol.modified_by & "', modified_date=GETDATE() WHERE kd_volume='" & modelvol.kd_volume & "'"
        Return CRUD_data(sql)
    End Function

    Public Function updatestok(ByVal modelvol As ModelVolume) As Boolean
        sql = "UPDATE Volume SET stok='" & modelvol.tmpstok & "', modified_by='" & modelvol.modified_by & "', modified_date=GETDATE() WHERE kd_volume='" & modelvol.kd_volume & "'"
        Return CRUD_data(sql)
    End Function

    Public Function rollbackstok(ByVal modelvol As ModelVolume) As Boolean
        sql = "UPDATE Volume SET stok='" & modelvol.stok & "', modified_by='" & modelvol.modified_by & "', modified_date=GETDATE() WHERE kd_volume='" & modelvol.kd_volume & "'"
        Return CRUD_data(sql)
    End Function

    Public Function delete(ByVal modelvol As ModelVolume) As Boolean
        sql = "UPDATE Volume SET is_deleted='True', modified_by='" & modelvol.modified_by & "', modified_date=GETDATE() WHERE kd_volume = '" & modelvol.kd_volume & "'"
        Return CRUD_data(sql)
    End Function

    Public Function selectall() As List(Of ModelVolume)
        Dim modelvol As List(Of ModelVolume)
        Dim databku As New DataBuku

        sql = "SELECT * FROM Volume WHERE is_deleted='False'"
        dtTable = get_dtTable(sql)

        modelvol = (From row As DataRow In dtTable.Rows
                  Select New ModelVolume() With
                         {.kd_volume = row("kd_volume").ToString,
                          .kd_buku = row("kd_buku").ToString,
                          .judul = row("judul").ToString,
                          .volume = Val(row("volume")),
                          .jumlah = Val(row("jumlah")),
                          .stok = Val(row("stok")),
                          .created_by = row("created_by").ToString,
                          .created_date = row("created_date"),
                          .buku = databku.selectbykode(.kd_buku)
                         }
                     ).ToList
        Return modelvol
    End Function

    Public Function selectbykode(ByVal kode As String) As ModelVolume
        Dim modelvol As New ModelVolume
        Dim databku As New DataBuku

        sql = "SELECT * FROM Volume WHERE kd_volume='" & kode & "' AND is_deleted='False'"
        dtTable = get_dtTable(sql)

        If Not dtTable.Rows.Count = 0 Then
            With modelvol
                .kd_volume = dtTable.Rows.Item(0).Item("kd_volume")
                .kd_buku = dtTable.Rows.Item(0).Item("kd_buku")
                .judul = dtTable.Rows.Item(0).Item("judul")
                .volume = dtTable.Rows.Item(0).Item("volume")
                .jumlah = dtTable.Rows.Item(0).Item("jumlah")
                .stok = dtTable.Rows.Item(0).Item("stok")
                .created_by = dtTable.Rows.Item(0).Item("created_by")
                .created_date = dtTable.Rows.Item(0).Item("created_date")
                If Not IsDBNull(dtTable.Rows.Item(0).Item("modified_by")) Then
                    .modified_by = dtTable.Rows.Item(0).Item("modified_by")
                    .modified_date = dtTable.Rows.Item(0).Item("modified_date")
                End If
                .buku = databku.selectbykode(.kd_buku)
            End With
        End If
        Return modelvol
    End Function

    Public Function pencarian(ByVal kode As String) As List(Of ModelVolume)
        Dim modelvol As List(Of ModelVolume)
        Dim databku As New DataBuku
        sql = "SELECT * FROM Volume WHERE kd_buku='" & kode & "' AND is_deleted='False' ORDER BY volume DESC"
        dtTable = get_dtTable(sql)

        modelvol = (From row As DataRow In dtTable.Rows
                  Select New ModelVolume() With
                         {.kd_volume = row("kd_volume").ToString,
                          .kd_buku = row("kd_buku").ToString,
                          .judul = row("judul").ToString,
                          .volume = Val(row("volume")),
                          .jumlah = Val(row("jumlah")),
                          .stok = Val(row("stok")),
                          .created_by = row("created_by").ToString,
                          .created_date = row("created_date"),
                          .buku = databku.selectbykode(.kd_buku)
                         }
                ).ToList
        Return modelvol
    End Function

    Public Function selectbyVolume(ByVal kode As String) As List(Of ModelVolume)
        Dim modelvol As List(Of ModelVolume)
        Dim databku As New DataBuku
        sql = "SELECT * FROM Volume WHERE kd_volume='" & kode & "' AND is_deleted='False' ORDER BY volume DESC"
        dtTable = get_dtTable(sql)

        modelvol = (From row As DataRow In dtTable.Rows
                  Select New ModelVolume() With
                         {.kd_volume = row("kd_volume").ToString,
                          .kd_buku = row("kd_buku").ToString,
                          .judul = row("judul").ToString,
                          .volume = Val(row("volume")),
                          .jumlah = Val(row("jumlah")),
                          .stok = Val(row("stok")),
                          .created_by = row("created_by").ToString,
                          .created_date = row("created_date"),
                          .ket = Val(row("stok")),
                          .buku = databku.selectbykode(.kd_buku)
                         }
                ).ToList
        Return modelvol
    End Function
End Class
