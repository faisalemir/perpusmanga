Imports Logic
Imports Model

Public Class History
    Inherits System.Web.UI.Page

    Dim modelpjm As New ModelPinjam
    Dim logicpjm As New LogicPinjam

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsNothing(Session("admin")) Then
            With gdv_tampil
                .DataSource = logicpjm.selectStatTrue
                .DataBind()
            End With
        Else
            Response.Redirect("../index.aspx")
        End If
    End Sub

    Protected Sub btn_cari_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_cari.Click
        With gdv_tampil
            .DataSource = logicpjm.pencarianTrue(tbx_cari.Text)
            .DataBind()
        End With
    End Sub

    Protected Sub gdv_tampil_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        Me.gdv_tampil.PageIndex = e.NewPageIndex
        Me.gdv_tampil.DataBind()
    End Sub
End Class