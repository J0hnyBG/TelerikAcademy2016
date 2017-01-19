<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="_01_WebForms.Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1><a href="/This Picture Changes With The Url.img">HttpHandler page</a> or </h1>
    <div class="jumbotron">

        <h2>Sum integers:</h2>
        <div class="form-group">
            <asp:Label ID="Label1" runat="server" Text="First number:"></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            
        </div>

        <div class="form-group">
            <asp:Label ID="Label2" runat="server" Text="Second number:"></asp:Label>
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            
        </div>
        <div class="form-group">
            <asp:Button ID="SumNumbers"
                        runat="server"
                        Text="Sum"
                        ValidationGroup="TextBoxValidation"
                        OnClick="SumNumbers_Click"/>
        </div>
        <div class="form-group">

            <asp:Label ID="Label3" runat="server" Text="Result: "></asp:Label>

            <asp:Label ID="Result" runat="server" Text="0"></asp:Label>
        </div>
    </div>
</asp:Content>