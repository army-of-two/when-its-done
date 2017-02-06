﻿<%@ Control
    Language="C#"
    AutoEventWireup="true"
    CodeBehind="TopVideoItemsUserControl.ascx.cs"
    Inherits="WhenItsDone.WebFormsClient.ViewControls.ContentContainers.TopVideoItemsUserControl" %>

<asp:EntityDataSource
    ID="UsersDataSource" runat="server"
    DefaultContainerName="Entities"
    ConnectionString="name=Entities"
    EntitySetName="VideoItems"
    Select="TOP(3) it.Id, it.Url, it.Rating"
    OrderBy="it.Rating DESC"
    EnableFlattening="false">
</asp:EntityDataSource>

<section class="content-container-heading">
    <h1>Food.Me Top 3 Videos</h1>
</section>
<section class="content-container-content">
    <div class="row">
        <asp:Repeater
            ID="TopDishesRepeater" runat="server"
            DataSourceID="UsersDataSource">
            <ItemTemplate>
                <a class="panel-anchor" href="/Details?itemid=<%#: Eval("Id") %>" title="Click for more details: <%#: Eval("Url") %>">
                    <div class="col-md-4">
                        <div class="panel panel-primary">
                            <div class="panel-heading">
                                <div class="row">
                                    <div class="col-md-12 text-left">
                                        <h3 class="panel-title"><%#: Eval("Url") %></h3>
                                    </div>
                                </div>
                            </div>
                            <div class="panel-body">
                                <iframe width="320" height="180" src="https://www.youtube.com/embed/<%#: Eval("Url") %>?rel=0&amp;controls=0&amp;showinfo=0" frameborder="0" allowfullscreen></iframe>
                            </div>
                        </div>
                    </div>
                </a>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</section>
