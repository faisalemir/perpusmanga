Imports Model

Public Class DataAdmin
    Dim dataaks As New DataHakAkses

    Public Function FindNumber() As String
        Return Find_Number("AD", 1)
    End Function

    Public Function GenerateNumber() As String
        Return Generate_Number("AD", 1)
    End Function

    Public Function insert(ByVal modeladm As ModelAdmin) As Boolean
        sql = "INSERT INTO Admin VALUES('" & modeladm.kd_admin & "', '" & modeladm.kd_akses & "', '" & modeladm.nama & "', '" & modeladm.alamat & "'," & _
              "'" & modeladm.jk & "', '" & modeladm.ktp & "', '" & modeladm.telp & "', '" & modeladm.username & "', '" & modeladm.password & "', '" & modeladm.created_by & "', GETDATE(), NULL, NULL, 'False')"
        Return CRUD_data(sql)
    End Function

    Public Function update(ByVal modeladm As ModelAdmin) As Boolean
        sql = "UPDATE Admin SET kd_akses='" & modeladm.kd_akses & "', nama='" & modeladm.nama & "', alamat='" & modeladm.alamat & "', jk='" & modeladm.jk & "'," & _
              " ktp='" & modeladm.ktp & "', telp='" & modeladm.telp & "', username='" & modeladm.username & "', password='" & modeladm.password & "'," & _
              " modified_by='" & modeladm.created_by & "', modified_date=GETDATE() WHERE kd_admin='" & modeladm.kd_admin & "'"
        Return CRUD_data(sql)
    End Function

    Public Function delete(ByVal modeladm As ModelAdmin) As Boolean
        sql = "UPDATE Admin SET is_deleted='True', modified_by='" & modeladm.created_by & "', modified_date=GETDATE() WHERE kd_admin = '" & modeladm.kd_admin & "'"
        Return CRUD_data(sql)
    End Function

    Public Function selectall() As List(Of ModelAdmin)
        Dim modeladm As List(Of ModelAdmin)
        sql = "SELECT * FROM Admin WHERE is_deleted='False'"
        dtTable = get_dtTable(sql)

        modeladm = (From row As DataRow In dtTable.Rows
                  Select New ModelAdmin() With
                         {.kd_admin = row("kd_admin").ToString,
                          .kd_akses = row("kd_akses"),
                          .nama = row("nama").ToString,
                          .alamat = row("alamat").ToString,
                          .jk = row("jk"),
                          .ktp = row("ktp").ToString,
                          .telp = row("telp").ToString,
                          .username = row("username").ToString,
                          .password = row("password").ToString,
                          .created_by = row("created_by").ToString,
                          .created_date = row("created_date"),
                          .hakakses = dataaks.selectbykode(.kd_akses)
                         }
                ).ToList
        Return modeladm
    End Function
    Public Function selectbykode(ByVal kode As String) As ModelAdmin
        Dim modeladm As New ModelAdmin

        sql = "SELECT * FROM Admin WHERE kd_admin='" & kode & "' AND is_deleted='False'"
        dtTable = get_dtTable(sql)

        If Not dtTable.Rows.Count = 0 Then
            With modeladm
                .kd_admin = dtTable.Rows.Item(0).Item("kd_admin")
                .kd_akses = dtTable.Rows.Item(0).Item("kd_akses")
                .nama = dtTable.Rows.Item(0).Item("nama")
                .alamat = dtTable.Rows.Item(0).Item("alamat")
                .jk = dtTable.Rows.Item(0).Item("jk")
                .ktp = dtTable.Rows.Item(0).Item("ktp")
                .telp = dtTable.Rows.Item(0).Item("telp")
                .username = dtTable.Rows.Item(0).Item("username")
                .password = dtTable.Rows.Item(0).Item("password")
                .created_by = dtTable.Rows.Item(0).Item("created_by")
                .created_date = dtTable.Rows.Item(0).Item("created_date")
                If Not IsDBNull(dtTable.Rows.Item(0).Item("modified_by")) Then
                    .modified_by = dtTable.Rows.Item(0).Item("modified_by")
                    .modified_date = dtTable.Rows.Item(0).Item("modified_date")
                End If
                .hakakses = dataaks.selectbykode(.kd_akses)
            End With
        End If
        Return modeladm
    End Function
    Public Function pencarian(ByVal kode As String) As List(Of ModelAdmin)
        Dim modeladm As List(Of ModelAdmin)
        sql = "SELECT * FROM Admin WHERE nama LIKE '%" & kode & "%' AND is_deleted='False'"
        dtTable = get_dtTable(sql)

        modeladm = (From row As DataRow In dtTable.Rows
                  Select New ModelAdmin() With
                         {.kd_admin = row("kd_admin").ToString,
                          .kd_akses = row("kd_akses"),
                          .nama = row("nama").ToString,
                          .alamat = row("alamat").ToString,
                          .jk = row("jk"),
                          .ktp = row("ktp").ToString,
                          .telp = row("telp").ToString,
                          .username = row("username").ToString,
                          .password = row("password").ToString,
                          .created_by = row("created_by").ToString,
                          .created_date = row("created_date"),
                          .hakakses = dataaks.selectbykode(.kd_akses)
                         }
                ).ToList
        Return modeladm
    End Function

    Public Function login(ByVal user As String, ByVal pass As String) As ModelAdmin
        Dim modeladm As New ModelAdmin

        sql = "SELECT * FROM Admin WHERE username='" & user & "' AND password='" & pass & "' AND is_deleted='False'"
        dtTable = get_dtTable(sql)

        If Not dtTable.Rows.Count = 0 Then
            With modeladm
                .kd_admin = dtTable.Rows.Item(0).Item("kd_admin")
                .kd_akses = dtTable.Rows.Item(0).Item("kd_akses")
                .nama = dtTable.Rows.Item(0).Item("nama")
                .username = dtTable.Rows.Item(0).Item("username")
                .password = dtTable.Rows.Item(0).Item("password")
                .hakakses = dataaks.selectbykode(.kd_akses)
            End With
        End If
        Return modeladm
    End Function
End Class
