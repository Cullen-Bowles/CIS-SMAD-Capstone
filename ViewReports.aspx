<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ViewReports.aspx.cs" Inherits="WebApplication4.ViewReports" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        /*body {*/

        /*text-align: left;*/
        /*}*/

        section {
            margin-left: auto;
            margin-right: auto;
            width: 70%;
            text-align: left;
        }

        .column {
            float: left;
            width: 15%;
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

        .ddlmargin {
            margin: 5px;
        }

        aside {
            float: right;
            width: 500px;
            position: relative;
            right: 20px;
        }

        .addPadding {
            padding: 5px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <aside>
        <%--<form id="form1" runat="server">--%>
        <div>
            <h2>Example of a returned analysis from the 3rd Party app</h2>
            <asp:Label ID="lblSelectAnalysis" runat="server" Text="SelectAnalysis"></asp:Label>
            <asp:DropDownList ID="ddlSAList" runat="server"></asp:DropDownList>
            <asp:Label ID="lblRequests" runat="server" Text="Choose Request:"></asp:Label>
            <asp:DropDownList ID="ddlRequest" runat="server">
                <asp:ListItem Text="gettitle"></asp:ListItem>
                <asp:ListItem Text="getsource"></asp:ListItem>
                <asp:ListItem Text="getpeople"></asp:ListItem>
                <asp:ListItem Text="getplaces"></asp:ListItem>
                <asp:ListItem Text="getvisinteractionschord"></asp:ListItem>
                <asp:ListItem Text="getvisnarrativeweb"></asp:ListItem>
                <asp:ListItem Text="getviswordcloud-subjects"></asp:ListItem>
                <asp:ListItem Text="getviswordcloud-places"></asp:ListItem>
                <asp:ListItem Text="getviswordcloud-people"></asp:ListItem>
                <asp:ListItem Text="getviswordcloud-groups"></asp:ListItem>
                <asp:ListItem Text="getsentencedetails"></asp:ListItem>
                <asp:ListItem Text="showdashboard"></asp:ListItem>
                <asp:ListItem Text="showbootstrapdashboard"></asp:ListItem>

            </asp:DropDownList>
            <br />
            <asp:Button ID="btnMakeRequest" runat="server" Text="Make Analysis Request" OnClick="btnMakeRequest_Click" />
            <br />
            <asp:TextBox ID="txtDisplay" runat="server" Rows="15" Height="200" Width="400" TextMode="MultiLine"></asp:TextBox>
        </div>
        <div runat="server" id="displayViz"></div>
        <%--</form>--%>
    </aside>
    <br />
    <br />
    <asp:DropDownList ID="ddlusersreports" runat="server" OnSelectedIndexChanged="ddlusersstories_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
    <br />
    <br />
    <asp:Label ID="lblstorytitle" runat="server" Text="Story Title: " ForeColor="White"></asp:Label>
    <asp:TextBox ID="txtstorytile" runat="server" ReadOnly="true"></asp:TextBox>
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
