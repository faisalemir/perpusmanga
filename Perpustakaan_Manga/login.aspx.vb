Imports Logic
Imports Model

Public Class login
    Inherits System.Web.UI.Page

    Dim modeladm As New ModelAdmin
    Dim logicadm As New LogicAdmin

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        tbx_pass.TextMode = TextBoxMode.Password
    End Sub

    Protected Sub btn_login_Click(sender As Object, e As EventArgs) Handles btn_login.Click
        If tbx_user.Text = Nothing And tbx_pass.Text = Nothing Then
            ClientScript.RegisterClientScriptBlock(Me.GetType(), UniqueID, "<script type = 'text/javascript'>window.onload=function(){hide();alert('Username dan Password belum terisi.');};</script>")
            MsgBox("Username dan Password belum terisi.", MsgBoxStyle.Information, "Login")
            tbx_user.Focus()
        ElseIf tbx_user.Text = Nothing Then
            ClientScript.RegisterClientScriptBlock(Me.GetType(), UniqueID, "<script type = 'text/javascript'>window.onload=function(){hide();alert('Username belum terisi.');};</script>")
            tbx_user.Focus()
        ElseIf tbx_pass.Text = Nothing Then
            ClientScript.RegisterClientScriptBlock(Me.GetType(), UniqueID, "<script type = 'text/javascript'>window.onload=function(){hide();alert('Password belum terisi.');};</script>")
            tbx_pass.Focus()
        Else
            login()
        End If
    End Sub

    Sub login()
        modeladm = logicadm.login(tbx_user.Text, tbx_pass.Text)
        If modeladm.username = Nothing Then
            ClientScript.RegisterClientScriptBlock(Me.GetType(), UniqueID, "<script type = 'text/javascript'>window.onload=function(){hide();alert('Username dan Password tidak tepat.');};</script>")
        Else
            Session("admin") = modeladm
            Response.Redirect("index.aspx")
        End If
    End Sub
End Class