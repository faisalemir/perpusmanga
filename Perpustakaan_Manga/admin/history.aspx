<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master Page/Manga.Master" CodeBehind="history.aspx.vb" Inherits="Perpustakaan_Manga.History" %>

<asp:Content ID="Content3" ContentPlaceHolderID="cph_head" runat="server">
    <script type="text/javascript" src="../Master Page/js/jquery-1.9.1.min.js"></script>
    <script type="text/javascript" src="../Master Page/js/jquery.onImagesLoad.min.js"></script>
    <script type="text/javascript" src="../Master Page/js/jquery.responsiveSlides.js"></script>
    <link type="text/css" rel="stylesheet" href="../Master Page/css/master.css" />
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="cph_cari" runat="server">
    <div class="div_cari">
        <asp:TextBox ID="tbx_cari" runat="server" Width="291px" ToolTip="Cari kode pinjam . ." CssClass="tbx_cari" TextMode="Search"></asp:TextBox>
        <asp:Button ID="btn_cari" runat="server" Text="Cari" CssClass="btn_cari"/>
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
    <a class="btn_kembali" href="peminjaman.aspx">Kembali</a>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_judul" runat="server">
    History Peminjaman
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_isi" runat="server">
    <asp:GridView ID="gdv_tampil" runat="server" 
        AutoGenerateColumns="False"
        GridLines="None"  
        AllowPaging="True" 
        CssClass="mGrid" 
        PagerStyle-CssClass="pgr" 
        AlternatingRowStyle-CssClass="alt"
        PageSize="20" 
        OnPageIndexChanging="gdv_tampil_PageIndexChanging">  
        <pagersettings mode="NumericFirstLast" PageButtonCount="5" FirstPageText="Awal" LastPageText="Akhir"/>
        <PagerStyle HorizontalAlign="Center" />
            <AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
        <Columns>
            <asp:BoundField DataField="kd_pinjam" HeaderStyle-Width="50px" HeaderText="Kode Pinjam">
                <HeaderStyle Width="50px"></HeaderStyle>
            </asp:BoundField>
            <asp:BoundField DataField="kd_anggota" HeaderStyle-Width="50px" HeaderText="Kode Anggota">
                <HeaderStyle Width="50px"></HeaderStyle>
            </asp:BoundField>
            <asp:BoundField DataField="anggota.nama" HeaderText="Nama Anggota"/>
            <asp:TemplateField HeaderText="Denda">
                <ItemTemplate>
                    <%#IIf(Eval("total").ToString() <> 0, Format(Eval("total"), "Rp #,#.00"), "Rp 0")%>,-
                </ItemTemplate>
                <HeaderStyle Width="100px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Tanggal Pinjam" ItemStyle-HorizontalAlign="Right">
                <ItemTemplate>
                    <%# CDate(Eval("created_date")).ToString("D")%>
                </ItemTemplate>
                <HeaderStyle Width="100px" />
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:HyperLinkField DataNavigateUrlFields="kd_pinjam" DataNavigateUrlFormatString="~/admin/detailpeminjaman.aspx?history={0}" NavigateUrl="~/admin/detailpeminjaman.aspx" Text="Detail" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="50px">
                <ItemStyle HorizontalAlign="Center" Width="50px"></ItemStyle>
            </asp:HyperLinkField>
        </Columns>
    </asp:GridView>
</asp:Content>
