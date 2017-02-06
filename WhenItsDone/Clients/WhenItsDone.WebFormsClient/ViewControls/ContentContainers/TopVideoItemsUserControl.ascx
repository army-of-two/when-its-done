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
    Select="TOP(3) it.Id, it.YouTubeId, it.Rating, it.Title"
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
                <a class="panel-anchor" href="/Details?itemid=<%#: Eval("Id") %>" title="Click for more details: <%#: Eval("Title") %>">
                    <div class="col-md-4">
                        <div class="panel panel-primary">
                            <div class="panel-heading">
                                <div class="row">
                                    <div class="col-md-6 text-left">
                                        <h3 class="panel-title"><%#: Eval("Title") %></h3>
                                    </div>
                                    <div class="col-md-6 text-right">
                                        <h3 class="panel-title"><%#: Eval("Rating") %></h3>
                                    </div>
                                </div>
                            </div>
                            <div class="panel-body">
                                <div class="embedded-video-container">
                                    <iframe class="embedded-video" width="320" height="180" src="https://www.youtube.com/embed/<%#: Eval("YouTubeId") %>?rel=0&amp;controls=0&amp;showinfo=0" frameborder="0" allowfullscreen></iframe>
                                </div>
                            </div>
                        </div>
                    </div>
                </a>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</section>
