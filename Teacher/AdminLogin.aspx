<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdminLogin.aspx.cs" Inherits="AdminLogin" %>

<!DOCTYPE html>

<html >
<head runat="server">
   <title>Welcome Admin Login - TRMS-</title>
    <!-- META TAGS -->
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="shortcut icon" href="images/favicon.ico" type="image/x-icon" />
    <!-- GOOGLE FONT -->
    <link href="https://fonts.googleapis.com/css?family=Open+Sans:300,400,600,700%7CJosefin+Sans:600,700" rel="stylesheet" />
    <!-- FONTAWESOME ICONS -->
    <link rel="stylesheet" href="css/font-awesome.min.css" />
    <!-- ALL CSS FILES -->
    <link href="css/materialize.css" rel="stylesheet" />
    <link href="css/bootstrap.css" rel="stylesheet" />
    <link href="css/style.css" rel="stylesheet" />
    <link href="css/style-mob.css" rel="stylesheet" />
    <style>
         input:not([type]), input[type=text], input[type=password], input[type=email], input[type=url], input[type=time], input[type=date], input[type=datetime], input[type=datetime-local], input[type=tel], input[type=number], textarea.materialize-textarea 
        {
            border: none;
            border: 1px solid #9e9e9e;
            border-radius: 5px;
            outline: none;
            height: 3rem;
            width: 95% !important;
            font-size: 1.5rem;
            margin: 0 0 0px 0;
            padding-left: 8px;
            box-shadow: none;
            box-sizing: content-box;
            transition: all 0.3s;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <section>
		<div>
            <div class="ad-log-in">
                <div class="ad-log-in-logo">
                    <a href="AdminLogin.aspx">
                        <img src="images/logo.png" alt="" style="width:100%" /></a>
                </div>
                <hr />
                <div class="ad-log-in-con">

                    <h4>Admin Login</h4>
                    <hr />
                    <div class="s12">
                        
                            <div class="form-group">
                                <label class="left">User name</label>

                                <asp:TextBox ID="txtUserName" runat="server" CssClass="form-control" required="required"></asp:TextBox>
                               

                            </div>
                         <div class="form-group">
                                <label class="left">Password</label>

                                <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" required="required" TextMode="Password"></asp:TextBox>
                               

                            </div>
                        
                       
                   
                        
                       
                            <div class="form-group">
                                <asp:Button ID="btnAdminLogin" runat="server" Text="Login" CssClass="waves-button-input btn " OnClick="btnAdminLogin_Click" Width="100%" />
                            </div>
                        <hr />
                        
                        <div style="display:none">
                            <div class="input-field s12"><a href="#">Forgot password</a>  </div>
                        </div>

                        <div>
                            <div class="input-field s12"><a href="index.aspx" class="pull-right text-danger">Back to Home</a>  </div>
                        </div>
                    </div>
                </div>

            </div>
        </div>
   </section>

    <!--Import jQuery before materialize.js-->
    <script src="js/main.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script src="js/materialize.min.js"></script>
    <script src="js/custom.js"></script>
    </form>
</body>
</html>
