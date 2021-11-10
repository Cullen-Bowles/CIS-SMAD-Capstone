<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="SubmitRequest.aspx.cs" Inherits="WebApplication4.SubmitRequest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row mb-1">
        <div class="col-6">
            <asp:DropDownList ID="ddlusersstories" runat="server" OnSelectedIndexChanged="ddlusersstories_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
        </div>
    </div>
    <div class="row mb-1">
        <div class="col-3">
            <asp:Label ID="lblAnalysis" runat="server" Text="Choose Analysis:"></asp:Label>
        </div>
        <div class="col-9">
            <asp:DropDownList ID="ddlExtracts" CssClass="form-control" runat="server"></asp:DropDownList>
        </div>
    </div>
    <div class="row mb-1">
        <div class="col-3">
            <asp:Label ID="lblCommand" runat="server" Text="Choose POST Command:"></asp:Label>
        </div>
        <div class="col-9">
            <asp:DropDownList ID="ddlCommands" runat="server" CssClass="form-control">
                <asp:ListItem Text="saextract"></asp:ListItem>
                <asp:ListItem Text="setdates"></asp:ListItem>
                <asp:ListItem Text="setsentencedetails"></asp:ListItem>
                <asp:ListItem Text="settokensdetail"></asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>
    <div class="row mb-1">
        <div class="col-10">
            <strong>Upload a New Story (Select 'saextract' from the list above):
            </strong>
        </div>
    </div>
    <div class="row mb-1">
        <div class="col-4"><asp:Label ID="lblemail" runat="server" Text="User Email:"></asp:Label></div>
        <div class="col-8"><asp:TextBox ID="txtEmail" runat="server" Width="200" ReadOnly="true"></asp:TextBox></div>
    </div>
    <div class="row mb-1">
        <div class="col-4"><asp:Label ID="lblTitle" runat="server" Text="Story Title:"></asp:Label></div>
        <div class="col-8"><asp:TextBox ID="txtTitle" runat="server" Width="200"></asp:TextBox></div>
    </div>
    <div class="row mb-1">
        <div class="col-4"> <asp:Label ID="lblURL" runat="server" Text="Story Source (URL):"></asp:Label></div>
        <div class="col-8"><asp:TextBox ID="txtURL" runat="server" Width="300"></asp:TextBox></div>
    </div>
    <div class="row mb-1">
        <div class="col-4"><asp:Label ID="lblStoryBody" runat="server" Text="Body of Story Text:"></asp:Label></div>
        <div class="col-8"><asp:TextBox ID="txtStory" runat="server" TextMode="MultiLine" Width="600" Height="200"></asp:TextBox></div>
    </div>
    <div class="row mb-1">
            <div class="col-4"><asp:Button ID="btnSubmit" runat="server" Text="Send Story to SA for Analysis ->" OnClick="btnSubmit_Click" /></div>
            <div class="col-8"><asp:Label ID="lblPostResponseMessage" runat="server" Text="" ForeColor="Red" Font-Bold="true" Font-Size="X-Large"></asp:Label></div>
    </div>    
</asp:Content>
