﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ManageReports.aspx.cs" Inherits="WebApplication4.ManageReports" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row mt-2">
        <div class="col-4">
            <asp:Label ID="lblSelectAnalysis" runat="server" Text="Select Analysis:"></asp:Label>
        </div>
        <div class="col-4">            
            <asp:DropDownList ID="ddlSAList" CssClass="form-control" runat="server"></asp:DropDownList>                        
        </div>
         <div class="col-4">
            <asp:Button ID="btnMakeRequest" CssClass="btn btn-success" runat="server" Text="Make Analysis Request" OnClick="btnMakeRequest_Click" />
        </div>
    </div>
    <div class="row mt-2">
        <div class="col-4">
            <asp:Label ID="lblRequests" runat="server" Text="Choose Request:"></asp:Label>
        </div>
        <div class="col-8">
            <asp:DropDownList CssClass="form-control" ID="ddlRequest" runat="server">
                <asp:ListItem Text="Edit the Title of the Story" Value="settitle"></asp:ListItem>
                <asp:ListItem Text="Edit the Source of the Story" Value="setsource"></asp:ListItem>
                <asp:ListItem Text="Edit the Output of the Extracts" Value="setsentencedetails"></asp:ListItem>
                <asp:ListItem Text="Edit the People in the Extract" Value="settokensdetail"></asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>
    <div class="row mt-2">
        <div class="col-4">
            <asp:Label ID="lblstorytitle" runat="server" Text="Story Title: "></asp:Label>
        </div>
        <div class="col-8">
            <asp:TextBox ID="txtstorytitle" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
        </div>
    </div>
   <%-- <div class="row mt-2">
        <div class="col-4">
            <asp:Label ID="lblstorydate" runat="server" Text="Date Submitted: "></asp:Label>
        </div>
        <div class="col-8">
            <asp:TextBox ID="txtsubmissiondate" CssClass="form-control" runat="server" TextMode="Date"></asp:TextBox>
        </div>
    </div>--%>
    <div class="row mt-2">
        <div class="col-4">
            <asp:Label ID="lblstorysource" runat="server" Text="Story Source: "></asp:Label>
        </div>
        <div class="col-8">
            <asp:TextBox ID="txtstorysource" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
        </div>
    </div>
    <div class="row mt-2">
        <div class="col-4">
            <asp:Label ID="lblstorytext" runat="server" Text="Report: "></asp:Label>
        </div>
        <div class="col-8">
            <asp:TextBox ID="txtstorytext" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
        </div>
    </div>
    <div class="row mt-2">
        <div class="col-4">
            <asp:Button ID="btnPUTedit" runat="server" Text="Confirm Edit" CssClass="btn btn-primary" OnClick="btnPUTedit_Click"/>
        </div>
        <div class="col-8"><asp:Label ID="lblPostResponseMessage" runat="server" Text="" ForeColor="Red" Font-Bold="true" Font-Size="X-Large"></asp:Label></div>
    </div>

   <%-- <div class="row mt-2">
        <div class="col-4">
            <asp:Button ID="btndeletereport" CssClass="btn btn-primary" runat="server" Text="Update Report" OnClick="btndeletereport_Click"/>
        </div>
        <div class="col-8"></div>
    </div>--%>


    
</asp:Content>
