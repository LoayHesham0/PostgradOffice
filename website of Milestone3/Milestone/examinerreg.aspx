<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="examinerreg.aspx.cs" Inherits="Milestone.examiner" %>

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
            Fieldofwork:<br />
            <asp:TextBox ID="fieldOfWork" runat="server"></asp:TextBox>
            <br />
            IsNational:<br />
            <asp:TextBox ID="isNational" runat="server"></asp:TextBox>
            <br />
            Email:<br />
            <asp:TextBox ID="email" runat="server"></asp:TextBox>
            <br />
            Password:<br />
            <asp:textbox ID="password" type="password" runat="server" ></asp:textbox>
            <br />
            <asp:Button ID="examinerRegister" runat="server" Text="Register" OnClick="examinerRegister_Click" />           
        </div>
    </form>
</body>
</html>
