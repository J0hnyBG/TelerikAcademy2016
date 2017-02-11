<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="_01_Links._Default" %>
<%@ Register TagPrefix="uc" TagName="LinkMenu" Src="UserControls/LinkMenu.ascx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <uc:LinkMenu runat="server" ID="LinkMenu" FontColor="#309f30" FontSize="30" FontFamily="Tahoma"></uc:LinkMenu>
    </div>
</asp:Content>
