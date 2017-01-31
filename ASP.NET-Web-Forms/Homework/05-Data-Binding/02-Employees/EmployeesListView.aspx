<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EmployeesListView.aspx.cs" Inherits="_02_Employees.EmployeesListView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<asp:ListView ID="EmployeeListView" runat="server" DataSourceID="EmployeesDataSource">
<AlternatingItemTemplate>
    <tr style="">
        <td>
            <asp:Label ID="EmployeeIDLabel" runat="server" Text='<%#
                                      this.Eval("EmployeeID") %>'/>
        </td>
        <td>
            <asp:Label ID="LastNameLabel" runat="server" Text='<%#
                                      this.Eval("LastName") %>'/>
        </td>
        <td>
            <asp:Label ID="FirstNameLabel" runat="server" Text='<%#
                                      this.Eval("FirstName") %>'/>
        </td>
        <td>
            <asp:Label ID="TitleLabel" runat="server" Text='<%#
                                      this.Eval("Title") %>'/>
        </td>
        <td>
            <asp:Label ID="BirthDateLabel" runat="server" Text='<%#
                                      this.Eval("BirthDate") %>'/>
        </td>
        <td>
            <asp:Label ID="AddressLabel" runat="server" Text='<%#
                                      this.Eval("Address") %>'/>
        </td>
        <td>
            <asp:Label ID="CityLabel" runat="server" Text='<%#
                                      this.Eval("City") %>'/>
        </td>
        <td>
            <asp:Label ID="RegionLabel" runat="server" Text='<%#
                                      this.Eval("Region") %>'/>
        </td>
        <td>
            <asp:Label ID="PostalCodeLabel" runat="server" Text='<%#
                                      this.Eval("PostalCode") %>'/>
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
            <asp:TextBox ID="EmployeeIDTextBox" runat="server" Text='<%#
                                      Bind("EmployeeID") %>'/>
        </td>
        <td>
            <asp:TextBox ID="LastNameTextBox" runat="server" Text='<%#
                                      Bind("LastName") %>'/>
        </td>
        <td>
            <asp:TextBox ID="FirstNameTextBox" runat="server" Text='<%#
                                      Bind("FirstName") %>'/>
        </td>
        <td>
            <asp:TextBox ID="TitleTextBox" runat="server" Text='<%#
                                      Bind("Title") %>'/>
        </td>
        <td>
            <asp:TextBox ID="BirthDateTextBox" runat="server" Text='<%#
                                      Bind("BirthDate") %>'/>
        </td>
        <td>
            <asp:TextBox ID="AddressTextBox" runat="server" Text='<%#
                                      Bind("Address") %>'/>
        </td>
        <td>
            <asp:TextBox ID="CityTextBox" runat="server" Text='<%#
                                      Bind("City") %>'/>
        </td>
        <td>
            <asp:TextBox ID="RegionTextBox" runat="server" Text='<%#
                                      Bind("Region") %>'/>
        </td>
        <td>
            <asp:TextBox ID="PostalCodeTextBox" runat="server" Text='<%#
                                      Bind("PostalCode") %>'/>
        </td>
        <td>
            <asp:TextBox ID="CountryTextBox" runat="server" Text='<%#
                                      Bind("Country") %>'/>
        </td>
    </tr>
</EditItemTemplate>
<EmptyDataTemplate>
    <table runat="server" style="">
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
            <asp:TextBox ID="EmployeeIDTextBox" runat="server" Text='<%#
                                      Bind("EmployeeID") %>'/>
        </td>
        <td>
            <asp:TextBox ID="LastNameTextBox" runat="server" Text='<%#
                                      Bind("LastName") %>'/>
        </td>
        <td>
            <asp:TextBox ID="FirstNameTextBox" runat="server" Text='<%#
                                      Bind("FirstName") %>'/>
        </td>
        <td>
            <asp:TextBox ID="TitleTextBox" runat="server" Text='<%#
                                      Bind("Title") %>'/>
        </td>
        <td>
            <asp:TextBox ID="BirthDateTextBox" runat="server" Text='<%#
                                      Bind("BirthDate") %>'/>
        </td>
        <td>
            <asp:TextBox ID="AddressTextBox" runat="server" Text='<%#
                                      Bind("Address") %>'/>
        </td>
        <td>
            <asp:TextBox ID="CityTextBox" runat="server" Text='<%#
                                      Bind("City") %>'/>
        </td>
        <td>
            <asp:TextBox ID="RegionTextBox" runat="server" Text='<%#
                                      Bind("Region") %>'/>
        </td>
        <td>
            <asp:TextBox ID="PostalCodeTextBox" runat="server" Text='<%#
                                      Bind("PostalCode") %>'/>
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
            <asp:Label ID="EmployeeIDLabel" runat="server" Text='<%#
                                      this.Eval("EmployeeID") %>'/>
        </td>
        <td>
            <asp:Label ID="LastNameLabel" runat="server" Text='<%#
                                      this.Eval("LastName") %>'/>
        </td>
        <td>
            <asp:Label ID="FirstNameLabel" runat="server" Text='<%#
                                      this.Eval("FirstName") %>'/>
        </td>
        <td>
            <asp:Label ID="TitleLabel" runat="server" Text='<%#
                                      this.Eval("Title") %>'/>
        </td>
        <td>
            <asp:Label ID="BirthDateLabel" runat="server" Text='<%#
                                      this.Eval("BirthDate") %>'/>
        </td>
        <td>
            <asp:Label ID="AddressLabel" runat="server" Text='<%#
                                      this.Eval("Address") %>'/>
        </td>
        <td>
            <asp:Label ID="CityLabel" runat="server" Text='<%#
                                      this.Eval("City") %>'/>
        </td>
        <td>
            <asp:Label ID="RegionLabel" runat="server" Text='<%#
                                      this.Eval("Region") %>'/>
        </td>
        <td>
            <asp:Label ID="PostalCodeLabel" runat="server" Text='<%#
                                      this.Eval("PostalCode") %>'/>
        </td>
        <td>
            <asp:Label ID="CountryLabel" runat="server" Text='<%#
                                      this.Eval("Country") %>'/>
        </td>
    </tr>
