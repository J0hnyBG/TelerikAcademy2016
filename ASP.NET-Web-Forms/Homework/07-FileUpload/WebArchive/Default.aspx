<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebArchive._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <asp:Label runat="server" ID="Notification" CssClass="text-danger" Visible="False"></asp:Label>
        <asp:FileUpload ID="FileControl" runat="server"/>
        <asp:Button runat="server" ID="UploadButton"
                    Text="Upload" OnClick="UploadButton_OnClick"/>
    </div>

    <div class="container">
        <asp:Repeater runat="server" DataSourceID="EntityDataSource1"
                      >
            <ItemTemplate>
                <div class="panel panel-default">
                    <div class="panel-heading"><%#: Eval("ArchiveName") + Eval("FileName").ToString() %></div>
                    <div class="panel-body" style="white-space: pre-wrap;">
                        <%#: Eval("Content") %>
                    </div>
                    <div class="panel-footer"><%#  Eval("Id") %></div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
        <ef:entitydatasource runat="server"
                                 ID="EntityDataSource1"
                                 ContextTypeName="WebArchive.Data.ArchiveDbContext"
                                 EntitySetName="Files"/>
    </div>
</asp:Content>