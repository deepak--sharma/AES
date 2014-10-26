<%@ Control Language="C#" AutoEventWireup="true" CodeFile="HomepageMenu.ascx.cs" Inherits="HomepageMenu" %>
<style type="text/css">
    .styleMenu
    {
        width: 100%;
        border: 1px solid #CC99FF;
        background-color: #FFCCFF;
    }
     .removeHyperLink
    {
        text-decoration: none;
        font-family: Arial Baltic;
        font-size: 12px;
       /*font-weight: bold*/
        cursor: pointer;
    }
</style>
<table cellpadding="2" cellspacing ="2" border="0">
    <tr>
        <td>
            <asp:HyperLink ID="first" runat="server" NavigateUrl="Default.aspx" CssClass ="removeHyperLink" >Fisrt</asp:HyperLink>
        </td>
    </tr>
    <tr>
        <td>
            <asp:HyperLink ID="Second" runat="server" NavigateUrl="#" CssClass ="removeHyperLink">Second</asp:HyperLink>
        </td>
    </tr>
    <tr>
        <td>
            <asp:HyperLink ID="Third" runat="server" NavigateUrl="#" CssClass ="removeHyperLink">Third</asp:HyperLink>
        </td>
    </tr>
    <tr>
        <td>
            <asp:HyperLink ID="Fourth" runat="server" NavigateUrl="#" CssClass ="removeHyperLink">Fourth</asp:HyperLink>
        </td>
    </tr>
    <tr>
        <td>
            <asp:HyperLink ID="Fiveth" runat="server" NavigateUrl="#" CssClass ="removeHyperLink">Fifth</asp:HyperLink>
        </td>
    </tr>
</table>
