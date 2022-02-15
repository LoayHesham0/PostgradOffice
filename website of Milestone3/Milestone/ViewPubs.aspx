<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewPubs.aspx.cs" Inherits="Milestone.ViewPubs" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="height: 178px">
    <form id="form1" runat="server">
        <div>
            <br />
            Student ID:
            <asp:TextBox ID="StudentIDBox" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="View" OnClick="ViewButton" />
            <br />
        </div>
        <br />
        <asp:Button ID="Button2" runat="server" OnClick="BackButton" Text="Back" />
    </form>
</body>
</html>
