<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="WhenItsDone.WebFormsClient.Details" %>

<asp:Content ContentPlaceHolderID="Stylesheets" runat="server">
</asp:Content>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <h1 id="Test" runat="server"></h1>

    <asp:FormView runat="server" ItemType="WhenItsDone.DTOs.DishViewsDTOs.DishDetailsViewDTO" SelectMethod="Unnamed_GetItem" DataKeyNames="Id">
        <ItemTemplate>
            <h1><%#: Item.Name %></h1>
        </ItemTemplate>
    </asp:FormView>
</asp:Content>

<asp:Content ContentPlaceHolderID="JavaScript" runat="server">
</asp:Content>
