Imports Model
Imports System.Data
Imports System.Data.SqlClient

Public Class DataDetailPinjam
    Public Function insert(ByVal modeldpm As ModelDetailPinjam) As Boolean
        sql = "INSERT INTO Detail_Pinjam VALUES ('" & modeldpm.kd_pinjam & "', '" & modeldpm.kd_volume & "', '" & modeldpm.kd_denda & "', '" & modeldpm.jumlah & "'," & _
              "'" & modeldpm.tgl_kembali & "', NULL, " & modeldpm.sub_total & ", '" & modeldpm.created_by & "', GETDATE(), NULL, NULL, 'False')"
        Return CRUD_data(sql)
    End Function

    Public Function update(ByVal modeldpm As ModelDetailPinjam) As Boolean
        sql = "UPDATE Detail_Pinjam SET tgl_pengembalian=GETDATE(), sub_total='" & modeldpm.sub_total & "', modified_by='" & modeldpm.created_by & "', modified_date=GETDATE()  WHERE kd_pinjam='" & modeldpm.kd_pinjam & "' AND kd_volume = '" & modeldpm.kd_volume & "' AND is_deleted='False'"
        Return CRUD_data(sql)
    End Function

    Public Function rollback(ByVal modeldpm As ModelDetailPinjam) As Boolean
        sql = "UPDATE Detail_Pinjam SET tgl_pengembalian=NULL, sub_total=0, modified_by='" & modeldpm.created_by & "', modified_date=GETDATE()  WHERE kd_pinjam='" & modeldpm.kd_pinjam & "' AND kd_volume = '" & modeldpm.kd_volume & "' AND is_deleted='False'"
        Return CRUD_data(sql)
    End Function

    Public Function delete(ByVal modeldpm As ModelDetailPinjam) As Boolean
        sql = "UPDATE Detail_Pinjam SET is_deleted='True', modified_by='" & modeldpm.created_by & "', modified_date=GETDATE()  WHERE kd_pinjam = '" & modeldpm.kd_pinjam & "' AND kd_volume = '" & modeldpm.kd_volume & "'"
        Return CRUD_data(sql)
    End Function

    Public Function selectall() As List(Of ModelDetailPinjam)
        Dim modeldpm As List(Of ModelDetailPinjam)
        Dim datadnd As New DataDenda
        Dim datavol As New DataVolume
        Dim datapjm As New DataPinjam

        sql = "SELECT * FROM Detail_Pinjam WHERE is_deleted='False'"
        dtTable = get_dtTable(sql)

        Try
            modeldpm = (From row As DataRow In dtTable.Rows
                      Select New ModelDetailPinjam() With
                             {.kd_pinjam = row("kd_pinjam").ToString,
                              .kd_volume = row("kd_volume").ToString,
                              .kd_denda = row("kd_denda").ToString,
                              .jumlah = Val(row("jumlah")),
                              .tgl_kembali = row("tgl_kembali"),
                              .tgl_pengembalian = row("tgl_pengembalian"),
                              .sub_total = Val(row("sub_total")),
                              .created_by = row("created_by").ToString,
                              .created_date = row("created_date"),
                              .volume = datavol.selectbykode(.kd_volume),
                              .denda = datadnd.selectbykode(.kd_denda),
                              .pinjam = datapjm.selectbykode(.kd_pinjam)
                             }
                    ).ToList
            Return modeldpm
        Catch ex As Exception
            modeldpm = (From row As DataRow In dtTable.Rows
                      Select New ModelDetailPinjam() With
                             {.kd_pinjam = row("kd_pinjam").ToString,
                              .kd_volume = row("kd_volume").ToString,
                              .kd_denda = row("kd_denda").ToString,
                              .jumlah = Val(row("jumlah")),
                              .tgl_kembali = row("tgl_kembali"),
                              .sub_total = Val(row("sub_total")),
                              .created_by = row("created_by").ToString,
                              .created_date = row("created_date"),
                              .volume = datavol.selectbykode(.kd_volume),
                              .denda = datadnd.selectbykode(.kd_denda),
                              .pinjam = datapjm.selectbykode(.kd_pinjam)
                             }
                    ).ToList
            Return modeldpm
        End Try
    End Function

    Public Function selectbykode(ByVal kd_pinjam As String, ByVal kd_volume As String) As ModelDetailPinjam
        Dim modeldpm As New ModelDetailPinjam
        Dim datadnd As New DataDenda
        Dim datavol As New DataVolume
        Dim datapjm As New DataPinjam

        sql = "SELECT * FROM Detail_Pinjam WHERE kd_pinjam='" & kd_pinjam & "' AND kd_volume='" & kd_volume & "'"
        dtTable = get_dtTable(sql)

        If Not dtTable.Rows.Count = 0 Then
            With modeldpm
                .kd_pinjam = dtTable.Rows.Item(0).Item("kd_pinjam")
                .kd_volume = dtTable.Rows.Item(0).Item("kd_volume")
                .kd_denda = dtTable.Rows.Item(0).Item("kd_denda")
                .tgl_kembali = dtTable.Rows.Item(0).Item("tgl_kembali")
                .tgl_pengembalian = dtTable.Rows.Item(0).Item("tgl_pengembalian")
                .sub_total = Val(dtTable.Rows.Item(0).Item("sub_total"))
                .created_by = dtTable.Rows.Item(0).Item("created_by")
                .created_date = dtTable.Rows.Item(0).Item("created_date")
                If Not IsDBNull(dtTable.Rows.Item(0).Item("modified_by")) Then
                    .modified_by = dtTable.Rows.Item(0).Item("modified_by")
                    .modified_date = dtTable.Rows.Item(0).Item("modified_date")
                End If
                .volume = datavol.selectbykode(.kd_volume)
                .denda = datadnd.selectbykode(.kd_denda)
                .pinjam = datapjm.selectbykode(.kd_pinjam)
            End With
        End If
        Return modeldpm
    End Function

    Public Function selectbyPinjam(ByVal kd_pinjam As String) As List(Of ModelDetailPinjam)
        Dim modeldpm As List(Of ModelDetailPinjam)
        Dim datadnd As New DataDenda
        Dim datavol As New DataVolume
        Dim datapjm As New DataPinjam

        sql = "SELECT * FROM Detail_Pinjam WHERE kd_pinjam='" & kd_pinjam & "' AND is_deleted='False'"
        dtTable = get_dtTable(sql)
        Try
            modeldpm = (From row As DataRow In dtTable.Rows
                      Select New ModelDetailPinjam() With
                             {.kd_pinjam = row("kd_pinjam").ToString,
                              .kd_volume = row("kd_volume").ToString,
                              .kd_denda = row("kd_denda").ToString,
                              .jumlah = Val(row("jumlah")),
                              .tgl_kembali = row("tgl_kembali"),
                              .tgl_pengembalian = row("tgl_pengembalian"),
                              .sub_total = Val(row("sub_total")),
                              .created_by = row("created_by").ToString,
                              .created_date = row("created_date"),
                              .volume = datavol.selectbykode(.kd_volume),
                              .denda = datadnd.selectbykode(.kd_denda),
                              .pinjam = datapjm.selectbykode(.kd_pinjam)
                             }
                    ).ToList
            Return modeldpm
        Catch ex As Exception
            sql = "SELECT * FROM Detail_Pinjam WHERE kd_pinjam='" & kd_pinjam & "' AND is_deleted='False'"
            dtTable = get_dtTable(sql)
            modeldpm = (From row As DataRow In dtTable.Rows
                      Select New ModelDetailPinjam() With
                             {.kd_pinjam = row("kd_pinjam").ToString,
                              .kd_volume = row("kd_volume").ToString,
                              .kd_denda = row("kd_denda").ToString,
                              .jumlah = Val(row("jumlah")),
                              .tgl_kembali = row("tgl_kembali"),
                              .sub_total = Val(row("sub_total")),
                              .created_by = row("created_by").ToString,
                              .created_date = row("created_date"),
                              .volume = datavol.selectbykode(.kd_volume),
                              .denda = datadnd.selectbykode(.kd_denda),
                              .pinjam = datapjm.selectbykode(.kd_pinjam)
                             }
                    ).ToList
            Return modeldpm
        End Try
    End Function

    Public Function selectbyPinjamNull(ByVal kd_pinjam As String) As List(Of ModelDetailPinjam)
        Dim modeldpm As List(Of ModelDetailPinjam)
        Dim datadnd As New DataDenda
        Dim datavol As New DataVolume
        Dim datapjm As New DataPinjam

        sql = "SELECT * FROM Detail_Pinjam WHERE kd_pinjam='" & kd_pinjam & "' AND tgl_pengembalian IS NULL AND is_deleted='False'"
        dtTable = get_dtTable(sql)
        Try
            modeldpm = (From row As DataRow In dtTable.Rows
                      Select New ModelDetailPinjam() With
                             {.kd_pinjam = row("kd_pinjam").ToString,
                              .kd_volume = row("kd_volume").ToString,
                              .kd_denda = row("kd_denda").ToString,
                              .jumlah = Val(row("jumlah")),
                              .tgl_kembali = row("tgl_kembali"),
                              .tgl_pengembalian = row("tgl_pengembalian"),
                              .sub_total = Val(row("sub_total")),
                              .created_by = row("created_by").ToString,
                              .created_date = row("created_date"),
                              .volume = datavol.selectbykode(.kd_volume),
                              .denda = datadnd.selectbykode(.kd_denda),
                              .pinjam = datapjm.selectbykode(.kd_pinjam)
                             }
                    ).ToList
            Return modeldpm
        Catch ex As Exception
            sql = "SELECT * FROM Detail_Pinjam WHERE kd_pinjam='" & kd_pinjam & "' AND tgl_pengembalian IS NULL AND is_deleted='False'"
            dtTable = get_dtTable(sql)
            modeldpm = (From row As DataRow In dtTable.Rows
                      Select New ModelDetailPinjam() With
                             {.kd_pinjam = row("kd_pinjam").ToString,
                              .kd_volume = row("kd_volume").ToString,
                              .kd_denda = row("kd_denda").ToString,
                              .jumlah = Val(row("jumlah")),
                              .tgl_kembali = row("tgl_kembali"),
                              .sub_total = Val(row("sub_total")),
                              .created_by = row("created_by").ToString,
                              .created_date = row("created_date"),
                              .volume = datavol.selectbykode(.kd_volume),
                              .denda = datadnd.selectbykode(.kd_denda),
                              .pinjam = datapjm.selectbykode(.kd_pinjam)
                             }
                    ).ToList
            Return modeldpm
        End Try
    End Function

    Public Function selectbyPinjamNotNull(ByVal kd_pinjam As String) As List(Of ModelDetailPinjam)
        Dim modeldpm As List(Of ModelDetailPinjam)
        Dim datadnd As New DataDenda
        Dim datavol As New DataVolume
        Dim datapjm As New DataPinjam

        sql = "SELECT * FROM Detail_Pinjam WHERE kd_pinjam='" & kd_pinjam & "' AND tgl_pengembalian IS NOT NULL AND is_deleted='False'"
        dtTable = get_dtTable(sql)
        Try
            modeldpm = (From row As DataRow In dtTable.Rows
                      Select New ModelDetailPinjam() With
                             {.kd_pinjam = row("kd_pinjam").ToString,
                              .kd_volume = row("kd_volume").ToString,
                              .kd_denda = row("kd_denda").ToString,
                              .jumlah = Val(row("jumlah")),
                              .tgl_kembali = row("tgl_kembali"),
                              .tgl_pengembalian = row("tgl_pengembalian"),
                              .sub_total = Val(row("sub_total")),
                              .created_by = row("created_by").ToString,
                              .created_date = row("created_date"),
                              .volume = datavol.selectbykode(.kd_volume),
                              .denda = datadnd.selectbykode(.kd_denda),
                              .pinjam = datapjm.selectbykode(.kd_pinjam)
                             }
                    ).ToList
            Return modeldpm
        Catch ex As Exception
            sql = "SELECT * FROM Detail_Pinjam WHERE kd_pinjam='" & kd_pinjam & "' AND tgl_pengembalian IS NOT NULL AND is_deleted='False'"
            dtTable = get_dtTable(sql)
            modeldpm = (From row As DataRow In dtTable.Rows
                      Select New ModelDetailPinjam() With
                             {.kd_pinjam = row("kd_pinjam").ToString,
                              .kd_volume = row("kd_volume").ToString,
                              .kd_denda = row("kd_denda").ToString,
                              .jumlah = Val(row("jumlah")),
                              .tgl_kembali = row("tgl_kembali"),
                              .sub_total = Val(row("sub_total")),
                              .created_by = row("created_by").ToString,
                              .created_date = row("created_date"),
                              .volume = datavol.selectbykode(.kd_volume),
                              .denda = datadnd.selectbykode(.kd_denda),
                              .pinjam = datapjm.selectbykode(.kd_pinjam)
                             }
                    ).ToList
            Return modeldpm
        End Try
    End Function

    Public Function selectbyVolume(ByVal kd_volume As String) As List(Of ModelDetailPinjam)
        Dim modeldpm As List(Of ModelDetailPinjam)
        Dim datadnd As New DataDenda
        Dim datavol As New DataVolume
        Dim datapjm As New DataPinjam

        sql = "SELECT * FROM Detail_Pinjam WHERE kd_volume='" & kd_volume & "' AND is_deleted='False'"
        dtTable = get_dtTable(sql)

        Try
            modeldpm = (From row As DataRow In dtTable.Rows
                      Select New ModelDetailPinjam() With
                             {.kd_pinjam = row("kd_pinjam").ToString,
                              .kd_volume = row("kd_volume").ToString,
                              .kd_denda = row("kd_denda").ToString,
                              .jumlah = Val(row("jumlah")),
                              .tgl_kembali = row("tgl_kembali"),
                              .tgl_pengembalian = row("tgl_pengembalian"),
                              .sub_total = Val(row("sub_total")),
                              .created_by = row("created_by").ToString,
                              .created_date = row("created_date"),
                              .volume = datavol.selectbykode(.kd_volume),
                              .denda = datadnd.selectbykode(.kd_denda),
                              .pinjam = datapjm.selectbykode(.kd_pinjam)
                             }
                    ).ToList
            Return modeldpm
        Catch ex As Exception
            sql = "SELECT * FROM Detail_Pinjam WHERE kd_volume='" & kd_volume & "' AND is_deleted='False'"
            dtTable = get_dtTable(sql)
            modeldpm = (From row As DataRow In dtTable.Rows
                      Select New ModelDetailPinjam() With
                             {.kd_pinjam = row("kd_pinjam").ToString,
                              .kd_volume = row("kd_volume").ToString,
                              .kd_denda = row("kd_denda").ToString,
                              .jumlah = Val(row("jumlah")),
                              .tgl_kembali = row("tgl_kembali"),
                              .sub_total = Val(row("sub_total")),
                              .created_by = row("created_by").ToString,
                              .created_date = row("created_date"),
                              .volume = datavol.selectbykode(.kd_volume),
                              .denda = datadnd.selectbykode(.kd_denda),
                              .pinjam = datapjm.selectbykode(.kd_pinjam)
                             }
                    ).ToList
            Return modeldpm
        End Try
    End Function

    Public Function selectbyDenda(ByVal kd_denda As String) As List(Of ModelDetailPinjam)
        Dim modeldpm As List(Of ModelDetailPinjam)
        Dim datadnd As New DataDenda
        Dim datavol As New DataVolume
        Dim datapjm As New DataPinjam

        sql = "SELECT * FROM Detail_Pinjam WHERE kd_denda='" & kd_denda & "' AND is_deleted='False'"
        dtTable = get_dtTable(sql)

        Try
            modeldpm = (From row As DataRow In dtTable.Rows
                      Select New ModelDetailPinjam() With
                             {.kd_pinjam = row("kd_pinjam").ToString,
                              .kd_volume = row("kd_volume").ToString,
                              .kd_denda = row("kd_denda").ToString,
                              .jumlah = Val(row("jumlah")),
                              .tgl_kembali = row("tgl_kembali"),
                              .tgl_pengembalian = row("tgl_pengembalian"),
                              .sub_total = Val(row("sub_total")),
                              .created_by = row("created_by").ToString,
                              .created_date = row("created_date"),
                              .volume = datavol.selectbykode(.kd_volume),
                              .denda = datadnd.selectbykode(.kd_denda),
                              .pinjam = datapjm.selectbykode(.kd_pinjam)
                             }
                    ).ToList
            Return modeldpm
        Catch ex As Exception
            sql = "SELECT * FROM Detail_Pinjam WHERE kd_denda='" & kd_denda & "' AND is_deleted='False'"
            dtTable = get_dtTable(sql)
            modeldpm = (From row As DataRow In dtTable.Rows
                      Select New ModelDetailPinjam() With
                             {.kd_pinjam = row("kd_pinjam").ToString,
                              .kd_volume = row("kd_volume").ToString,
                              .kd_denda = row("kd_denda").ToString,
                              .jumlah = Val(row("jumlah")),
                              .tgl_kembali = row("tgl_kembali"),
                              .sub_total = Val(row("sub_total")),
                              .created_by = row("created_by").ToString,
                              .created_date = row("created_date"),
                              .volume = datavol.selectbykode(.kd_volume),
                              .denda = datadnd.selectbykode(.kd_denda),
                              .pinjam = datapjm.selectbykode(.kd_pinjam)
                             }
                    ).ToList
            Return modeldpm
        End Try
    End Function
End Class
