<%@ Control
    Language="C#"
    AutoEventWireup="true"
    CodeBehind="UploadProfilePictureUserControl.ascx.cs"
    Inherits="WhenItsDone.WebFormsClient.ViewControls.ManageUserControls.UploadProfilePictureUserControl" %>

<h1>Upload Profile Picture</h1>

<img src="data:image/<%#: Eval("ProfilePictures.MimeType") %>;base64,<%#: Eval("ProfilePictures.PictureBase64") %>" alt="picture of <%#: Eval("Username") %>" />

<asp:TextBox ID="ProfilePictureUrlTextBox" runat="server"></asp:TextBox>
<asp:FileUpload ID="ProfilePictureFileUpload" runat="server" ToolTip="Upload Profile Picture" />
<asp:Button runat="server" OnClick="OnUploadProfilePictureButtonClick" Text="Update Profile Picture" />

<asp:Label ID="ResultLable" runat="server" CssClass="" Visible="false"></asp:Label>