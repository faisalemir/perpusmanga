Imports Model

Public Class DataHakAkses
    Public Function selectall() As List(Of ModelHakAkses)
        Dim dataaks As List(Of ModelHakAkses)
        sql = "SELECT * FROM Akses"
        dtTable = get_dtTable(sql)

        dataaks = (From row As DataRow In dtTable.Rows
                  Select New ModelHakAkses() With
                         {.kd_akses = row("kd_akses"),
                          .akses = row("akses").ToString
                         }
                ).ToList

        konek.Close()
        Return dataaks
    End Function
    Public Function selectbykode(ByVal kode As Boolean) As ModelHakAkses
        Dim dataaks As New ModelHakAkses

        sql = "SELECT * FROM Akses WHERE kd_akses='" & kode & "'"
        dtTable = get_dtTable(sql)
        With dataaks
            .kd_akses = dtTable.Rows.Item(0).Item("kd_akses")
            .akses = dtTable.Rows.Item(0).Item("akses")
        End With
        Return dataaks
    End Function
End Class
