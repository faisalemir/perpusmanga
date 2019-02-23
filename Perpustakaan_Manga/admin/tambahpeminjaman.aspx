<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master Page/Manga.Master" CodeBehind="tambahpeminjaman.aspx.vb" Inherits="Perpustakaan_Manga.TambahPeminjaman" %>
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
    <asp:Button ID="btn_proses" runat="server" Text="Proses" CssClass="btn_simpan"/>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cph_judul" runat="server">
    Tambah Peminjaman
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cph_isi" runat="server">
    <asp:Table runat="server" ID="tbl_tambah" CellPadding="5">
        <asp:TableRow>
            <asp:TableCell>Kode Anggota</asp:TableCell>
            <asp:TableCell Width="1px">:</asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="tbx_kd_anggota" runat="server" TabIndex="2" Width="90"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>Jangka Waktu</asp:TableCell>
            <asp:TableCell>:</asp:TableCell>
            <asp:TableCell>
                <asp:DropDownList ID="ddl_hari" runat="server" Width="105">
                    <asp:ListItem Value="1" Text="1 Hari"></asp:ListItem>
                    <asp:ListItem Value="3" Text="3 Hari"></asp:ListItem>
                    <asp:ListItem Value="7" Text="7 Hari"></asp:ListItem>
                </asp:DropDownList>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>Kode Volume</asp:TableCell>
            <asp:TableCell>:</asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="tbx_volume" runat="server" TabIndex="2" Width="90"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>Jumlah</asp:TableCell>
            <asp:TableCell>:</asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="tbx_jumlah" runat="server" TabIndex="3" Width="30" Text="1"></asp:TextBox>
                <asp:Button ID="btn_tambah" runat="server" Text="Tambah" />
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <asp:GridView ID="gdv_tampil" runat="server"
            AutoGenerateColumns="False"
            GridLines="None"  
            AllowPaging="True" 
            CssClass="mGrid" 
            PagerStyle-CssClass="pgr" 
            AlternatingRowStyle-CssClass="alt"
            PageSize="5" 
            OnPageIndexChanging="gdv_tampil_PageIndexChanging">  
        <pagersettings mode="NumericFirstLast" PageButtonCount="5" FirstPageText="Awal" LastPageText="Akhir"/>
        <PagerStyle HorizontalAlign="Center" />
        <AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
        <Columns>
            <asp:BoundField DataField="kd_volume" HeaderText="Kode" HeaderStyle-Width="10px" ItemStyle-HorizontalAlign="Center">
                <HeaderStyle Width="10px"></HeaderStyle>
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="volume.buku.nama" HeaderText="Nama Manga">
                <HeaderStyle Width="150px"></HeaderStyle>
            </asp:BoundField>
            <asp:BoundField DataField="volume.judul" HeaderText="Judul">
                <HeaderStyle Width="200px"></HeaderStyle>
            </asp:BoundField>
            <asp:BoundField DataField="volume.volume" HeaderText="Volume">
                <HeaderStyle HorizontalAlign="Center" Width="30px"></HeaderStyle>
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:ButtonField CommandName="min" Text="-" HeaderText="&lt;">
                <HeaderStyle Width="1px"></HeaderStyle>
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:ButtonField>
            <asp:BoundField DataField="jumlah" HeaderText="Jumlah">
                <HeaderStyle Width="30px"></HeaderStyle>
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:ButtonField CommandName="plus" Text="+" HeaderText="&gt;">
                <HeaderStyle Width="1px"></HeaderStyle>
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:ButtonField>
            <asp:TemplateField HeaderText="Tanggal Kembali" ItemStyle-HorizontalAlign="Right">
                <ItemTemplate>
                    <%# CDate(Eval("tgl_kembali")).ToString("D")%>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" Width="50px" />
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:ButtonField CommandName="hapus" Text="Hapus" HeaderText="Opsi">
                <HeaderStyle Width="10px"></HeaderStyle>
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:ButtonField>
        </Columns>
    </asp:GridView>
</asp:Content>
