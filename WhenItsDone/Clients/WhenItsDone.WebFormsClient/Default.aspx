<%@ Page Title="Food.Me" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WhenItsDone.WebFormsClient._Default" %>

<%@ Register Src="~/ViewControls/ContentContainers/TopDishesUserControl.ascx" TagPrefix="uc" TagName="topdishes" %>
<%@ Register Src="~/ViewControls/ContentContainers/TopUsersUserControl.ascx" TagPrefix="uc" TagName="topusers" %>
<%@ Register Src="~/ViewControls/ContentContainers/TopVideoItemsUserControl.ascx" TagPrefix="uc" TagName="topvideos" %>

<asp:Content ContentPlaceHolderID="Stylesheets" runat="server">
    <link href="<%= ResolveUrl("~/Content/Css/TopDishesUserControl.css") %>" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="well content-container-even">
        <uc:topdishes runat="server" />
    </div>
    <hr />
    <div class="well content-container-even">
        <uc:topusers runat="server" />
    </div>
    <hr />
    <div class="well content-container-even">
        <uc:topvideos runat="server" />
    </div>

</asp:Content>
