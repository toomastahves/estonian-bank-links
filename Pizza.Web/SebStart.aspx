<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SebStart.aspx.cs" Inherits="Pizza.Web.SebStart" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table style="width: 100%;">
                <tr>
                    <td>VK_SERVICE -
                        <asp:Label ID="VK_SERVICE" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>VK_VERSION -
                        <asp:Label ID="VK_VERSION" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>VK_SND_ID -
                        <asp:Label ID="VK_SND_ID" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>VK_STAMP -
                        <asp:Label ID="VK_STAMP" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>VK_AMOUNT -
                        <asp:Label ID="VK_AMOUNT" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>VK_CURR -
                        <asp:Label ID="VK_CURR" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>VK_ACC -
                        <asp:Label ID="VK_ACC" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>VK_NAME -
                        <asp:Label ID="VK_NAME" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>VK_REF -
                        <asp:Label ID="VK_REF" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>VK_MSG -
                        <asp:Label ID="VK_MSG" runat="server"></asp:Label>
                    </td>
                </tr>

                <tr>
                    <td>VK_RETURN -
                        <asp:Label ID="VK_RETURN" runat="server"></asp:Label>
                    </td>
                </tr>

                <tr>
                    <td>VK_CANCEL -
                        <asp:Label ID="VK_CANCEL" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>VK_DATETIME -
                        <asp:Label ID="VK_DATETIME" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>VK_MAC -
                        <asp:Label ID="VK_MAC" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>VK_LANG -
                        <asp:Label ID="VK_LANG" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>VK_ENCODING -
                        <asp:Label ID="VK_ENCODING" runat="server"></asp:Label>
                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:Button ID="Button1" runat="server" Text="Pay with SEB" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
