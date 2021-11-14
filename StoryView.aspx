<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="StoryView.aspx.cs" Inherits="WebApplication4.StoryView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .storyFormat {
            text-align: left;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="card">
        <div class="card-body">
            <div class="storyFormat">
                <h1>Your Stories</h1>
                <div class="row">
                    <asp:DropDownList ID="StoriesList" runat="server" Width="500" OnSelectedIndexChanged="StoriesList_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                </div>
                <div class="row">
                    <asp:Label ID="LoggedIn" runat="server" Text=""></asp:Label>
                </div>
                <div class="row">
                    <div class="col-3">
                        <asp:Label ID="StoryTitle" runat="server" Text="Story Title:" ></asp:Label>
                    </div>
                    <div class="col-9">
                        <asp:TextBox ID="StoryTitleEntry" CssClass="form-control" runat="server" AutoPostBack="false" ReadOnly="true"></asp:TextBox>
                        <span>&nbsp;</span>

                    </div>
                </div>


                <div class="row">
                    <div class="col-3">
                        <asp:Label ID="StoryDate" runat="server" Text="Story Submission Date:" ></asp:Label>
                    </div>
                    <div class="col-9">
                        <asp:TextBox ID="StoryDateEntry" runat="server" CssClass="form-control" AutoPostBack="false" ReadOnly="true"></asp:TextBox>
                        <span>&nbsp;</span>
                    </div>
                </div>
                <div class="row">
                    <div class="col-3">
                        <asp:Label ID="StorySource" runat="server" Text="Story Source:" ></asp:Label>
                    </div>
                    <div class="col-9">
                        <asp:TextBox ID="StorySourceEntry" runat="server" AutoPostBack="false" ReadOnly="true"></asp:TextBox>
                        <span>&nbsp;</span>

                    </div>
                </div>
                <div class="row">
                    <div class="col-3">
                        <asp:Label ID="StoryText" runat="server" Text="Story Text:"></asp:Label>
                    </div>
                    <div class="col-9">
                        <asp:TextBox ID="StoryTextEntry" runat="server" Rows="10" Columns="100" AutoPostBack="false" CssClass="form-control" TextMode="MultiLine" Wrap="True" ReadOnly="true"></asp:TextBox>
                        <span>&nbsp;</span>
                    </div>
                </div>

            </div>
        </div>
    </div>
</asp:Content>
