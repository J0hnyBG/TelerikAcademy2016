<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="_05_Calculator._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="col-lg-4"></div>
        <div class="col-lg-4">
            <asp:Panel ID="CalculatorPanel" runat="server">
                <table class="table table-responsive text-center calc-box">
                    <th colspan="4">
                        <asp:TextBox CssClass="result" ID="Operation" Visible="false" runat="server" Enabled="False"></asp:TextBox>
                        <asp:TextBox CssClass="result" ID="Previous" Visible="false" runat="server" Enabled="False"></asp:TextBox>
                        <asp:TextBox CssClass="result" ID="Result" runat="server" Enabled="True"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1"
                                                        ControlToValidate="Result" runat="server"
                                                        ErrorMessage="Only Numbers and . allowed" 
                            ValidationExpression="^\d*\.{0,1}\d+$"></asp:RegularExpressionValidator>
                    </th>
                    <tr>
                        <td>
                            <asp:Button runat="server"
                                        ID="Button1"
                                        OnCommand="OnNumberClickedCommand"
                                        Text="1"
                                        CommandArgument="1"/>
                        </td>

                        <td>
                            <asp:Button runat="server"
                                        ID="Button2"
                                        OnCommand="OnNumberClickedCommand"
                                        Text="2"
                                        CommandArgument="2"/>

                        </td>
                        <td>
                            <asp:Button runat="server"
                                        ID="Button3"
                                        OnCommand="OnNumberClickedCommand"
                                        Text="3"
                                        CommandArgument="3"/>

                        </td>
                            <td>
                                <asp:Button runat="server"
                                            ID="Button11"
                                            Text="+"
                                            OnCommand="OnOperationClickedCommand"
                                            CommandArgument="+"/>

                            </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button runat="server"
                                        ID="Button4"
                                        OnCommand="OnNumberClickedCommand"
                                        Text="4"
                                        CommandArgument="4"/>
                        </td>
                        <td>
                            <asp:Button runat="server"
                                        ID="Button5"
                                        OnCommand="OnNumberClickedCommand"
                                        Text="5"
                                        CommandArgument="5"/>
                        </td>
                        <td>
                            <asp:Button runat="server"
                                        ID="Button6"
                                        OnCommand="OnNumberClickedCommand"
                                        Text="6"
                                        CommandArgument="6"/>
                        </td>
                        <td>
                            <asp:Button runat="server"
                                        ID="Button12"
                                        OnCommand="OnOperationClickedCommand"
                                        Text="-"

                                        CommandArgument="-"/>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button runat="server"
                                        ID="Button7"
                                        OnCommand="OnNumberClickedCommand"
                                        Text="7"
                                        CommandArgument="7"/>
                        </td>
                        <td>
                            <asp:Button runat="server"
                                        ID="Button8"
                                        OnCommand="OnNumberClickedCommand"
                                        Text="8"
                                        CommandArgument="8"/>
                        </td>
                        <td>
                            <asp:Button runat="server"
                                        ID="Button9"
                                        OnCommand="OnNumberClickedCommand"
                                        Text="9"
                                        CommandArgument="9"/>
                        </td>
                        <td>
                            <asp:Button runat="server"
                                        ID="Button13"
                                        Text="x"
                                        OnCommand="OnOperationClickedCommand"
                                        CommandArgument="*"/>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button runat="server"
                                        ID="Button14"
                                        Text="Clear"
                                        OnCommand="OnClearClickedCommand"/>
                        </td>
                        <td>
                            <asp:Button runat="server"
                                        ID="Button10"
                                        OnCommand="OnNumberClickedCommand"
                                        Text="0"
                                        CommandArgument="0"/>

                        </td>
                        <td>
                            <asp:Button runat="server"
                                        ID="Button15"
                                        OnCommand="OnOperationClickedCommand"
                                        Text="/"
                                        CommandArgument="/"/>
                        </td>
                        <td>
                            <asp:Button runat="server"
                                        ID="Button16"
                                        OnCommand="OnOperationClickedCommand"
                                        Text="&#8730;"
                                        CommandArgument="sqrt"/>
                        </td>
                    </tr>
                    <tfoot>
                    <tr>
                        <td colspan="4">
                            <asp:Button runat="server"
                                        ID="Button17"
                                        OnCommand="OnCalculateCommand"
                                        Text="="
                                        CommandArgument="="/>
                        </td>
                    </tr>
                    </tfoot>
                </table>
            </asp:Panel>
        </div>
        <div class="col-lg-4">
            <asp:Label runat="server" ID="ErrorLabel"></asp:Label>
        </div>
    </div>
</asp:Content>