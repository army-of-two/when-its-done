<%@ Control Language="C#" AutoEventWireup="true"
    CodeBehind="APWorkersControl.ascx.cs"
    Inherits="WhenItsDone.WebFormsClient.ViewControls.AdminPageControls.APWorkersControl" %>

<div>
    <asp:ListView runat="server" ID="workersList" DataKeyNames="Id"
        ItemType="WhenItsDone.DTOs.WorkerVIewsDTOs.WorkerWithDishesDTO">
        <ItemTemplate>
            <%#: Item.Id %>
            <%#: Item.FirstName %>
            <%#: Item.LastName %>
            <asp:Button ID="ButtonEdit" runat="server" CommandName="Edit" Text="Edit" />
            <asp:Button ID="ButtonDelete" runat="server" CommandName="Delete" Text="Delete" />
        </ItemTemplate>
    </asp:ListView>
</div>
