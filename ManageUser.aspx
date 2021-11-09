<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ManageUser.aspx.cs" Inherits="WebApplication4.ManageUser" %>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="card">
        <div class="card-body">
       <div class="row">
        <div class="col-3">
            <asp:Label ID="lblfirstname" runat="server" Text="First Name: " ></asp:Label>
        </div>
        <div class="col-9">
            <asp:TextBox ID="txtfirstname" CssClass="form-control" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtfirstname" Text="Must Enter First Name"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="row">
        <div class="col-3">
            <asp:Label ID="lbllastname" runat="server" Text="Last Name: " ></asp:Label>
        </div>
        <div class="col-9">
            <asp:TextBox ID="txtlastname" CssClass="form-control" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtlastname" Text="Must Enter Last Name"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="row">
        <div class="col-3">
            <asp:Label ID="lblusername" runat="server" Text="Username: " ></asp:Label>
        </div>
        <div class="col-9">
            <asp:TextBox ID="txtusername" CssClass="form-control" runat="server"></asp:TextBox>
            <asp:Label ID="UserUpdated" runat="server" Text=""></asp:Label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="RequiredFieldValidator" Text="Must Enter Username" ControlToValidate="txtusername"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="row">
        <div class="col-3">
            <asp:Label ID="lbloldpass" runat="server" Text="Current Password: "></asp:Label>
        </div>
        <div class="col-9">
            <asp:TextBox ID="txtoldpassword" CssClass="form-control" runat="server" type="password"></asp:TextBox>
            <span>&nbsp;</span>
        </div>
    </div>
    <div class="row">
        <div class="col-3">
            <asp:Label ID="lblnewpass" runat="server" Text="New Password: " ></asp:Label>
        </div>
        <div class="col-9">
            <asp:TextBox ID="txtnewpassword" CssClass="form-control" runat="server" type="password"></asp:TextBox>
            <asp:Label ID="noMatch" runat="server" Text=""></asp:Label>
            <span>&nbsp;</span>
        </div>
    </div>
    <div class="row">
        <div class="col-3">
            <asp:Label ID="lblconpass" runat="server" Text="Confirm New Password: " ></asp:Label>
        </div>
        <div class="col-9">
            <asp:TextBox ID="txtconpassword" CssClass="form-control" runat="server" type="password"></asp:TextBox>
            <span>&nbsp;</span>
        </div>
    </div>
    <div class="row">
        <div class="col-3">
            <asp:Label ID="lblemail" runat="server" Text="Email: "></asp:Label>
        </div>
        <div class="col-9">
             <asp:TextBox ID="txtemail" CssClass="form-control" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtemail" Text="Must Enter Email"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="RegularExpressionValidator" ControlToValidate="txtemail" Text="Invalid Email" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
        </div>
    </div>
    <div class="row">
        <div class="col-3">
            <asp:Label ID="lblorganization" runat="server" Text="Orginization: " ></asp:Label>
        </div>
        <div class="col-9">
            <asp:TextBox ID="txtorganization" CssClass="form-control" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtorganization" Text="Must Enter Organization"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="row">
        <div class="col-3">
            <asp:Label ID="lblreason" runat="server" Text="Reason: "></asp:Label>
        </div>
        <div class="col-9">
            <asp:TextBox ID="txtreason" CssClass="form-control" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtreason" Text="Must Enter Reason"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="row">
        <div class="column">
            <asp:Button ID="btnconfirm" runat="server" CssClass="btn btn-primary" Text="Save Changes" OnClick="btnconfirm_Click"/>
        </div>
    </div>
        </div>
    </div>

    
</asp:Content>
