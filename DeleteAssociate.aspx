<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="DeleteAssociate.aspx.cs" Inherits="WebApplication4.DeleteAssociate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            color: #FFFFFF;
            font-weight: bold;
        }
        .auto-style3 {
            color: #000000;
            font-weight: bold;
            margin-left: 40px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p class="auto-style3">
        <span class="text-white">&nbsp; </span></p>
    <p class="auto-style3">
        <span class="text-white">&nbsp;&nbsp; Select a colleague to remove</span></p>
    <p class="auto-style3">
&nbsp;&nbsp; <span class="text-white">Y</span><span class="auto-style2">our Colleagues</span></p>
    <p class="auto-styl1">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:DropDownList ID="DropDownList1" runat="server" Width="239px" DataTextField="SharedUsername" DataValueField="SharedUsername" AutoPostBack="true">
        </asp:DropDownList>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnRemove" runat="server" Text="Remove Colleague" OnClick="btnRemove_Click" Width="375px" />
        &nbsp;&nbsp;
        <asp:Label ID="lblRemove" runat="server" Text=""></asp:Label>
    </p>
    <p class="auto-styl1">
        &nbsp;</p>
    <p class="auto-styl1">
        &nbsp;</p>
</asp:Content>
