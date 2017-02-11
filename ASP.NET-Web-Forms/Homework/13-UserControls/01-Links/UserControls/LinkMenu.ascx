<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LinkMenu.ascx.cs" Inherits="_01_Links.UserControls.LinkMenu" %>
<asp:DataList ID="LinkMenuList" runat="server" ForeColor='<%# this.FontColor %>' Font-Size='<%# this.FontSize %>'>
    <ItemTemplate>
        <li class="list-group-item">
            <asp:LinkButton runat="server"
                            CssClass="myMenuItem"
                            PostBackUrl='<%# Eval("Url") %>'
                            Text='<%# Eval("Title") %>'>
            </asp:LinkButton>
        </li>
    </ItemTemplate>
    <HeaderTemplate>
        <style type="text/css" runat="server">
            .myMenuItem {
                color: <%# "#" + this.FontColor.R.ToString("X2") + this.FontColor.G.ToString("X2") + this.FontColor.B.ToString("X2") %>;
                font-family: <%#: this.FontFamily %>;
            }
        </style>
    </HeaderTemplate>
</asp:DataList>