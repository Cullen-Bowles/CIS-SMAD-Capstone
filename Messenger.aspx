<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Messenger.aspx.cs" Inherits="WebApplication4.Messanger" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <h1>Message Center</h1>
    <div class="row mt-3">
        <div class="col-8">
            <asp:Repeater id="dsMessages" runat="server">
                <HeaderTemplate>
                    <table class="table table-striped">
                        <tr>
                            <td>From</td>
                            <td>Message</td>
                            <td>Date Sent</td>
                            <td>&nbsp;</td>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("CreatedByUsername")%></td>
                        <td><%# Eval("Body")%></td>
                        <td><%# Eval("Created")%></td>
                        <td> <asp:Button ID="btnRead" CssClass="btn btn-info" runat="server" CommandArgument='<%# Eval("ID") %>' CommandName="MarkOneRead" Text="Mark Read" OnClick="btnRead_OnClick"/></td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
            <asp:Button ID="btnAllRead" CssClass="btn btn-info" runat="server" CommandArgument='0' CommandName="MarkAllRead" Text="Mark All Read" OnClick="btnRead_OnClick"/>
        </div>
        <div class="col-4">
            <div class="card">
                <div class="card-header">
                    Send Message
                </div>
                <div class="card-body">
                    <div class="row">
                        <div class="col-12">
                            To: <asp:DropDownList ID="ddlsharedusers" CssClass="form-control" runat="server" OnSelectedIndexChanged="ddlsharedusers_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-12">
                            Message: <asp:TextBox ID="txtmessage" CssClass="form-control" runat="server" TextMode="MultiLine" Rows="5" Columns="50"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-12">
                            <asp:Button ID="btnsend" CssClass="btn btn-success mt-2" runat="server" Text="Send Message" OnClick="btnsend_Click"/>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-12"></div>
                    </div>
                    <div class="row">
                        <div class="col-12"></div>
                    </div>
                    <div class="row">
                        <div class="col-12"></div>
                    </div>
                    <div class="row">
                        <div class="col-12"></div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
