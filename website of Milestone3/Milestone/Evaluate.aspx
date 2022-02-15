<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Evaluate.aspx.cs" Inherits="Milestone.Evaluate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Evaluation:<br />
            <br />
            supervisor ID:
            <br />
            <br />
            <asp:TextBox ID="TextBox1" runat="server" ></asp:TextBox>
            <br />
            <br />
            thesis Serial Number:<br />
            <br />
            <asp:TextBox ID="TextBox2" runat="server" ></asp:TextBox>
            <br />
            <br />
            progressReportNo:<br />
            <br />
            <asp:TextBox ID="TextBox3" runat="server" ></asp:TextBox>
            <br />
            <br />
            evaluation:<br />
            <br />
            <asp:TextBox ID="TextBox4" runat="server" ></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="evaluate" OnClick="EvaluateButton" />
            <br />
            <br />
            <asp:Button ID="Button2" runat="server" Text="Back" OnClick="BackButton" />
        </div>
    </form>
</body>
</html>
