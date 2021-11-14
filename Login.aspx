<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" MasterPageFile="~/Site1.Master" Inherits="WebApplication4.WebForm1" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2><%: Title %></h2>
    <p>Please enter your username and password to log in.</p>
    <div class="col-lg-12">
        <div class="row">
            <div class="card">
                <div class="card-header">
                    Log in
                </div>
                <div class="card-body">
                    <form>
                        <div class="form-group">
                            <label for="username">Username</label>
                            <asp:TextBox ID="txtusername" runat="server" class="form-control" placeholder="Enter username" ></asp:TextBox>
                            
                            <asp:Label ID="LoginFailure" runat="server" Text=""></asp:Label>
                        </div>
                        <div class="form-group">
                            <label for="password">Password</label>
                            <asp:TextBox ID="txtpassword" runat="server" type="password"  class="form-control" placeholder="Password"></asp:TextBox>
                           
                        </div>
                        <div class="form-check">
                            <%--<input type="checkbox" class="form-check-input" id="exampleCheck1">
                            <label class="form-check-label" for="exampleCheck1">Remember me</label>
                            <br />--%>
                            Don't have an account? <a href="CreateUser.aspx" class="text-info">Register here</a>
                        </div>
                        
                        <asp:Button ID="btnlogin" runat="server" Text="Log In" class="btn btn-primary mt-2" OnClick="btnlogin_Click" />
                    </form>
                </div>
            </div>
        </div>
    </div>
</asp:Content>


