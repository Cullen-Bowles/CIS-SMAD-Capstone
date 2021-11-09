<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="SubmitRequest.aspx.cs" Inherits="WebApplication4.SubmitRequest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--<br />
    <br />
    <asp:DropDownList ID="ddlusersstories" runat="server" OnSelectedIndexChanged="ddlusersstories_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
    <br />
    <br />
    <asp:Label ID="lblstorytitle" runat="server" Text="Story Title: " ForeColor="White"></asp:Label>
    <asp:TextBox ID="txtstorytile" runat="server" ReadOnly="true"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="lblstorydate" runat="server" Text="Story Date: " ForeColor="White"></asp:Label>
    <asp:TextBox ID="txtsubmissiondate" runat="server" TextMode="Date"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="lblstorysource" runat="server" Text="Story Source: " ForeColor="White"></asp:Label>
    <asp:TextBox ID="txtstorysource" runat="server" ReadOnly="true"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="lblstorytext" runat="server" Text="Story Text: " ForeColor="White"></asp:Label>
    <br />
    <br />
    <asp:TextBox ID="txtstorytext" runat="server" ReadOnly="true" Width="150px" Height="300px" TextMode="MultiLine"></asp:TextBox>
    <br />
    <br />
    <asp:Button ID="btnSubmitRequest" runat="server" Text="Submit Request" OnClick="btnSubmitRequest_Click1" />--%>
    <div class="card">
        <div class="card-body">
            <asp:Label ID="lblAnalysis" runat="server" Text="Choose Analysis:"></asp:Label>
            &nbsp;&nbsp;
            <asp:DropDownList ID="ddlExtracts" runat="server"></asp:DropDownList>
            <br />
            <br />
            <asp:Label ID="lblCommand" runat="server" Text="Choose POST Command:"></asp:Label>
            &nbsp;&nbsp;
            <asp:DropDownList ID="ddlCommands" runat="server">
                <asp:ListItem Text="saextract"></asp:ListItem>
                <asp:ListItem Text="setdates"></asp:ListItem>
                <asp:ListItem Text="setsentencedetails"></asp:ListItem>
                <asp:ListItem Text="settokensdetail"></asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            <strong>Upload a New Story (Select 'saextract' from the list above):
            </strong>
            <br />
            <br />
            <asp:Label ID="lblemail" runat="server" Text="User Email:"></asp:Label>
            &nbsp;&nbsp;
            <asp:TextBox ID="txtEmail" runat="server" Width="200" ReadOnly="true"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblTitle" runat="server" Text="Story Title:"></asp:Label>
            &nbsp;&nbsp;
            <asp:TextBox ID="txtTitle" runat="server" Width="200"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblURL" runat="server" Text="Story Source (URL):"></asp:Label>
            &nbsp;&nbsp;
            <asp:TextBox ID="txtURL" runat="server" Width="300"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblStoryBody" runat="server" Text="Body of Story Text:"></asp:Label>
            <br />
            <asp:TextBox ID="txtStory" runat="server" TextMode="MultiLine" Width="600" Height="200"></asp:TextBox>
            <br />
            <asp:Button ID="btnSubmit" runat="server" Text="Send Story to SA for Analysis ->" OnClick="btnSubmit_Click" />
            <br />
            <br />
            <asp:Label ID="lblPostResponseMessage" runat="server" Text="" ForeColor="Red" Font-Bold="true" Font-Size="X-Large"></asp:Label>
        </div>
    </div>
</asp:Content>
