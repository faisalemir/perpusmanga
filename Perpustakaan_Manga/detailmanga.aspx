<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master Page/Manga.Master" CodeBehind="detailmanga.aspx.vb" Inherits="Perpustakaan_Manga.Detailmanga" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_head" runat="server">
    <script type="text/javascript" src="Master Page/js/jquery-1.9.1.min.js"></script>
    <script type="text/javascript" src="Master Page/js/jquery.onImagesLoad.min.js"></script>
    <script type="text/javascript" src="Master Page/js/jquery.responsiveSlides.js"></script>
    <link type="text/css" rel="stylesheet" href="Master Page/css/master.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_cari" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_slide" runat="server">
        <img src="Master Page/img/1.jpg">
        <img src="Master Page/img/2.jpg">
        <img src="Master Page/img/3.jpg">
        <img src="Master Page/img/4.jpg">
        <img src="Master Page/img/5.jpg">
        <img src="Master Page/img/6.jpg">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="cph_tombol" runat="server">
    <asp:Button ID="btn_kembali" runat="server" Text="Kembali" CssClass="btn_kembali" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cph_judul" runat="server">
    <asp:Label ID="lbl_nama" runat="server"></asp:Label>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cph_isi" runat="server">
    <asp:table ID="tbl_detail" runat="server" CellPadding="7">
        <asp:TableRow>
            <asp:TableCell rowspan="6" Width="320px">
                <asp:Image ID="Img" runat="server" Width="300px"/>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell Width="100px" ForeColor="#8e44ad">Nama Manga</asp:TableCell>
            <asp:TableCell Width="1px">:</asp:TableCell>
            <asp:TableCell ID="strNama"></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell Width="100px" ForeColor="#8e44ad">Tahun</asp:TableCell>
            <asp:TableCell Width="1px">:</asp:TableCell>
            <asp:TableCell ID="strTahun"></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell ForeColor="#8e44ad">Pengarang</asp:TableCell>
            <asp:TableCell>:</asp:TableCell>
            <asp:TableCell ID="strPengarang"></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell ForeColor="#8e44ad">Penulis</asp:TableCell>
            <asp:TableCell>:</asp:TableCell>
            <asp:TableCell ID="strPenulis"></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell ForeColor="#8e44ad">Kategori</asp:TableCell>
            <asp:TableCell>:</asp:TableCell>
            <asp:TableCell ID="strKategori">
                <asp:BulletedList ID="bul_kategori" runat="server" CssClass="list">
                </asp:BulletedList>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell ForeColor="#8e44ad" ColumnSpan="4">Sinopsis:</asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell ColumnSpan="4" ID="strSinopsis"></asp:TableCell>
        </asp:TableRow>
    </asp:table>
    <asp:GridView ID="gdv_tampil" runat="server"
        AutoGenerateColumns="False"
        GridLines="None"  
        AllowPaging="True" 
        CssClass="mGrid" 
        PagerStyle-CssClass="pgr" 
        AlternatingRowStyle-CssClass="alt" 
        OnPageIndexChanging="gdv_tampil_PageIndexChanging">  
        <pagersettings mode="NumericFirstLast" PageButtonCount="5" FirstPageText="Awal" LastPageText="Akhir"/>
        <PagerStyle HorizontalAlign="Center" />
            <AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
        <Columns>
            <asp:BoundField DataField="buku.nama" HeaderText="Volume">
                <ItemStyle HorizontalAlign="Right"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="volume">
                <HeaderStyle Width="20px"></HeaderStyle>
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="judul">
                <HeaderStyle HorizontalAlign="Left" Width="500px"></HeaderStyle>
            </asp:BoundField>
            <asp:BoundField DataField="ket" HeaderText="Katerangan">
                <HeaderStyle Width="150px"></HeaderStyle>
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:TemplateField HeaderText="Ditambahkan">
                <ItemTemplate>
                    <%# CDate(Eval("created_date")).ToString("D")%>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" Width="150px" />
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
