<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admin.aspx.cs" Inherits="Milestone.admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Admin:<br />
            <br />
            <asp:Button ID="listsupname" runat="server" Text=" List all supervisors in the system" OnClick="listsupname_Click" />
            &nbsp;<br />
            <br />
            <asp:Button ID="Listthesesandcount" runat="server" Text="List all Theses in the system and the count of the on going theses" OnClick="Listthesesandcount_Click" />
            <br />
            <br />
            <asp:Button ID="issuethesispayment" runat="server"  Text="Issue a Thesis Payment" OnClick="issuethesispayment_Click" />
            <br />
            <br />
            <asp:Button ID="AdminIssueInstallPayment" runat="server" Text="Issue installments" OnClick="AdminIssueInstallPayment_Click" />
            <br />
            <br />
            <asp:Button ID="AdminUpdateExtension" runat="server" Text="Update Thesis Extensions" OnClick="AdminUpdateExtension_Click" />
            <br />
            <br />
            <asp:Button ID="AddPhoneNumber" runat="server" Text="Add phone number" OnClick="AddPhoneNumber_Click" />
            <br />
            <br />
            <asp:Button ID="back" runat="server" Text="back" OnClick="back_Click" />  
        </div>
    </form>
</body>
</html>
