<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="StoryEdit.aspx.cs" Inherits="WebApplication4.StoryEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="storyFormat">
        
        <h1>View Posted Texts</h1>
        <asp:DropDownList ID="StoriesList" runat="server" Width="500"  OnSelectedIndexChanged="StoriesList_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
        <br />
        <br />
        <asp:Label ID="StoryTitle" runat="server" Text="Story Title:" ForeColor="White"></asp:Label>
        <asp:TextBox ID="StoryTitleEntry" runat="server" Width="432px" AutoPostBack="True" ></asp:TextBox>
        <%--<asp:CheckBox ID="CheckBox1" runat="server" OnCheckedChanged="CheckBox1_CheckedChanged" AutoPostBack="True" />--%>
        <asp:Label ID="LoggedIn" runat="server" Text=""></asp:Label>
        <br />
        <br />
        <br />
        <asp:Label ID="StoryDate" runat="server" Text="Story Submission Date:" ForeColor="White"></asp:Label>
        <asp:TextBox ID="StoryDateEntry" runat="server" Width="357px" AutoPostBack="True" TextMode="SingleLine"></asp:TextBox>
        <br />
        <%-- Validators make sure date is not empty and matches a specific format --%>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="StoryDateEntry" ForeColor="DarkRed" Text="Story Date Cannot be blank " BorderStyle="Solid" BorderWidth="2px"></asp:RequiredFieldValidator>
        <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="CompareValidator" ControlToValidate="StoryDateEntry" Text="Story Date must be in xx/xx/xxxx Format" Operator="DataTypeCheck" Type="Date" ForeColor="DarkRed" BorderStyle="Solid" BorderWidth="2px"></asp:CompareValidator>
        <br />

        <br />
        <asp:Label ID="StorySource" runat="server" Text="Story Source:" ForeColor="White"></asp:Label>
        <asp:TextBox ID="StorySourceEntry" runat="server" Width="415px" AutoPostBack="True"></asp:TextBox>
        <br />
        <%-- Validators make sure text box is not empty--%>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="StorySourceEntry" ForeColor="DarkRed" Text="Story Source Cannot be blank" BorderStyle="Solid" BorderWidth="2px"></asp:RequiredFieldValidator>
        <br />
        <br />
        <asp:Label ID="StoryText" runat="server" Text="Story Text:" ForeColor="White"></asp:Label>
        <%-- Validators make sure text box is not empty--%>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="StoryTextEntry" ForeColor="DarkRed" Text="Story Text Cannot be blank" BorderStyle="Solid" BorderWidth="2px"></asp:RequiredFieldValidator>
        <br />
        <asp:TextBox ID="StoryTextEntry" runat="server" Width="500" Height="650" AutoPostBack="True" TextMode="MultiLine" Wrap="True" ></asp:TextBox>
        <br />
        <br />
        
        <%-- First Item in list is can't be selected until a second item is clicked --%>
        <br /> 
        <br />
        <%--<asp:Button ID="Populate" runat="server" Text="Populate" Height="25px" Width="70px" OnClick="Populate_Click" />--%>
        <%--<asp:Button ID="Save" runat="server" Text="Save" Height="25px" Width="70px" OnClick="Save_Click" />--%>
        <asp:Button ID="Confirm" runat="server" Text="Save Changes" Height="25px" Width="70px" OnClick="Confirm_Click" />
        <%--<asp:Button ID="Clear" runat="server" Text="Clear" Height="25px" Width="70px" OnClick="Clear_Click" CausesValidation="False" />--%>
    </div>
</asp:Content>
