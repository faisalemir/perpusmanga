Imports Model
Imports Logic

Public Class Detailkategori
    Inherits System.Web.UI.Page

    Dim modelagt As New ModelKategori
    Dim logicagt As New LogicKategori
    Dim sunting As ModelKategori

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim type As String = Request.QueryString.Keys.Item(0)
        If Not IsNothing(Session("admin")) Then
            If Not IsPostBack Then
                If type = "kode" Then
                    tampil()
                End If
            End If
        Else
            Response.Redirect("../index.aspx")
        End If
    End Sub

    Protected Sub btn_simpan_Click(sender As Object, e As EventArgs) Handles btn_simpan.Click
        With modelagt
            .kd_kategori = lbl_kd_kategori.Text
            .nama = tbx_nama.Text
            .modified_by = Session("admin").username
        End With
        logicagt.update(modelagt)
        Response.Redirect("kategori.aspx")
    End Sub

    Protected Sub btn_sunting_Click(sender As Object, e As EventArgs) Handles btn_sunting.Click
        btn_simpan.Visible = True
        btn_sunting.Visible = False
        btn_hapus.Visible = False
        tbx_nama.ReadOnly = False
    End Sub

    Protected Sub btn_kembali_Click(sender As Object, e As EventArgs) Handles btn_kembali.Click
        Response.Redirect("kategori.aspx")
    End Sub

    Protected Sub btn_hapus_Click(sender As Object, e As EventArgs) Handles btn_hapus.Click
        hapus()
    End Sub

    Sub tampil()
        modelagt.kd_kategori = Request.QueryString("kode")
        sunting = logicagt.selectbykode(modelagt.kd_kategori)
        lbl_kd_kategori.Text = sunting.kd_kategori
        tbx_nama.Text = sunting.nama
    End Sub

    Sub hapus()
        modelagt.kd_kategori = lbl_kd_kategori.Text
        modelagt.modified_by = Session("admin").username
        logicagt.delete(modelagt)
        Response.Redirect("kategori.aspx")
    End Sub
End Class