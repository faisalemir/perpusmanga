Imports Model
Imports Logic

Public Class DetailBuku
    Inherits System.Web.UI.Page

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
        Dim modelbku As New ModelBuku
        Dim logicbku As New LogicBuku
        Dim logicgbr As New LogicGambar
        Dim modelgbr As New ModelGambar
        Dim sunting As ModelBuku
        Dim delete As ModelGambar
        Dim kategori As New List(Of ModelKategori)
        Dim logicktg As New LogicKategori
        Dim modeldkg As New ModelDetailKategori
        Dim logicdkg As New LogicDetailKategori
        Dim isi As New List(Of ModelDetailKategori)
        Dim i As Integer
        Dim kd_gambar As String = logicgbr.FindNumber

        modelbku.kd_buku = Request.QueryString("kode")
        sunting = logicbku.selectbykode(modelbku.kd_buku)
        delete = logicgbr.selectbykode(sunting.kd_gambar)
        delete.modified_by = Session("admin").username

        If fup_gambar.PostedFile.ContentLength > 0 Then
            With modelgbr
                .kd_gambar = kd_gambar
                .nama = fup_gambar.PostedFile.FileName
                .created_by = Session("admin").username
            End With
        End If

        With modelbku
            .kd_buku = lbl_kd_buku.Text
            If fup_gambar.PostedFile.ContentLength > 0 Then
                .kd_gambar = kd_gambar
            Else
                .kd_gambar = sunting.kd_gambar
            End If
            .nama = tbx_nama.Text
            .tahun = tbx_tahun.Text
            .pengarang = tbx_pengarang.Text
            .penulis = tbx_penulis.Text
            .sinopsis = tbx_sinopsis.Text
            .modified_by = Session("admin").username
        End With

        For i = 0 To cbl_kategori.Items.Count - 1
            If cbl_kategori.Items(i).Selected = True Then
                kategori.Add(logicktg.selectbykode(cbl_kategori.Items(i).Value))
            End If
        Next

        modeldkg.kd_buku = lbl_kd_buku.Text
        modeldkg.modified_by = Session("admin").username

        Dim cekgambar As Boolean
        If fup_gambar.PostedFile.ContentLength > 0 Then
            cekgambar = logicgbr.insert(modelgbr)
        Else
            cekgambar = True
        End If
        Dim cekhapus As Boolean = logicgbr.delete(delete)
        Dim cekbuku As Boolean = logicbku.update(modelbku)
        Dim cekdetail As Boolean = logicdkg.delete(modeldkg)

        If cekgambar = True And cekbuku = True And cekhapus = True And cekdetail = True Then
            logicgbr.GenerateNumber()

            Dim link As String = "../images/" + modelgbr.kd_gambar + ".jpg"
            fup_gambar.SaveAs(Server.MapPath(link))

            Dim ii As Integer
            For ii = 0 To kategori.Count - 1
                With modeldkg
                    .kd_buku = lbl_kd_buku.Text
                    .kd_kategori = kategori(ii).kd_kategori
                    .created_by = Session("admin").username
                    .modified_by = Session("admin").username
                    .buku = logicbku.selectbykode(.kd_buku)
                    .kategori = logicktg.selectbykode(.kd_kategori)
                End With
                logicdkg.insert(modeldkg)
            Next
            Response.Redirect("Buku.aspx")
        Else
            logicgbr.undelete(delete)
            logicgbr.truedelete(modelgbr)
            logicdkg.undelete(modeldkg)
            ClientScript.RegisterClientScriptBlock(Me.GetType(), UniqueID, "<script type = 'text/javascript'>window.onload=function(){hide();alert('Terjadi kesalahan, periksa kembali.');};</script>")
        End If
    End Sub

    Protected Sub btn_sunting_Click(sender As Object, e As EventArgs) Handles btn_sunting.Click
        btn_simpan.Visible = True
        btn_sunting.Visible = False
        tbx_nama.ReadOnly = False
        tbx_tahun.ReadOnly = False
        tbx_pengarang.ReadOnly = False
        tbx_penulis.ReadOnly = False
        tbx_sinopsis.ReadOnly = False
        btn_hapus.Visible = False
        tr_gambar.Visible = True
        cbl_kategori.Enabled = True
    End Sub

    Protected Sub btn_kembali_Click(sender As Object, e As EventArgs) Handles btn_kembali.Click
        Response.Redirect("buku.aspx")
    End Sub

    Protected Sub btn_hapus_Click(sender As Object, e As EventArgs) Handles btn_hapus.Click
        hapus()
    End Sub

    Protected Sub btn_tambah_Click(sender As Object, e As EventArgs) Handles btn_tambah.Click
        Response.Redirect("tambahvolume.aspx?kode=" & Request.QueryString("kode") & "")
    End Sub

    Protected Sub gdv_tampil_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles gdv_tampil.PageIndexChanging
        Me.gdv_tampil.PageIndex = e.NewPageIndex
        Me.gdv_tampil.DataBind()
    End Sub

    Sub tampil()
        Dim modelbku As New ModelBuku
        Dim logicbku As New LogicBuku
        Dim logicvol As New LogicVolume
        Dim logicktg As New LogicKategori
        Dim sunting As ModelBuku

        modelbku.kd_buku = Request.QueryString("kode")
        sunting = logicbku.selectbykode(modelbku.kd_buku)
        lbl_nama.Text = sunting.nama
        lbl_kd_buku.Text = sunting.kd_buku
        tbx_nama.Text = sunting.nama
        tbx_tahun.Text = sunting.tahun
        tbx_pengarang.Text = sunting.pengarang
        tbx_penulis.Text = sunting.penulis
        tbx_sinopsis.Text = sunting.sinopsis
        gdv_tampil.DataSource = logicvol.pencarian(modelbku.kd_buku)
        gdv_tampil.DataBind()

        cbl_kategori.DataSource = logicktg.selectall
        cbl_kategori.DataTextField = "nama"
        cbl_kategori.DataValueField = "kd_kategori"
        cbl_kategori.DataBind()

        Dim i As Integer
        Dim ii As Integer
        Dim isi As New List(Of ModelDetailKategori)
        Dim logicdet As New LogicDetailKategori
        isi = logicdet.selectbyBuku(sunting.kd_buku)
        For i = 0 To cbl_kategori.Items.Count - 1
            For ii = 0 To isi.Count - 1
                If cbl_kategori.Items(i).Value = isi(ii).kd_kategori Then
                    cbl_kategori.Items(i).Selected = True
                End If
            Next
        Next
    End Sub

    Sub hapus()
        Dim modelbku As New ModelBuku
        Dim logicbku As New LogicBuku

        modelbku.kd_buku = lbl_kd_buku.Text
        modelbku.modified_by = Session("admin").username
        logicbku.delete(modelbku)
        Response.Redirect("buku.aspx")
    End Sub
End Class