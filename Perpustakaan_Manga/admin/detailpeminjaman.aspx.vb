Imports Model
Imports Logic
Imports Data
Imports System.Data
Imports System.Data.SqlClient

Public Class DetailPeminjaman
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsNothing(Session("admin")) Then
            If Not IsNothing(Request.QueryString("detail")) Then
                btn_selesai.Visible = True
                btn_kembali.Visible = True
                btn_kembali2.Visible = False
                gdv_history.Visible = False
            ElseIf Not IsNothing(Request.QueryString("history")) Then
                btn_selesai.Visible = False
                btn_kembali.Visible = False
                btn_kembali2.Visible = True
                rowdenda.Visible = False
                gdv_tampil.Visible = False
            End If
            tampil()
        Else
            Response.Redirect("../index.aspx")
        End If
    End Sub

    Protected Sub gdv_tampil_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        Me.gdv_tampil.PageIndex = e.NewPageIndex
        Me.gdv_tampil.DataBind()
    End Sub

    Protected Sub gdv_history_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        Me.gdv_history.PageIndex = e.NewPageIndex
        Me.gdv_history.DataBind()
    End Sub

    Protected Sub btn_selesai_Click(sender As Object, e As EventArgs) Handles btn_selesai.Click
        Dim dpinjam As List(Of ModelDetailPinjam) = Session("dpinjam")
        Dim logicdpj As New LogicDetailPinjam
        Dim logicvol As New LogicVolume
        Dim logicpjm As New LogicPinjam
        Dim hitung As Integer

        If Not dpinjam.Count = 0 Then
            dpinjam(0).pinjam.status_pinjam = True
            dpinjam(0).pinjam.modified_by = Session("admin").username

            Dim cek As Boolean = logicpjm.update(dpinjam(0).pinjam)

            If cek = True Then
                While hitung < dpinjam.Count
                    dpinjam(hitung).volume.tmpstok = dpinjam(hitung).volume.stok + dpinjam(hitung).jumlah
                    logicdpj.update(dpinjam(hitung))
                    logicvol.updatestok(dpinjam(hitung).volume)

                    hitung += 1
                End While
            Else
                logicpjm.rollback(dpinjam(0).pinjam)
                ClientScript.RegisterClientScriptBlock(Me.GetType(), UniqueID, "<script type = 'text/javascript'>window.onload=function(){hide();alert('Terjadi kesalahan, periksa kembali.');};</script>")
            End If
            tampil()
        End If
    End Sub

    Protected Sub gdv_tampil_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gdv_tampil.RowCommand
        Dim index As Integer = Convert.ToInt32(e.CommandArgument)
        Dim dgvrow As GridViewRow = gdv_tampil.Rows(index)
        Dim dpinjam As List(Of ModelDetailPinjam) = Session("dpinjam")
        Dim logicdpj As New LogicDetailPinjam
        Dim pinjam As New ModelPinjam
        Dim logicpjm As New LogicPinjam
        Dim logicvol As New LogicVolume

        If e.CommandName = "kembali" Then
            If Not dpinjam.Count = 0 Then
                dpinjam(index).volume.tmpstok = dpinjam(index).volume.stok + dpinjam(index).jumlah

                pinjam.kd_pinjam = dpinjam(index).kd_pinjam
                pinjam.total = dpinjam(index).pinjam.total
                pinjam.status_pinjam = True
                pinjam.modified_by = Session("admin").username

                Dim cekupdatedpj As Boolean = logicdpj.update(dpinjam(index))
                Dim cekupdatestok As Boolean = logicvol.updatestok(dpinjam(index).volume)
                Dim cekupdatepj As Boolean = logicpjm.update(pinjam)

                If cekupdatedpj = True And cekupdatepj = True And cekupdatestok = True Then
                    tampil()
                Else
                    logicpjm.rollback(pinjam)
                    logicvol.rollbackstok(dpinjam(index).volume)
                    logicdpj.rollback(dpinjam(index))
                    ClientScript.RegisterClientScriptBlock(Me.GetType(), UniqueID, "<script type = 'text/javascript'>window.onload=function(){hide();alert('Terjadi kesalahan, periksa kembali.');};</script>")
                    tampil()
                End If
            End If
        End If
    End Sub

    Protected Sub btn_kembali_Click(sender As Object, e As EventArgs) Handles btn_kembali.Click
        Response.Redirect("peminjaman.aspx")
    End Sub

    Protected Sub btn_kembali2_Click1(sender As Object, e As EventArgs) Handles btn_kembali2.Click
        Response.Redirect("history.aspx")
    End Sub

    Sub tampil()
        If Not IsNothing(Request.QueryString("detail")) Then
            Dim dpinjam As New List(Of ModelDetailPinjam)
            Dim dpinjam2 As New List(Of ModelDetailPinjam)
            Dim logicdpj As New LogicDetailPinjam
            Dim hitung As Integer
            Dim hitung2 As Integer
            Dim totalsementara As Integer

            dpinjam = logicdpj.selectbyPinjamNull(Request.QueryString("detail"))
            If Not dpinjam.Count = 0 Then
                strkd_pinjam.Text = dpinjam(0).kd_pinjam
                strkd_anggota.Text = dpinjam(0).pinjam.anggota.kd_anggota
                strnama.Text = dpinjam(0).pinjam.anggota.nama
                strTgl_pinjam.Text = CDate(dpinjam(0).created_date).ToString("D")

                While hitung < dpinjam.Count
                    If DateDiff(DateInterval.Day, CDate(dpinjam(hitung).tgl_kembali), Date.Today) < 1 Then
                        dpinjam(hitung).sub_total = 0
                    Else
                        dpinjam(hitung).sub_total = Val(DateDiff(DateInterval.Day, CDate(dpinjam(hitung).tgl_kembali), Date.Today)) * Val(dpinjam(hitung).denda.denda)
                    End If
                    totalsementara += dpinjam(hitung).sub_total
                    hitung += 1
                End While

                dpinjam2 = logicdpj.selectbyPinjam(Request.QueryString("detail"))
                While hitung2 < dpinjam2.Count
                    If Not IsDBNull(dpinjam2(hitung2).tgl_pengembalian) Then
                        If DateDiff(DateInterval.Day, CDate(dpinjam2(hitung2).tgl_kembali), Date.Today) < 1 Then
                            dpinjam2(hitung2).sub_total = 0
                        Else
                            dpinjam2(hitung2).sub_total = Val(DateDiff(DateInterval.Day, CDate(dpinjam2(hitung2).tgl_kembali), Date.Today)) * Val(dpinjam2(hitung2).denda.denda)
                        End If
                        dpinjam(0).pinjam.total += dpinjam2(hitung2).sub_total
                    Else
                        dpinjam(0).pinjam.total += dpinjam2(hitung2).sub_total
                    End If
                    hitung2 += 1
                End While

                If Not dpinjam(0).pinjam.total = 0 Then
                    strTotal.Text = Format(dpinjam(0).pinjam.total, "Rp #,#.00") + ",-"
                Else
                    strTotal.Text = "Rp 0,-"
                End If
                If Not totalsementara = 0 Then
                    strtotalnow.Text = Format(totalsementara, "Rp #,#.00") + ",-"
                Else
                    strtotalnow.Text = "Rp 0,-"
                End If
            Else
                Response.Redirect("peminjaman.aspx")
            End If
            Session("dpinjam") = dpinjam
            gdv_tampil.DataSource = dpinjam
            gdv_tampil.DataBind()
        ElseIf Not IsNothing(Request.QueryString("history")) Then
            Dim logicdpj As New LogicDetailPinjam
            Dim dpinjam As List(Of ModelDetailPinjam) = logicdpj.selectbyPinjamNotNull(Request.QueryString("history"))

            strkd_pinjam.Text = dpinjam(0).kd_pinjam
            strkd_anggota.Text = dpinjam(0).pinjam.anggota.kd_anggota
            strnama.Text = dpinjam(0).pinjam.anggota.nama
            strTgl_pinjam.Text = CDate(dpinjam(0).created_date).ToString("D")

            If Not dpinjam(0).pinjam.total = 0 Then
                strTotal.Text = Format(dpinjam(0).pinjam.total, "Rp #,#.00") + ",-"
            Else
                strTotal.Text = "Rp 0,-"
            End If

            gdv_history.DataSource = dpinjam
            gdv_history.DataBind()
        Else
            Response.Redirect("peminjaman.aspx")
        End If
    End Sub
End Class