<%@ Page
    Title="Manage Account"
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="Manage.aspx.cs"
    Inherits="WhenItsDone.WebFormsClient.Account.Manage" %>

<%@ Register Src="~/ViewControls/ManageUserControls/UploadProfilePictureUserControl.ascx" TagPrefix="manage" TagName="profilepicture" %>
<%@ Register Src="~/ViewControls/ManageUserControls/UpdatePersonalInformationUserControl.ascx" TagPrefix="manage" TagName="personalinformation" %>
<%@ Register Src="~/ViewControls/ManageUserControls/UpdateMedicalInformationUserControl.ascx" TagPrefix="manage" TagName="medicalinformation" %>
<%@ Register Src="~/ViewControls/ManageUserControls/UpdateContactInformationUserControl.ascx" TagPrefix="manage" TagName="contactinformation" %>

<asp:Content ContentPlaceHolderID="Stylesheets" runat="server">
    <link href="<%= ResolveUrl("~/Content/Css/Manage.css") %>" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <div id="manage-root" class="well content-container-even">
        <section class="content-container-heading">
            <h2>Food.Me Profile Settings</h2>
        </section>
        
        <asp:UpdateProgress runat="server">
            <ProgressTemplate>
                Loading data...
            </ProgressTemplate>
        </asp:UpdateProgress>

        <asp:UpdatePanel ID="ManageUserUpdatePanel" runat="server">
            <ContentTemplate>
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <div class="manage-sections-menu">
                            <div class="btn-group" role="group" aria-label="manage-sections-menu">
                                <asp:Button ID="ProfilePictureButton" runat="server" OnClick="ProfilePictureButtonClick" CssClass="btn btn-default" Text="Profile Picture" />
                                <asp:Button ID="PersonalInformationButton" runat="server" OnClick="PersonalInformationButtonClick" CssClass="btn btn-default" Text="Personal Information" />
                                <asp:Button ID="MedicalInformationButton" runat="server" OnClick="MedicalInformationButtonClick" CssClass="btn btn-default" Text="Medical Information" />
                                <asp:Button ID="ContactInformationButton" runat="server" OnClick="ContactInformationButtonClick" CssClass="btn btn-default" Text="Contact Information" />
                            </div>
                        </div>
                    </div>
                    <div class="panel-body">
                        <asp:Panel ID="ActiveContent" CssClass="active-content" runat="server">
                            <manage:profilepicture ID="ManageProfilePictureUserControl" runat="server" />
                            <manage:personalinformation ID="UpdatePersonalInformationUserControl" runat="server" />
                            <manage:medicalinformation ID="UpdateMedicalInformationUserControl" runat="server" />
                            <manage:contactinformation ID="UpdateContactInformationUserControl" runat="server" />
                        </asp:Panel>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
