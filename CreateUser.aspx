<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="CreateUser.aspx.cs" Inherits="WebApplication4.WebForm4" %>

<asp:Content CssClass="formatCon" ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2><%: Title %></h2>
    <p>Please fill out the form to create a new user.</p>

            <div class="card">
                <div class="card-header">
                    Create User
                </div>
                <div class="card-body">
                        <form>
                            <div class="form-group row">
                                <asp:Label ID="lblfirstname" runat="server" class="col-3" Text="First Name: "></asp:Label>
                                <div class="col-sm-9">
                                    <asp:TextBox ID="txtfirstname" class="form-control" runat="server"></asp:TextBox>
                                    <asp:Label ID="ExistingUser" runat="server" Text="" ForeColor="Red"></asp:Label>
                                </div>
                            </div>
                            <div class="form-group row">
                                <asp:Label ID="lbllastname" runat="server" class="col-3" Text="Last Name: " ></asp:Label>
                                <div class="col-sm-9">
                                    <asp:TextBox ID="txtlastname" class="form-control" runat="server"></asp:TextBox>
                                    <%--<input type="password" class="form-control" id="inputPassword" placeholder="Password">--%>
                                </div>
                            </div>
                            
                            <div class="form-group row">
                                <asp:Label ID="lblusername" runat="server" class="col-3" Text="Username: "></asp:Label>
                                <div class="col-sm-9">
                                    <asp:TextBox ID="txtusername" class="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group row">
                                <asp:Label ID="lblpassword" runat="server" class="col-3" Text="Current Password: " ></asp:Label>
                                <div class="col-sm-9">
                                    <asp:TextBox ID="txtpassword" class="form-control" runat="server" type="password"></asp:TextBox>
                                </div>
                            </div>
                            
                            <div class="form-group row">
                                <asp:Label ID="lblconpass" runat="server" class="col-3" Text="Confirm New Password: "></asp:Label>
                                <div class="col-sm-9">
                                    <asp:TextBox ID="txtconpassword" class="form-control" runat="server" type="password"></asp:TextBox>
                                </div>
                            </div>
                            
                            <div class="form-group row">
                                <asp:Label ID="lblemail" runat="server" class="col-3" Text="Email: "></asp:Label>
                                <div class="col-sm-9">
                                    <asp:TextBox ID="txtemail" class="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group row">
                                <asp:Label ID="lblorganization" runat="server" class="col-3" Text="Organization: " ></asp:Label>
                                <div class="col-sm-9">
                                    <asp:TextBox ID="txtorganization" class="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            
                                    
                            <div class="form-group row">
                                <asp:Label ID="lblreason" runat="server" class="col-3" Text="Reason: " ></asp:Label>
                                <div class="col-sm-9">
                                    <asp:TextBox ID="txtreason" class="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            
                            <div class="form-group row">
                                <div >
                                    <asp:Button ID="btncreateuser" runat="server" class="btn btn-primary" Text="Create User" OnClick="btncreateuser_Click" />
                                    <asp:Button ID="btnclear" runat="server" Text="Clear Info" class="btn btn-secondary" OnClick="btnclear_Click" />
                                </div>       
                            </div>
                            

                        </form>
                </div>
            </div>


</asp:Content>
