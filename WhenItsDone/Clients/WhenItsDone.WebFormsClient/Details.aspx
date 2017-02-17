<%@ Page
    Title="Details"
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="Details.aspx.cs"
    Inherits="WhenItsDone.WebFormsClient.Details" %>

<%@ Register Src="~/ViewControls/DetailsUserControls/DishRatingUserControl.ascx" TagPrefix="uc" TagName="DishRatingUserControl" %>

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

                            <div class="row">

                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <section class="row">
                                            <header>
                                                <h5>
                                                    <asp:Label runat="server">Rating: <%#: Model.DishDetails.Rating %></asp:Label>
                                                </h5>
                                            </header>
                                        </section>

                                        <section class="row">
                                            <asp:LinkButton ID="LikeLinkButton" runat="server" CssClass="waves-effect waves-light btn" OnClick="OnLikeLinkButtonClick">
                                                <i class="material-icons right">thumb_up</i>
                                                <span>Like</span>
                                            </asp:LinkButton>

                                            <asp:LinkButton ID="DislikeLinkButton" runat="server" CssClass="waves-effect waves-light btn" OnClick="OnDislikeLinkButtonClick">
                                                <i class="material-icons left">thumb_down</i>
                                                <span>Dislike</span>
                                            </asp:LinkButton>
                                        </section>
                                    </ContentTemplate>
                                </asp:UpdatePanel>

                                <section>
                                    <header>
                                        <h5>Nutrition:</h5>
                                    </header>

                                    <div class="row">
                                        <div class="col s6">
                                            <p>Calories: <span><%#: Item.Calories %></span> </p>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col s6">
                                            <p>Carbohydrates: <span><%#: Item.Carbohydrates %></span> </p>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col s6">
                                            <p>Protein: <span><%#: Item.Protein %></span> </p>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col s6">
                                            <p>Fats: <span><%#: Item.Fats %></span> </p>
                                        </div>
                                    </div>
                                </section>

                                <div class="row">
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
                    </div>
            </ItemTemplate>
        </asp:FormView>

    </div>

</asp:Content>

<asp:Content ContentPlaceHolderID="JavaScript" runat="server">
    <script type="text/javascript" src="https://code.jquery.com/jquery-2.1.1.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/materialize/0.98.0/js/materialize.min.js"></script>
</asp:Content>
