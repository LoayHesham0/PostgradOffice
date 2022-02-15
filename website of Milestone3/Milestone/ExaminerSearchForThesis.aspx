<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExaminerSearchForThesis.aspx.cs" Inherits="Milestone.ExaminerSearchForThesis" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            KeyWord :
            <asp:TextBox ID="keywordBox" runat="server"></asp:TextBox>
&nbsp;
            <asp:Button ID="searchButton" runat="server" Text="Seach" OnClick="searchButton_Click" />
            <br />
            <br />
            <asp:Button ID="backButton" runat="server" Text="Back" OnClick="backButton_Click" />
        </div>
    </form>
</body>
</html>
