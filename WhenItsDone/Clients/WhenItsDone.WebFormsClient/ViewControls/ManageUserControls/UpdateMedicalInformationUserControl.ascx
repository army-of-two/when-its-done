<%@ Control
    Language="C#"
    AutoEventWireup="true"
    CodeBehind="UpdateMedicalInformationUserControl.ascx.cs"
    Inherits="WhenItsDone.WebFormsClient.ViewControls.ManageUserControls.UpdateMedicalInformationUserControl" %>

<h1>Update Medical Information</h1>

<asp:TextBox ID="HeightInCmTextBox" runat="server"></asp:TextBox>
<asp:TextBox ID="WeightInKgTextBox" runat="server"></asp:TextBox>
<asp:Button runat="server" Text="Update Medical Information" OnClick="OnUpdateMedicalInformation" />