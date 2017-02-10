<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminPage.aspx.cs" Inherits="WhenItsDone.WebFormsClient.AdminPage" %>

<%@ Register Src="~/ViewControls/AdminPageControls/APWorkersControl.ascx" TagPrefix="uc" TagName="APWorkersControl" %>

<asp:Content ContentPlaceHolderID="Stylesheets" runat="server">
    <link href="<%= ResolveUrl("~/Content/Css/AdminPage.css") %>" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    
    <uc:APWorkersControl runat="server" ID="APWorkersControl" />

</asp:Content>



<asp:Content ContentPlaceHolderID="JavaScript" runat="server">
</asp:Content>
