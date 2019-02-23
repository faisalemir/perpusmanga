Imports Model
Imports Logic
Imports System.Data
Imports System.Data.SqlClient

Public Class TambahPeminjaman
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsNothing(Session("admin")) Then
            Response.Redirect("../index.aspx")
        End If
        tbx_jumlah.TextMode = TextBoxMode.Number
        tbx_volume.MaxLength = 10
        tbx_kd_anggota.MaxLength = 12
        tampil()
    End Sub

    Protected Sub gdv_tampil_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        With Me.gdv_tampil
            .PageIndex = e.NewPageIndex
            .DataBind()
        End With
    End Sub

    Protected Sub btn_tambah_Click(sender As Object, e As EventArgs) Handles btn_tambah.Click
        Dim arrayDpinjam As New List(Of ModelDetailPinjam)
        Dim dpinjam As New ModelDetailPinjam
        Dim volume As New ModelVolume
        Dim logicvol As New LogicVolume
        Dim logicdnd As New LogicDenda
        Dim denda As New ModelDenda
        Dim index As Integer

        If Not IsNothing(Session("pinjam")) Then
            arrayDpinjam = Session("pinjam")
        End If

        denda = logicdnd.selectFalse
        With dpinjam
            .kd_volume = tbx_volume.Text
            .kd_denda = denda.kd_denda
            .tgl_kembali = Date.Now.AddDays(Val(ddl_hari.Text)).ToString("yyyy-MM-dd")
            .sub_total = Nothing
            .created_by = Session("admin").username
            .modified_by = Session("admin").username
            .volume = logicvol.selectbykode(dpinjam.kd_volume)
            .denda = logicdnd.selectFalse
        End With

        If Not tbx_volume.Text = Nothing Then
            If Not IsNothing(dpinjam.volume.kd_volume) Then
                If Not dpinjam.volume.stok = 0 Then
                    If Val(tbx_jumlah.Text) > dpinjam.volume.stok Then
                        dpinjam.jumlah = dpinjam.volume.stok
                        ClientScript.RegisterClientScriptBlock(Me.GetType(), UniqueID, "<script type = 'text/javascript'>window.onload=function(){hide();alert('Stok tersisa " & dpinjam.jumlah & ".');};</script>")
                    ElseIf Val(tbx_jumlah.Text) < 1 Then
                        dpinjam.jumlah = 1
                        ClientScript.RegisterClientScriptBlock(Me.GetType(), UniqueID, "<script type = 'text/javascript'>window.onload=function(){hide();alert('Minimal satu peminjaman.');};</script>")
                    Else
                        dpinjam.jumlah = Val(tbx_jumlah.Text)
                    End If

                    index = arrayDpinjam.IndexOf(arrayDpinjam.Find(Function(x) x.kd_volume = tbx_volume.Text))
                    If index >= 0 Then
                        arrayDpinjam(index).jumlah += dpinjam.jumlah
                        If arrayDpinjam(index).jumlah > dpinjam.volume.stok Then
                            arrayDpinjam(index).jumlah = dpinjam.volume.stok
                        End If
                    Else
                        arrayDpinjam.Add(dpinjam)
                    End If
                    Session("pinjam") = arrayDpinjam
                Else
                    ClientScript.RegisterClientScriptBlock(Me.GetType(), UniqueID, "<script type = 'text/javascript'>window.onload=function(){hide();alert('Stok habis.');};</script>")
                End If
            Else
                ClientScript.RegisterClientScriptBlock(Me.GetType(), UniqueID, "<script type = 'text/javascript'>window.onload=function(){hide();alert('Kode volume tidak ditemukan.');};</script>")
                tbx_volume.Focus()
            End If
        Else
            ClientScript.RegisterClientScriptBlock(Me.GetType(), UniqueID, "<script type = 'text/javascript'>window.onload=function(){hide();alert('Masukkan kode volume.');};</script>")
            tbx_volume.Focus()
        End If


        tbx_volume.Text = Nothing
        tbx_jumlah.Text = 1
        tampil()
    End Sub

    Protected Sub btn_proses_Click(sender As Object, e As EventArgs) Handles btn_proses.Click
        Dim arrayDpinjam As List(Of ModelDetailPinjam) = Session("pinjam")
        Dim pinjam As New ModelPinjam
        Dim logicpjm As New LogicPinjam
        Dim logicagt As New LogicAnggota
        Dim logicdpj As New LogicDetailPinjam
        Dim logicvol As New LogicVolume
        Dim hitung As Integer

        With pinjam
            .kd_anggota = tbx_kd_anggota.Text
            .status_pinjam = False
            .created_by = Session("admin").username
            .anggota = logicagt.selectbykode(pinjam.kd_anggota)
        End With

        If Not IsNothing(arrayDpinjam) Then
            If Not IsNothing(pinjam.anggota.kd_anggota) Then
                Dim kd_pinjam As String = logicpjm.FindNumber

                pinjam.kd_pinjam = kd_pinjam
                pinjam.kd_anggota = tbx_kd_anggota.Text
                pinjam.status_pinjam = False
                pinjam.created_by = Session("admin").username
                Dim cek As Boolean = logicpjm.insert(pinjam)

                If cek = True Then
                    logicpjm.GenerateNumber()
                    While hitung < arrayDpinjam.Count
                        With arrayDpinjam(hitung)
                            .kd_pinjam = pinjam.kd_pinjam
                            .volume.tmpstok = arrayDpinjam(hitung).volume.stok - arrayDpinjam(hitung).jumlah
                        End With
                        logicdpj.insert(arrayDpinjam(hitung))
                        logicvol.updatestok(arrayDpinjam(hitung).volume)

                        hitung += 1
                    End While
                    Session.Remove("pinjam")
                    Response.Redirect("peminjaman.aspx")
                Else
                    logicpjm.truedelete(pinjam)
                    ClientScript.RegisterClientScriptBlock(Me.GetType(), UniqueID, "<script type = 'text/javascript'>window.onload=function(){hide();alert('Terjadi kesalahan, periksa kembali.');};</script>")
                End If
            Else
                If tbx_kd_anggota.Text = Nothing Then
                    ClientScript.RegisterClientScriptBlock(Me.GetType(), UniqueID, "<script type = 'text/javascript'>window.onload=function(){hide();alert('Masukkan kode anggota.');};</script>")
                    tbx_kd_anggota.Focus()
                Else
                    ClientScript.RegisterClientScriptBlock(Me.GetType(), UniqueID, "<script type = 'text/javascript'>window.onload=function(){hide();alert('Kode Anggota tidak ditemukan.');};</script>")
                    With tbx_kd_anggota
                        .Text = Nothing
                        .Focus()
                    End With
                End If
            End If
        Else
            ClientScript.RegisterClientScriptBlock(Me.GetType(), UniqueID, "<script type = 'text/javascript'>window.onload=function(){hide();alert('Belum ada peminjaman');};</script>")
        End If
    End Sub

    Protected Sub gdv_tampil_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gdv_tampil.RowCommand
        Dim index As Integer = Convert.ToInt32(e.CommandArgument)
        Dim dgvrow As GridViewRow = gdv_tampil.Rows(index)
        Dim arrayDpinjam As List(Of ModelDetailPinjam) = Session("pinjam")
        Dim dpinjam As New ModelDetailPinjam

        If e.CommandName = "hapus" Then
            arrayDpinjam.Remove(arrayDpinjam(index))
            Session("pinjam") = arrayDpinjam
            tampil()
        ElseIf e.CommandName = "min" Then
            arrayDpinjam(index).jumlah -= 1
            If arrayDpinjam(index).jumlah < 1 Then
                arrayDpinjam(index).jumlah = 1
                ClientScript.RegisterClientScriptBlock(Me.GetType(), UniqueID, "<script type = 'text/javascript'>window.onload=function(){hide();alert('Minimal satu peminjaman.');};</script>")
            End If
            tampil()
        ElseIf e.CommandName = "plus" Then
            arrayDpinjam(index).jumlah += 1
            If arrayDpinjam(index).jumlah > arrayDpinjam(index).volume.stok Then
                arrayDpinjam(index).jumlah = arrayDpinjam(index).volume.stok
                ClientScript.RegisterClientScriptBlock(Me.GetType(), UniqueID, "<script type = 'text/javascript'>window.onload=function(){hide();alert('Tidak mencukupi, stok tersisa " & arrayDpinjam(index).jumlah & "');};</script>")
            End If
            tampil()
        End If
    End Sub

    Protected Sub btn_kembali_Click(sender As Object, e As EventArgs) Handles btn_kembali.Click
        Session.Remove("pinjam")
        Response.Redirect("peminjaman.aspx")
    End Sub

    Sub tampil()
        Dim arrayDpinjam As New List(Of ModelDetailPinjam)
        If Not IsNothing(Session("pinjam")) Then
            arrayDpinjam = Session("pinjam")
            btn_proses.Visible = True
        Else
            btn_proses.Visible = False
        End If
        With gdv_tampil
            .DataSource = arrayDpinjam
            .DataBind()
        End With
    End Sub
End Class