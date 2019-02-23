Imports Model
Imports Logic

Public Class Tambahkategori
    Inherits System.Web.UI.Page

    Dim modelktg As New ModelKategori
    Dim logicktg As New LogicKategori

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsNothing(Session("admin")) Then
            Response.Redirect("../index.aspx")
        End If
    End Sub

    Protected Sub btn_simpan_Click(sender As Object, e As EventArgs) Handles btn_simpan.Click
        If Not tbx_nama.Text = Nothing Then
            With modelktg
                .kd_kategori = logicktg.FindNumber
                .nama = tbx_nama.Text
                .created_by = Session("admin").username
            End With
            Dim cek As Boolean = logicktg.insert(modelktg)
            If cek = True Then
                logicktg.GenerateNumber()
                Response.Redirect("kategori.aspx")
            Else
                ClientScript.RegisterClientScriptBlock(Me.GetType(), UniqueID, "<script type = 'text/javascript'>window.onload=function(){hide();alert('Terjadi kesalahan, periksa kembali.');};</script>")
            End If
        Else
            ClientScript.RegisterClientScriptBlock(Me.GetType(), UniqueID, "<script type = 'text/javascript'>window.onload=function(){hide();alert('Nama kategori belum terisi.');};</script>")
        End If
    End Sub

    Protected Sub btn_kembali_Click(sender As Object, e As EventArgs) Handles btn_kembali.Click
        Response.Redirect("kategori.aspx")
    End Sub
End Class