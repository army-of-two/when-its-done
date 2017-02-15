<%@ Control Language="C#"
    AutoEventWireup="true"
    CodeBehind="APWorkerDetails.ascx.cs"
    Inherits="WhenItsDone.WebFormsClient.ViewControls.AdminPageControls.APWorkerDetails" %>

<div>
    <asp:UpdatePanel runat="server"
        UpdateMode="Conditional"
        ChildrenAsTriggers="false">
        <ContentTemplate>

            <asp:Button runat="server" Text="Back" CssClass="btn"/>


        </ContentTemplate>
    </asp:UpdatePanel>
</div>
