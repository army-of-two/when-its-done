<%@ Control Language="C#"
    AutoEventWireup="true"
    CodeBehind="APWorkerDishesControl.ascx.cs"
    Inherits="WhenItsDone.WebFormsClient.ViewControls.AdminPageControls.APWorkerDishesControl" %>

<div>
    <asp:DetailsView runat="server" ID ="WorkerDetails" AutoGenerateRows="false" HeaderText="Details"
         ItemType="WhenItsDone.DTOs.DishViewsDTOs.NamePhotoDishViewDTO">
        <Fields>
            <asp:BoundField DataField="Gender"/>
        </Fields>
    </asp:DetailsView>
</div>
