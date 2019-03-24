<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblVreme1" runat="server" Font-Names="Arial" Font-Size="Medium" ForeColor="Navy" Text="Контрола за приказ на време"></asp:Label>
            <br />
        </div>
        <div>
        <asp:Label ID="lblVreme2" runat="server" Font-Names="Arial" Font-Size="Medium" ForeColor="Navy" Text="Label"></asp:Label>
            <br />
            <asp:Button ID="Button1" runat="server" Font-Names="Arial" Font-Size="Medium" ForeColor="Navy" OnClick="Button1_Click" Text="Button" />
        </div>
        <div>
            <asp:HyperLink ID="hlSledno" runat="server" NavigateUrl="~/Default2.aspx">hlSledno</asp:HyperLink>
        </div>
    </form>
</body>
</html>
