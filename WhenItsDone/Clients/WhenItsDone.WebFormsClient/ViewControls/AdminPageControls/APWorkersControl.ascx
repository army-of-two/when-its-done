<%@ Control Language="C#" AutoEventWireup="true"
    CodeBehind="APWorkersControl.ascx.cs"
    Inherits="WhenItsDone.WebFormsClient.ViewControls.AdminPageControls.APWorkersControl" %>

<div id="workers-list">

    <asp:UpdatePanel runat="server" UpdateMode="Always">
        <ContentTemplate>
            <div class="APViewsWrapper container" runat="server">
                <table class="centered striped">
                    <thead>
                        <th data-field="Id" class="padding-5">Id</th>
                        <th data-field="FirstName">First Name</th>
                        <th data-field="LastName">Last Name</th>
                        <th data-field="NumberOfDishes">Number Of Dishes</th>
                        <th data-field="buttons"></th>
                    </thead>
                    <tbody>
                        <asp:Repeater runat="server"
                            ID="WorkersList"
                            ItemType="WhenItsDone.DTOs.WorkerVIewsDTOs.WorkerNamesIdDTO"
                            DataSource="<%# this.Model.WorkersWithDishes %>">

                            <ItemTemplate>
                                <tr>
                                    <td class="padding-5"><%# Item.Id %></td>
                                    <td><%# Item.FirstName %></td>
                                    <td><%# Item.LastName %></td>
                                    <td><%# Item.NumberOfDishes %></td>
                                    <td>
                                        <asp:Button runat="server" Text="Info" CssClass="btn light-green"
                                            ID="RepeaterBtn"
                                            CommandName="NeedInfo"
                                            CommandArgument="<%# Item.Id %>"
                                            OnClick="InfoClick" />
                                    </td>
                                </tr>
                            </ItemTemplate>

                        </asp:Repeater>
                    </tbody>

                </table>

            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</div>
