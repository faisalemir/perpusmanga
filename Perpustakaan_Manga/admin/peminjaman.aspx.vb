Imports Logic
Imports Model

Public Class Peminjaman
    Inherits System.Web.UI.Page

    Dim modelpjm As New List(Of ModelPinjam)
    Dim logicpjm As New LogicPinjam

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsNothing(Session("admin")) Then
            With gdv_tampil
                .DataSource = logicpjm.selectStatFalse
                .DataBind()
            End With

            If Not logicpjm.selectStatFalse.Count = 0 Then
                pnl_kosong.Visible = False
            Else
                pnl_kosong.Visible = True
            End If
        Else
            Response.Redirect("../index.aspx")
        End If
    End Sub

    Protected Sub btn_cari_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_cari.Click
        With gdv_tampil
            .DataSource = logicpjm.pencarianFalse(tbx_cari.Text)
            .DataBind()
        End With
    End Sub

    Protected Sub gdv_tampil_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        Me.gdv_tampil.PageIndex = e.NewPageIndex
        Me.gdv_tampil.DataBind()
    End Sub
End Class