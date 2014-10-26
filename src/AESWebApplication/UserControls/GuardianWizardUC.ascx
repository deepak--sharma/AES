<%@ Control Language="C#" AutoEventWireup="true" CodeFile="GuardianWizardUC.ascx.cs"
    Inherits="GuardianWizardUC" %>
<%@ Register Src="~/UserControls/AddressDetailUC.ascx" TagName="AddressDetailUC"
    TagPrefix="uc1" %>
<%@ Register Src="~/UserControls/Calender.ascx" TagName="CalenderUC" TagPrefix="uc1" %>
<asp:HiddenField ID="hfIsControlsLoaded" runat="server" Value="false" />
<div id="dvFullName" class="dvColumnLeft">
    <asp:Label ID="lblName" runat="server" Text="Full Name"></asp:Label>
    <span style="color: Red">*</span>
    <asp:TextBox ID="txtFullName" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvFullName" runat="server" ControlToValidate="txtFullName"
        Display="Static" ToolTip="Enter Full Name"><span style="color:Red">*</span>
    </asp:RequiredFieldValidator>
</div>
<div id="dvDateOfBirth" class="dvColumnRight">
    <asp:Label ID="lblDateOfBirth" runat="server" Text="Date Of Birth"></asp:Label>
    <span style="color: Red">*</span>
    <uc1:CalenderUC ID="txtDateOfBirth" runat="server" EnableRFValidator="true" RFVMessage="Enter Date Of Birth">
    </uc1:CalenderUC>
</div>
<div id="dvContactNo" class="dvColumnLeft">
    <asp:Label ID="lblContactNo" runat="server" Text="Contact No"></asp:Label>
    <asp:TextBox ID="txtContactNo" runat="server"></asp:TextBox>
</div>
<div id="dvDesignation" class="dvColumnRight">
    <asp:Label ID="lblDesignation" runat="server" Text="Designation"></asp:Label>
    <asp:TextBox ID="txtDesignation" runat="server"></asp:TextBox>
</div>
<div id="dvQualification" class="dvColumnLeft">
    <asp:Label ID="lblQualification" runat="server" Text="Qualification"></asp:Label>
    <asp:TextBox ID="txtQualification" runat="server"></asp:TextBox>
</div>
<div id="dvNationality" class="dvColumnRight">
    <asp:Label ID="lblNationality" runat="server" Text="Nationality"></asp:Label>
    <asp:DropDownList ID="ddlNationality" runat="server" DataValueField="Metadata_Id"
        DataTextField="Metadata_Name">
    </asp:DropDownList>
    <asp:RequiredFieldValidator ID="rfvNationality" runat="server" ControlToValidate="ddlNationality"
        InitialValue='<%# UIUtility.DEFAULT_DDL_VALUE %>' Display="Static" ToolTip="Select Nationality">
        <span style="color:Red">*</span>
    </asp:RequiredFieldValidator>
</div>
<div id="dvRelation" class="dvColumnLeft">
    <asp:Label ID="lblRelation" runat="server" Text="Relation"></asp:Label>
    <asp:TextBox ID="txtRelation" runat="server"></asp:TextBox>
</div>
<div id="dvIsStaff" class="dvColumnRight">
    <asp:Label ID="lblIsStaff" runat="server" Text="Is Staff"></asp:Label>
    <asp:RadioButtonList ID="rblIsStaff" runat="server" RepeatDirection="Horizontal">
        <asp:ListItem Value="True">Yes</asp:ListItem>
        <asp:ListItem Value="False" Selected="True">No</asp:ListItem>
    </asp:RadioButtonList>
</div>
<div id="dvWasStudent" class="dvColumnLeft">
    <asp:Label ID="lblWasStudent" runat="server" Text="Was Student"></asp:Label>
    <asp:RadioButtonList ID="rblWasStudent" runat="server" RepeatDirection="Horizontal">
        <asp:ListItem Value="True">Yes</asp:ListItem>
        <asp:ListItem Value="False" Selected="True">No</asp:ListItem>
    </asp:RadioButtonList>
</div>
<div id="dvOfficeDetail" class="dvColumnRight">
    <asp:Label ID="lblOfficeDetail" runat="server" Text="Office Detail"></asp:Label>
    <asp:TextBox ID="txtOfficeDetail" runat="server" TextMode="MultiLine"></asp:TextBox>
</div>