</ItemTemplate>
<LayoutTemplate>
    <table runat="server">
        <tr runat="server">
            <td runat="server">
                <table id="itemPlaceholderContainer" runat="server" border="0" style="" class="table table-hover table-striped table-bordered">
                    <tr runat="server" style="">
                        <th runat="server">EmployeeID</th>
                        <th runat="server">LastName</th>
                        <th runat="server">FirstName</th>
                        <th runat="server">Title</th>
                        <th runat="server">BirthDate</th>
                        <th runat="server">Address</th>
                        <th runat="server">City</th>
                        <th runat="server">Region</th>
                        <th runat="server">PostalCode</th>
                        <th runat="server">Country</th>
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
                            <asp:NextPreviousPagerField ButtonCssClass="btn btn-primary" ButtonType="Button" ShowFirstPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False"/>
                            <asp:NumericPagerField CurrentPageLabelCssClass="active"/>
                            <asp:NextPreviousPagerField ButtonCssClass="btn btn-primary" ButtonType="Button" ShowLastPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False"/>
                        </Fields>
                    </asp:DataPager>
            </td>
        </tr>
    </table>
</LayoutTemplate>
<SelectedItemTemplate>
    <tr style="">
        <td>
            <asp:Label ID="EmployeeIDLabel" runat="server" Text='<%#
                                      this.Eval("EmployeeID") %>'/>
        </td>
        <td>
            <asp:Label ID="LastNameLabel" runat="server" Text='<%#
                                      this.Eval("LastName") %>'/>
        </td>
        <td>
            <asp:Label ID="FirstNameLabel" runat="server" Text='<%#
                                      this.Eval("FirstName") %>'/>
        </td>
        <td>
            <asp:Label ID="TitleLabel" runat="server" Text='<%#
                                      this.Eval("Title") %>'/>
        </td>
        <td>
            <asp:Label ID="BirthDateLabel" runat="server" Text='<%#
                                      this.Eval("BirthDate") %>'/>
        </td>
        <td>
            <asp:Label ID="AddressLabel" runat="server" Text='<%#
                                      this.Eval("Address") %>'/>
        </td>
        <td>
            <asp:Label ID="CityLabel" runat="server" Text='<%#
                                      this.Eval("City") %>'/>
        </td>
        <td>
            <asp:Label ID="RegionLabel" runat="server" Text='<%#
                                      this.Eval("Region") %>'/>
        </td>
        <td>
            <asp:Label ID="PostalCodeLabel" runat="server" Text='<%#
                                      this.Eval("PostalCode") %>'/>
        </td>
        <td>
            <asp:Label ID="CountryLabel" runat="server" Text='<%#
                                      this.Eval("Country") %>'/>
        </td>
    </tr>
</SelectedItemTemplate>
</asp:ListView>

<asp:LinqDataSource ID="EmployeesDataSource" runat="server"
                    ContextTypeName="_02_Employees.Data.Repositories.EmployeeRepository"
                    EntityTypeName=""
                    OrderBy="EmployeeID"
                    Select="new (EmployeeID, LastName, FirstName, Title, BirthDate, Address, City, Region, PostalCode, Country)"
                    TableName="All"
                    OnContextCreating="EmployeesDataSource_OnContextCreating">
</asp:LinqDataSource>


</asp:Content>