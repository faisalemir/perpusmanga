Imports Logic
Imports Model

Public Class Daftarmanga
    Inherits System.Web.UI.Page

    Dim modelbku As New ModelBuku
    Dim logicbku As New LogicBuku

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            tampil()
        End If
    End Sub

    Protected Sub btn_cari_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_cari.Click
        cari()
    End Sub

    Protected Sub gdv_tampil_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles gdv_tampil.PageIndexChanging
        Me.gdv_tampil.PageIndex = e.NewPageIndex
        Me.gdv_tampil.DataBind()
    End Sub

    Sub tampil()
        With gdv_tampil
            .DataSource = logicbku.selectall
            .DataBind()
        End With
    End Sub

    Sub cari()
        With gdv_tampil
            .DataSource = logicbku.pencarian(tbx_cari.Text)
            .DataBind()
        End With
    End Sub
End Class