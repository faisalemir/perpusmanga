Imports Model
Imports Logic
Imports Data
Imports System.Data
Imports System.Data.SqlClient

Public Class TambahBuku
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsNothing(Session("admin")) Then
            Response.Redirect("../index.aspx")
        Else
            If Not Me.IsPostBack Then
                tampil()
            End If
        End If
    End Sub

    Protected Sub btn_simpan_Click(sender As Object, e As EventArgs) Handles btn_simpan.Click
        Dim modelbku As New ModelBuku
        Dim logicbku As New LogicBuku
        Dim modelgbr As New ModelGambar
        Dim logicgbr As New LogicGambar
        Dim modelktg As New ModelKategori
        Dim logicktg As New LogicKategori
        Dim kategori As New List(Of ModelKategori)
        Dim modeldkg As New ModelDetailKategori
        Dim logicdkg As New LogicDetailKategori

        If tbx_nama.Text = Nothing Or tbx_tahun.Text = Nothing Or tbx_pengarang.Text = Nothing Or tbx_penulis.Text = Nothing Or tbx_sinopsis.Text = Nothing Then
            ClientScript.RegisterClientScriptBlock(Me.GetType(), UniqueID, "<script type = 'text/javascript'>window.onload=function(){hide();alert('Pastikan semua kolom sudah terisi.');};</script>")
            If tbx_nama.Text = Nothing Then
                tbx_nama.Focus()
            ElseIf tbx_tahun.Text = Nothing Then
                tbx_tahun.Focus()
            ElseIf tbx_pengarang.Text = Nothing Then
                tbx_pengarang.Focus()
            ElseIf tbx_penulis.Text = Nothing Then
                tbx_penulis.Focus()
            ElseIf tbx_sinopsis.Text = Nothing Then
                tbx_sinopsis.Focus()
            End If
        Else
            If Not fup_gambar.PostedFile.ContentLength = 0 Then
                Dim kd_gambar As String = logicgbr.FindNumber
                logicgbr.selectbykode(kd_gambar)
                Dim kd_buku As String = logicbku.FindNumber

                With modelgbr
                    .kd_gambar = kd_gambar
                    .nama = fup_gambar.PostedFile.FileName
                    .created_by = Session("admin").username
                End With

                With modelbku
                    .kd_buku = kd_buku
                    .kd_gambar = modelgbr.kd_gambar
                    .nama = tbx_nama.Text
                    .tahun = Val(tbx_tahun.Text)
                    .pengarang = tbx_pengarang.Text
                    .penulis = tbx_penulis.Text
                    .sinopsis = tbx_sinopsis.Text
                    .created_by = Session("admin").username
                End With

                Dim i As Integer
                For i = 0 To cbl_kategori.Items.Count - 1
                    If cbl_kategori.Items(i).Selected = True Then
                        kategori.Add(logicktg.selectbykode(cbl_kategori.Items(i).Value))
                    End If
                Next

                Dim cekgambar As Boolean = logicgbr.insert(modelgbr)
                Dim cekbuku As Boolean = logicbku.insert(modelbku)

                If Not kategori.Count = 0 Then
                    If cekgambar = True And cekbuku = True Then
                        logicgbr.GenerateNumber()
                        logicgbr.selectbykode(kd_gambar)
                        logicbku.GenerateNumber()
                        Dim link As String = "../images/" + modelgbr.kd_gambar + ".jpg"
                        fup_gambar.SaveAs(Server.MapPath(link))

                        Dim ii As Integer
                        For ii = 0 To kategori.Count - 1
                            With modeldkg
                                .kd_buku = modelbku.kd_buku
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
                        logicgbr.truedelete(modelgbr)
                        logicbku.truedelete(modelbku)
                        ClientScript.RegisterClientScriptBlock(Me.GetType(), UniqueID, "<script type = 'text/javascript'>window.onload=function(){hide();alert('Terjadi kesalahan, periksa kembali.');};</script>")
                    End If
                Else
                    ClientScript.RegisterClientScriptBlock(Me.GetType(), UniqueID, "<script type = 'text/javascript'>window.onload=function(){hide();alert('Kategori belum terpilih.');};</script>")
                    cbl_kategori.Focus()
                End If
            Else
                ClientScript.RegisterClientScriptBlock(Me.GetType(), UniqueID, "<script type = 'text/javascript'>window.onload=function(){hide();alert('Belum memilih gambar.');};</script>")
                fup_gambar.Focus()
            End If
        End If
    End Sub

    Protected Sub btn_kembali_Click(sender As Object, e As EventArgs) Handles btn_kembali.Click
        Response.Redirect("Buku.aspx")
    End Sub

    Sub tampil()
        Dim logicktg As New LogicKategori

        cbl_kategori.DataSource = logicktg.selectall
        cbl_kategori.DataTextField = "nama"
        cbl_kategori.DataValueField = "kd_kategori"
        cbl_kategori.DataBind()
    End Sub
End Class