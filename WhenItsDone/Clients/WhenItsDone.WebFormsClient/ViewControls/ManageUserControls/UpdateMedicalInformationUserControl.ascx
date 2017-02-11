<%@ Control
    Language="C#"
    AutoEventWireup="true"
    CodeBehind="UpdateMedicalInformationUserControl.ascx.cs"
    Inherits="WhenItsDone.WebFormsClient.ViewControls.ManageUserControls.UpdateMedicalInformationUserControl" %>

<h1>Update Medical Information</h1>
<asp:HiddenField ID="LoggedUserUsername" Value="" runat="server" />
<asp:EntityDataSource
    ID="UsersDataSource" runat="server"
    DefaultContainerName="Entities"
    EntitySetName="Users"
    ConnectionString="name=Entities"
    EnableUpdate="true"
    EnableFlattening="false"
    Where="it.Username=@Username">
    <WhereParameters>
        <asp:ControlParameter
            ControlID="LoggedUserUsername"
            DbType="String"
            Name="Username" />
    </WhereParameters>
</asp:EntityDataSource>

<asp:GridView
    ID="UserInfoGridView" runat="server"
    DataSourceID="UsersDataSource"
    Visible="false"
    AutoGenerateColumns="false"
    DataKeyNames="Id">
</asp:GridView>

<asp:EntityDataSource
    ID="MedicalInformationEntityDataSource" runat="server"
    DefaultContainerName="Entities"
    EntitySetName="MedicalInformations"
    ConnectionString="name=Entities"
    EnableUpdate="true"
    EnableFlattening="false"
    Where="it.Id=@Id">
    <WhereParameters>
        <asp:ControlParameter
            ControlID="LoggedUserUsername"
            DbType="Int32"
            Name="Id" />
    </WhereParameters>
</asp:EntityDataSource>

<asp:GridView
    ID="MedicalInformationGridView" runat="server"
    DataSourceID="MedicalInformationEntityDataSource"
    AutoGenerateColumns="false"
    DataKeyNames="Id">
    <Columns>
        <asp:CommandField ShowEditButton="true" />
        <asp:BoundField DataField="HeightInCm" HeaderText="First Name" />
        <asp:BoundField DataField="WeightInKg" HeaderText="Last Name" />
    </Columns>
</asp:GridView>
