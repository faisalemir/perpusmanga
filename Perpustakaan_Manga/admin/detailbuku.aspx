<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master Page/Manga.Master" CodeBehind="detailbuku.aspx.vb" Inherits="Perpustakaan_Manga.DetailBuku" %>
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
    <asp:Button ID="btn_sunting" runat="server" Text="Sunting" CssClass="btn_sunting" />
    <asp:Button ID="btn_simpan" runat="server" Text="Simpan" CssClass="btn_simpan" Visible="false"/>
    <asp:Button ID="btn_tambah" runat="server" Text="Tambah Volume" CssClass="btn_tambah" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cph_judul" runat="server">
    Detail <asp:Label ID="lbl_nama" runat="server"></asp:Label>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cph_isi" runat="server">
    <asp:Table runat="server" style="text-align:right;" ID="tbl_tambah" CellPadding="5" HorizontalAlign="Center">
        <asp:TableRow Visible="false">
            <asp:TableCell>Kode Buku</asp:TableCell>
            <asp:TableCell style="width:50px; text-align:center;">:</asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lbl_kd_buku" runat="server"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow Visible="false" ID="tr_gambar">
            <asp:TableCell>Gambar</asp:TableCell>
            <asp:TableCell Width="1px">:</asp:TableCell>
            <asp:TableCell>
                <asp:FileUpload ID="fup_gambar" runat="server" Width="300px" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>Nama Manga</asp:TableCell>
            <asp:TableCell style="width:50px; text-align:center;">:</asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="tbx_nama" runat="server" TabIndex="1" Width="300px" ReadOnly="true"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>Tahun</asp:TableCell>
            <asp:TableCell style="width:50px; text-align:center;">:</asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="tbx_tahun" runat="server" TabIndex="2" Width="300px" ReadOnly="true" TextMode="Number" MaxLength="4"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>Pengarang</asp:TableCell>
            <asp:TableCell style="width:50px; text-align:center;">:</asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="tbx_pengarang" runat="server" TabIndex="4" Width="300px" ReadOnly="true"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>Penulis</asp:TableCell>
            <asp:TableCell style="width:50px; text-align:center;">:</asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="tbx_penulis" runat="server" TabIndex="5" Width="300px" ReadOnly="true"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>Kategori</asp:TableCell>
            <asp:TableCell>:</asp:TableCell>
            <asp:TableCell>
                <asp:CheckBoxList ID="cbl_kategori" runat="server" CssClass="cbl_kategori" RepeatColumns="3" TabIndex="5" Enabled="false"></asp:CheckBoxList>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>Sinopsis</asp:TableCell>
            <asp:TableCell style="width:50px; text-align:center;">:</asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="tbx_sinopsis" runat="server" TabIndex="6" Width="310px" ReadOnly="true" TextMode="MultiLine" Height="100px"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <asp:GridView ID="gdv_tampil" runat="server"
        AutoGenerateColumns="False"
        GridLines="None"  
        AllowPaging="true" 
        CssClass="mGrid" 
        PagerStyle-CssClass="pgr" 
        AlternatingRowStyle-CssClass="alt"
        PageSize="10" 
        OnPageIndexChanging="gdv_tampil_PageIndexChanging">  
        <pagersettings mode="NumericFirstLast" PageButtonCount="5" FirstPageText="Awal" LastPageText="Akhir"/>
        <PagerStyle HorizontalAlign="Center" />
        <Columns>
            <asp:BoundField DataField="kd_volume" Visible="false" />
            <asp:BoundField DataField="buku.nama" ItemStyle-HorizontalAlign="Right"/>
            <asp:BoundField DataField="volume" HeaderStyle-Width="20px" ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField DataField="judul" HeaderText="Judul" HeaderStyle-Width="400px" HeaderStyle-HorizontalAlign="Left"/>
            <asp:BoundField DataField="jumlah" HeaderText="Jumlah" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="Center"/>
            <asp:BoundField DataField="stok" HeaderText="Stok" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="Center"/>
            <asp:BoundField DataField="created_date" HeaderText="Ditambahkan" HeaderStyle-Width="100px" ItemStyle-HorizontalAlign="Center"/>
            <asp:HyperLinkField DataNavigateUrlFields="kd_volume" DataNavigateUrlFormatString="~/admin/detailvolume.aspx?kode={0}" NavigateUrl="~/admin/detailvolume.aspx" Text="Detail" ItemStyle-HorizontalAlign="Center"/>
        </Columns>
    </asp:GridView>
    <div style="width:100%; text-align:center;"><asp:Button ID="btn_hapus" runat="server" Text="Hapus" CssClass="btn_hapus"/></div>
</asp:Content>
