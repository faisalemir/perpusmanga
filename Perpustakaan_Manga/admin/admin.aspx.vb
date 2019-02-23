Imports Logic
Imports Model

Public Class Admin
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsNothing(Session("admin")) Then
            If Session("admin").hakakses.akses = "Pemilik" Then
                If IsNothing(tbx_cari.Text) Then
                    tampil()
                Else
                    cari()
                End If
            Else
                Response.Redirect("../index.aspx")
            End If
        Else
            Response.Redirect("../login.aspx")
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
        Dim modeladm As List(Of ModelAdmin)
        Dim logicadm As New LogicAdmin
        Dim hitung As Integer

        modeladm = logicadm.selectall
        While hitung < modeladm.Count
                modeladm(hitung).tmpjk = Konversi.jk(modeladm(hitung).jk)
                hitung += 1
        End While
        With gdv_tampil
            .DataSource = modeladm
            .DataBind()
        End With
    End Sub

    Sub cari()
        Dim modeladm As List(Of ModelAdmin)
        Dim logicadm As New LogicAdmin
        Dim hitung As Integer

        modeladm = logicadm.pencarian(tbx_cari.Text)
        While hitung < modeladm.Count
            modeladm(hitung).tmpjk = Konversi.jk(modeladm(hitung).jk)
            hitung += 1
        End While
        With gdv_tampil
            .DataSource = modeladm
            .DataBind()
        End With
    End Sub
End Class