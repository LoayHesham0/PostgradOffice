<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="studentreg.aspx.cs" Inherits="Milestone.student" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="back" runat="server" Text="back" OnClick="back_Click"  />
            <br />
            <br />
            First Name:<br />
            <asp:TextBox ID="first_name" runat="server"></asp:TextBox>
            <br />
            Last Name:<br />
            <asp:TextBox ID="last_name" runat="server"></asp:TextBox>
            <br />
            Faculty:<br />
            <asp:TextBox ID="faculty" runat="server"></asp:TextBox>
            <br />
            address:<br />
            <asp:TextBox ID="address" runat="server"></asp:TextBox>
            <br />
            gucian:<br />
            <asp:TextBox ID="gucian" runat="server"></asp:TextBox>
            <br />
            Email:<br />
            <asp:TextBox ID="email" runat="server"></asp:TextBox>
            <br />
            Password:<br />
            <asp:textbox ID="password" type="password" runat="server" ></asp:textbox>
            <br />
            <asp:Button ID="studentRegister" runat="server" Text="Register" OnClick="studentRegister_Click" />           
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;           
        </div>
    </form>
</body>
</html>
