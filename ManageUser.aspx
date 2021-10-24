<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ManageUser.aspx.cs" Inherits="WebApplication4.ManageUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .column{
             float: left;
            width: 40%;
            padding: 20px;
            height: 50px;
            text-align:left;
            text-wrap:avoid;
        }
        .row:after {
            content: "";
            display: table;
            clear: both;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="column">
            <asp:Label ID="lblfirstname" runat="server" Text="First Name: " ForeColor="White"></asp:Label>
        </div>
        <div class="column">
            <asp:TextBox ID="txtfirstname" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtfirstname" Text="Must Enter First Name"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="row">
        <div class="column">
            <asp:Label ID="lbllastname" runat="server" Text="Last Name: " ForeColor="White"></asp:Label>
        </div>
        <div class="column">
            <asp:TextBox ID="txtlastname" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtlastname" Text="Must Enter Last Name"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="row">
        <div class="column">
            <asp:Label ID="lblusername" runat="server" Text="Username: " ForeColor="White"></asp:Label>
        </div>
        <div class="column">
            <asp:TextBox ID="txtusername" runat="server"></asp:TextBox>
            <asp:Label ID="UserUpdated" runat="server" Text=""></asp:Label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="RequiredFieldValidator" Text="Must Enter Username" ControlToValidate="txtusername"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="row">
        <div class="column">
            <asp:Label ID="lbloldpass" runat="server" Text="Current Password: " ForeColor="White"></asp:Label>
        </div>
        <div class="column">
            <asp:TextBox ID="txtoldpassword" runat="server" type="password"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="column">
            <asp:Label ID="lblnewpass" runat="server" Text="New Password: " ForeColor="White"></asp:Label>
        </div>
        <div class="column">
            <asp:TextBox ID="txtnewpassword" runat="server" type="password"></asp:TextBox>
            <asp:Label ID="noMatch" runat="server" Text=""></asp:Label>
        </div>
    </div>
    <div class="row">
        <div class="column">
            <asp:Label ID="lblconpass" runat="server" Text="Confirm New Password: " ForeColor="White"></asp:Label>
        </div>
        <div class="column">
            <asp:TextBox ID="txtconpassword" runat="server" type="password"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="column">
            <asp:Label ID="lblemail" runat="server" Text="Email: " ForeColor="White"></asp:Label>
        </div>
        <div class="column">
             <asp:TextBox ID="txtemail" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtemail" Text="Must Enter Email"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="RegularExpressionValidator" ControlToValidate="txtemail" Text="Invalid Email" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
        </div>
    </div>
    <div class="row">
        <div class="column">
            <asp:Label ID="lblorganization" runat="server" Text="Orginization: " ForeColor="White"></asp:Label>
        </div>
        <div class="column">
            <asp:TextBox ID="txtorganization" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtorganization" Text="Must Enter Organization"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="row">
        <div class="column">
            <asp:Label ID="lblreason" runat="server" Text="Reason: "></asp:Label>
        </div>
        <div class="column">
            <asp:TextBox ID="txtreason" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtreason" Text="Must Enter Reason"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="row">
        <div class="column">
            <asp:Button ID="btnconfirm" runat="server" Text="Save Changes" OnClick="btnconfirm_Click"/>
        </div>
    </div>
</asp:Content>
