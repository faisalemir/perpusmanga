<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master Page/Manga.Master" CodeBehind="login.aspx.vb" Inherits="Perpustakaan_Manga.login" %>
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
<asp:Content ID="Content4" ContentPlaceHolderID="cph_judul" runat="server">
    Login
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cph_isi" runat="server">
    <div class="login">
        <asp:Label ID="lbl_user" runat="server" Text="Username :"></asp:Label>
        <br />
        <asp:TextBox ID="tbx_user" runat="server" TabIndex="1"></asp:TextBox>
        <br />
        <asp:Label ID="lbl_pass" runat="server" Text="Password :"></asp:Label>
        <br />
        <asp:TextBox ID="tbx_pass" runat="server" TabIndex="2"></asp:TextBox>
        <br />
    </div>
    <div style="text-align:center; margin-top:10px;">
        <asp:Button ID="btn_login" runat="server" Text="Login" CssClass="btn_login" TabIndex="3"/>
        <br />
        <br />
        <asp:Label ID="lbl_salah" runat="server" Text="Username atau Password tidak tepat." Visible="false"></asp:Label>
        <br />
        <asp:Label ID="lbl_injek" runat="server" Text="Ooo tidak bisa~ :P" Visible="false"></asp:Label>
        <br />
    </div>
    </asp:Content>
