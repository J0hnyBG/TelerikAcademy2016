<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="_01_Hello._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <p> Hello
            <asp:Label runat="server" ID="Result"></asp:Label>
        </p>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <asp:Button ID="Button1" runat="server" Text="Change Name" OnClick="Button1_Click" />
    </div>
    <div class="jumbotron">
        <asp:Label runat="server" ID="Hello"></asp:Label>
        <br/>
        <% this.Response.Write("Hello from .aspx"); %>
    </div>
</asp:Content>
