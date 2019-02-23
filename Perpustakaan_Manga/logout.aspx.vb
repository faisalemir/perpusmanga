Public Class logout
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsNothing(Session("admin")) Then
            Session.RemoveAll()
            Response.Redirect("index.aspx")
        Else
            Response.Redirect("index.aspx")
        End If
    End Sub
End Class