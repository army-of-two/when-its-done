<%@ Page
    Title="Details"
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="Details.aspx.cs"
    Inherits="WhenItsDone.WebFormsClient.Details" %>

<asp:Content ContentPlaceHolderID="Stylesheets" runat="server">
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

        <asp:HiddenField runat="server" ID="DishIdHiddenField" Value="<%#: Model.DishDetails.Id %>" />

        <section class="content-container-heading">
            <h3><%#: Model.DishDetails.Name %></h3>
        </section>

        <div class="well">
            <div class="row">

                <div class="col s6">
                    <div class="embedded-container">
                        <iframe class="embedded-video" src="https://www.youtube.com/embed/<%#: Model.DishDetails.VideoYouTubeId %>?rel=0&amp;controls=1&amp;showinfo=0" frameborder="0"></iframe>
                    </div>
                </div>

                <div class="col s6">

                    <div class="row">

                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <section class="row">
                                    <header>
                                        <h5>
                                            <asp:Label ID="RatingHeaderLabel" runat="server">Rating: <%#: Model.DishRating %></asp:Label>
                                        </h5>
                                    </header>
                                </section>

                                <section class="row">
                                    <asp:LinkButton ID="LikeLinkButton" runat="server" ToolTip="Like" CssClass="waves-effect waves-light btn" OnClick="OnLikeLinkButtonClick">
                                        <i class="material-icons right">thumb_up</i>
                                        <span>Like</span>
                                    </asp:LinkButton>

                                    <asp:LinkButton ID="DislikeLinkButton" runat="server" ToolTip="Dislike" CssClass="waves-effect waves-light btn" OnClick="OnDislikeLinkButtonClick">
                                        <i class="material-icons left">thumb_down</i>
                                        <span>Dislike</span>
                                    </asp:LinkButton>
                                </section>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="LikeLinkButton" EventName="Click" />
                                <asp:AsyncPostBackTrigger ControlID="DislikeLinkButton" EventName="Click" />
                            </Triggers>
                        </asp:UpdatePanel>

                        <hr />

                        <section>
                            <header>
                                <h5>Nutrition:</h5>
                            </header>

                            <div class="row">
                                <div class="col s6">
                                    <p>Calories: <span><%#: Model.DishDetails.Calories %></span> </p>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col s6">
                                    <p>Carbohydrates: <span><%#: Model.DishDetails.Carbohydrates %></span> </p>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col s6">
                                    <p>Protein: <span><%#: Model.DishDetails.Protein %></span> </p>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col s6">
                                    <p>Fats: <span><%#: Model.DishDetails.Fats %></span> </p>
                                </div>
                            </div>
                        </section>

                        <hr />

                        <div class="row">
                            <section>
                                <header>
                                    <h5>Description:</h5>
                                </header>
                                <p>
                                    <%#: Model.DishDetails.Description %>
                                </p>
                            </section>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

<asp:Content ContentPlaceHolderID="JavaScript" runat="server">
</asp:Content>
