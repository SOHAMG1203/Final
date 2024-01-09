<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Gamma1.index" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="styles.css" />
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Poppins&display=swap" />

</head>
<body>
    <div class="container0">
        <header class="site-header">
            <div class="profile-icon">
                <img src="profile_icon.jpg" alt="Profile" id="profileIcon" height="40px" width="30px" />
            </div>

            <!-- Navigation links -->
            <nav>
                <ul>
                    <li><a href="index.aspx">Home</a></li>
                    <li><a href="about.html">About Us</a></li>
                    <li><a href="services.aspx">Services</a></li>
                    <li><a href="contact.html">Contact Us</a></li>
                    <li><a href="feedback.aspx">Feedback</a></li>

                </ul>
            </nav>
        </header>

        <div class="text-above-login">
            <p>Welcome to Wedding Solutions</p>
        </div>

        <!-- Home Picture -->
        <div class="home-picture">
            <!-- Your home picture goes here -->
        </div>

        <!-- Login/Register Box -->
        <div class="login-register-box" id="loginRegisterBox">
            <div class="container">

                <div class="login form">
                    <header>Sign In</header>
                    <form id="form1" action="#" runat="server">
                        <asp:TextBox ID="l_email" placeholder="Enter your email" runat="server" />
                        <asp:TextBox TextMode="Password" ID="l_password" placeholder="Enter your password" runat="server" />
                        <asp:Label ID="Error" runat="server" Text=""></asp:Label>
                        <br />
                        <a href="#">Forgot password?</a>
                        <div class="radio-group">
                            <asp:Label ID="Label1" runat="server" Text="User"></asp:Label>
                            <asp:RadioButton ID="RadioButtonUser" runat="server" GroupName="UserType" CssClass="custom-radio"></asp:RadioButton>
                            <asp:Label ID="Label2" runat="server" Text="Admin"></asp:Label>
                            <asp:RadioButton ID="RadioButtonAdmin" runat="server" GroupName="UserType" CssClass="custom-radio"></asp:RadioButton>
                        </div>
                        <asp:Button ID="loginbtn" CssClass="button" Text="Login" runat="server" OnClick="loginbtn_Click" />
                    </form>
                    <div class="signup">
                        <span class="signup">Don't have an account?
                            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/register.aspx">Signup</asp:HyperLink>
                        </span>
                    </div>
                </div>

            </div>
            <!-- Your login/register form goes here -->
        </div>
    </div>
    <script src="script.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
</body>
</html>
