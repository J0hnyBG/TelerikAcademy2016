<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="_03_Students._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-lg-3">
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="FirstName">First name</asp:Label>
                <asp:TextBox ID="FirstName" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="LastName">Last name</asp:Label>
                <asp:TextBox ID="LastName" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="Number">Student Number</asp:Label>
                <asp:TextBox ID="Number" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="University">University</asp:Label>
                <asp:DropDownList ID="University" runat="server" CssClass="form-control">
                    <asp:ListItem Value="Uni1"></asp:ListItem>
                    <asp:ListItem Value="Uni2"></asp:ListItem>
                    <asp:ListItem Value="Uni3"></asp:ListItem>
                </asp:DropDownList>
            </div>

            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="Courses">Courses</asp:Label>
                <asp:ListBox ID="Courses" runat="server" SelectionMode="Multiple" CssClass="form-control">
                    <asp:ListItem Value="Course 1"></asp:ListItem>
                    <asp:ListItem Value="Course 2"></asp:ListItem>
                    <asp:ListItem Value="Course 3"></asp:ListItem>
                    <asp:ListItem Value="Course 4"></asp:ListItem>
                    <asp:ListItem Value="Course 5"></asp:ListItem>
                    <asp:ListItem Value="Course 6"></asp:ListItem>
                    <asp:ListItem Value="Course 7"></asp:ListItem>
                </asp:ListBox>
            </div>
            <asp:Button ID="CreateStudent" CssClass="btn btn-primary" OnClick="CreateStudent_OnClick" runat="server" Text="Button"/>

        </div>
        <div class="col-lg-9">
            <h2>Existing students</h2>
            <table class="table table-striped table-responsive table-hover">
                <asp:Repeater ID="Students" runat="server">
                    <HeaderTemplate>
                        <thead>
                            <th>First Name</th>
                            <th>Last Name</th>
                            <th>Student Number</th>
                            <th>University</th>
                            <th>Courses</th>
                        </thead>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td><%# this.Eval("FirstName") %></td>
                            <td><%# this.Eval("LastName") %></td>
                            <td><%# this.Eval("Number") %></td>
                            <td><%# this.Eval("University") %></td>
                            <td><%# string.Join(", ", this.Eval("Courses") as IList<string>) %></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
        </div>
    </div>

</asp:Content>