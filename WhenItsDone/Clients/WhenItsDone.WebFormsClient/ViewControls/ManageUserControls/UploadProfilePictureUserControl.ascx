<%@ Control
    Language="C#"
    AutoEventWireup="true"
    CodeBehind="UploadProfilePictureUserControl.ascx.cs"
    Inherits="WhenItsDone.WebFormsClient.ViewControls.ManageUserControls.UploadProfilePictureUserControl" %>

<h1>Upload Profile Picture</h1>

<asp:UpdatePanel runat="server">
    <ContentTemplate>
        <img src="data:image/<%#: Model.CurrentProfilePictureMimeType %>;base64,<%#: Model.CurrentProfilePictureBase64 %>" alt="The profile picture of <%#: Model.LoggedUserUsername %>" />

        <asp:TextBox ID="ProfilePictureUrlTextBox" runat="server"></asp:TextBox>
        <asp:FileUpload ID="ProfilePictureFileUpload" runat="server" ToolTip="Upload Profile Picture" />
        <asp:Button runat="server" OnClick="OnUploadProfilePictureButtonClick" Text="Update Profile Picture" />

        <asp:Label ID="ResultLable" runat="server" CssClass="" Visible="false"></asp:Label>
    </ContentTemplate>
</asp:UpdatePanel>
