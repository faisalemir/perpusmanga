Imports Model
Imports Logic

Public Class DetailAnggota
    Inherits System.Web.UI.Page

    Dim modelagt As New ModelAnggota
    Dim logicagt As New LogicAnggota
    Dim sunting As ModelAnggota

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsNothing(Session("admin")) Then
            If Not IsPostBack Then
                If Request.QueryString.Keys.Item(0) = "kode" Then
                    tampil()
                End If
            End If
            tbx_nama.Visible = False
            tbx_alamat.Visible = False
            tbx_ktp.Visible = False
            tbx_telp.Visible = False
            ddl_jk.Visible = False
        Else
            Response.Redirect("../index.aspx")
        End If
    End Sub

    Protected Sub btn_simpan_Click(sender As Object, e As EventArgs) Handles btn_simpan.Click
        With modelagt
            .kd_anggota = lbl_kd_anggota.Text
            .jk = ddl_jk.Text
            .nama = tbx_nama.Text
            .alamat = tbx_alamat.Text
            .ktp = Val(tbx_ktp.Text)
            .telp = Val(tbx_telp.Text)
            .modified_by = Session("admin").username
        End With
        logicagt.update(modelagt)
        Response.Redirect("anggota.aspx")
    End Sub

    Protected Sub btn_sunting_Click(sender As Object, e As EventArgs) Handles btn_sunting.Click
        btn_simpan.Visible = True
        btn_sunting.Visible = False
        ddl_jk.Enabled = True
        tbx_nama.ReadOnly = False
        tbx_alamat.ReadOnly = False
        tbx_ktp.ReadOnly = False
        tbx_telp.ReadOnly = False
        btn_hapus.Visible = False

        tbx_nama.Visible = True
        tbx_alamat.Visible = True
        tbx_ktp.Visible = True
        tbx_telp.Visible = True
        ddl_jk.Visible = True

        lbl_nama.Visible = False
        lbl_alamat.Visible = False
        lbl_ktp.Visible = False
        lbl_telp.Visible = False
        lbl_jk.Visible = False
    End Sub

    Protected Sub btn_kembali_Click(sender As Object, e As EventArgs) Handles btn_kembali.Click
        Response.Redirect("anggota.aspx")
    End Sub

    Protected Sub btn_hapus_Click(sender As Object, e As EventArgs) Handles btn_hapus.Click
        hapus()
    End Sub

    Sub tampil()
        modelagt.kd_anggota = Request.QueryString("kode")
        sunting = logicagt.selectbykode(modelagt.kd_anggota)
        lbl_kd_anggota.Text = sunting.kd_anggota
        ddl_jk.SelectedValue = sunting.jk
        tbx_nama.Text = sunting.nama
        tbx_alamat.Text = sunting.alamat
        tbx_ktp.Text = sunting.ktp
        tbx_telp.Text = sunting.telp

        lbl_jk.Text = Konversi.jk(sunting.jk)
        lbl_nama.Text = sunting.nama
        lbl_alamat.Text = sunting.alamat
        lbl_ktp.Text = sunting.ktp
        lbl_telp.Text = sunting.telp
    End Sub

    Sub hapus()
        modelagt.kd_anggota = lbl_kd_anggota.Text
        modelagt.modified_by = Session("admin").username
        logicagt.delete(modelagt)
        Response.Redirect("anggota.aspx")
    End Sub
End Class