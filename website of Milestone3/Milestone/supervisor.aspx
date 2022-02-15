<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="supervisor.aspx.cs" Inherits="Milestone.supervisor1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="height: 465px">
            Supervisor:<br />
            <br />
            <asp:Button ID="Button1" runat="server" Text=" List all my students's names and years spent in the thesis" Height="30px" Width="540px" OnClick="ListMyButton" />
            <br />
            <br />
            <asp:Button ID="Button2" runat="server" Text="View all publications of a student" Width="541px" OnClick="ViewPubsButton" />
            <br />
            <br />
            <asp:Button ID="Button3" runat="server" Text="Add a defense for a thesis and add examiner(s) for the defense" Width="543px" OnClick="AddButton" />
            <br />
            <br />
            <asp:Button ID="Button4" runat="server" Text=" Evaluate a progress report of a student, and give evaluation value 0 to 3" Width="541px" OnClick="EvaluateButton" />
            <br />
            <br />
            <asp:Button ID="Button5" runat="server" Text="Cancel a Thesis if the evaluation of the last progress report is zero" Width="543px" OnClick="CancelButton" />
            <br />
            <br />
            <asp:Button ID="AddPhoneNumber" runat="server" Text="Add phone number" OnClick="AddPhoneNumber_Click" />
            <br />
            <br />
            <asp:Button ID="Button6" runat="server" OnClick="BackButton" Text="Back" />
        </div>
    </form>
</body>
</html>
