<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="_01_Cars._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-4">
            <h2>Search: </h2>
            <div class="form-group">
                <asp:Label runat="server" CssClass="control-label" AssociatedControlID="ProducerDropDownList">Producer</asp:Label>
                <asp:DropDownList CssClass="form-control" ID="ProducerDropDownList" AutoPostBack="true" OnSelectedIndexChanged="ProducerChanged" runat="server">
                </asp:DropDownList>
            </div>
            <div class="form-group">
                <asp:Label runat="server" CssClass="control-label" AssociatedControlID="ModelDropDownList">Model</asp:Label>
                <asp:DropDownList CssClass="form-control" ID="ModelDropDownList" runat="server">
                </asp:DropDownList>
            </div>

            <div class="form-group">
                <asp:Label runat="server" CssClass="control-label" AssociatedControlID="ExtrasCheckBoxList">Extras</asp:Label>
                <div class="checkbox">
                    <asp:CheckBoxList ID="ExtrasCheckBoxList" runat="server">
                    </asp:CheckBoxList>
                </div>
            </div>

            <div class="form-group">
                <asp:Label runat="server" CssClass="control-label" AssociatedControlID="EngineRadioButtonList">Engine type</asp:Label>
                <div class="radio">
                    <asp:RadioButtonList ID="EngineRadioButtonList" runat="server">
                    </asp:RadioButtonList>
                </div>

                <asp:RequiredFieldValidator CssClass="text-danger" ControlToValidate="EngineRadioButtonList" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Engine is required">
                </asp:RequiredFieldValidator>
            </div>

            <asp:Button ID="Submit" runat="server" OnClick="SearchCarsSubmit" Text="Search"/>
        </div>
        <div class="col-md-8">
            <asp:Repeater ID="ResultsRepeater" ItemType="_01_Cars.Models.Contracts.ICarModel" runat="server" OnItemDataBound="CarRepeaterDataBound">
                <HeaderTemplate>
                    <h2>
                       Results: 
                    </h2>
                </HeaderTemplate>
                <ItemTemplate>
                    <div class="panel panel-default">
                        <div class="panel-heading"><%#: Item.Name %></div>
                        <div class="panel-body">
                            <p>
                                Engine: <em><%#: Item.Engine %></em>
                            </p>
                            <ul class="list-group">
                                <asp:Repeater runat="server" ID="ExtrasRepeater" ItemType="_01_Cars.Models.Enums.Extra">
                                    <ItemTemplate>
                                        <li class="list-group-item">
                                            <%#: Item %>
                                        </li>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>