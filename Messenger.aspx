<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Messenger.aspx.cs" Inherits="WebApplication4.Messanger" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:DropDownList ID="ddlsharedusers" runat="server" OnSelectedIndexChanged="ddlsharedusers_SelectedIndexChanged"></asp:DropDownList>
    <asp:Label ID="lblreceived" runat="server" Text="Received Messages"></asp:Label>
    <asp:TextBox ID="txtmessages" runat="server" ReadOnly="true" TextMode="MultiLine" Rows="10" Columns="100"></asp:TextBox>
    <asp:Label ID="lblmessage" runat="server" Text="Enter in a message: "></asp:Label>
    <asp:TextBox ID="txtmessage" runat="server" TextMode="MultiLine" Rows="5" Columns="100"></asp:TextBox>
    <asp:Button ID="btnsend" runat="server" Text="Send Message" OnClick="btnsend_Click"/>
</asp:Content>
