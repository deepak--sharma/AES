<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MenuControl.ascx.cs" Inherits="MenuControl" %>
<style type="text/css">
    .styleMenu
    {
        width: 100%;
        border: 1px solid #CC99FF;
        background-color: #FFCCFF;
        text-decoration: none;
    }
    .removeHyperLink
    {
        text-decoration: none;
        font-family: Arial Baltic;
        font-size: 15px;
        font-weight: bold;
        cursor: pointer;
    }
</style>
<table cellpadding="2" cellspacing="0" class="styleMenu">
    <tr>
        <td>
            <asp:HyperLink ID="HyperLink1" runat="server" CssClass="removeHyperLink" NavigateUrl ="~/AboutUs.aspx" >About us</asp:HyperLink>
        </td>
        <td>
            <asp:HyperLink ID="HyperLink2" runat="server" CssClass="removeHyperLink">Registration</asp:HyperLink>
        </td>
        <td>
            <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="#" CssClass="removeHyperLink">Scheme</asp:HyperLink>
        </td>
        <td>
            <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="#" CssClass="removeHyperLink">AddTwo</asp:HyperLink>
        </td>
       
        <td>
            <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="#" CssClass="removeHyperLink">Home</asp:HyperLink>
        </td>
        <td>
            <asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="#" CssClass="removeHyperLink">Help</asp:HyperLink>
        </td>
    </tr>
</table>
