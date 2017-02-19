<%@ Control Language="C#"
    AutoEventWireup="true"
    CodeBehind="APWorkerDetails.ascx.cs"
    Inherits="WhenItsDone.WebFormsClient.ViewControls.AdminPageControls.APWorkerDetails" %>

<div id="workers-list">
    <div class="APViewsWrapper col s12">
        <div class="row">
            <div class="input-field col s1 offset-s1">
                <label for="Id" class="active">Id</label>
                <input runat="server" type="text" id="Id" value="<%#this.Model.Worker?.Id.ToString() %>" />
            </div>
            <div class="input-field col s1">
                <label for="Rating" class="active">Rating</label>
                <input runat="server" type="text" id="Rating" value="<%#this.Model.Worker?.Rating.ToString() %>" />
            </div>
        </div>
        <div class="row">
            <div class="input-field col s3 offset-s1">
                <label for="FirstName" class="active">First name</label>
                <input runat="server" type="text" id="FirstName" value="<%#this.Model.Worker?.FirstName.ToString() %>" />
            </div>
            <div class="input-field col s3">
                <label for="LastName" class="active">Last name</label>
                <input runat="server" type="text" id="LastName" value="<%#this.Model.Worker?.LastName.ToString() %>" />
            </div>
        </div>
        <div class="row">
            <div class="input-field col s3 offset-s1">
                <label for="Gender" class="active">Gender</label>
                <input runat="server" type="text" id="Gender" value="<%#this.Model.Worker?.Gender.ToString() %>" />
            </div>
            <div class="input-field col s1">
                <label for="Age" class="active">Age</label>
                <input runat="server" type="text" id="Age" value="<%#this.Model.Worker?.Age.ToString() %>" />
            </div>
        </div>
        <div class="row">
            <div class="input-field col s3 offset-s1">
                <label for="Email" class="active">Email</label>
                <input runat="server" type="text" id="Email" value="<%#this.Model.Worker?.Email.ToString() %>" />
            </div>
            <div class="input-field col s3 ">
                <label for="PhoneNumber" class="active">Phone</label>
                <input runat="server" type="text" id="PhoneNumber" value="<%#this.Model.Worker?.PhoneNumber.ToString() %>" />
            </div>
        </div>
        <div class="row">
            <div class="input-field col s2 offset-s1">
                <label for="Country" class="active">Country</label>
                <input runat="server" type="text" id="Country" value="<%#this.Model.Worker?.Country.ToString() %>" />
            </div>
            <div class="input-field col s2">
                <label for="City" class="active">City</label>
                <input runat="server" type="text" id="City" value="<%#this.Model.Worker?.City.ToString() %>" />
            </div>
            <div class="input-field col s4">
                <label for="Address" class="active">Address</label>
                <input runat="server" type="text" id="Address" value="<%#this.Model.Worker?.Street.ToString() %>" />
            </div>
        </div>
    </div>
</div>
