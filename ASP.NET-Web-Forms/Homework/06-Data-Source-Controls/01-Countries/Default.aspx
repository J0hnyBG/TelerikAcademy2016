﻿<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="_01_Countries._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Countries and Towns</h1>
    <div class="row">
        <section class="col-lg-3">
            <asp:ListBox CssClass="form-control"
                         Rows="7"
                         ID="ContinentsListBox"
                         DataSourceID="ContinentsDataSource"
                         ItemType="_01_Countries.Models.Continent"
                         runat="server"
                         DataTextField="Name"
                         DataValueField="Id"
                         SelectionMode="Single"
                         AutoPostBack="True">
            </asp:ListBox>
            <ef:entitydatasource runat="server"
                                 ID="ContinentsDataSource"
                                 ContextTypeName="_01_Countries.Data.CountriesAndTownsDbContext"
                                 EntitySetName="Continents"/>
        </section>

        <section class="col-lg-9">
            <asp:GridView CssClass="table table-bordered table-striped table-hover"
                          ID="CountriesGridView" runat="server"
                          DataSourceID="CoutriesDataSource"
                          ItemType="_01_Countries.Models.Country"
                          AllowPaging="True"
                          AutoGenerateEditButton="True"
                          AutoGenerateDeleteButton="True"
                          AutoGenerateSelectButton="True"
                          AutoGenerateColumns="False"
                          DataKeyNames="Id"
                          AllowSorting="True"
                          SortedAscendingCellStyle-BackColor="LightGray"
                          SortedDescendingCellStyle-BackColor="LightGray">
                <Columns>
                    <asp:boundfield datafield="Name" headertext="Name" SortExpression="Name"/>
                    <asp:boundfield datafield="Language" headertext="Language" SortExpression="Language"/>
                    <asp:boundfield datafield="Population" headertext="Population" SortExpression="Population"/>
                </Columns>
            </asp:GridView>

            <ef:entitydatasource runat="server"
                                 ID="CoutriesDataSource"
                                 EnableUpdate="True"
                                 EnableInsert="True"
                                 EnableDelete="True"
                                 ContextTypeName="_01_Countries.Data.CountriesAndTownsDbContext"
                                 EntitySetName="Countries"
                                 AutoGenerateWhereClause="True">
                <WhereParameters>
                    <asp:ControlParameter DbType="Int32" Name="ContinentId" ControlID="ContinentsListBox" PropertyName="SelectedValue" DefaultValue="1"/>
                </WhereParameters>
            </ef:entitydatasource>
        </section>

        <hr/>
    </div>
    <div class="row">
        <section class="container">
            <h2>Towns: </h2>
            <asp:Repeater runat="server" ID="TownRepeater" ItemType="_01_Countries.Models.Town" DataSourceID="TownsDataSource">
                <ItemTemplate>
                    <div class="panel panel-default">
                        <div class="panel-heading">Name: <%#: Eval("Name") %></div>
                        <div class="panel-body">
                            Population: <%#: Eval("Population") %> <br/>
                            Country: <%#: Eval("Country.Name") %> <br/>
                        </div>
                    </div>

                    <hr/>
                </ItemTemplate>
            </asp:Repeater>
            <ef:entitydatasource runat="server"
                                 EnableFlattening="False"
                                 ID="TownsDataSource"
                                 EnableUpdate="True"
                                 EnableInsert="True"
                                 EnableDelete="True"
                                 ContextTypeName="_01_Countries.Data.CountriesAndTownsDbContext"
                                 EntitySetName="Towns"
                                 AutoGenerateWhereClause="True">
                <WhereParameters>
                    <asp:ControlParameter DbType="Int32" Name="CountryId" ControlID="CountriesGridView" PropertyName="SelectedValue" DefaultValue="1"/>
                </WhereParameters>
            </ef:entitydatasource>
        </section>
    </div>
</asp:Content>