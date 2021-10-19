<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AssociateReport.aspx.cs" Inherits="WebApplication4.AssociateReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>!!!WORK IN PROGRESS!!!</h1>
    <br />
    <br />
    <asp:DropDownList ID="ddlsharedreports" runat="server" OnSelectedIndexChanged="ddlusersstories_SelectedIndexChanged"></asp:DropDownList>
    <br />
    <br />
    <asp:Label ID="lblstorytitle" runat="server" Text="Story Title: " ForeColor="White"></asp:Label>
    <asp:TextBox ID="txtstorytile" runat="server" ReadOnly="true" "></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="lblstorydate" runat="server" Text="Date Submitted: " ForeColor="White"></asp:Label>
    <asp:TextBox ID="txtsubmissiondate" runat="server" TextMode="Date"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="lblstorysource" runat="server" Text="Story Source: " ForeColor="White"></asp:Label>
    <asp:TextBox ID="txtstorysource" runat="server" ReadOnly="true"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="lblstorytext" runat="server" Text="Report: " ForeColor="White"></asp:Label>
    <asp:TextBox ID="txtstorytext" runat="server" ReadOnly="true"></asp:TextBox>
    <br />
    <br />
</asp:Content>
