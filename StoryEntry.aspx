﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="StoryEntry.aspx.cs" Inherits="WebApplication4.StoryEntry" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        h1{
            color: white;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="storyFormat">
        <h1 color="white">Submit Stories</h1>
        <asp:Label ID="submitted" runat="server" Text="" ForeColor="White"></asp:Label>
        <br />
        <br />

        <asp:Label ID="StoryTitle" runat="server" Text="Story Title:" ForeColor="White"></asp:Label>
        <asp:TextBox ID="StoryTitleEntry" runat="server" Width="430px" AutoPostBack="true"></asp:TextBox>
        <asp:Label ID="ExistingStory" runat="server" Text="" ForeColor="White"></asp:Label>
        <br />
        <%-- Validators make sure text box is not empty--%>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="StoryTitleEntry" ForeColor="Red" Text="Story Title Cannot be blank" BorderStyle="Solid" BorderWidth="2px"></asp:RequiredFieldValidator>
        <br />

        <br />
        <asp:Label ID="StoryDate" runat="server" Text="Story Submission Date:" ForeColor="White"></asp:Label>
        <asp:TextBox ID="StoryDateEntry" runat="server" Width="353px" AutoPostBack="true" TextMode="Date"></asp:TextBox>
        <br />
        <%-- Validators make sure text box is not empty and is correct data type--%>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="StoryDateEntry" ForeColor="Red" Text="Story Date Cannot be blank " BorderStyle="Solid" BorderWidth="2px"></asp:RequiredFieldValidator>
        <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="CompareValidator" ControlToValidate="StoryDateEntry" Text="Story Date must be in mm/dd/yyyy Format" Operator="DataTypeCheck" Type="Date" ForeColor="DarkRed" BorderStyle="Solid" BorderWidth="2px"></asp:CompareValidator>
        <br />

        <br />
        <asp:Label ID="StorySource" runat="server" Text="Story Source:" ForeColor="White"></asp:Label>
        <asp:TextBox ID="StorySourceEntry" runat="server" Width="412px" AutoPostBack="true"></asp:TextBox>
        <br />
        <%-- Validators make sure text box is not empty--%>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="StorySourceEntry" ForeColor="Red" Text="Story Source Cannot be blank" BorderStyle="Solid" BorderWidth="2px"></asp:RequiredFieldValidator>
        <br />
        <br />
        <asp:Label ID="StoryText" runat="server" Text="Story Text:" ForeColor="White"></asp:Label>
        <%-- Validators make sure text box is not empty--%>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="StoryTextEntry" ForeColor="Red" Text="Story Text Cannot be blank" BorderStyle="Solid" BorderWidth="2px"></asp:RequiredFieldValidator>
        <br />
        <asp:TextBox ID="StoryTextEntry" runat="server" Width="500" Height="650" AutoPostBack="true" TextMode="MultiLine" Wrap="True"></asp:TextBox>
        <br />

        <%-- <textarea id="StoryTextEntry" cols="20" rows="2" AutoPostBack="true"></textarea>--%>
        <br />
        <%--<asp:Button ID="Populate" runat="server" Text="Populate" Height="25px" Width="70px" OnClick="Populate_Click" CausesValidation="False" />--%>
        <%--<asp:Button ID="Save" runat="server" Text="Save" Height="25px" Width="70px" OnClick="Save_Click" />--%>
        <asp:Button ID="Confirm" runat="server" Text="Save" Height="25px" Width="70px" OnClick="Confirm_Click" />
        <asp:Button ID="Clear" runat="server" Text="Clear" Height="25px" Width="70px" OnClick="Clear_Click" CausesValidation="False" />
    </div>
</asp:Content>
