﻿<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Categories.aspx.cs" Inherits="_02_Todo.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <asp:GridView ID="GridView1"
                      runat="server"
                      DataSourceID="CategoryDataSource"
                      ItemType="_02_Todo.Data.Models.Category"
                      AutoGenerateEditButton="True"
                      AutoGenerateDeleteButton="True"
                      AutoGenerateSelectButton="True"
                      AutoGenerateColumns="False"
                      DataKeyNames="Id"
                      AllowPaging="True"
                      ShowFooter="True"
                      CssClass="table table-hover table-bordered table-striped">
            <Columns>
                <asp:BoundField DataField="Name" HeaderText="Name"/>
            </Columns>
        </asp:GridView>

        <ef:entitydatasource runat="server"
                             ID="CategoryDataSource"
                             EnableFlattening="False"
                             EnableUpdate="True"
                             EnableDelete="True"
                             EnableInsert="True"
                             ContextTypeName="_02_Todo.Data.TodoAppDbContext"
                             EntitySetName="Categories">
        </ef:entitydatasource>

        <hr/>
        <h2>Create new category: </h2>
        <asp:TextBox runat="server" ID="TbCategoryName" CssClass="form-control">

        </asp:TextBox>
        <asp:Button runat="server" CssClass="btn btn-success" Text="Create" OnClick="OnClick"/>
    </div>
    <hr/>
</asp:Content>