<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminIssueInstallPayment.aspx.cs" Inherits="Milestone.AdminIssueInstallPayment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Issue Install Payment
            <br />
            payment ID:<br />
            <asp:TextBox ID="paymentID" runat="server"></asp:TextBox>
            <br />
            Install Start Date:<br />
            <asp:TextBox ID="InstallStartDate" runat="server"></asp:TextBox>
            &nbsp;&nbsp;
            <asp:Button ID="addButton" runat="server" Text="Add" OnClick="addButton_Click" />
            <br />
            <asp:Button ID="backButton" runat="server" Text="Back" OnClick="backButton_Click" />       
        </div>
    </form>
</body>
</html>
