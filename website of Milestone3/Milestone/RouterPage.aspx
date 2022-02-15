<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RouterPage.aspx.cs" Inherits="Milestone.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <p>
            <asp:Button ID="View" runat="server" Text="View Your Profile" OnClick="View_Click" />
&nbsp;&nbsp;&nbsp;
            <asp:Button ID="List" runat="server" Text="View My Thesis" OnClick="List_Click" />
&nbsp;&nbsp;&nbsp;
            <asp:Button ID="CoursesAndGrades" runat="server" Text="View Courses and Grades" OnClick="CoursesAndGrades_Click" />
&nbsp;&nbsp;&nbsp;
            <asp:Button ID="PR" runat="server" Text="Add and Fill progress Reports" OnClick="PR_Click" />
&nbsp;&nbsp;&nbsp;
            <asp:Button ID="addpub" runat="server" Text="Add publication" OnClick="addpub_Click" />
        &nbsp;&nbsp;</p>
    </form>
</body>
</html>
