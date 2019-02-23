Imports Logic
Imports Model

Public Class Kategori
    Inherits System.Web.UI.Page

    Dim modelktg As New ModelKategori
    Dim logicktg As New LogicKategori

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        With gdv_tampil
            .DataSource = logicktg.selectall
            .DataBind()
        End With
    End Sub

    Protected Sub btn_cari_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_cari.Click
        With gdv_tampil
            .DataSource = logicktg.pencarian(tbx_cari.Text)
            .DataBind()
        End With
    End Sub

    Protected Sub gdv_tampil_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        Me.gdv_tampil.PageIndex = e.NewPageIndex
        Me.gdv_tampil.DataBind()
    End Sub
End Class