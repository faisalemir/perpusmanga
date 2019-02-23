Imports Model
Imports Logic

Public Class DetailVolume
    Inherits System.Web.UI.Page

    Dim modelvol As New ModelVolume
    Dim logicvol As New LogicVolume
    Dim sunting As ModelVolume

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim type As String = Request.QueryString.Keys.Item(0)

        If Not IsNothing(Session("admin")) Then
            If Not IsPostBack Then
                If type = "kode" Then
                    tampil()
                End If
            End If
        Else
            Response.Redirect("../index.aspx")
        End If
    End Sub

    Protected Sub btn_simpan_Click(sender As Object, e As EventArgs) Handles btn_simpan.Click
        With modelvol
            .kd_volume = lbl_kd_volume.Text
            .volume = tbx_volume.Text
            .judul = tbx_judul.Text
            .jumlah = tbx_jumlah.Text
            .stok = tbx_stok.Text
            .modified_by = Session("admin").username
        End With
        logicvol.update(modelvol)
        modelvol.kd_volume = Request.QueryString("kode")
        sunting = logicvol.selectbykode(modelvol.kd_volume)
        Response.Redirect("detailbuku.aspx?kode=" & sunting.kd_buku & "")
    End Sub

    Protected Sub btn_sunting_Click(sender As Object, e As EventArgs) Handles btn_sunting.Click
        btn_simpan.Visible = True
        btn_sunting.Visible = False
        btn_hapus.Visible = False
        tbx_judul.ReadOnly = False
        tbx_volume.ReadOnly = False
        tbx_jumlah.ReadOnly = False
        tbx_stok.ReadOnly = False
        created_by.Visible = False
        created_date.Visible = False
        modified_by.Visible = False
        modified_date.Visible = False
    End Sub

    Protected Sub btn_kembali_Click(sender As Object, e As EventArgs) Handles btn_kembali.Click
        modelvol.kd_volume = Request.QueryString("kode")
        sunting = logicvol.selectbykode(modelvol.kd_volume)
        Response.Redirect("detailbuku.aspx?kode=" & sunting.kd_buku & "")
    End Sub

    Protected Sub btn_hapus_Click(sender As Object, e As EventArgs) Handles btn_hapus.Click
        hapus()
    End Sub

    Sub tampil()
        modelvol.kd_volume = Request.QueryString("kode")
        sunting = logicvol.selectbykode(modelvol.kd_volume)
        lbl_kd_volume.Text = sunting.kd_volume
        tbx_volume.Text = sunting.volume
        tbx_judul.Text = sunting.judul
        tbx_jumlah.Text = sunting.jumlah
        tbx_stok.Text = sunting.stok
        tbx_created_by.Text = sunting.created_by
        tbx_created_date.Text = sunting.created_date
        tbx_modified_by.Text = sunting.modified_by
        tbx_modified_date.Text = sunting.modified_date
    End Sub

    Sub hapus()
        modelvol.kd_volume = lbl_kd_volume.Text
        modelvol.modified_by = Session("admin").username
        logicvol.delete(modelvol)
        modelvol.kd_volume = Request.QueryString("kode")
        sunting = logicvol.selectbykode(modelvol.kd_volume)
        Response.Redirect("detailbuku.aspx?kode=" & sunting.kd_buku & "")
    End Sub
End Class