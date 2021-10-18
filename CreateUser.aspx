<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="CreateUser.aspx.cs" Inherits="WebApplication4.WebForm4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .formatCon{
            width: 80%;
            margin-right: auto;
            margin-left: auto;
        }
        .column{
            float: left;
            width: 40%;
            padding: 20px;
            height: 50px;
            text-align: left;
            text-wrap: avoid;
           
        }
        .row:after {
            content: "";
            display: table;
            clear: both;
        }
        .columnTitles {
            float: left;
            width: 20%;
            padding: 20px;
            height: 50px;
            text-wrap: avoid;
            
        }

        .columnHead {
            float: left;
            width: 25%;
            padding: 20px;
            height: 100px;
            margin: 1em;
            text-wrap: avoid;
            
        }
    </style>
</asp:Content>
<asp:Content CssClass="formatCon" ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <div class="row">
        <div class="columnTitles">
            <asp:Label ID="lblfirstname" runat="server" Text="First Name: " ForeColor="White"></asp:Label>
        </div>
        <div class="column">
            <asp:TextBox ID="txtfirstname" runat="server"></asp:TextBox>
            <asp:Label ID="ExistingUser" runat="server" Text="" ForeColor="Red"></asp:Label>
        </div>
    </div>
    <div class="row">
        <div class="columnTitles">
            <asp:Label ID="lbllastname" runat="server" Text="Last Name: " ForeColor="White"></asp:Label>
        </div>
        <div class="column">
            <asp:TextBox ID="txtlastname" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="columnTitles">
            <asp:Label ID="lblusername" runat="server" Text="Username: " ForeColor="White"></asp:Label>
        </div>
        <div class="column">
            <asp:TextBox ID="txtusername" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="columnTitles">
            <asp:Label ID="lblpassword" runat="server" Text="Current Password: " ForeColor="White"></asp:Label>
        </div>
        <div class="column">
            <asp:TextBox ID="txtpassword" runat="server" type="password"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="columnTitles">
            <asp:Label ID="lblconpass" runat="server" Text="Confirm New Password: " ForeColor="White"></asp:Label>
        </div>
        <div class="column">
            <asp:TextBox ID="txtconpassword" runat="server" type="password"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="columnTitles">
            <asp:Label ID="lblemail" runat="server" Text="Email: " ForeColor="White"></asp:Label>
        </div>
        <div class="column">
             <asp:TextBox ID="txtemail" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="columnTitles">
            <asp:Label ID="lblorganization" runat="server" Text="Orginization: " ForeColor="White"></asp:Label>
        </div>
        <div class="column">
            <asp:TextBox ID="txtorganization" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="columnTitles">
            <asp:Label ID="lblreason" runat="server" Text="Reason: " ForeColor="White"></asp:Label>
        </div>
        <div class="column">
            <asp:TextBox ID="txtreason" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="columnTitles">
            <asp:Button ID="btncreateuser" runat="server" Text="Create User" OnClick="btncreateuser_Click" />
            <asp:Button ID="btnclear" runat="server" Text="Clear Info" OnClick="btnclear_Click" />
        </div>       
    </div>

</asp:Content>
