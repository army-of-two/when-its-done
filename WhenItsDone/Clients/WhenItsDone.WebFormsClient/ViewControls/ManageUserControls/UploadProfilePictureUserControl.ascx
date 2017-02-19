<%@ Control
    Language="C#"
    AutoEventWireup="true"
    CodeBehind="UploadProfilePictureUserControl.ascx.cs"
    Inherits="WhenItsDone.WebFormsClient.ViewControls.ManageUserControls.UploadProfilePictureUserControl" %>

<h1>Upload Profile Picture</h1>

<asp:UpdatePanel runat="server">
    <ContentTemplate>
        <div class="row">
            <div class="col s6">
                <img src="data:image/<%#: Model.CurrentProfilePictureMimeType %>;base64,<%#: Model.CurrentProfilePictureBase64 %>" alt="The profile picture of <%#: Model.LoggedUserUsername %>" />
            </div>

            <div class="col s6">
                <div class="row">
                    <div class="input-field col s12">
                        <input runat="server" id="ProfilePictureUrlTextBox" type="url" class="validate">
                        <label for="ProfilePictureUrlTextBox">Url</label>
                    </div>
                </div>

                <div class="row">
                    <div class="file-field input-field col s12">
                        <div class="btn">
                            <span>File</span>
                            <asp:FileUpload ID="ProfilePictureFileUpload" runat="server" />
                        </div>
                        <div class="file-path-wrapper">
                            <input class="file-path validate" type="text">
                        </div>
                    </div>
                </div>

                <div class="row">
                    <asp:LinkButton CssClass="waves-effect waves-light btn" ID="UpdateProfilePictureButton" runat="server" OnClick="OnUploadProfilePictureButtonClick">
                        <i class="material-icons right">cloud</i>
                        <asp:Label runat="server">Update Profile Picture</asp:Label>
                    </asp:LinkButton>
                </div>

                <asp:Label ID="ResultLable" runat="server" CssClass=""></asp:Label>
            </div>
        </div>

    </ContentTemplate>
    <Triggers>
        <asp:PostBackTrigger ControlID="UpdateProfilePictureButton" />
    </Triggers>
</asp:UpdatePanel>
