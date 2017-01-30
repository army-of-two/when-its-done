<%@ Control
    Language="C#"
    AutoEventWireup="true"
    CodeBehind="TopDishesUserControl.ascx.cs"
    Inherits="WhenItsDone.WebFormsClient.ViewControls.ContentContainers.TopDishesUserControl" %>

<div class="well content-container-even">
    <section class="content-container-heading">
        <h1>Food.Me Top 3</h1>
    </section>
    <section class="content-container-content">
        <div class="row">
            <asp:Repeater ID="TopDishesRepeater" runat="server" ItemType="WhenItsDone.DTOs.DishViews.NamePhotoDishView">
                <ItemTemplate>
                    <div class="col-md-4">
                        <div class="panel panel-primary">
                            <div class="panel-heading">
                                <h3 class="panel-title"><%#: Item.Name %></h3>
                            </div>
                            <div class="panel-body">
                                <img src="<%#: Item.PhotoItemUrl %>" alt="picture of <%#: Item.Name %>" />
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </section>
</div>
