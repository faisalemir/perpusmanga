Imports Logic
Imports Model

Public Class Anggota
    Inherits System.Web.UI.Page

    Dim modelagt As New ModelAnggota
    Dim logicagt As New LogicAnggota

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsNothing(Session("admin")) Then
            If IsNothing(tbx_cari.Text) Then
                tampil()
            Else
                cari()
            End If
        Else
            Response.Redirect("../index.aspx")
        End If
    End Sub

    Protected Sub btn_cari_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_cari.Click
        cari()
    End Sub

    Protected Sub gdv_tampil_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        Me.gdv_tampil.PageIndex = e.NewPageIndex
        Me.gdv_tampil.DataBind()
    End Sub

    Sub tampil()
        Dim modelagt As List(Of ModelAnggota)
        Dim logicagt As New LogicAnggota
        Dim hitung As Integer

        modelagt = logicagt.selectall
        While hitung < modelagt.Count
            modelagt(hitung).tmpjk = Konversi.jk(modelagt(hitung).jk)
            hitung += 1
        End While
        With gdv_tampil
            .DataSource = modelagt
            .DataBind()
        End With
    End Sub

    Sub cari()
        Dim modelagt As List(Of ModelAnggota)
        Dim logicagt As New LogicAnggota
        Dim hitung As Integer

        modelagt = logicagt.pencarian(tbx_cari.Text)
        While hitung < modelagt.Count
            modelagt(hitung).tmpjk = Konversi.jk(modelagt(hitung).jk)
            hitung += 1
        End While
        With gdv_tampil
            .DataSource = modelagt
            .DataBind()
        End With
    End Sub
End Class