Public Class Manga
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsNothing(Session("admin")) Then
            If Session("admin").hakakses.akses = "Pemilik" Then
                tbl_menu.Visible = True
                btn_logout.Visible = True
                btn_login.Visible = False
            Else
                tbl_menu.Visible = True
                btn_logout.Visible = True
                btn_login.Visible = False
                mn_admin.Visible = False
                mn_tarif.Visible = False
            End If
        Else
            tbl_menu.Visible = False
            btn_logout.Visible = False
            btn_login.Visible = True
        End If
    End Sub
End Class