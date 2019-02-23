<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master Page/Manga.Master" CodeBehind="anggota.aspx.vb" Inherits="Perpustakaan_Manga.Anggota" %>

<asp:Content ID="Content3" ContentPlaceHolderID="cph_head" runat="server">
    <script type="text/javascript" src="../Master Page/js/jquery-1.9.1.min.js"></script>
    <script type="text/javascript" src="../Master Page/js/jquery.onImagesLoad.min.js"></script>
    <script type="text/javascript" src="../Master Page/js/jquery.responsiveSlides.js"></script>
    <link type="text/css" rel="stylesheet" href="../Master Page/css/master.css" />
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="cph_cari" runat="server">
    <div class="div_cari">
        <asp:TextBox ID="tbx_cari" runat="server" Width="291px" ToolTip="Cari nama anggota . ." CssClass="tbx_cari" TextMode="Search"></asp:TextBox>
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
    <a class="btn_tambah" href="tambahanggota.aspx">Tambah Anggota</a>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_judul" runat="server">
    Data Anggota
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_isi" runat="server">
    <asp:GridView ID="gdv_tampil" runat="server" 
        AutoGenerateColumns="False"
        GridLines="None"  
        AllowPaging="true" 
        CssClass="mGrid" 
        PagerStyle-CssClass="pgr" 
        AlternatingRowStyle-CssClass="alt"
        PageSize="20" 
        OnPageIndexChanging="gdv_tampil_PageIndexChanging">  
        <pagersettings mode="NumericFirstLast" PageButtonCount="5" FirstPageText="Awal" LastPageText="Akhir"/>
        <PagerStyle HorizontalAlign="Center" />
        <Columns>
            <asp:BoundField DataField="kd_anggota" HeaderText="Kode" />
            <asp:BoundField DataField="nama" HeaderText="Nama" HeaderStyle-Width="200px"/>
            <asp:BoundField DataField="alamat" HeaderText="Alamat" HeaderStyle-Width="270px"/>
            <asp:BoundField DataField="tmpjk" HeaderText="Jenis Kelamin" ItemStyle-HorizontalAlign="Center"/>
            <asp:BoundField DataField="ktp" HeaderText="No. KTP"/>
            <asp:BoundField DataField="telp" HeaderText="No. Telp"/>
            <asp:HyperLinkField DataNavigateUrlFields="kd_anggota" DataNavigateUrlFormatString="~/admin/detailanggota.aspx?kode={0}" NavigateUrl="~/admin/detailanggota.aspx" Text="Detail" ItemStyle-HorizontalAlign="Center"/>
        </Columns>
    </asp:GridView>
</asp:Content>
