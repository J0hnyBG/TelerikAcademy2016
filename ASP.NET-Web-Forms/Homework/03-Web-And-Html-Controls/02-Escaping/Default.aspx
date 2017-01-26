<%@ Page ValidateRequest="false" Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="_02_Escaping._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:TextBox ID="TextBox" runat="server"></asp:TextBox>

    <asp:Button ID="Submit" runat="server" Text="Button" OnClick="Submit_OnClick"/>
    <asp:Label ID="Result" runat="server" Text="Label"></asp:Label>
</asp:Content>
