<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExaminerPersonalInfo.aspx.cs" Inherits="Milestone.ExaminerPersonalInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            Name :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="nameBox" runat="server"></asp:TextBox>
            <br />
            <br />
            Field Of Work :
            <asp:TextBox ID="fieldOfWorkBox" runat="server"></asp:TextBox>
&nbsp;&nbsp;
            <asp:Button ID="editButton" runat="server" Text="Edit Info" Width="152px" OnClick="editButton_Click" />
            <br />
            <br />
            <asp:Button ID="backButton" runat="server" Text="Back" OnClick="backButton_Click" />
        </div>
    </form>
</body>
</html>
