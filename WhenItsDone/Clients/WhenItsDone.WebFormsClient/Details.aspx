<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="WhenItsDone.WebFormsClient.Details" %>

<asp:Content ContentPlaceHolderID="Stylesheets" runat="server">
    <link href="http://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet">
    <link href="https://cdnjs.cloudflare.com/ajax/libs/materialize/0.98.0/css/materialize.min.css" rel="stylesheet">
    <link href="<%= ResolveUrl("~/Content/Css/FixedNavBarWidth.css") %>" rel="stylesheet" type="text/css" />
    <style>
        td {
            padding: 0;
        }
    </style>
</asp:Content>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">

    <div id="manage-root" class="content-container-even">

        <asp:FormView runat="server" ItemType="WhenItsDone.DTOs.DishViewsDTOs.DishDetailsViewDTO" SelectMethod="Unnamed_GetItem" DataKeyNames="Id">
            <ItemTemplate>
                <section class="content-container-heading">
                    <h3><%#: Item.Name %></h3>
                </section>

                <div class="well">
                    <div class="row">

                        <div class="col s8">
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:FormView>

    </div>

</asp:Content>

<asp:Content ContentPlaceHolderID="JavaScript" runat="server">
    <script type="text/javascript" src="https://code.jquery.com/jquery-2.1.1.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/materialize/0.98.0/js/materialize.min.js"></script>
</asp:Content>
