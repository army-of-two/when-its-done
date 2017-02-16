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
                        </div>

                        <div class="input-field col s6">
                            <input runat="server" id="DishPrice" type="text" class="validate">
                            <label for="DishPrice">Price</label>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="DishPrice" ErrorMessage="Price is required." Display="None"></asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <div class="row">
                        <div class="input-field col s6">
                            <input runat="server" id="Calories" type="text" class="validate">
                            <label for="Calories">Calories</label>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Calories" ErrorMessage="Calories is required." Display="None"></asp:RequiredFieldValidator>
                        </div>

                        <div class="input-field col s6">
                            <input runat="server" id="Carbohydrates" type="text" class="validate">
                            <label for="Carbohydrates">Carbohydrates</label>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Carbohydrates" ErrorMessage="Carbohydrates is required." Display="None"></asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <div class="row">
                        <div class="input-field col s6">
                            <input runat="server" id="Fats" type="text" class="validate">
                            <label for="Fats">Fats</label>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Fats" ErrorMessage="Fats is required." Display="None"></asp:RequiredFieldValidator>
                        </div>

                        <div class="input-field col s6">
                            <input runat="server" id="Protein" type="text" class="validate">
                            <label for="Protein">Protein</label>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Protein" ErrorMessage="Protein is required." Display="None"></asp:RequiredFieldValidator>
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
                        <asp:LinkButton CssClass="waves-effect waves-light btn" runat="server" OnClick="OnCreateFormSubmit">
                            <i class="material-icons right">cloud</i>Submit
                        </asp:LinkButton>
                    </div>

                    <div class="row">
                        <asp:ValidationSummary runat="server" ForeColor="Red" DisplayMode="BulletList" />
                    </div>
                </div>

                <div class="col s4">
                    <span>image tag here</span>
                </div>
            </div>
        </div>
    </div>

</asp:Content>

<asp:Content ContentPlaceHolderID="JavaScript" runat="server">
    <script type="text/javascript" src="https://code.jquery.com/jquery-2.1.1.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/materialize/0.98.0/js/materialize.min.js"></script>
</asp:Content>
