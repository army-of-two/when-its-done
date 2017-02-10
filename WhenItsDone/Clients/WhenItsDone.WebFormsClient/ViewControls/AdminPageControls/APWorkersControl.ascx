<%@ Control Language="C#" AutoEventWireup="true"
    CodeBehind="APWorkersControl.ascx.cs"
    Inherits="WhenItsDone.WebFormsClient.ViewControls.AdminPageControls.APWorkersControl" %>

<div id="workers-list">

    <asp:UpdatePanel runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="APViewsWrapper container" runat="server">

                <asp:GridView runat="server" ID="workersList"
                    DataKeyNames="Id"
                    GridLines="None"
                    PageSize="10"
                    RowStyle-Height="25px"
                    HeaderStyle-Height="30px"
                    HeaderStyle-CssClass="border-bottom"
                    HeaderStyle-BackColor="DarkCyan"
                    HeaderStyle-ForeColor="Azure"
                    Font-Size="Larger"
                    ForeColor="#000099"
                    CellPadding="5"
                    AutoGenerateColumns="false">

                    <AlternatingRowStyle BackColor="Highlight" />

                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="Id" />
                        <asp:BoundField DataField="FirstName" HeaderText="First Name" />
                        <asp:BoundField DataField="LastName" HeaderText="Last Name" />
                        <asp:ButtonField ButtonType="Link" ControlStyle-CssClass="btn btn-primary" Text="Info" />
                        <asp:ButtonField ButtonType="Link" ControlStyle-CssClass="btn btn-warning" Text="Edit" />
                        <asp:ButtonField ButtonType="Link" ControlStyle-CssClass="btn btn-danger" Text="Delete" />
                    </Columns>

                </asp:GridView>

            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</div>
