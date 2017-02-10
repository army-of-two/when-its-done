<%@ Page
    Title="Manage Account"
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="Manage.aspx.cs"
    Inherits="WhenItsDone.WebFormsClient.Account.Manage" %>

<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">

    <asp:UpdatePanel ID="ManageUserUpdatePanel" runat="server">
        <ContentTemplate>
            <div class="manage-sections-menu">
                <div class="btn-group" role="group" aria-label="manage-sections-menu">
                    <asp:Button ID="ProfilePictureButton" runat="server" OnClick="ProfilePictureButton_Click" CssClass="btn btn-default">Profile Picture</button>
                    <button type="button" class="btn btn-default">Personal Information</button>
                    <button type="button" class="btn btn-default">Medical Information</button>
                    <button type="button" class="btn btn-default">Contact Information</button>
                </div>
            </div>
            <asp:Panel ID="ActiveContent" runat="server">
                <uc:OpenAuthProviders runat="server" ID="Test" />
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
