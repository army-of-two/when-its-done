<%@ Control
    Language="C#"
    AutoEventWireup="true"
    CodeBehind="UpdateContactInformationUserControl.ascx.cs"
    Inherits="WhenItsDone.WebFormsClient.ViewControls.ManageUserControls.UpdateContactInformationUserControl" %>

<h3>Update Contact Information</h3>

<div class="row">
    <div class="input-field col s12">
        <input runat="server" id="CountryTextBox" type="text" class="validate">
        <label for="CountryTextBox"><%#: Model.Country %></label>
    </div>
</div>

<div class="row">
    <div class="input-field col s12">
        <input runat="server" id="CityTextBox" type="text" class="validate">
        <label for="CityTextBox"><%#: Model.City %></label>
    </div>
</div>

<div class="row">
    <div class="input-field col s12">
        <input runat="server" id="StreetTextBox" type="text" class="validate">
        <label for="StreetTextBox"><%#: Model.Street %></label>
    </div>
</div>

<div class="row">
    <asp:LinkButton CssClass="waves-effect waves-light btn" ID="UpdateProfilePictureButton" runat="server" OnClick="OnUpdateContactInformation">
        <i class="material-icons right">cloud</i>
        <asp:Label runat="server">Update Contact Information</asp:Label>
    </asp:LinkButton>
</div>
