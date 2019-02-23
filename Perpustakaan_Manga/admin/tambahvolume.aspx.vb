Imports Model
Imports Logic

Public Class TambahVolume
    Inherits System.Web.UI.Page

    Dim modeldbk As New ModelVolume
    Dim logicdbk As New LogicVolume

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsNothing(Session("admin")) Then
            Response.Redirect("../index.aspx")
        End If
    End Sub

    Protected Sub btn_simpan_Click(sender As Object, e As EventArgs) Handles btn_simpan.Click
        If tbx_judul.Text = Nothing Or tbx_volume.Text = Nothing Or tbx_jumlah.Text = Nothing Then
            ClientScript.RegisterClientScriptBlock(Me.GetType(), UniqueID, "<script type = 'text/javascript'>window.onload=function(){hide();alert('Pastikan semua kolom sudah terisi.');};</script>")
            If tbx_judul.Text = Nothing Then
                tbx_judul.Focus()
            ElseIf tbx_volume.Text = Nothing Then
                tbx_volume.Focus()
            ElseIf tbx_jumlah.Text = Nothing Then
                tbx_jumlah.Focus()
            End If
        Else
            With modeldbk
                .kd_buku = Request.QueryString("kode")
                .kd_volume = logicdbk.FindNumber
                .judul = tbx_judul.Text
                .volume = Val(tbx_volume.Text)
                .jumlah = Val(tbx_jumlah.Text)
                .created_by = Session("admin").username
            End With
            Dim cek As Boolean = logicdbk.insert(modeldbk)
            If cek = True Then
                logicdbk.GenerateNumber()
                Response.Redirect("detailbuku.aspx?kode=" & Request.QueryString("kode") & "")
            Else
                ClientScript.RegisterClientScriptBlock(Me.GetType(), UniqueID, "<script type = 'text/javascript'>window.onload=function(){hide();alert('Terjadi kesalahan, periksa kembali.');};</script>")
            End If
        End If
    End Sub

    Protected Sub btn_kembali_Click(sender As Object, e As EventArgs) Handles btn_kembali.Click
        Response.Redirect("detailbuku.aspx?kode=" & Request.QueryString("kode") & "")
    End Sub
End Class