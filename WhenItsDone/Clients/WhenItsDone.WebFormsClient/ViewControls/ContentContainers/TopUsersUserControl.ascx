<%@ Control
    Language="C#"
    AutoEventWireup="true"
    CodeBehind="TopUsersUserControl.ascx.cs"
    Inherits="WhenItsDone.WebFormsClient.ViewControls.ContentContainers.TopUsersUserControl" %>

<asp:EntityDataSource
    ID="UsersDataSource" runat="server"
    DefaultContainerName="Entities"
    ConnectionString="name=Entities"
    EntitySetName="Users"
    OrderBy="it.Rating DESC"
    Select="TOP(3) it.Id, it.ProfilePictures, it.Username, it.Rating"
    EnableFlattening="false">
</asp:EntityDataSource>

<section class="content-container-heading">
    <h1>Food.Me Top 3 Users</h1>
</section>
<section class="content-container-content">
    <div class="row">
        <asp:Repeater
            ID="TopDishesRepeater" runat="server"
            DataSourceID="UsersDataSource">
            <ItemTemplate>
                <a class="panel-anchor" href="/Details?itemid=<%#: Eval("Id") %>" title="Click for more details: <%#: Eval("Username") %>">
                    <div class="col-md-4">
                        <div class="panel panel-primary">
                            <div class="panel-heading">
                                <div class="row">
                                    <div class="col-md-6 text-left">
                                        <h3 class="panel-title"><%#: Eval("Username") %></h3>
                                    </div>
                                    <div class="col-md-6 text-right">
                                        <h3 class="panel-title"><%#: Eval("Rating") %></h3>
                                    </div>
                                </div>
                            </div>
                            <div class="panel-body">
                                <img src="data:image/<%#: Eval("ProfilePictures.MimeType") %>;base64,<%#: Eval("ProfilePictures.PictureBase64") %>" alt="picture of <%#: Eval("Username") %>" />
                            </div>
                        </div>
                    </div>
                </a>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</section>
