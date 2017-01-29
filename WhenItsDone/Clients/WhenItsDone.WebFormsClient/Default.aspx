<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WhenItsDone.WebFormsClient._Default" %>

<%@ Register Src="~/ViewControls/Home/HomeViewUserControl.ascx" TagPrefix="uc" TagName="test" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="well content-container-even">
        <section class="content-container-heading">
            <h1>Food.Me</h1>
        </section>
        <section class="content-container-content">
        </section>
    </div>
    <hr />
    <div class="well content-container-even">
        <section class="content-container-heading">
            <uc:test runat="server" />
        </section>
        <section class="content-container-content">
        </section>
    </div>

</asp:Content>
