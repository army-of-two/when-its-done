<%@ Control
    Language="C#"
    AutoEventWireup="true"
    CodeBehind="TopDishesUserControl.ascx.cs"
    Inherits="WhenItsDone.WebFormsClient.ViewControls.ContentContainers.TopDishesUserControl" %>

<section class="content-container-heading">
    <h1>Food.Me Top 3</h1>
</section>
<section class="content-container-content">
    <div class="row">
        <asp:Repeater ID="TopDishesRepeater" runat="server" ItemType="WhenItsDone.DTOs.DishViewsDTOs.NamePhotoDishViewDTO">
            <ItemTemplate>
                <a class="panel-anchor" href="/Details?itemid=<%#: Item.Id %>" title="Click for more details: <%#: Item.Name %>">
                    <div class="col-md-4">
                        <div class="panel panel-primary">
                            <div class="panel-heading">
                                <div class="row">
                                    <div class="col-md-6 text-left">
                                        <h3 class="panel-title"><%#: Item.Name %></h3>
                                    </div>
                                    <div class="col-md-6 text-right">
                                        <h3 class="panel-title">Rating</h3>
                                    </div>
                                </div>
                            </div>
                            <div class="panel-body">
                                <img src="<%#: Item.PhotoItemUrl %>" alt="picture of <%#: Item.Name %>" />
                            </div>
                        </div>
                    </div>
                </a>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</section>
