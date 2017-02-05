<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="_02_Todo._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-lg-3">
        <asp:Repeater runat="server"
                      DataSourceID="CategoryDataSource"
                      ItemType="_02_Todo.Data.Models.Category">
            <HeaderTemplate>
                <div class="list-group">
                <a class="list-group-item" href='<%# $"/Default.aspx" %>'>All categories </a>
            </HeaderTemplate>
            <ItemTemplate>
                <a class="list-group-item" href='<%# $"/Default.aspx?CategoryId={this.Eval("Id")}" %>'><%# this.Eval("Name") %></a>
            </ItemTemplate>
            <FooterTemplate>
                </div>
            </FooterTemplate>
        </asp:Repeater>
        <ef:entitydatasource runat="server"
                             ID="CategoryDataSource"
                             EnableFlattening="False"
                             ContextTypeName="_02_Todo.Data.TodoAppDbContext"
                             EntitySetName="Categories">
        </ef:entitydatasource>
    </div>
    <div class="col-lg-9">
        <asp:ListView runat="server"
                      ID="TodosListView"
                      ItemType="_02_Todo.Data.Models.Todo"
                      DataSourceID="TodoDataSource"
                      InsertItemPosition="FirstItem">
            <LayoutTemplate>
                <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
            </LayoutTemplate>
            <ItemTemplate>
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <h3 class="panel-title">
                            <%#: Item.Title %>
                            <span>
                                <asp:Button  runat="server" 
                                    CssClass="btn btn-warning btn-sm" 
                                    CommandName="Edit" 
                                    Text="Edit"/>
                                <asp:Button runat="server"
                                    ID="DeleteButton"
                                    CssClass="btn btn-danger btn-sm"
                                    CommandName="Delete"
                                    CommandArgument='<%# Bind("Id") %>'
                                    Text="Delete"/>
                            </span>
                        </h3>
                    </div>
                    <div class="panel-body">
                        <%#: Item.Body %>
                    </div>
                    <div class="panel-footer">
                        <span><%#: Item.CreatedAt %></span>
                    </div>

                </div>
            </ItemTemplate>
            <EmptyDataTemplate>
                <h2>No todos found!</h2>
            </EmptyDataTemplate>
            <InsertItemTemplate>
                <a data-toggle="collapse" class="btn btn-success" data-target="#insert-item">Create TODO</a>
                <div id="insert-item" class="collapse collapsed">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            <h3 class="panel-title">
                                Insert new item
                            </h3>
                        </div>
                        <div class="panel-body">
                            <asp:TextBox runat="server"
                                         ID="TextBox1"
                                         Text='<%# Bind("Id") %>'
                                         Visible="False"/>

                            <div class="form-group">
                                <label>Title: </label>
                                <asp:TextBox runat="server"
                                             CssClass="form-control"
                                             ID="TextBox2"
                                             Text='<%# Bind("Title") %>'
                                             MaxLength="1000"/>
                            </div>

                            <div class="form-group">
                                <label>Description: </label>
                                <asp:TextBox runat="server"
                                             CssClass="form-control"
                                             TextMode="MultiLine"
                                             ID="BodyTextBox"
                                             Text='<%# Bind("Body") %>'
                                             MaxLength="10000"/>
                            </div>

                            <div class="form-group">
                                <label>Category: </label>
                                <asp:DropDownList runat="server"
                                                  SelectedValue='<%# Bind("CategoryId") %>'
                                                  ID="TodoCategory"
                                                  ItemType="_02_Todo.Data.Models.Category"
                                                  DataSourceID="CategoryDataSource"
                                                  DataTextField="Name"
                                                  DataValueField="Id"/>
                            </div>

                        </div>
                        <div class="panel-footer">
                            <asp:Button runat="server"
                                        CssClass="btn btn-warning btn-sm"
                                        CommandName="Cancel"
                                        Text="Cancel"/>

                            <asp:Button runat="server"
                                        CssClass="btn btn-success"
                                        CommandName="Insert"
                                        Text="Insert"/>
                        </div>
                    </div>
                </div>
            </InsertItemTemplate>
            <EditItemTemplate>
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <h3 class="panel-title">
                            <%#: Item.Title %>
                        </h3>
                    </div>
                    <div class="panel-body">
                        <asp:TextBox runat="server"
                                     ID="TextBox1"
                                     Text='<%# Bind("Id") %>'
                                     Visible="False"/>

                        <div class="form-group">
                            <label>Title: </label>
                            <asp:TextBox runat="server"
                                         CssClass="form-control"
                                         ID="TextBox2"
                                         Text='<%# Bind("Title") %>'
                                         MaxLength="1000"/>
                        </div>

                        <div class="form-group">
                            <label>Description: </label>
                            <asp:TextBox runat="server"
                                         CssClass="form-control"
                                         TextMode="MultiLine"
                                         ID="BodyTextBox"
                                         Text='<%# Bind("Body") %>'
                                         MaxLength="10000"/>
                        </div>

                        <div class="form-group">
                            <label>Category: </label>
                            <asp:DropDownList runat="server"
                                              SelectedValue='<%# Bind("CategoryId") %>'
                                              ID="TodoCategory"
                                              ItemType="_02_Todo.Data.Models.Category"
                                              DataSourceID="CategoryDataSource"
                                              DataTextField="Name"
                                              DataValueField="Id"/>
                        </div>

                    </div>
                    <div class="panel-footer">
                        <asp:Button runat="server"
                                    CssClass="btn btn-warning btn-xs"
                                    CommandName="Cancel"
                                    Text="Cancel"/>
                        <asp:Button runat="server"
                                    CssClass="btn btn-success btn-xs"
                                    CommandName="Update"
                                    Text="Update"/>
                    </div>
                </div>
            </EditItemTemplate>
            <ItemSeparatorTemplate>
                <hr/>
            </ItemSeparatorTemplate>
        </asp:ListView>
        <ef:entitydatasource runat="server"
                             ID="TodoDataSource"
                             EnableFlattening="False"
                             ContextTypeName="_02_Todo.Data.TodoAppDbContext"
                             EntitySetName="Todos"
                             EnableUpdate="True"
                             EnableInsert="True"
                             EnableDelete="True"
                             AutoGenerateWhereClause="True">
            <WhereParameters>
                <asp:QueryStringParameter Name="CategoryId" Type="Int32" DefaultValue="1" QueryStringField="CategoryId"/>
            </WhereParameters>
        </ef:entitydatasource>
    </div>

</asp:Content>