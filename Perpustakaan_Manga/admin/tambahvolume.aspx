﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master Page/Manga.Master" CodeBehind="tambahvolume.aspx.vb" Inherits="Perpustakaan_Manga.TambahVolume" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_head" runat="server">
    <script type="text/javascript" src="../../Master Page/js/jquery-1.9.1.min.js"></script>
    <script type="text/javascript" src="../../Master Page/js/jquery.onImagesLoad.min.js"></script>
    <script type="text/javascript" src="../../Master Page/js/jquery.responsiveSlides.js"></script>
    <link type="text/css" rel="stylesheet" href="../../Master Page/css/master.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_cari" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_slide" runat="server">
        <img src="../../Master Page/img/1.jpg">
        <img src="../../Master Page/img/2.jpg">
        <img src="../../Master Page/img/3.jpg">
        <img src="../../Master Page/img/4.jpg">
        <img src="../../Master Page/img/5.jpg">
        <img src="../../Master Page/img/6.jpg">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="cph_tombol" runat="server">
    <asp:Button ID="btn_kembali" runat="server" Text="Kembali" CssClass="btn_kembali" />
    <asp:Button ID="btn_simpan" runat="server" Text="Simpan" CssClass="btn_simpan"/>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cph_judul" runat="server">
    Tambah Volume
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cph_isi" runat="server">
        <asp:Table runat="server" style="text-align:right;" ID="tbl_tambah" CellPadding="5" HorizontalAlign="Center">
            <asp:TableRow>
                <asp:TableCell>Judul</asp:TableCell>
                <asp:TableCell style="width:50px; text-align:center;">:</asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="tbx_judul" runat="server" TabIndex="1" Width="200px"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>Volume</asp:TableCell>
                <asp:TableCell style="width:50px; text-align:center;">:</asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="tbx_volume" runat="server" TabIndex="2" Width="200px" TextMode="Number" MaxLength="11"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>Jumlah</asp:TableCell>
                <asp:TableCell style="width:50px; text-align:center;">:</asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="tbx_jumlah" runat="server" TabIndex="4" Width="200px" TextMode="Number" MaxLength="11"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
</asp:Content>
