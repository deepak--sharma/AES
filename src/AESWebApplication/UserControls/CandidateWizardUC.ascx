<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CandidateWizardUC.ascx.cs"
    Inherits="CandidateWizardUC" %>
<%@ Register Src="~/UserControls/AddressDetailUC.ascx" TagName="AddressDetailUC"
    TagPrefix="uc1" %>
<%@ Register Src="~/UserControls/Calender.ascx" TagName="CalenderUC" TagPrefix="uc1" %>
<%@ Register Src="~/UserControls/ImagePreviewUC.ascx" TagName="ImagePreviewUC" TagPrefix="uc2" %>
<asp:HiddenField ID="hfIsControlsLoaded" runat="server" Value="false" />
<div style="background-color: #399bc6; color: White; height: 20px; vertical-align: middle;
    margin-bottom: 15px;">
    <h4>
        Candidate Personal Information</h4>
</div>
<div class="dvColumnLeft">
    <asp:Label ID="lblFirstName" runat="server" Text="First Name" />        <span style="color:Red">*</span>
    <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvFirstName" runat="server" ControlToValidate="txtFirstName"
        Display="Static" ToolTip="Enter First Name">
                                                        <span style="color:Red">*</span>
    </asp:RequiredFieldValidator>
</div>
<div class="dvColumnRight">
    <asp:Label ID="lblMiddleName" runat="server" Text="Middle Name"></asp:Label>
    <asp:TextBox ID="txtMiddleName" runat="server"></asp:TextBox>
</div>
<div class="dvColumnLeft">
    <asp:Label ID="lblLastName" runat="server" Text="Last Name"></asp:Label>        <span style="color:Red">*</span>
    <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvLastName" runat="server" ControlToValidate="txtLastName"
        Display="Static" ToolTip="Enter Last Name">
                                                        <span style="color:Red">*</span>
    </asp:RequiredFieldValidator>
</div>
<div class="dvColumnRight">
    <asp:Label ID="lblDateOfBirth" runat="server" Text="Date Of Birth"></asp:Label>         <span style="color:Red">*</span>
    <uc1:CalenderUC ID="calenderDateOfBirth" runat="server" EnableRFValidator="true" RFVMessage="Enter Date Of Birth" />
</div>
<div class="dvColumnLeft">
    <asp:Label ID="lblGender" runat="server" Text="Gender"></asp:Label>   <span style="color: Red">*</span>
    <asp:DropDownList ID="ddlGender" runat="server" DataValueField="Metadata_Id" DataTextField="Metadata_Name">
    </asp:DropDownList>
     <asp:RequiredFieldValidator ID="rfvGender" runat="server" ControlToValidate="ddlGender"
        InitialValue='<%# UIUtility.DEFAULT_DDL_VALUE %>' Display="Static" ToolTip="Select Gender">
                                            <span style="color:Red">*</span>
    </asp:RequiredFieldValidator>
</div>
<div class="dvColumnRight">
    <asp:Label ID="lblCategory" runat="server" Text="Caste Category"></asp:Label>
    <span style="color: Red">*</span>
    <asp:DropDownList ID="ddlCategory" runat="server" DataValueField="Metadata_Id" DataTextField="Metadata_Name">
    </asp:DropDownList>
    <asp:RequiredFieldValidator ID="rfvCategory" runat="server" ControlToValidate="ddlCategory"
        InitialValue='<%# UIUtility.DEFAULT_DDL_VALUE %>' Display="Static" ToolTip="Select Caste Category Name">
                                            <span style="color:Red">*</span>
    </asp:RequiredFieldValidator>
</div>
<div class="dvColumnLeft">
    <asp:Label ID="lblReligion" runat="server" Text="Religion"></asp:Label>
    <span style="color: Red">*</span>
    <asp:DropDownList ID="ddlReligion" runat="server" DataValueField="Metadata_Id" DataTextField="Metadata_Name">
    </asp:DropDownList>
    <asp:RequiredFieldValidator ID="rfvReligion" runat="server" ControlToValidate="ddlReligion"
        InitialValue='<%# UIUtility.DEFAULT_DDL_VALUE %>' Display="Static" ToolTip="Select Religion Name">
        <span style="color:Red">*</span>
    </asp:RequiredFieldValidator>
</div>
<div class="dvColumnRight">
    <asp:Label ID="lblMaritialStatus" runat="server" Text="Maritial Status"></asp:Label><span
        style="color: Red">*</span>
    <asp:DropDownList ID="ddlMaritialStatus" runat="server" DataValueField="Metadata_Id"
        DataTextField="Metadata_Name">
    </asp:DropDownList>
    <asp:RequiredFieldValidator ID="rfvMaritialStatus" runat="server" ControlToValidate="ddlMaritialStatus"
        InitialValue='<%# UIUtility.DEFAULT_DDL_VALUE %>' Display="Static" ToolTip="Select Maritial Status">
        <span style="color:Red">*</span>
    </asp:RequiredFieldValidator>
</div>
<div class="dvColumnLeft">
    <asp:Label ID="lblIsStaffChild" runat="server" Text="Staff Child"></asp:Label>
    <asp:RadioButtonList ID="rblIsStaffChild" runat="server" RepeatDirection="Horizontal">
        <asp:ListItem Value="True">Yes</asp:ListItem>
        <asp:ListItem Value="False" Selected="True">No</asp:ListItem>
    </asp:RadioButtonList>
</div>
<div class="dvColumnRight">
    <asp:Label ID="lblPhoto" runat="server" Text="Photo" Style="text-align: right; margin-right: 50px;"></asp:Label>
    <uc2:ImagePreviewUC ID="FileUpload1" runat="server" />
</div>
<div style="float: left;">
    <div style="background-color: #399bc6; color: White; height: 20px; vertical-align: middle;
        margin-bottom: 15px;">
        <h4>
            Candidate Current Address</h4>
    </div>
    <uc1:AddressDetailUC ID="uxCurrentAddressUC" runat="server" />
</div>
