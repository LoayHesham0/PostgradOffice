<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddFillProg.aspx.cs" Inherits="Milestone.WebForm6" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Back" runat="server" Text="Back" OnClick="Back_Click" style="width: 55px" />
            <br />
            <asp:Label ID="Label3" runat="server" Text="Add a new Progress Report: "></asp:Label>
            <br />
            <asp:Label ID="Label1" runat="server" Text="Thesis Serial Number: "></asp:Label>
&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="Serial" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label2" runat="server" Text="Progress Report Date (YYYY-MM-DD):  "></asp:Label>
&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="Date" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Save" OnClick="Button1_Click" />
            <br />
            <br />
            <asp:Label ID="Label6" runat="server" Text="Fill an Existing Progress Report: "></asp:Label>
            <br />
            <asp:Label ID="Label4" runat="server" Text="Thesis Serial Number: "></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="Serialtoo" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label5" runat="server" Text="Progress Report Number: "></asp:Label>
&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="PRNO" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label7" runat="server" Text="State: "></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="State" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label8" runat="server" Text="Description: "></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="Desc"  MaxLength ="200" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button2" runat="server" Text="Save" OnClick="Button2_Click" />
        </div>
    </form>
</body>
</html>
