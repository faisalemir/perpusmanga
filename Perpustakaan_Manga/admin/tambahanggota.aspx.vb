Imports Model
Imports Logic

Public Class TambahAnggota
    Inherits System.Web.UI.Page

    Dim modelagt As New ModelAnggota
    Dim logicagt As New LogicAnggota

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsNothing(Session("admin")) Then
            Response.Redirect("../index.aspx")
        End If
    End Sub

    Protected Sub btn_simpan_Click(sender As Object, e As EventArgs) Handles btn_simpan.Click
        If tbx_nama.Text = Nothing Or tbx_alamat.Text = Nothing Or tbx_ktp.Text = Nothing Or tbx_telp.Text = Nothing Then
            ClientScript.RegisterClientScriptBlock(Me.GetType(), UniqueID, "<script type = 'text/javascript'>window.onload=function(){hide();alert('Pastikan semua kolom sudah terisi.');};</script>")
            If tbx_nama.Text = Nothing Then
                tbx_nama.Focus()
            ElseIf tbx_alamat.Text = Nothing Then
                tbx_alamat.Focus()
            ElseIf tbx_ktp.Text = Nothing Then
                tbx_ktp.Focus()
            ElseIf tbx_telp.Text = Nothing Then
                tbx_telp.Focus()
            End If
        Else
            With modelagt
                .kd_anggota = logicagt.FindNumber
                .jk = Val(ddl_jk.Text)
                .nama = tbx_nama.Text
                .alamat = tbx_alamat.Text
                .ktp = Val(tbx_ktp.Text)
                .telp = Val(tbx_telp.Text)
                .created_by = Session("admin").username
            End With
            Dim cek As Boolean = logicagt.insert(modelagt)
            If cek = True Then
                logicagt.GenerateNumber()
                Response.Redirect("anggota.aspx")
            Else
                ClientScript.RegisterClientScriptBlock(Me.GetType(), UniqueID, "<script type = 'text/javascript'>window.onload=function(){hide();alert('Terjadi kesalahan, periksa kembali.');};</script>")
            End If
        End If
    End Sub

    Protected Sub btn_kembali_Click(sender As Object, e As EventArgs) Handles btn_kembali.Click
        Response.Redirect("anggota.aspx")
    End Sub
End Class