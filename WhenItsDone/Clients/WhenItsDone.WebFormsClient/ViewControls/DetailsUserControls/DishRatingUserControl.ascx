<%@ Control
    Language="C#"
    AutoEventWireup="true"
    CodeBehind="DishRatingUserControl.ascx.cs"
    Inherits="WhenItsDone.WebFormsClient.ViewControls.DetailsUserControls.DishRatingUserControl" %>

<div class="row">
    <asp:Label runat="server"> <%#: DishRating %></asp:Label>
    <asp:LinkButton runat="server" CssClass="waves-effect waves-light btn">
        <i class="material-icons right">thumb_up</i>
        <span>Like</span>
    </asp:LinkButton>
</div>
