<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="_04_TicTacToe._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <asp:Button ID="ButtonReset" runat="server" Text="Reset game" OnClick="ButtonReset_OnClick"/>
        <br/>
        <asp:Panel CssClass="text-center" ID="GameField" runat="server">
            <table>
                <tr>
                    <td>
                        <asp:Button CssClass="game-box" runat="server"
                                    Text=""
                                    ID="Button1"
                                    CommandArgument="0"
                                    CommandName="ProcessTurn"
                                    OnCommand="OnTurnCommand"/>
                    </td>
                    <td>
                        <asp:Button CssClass="game-box" runat="server"
                                    Text="X"
                                    ID="Button2"
                                    CommandArgument="1"
                                    CommandName="ProcessTurn"
                                    OnCommand="OnTurnCommand"/>
                    </td>
                    <td>
                        <asp:Button CssClass="game-box" runat="server"
                                    Text="X"
                                    ID="Button3"
                                    CommandArgument="2"
                                    CommandName="ProcessTurn"
                                    OnCommand="OnTurnCommand"/>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button CssClass="game-box" runat="server"
                                    Text="X" ID="Button4"
                                    CommandArgument="3"
                                    CommandName="ProcessTurn"
                                    OnCommand="OnTurnCommand"/>
                    </td>
                    <td>
                        <asp:Button CssClass="game-box" runat="server"
                                    Text="X"
                                    ID="Button5"
                                    CommandArgument="4"
                                    CommandName="ProcessTurn"
                                    OnCommand="OnTurnCommand"/>
                    </td>
                    <td>
                        <asp:Button CssClass="game-box" runat="server"
                                    Text="X"
                                    ID="Button6"
                                    CommandArgument="5"
                                    CommandName="ProcessTurn"
                                    OnCommand="OnTurnCommand"/>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button CssClass="game-box" runat="server"
                                    Text="X"
                                    ID="Button7"
                                    CommandArgument="6"
                                    CommandName="ProcessTurn"
                                    OnCommand="OnTurnCommand"/>
                    </td>
                    <td>
                        <asp:Button CssClass="game-box" runat="server"
                                    Text="X"
                                    ID="Button8"
                                    CommandArgument="7"
                                    CommandName="ProcessTurn"
                                    OnCommand="OnTurnCommand"/>
                    </td>
                    <td>
                        <asp:Button CssClass="game-box" runat="server"
                                    Text="X"
                                    ID="Button9"
                                    CommandArgument="8"
                                    CommandName="ProcessTurn"
                                    OnCommand="OnTurnCommand"/>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <h2 id="Result" runat="server" Text=""></h2>
    </div>
</asp:Content>