Imports Model
Imports System.Data
Imports System.Data.SqlClient

Public Class DataPinjam
    Public Function FindNumber() As String
        Return Find_Number("PJ", 0)
    End Function

    Public Function GenerateNumber() As String
        Return Generate_Number("PJ", 0)
    End Function

    Public Function insert(ByVal modelpjm As ModelPinjam) As Boolean
        sql = "INSERT INTO Pinjam VALUES ('" & modelpjm.kd_pinjam & "', '" & modelpjm.kd_anggota & "', '" & modelpjm.total & "', " & _
              "'" & modelpjm.status_pinjam & "', '" & modelpjm.created_by & "', GETDATE(), NULL, NULL, 'False')"
        Return CRUD_data(sql)
    End Function

    Public Function update(ByVal modelpjm As ModelPinjam) As Boolean
        sql = "UPDATE Pinjam SET total='" & modelpjm.total & "', status_pinjam='" & modelpjm.status_pinjam & "', modified_by='" & modelpjm.modified_by & "', modified_date=GETDATE() " & _
              "WHERE kd_pinjam='" & modelpjm.kd_pinjam & "'"
        Return CRUD_data(sql)
    End Function

    Public Function rollback(ByVal modelpjm As ModelPinjam) As Boolean
        sql = "UPDATE Pinjam SET total=0, status_pinjam='False', modified_by='" & modelpjm.modified_by & "', modified_date=GETDATE() " & _
              "WHERE kd_pinjam='" & modelpjm.kd_pinjam & "'"
        Return CRUD_data(sql)
    End Function

    Public Function delete(ByVal modelpjm As ModelPinjam) As Boolean
        sql = "UPDATE Pinjam SET is_deleted='True', modified_by='" & modelpjm.modified_by & "', modified_date=GETDATE()  WHERE kd_Pinjam = '" & modelpjm.kd_pinjam & "'"
        Return CRUD_data(sql)
    End Function

    Public Function truedelete(ByVal modelpjm As ModelPinjam) As Boolean
        sql = "DELETE Pinjam WHERE kd_pinjam = '" & modelpjm.kd_pinjam & "'"
        Return CRUD_data(sql)
    End Function

    Public Function selectStatFalse() As List(Of ModelPinjam)
        Dim modelpjm As List(Of ModelPinjam)
        Dim dataagt As New DataAnggota

        sql = "SELECT * FROM Pinjam WHERE status_pinjam='False' AND is_deleted='False' ORDER BY created_date DESC"
        dtTable = get_dtTable(sql)

        modelpjm = (From row As DataRow In dtTable.Rows
                  Select New ModelPinjam() With
                         {.kd_pinjam = row("kd_pinjam").ToString,
                          .kd_anggota = row("kd_anggota").ToString,
                          .total = Val(row("total")),
                          .status_pinjam = row("status_pinjam").ToString,
                          .created_by = row("created_by").ToString,
                          .created_date = row("created_date"),
                          .anggota = dataagt.selectbykode(.kd_anggota)
                         }
                ).ToList
        Return modelpjm
    End Function

    Public Function selectStatTrue() As List(Of ModelPinjam)
        Dim modelpjm As List(Of ModelPinjam)
        Dim dataagt As New DataAnggota

        sql = "SELECT * FROM Pinjam WHERE status_pinjam='True' AND is_deleted='False' ORDER BY created_date DESC"
        dtTable = get_dtTable(sql)

        modelpjm = (From row As DataRow In dtTable.Rows
                  Select New ModelPinjam() With
                         {.kd_pinjam = row("kd_pinjam").ToString,
                          .kd_anggota = row("kd_anggota").ToString,
                          .total = row("total").ToString,
                          .status_pinjam = row("status_pinjam").ToString,
                          .created_by = row("created_by").ToString,
                          .created_date = row("created_date"),
                          .anggota = dataagt.selectbykode(.kd_anggota)
                         }
                ).ToList
        Return modelpjm
    End Function

    Public Function selectbykode(ByVal kode As String) As ModelPinjam
        Dim modelpjm As New ModelPinjam
        Dim dataagt As New DataAnggota

        sql = "SELECT * FROM Pinjam WHERE kd_pinjam='" & kode & "' AND is_deleted='False'"
        dtTable = get_dtTable(sql)

        If Not dtTable.Rows.Count = 0 Then
            With modelpjm
                .kd_pinjam = dtTable.Rows.Item(0).Item("kd_pinjam")
                .kd_anggota = dtTable.Rows.Item(0).Item("kd_anggota")
                .total = dtTable.Rows.Item(0).Item("total")
                .status_pinjam = dtTable.Rows.Item(0).Item("status_pinjam")
                .created_by = dtTable.Rows.Item(0).Item("created_by")
                .created_date = dtTable.Rows.Item(0).Item("created_date")
                If Not IsDBNull(dtTable.Rows.Item(0).Item("modified_by")) Then
                    .modified_by = dtTable.Rows.Item(0).Item("modified_by")
                    .modified_date = dtTable.Rows.Item(0).Item("modified_date")
                End If
                .anggota = dataagt.selectbykode(.kd_anggota)
            End With
        End If
        Return modelpjm
    End Function

    Public Function pencarianFalse(ByVal kode As String) As List(Of ModelPinjam)
        Dim modelpjm As List(Of ModelPinjam)
        Dim dataagt As New DataAnggota

        sql = "SELECT * FROM Pinjam WHERE kd_pinjam LIKE '%" & kode & "%' AND status_pinjam=0 AND is_deleted='False'"
        dtTable = get_dtTable(sql)

        modelpjm = (From row As DataRow In dtTable.Rows
                  Select New ModelPinjam() With
                         {.kd_pinjam = row("kd_pinjam").ToString,
                          .kd_anggota = row("kd_anggota").ToString,
                          .total = row("total").ToString,
                          .status_pinjam = row("status_pinjam").ToString,
                          .created_by = row("created_by").ToString,
                          .created_date = row("created_date"),
                          .anggota = dataagt.selectbykode(.kd_anggota)
                         }
                ).ToList
        Return modelpjm
    End Function

    Public Function pencarianTrue(ByVal kode As String) As List(Of ModelPinjam)
        Dim modelpjm As List(Of ModelPinjam)
        Dim dataagt As New DataAnggota

        sql = "SELECT * FROM Pinjam WHERE kd_pinjam LIKE '%" & kode & "%' AND status_pinjam=1 AND is_deleted='False'"
        dtTable = get_dtTable(sql)

        modelpjm = (From row As DataRow In dtTable.Rows
                  Select New ModelPinjam() With
                         {.kd_pinjam = row("kd_pinjam").ToString,
                          .kd_anggota = row("kd_anggota").ToString,
                          .total = row("total").ToString,
                          .status_pinjam = row("status_pinjam").ToString,
                          .created_by = row("created_by").ToString,
                          .created_date = row("created_date"),
                          .anggota = dataagt.selectbykode(.kd_anggota)
                         }
                ).ToList
        Return modelpjm
    End Function

    Public Function selectbyAnggota(ByVal kd_anggota As String) As List(Of ModelPinjam)
        Dim modelpjm As List(Of ModelPinjam)
        Dim dataagt As New DataAnggota

        sql = "SELECT * FROM Pinjam WHERE kd_anggota='" & kd_anggota & "' AND is_deleted='False'"
        dtTable = get_dtTable(sql)

        modelpjm = (From row As DataRow In dtTable.Rows
                  Select New ModelPinjam() With
                         {.kd_pinjam = row("kd_pinjam").ToString,
                          .kd_anggota = row("kd_anggota").ToString,
                          .total = row("total").ToString,
                          .status_pinjam = row("status_pinjam").ToString,
                          .created_by = row("created_by").ToString,
                          .created_date = row("created_date"),
                          .anggota = dataagt.selectbykode(.kd_anggota)
                         }
                ).ToList
        Return modelpjm
    End Function
End Class
