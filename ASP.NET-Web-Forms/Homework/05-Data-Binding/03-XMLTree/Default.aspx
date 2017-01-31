<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="_03_XMLTree._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="FileUpload">Upload XML file: </asp:Label>
            <asp:FileUpload CssClass="form-control" ID="FileUpload" runat="server"/>
        </div>
        <div class="form-group">
            <asp:Button CssClass="form-control btn btn-success" ID="Submit" runat="server" Text="Submit" OnClick="Submit_OnClick"/>
        </div>
    </div>

    <hr/>
    <div class="row">
        <div class="col-md-3">
            <div class="well">
                <asp:TreeView
                ID="ResultTreeView"
                runat="server"
                OnSelectedNodeChanged="ResultTreeView_SelectedNodeChanged">
            </asp:TreeView>
            </div>
        </div>

        <div class="col-md-9">
            <pre>
                <asp:Literal ID="ExpandedResultLiteral" runat="server" Mode="Encode"></asp:Literal>
            </pre>
        </div>
    </div>
    <asp:XmlDataSource ID="TreeviewDataSource" runat="server">
    </asp:XmlDataSource>
</asp:Content>