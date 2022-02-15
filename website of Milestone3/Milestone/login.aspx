<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Milestone.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Please Log In<br />      
            UserName:<br />
            <asp:TextBox ID="id" runat="server"></asp:TextBox>
            <br />
            Password:<br />
            <asp:TextBox ID="password" type="password" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="Signin" runat="server" OnClick="Login" Text="Log In" />
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:LinkButton runat="server" OnClick="register">Don't have an account? Register here</asp:LinkButton>
        </div>
    </form>
</body>
</html>
