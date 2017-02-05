<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="_03_Twitter._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h2>Get Tweets for User:</h2>
        <div class="form-group">
            <asp:TextBox CssClass="form-control" runat="server" ID="UserTextBox"></asp:TextBox>
            <asp:Button CssClass="btn btn-default" runat="server" ID="GetTweetsButton" Text="Get Tweets"/>
        </div>
    </div>
    <div class="well">
        <asp:GridView runat="server"
                      CssClass="table table-hover table-bordered table-striped"
                      ID="TweetsGridView"
                      DataSourceID="TweetsDataSource"
                      AutoGenerateColumns="False">
            <Columns>
                <asp:TemplateField HeaderText="">
                    <ItemTemplate>
                        <img src="<%#: Eval("ImgUrl") %>"/>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="FullText" HeaderText="FullText" SortExpression="FullText"/>
                <asp:BoundField DataField="CreatedAt" HeaderText="CreatedAt" SortExpression="CreatedAt"/>
                <asp:BoundField DataField="DisplayName" HeaderText="DisplayName" SortExpression="DisplayName"/>
                <asp:TemplateField HeaderText="Link">
                    <ItemTemplate>
                        <a target="_blank" href="<%#: Eval("Url") %>">See on Twitter</a>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

        <asp:ObjectDataSource
            runat="server"
            ID="TweetsDataSource"
            TypeName="_03_Twitter.Tweets.TweetService"
            SelectMethod="GeSimpleTweets">
            <SelectParameters>
                <asp:ControlParameter ControlID="UserTextBox" Name="userName" PropertyName="Text" Type="String"/>
            </SelectParameters>

        </asp:ObjectDataSource>
    </div>
</asp:Content>