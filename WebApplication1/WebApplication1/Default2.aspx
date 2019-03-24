<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default2.aspx.cs" Inherits="WebApplication1.Default2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 588px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style2">
                        <asp:Panel ID="pnlPanela" runat="server" Font-Names="Calibri" ForeColor="#990099" Width="584px">
                            <asp:TextBox ID="txtOperand1" runat="server"></asp:TextBox>
                            <asp:TextBox ID="txtOperand2" runat="server" OnTextChanged="txtOperand2_TextChanged"></asp:TextBox>
                            <asp:Label ID="lblRezultat" runat="server" Height="25px" Text="Резултат" Width="60px"></asp:Label>
                            <asp:Button ID="btnSoberi" runat="server" OnClick="btnSoberi_Click" Text="Button" />
                        </asp:Panel>
                    </td>
                    <td>

                        <asp:CheckBox ID="chbVidlivo" runat="server" OnCheckedChanged="chbVidlivo_CheckedChanged" Text="Видливо" />

                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">

                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
