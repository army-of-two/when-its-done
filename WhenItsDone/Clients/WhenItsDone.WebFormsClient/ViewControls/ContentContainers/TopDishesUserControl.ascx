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
        <asp:Repeater ID="TopDishesRepeater" runat="server" ItemType="WhenItsDone.DTOs.DishViewsDTOs.NamePhotoRatingDishViewDTO">
            <ItemTemplate>
                <a class="panel-anchor" href="/Details?itemid=<%#: Item.Id %>" title="Click for more details: <%#: Item.Name %>">
                    <div class="col-md-4">
                        <div class="panel panel-primary">
                            <div class="panel-heading">
                                <div class="row">
                                    <div class="col-md-10 text-left">
                                        <h1 class="panel-title"><%#: Item.Name %></h1>
                                    </div>
                                    <div class="col-md-2 text-right">
                                        <h2 class="panel-title"><%#: Item.Rating %></h2>
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
