<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master Page/Manga.Master" CodeBehind="admin.aspx.vb" Inherits="Perpustakaan_Manga.Admin" %>

<asp:Content ID="Content3" ContentPlaceHolderID="cph_head" runat="server">
    <script type="text/javascript" src="../Master Page/js/jquery-1.9.1.min.js"></script>
    <script type="text/javascript" src="../Master Page/js/jquery.onImagesLoad.min.js"></script>
    <script type="text/javascript" src="../Master Page/js/jquery.responsiveSlides.js"></script>
    <link type="text/css" rel="stylesheet" href="../Master Page/css/master.css" />
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="cph_cari" runat="server">
    <div class="div_cari">
        <asp:TextBox ID="tbx_cari" runat="server" Width="291px" ToolTip="Cari nama admin . ." CssClass="tbx_cari" TextMode="Search"></asp:TextBox>
        <asp:Button ID="btn_cari" runat="server" Text="Cari" CssClass="btn_cari" />
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cph_slide" runat="server">
        <img src="../Master Page/img/1.jpg">
        <img src="../Master Page/img/2.jpg">
        <img src="../Master Page/img/3.jpg">
        <img src="../Master Page/img/4.jpg">
        <img src="../Master Page/img/5.jpg">
        <img src="../Master Page/img/6.jpg">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cph_tombol" runat="server">
    <a class="btn_tambah" href="tambahadmin.aspx">Tambah Admin</a>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_judul" runat="server">
    Data Admin
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_isi" runat="server">
    <asp:GridView ID="gdv_tampil" runat="server" 
        AutoGenerateColumns="False"
        GridLines="None"  
        AllowPaging="True" 
        CssClass="mGrid" 
        PagerStyle-CssClass="pgr" 
        PageSize="15" 
        OnPageIndexChanging="gdv_tampil_PageIndexChanging">  
        <pagersettings mode="NumericFirstLast" PageButtonCount="5" FirstPageText="Awal" LastPageText="Akhir"/>
        <PagerStyle HorizontalAlign="Center" />
        <AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
        <Columns>
            <asp:BoundField DataField="kd_admin" HeaderText="Kode" Visible="false"/>
            <asp:BoundField DataField="nama" HeaderText="Nama">
                <HeaderStyle Width="200px"></HeaderStyle>
            </asp:BoundField>
            <asp:BoundField DataField="alamat" HeaderText="Alamat">
                <HeaderStyle Width="270px"></HeaderStyle>
            </asp:BoundField>
            <asp:BoundField DataField="tmpjk" HeaderText="Jenis Kelamin">
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="ktp" HeaderText="No. KTP"/>
            <asp:BoundField DataField="telp" HeaderText="No. Telp"/>
            <asp:BoundField DataField="hakakses.akses" HeaderText="Akses">
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:HyperLinkField DataNavigateUrlFields="kd_admin" DataNavigateUrlFormatString="~/admin/detailadmin.aspx?kode={0}" NavigateUrl="~/admin/detailadmin.aspx" Text="Detail">
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:HyperLinkField>
        </Columns>
    </asp:GridView> 
</asp:Content>
