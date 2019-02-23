Imports Model
Imports Logic

Public Class Detailadmin
    Inherits System.Web.UI.Page

    Dim modeladm As New ModelAdmin
    Dim logicadm As New LogicAdmin
    Dim sunting As ModelAdmin

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsNothing(Session("admin")) Then
            If Session("admin").hakakses.akses = "Pemilik" Then
                If Not IsPostBack Then
                    If Request.QueryString.Keys.Item(0) = "kode" Then
                        tampil()
                    End If
                End If
                tbx_nama.Visible = False
                tbx_alamat.Visible = False
                tbx_ktp.Visible = False
                tbx_telp.Visible = False
                tbx_id.Visible = False
                tbx_pass.Visible = False
                ddl_jk.Visible = False
                ddl_akses.Visible = False
            Else
                Response.Redirect("../index.aspx")
            End If
        Else
            Response.Redirect("../login.aspx")
        End If
    End Sub

    Protected Sub btn_simpan_Click(sender As Object, e As EventArgs) Handles btn_simpan.Click
        With modeladm
            .kd_admin = lbl_kd_admin.Text
            .kd_akses = ddl_akses.Text
            .jk = ddl_jk.Text
            .nama = tbx_nama.Text
            .alamat = tbx_alamat.Text
            .ktp = Val(tbx_ktp.Text)
            .telp = Val(tbx_telp.Text)
            .username = tbx_id.Text
            .password = tbx_pass.Text
            .modified_by = Session("admin").username
        End With
        logicadm.update(modeladm)
        Response.Redirect("admin.aspx")
    End Sub

    Protected Sub btn_sunting_Click(sender As Object, e As EventArgs) Handles btn_sunting.Click
        btn_simpan.Visible = True
        btn_sunting.Visible = False
        ddl_akses.Enabled = True
        ddl_jk.Enabled = True
        tbx_nama.ReadOnly = False
        tbx_alamat.ReadOnly = False
        tbx_ktp.ReadOnly = False
        tbx_telp.ReadOnly = False
        tbx_id.ReadOnly = False
        tbx_pass.ReadOnly = False
        btn_hapus.Visible = False

        tbx_nama.Visible = True
        tbx_alamat.Visible = True
        tbx_ktp.Visible = True
        tbx_telp.Visible = True
        tbx_id.Visible = True
        tbx_pass.Visible = True
        ddl_jk.Visible = True
        ddl_akses.Visible = True

        lbl_nama.Visible = False
        lbl_alamat.Visible = False
        lbl_ktp.Visible = False
        lbl_telp.Visible = False
        lbl_id.Visible = False
        lbl_pass.Visible = False
        lbl_jk.Visible = False
        lbl_akses.Visible = False
    End Sub

    Protected Sub btn_kembali_Click(sender As Object, e As EventArgs) Handles btn_kembali.Click
        Response.Redirect("admin.aspx")
    End Sub

    Protected Sub btn_hapus_Click(sender As Object, e As EventArgs) Handles btn_hapus.Click
        hapus()
    End Sub

    Sub tampil()
        modeladm.kd_admin = Request.QueryString("kode")
        sunting = logicadm.selectbykode(modeladm.kd_admin)
        lbl_kd_admin.Text = sunting.kd_admin
        ddl_akses.SelectedValue = sunting.kd_akses
        ddl_jk.SelectedValue = sunting.jk
        tbx_nama.Text = sunting.nama
        tbx_alamat.Text = sunting.alamat
        tbx_ktp.Text = sunting.ktp
        tbx_telp.Text = sunting.telp
        tbx_id.Text = sunting.username
        tbx_pass.Text = sunting.password

        lbl_akses.Text = sunting.hakakses.akses
        lbl_jk.Text = Konversi.jk(sunting.jk)
        lbl_nama.Text = sunting.nama
        lbl_alamat.Text = sunting.alamat
        lbl_ktp.Text = sunting.ktp
        lbl_telp.Text = sunting.telp
        lbl_id.Text = sunting.username
        lbl_pass.Text = sunting.password
    End Sub

    Sub hapus()
        modeladm.kd_admin = lbl_kd_admin.Text
        modeladm.modified_by = Session("admin").username
        logicadm.delete(modeladm)
        Response.Redirect("admin.aspx")
    End Sub
End Class