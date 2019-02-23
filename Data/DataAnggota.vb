Imports Model
Imports System.Data
Imports System.Data.SqlClient

Public Class DataAnggota
    Dim datapjm As New List(Of DataPinjam)

    Public Function FindNumber() As String
        Return Find_Number("AG", 0)
    End Function

    Public Function GenerateNumber() As String
        Return Generate_Number("AG", 0)
    End Function

    Public Function insert(ByVal modelagt As ModelAnggota) As Boolean
        sql = "INSERT INTO Anggota VALUES ('" & modelagt.kd_anggota & "', '" & modelagt.nama & "', '" & modelagt.alamat & "', '" & modelagt.jk & "', '" & modelagt.ktp & "', " & _
              "'" & modelagt.telp & "', '" & modelagt.created_by & "', GETDATE(), NULL, NULL, 'False')"
        Return CRUD_data(sql)
    End Function

    Public Function update(ByVal modelagt As ModelAnggota) As Boolean
        sql = "UPDATE Anggota SET nama='" & modelagt.nama & "', alamat='" & modelagt.alamat & "', jk='" & modelagt.jk & "', ktp='" & modelagt.ktp & "', " & _
              "telp='" & modelagt.telp & "', modified_by='" & modelagt.modified_by & "', modified_date=GETDATE() WHERE kd_anggota='" & modelagt.kd_anggota & "'"
        Return CRUD_data(sql)
    End Function

    Public Function delete(ByVal modelagt As ModelAnggota) As Boolean
        sql = "UPDATE Anggota SET is_deleted='True', modified_by='" & modelagt.modified_by & "', modified_date=GETDATE()  WHERE kd_anggota = '" & modelagt.kd_anggota & "'"
        Return CRUD_data(sql)
    End Function

    Public Function truedelete(ByVal modelagt As ModelAnggota) As Boolean
        sql = "DELETE Anggota WHERE kd_anggota = '" & modelagt.kd_anggota & "'"
        Return CRUD_data(sql)
    End Function

    Public Function selectall() As List(Of ModelAnggota)
        Dim modelagt As List(Of ModelAnggota)
        sql = "SELECT * FROM Anggota WHERE is_deleted='False'"
        dtTable = get_dtTable(sql)

        modelagt = (From row As DataRow In dtTable.Rows
                  Select New ModelAnggota() With
                         {.kd_anggota = row("kd_anggota").ToString,
                          .nama = row("nama").ToString,
                          .alamat = row("alamat").ToString,
                          .jk = row("jk"),
                          .ktp = row("ktp").ToString,
                          .telp = row("telp").ToString,
                          .created_by = row("created_by").ToString,
                          .created_date = row("created_date")
                         }
                ).ToList
        Return modelagt
    End Function

    Public Function selectbykode(ByVal kode As String) As ModelAnggota
        Dim modelagt As New ModelAnggota

        sql = "SELECT * FROM Anggota WHERE kd_anggota='" & kode & "'"
        dtTable = get_dtTable(sql)

        If Not dtTable.Rows.Count = 0 Then
            With modelagt
                .kd_anggota = dtTable.Rows.Item(0).Item("kd_anggota")
                .nama = dtTable.Rows.Item(0).Item("nama")
                .alamat = dtTable.Rows.Item(0).Item("alamat")
                .jk = dtTable.Rows.Item(0).Item("jk")
                .ktp = dtTable.Rows.Item(0).Item("ktp")
                .telp = dtTable.Rows.Item(0).Item("telp")
                .created_by = dtTable.Rows.Item(0).Item("created_by")
                .created_date = dtTable.Rows.Item(0).Item("created_date")
                If Not IsDBNull(dtTable.Rows.Item(0).Item("modified_by")) Then
                    .modified_by = dtTable.Rows.Item(0).Item("modified_by")
                    .modified_date = dtTable.Rows.Item(0).Item("modified_date")
                End If
            End With
        End If
        Return modelagt
    End Function

    Public Function pencarian(ByVal kode As String) As List(Of ModelAnggota)
        Dim modelagt As List(Of ModelAnggota)
        sql = "SELECT * FROM Anggota WHERE nama LIKE '%" & kode & "%' AND is_deleted='False'"
        dtTable = get_dtTable(sql)

        modelagt = (From row As DataRow In dtTable.Rows
                  Select New ModelAnggota() With
                         {.kd_anggota = row("kd_anggota").ToString,
                          .nama = row("nama").ToString,
                          .alamat = row("alamat").ToString,
                          .jk = row("jk"),
                          .ktp = row("ktp").ToString,
                          .telp = row("telp").ToString,
                          .created_by = row("created_by").ToString,
                          .created_date = row("created_date")
                         }
                ).ToList
        Return modelagt
    End Function
End Class
