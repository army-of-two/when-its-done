<%@ Control
    Language="C#"
    AutoEventWireup="true"
    CodeBehind="UpdateMedicalInformationUserControl.ascx.cs"
    Inherits="WhenItsDone.WebFormsClient.ViewControls.ManageUserControls.UpdateMedicalInformationUserControl" %>

<h1>Update Medical Information</h1>

<div class="row">
    <div class="input-field col s12">
        <input runat="server" id="HeightInCmTextBox" type="text" class="validate">
        <label for="HeightInCmTextBox">Height <%#: Model.HeightInCm %>Cm </label>
    </div>
</div>

<div class="row">
    <div class="input-field col s12">
        <input runat="server" id="WeightInKgTextBox" type="text" class="validate" >
        <label for="WeightInKgTextBox">Weight <%#: Model.WeightInKg %>Kg</label>
    </div>
</div>

<div class="row">
    <asp:LinkButton CssClass="waves-effect waves-light btn" ID="UpdateProfilePictureButton" runat="server" OnClick="OnUpdateMedicalInformation">
        <i class="material-icons right">cloud</i>
        <asp:Label runat="server">Update Medical Information</asp:Label>
    </asp:LinkButton>
</div>
