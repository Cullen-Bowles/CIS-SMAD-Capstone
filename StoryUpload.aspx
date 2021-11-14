<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="StoryUpload.aspx.cs" Inherits="WebApplication4.StoryUpload" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Upload Stories</h1>
        <asp:Label ID="submitted" runat="server" Text="" ForeColor="White"></asp:Label>
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
                        <span>&nbsp;</span>
                    </div>
                </div>
        <div class="row">
            <div class="col-3">
                <asp:Label ID="StoryText" runat="server" Text="Story Text:"></asp:Label>
                <asp:FileUpload ID="fileUploadText" runat="server"/>
                <span>&nbsp;</span>
                <span>&nbsp;</span>
                <asp:Button ID="btnUploadFile" runat="server" Text="Upload File" OnClick="btnUploadFile_Click" CausesValidation="false"/><br/>
            </div>
            <div class="col-9">
                <asp:TextBox ID="StoryTextEntry" runat="server" Rows="10" Columns="100" AutoPostBack="false" CssClass="form-control" TextMode="MultiLine" Wrap="True"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="StoryTextEntry" ForeColor="Red" Text="Story Text Cannot be blank" BorderStyle="Solid" BorderWidth="2px"></asp:RequiredFieldValidator>
            </div>
        </div>
        
    <div class="row">
        <asp:Button ID="Confirm" runat="server" Text="Save" CssClass="btn btn-primary" OnClick="Confirm_Click" />
        <asp:Button ID="Clear" runat="server" Text="Clear" CssClass="btn btn-secondary"  OnClick="Clear_Click" CausesValidation="False" />
    </div>
</asp:Content>
