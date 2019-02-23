<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master Page/Manga.Master" CodeBehind="detailpeminjaman.aspx.vb" Inherits="Perpustakaan_Manga.DetailPeminjaman" %>
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
    <asp:Button ID="btn_kembali2" runat="server" Text="Kembali" CssClass="btn_kembali" />
    <asp:Button ID="btn_selesai" runat="server" Text="Selesai" CssClass="btn_simpan"/>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cph_judul" runat="server">
    Detail Peminjaman
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cph_isi" runat="server">
        <asp:Table runat="server" ID="tbl_tambah" CellPadding="5">
            <asp:TableRow>
                <asp:TableCell>Kode Peminjaman</asp:TableCell>
                <asp:TableCell Width="1px">:</asp:TableCell>
                <asp:TableCell ID="strkd_pinjam"></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>Kode Anggota</asp:TableCell>
                <asp:TableCell Width="1px">:</asp:TableCell>
                <asp:TableCell ID="strkd_anggota"></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>Nama Anggota</asp:TableCell>
                <asp:TableCell>:</asp:TableCell>
                <asp:TableCell ID="strnama"></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>Tanggal Pinjam</asp:TableCell>
                <asp:TableCell>:</asp:TableCell>
                <asp:TableCell ID="strTgl_pinjam"></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>Total Denda</asp:TableCell>
                <asp:TableCell Width="1px">:</asp:TableCell>
                <asp:TableCell ID="strTotal"></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="rowdenda">
                <asp:TableCell>Denda Saat ini</asp:TableCell>
                <asp:TableCell Width="1px">:</asp:TableCell>
                <asp:TableCell ID="strtotalnow"></asp:TableCell>
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
                <asp:BoundField DataField="kd_volume" HeaderText="Kode">
                    <HeaderStyle Width="10px"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="volume.buku.nama" HeaderText="Nama Manga">
                    <HeaderStyle Width="150px"></HeaderStyle>
                </asp:BoundField>
                <asp:BoundField DataField="volume.volume" HeaderText="Volume">
                    <HeaderStyle HorizontalAlign="Center" Width="10px"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="jumlah" HeaderText="Jumlah">
                    <HeaderStyle Width="10px"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:TemplateField HeaderText="Tanggal Kembali" ItemStyle-HorizontalAlign="Right">
                    <ItemTemplate>
                        <%# CDate(Eval("tgl_kembali")).ToString("D")%>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" Width="100px" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Denda">
                    <ItemTemplate>
                        <%# IIf(Eval("sub_total").ToString() <> 0, Format(Eval("sub_total"), "Rp #,#.00"), "Rp 0")%>,-
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" Width="100px" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:ButtonField CommandName="kembali" Text="Kembali" HeaderText="Opsi">
                    <HeaderStyle Width="10px"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:ButtonField>
            </Columns>
        </asp:GridView>
        <asp:GridView ID="gdv_history" runat="server"
                AutoGenerateColumns="False"
                GridLines="None"  
                AllowPaging="True" 
                CssClass="mGrid" 
                PagerStyle-CssClass="pgr" 
                AlternatingRowStyle-CssClass="alt"
                PageSize="5" 
                OnPageIndexChanging="gdv_history_PageIndexChanging">  
            <pagersettings mode="NumericFirstLast" PageButtonCount="5" FirstPageText="Awal" LastPageText="Akhir"/>
            <PagerStyle HorizontalAlign="Center" />
            <AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
            <Columns>
                <asp:BoundField DataField="kd_volume" HeaderText="Kode">
                    <HeaderStyle Width="10px"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="volume.buku.nama" HeaderText="Nama Manga">
                    <HeaderStyle Width="150px"></HeaderStyle>
                </asp:BoundField>
                <asp:BoundField DataField="volume.volume" HeaderText="Volume">
                    <HeaderStyle HorizontalAlign="Center" Width="10px"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="jumlah" HeaderText="Jumlah">
                    <HeaderStyle Width="10px"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:TemplateField HeaderText="Denda">
                    <ItemTemplate>
                        <%#IIf(Eval("sub_total").ToString() <> 0, Format(Eval("sub_total"), "Rp #,#.00"), "Rp 0")%>,-
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" Width="100px" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Kembali" ItemStyle-HorizontalAlign="Right">
                    <ItemTemplate>
                        <%# CDate(Eval("tgl_kembali")).ToString("D")%>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" Width="100px" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Pengembalian" ItemStyle-HorizontalAlign="Right">
                    <ItemTemplate>
                        <%# CDate(Eval("tgl_pengembalian")).ToString("D")%>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" Width="100px" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
</asp:Content>
