Imports Model
Imports Logic

Public Class denda
    Inherits System.Web.UI.Page

    Dim updatednd As New ModelDenda
    Dim insertdnd As New ModelDenda
    Dim logicdnd As New LogicDenda
    Dim modeldnd2 As ModelDenda

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsNothing(Session("admin")) Then
            If Session("admin").hakakses.akses = "Pemilik" Then
                If Not Me.IsPostBack Then
                    modeldnd2 = logicdnd.selectFalse
                    lbl_kd_denda.Text = modeldnd2.kd_denda
                    lbl_denda.Text = modeldnd2.denda
                    tbx_denda.Text = modeldnd2.denda
                End If
            Else
                Response.Redirect("../index.aspx")
            End If
        Else
            Response.Redirect("../login.aspx")
        End If
    End Sub

    Protected Sub btn_simpan_Click(sender As Object, e As EventArgs) Handles btn_simpan.Click
        Dim kd_denda As String = logicdnd.FindNumber
        With updatednd
            .kd_denda = lbl_kd_denda.Text
            .modified_by = Session("admin").username
        End With
        With insertdnd
            .kd_denda = kd_denda
            .denda = tbx_denda.Text
            .created_by = Session("admin").username
        End With
        Dim cekupdate As Boolean = logicdnd.update(updatednd)
        Dim cekinsert As Boolean = logicdnd.insert(insertdnd)
        If cekinsert = True And cekupdate = True Then
            logicdnd.GenerateNumber()
            Response.Redirect("denda.aspx")
        Else
            logicdnd.truedelete(insertdnd)
            logicdnd.rollback(updatednd)
            ClientScript.RegisterClientScriptBlock(Me.GetType(), UniqueID, "<script type = 'text/javascript'>window.onload=function(){hide();alert('Terjadi kesalahan, periksa kembali.');};</script>")
        End If
    End Sub

    Protected Sub btn_sunting_Click(sender As Object, e As EventArgs) Handles btn_sunting.Click
        btn_simpan.Visible = True
        btn_sunting.Visible = False
        btn_kembali.Visible = True
        lbl_denda.Visible = False
        tbx_denda.Visible = True
        tbx_denda.ReadOnly = False
    End Sub

    Protected Sub btn_kembali_Click(sender As Object, e As EventArgs) Handles btn_kembali.Click
        btn_simpan.Visible = False
        btn_sunting.Visible = True
        btn_kembali.Visible = False
        lbl_denda.Visible = True
        tbx_denda.Visible = False
        tbx_denda.ReadOnly = True
    End Sub
End Class