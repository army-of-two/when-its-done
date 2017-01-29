<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WhenItsDone.WebFormsClient._Default" %>

<%@ Register Src="~/ViewControls/Home/HomeViewUserControl.ascx" TagPrefix="uc" TagName="test" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="well content-container-even">
        <h1>Food.Me</h1>
    </div>
    <hr />
    <div class="well content-container-even">
        <div class="row">
            <uc:test runat="server" />
        </div>
    </div>

</asp:Content>
