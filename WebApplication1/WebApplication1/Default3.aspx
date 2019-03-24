<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default3.aspx.cs" Inherits="WebApplication1.Default3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="txtLozinka" runat="server" TextMode="Password"></asp:TextBox>
            <asp:TextBox ID="txtPoraka" runat="server" ReadOnly="True" Rows="5" TextMode="MultiLine" AutoPostBack="true"></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="btnProveri" runat="server" OnClick="btnProveri_Click" Text="Button Check" Width="128px" />
            <asp:Button ID="btnPrvaStrana" runat="server" Enabled="False" Text="Button" OnClick="btnPrvaStrana_Click" PostBackUrl="~/Default.aspx" />
        </div>
    </form>
</body>
</html>
