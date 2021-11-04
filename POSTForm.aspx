<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="POSTForm.aspx.cs" Inherits="InClassWebApp.POSTForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblAnalysis" runat="server" Text="Choose Analysis:"></asp:Label>
            &nbsp;&nbsp;
            <asp:DropDownList ID="ddlExtracts" runat="server"></asp:DropDownList>
            <br /><br />
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
            <asp:Label ID="lblTitle" runat="server" Text="Story Title:"></asp:Label>
            &nbsp;&nbsp;
            <asp:TextBox ID="txtTitle" runat="server" Width="200"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblURL" runat="server" Text="Story Source (URL):"></asp:Label>
            &nbsp;&nbsp;
            <asp:TextBox ID="txtURL" runat="server" Width="300"></asp:TextBox>
            <br /><br />
            <asp:Label ID="lblStoryBody" runat="server" Text="Body of Story Text:"></asp:Label>
            <br />
            <asp:TextBox ID="txtStory" runat="server" TextMode="MultiLine" Width="600" Height="200"></asp:TextBox>
            <br />
            <asp:Button ID="btnSubmit" runat="server" Text="Send Story to SA for Analysis ->" OnClick="btnSubmit_Click" />
            <br />
            <br />
            <asp:Label ID="lblPostResponseMessage" runat="server" Text="" ForeColor="Red" Font-Bold="true" Font-Size="X-Large"></asp:Label>
        </div>
    </form>
</body>
</html>
