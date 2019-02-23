<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master Page/Manga.Master" CodeBehind="tambahbuku.aspx.vb" Inherits="Perpustakaan_Manga.TambahBuku" %>
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
    Tambah Manga
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cph_isi" runat="server">
        <asp:Table runat="server" style="text-align:right;" ID="tbl_tambah" CellPadding="5" HorizontalAlign="Center">
            <asp:TableRow>
                <asp:TableCell>Gambar</asp:TableCell>
                <asp:TableCell Width="1px">:</asp:TableCell>
                <asp:TableCell>
                    <asp:FileUpload ID="fup_gambar" runat="server" Width="300px" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>Nama Manga</asp:TableCell>
                <asp:TableCell>:</asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="tbx_nama" runat="server" TabIndex="1" Width="300px"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>Tahun</asp:TableCell>
                <asp:TableCell>:</asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="tbx_tahun" runat="server" TabIndex="2" Width="300px" TextMode="Number" MaxLength="4"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>Pengarang</asp:TableCell>
                <asp:TableCell>:</asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="tbx_pengarang" runat="server" TabIndex="3" Width="300px"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>Penulis</asp:TableCell>
                <asp:TableCell>:</asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="tbx_penulis" runat="server" TabIndex="4" Width="300px"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>Kategori</asp:TableCell>
                <asp:TableCell>:</asp:TableCell>
                <asp:TableCell>
                    <asp:CheckBoxList ID="cbl_kategori" runat="server" CssClass="cbl_kategori" RepeatColumns="3" TabIndex="5" ></asp:CheckBoxList>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>Sinopsis</asp:TableCell>
                <asp:TableCell>:</asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="tbx_sinopsis" runat="server" TabIndex="6" Width="300px" TextMode="MultiLine" Height="100px"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
</asp:Content>
