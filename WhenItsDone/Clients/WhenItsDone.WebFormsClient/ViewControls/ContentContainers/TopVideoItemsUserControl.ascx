<%@ Control
    Language="C#"
    AutoEventWireup="true"
    CodeBehind="TopVideoItemsUserControl.ascx.cs"
    Inherits="WhenItsDone.WebFormsClient.ViewControls.ContentContainers.TopVideoItemsUserControl" %>

<asp:SqlDataSource
    ID="VideoItemsSqlDataSource" runat="server"
    ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"
    SelectCommand="SELECT TOP(3) v.Id, v.YouTubeId, v.Rating, v.Title FROM dbo.VideoItems v ORDER BY v.Rating DESC">
</asp:SqlDataSource>

<section class="content-container-heading">
    <h2>Food.Me Top 3 Videos</h2>
</section>
<section class="content-container-content">
    <div class="row">
        <asp:Repeater
            ID="TopDishesRepeater" runat="server"
            DataSourceID="VideoItemsSqlDataSource">
            <ItemTemplate>
                <a class="panel-anchor" href="/Details?itemid=<%#: Eval("Id") %>" title="Click for more details: <%#: Eval("Title") %>">
                    <div class="col-md-4">
                        <div class="panel panel-primary">
                            <div class="panel-heading">
                                <div class="row">
                                    <div class="col-md-10 text-left">
                                        <h1 class="panel-title"><%#: Eval("Title") %></h1>
                                    </div>
                                    <div class="col-md-2 text-right">
                                        <h2 class="panel-title"><%#: Eval("Rating") %></h2>
                                    </div>
                                </div>
                            </div>
                            <div class="panel-body">
                                <div class="embedded-video-container">
                                    <iframe class="embedded-video" src="https://www.youtube.com/embed/<%#: Eval("YouTubeId") %>?rel=0&amp;controls=0&amp;showinfo=0" frameborder="0" allowfullscreen></iframe>
                                </div>
                            </div>
                        </div>
                    </div>
                </a>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</section>
