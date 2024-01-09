<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="Gamma1.register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="r_styles.css" />
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Poppins&display=swap" />
</head>


<body>
    <div class="container0">
        <header>
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
        <div class="login-register-box">
            <div class="container">

                <div class="login form">
                    <header>Register Here!</header>
                    <form id="form1" action="#" runat="server">
                        <asp:TextBox ID="r_email" placeholder="Enter your email" runat="server" />
                        <asp:TextBox ID="r_password" TextMode="Password" placeholder="Enter your password" runat="server" />
                        <asp:TextBox ID="r_cpassword" TextMode="Password" placeholder="Confirm your password" runat="server" />
                        <asp:DropDownList ID="ddlSecurityQuestion" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlSecurityQuestion_SelectedIndexChanged">
                            <asp:ListItem Text="Select a Security Question" Value=""></asp:ListItem>
                            <asp:ListItem Text="What is your pet's name?" Value="PetName"></asp:ListItem>
                            <asp:ListItem Text="What is your mother's maiden name?" Value="MaidenName"></asp:ListItem>
                            <asp:ListItem Text="What was the make of your first car?" Value="FirstCar"></asp:ListItem>
                            <asp:ListItem Text="Custom Question" Value="Custom"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:TextBox ID="txtCustomQuestion" runat="server" placeholder="Enter Custom Question" Visible="false" />
                        <asp:TextBox ID="txtSecurityAnswer" runat="server" placeholder="Enter Answer" />

                        <asp:Label ID="Error" runat="server" Text="Label"></asp:Label>
                        <asp:Button ID="registerbtn" CssClass="button" Text="Register" runat="server" OnClick="registerbtn_Click" />
                    </form>
                    <div class="signup">
                        <span class="signup">Already an user?
                            <a href="javascript:void(0);" onclick="redirectToLogin()">Login</a>
                        </span>
                    </div>
                </div>

            </div>
            <!-- Your login/register form goes here -->
        </div>
    </div>
    <script src="script.js"></script>
</body>
</html>
