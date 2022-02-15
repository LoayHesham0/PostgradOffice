<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addlinkpub.aspx.cs" Inherits="Milestone.WebForm7" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #form1 {
            height: 398px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Button3" runat="server" Text="Back" OnClick="Button3_Click" />
            <br />
            <asp:Label ID="Label6" runat="server" Text="Add a Publication:"></asp:Label>
            <br />
            <asp:Label ID="Label1" runat="server" Text="Title: "></asp:Label>
            <asp:TextBox ID="Title" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label2" runat="server" Text="Publication Date (YYYY-MM-DD): "></asp:Label>
            <asp:TextBox ID="PubDate" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label3" runat="server" Text="Host: "></asp:Label>
            <asp:TextBox ID="Host" MaxLength="50" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label4" runat="server" Text="Place: "></asp:Label>
            <asp:TextBox ID="Place" MaxLength="50" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label5" runat="server" Text="Accepted? (1 if yes, 0 if no): "></asp:Label>
            <asp:TextBox ID="Accepted" MaxLength="1" runat="server"></asp:TextBox>
        </div>
        <br />
        <asp:Button ID="Button1" runat="server" Text="Add" OnClick="Button1_Click1" />
        <br />
        <br />
        <asp:Label ID="Label7" runat="server" Text="Link a Publication to your thesis:  "></asp:Label>
        <br />
        <asp:Label ID="Label8" runat="server" Text="Publication ID"></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="Pubid" runat="server" ></asp:TextBox>
        <br />
        <asp:Label ID="Label9" runat="server" Text="Thesis Serial Number:"></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="Tno" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="Button2" runat="server" Text="Link" OnClick="Button2_Click" />
    </form>
</body>
</html>
