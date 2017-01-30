<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EmployeesRepeater.aspx.cs" Inherits="_02_Employees.EmployeesRepeater" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Repeater ID="EmployeeRepeater"
                  runat="server"
                  DataSourceID="EmployeeDataSource"
                  ItemType="_02_Employees.Data.Employee">
        <HeaderTemplate>
            <table class="table table-hover table-striped table-bordered">
            <tr>
                <th>EmployeeID</th>
                <th>First Name</th>
                <th>Last Name</th>
            </tr>
                
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td><%#: Item.EmployeeID %></td>
                <td><%#: Item.FirstName %></td>
                <td><%#: Item.LastName %></td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>

    <asp:LinqDataSource OnContextCreating="EmployeesDataSource_OnContextCreating"
                        ID="EmployeeDataSource"
                        runat="server"
                        ContextTypeName="_02_Employees.Data.Repositories.EmployeeRepository"
                        EntityTypeName="Employee"
                        OrderBy="EmployeeID"
                        TableName="All">
    </asp:LinqDataSource>
</asp:Content>