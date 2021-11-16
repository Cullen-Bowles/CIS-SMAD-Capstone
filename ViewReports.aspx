<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ViewReports.aspx.cs" Inherits="WebApplication4.ViewReports" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-6">
            <div class="card">
                <%--<form id="form1" runat="server">--%>
                <div class="card-body">
                    <h2>View Your Report</h2>
                    <br />
                    <br />
                    <asp:Label ID="lblemail" runat="server" Text="User Email:"></asp:Label>
                    &nbsp;&nbsp;
                    <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server" Width="200" ReadOnly="true"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Label ID="lblSelectAnalysis" runat="server" Text="SelectAnalysis"></asp:Label>
                    <asp:DropDownList ID="ddlSAList" CssClass="form-control" runat="server"></asp:DropDownList>
                    <asp:Label ID="lblRequests" runat="server" Text="Choose Request:"></asp:Label>
                    <asp:DropDownList CssClass="form-control" ID="ddlRequest" runat="server">
                        <asp:ListItem Text="Get Title" value="gettitle"></asp:ListItem>
                        <asp:ListItem Text="Get Source" value="getsource"></asp:ListItem>
                        <asp:ListItem Text="Get People" value="getpeople"></asp:ListItem>
                        <asp:ListItem Text="Get Places" value="getplaces"></asp:ListItem>
                        <asp:ListItem Text="getvisinteractionschord" value="getvisinteractionschord"></asp:ListItem>
                        <asp:ListItem Text="getvisnarrativeweb" value="getvisnarrativeweb"></asp:ListItem>
                        <asp:ListItem Text="getviswordcloud-subjects" value="getviswordcloud-subjects"></asp:ListItem>
                        <asp:ListItem Text="getviswordcloud-places" value="getviswordcloud-places"></asp:ListItem>
                        <asp:ListItem Text="getviswordcloud-people" value="getviswordcloud-people"></asp:ListItem>
                        <asp:ListItem Text="getviswordcloud-groups" value="getviswordcloud-groups"></asp:ListItem>
                        <asp:ListItem Text="Get Sentence Details" value="getsentencedetails"></asp:ListItem>
                        <asp:ListItem Text="Show Dashboard" value="showdashboard"></asp:ListItem>
                        <asp:ListItem Text="Show Formatted Dashboard" value="showbootstrapdashboard"></asp:ListItem>

                    </asp:DropDownList>
                    <br />
                    <asp:Button ID="btnMakeRequest" CssClass="btn btn-success" runat="server" Text="Make Analysis Request" OnClick="btnMakeRequest_Click" />
                    <br />
                    <asp:TextBox ID="txtDisplay" runat="server"  CssClass="form-control" Rows="15" Height="200" Width="400" TextMode="MultiLine"></asp:TextBox>
                    <%--<input id="CallButton" name="CallButton" class="btn btn-warning" type="button" value="TEST" />--%>
                    
                </div>
                
                <%--</form>--%>
            </div>
        </div>
        <div class="col-6">
            <div class="row">
                <div runat="server" id="displayViz"></div>
                
                
                <%--<div class="col">
                    <h2>Edit Your Report</h2>
                    <br />
                    <br />
                    <asp:Label ID="Label1" runat="server" Text="Choose Edit:"></asp:Label>
                    <asp:DropDownList CssClass="form-control" ID="DropDownList1" runat="server">
                        <asp:ListItem Text="Set Title" value="settitle"></asp:ListItem>
                        <asp:ListItem Text="Set Source" value="setsource"></asp:ListItem>
                        <asp:ListItem Text="Set Tokens Detail" value="settokensdetail"></asp:ListItem>
                        <asp:ListItem Text="Set Sendtence Details" value="setsentencedetails"></asp:ListItem>
                        
                        

                    </asp:DropDownList>
                </div>--%>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-12">
            <div class="col-12 dashboard">
                <asp:Literal runat="server" id="DashboardHome"></asp:Literal>
            </div>
        </div>
    </div>
    
    <%--<br />
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
    <br />--%>
    

    
</asp:Content>
