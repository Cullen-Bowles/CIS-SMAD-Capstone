<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="StoryEntry.aspx.cs" Inherits="WebApplication4.StoryEntry" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
<%--    <div class="card">
        <div class="card-body">
            This is some text within a card body.
        </div>
    </div>--%>
    
    <div class="card">
        <div class="card-body">
            <div class="storyFormat">
        <h1 >Submit Stories</h1>
        <asp:Label ID="submitted" runat="server" Text="" ></asp:Label>
        <br />
        <br />
                
                <div class="row">
                    <div class="col-3">
                        <asp:Label ID="StoryTitle" runat="server" Text="Story Title:" ></asp:Label>
                    </div>
                    <div class="col-9">
                        <asp:TextBox ID="StoryTitleEntry" CssClass="form-control" runat="server" AutoPostBack="true"></asp:TextBox>
                        <asp:Label ID="ExistingStory" runat="server" Text="" ForeColor="White"></asp:Label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="StoryTitleEntry" ForeColor="Red" Text="Story Title Cannot be blank" BorderStyle="Solid" BorderWidth="2px"></asp:RequiredFieldValidator>
                    </div>
                </div>

       
                <div class="row">
                    <div class="col-3">
                        <asp:Label ID="StoryDate" runat="server" Text="Story Submission Date:"></asp:Label>
                    </div>
                    <div class="col-9">
                        <asp:TextBox ID="StoryDateEntry" runat="server" CssClass="form-control"  AutoPostBack="true" TextMode="Date"></asp:TextBox>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="StoryDateEntry" ForeColor="Red" Text="Story Date Cannot be blank " BorderStyle="Solid" BorderWidth="2px"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="CompareValidator" ControlToValidate="StoryDateEntry" Text="Story Date must be in mm/dd/yyyy Format" Operator="DataTypeCheck" Type="Date" ForeColor="DarkRed" BorderStyle="Solid" BorderWidth="2px"></asp:CompareValidator>
                    </div>
                </div>


        <br />
        <asp:Label ID="StorySource" runat="server" Text="Story Source:" ForeColor="White"></asp:Label>
        <asp:TextBox ID="StorySourceEntry" runat="server" Width="412px" AutoPostBack="true"></asp:TextBox>
        <br />
        <%-- Validators make sure text box is not empty--%>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="StorySourceEntry" ForeColor="Red" Text="Story Source Cannot be blank" BorderStyle="Solid" BorderWidth="2px"></asp:RequiredFieldValidator>
        <br />
        <br />
        <asp:Label ID="StoryText" runat="server" Text="Story Text:" ></asp:Label>
        <%-- Validators make sure text box is not empty--%>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="StoryTextEntry" ForeColor="Red" Text="Story Text Cannot be blank" BorderStyle="Solid" BorderWidth="2px"></asp:RequiredFieldValidator>
        <br />
        <asp:TextBox ID="StoryTextEntry" runat="server"  Rows="10" Columns="100" AutoPostBack="true" CssClass="form-control" TextMode="MultiLine" Wrap="True"></asp:TextBox>

        <br />

        <%-- <textarea id="StoryTextEntry" cols="20" rows="2" AutoPostBack="true"></textarea>--%>
        <br />
        <%--<asp:Button ID="Populate" runat="server" Text="Populate" Height="25px" Width="70px" OnClick="Populate_Click" CausesValidation="False" />--%>
        <%--<asp:Button ID="Save" runat="server" Text="Save" Height="25px" Width="70px" OnClick="Save_Click" />--%>
        <asp:Button ID="Confirm" runat="server" Text="Save"  CssClass="btn btn-primary" OnClick="Confirm_Click" />
        <asp:Button ID="Clear" runat="server" Text="Clear"  CssClass="btn btn-secondary" OnClick="Clear_Click" CausesValidation="False" />
    </div>
        </div>
    </div>

    
</asp:Content>
