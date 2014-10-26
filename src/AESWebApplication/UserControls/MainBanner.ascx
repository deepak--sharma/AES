<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MainBanner.ascx.cs" Inherits="MainBanner" %>
<style type="text/css">
    .styleBanner
    {
        width: 100%;
        border-style: solid;
        border-width: 1px;
        background-color: #FFFFCC;
        height :20%;
    }
</style>
<table cellspacing="0" class="styleBanner">
    <tr>
        <td valign="top">
            <asp:Image ID="ImgLogo" runat="server" ImageUrl="~/Images/lor20a21.jpg" ToolTip="Company Logo" Width="200px" Height ="90px"/>
        </td>
        <td>
            <asp:AdRotator ID="adRotImage" runat="server" AdvertisementFile="~/Resource/Advertisment.xml"
               Target ="_self"/>
        </td>
    </tr>
</table>
