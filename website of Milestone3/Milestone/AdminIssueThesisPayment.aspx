<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminIssueThesisPayment.aspx.cs" Inherits="Milestone.AdminIssueThesisPayment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Issue Thesis Payment<br />
            Thesis Serial Number:<br />
            <asp:TextBox ID="ThesisSerialNo" runat="server"></asp:TextBox>
            <br />
            Amount:<br />
            <asp:TextBox ID="amount" runat="server"></asp:TextBox>
            <br />
            Number Of Installments:<br />
            <asp:TextBox ID="noOfInstallments" runat="server"></asp:TextBox>
            <br />
            Fund Percentage:<br />
            <asp:TextBox ID="fundPercentage" runat="server"></asp:TextBox>
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="addButton" runat="server" Text="Add" OnClick="addButton_Click" />
            <br />
            <asp:Button ID="backButton" runat="server" Text="Back" OnClick="backButton_Click" />       
        </div>
    </form>
</body>
</html>
