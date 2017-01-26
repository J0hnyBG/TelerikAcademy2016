<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="_01_Random._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <p runat="server" id="ErrorResult" style="color: #f00"></p>

    <p>Html Server Controls</p>
    <label>From</label>
    <input id="HtmlFrom" type="number" runat="server" maxlength="9"/>
    <br/>
    <label>To</label>
    <input id="HtmlTo" type="number" runat="server" maxlength="9"/>

    <input type="submit"
           id="SubmitHtmlForm"
           OnServerClick="SubmitHtmlForm_OnServerClick"
           runat="server"/>

    <p runat="server" id="HtmlResult"></p>

    <hr/>
    <p>Web Server Controls</p>
    <asp:Label runat="server" ID="LabelFrom" Text="From"></asp:Label>
    <asp:TextBox runat="server" ID="WebFrom" MaxLength="9"></asp:TextBox>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="WebFrom" runat="server" ErrorMessage="Only Numbers allowed" ValidationExpression="\d+"></asp:RegularExpressionValidator>
    <br/>
    <asp:Label runat="server" ID="Label1" Text="To"></asp:Label>
    <asp:TextBox runat="server" ID="WebTo" MaxLength="9"></asp:TextBox>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="WebTo" runat="server" ErrorMessage="Only Numbers allowed" ValidationExpression="\d+"></asp:RegularExpressionValidator>
    <asp:Button ID="SubmitWebForm" runat="server" OnClick="SubmitWebForm_OnClick" Text="Submit"/>
    <p runat="server" id="WebResult"></p>

</asp:Content>