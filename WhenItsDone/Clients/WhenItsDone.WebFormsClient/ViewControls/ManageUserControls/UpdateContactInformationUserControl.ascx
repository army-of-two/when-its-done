<%@ Control
    Language="C#"
    AutoEventWireup="true"
    CodeBehind="UpdateContactInformationUserControl.ascx.cs"
    Inherits="WhenItsDone.WebFormsClient.ViewControls.ManageUserControls.UpdateContactInformationUserControl" %>

<h1>Update Contact Information</h1>

<asp:TextBox ID="CountryTextBox" Text="<%#: Model.Country %>" runat="server"></asp:TextBox>
<asp:TextBox ID="CityTextBox" Text="<%#: Model.City %>" runat="server"></asp:TextBox>
<asp:TextBox ID="StreetTextBox" Text="<%#: Model.Street %>" runat="server"></asp:TextBox>
<asp:Button runat="server" Text="Update Contact Information" OnClick="OnUpdateContactInformation" />