<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ViewSwitcher.ascx.cs" Inherits="_03_Students.ViewSwitcher" %>
<div id="viewSwitcher">
    <%: this.CurrentView %> view | <a href="<%: this.SwitchUrl %>" data-ajax="false">Switch to <%: this.AlternateView %></a>
</div>