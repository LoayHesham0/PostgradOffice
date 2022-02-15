<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExaminerAddGrade.aspx.cs" Inherits="Milestone.ExaminerAddGrade" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Thesis Serial Number :
            <asp:TextBox ID="thesisSerialNumberBox" runat="server"></asp:TextBox>
            <br />
            <br />
            Defense Date :
            <asp:TextBox ID="defenseDateBox" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
            <br />
            <br />
            Grade :
            <asp:TextBox ID="gradeBox" runat="server"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="addButton" runat="server" Text="Add" OnClick="addButton_Click" />
            <br />
            <br />
            <asp:Button ID="backButton" runat="server" Text="Back" OnClick="backButton_Click" />
        </div>
    </form>
</body>
</html>
