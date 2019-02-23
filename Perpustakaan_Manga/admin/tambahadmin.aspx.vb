Imports Model
Imports Logic

Public Class Tambahadmin
    Inherits System.Web.UI.Page

    Dim modeladm As New ModelAdmin
    Dim logicadm As New LogicAdmin

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsNothing(Session("admin")) Then
            If Not Session("admin").hakakses.akses = "Pemilik" Then
                Response.Redirect("../index.aspx")
            End If
        Else
            Response.Redirect("../login.aspx")
        End If
    End Sub

    Protected Sub btn_simpan_Click(sender As Object, e As EventArgs) Handles btn_simpan.Click
        If tbx_nama.Text = Nothing Or tbx_alamat.Text = Nothing Or tbx_ktp.Text = Nothing Or tbx_telp.Text = Nothing Or tbx_id.Text = Nothing Or tbx_pass.Text = Nothing Then
            ClientScript.RegisterClientScriptBlock(Me.GetType(), UniqueID, "<script type = 'text/javascript'>window.onload=function(){hide();alert('Pastikan semua kolom sudah terisi.');};</script>")
            If tbx_nama.Text = Nothing Then
                tbx_nama.Focus()
            ElseIf tbx_alamat.Text = Nothing Then
                tbx_alamat.Focus()
            ElseIf tbx_ktp.Text = Nothing Then
                tbx_ktp.Focus()
            ElseIf tbx_telp.Text = Nothing Then
                tbx_telp.Focus()
            ElseIf tbx_id.Text = Nothing Then
                tbx_id.Focus()
            ElseIf tbx_pass.Text = Nothing Then
                tbx_pass.Focus()
            End If
        Else
            With modeladm
                .kd_admin = logicadm.FindNumber
                .kd_akses = Val(ddl_akses.Text)
                .jk = Val(ddl_jk.Text)
                .nama = tbx_nama.Text
                .alamat = tbx_alamat.Text
                .ktp = Val(tbx_ktp.Text)
                .telp = Val(tbx_telp.Text)
                .username = tbx_id.Text
                .password = tbx_pass.Text
                .created_by = Session("admin").username
            End With
            Dim cek As Boolean = logicadm.insert(modeladm)
            If cek = True Then
                logicadm.GenerateNumber()
                Response.Redirect("admin.aspx")
            Else
                ClientScript.RegisterClientScriptBlock(Me.GetType(), UniqueID, "<script type = 'text/javascript'>window.onload=function(){hide();alert('Terjadi kesalahan, periksa kembali.');};</script>")
            End If
        End If
    End Sub

    Protected Sub btn_kembali_Click(sender As Object, e As EventArgs) Handles btn_kembali.Click
        Response.Redirect("admin.aspx")
    End Sub
End Class