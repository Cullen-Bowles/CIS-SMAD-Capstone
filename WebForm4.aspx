<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="WebForm4.aspx.cs" Inherits="WebApplication4.WebForm4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <asp:Label ID="lblfirstname" runat="server" Text="First Name: " ForeColor="White"></asp:Label>
        <asp:TextBox ID="txtfirstname" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lbllastname" runat="server" Text="Last Name: " ForeColor="White"></asp:Label>
        <asp:TextBox ID="txtlastname" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblusername" runat="server" Text="Username: " ForeColor="White"></asp:Label>
        <asp:TextBox ID="txtusername" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblpassword" runat="server" Text="Password: " ForeColor="White"></asp:Label>
        <asp:TextBox ID="txtpassworrd" runat="server" type="password"></asp:TextBox>
        <br />
        <asp:Label ID="lblconfirmpass" runat="server" Text="Confirm Pass: " ForeColor="White"></asp:Label>
        <asp:TextBox ID="txtconfirmpass" runat="server" type="password"></asp:TextBox>
        <br />
        <asp:Label ID="lblemail" runat="server" Text="Email: " ForeColor="White"></asp:Label>
        <asp:TextBox ID="txtemail" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblorganization" runat="server" Text="Organization: " ForeColor="White"></asp:Label>
        <asp:TextBox ID="txtorganization" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblreason" runat="server" Text="Reason for Use: " ForeColor="White"></asp:Label>
        <asp:TextBox ID="txtreason" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnplaceholder" runat="server" Text="Create User" />
</asp:Content>
