<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="_04_ExtendedEmployees._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row text-center">
        <asp:ListView ID="ListView1" runat="server" DataSourceID="EmployeesDataSource">
            <AlternatingItemTemplate>
                <tr style="">
                    <td>
                        <asp:Label ID="FirstNameLabel" runat="server" Text='<%#
                                        this.Eval("FirstName") %>'/>
                    </td>
                    <td>
                        <asp:Label ID="LastNameLabel" runat="server" Text='<%#
                                        this.Eval("LastName") %>'/>
                    </td>
                    <td>
                        <asp:Label ID="CityLabel" runat="server" Text='<%#
                                        this.Eval("City") %>'/>
                    </td>
                    <td>
                        <asp:Label ID="CountryLabel" runat="server" Text='<%#
                                        this.Eval("Country") %>'/>
                    </td>
                </tr>
            </AlternatingItemTemplate>
            <EditItemTemplate>
                <tr style="">
                    <td>
                        <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Update"/>
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel"/>
                    </td>
                    <td>
                        <asp:TextBox ID="FirstNameTextBox" runat="server" Text='<%#
                                        Bind("FirstName") %>'/>
                    </td>
                    <td>
                        <asp:TextBox ID="LastNameTextBox" runat="server" Text='<%#
                                        Bind("LastName") %>'/>
                    </td>
                    <td>
                        <asp:TextBox ID="CityTextBox" runat="server" Text='<%#
                                        Bind("City") %>'/>
                    </td>
                    <td>
                        <asp:TextBox ID="CountryTextBox" runat="server" Text='<%#
                                        Bind("Country") %>'/>
                    </td>
                </tr>
            </EditItemTemplate>
            <EmptyDataTemplate>
                <table runat="server" style="" class="center">
                    <tr>
                        <td>No data was returned.</td>
                    </tr>
                </table>
            </EmptyDataTemplate>
            <InsertItemTemplate>
                <tr style="">
                    <td>
                        <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insert"/>
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Clear"/>
                    </td>
                    <td>
                        <asp:TextBox ID="FirstNameTextBox" runat="server" Text='<%#
                                        Bind("FirstName") %>'/>
                    </td>
                    <td>
                        <asp:TextBox ID="LastNameTextBox" runat="server" Text='<%#
                                        Bind("LastName") %>'/>
                    </td>
                    <td>
                        <asp:TextBox ID="CityTextBox" runat="server" Text='<%#
                                        Bind("City") %>'/>
                    </td>
                    <td>
                        <asp:TextBox ID="CountryTextBox" runat="server" Text='<%#
                                        Bind("Country") %>'/>
                    </td>
                </tr>
            </InsertItemTemplate>
            <ItemTemplate>
                <tr style="">
                    <td>
                        <asp:Label ID="FirstNameLabel" runat="server" Text='<%#
                                        this.Eval("FirstName") %>'/>
                    </td>
                    <td>
                        <asp:Label ID="LastNameLabel" runat="server" Text='<%#
                                        this.Eval("LastName") %>'/>
                    </td>
                    <td>
                        <asp:Label ID="CityLabel" runat="server" Text='<%#
                                        this.Eval("City") %>'/>
                    </td>
                    <td>
                        <asp:Label ID="CountryLabel" runat="server" Text='<%#
                                        this.Eval("Country") %>'/>
                    </td>
                </tr>
            </ItemTemplate>
            <LayoutTemplate>
                <table runat="server" class="center">
                    <tr runat="server">
                        <td runat="server">
                            <table id="itemPlaceholderContainer" runat="server" border="0" style="" class="table table-hover table-striped table-bordered">
                                <tr runat="server" style="">
                                    <th class="text-center" runat="server">
                                        <asp:LinkButton runat="server"
                                                        CommandName="Sort"
                                                        CommandArgument="FirstName"
                                                        Text="FirstName">
                                        </asp:LinkButton>
                                    </th>
                                    <th class="text-center" runat="server">
                                        <asp:LinkButton runat="server"
                                                        CommandName="Sort"
                                                        CommandArgument="LastName"
                                                        Text="LastName">
                                        </asp:LinkButton>
                                    </th>
                                    <th class="text-center" runat="server">
                                        <asp:LinkButton runat="server"
                                                        CommandName="Sort"
                                                        CommandArgument="City"
                                                        Text="City">
                                        </asp:LinkButton>
                                    </th>
                                    <th class="text-center" runat="server">
                                        <asp:LinkButton runat="server"
                                                        CommandName="Sort"
                                                        CommandArgument="Country"
                                                        Text="Country">
                                        </asp:LinkButton>
                                    </th>
                                </tr>
                                <tr id="itemPlaceholder" runat="server">
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr runat="server">
                        <td runat="server" style="">
                            <asp:DataPager ID="DataPager1" runat="server">
                                <Fields>
                                    <asp:NextPreviousPagerField ButtonCssClass="btn btn-primary" ButtonType="Button" ShowFirstPageButton="True" ShowLastPageButton="True"/>
                                </Fields>
                            </asp:DataPager>
                        </td>
                    </tr>
                </table>
            </LayoutTemplate>
            <SelectedItemTemplate>
                <tr style="">
                    <td>
                        <asp:Label ID="FirstNameLabel" runat="server" Text='<%#
                                        this.Eval("FirstName") %>'/>
                    </td>
                    <td>
                        <asp:Label ID="LastNameLabel" runat="server" Text='<%#
                                        this.Eval("LastName") %>'/>
                    </td>
                    <td>
                        <asp:Label ID="CityLabel" runat="server" Text='<%#
                                        this.Eval("City") %>'/>
                    </td>
                    <td>
                        <asp:Label ID="CountryLabel" runat="server" Text='<%#
                                        this.Eval("Country") %>'/>
                    </td>
                </tr>
            </SelectedItemTemplate>
        </asp:ListView>
    </div>
    <asp:LinqDataSource ID="EmployeesDataSource" runat="server" OnContextCreating="EmployeesDataSource_OnContextCreating" ContextTypeName="_02_Employees.Data.Repositories.EmployeeRepository" EntityTypeName="" Select="new (FirstName, LastName, City, Country)" TableName="All" OrderBy="FirstName, LastName"></asp:LinqDataSource>
</asp:Content>