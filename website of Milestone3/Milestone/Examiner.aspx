<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Examiner.aspx.cs" Inherits="Milestone.Examiner" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Examiner :
            <br />
            <br />
            <asp:Button ID="editButton" runat="server" Text="Edit Personal Information" Width="240px" OnClick="editButton_Click" />
            <br />
            <br />
            <asp:Button ID="listButton" runat="server" Text="List Theses Info" Width="240px" OnClick="listButton_Click" />
            <br />
            <br />
            <asp:Button ID="commentButton" runat="server" Text="Add Comment for Defense" Width="240px" OnClick="commentButton_Click" />
            <br />
            <br />
            <asp:Button ID="gradeButton" runat="server" Text="Add Grade for Defense" OnClick="gradeButton_Click" Width="240px" />
            <br />
            <br />
            <asp:Button ID="searchForThesisButton" runat="server" Text="Search For Thesis" Width="240px" OnClick="searchForThesisButton_Click1" />
            <br />
            <br />
            <asp:Button ID="AddPhoneNumber" runat="server" Text="Add phone number" OnClick="AddPhoneNumber_Click" />
            <br />
            <br />
            <asp:Button ID="backButton" runat="server" Text="Back" OnClick="backButton_Click" />
        </div>
    </form>
</body>
</html>
