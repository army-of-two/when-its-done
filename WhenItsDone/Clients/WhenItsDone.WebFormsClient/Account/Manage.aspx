<%@ Page
    Title="Manage Account"
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="Manage.aspx.cs"
    Inherits="WhenItsDone.WebFormsClient.Account.Manage" %>

<%@ Register Src="~/ViewControls/ManageUserControls/UploadProfilePictureUserControl.aspx" TagPrefix="manage" TagName="profilepicture" %>
<%@ Register Src="~/ViewControls/ManageUserControls/UpdatePersonalInformationUserControl.ascx" TagPrefix="manage" TagName="personalinformation" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">

    <asp:UpdatePanel ID="ManageUserUpdatePanel" runat="server">
        <ContentTemplate>
            <div class="manage-sections-menu">
                <div class="btn-group" role="group" aria-label="manage-sections-menu">
                    <asp:Button ID="ProfilePictureButton" runat="server" OnClick="ProfilePictureButtonClick" CssClass="btn btn-default" Text="Profile Picture" />
                    <asp:Button ID="PersonalInformationButton" runat="server" OnClick="PersonalInformationButtonClick" CssClass="btn btn-default" Text="Personal Information" />
                    <asp:Button ID="MedicalInformationButton" runat="server" OnClick="MedicalInformationButtonClick" CssClass="btn btn-default" Text="Medical Information" />
                    <asp:Button ID="ContactInformationButton" runat="server" OnClick="ContactInformationButtonClick" CssClass="btn btn-default" Text="Contact Information" />
                </div>
            </div>
            <asp:Panel ID="ActiveContent" runat="server">
                <manage:profilepicture ID="ManageProfilePictureUserControl" runat="server" />
                <manage:personalinformation ID="UpdatePersonalInformationUserControl" runat="server" />
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
