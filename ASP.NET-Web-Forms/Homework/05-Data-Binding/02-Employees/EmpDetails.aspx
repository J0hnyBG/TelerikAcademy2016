<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EmpDetails.aspx.cs" Inherits="_02_Employees.EmpDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:HyperLink CssClass="btn btn-primary" runat="server" NavigateUrl="Default.aspx">Back</asp:HyperLink>

    <asp:DetailsView CssClass="table table-hover table-striped table-bordered"
                     ID="EmployeeDetailsView"
                     runat="server" Height="50px"
                     Width="125px"
                     AutoGenerateRows="False"
                     DataSourceID="EmployeeDataSource">
        <Fields>
            <asp:BoundField DataField="EmployeeID" HeaderText="EmployeeID" SortExpression="EmployeeID"/>
            <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName"/>
            <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName"/>
            <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title"/>
            <asp:BoundField DataField="TitleOfCourtesy" HeaderText="TitleOfCourtesy" SortExpression="TitleOfCourtesy"/>
            <asp:BoundField DataField="BirthDate" HeaderText="BirthDate" SortExpression="BirthDate"/>
            <asp:BoundField DataField="HireDate" HeaderText="HireDate" SortExpression="HireDate"/>
            <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address"/>
            <asp:BoundField DataField="City" HeaderText="City" SortExpression="City"/>
            <asp:BoundField DataField="Region" HeaderText="Region" SortExpression="Region"/>
            <asp:BoundField DataField="PostalCode" HeaderText="PostalCode" SortExpression="PostalCode"/>
            <asp:BoundField DataField="Country" HeaderText="Country" SortExpression="Country"/>
            <asp:BoundField DataField="HomePhone" HeaderText="HomePhone" SortExpression="HomePhone"/>
            <asp:BoundField DataField="Extension" HeaderText="Extension" SortExpression="Extension"/>
            <asp:BoundField DataField="Notes" HeaderText="Notes" SortExpression="Notes"/>
            <asp:BoundField DataField="ReportsTo" HeaderText="ReportsTo" SortExpression="ReportsTo"/>
            <asp:BoundField DataField="PhotoPath" HeaderText="PhotoPath" SortExpression="PhotoPath"/>
        </Fields>
    </asp:DetailsView>
    <asp:LinqDataSource OnContextCreating="EmployeesDataSource_OnContextCreating"
                        ID="EmployeeDataSource"
                        runat="server"
                        ContextTypeName="_02_Employees.Data.Repositories.EmployeeRepository"
                        EntityTypeName="Employee"
                        OrderBy="EmployeeID"
                        TableName="All" 
                        Where="EmployeeID == @EmployeeID">
        <WhereParameters>
            <asp:QueryStringParameter DefaultValue="1" Name="EmployeeID" QueryStringField="EmployeeID" Type="Int32" />
        </WhereParameters>
    </asp:LinqDataSource>

    </asp:Content>
