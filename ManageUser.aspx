﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ManageUser.aspx.cs" Inherits="WebApplication4.ManageUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .column{
            margin: 5px;
            display: inline-block;
        }
        .row{
            display: block;
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
        </div>
    </div>
    <div class="row">
        <div class="column">
            <asp:Label ID="lbllastname" runat="server" Text="Last Name: " ForeColor="White"></asp:Label>
        </div>
        <div class="column">
            <asp:TextBox ID="txtlastname" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="column">
            <asp:Label ID="lblusername" runat="server" Text="Username: " ForeColor="White"></asp:Label>
        </div>
        <div class="column">
            <asp:TextBox ID="txtusername" runat="server"></asp:TextBox>
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
        </div>
    </div>
    <div class="row">
        <div class="column">
            <asp:Label ID="lblorganization" runat="server" Text="Orginization: " ForeColor="White"></asp:Label>
        </div>
        <div class="column">
            <asp:TextBox ID="txtorganization" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="column">
            <asp:Label ID="lblreason" runat="server" Text="Reason: "></asp:Label>
        </div>
        <div class="column">
            <asp:TextBox ID="txtreason" runat="server"></asp:TextBox>
        </div>
    </div>
</asp:Content>
