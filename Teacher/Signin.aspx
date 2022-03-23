<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="Signin.aspx.cs" Inherits="Signin" UnobtrusiveValidationMode="None" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

        <div class="row">
            <div class="col-md-12">
               
                <div class="log-in-pop-left">
                        <h1>Hello...</h1>
                        <p> </p>

                    </div>


                    <div class="log-in-pop-right">

                        <h4>Login</h4>
                        <p>Don't have an account? Create your account. It's take less then a minutes</p>
                        <div class="s12">

                            <div class="form-group">
                                <label>Email/Mobile</label>
                                <asp:TextBox ID="txtUserId" runat="server" CssClass="form-control"></asp:TextBox>

                            </div>

                            <div class="form-group">
                                <label>Password</label>
                                <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" CssClass="form-control"></asp:TextBox>

                            </div>


                            <div>
                                <div class="input-field s4">
                                    <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="waves-effect waves-light log-in-btn" OnClick="btnLogin_Click" />

                                </div>
                            </div>
                            <div>
                                <div class="input-field s12">Not Registered yet| <a href="SignUp.aspx">Create a new account</a> </div>
                            </div>
                        </div>
                    </div>
                    
              
            </div>
        </div>
   
</asp:Content>

