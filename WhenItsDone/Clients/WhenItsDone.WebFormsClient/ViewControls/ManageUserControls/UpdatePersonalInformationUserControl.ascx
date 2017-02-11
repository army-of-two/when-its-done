<%@ Control
    Language="C#"
    AutoEventWireup="true"
    CodeBehind="UpdatePersonalInformationUserControl.ascx.cs"
    Inherits="WhenItsDone.WebFormsClient.ViewControls.ManageUserControls.UpdatePersonalInformationUserControl" %>

<h1>Update Personal Information</h1>

<asp:HiddenField ID="LoggedUserUsername" Value="<%#: LoggedUserUsernameFromIdentity %>" runat="server" />
<asp:EntityDataSource
    ID="UsersDataSource" runat="server"
    DefaultContainerName="Entities"
    EntitySetName="Users"
    ConnectionString="Entities"
    EnableUpdate="true"
    EnableFlattening="false"
    Where="it.Username=@Username">
    <WhereParameters>
        <asp:ControlParameter
            ControlID="LoggedUserUsername"
            DbType="String"
            Name="Username"
            DefaultValue="" />
    </WhereParameters>
</asp:EntityDataSource>

<asp:GridView
    ID="UserPersonalInfomationGridView" runat="server"
    DataSourceID="UsersDataSource"
    AutoGenerateColumns="false">
    <Columns>
        <asp:CommandField ShowEditButton="true" />
        <asp:BoundField DataField="FirstName" HeaderText="First Name" />
        <asp:BoundField DataField="LastName" HeaderText="Last Name" />
        <asp:BoundField DataField="Age" HeaderText="Age" />
    </Columns>
</asp:GridView>
