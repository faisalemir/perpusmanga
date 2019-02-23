Imports Model
Imports Logic

Public Class Detailmanga
    Inherits System.Web.UI.Page

    Dim modelbku As New ModelBuku
    Dim logicbku As New LogicBuku
    Dim modelvol As New ModelVolume
    Dim logicvol As New LogicVolume

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim type As String = Request.QueryString.Keys.Item(0)
        If type = "kode" Then
            tampil()
        Else
            Response.Redirect("index.aspx")
        End If
    End Sub

    Sub tampil()
        Dim logicdkg As New LogicDetailKategori
        Dim modeldkg As New List(Of ModelDetailKategori)
        Dim vol As New List(Of ModelVolume)
        Dim get_kode As String = Request.QueryString("kode")

        modelbku.kd_buku = get_kode
        modelbku = logicbku.selectbykode(modelbku.kd_buku)

        lbl_nama.Text = modelbku.nama
        strNama.Text = modelbku.nama
        strTahun.Text = modelbku.tahun
        strPengarang.Text = modelbku.pengarang
        strPenulis.Text = modelbku.penulis
        strSinopsis.Text = modelbku.sinopsis

        modeldkg = logicdkg.selectbyBuku(modelbku.kd_buku)
        Dim hitung As Integer = 0
        While (hitung < modeldkg.Count)
            bul_kategori.Items.Add(modeldkg(hitung).kategori.nama)
            hitung += 1
        End While

        Img.ImageUrl = "../images/" + modelbku.kd_gambar + ".jpg"

        vol = logicvol.pencarian(get_kode)

        Dim i As Integer = 0
        While i < vol.Count
            vol(i).ket = Konversi.stok(vol(i).stok)
            i += 1
        End While

        gdv_tampil.DataSource = vol
        gdv_tampil.DataBind()
    End Sub

    Protected Sub btn_kembali_Click(sender As Object, e As EventArgs) Handles btn_kembali.Click
        Response.Redirect("daftarmanga.aspx")
    End Sub

    Protected Sub gdv_tampil_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles gdv_tampil.PageIndexChanging
        Me.gdv_tampil.PageIndex = e.NewPageIndex
        Me.gdv_tampil.DataBind()
    End Sub
End Class