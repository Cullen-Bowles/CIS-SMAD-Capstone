<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AddAssociate.aspx.cs" Inherits="WebApplication4.AddAssociate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            color: #FFFFFF;
            font-weight: bold;
            margin-left: 40px;
        }
        .auto-style2 {
            color: #FFFFFF;
            font-weight: bold;
            margin-left: 680px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        &nbsp;</p>
    <p class="auto-style1">
        Add a colleague by searching their email:&nbsp;&nbsp;
        <asp:TextBox ID="txtsearch" runat="server"  Width="320px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblstatus" runat="server" Text=""></asp:Label>
    </p>
    <p class="auto-style2">
        &nbsp;&nbsp;
        <asp:Button ID="btnsearch" runat="server" Text="Add Colleague" OnClick="btnsearch_Click" />
    </p>
    <p class="auto-style2">
        &nbsp;</p>
    <p class="auto-style1">
        <asp:DropDownList ID="ddlCommonsAssociates" runat="server" Width="287px">
        </asp:DropDownList>
&nbsp;
        <asp:Button ID="btndelete" runat="server" Text="Delete Colleague" />
    &nbsp;&nbsp;&nbsp;
        <asp:Label ID="lbldelete" runat="server" Text=""></asp:Label>
    </p>
    <p class="auto-style1">
        &nbsp;</p>
    <p class="auto-style1">
        &nbsp;</p>
</asp:Content>
