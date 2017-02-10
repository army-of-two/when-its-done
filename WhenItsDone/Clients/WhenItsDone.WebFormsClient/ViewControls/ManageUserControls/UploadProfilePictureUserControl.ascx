<%@ Control
    Language="C#"
    AutoEventWireup="true"
    CodeBehind="UploadProfilePictureUserControl.ascx.cs"
    Inherits="WhenItsDone.WebFormsClient.ViewControls.ManageUserControls.UploadProfilePictureUserControl" %>

<h1>Upload Profile Picture</h1>

<asp:FileUpload ID="ProfilePictureFileUpload" runat="server" ToolTip="Upload Profile Picture" />
<asp:Button runat="server"  OnClick="OnUploadProfilePictureButtonClick" Text="Update Profile Picture" />
