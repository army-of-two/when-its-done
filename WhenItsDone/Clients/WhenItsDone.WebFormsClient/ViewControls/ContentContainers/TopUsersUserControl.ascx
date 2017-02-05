<%@ Control
    Language="C#"
    AutoEventWireup="true"
    CodeBehind="TopUsersUserControl.ascx.cs"
    Inherits="WhenItsDone.WebFormsClient.ViewControls.ContentContainers.TopUsersUserControl" %>

<asp:EntityDataSource
    ID="UsersDataSource" runat="server"
    DefaultContainerName="WhenItsDoneDbContext"
    ConnectionString="name=DefaultConnection"
    EntitySetName="Users"
    EnableFlattening="false">
</asp:EntityDataSource>

<section class="content-container-heading">
    <h1>Food.Me Top 3 Users</h1>
</section>
<section class="content-container-content">
    <div class="row">
        <asp:Repeater ID="TopDishesRepeater" runat="server" ItemType="WhenItsDone.Models.User">
            <ItemTemplate>
                <a class="panel-anchor" href="/Details?itemid=<%#: Item.Id %>" title="Click for more details: <%#: Item.Username %>">
                    <div class="col-md-4">
                        <div class="panel panel-primary">
                            <div class="panel-heading">
                                <h3 class="panel-title"><%#: Item.Username %></h3>
                            </div>
                            <div class="panel-body">
                                <%--<img src="<%#: Item.PhotoItemUrl %>" alt="picture of <%#: Item.Username %>" />--%>
                            </div>
                        </div>
                    </div>
                </a>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</section>
