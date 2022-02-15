<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Milestone.Register" %>

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
            <asp:Button ID="supervisor" runat="server" Text="supervisor" OnClick="supervisor_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="examiner" runat="server" Text="examiner" OnClick="examiner_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="student" runat="server" Text="student" OnClick="student_Click" />
        </div>
    </form>
</body>
</html>
