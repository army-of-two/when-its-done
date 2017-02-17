<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="WhenItsDone.WebFormsClient.Details" %>

<asp:Content ContentPlaceHolderID="Stylesheets" runat="server">
    <link href="http://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet">
    <link href="https://cdnjs.cloudflare.com/ajax/libs/materialize/0.98.0/css/materialize.min.css" rel="stylesheet">
    <link href="<%= ResolveUrl("~/Content/Css/FixedNavBarWidth.css") %>" rel="stylesheet" type="text/css" />
    <style>
        td {
            padding: 0;
        }

        .embedded-container {
            width: 100%;
            height: 480px;
            object-fit: contain;
        }

        iframe {
            width: 100%;
            height: 100%;
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

                        <div class="col s6">
                            <div class="embedded-container">
                                <iframe class="embedded-video" src="https://www.youtube.com/embed/<%#: Eval("VideoYouTubeId") %>?rel=0&amp;controls=1&amp;showinfo=0" frameborder="0"></iframe>
                            </div>
                        </div>

                        <div class="col s6">

                            <section>
                                <header>
                                    <h5>Description:</h5>
                                </header>
                                <p>
                                    <%#: Item.Description %>
                                </p>
                            </section>

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
