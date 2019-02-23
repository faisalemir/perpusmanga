<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master Page/Manga.Master" CodeBehind="gambar.aspx.vb" Inherits="Perpustakaan_Manga.gambar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_cari" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_slide" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cph_tombol" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cph_judul" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="cph_isi" runat="server">
    <asp:FileUpload ID="fud_gambar" runat="server" />
    <asp:Button ID="btn_upload" runat="server" Text="Upload" />
</asp:Content> 