<%@ Control
    Language="C#"
    AutoEventWireup="true"
    CodeBehind="UpdateMedicalInformationUserControl.ascx.cs"
    Inherits="WhenItsDone.WebFormsClient.ViewControls.ManageUserControls.UpdateMedicalInformationUserControl" %>

<h1>Update Medical Information</h1>

<asp:TextBox ID="HeightInCmTextBox" Text="<%#: Model.HeightInCm %>" runat="server"></asp:TextBox>
<asp:TextBox ID="WeightInKgTextBox" Text="<%#: Model.WeightInKg %>" runat="server"></asp:TextBox>
<asp:Button runat="server" Text="Update Medical Information" OnClick="OnUpdateMedicalInformation" />