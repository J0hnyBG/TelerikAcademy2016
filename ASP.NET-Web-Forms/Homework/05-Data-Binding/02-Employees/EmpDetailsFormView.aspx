<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EmpDetailsFormView.aspx.cs" Inherits="_02_Employees.EmpDetailsFormView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:FormView CssClass="table table-hover table-striped table-bordered" ID="EmployeeFormView" runat="server" DataSourceID="EmployeeDataSource" ItemType="_02_Employees.Data.Employee">
        <HeaderTemplate>
            <asp:HyperLink CssClass="btn btn-primary" runat="server" NavigateUrl="Default.aspx">Back</asp:HyperLink>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td>EmployeeID</td>
                <td><%#: Item.EmployeeID %></td>
            </tr>
            <tr>
                <td>First Name</td>
                <td><%#: Item.FirstName %></td>
            </tr>
            <tr>
                <td>Last Name</td>
                <td><%#: Item.LastName %></td>
            </tr>
            <tr>
                <td>Title</td>
                <td><%#: Item.Title %></td>
            </tr>
            <tr>
                <td>And</td>
                <td>So on...</td>
            </tr>
        </ItemTemplate>
    </asp:FormView>

    <asp:LinqDataSource OnContextCreating="EmployeesDataSource_OnContextCreating"
                        ID="EmployeeDataSource"
                        runat="server"
                        ContextTypeName="_02_Employees.Data.Repositories.EmployeeRepository"
                        EntityTypeName="Employee"
                        OrderBy="EmployeeID"
                        TableName="All"
                        Where="EmployeeID == @EmployeeID">
        <WhereParameters>
            <asp:QueryStringParameter Name="EmployeeID" QueryStringField="EmployeeID" Type="Int32" DefaultValue="1"/>
        </WhereParameters>
    </asp:LinqDataSource>
</asp:Content>