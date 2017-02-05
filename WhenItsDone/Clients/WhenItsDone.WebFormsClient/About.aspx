<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="WhenItsDone.WebFormsClient.About" %>

<%@ Register Src="~/ViewControls/AdminPageControls/APWorkersControl.ascx" TagPrefix="uc" TagName="APWorkersControl" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Your application description page.</h3>
    <p>Use this area to provide additional information.</p>

<uc:APWorkersControl runat="server" ID="APWorkersControl" />

</asp:Content>
