<%@ Page Title="Food.Me" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WhenItsDone.WebFormsClient._Default" %>

<%@ Register Src="~/ViewControls/ContentContainers/TopDishesUserControl.ascx" TagPrefix="uc" TagName="topdishes" %>
<%@ Register Src="~/ViewControls/ContentContainers/TopUsersUserControl.ascx" TagPrefix="uc" TagName="topusers" %>

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
        <section class="content-container-heading">
            <h1>test</h1>
        </section>
        <section class="content-container-content">
        </section>
    </div>

</asp:Content>
