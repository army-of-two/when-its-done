<%@ Page
    Title="Browse"
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="Browse.aspx.cs"
    Inherits="WhenItsDone.WebFormsClient.Browse" %>

<asp:Content ContentPlaceHolderID="Stylesheets" runat="server">
    <link href="http://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet">
    <link href="https://cdnjs.cloudflare.com/ajax/libs/materialize/0.98.0/css/materialize.min.css" rel="stylesheet">
    <link href="<%= ResolveUrl("~/Content/Css/FixedNavBarWidth.css") %>" rel="stylesheet" type="text/css" />
    <style>
        td {
            padding: 0;
        }

        img {
            width: 100%;
            height: 360px;
            object-fit: contain;
        }
    </style>
</asp:Content>

<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>

            <asp:ListView
                ID="BrowseDishesListView" runat="server"
                ItemType="WhenItsDone.DTOs.DishViewsDTOs.DishBrowseViewDTO"
                SelectMethod="BrowseDishesListViewGetData"
                OnSelectedIndexChanged="BrowseDishesListViewSelectedIndexChanged"
                DataKeyNames="Id">

                <LayoutTemplate>
                    <div class="row">
                        <asp:PlaceHolder runat="server" ID="itemPlaceHolder"></asp:PlaceHolder>
                    </div>

                    <asp:DataPager runat="server" PageSize="5" QueryStringField="Id">
                        <Fields>
                            <asp:NextPreviousPagerField />
                        </Fields>
                    </asp:DataPager>
                </LayoutTemplate>

                <ItemTemplate>
                    <div class="row">
                        <div class="col s4">
                            <img src="<%#: Item.PhotoUrl %>" alt="<%#: Item.Name %>" />
                        </div>
                    </div>
                </ItemTemplate>

                <ItemSeparatorTemplate>
                    <hr />
                </ItemSeparatorTemplate>
            </asp:ListView>

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

<asp:Content ContentPlaceHolderID="JavaScript" runat="server">
    <script type="text/javascript" src="https://code.jquery.com/jquery-2.1.1.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/materialize/0.98.0/js/materialize.min.js"></script>
</asp:Content>
