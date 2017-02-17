<%@ Page MasterPageFile="~/Site.Master" Title="Create" Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WhenItsDone.WebFormsClient.Create.Default" %>

<asp:Content ContentPlaceHolderID="Stylesheets" runat="server">
    <link href="http://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet">
    <link href="https://cdnjs.cloudflare.com/ajax/libs/materialize/0.98.0/css/materialize.min.css" rel="stylesheet">
    <link href="<%= ResolveUrl("~/Content/Css/FixedNavBarWidth.css") %>" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <div id="manage-root" class="content-container-even">
        <section class="content-container-heading">
            <h3>Create Dish</h3>
        </section>

        <div class="well">
            <div class="row">

                <div class="col s8">
                    <div class="row">
                        <div class="input-field col s6">
                            <input runat="server" id="DishName" type="text" class="validate">
                            <label for="DishName">Name</label>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="DishName" ErrorMessage="Name is required." Display="None"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator runat="server" ControlToValidate="DishName" ValidationExpression=".{2,50}" ErrorMessage="Name must be between 2 and 50 characters long." Display="None"></asp:RegularExpressionValidator>
                            <asp:RegularExpressionValidator runat="server" ControlToValidate="DishName" ValidationExpression="[a-zA-Z\-]+" ErrorMessage="Name must contain letters and dashes only." Display="None"></asp:RegularExpressionValidator>
                        </div>

                        <div class="input-field col s6">
                            <input runat="server" id="DishPrice" type="number" class="validate">
                            <label for="DishPrice">Price</label>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="DishPrice" ErrorMessage="Price is required." Display="None"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator runat="server" ControlToValidate="DishPrice" ValidationExpression="[0-9\.]{1,9}" ErrorMessage="Price must be a number." Display="None"></asp:RegularExpressionValidator>
                        </div>
                    </div>

                    <div class="row">
                        <div class="input-field col s6">
                            <input runat="server" id="Calories" type="number" class="validate" min="0">
                            <label for="Calories">Calories</label>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Calories" ErrorMessage="Calories is required." Display="None"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator runat="server" ControlToValidate="Calories" ValidationExpression=".{1,5}" ErrorMessage="Calories must be a value with max 5 digits." Display="None"></asp:RegularExpressionValidator>
                        </div>

                        <div class="input-field col s6">
                            <input runat="server" id="Carbohydrates" type="number" class="validate" min="0">
                            <label for="Carbohydrates">Carbohydrates</label>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Carbohydrates" ErrorMessage="Carbohydrates is required." Display="None"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator runat="server" ControlToValidate="Carbohydrates" ValidationExpression=".{1,5}" ErrorMessage="Carbohydrates must be a value with max 5 digits." Display="None"></asp:RegularExpressionValidator>
                        </div>
                    </div>

                    <div class="row">
                        <div class="input-field col s6">
                            <input runat="server" id="Fats" type="number" class="validate" min="0">
                            <label for="Fats">Fats</label>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Fats" ErrorMessage="Fats is required." Display="None"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator runat="server" ControlToValidate="Fats" ValidationExpression=".{1,5}" ErrorMessage="Fats must be a value with max 5 digits." Display="None"></asp:RegularExpressionValidator>
                        </div>

                        <div class="input-field col s6">
                            <input runat="server" id="Protein" type="number" class="validate" min="0">
                            <label for="Protein">Protein</label>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Protein" ErrorMessage="Protein is required." Display="None"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator runat="server" ControlToValidate="Protein" ValidationExpression=".{1,5}" ErrorMessage="Protein must be a value with max 5 digits." Display="None"></asp:RegularExpressionValidator>
                        </div>
                    </div>

                    <div class="row">
                        <div class="input-field col s6">
                            <input runat="server" id="Video" type="text" class="validate">
                            <label for="Video">Video</label>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Video" ErrorMessage="Video is required." Display="None"></asp:RequiredFieldValidator>
                        </div>

                        <div class="input-field col s6">
                            <input runat="server" id="Photo" type="text" class="validate">
                            <label for="Photo">Photo</label>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Photo" ErrorMessage="Photo is required." Display="None"></asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <div class="row">
                        <div class="input-field col s12">
                            <textarea runat="server" id="Description" class="materialize-textarea"></textarea>
                            <label for="Description">Description</label>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Description" ErrorMessage="Description is required." Display="None"></asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <div class="row">
                        <asp:LinkButton CssClass="waves-effect waves-light btn" runat="server" OnClick="OnCreateFormSubmit">
                            <i class="material-icons right">cloud</i>Submit
                        </asp:LinkButton>
                    </div>

                </div>

                <div class="col s4">
                    <div class="row">
                        <asp:ValidationSummary runat="server" ForeColor="Red" DisplayMode="BulletList" />
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>

<asp:Content ContentPlaceHolderID="JavaScript" runat="server">
    <script type="text/javascript" src="https://code.jquery.com/jquery-2.1.1.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/materialize/0.98.0/js/materialize.min.js"></script>
</asp:Content>
