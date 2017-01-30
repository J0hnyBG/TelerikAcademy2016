<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="_02_Employees._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <asp:GridView CssClass="table table-hover table-striped table-bordered" ID="EmployeeGridView" runat="server" AutoGenerateColumns="False" DataSourceID="EmployeesDataSource">
            <Columns>
                <asp:BoundField DataField="FirstName" HeaderText="FirstName" ReadOnly="True" SortExpression="FirstName"/>
                <asp:BoundField DataField="LastName" HeaderText="LastName" ReadOnly="True" SortExpression="LastName"/>
                <asp:BoundField DataField="EmployeeID" HeaderText="EmployeeID" ReadOnly="True" SortExpression="EmployeeID"/>
                <asp:HyperLinkField DataNavigateUrlFields="EmployeeID" DataNavigateUrlFormatString="EmpDetailsFormView.aspx?EmployeeID={0}" HeaderText="FormView" Text="FormView"/>
                <asp:HyperLinkField DataNavigateUrlFields="EmployeeID" DataNavigateUrlFormatString="EmpDetails.aspx?EmployeeID={0}" HeaderText="DetailsView" Text="DetailsView"/>
            </Columns>
        </asp:GridView>

        <asp:LinqDataSource ID="EmployeesDataSource" runat="server"
                            ContextTypeName="_02_Employees.Data.Repositories.EmployeeRepository"
                            EntityTypeName="Employee"
                            OrderBy="EmployeeID"
                            Select="new (FirstName, LastName, EmployeeID)"
                            TableName="All"
                            OnContextCreating="EmployeesDataSource_OnContextCreating">
        </asp:LinqDataSource>
    </div>

</asp:Content>