<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="FoodOrderManagement.Login" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>Login</title>
    <style type="text/css">
        body{
            background-color: floralwhite;
        }
        .auto-style1 {
            color: #0033CC;
        }
        #form1 {
            color: #0033CC;
        }
        .auto-style2 {
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">

        <h2 style="text-align: center; color: #0033CC">Admin Login</h2>

        <div class="auto-style2">
            <span class="auto-style1">Username:</span>
        <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>

        <br /><br />

        Password:
        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>

        <br /><br />

        <asp:Button ID="btnLogin" runat="server"
            Text="Login"
            OnClick="btnLogin_Click" BackColor="#0033CC" ForeColor="White" />

        <br /><br />

        <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>

        </div>

    </form>
</body>
</html>