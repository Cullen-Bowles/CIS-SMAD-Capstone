<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="StoryEdit.aspx.cs" Inherits="WebApplication4.StoryEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="storyFormat">

        <h1>View Posted Texts</h1>
        <div class="row">
            <asp:DropDownList ID="StoriesList" runat="server" CssClass="form-control" Width="500" OnSelectedIndexChanged="StoriesList_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
        </div>
        <div class="row">
            <asp:Label ID="LoggedIn" runat="server" Text=""></asp:Label>
        </div>
        <br />
        <br />
        <div class="row">
            <div class="col-3">
                <asp:Label ID="StoryTitle" runat="server" Text="Story Title:"></asp:Label>
            </div>
            <div class="col-9">
                <asp:TextBox ID="StoryTitleEntry" CssClass="form-control" runat="server" AutoPostBack="false"></asp:TextBox>
                <asp:Label ID="ExistingStory" runat="server" Text=""></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="StoryTitleEntry" ForeColor="Red" Text="Story Title Cannot be blank" BorderStyle="Solid" BorderWidth="2px"></asp:RequiredFieldValidator>
            </div>
        </div>


        <div class="row">
            <div class="col-3">
                <asp:Label ID="StoryDate" runat="server" Text="Story Submission Date:"></asp:Label>
            </div>
            <div class="col-9">
                <asp:TextBox ID="StoryDateEntry" runat="server" CssClass="form-control" AutoPostBack="false" TextMode="Date"></asp:TextBox>

                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="StoryDateEntry" ForeColor="Red" Text="Story Date Cannot be blank " BorderStyle="Solid" BorderWidth="2px"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="CompareValidator" ControlToValidate="StoryDateEntry" Text="Story Date must be in mm/dd/yyyy Format" Operator="DataTypeCheck" Type="Date" ForeColor="DarkRed" BorderStyle="Solid" BorderWidth="2px"></asp:CompareValidator>
            </div>
        </div>
        <div class="row">
            <div class="col-3">
                <asp:Label ID="StorySource" runat="server" Text="Story Source:"></asp:Label>
            </div>
            <div class="col-9">
                <asp:TextBox ID="StorySourceEntry" runat="server" AutoPostBack="false"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="StorySourceEntry" ForeColor="Red" Text="Story Source Cannot be blank" BorderStyle="Solid" BorderWidth="2px"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="row">
            <div class="col-3">
                <asp:Label ID="StoryText" runat="server" Text="Story Text:"></asp:Label>
            </div>
            <div class="col-9">
                <asp:TextBox ID="StoryTextEntry" runat="server" Rows="10" Columns="100" AutoPostBack="false" CssClass="form-control" TextMode="MultiLine" Wrap="True"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="StoryTextEntry" ForeColor="Red" Text="Story Text Cannot be blank" BorderStyle="Solid" BorderWidth="2px"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="row">
            <asp:Button ID="Confirm" runat="server" Text="Save Changes" Height="25px" Width="70px" OnClick="Confirm_Click" />
            <%--<asp:Button ID="Clear" runat="server" Text="Clear" Height="25px" Width="70px" OnClick="Clear_Click" CausesValidation="False" />--%>
        </div>
</asp:Content>
