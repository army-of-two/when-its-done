<%@ Control
    Language="C#"
    AutoEventWireup="true"
    CodeBehind="DishRatingUserControl.ascx.cs"
    Inherits="WhenItsDone.WebFormsClient.ViewControls.DetailsUserControls.DishRatingUserControl" %>

<div class="row">

    <section class="row">
        <header>
            <h5>
                <asp:Label runat="server">Rating: <%#: DishRating %></asp:Label>
            </h5>
        </header>
    </section>

    <section class="row">
        <asp:LinkButton ID="LikeLinkButton" runat="server" CssClass="waves-effect waves-light btn">
            <i class="material-icons right">thumb_up</i>
            <span>Like</span>
        </asp:LinkButton>

        <asp:LinkButton ID="DislikeLinkButton" runat="server" CssClass="waves-effect waves-light btn">
            <i class="material-icons left">thumb_down</i>
            <span>Dislike</span>
        </asp:LinkButton>
    </section>
</div>
