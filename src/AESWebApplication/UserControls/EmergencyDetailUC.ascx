<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EmergencyDetailUC.ascx.cs"
    Inherits="EmergencyDetailUC" %>
<%--<fieldset><legend>Emergency Detail</legend>--%>
<asp:HiddenField ID="hfEmergencyDetailId" runat="server"/>
<div id="dvContactPerson" class="dvColumnLeft">
    <asp:Label ID="lblContactPerson" runat="server" Text="Contact Person"></asp:Label>
    <asp:TextBox ID="txtContactPerson" runat="server"></asp:TextBox>
</div>
<div id="dvRelation" class="dvColumnRight">
    <asp:Label ID="lblRelation" runat="server" Text="Relation" ></asp:Label>
    <asp:TextBox ID="txtRelation" runat="server"></asp:TextBox>
</div>
<div id="dvContactNumber" class="dvColumnLeft">
    <asp:Label ID="lblContactNumber" runat="server" Text="Contact Number"></asp:Label>
    <asp:TextBox ID="txtContactNumber" runat="server"></asp:TextBox>
</div>
<div id="dvAddress" class="dvColumnRight">
    <asp:Label ID="lblAddress" runat="server" Text="Address" ></asp:Label>
    <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
</div>
<div id="dvEmailId" class="dvColumnLeft">
    <asp:Label ID="lblEmailId" runat="server" Text="Email Id"></asp:Label>
    <asp:TextBox ID="txtEmailId" runat="server"></asp:TextBox>
</div>
<%--</fieldset>--%>
