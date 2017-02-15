<%@ Page MasterPageFile="~/Site.Master" Title="Create" Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WhenItsDone.WebFormsClient.Create.Default" %>

<asp:Content ContentPlaceHolderID="Stylesheets" runat="server">
    <link href="http://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet">
    <link href="https://cdnjs.cloudflare.com/ajax/libs/materialize/0.98.0/css/materialize.min.css" rel="stylesheet">
    <link href="<%= ResolveUrl("~/Content/Css/FixedNavBarWidth.css") %>" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <h1>Create Dish</h1>

    <div class="container">
        <div class="well">
            <div class="row">
                <div class="input-field col s4">
                    <input id="DishName" type="text" class="validate">
                    <label for="DishName">Name</label>
                </div>

                <div class="input-field col s4">
                    <input id="DishPrice" type="text" class="validate">
                    <label for="DishPrice">Price</label>
                </div>
            </div>

            <div class="row">
                <div class="input-field col s4">
                    <input id="Calories" type="text" class="validate">
                    <label for="Calories">Calories</label>
                </div>

                <div class="input-field col s4">
                    <input id="Carbohydrates" type="text" class="validate">
                    <label for="Carbohydrates">Carbohydrates</label>
                </div>
            </div>

            <div class="row">
                <div class="input-field col s4">
                    <input id="Fats" type="text" class="validate">
                    <label for="Fats">Fats</label>
                </div>

                <div class="input-field col s4">
                    <input id="Protein" type="text" class="validate">
                    <label for="Protein">Protein</label>
                </div>
            </div>

            <div class="row">
                <asp:LinkButton CssClass="waves-effect waves-light btn" runat="server" OnClick="OnCreateFormSubmit">
                <i class="material-icons right">cloud</i>Submit
                </asp:LinkButton>
            </div>

        </div>
    </div>

</asp:Content>

<asp:Content ContentPlaceHolderID="JavaScript" runat="server">
    <script type="text/javascript" src="https://code.jquery.com/jquery-2.1.1.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/materialize/0.98.0/js/materialize.min.js"></script>
</asp:Content>
