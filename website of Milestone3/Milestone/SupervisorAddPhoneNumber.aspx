<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SupervisorAddPhoneNumber.aspx.cs" Inherits="Milestone.SupervisorAddPhoneNumber" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            ID:
            <br />
            <asp:TextBox ID="id" runat="server"></asp:TextBox>
            <br />
            Phone Number: <br />
            <asp:TextBox ID="phone_number" runat="server"></asp:TextBox>
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="addButton" runat="server" Text="Add" OnClick="addButton_Click" />
            <br />
            <asp:Button ID="backButton" runat="server" Text="Back" OnClick="backButton_Click" style="height: 26px" />       
        </div>
    </form>
</body>
</html>
