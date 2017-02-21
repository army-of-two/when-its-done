<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminPage.aspx.cs" Inherits="WhenItsDone.WebFormsClient.AdminPage" %>

<%@ Register Src="~/ViewControls/AdminPageControls/APWorkersControl.ascx" TagPrefix="uc" TagName="APWorkersControl" %>
<%@ Register Src="~/ViewControls/AdminPageControls/APWorkerDetailsControl.ascx" TagPrefix="uc" TagName="APWorkerDetailsControl" %>


<asp:Content ContentPlaceHolderID="Stylesheets" runat="server">
    <link href="<%= ResolveUrl("~/Content/Css/AdminPage.css") %>" rel="stylesheet" type="text/css" />
    <link href="http://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/materialize/0.98.0/css/materialize.min.css">
</asp:Content>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel runat="server" UpdateMode="Conditional"
        ChildrenAsTriggers="true" ID="AdminPageUpdater">
        <ContentTemplate>
            <asp:Label runat="server" ID="hiddenIdField" Visible="false"></asp:Label>

            <div class="container">
                <uc:APWorkersControl runat="server" ID="APWorkersControl" />
                <div class=" margin-top-40">
                    <div runat="server" id="buttons" visible="false">
                        <asp:Button runat="server" class="waves-effect waves-light btn" Text="Back" ID="BackToAll" OnClick="BackToAllWorkersClicked" />
                        <asp:Button runat="server" class="waves-effect waves-light btn" Text="Contact informations" ID="ContactsBtn" OnClick="ContactsButtonWasClicked" />
                        <asp:Button runat="server" class="waves-effect waves-light btn" Text="Medical information" ID="MedicalBtn" OnClick="MedicalBtnWasClicked"/>
                        <asp:Button runat="server" class="waves-effect waves-light btn" Text="Dishes" ID="DishesBtn" OnClick="DishesBtnWasClicked" />
                    </div>

                    <uc:APWorkerDetailsControl runat="server" ID="APWorkerDetailsControl" Visible="false" />
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>



<asp:Content ContentPlaceHolderID="JavaScript" runat="server">
    <script type="text/javascript" src="https://code.jquery.com/jquery-2.1.1.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/materialize/0.98.0/js/materialize.min.js"></script>
</asp:Content>
