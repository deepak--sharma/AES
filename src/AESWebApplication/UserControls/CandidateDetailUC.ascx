<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CandidateDetailUC.ascx.cs"
    Inherits="CandidateDetailUC" %>
<%@ Register Src="~/UserControls/AddressDetailUC.ascx" TagName="AddressDetailUC"
    TagPrefix="uc1" %>
<%@ Register Src="~/UserControls/GuardianDetailUC.ascx" TagName="GuardianDetailUC"
    TagPrefix="uc2" %>
<%@ Register Src="PreviousSchoolEducationDetailUC.ascx" TagName="PreviousSchoolEducationDetailUC"
    TagPrefix="uc4" %>
<%@ Register Src="SiblingDetailUC.ascx" TagName="SiblingDetailUC" TagPrefix="uc5" %>

<script src="../SCRIPT/Common.js" type="text/javascript"></script>

<script type="text/javascript">
    function ShowHideGuardianDetailPanel(sender) {

        var selectedValue;
        var listItem = sender.childNodes[0].childNodes[0].childNodes;
        for (var i = 0; i < listItem.length; i++) {
            if (listItem.item(i).childNodes[0].checked == true) {

                selectedValue = listItem.item(i).childNodes[0].value;
            }
        }

        //set guardian detail panel visibility
        if (selectedValue == 3) {
            $get('ctl00_MainContent_uxCandidateUC_rowGurdianDetail').style.display = 'block';
        }
        else {
            $get('ctl00_MainContent_uxCandidateUC_rowGurdianDetail').style.display = 'none';
        }
    }
</script>

<asp:HiddenField ID="hfCandidateId" runat="server" />

<table width="100%" cellpadding="0" cellspacing="0" border="1">
    <tr>
        <td>
            <asp:Label ID="lblFirstName" runat="server" Text="First Name" />
            <span style="color: Red">*</span>
        </td>
        <td>
            <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter First Name"
                ControlToValidate="txtFirstName" Display="Dynamic">
            </asp:RequiredFieldValidator>
        </td>
        <td>
            <asp:Label ID="lblMiddleName" runat="server" Text="Middle Name"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtMiddleName" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="lblLastName" runat="server" Text="Last Name"></asp:Label>
            <span style="color: Red">*</span>
        </td>
        <td>
            <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter Last Name"
                ControlToValidate="txtLastName" Display="Dynamic"></asp:RequiredFieldValidator>
        </td>
        <td>
            <asp:Label ID="lblDateOfBirth" runat="server" Text="Date Of Birth"></asp:Label>
            <span style="color: Red">*</span>
        </td>
        <td>
            <asp:TextBox ID="calenderDateOfBirth" runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="lblGender" runat="server" Text="Gender"></asp:Label>
            <span style="color: Red">*</span>
        </td>
        <td>
            <asp:DropDownList ID="ddlGender" runat="server" DataValueField="Metadata_Id" DataTextField="Metadata_Name">
            </asp:DropDownList>
        </td>
        <td>
            <asp:Label ID="lblCategory" runat="server" Text="Caste Category"></asp:Label>
            <span style="color: Red">*</span>
        </td>
        <td>
            <asp:DropDownList ID="ddlCategory" runat="server" DataValueField="Metadata_Id" DataTextField="Metadata_Name">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="lblReligion" runat="server" Text="Religion"></asp:Label>
            <span style="color: Red">*</span>
        </td>
        <td>
            <asp:DropDownList ID="ddlReligion" runat="server" DataValueField="Metadata_Id" DataTextField="Metadata_Name">
            </asp:DropDownList>
        </td>
        <td>
            <asp:Label ID="lblMaritial" runat="server" Text="Maritial Status"></asp:Label>
            <span style="color: Red">*</span>
        </td>
        <td>
            <asp:DropDownList ID="ddlMaritial" runat="server" DataValueField="Metadata_Id" DataTextField="Metadata_Name">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="lblIsStaffChild" runat="server" Text="Is Staff Child"></asp:Label>
        </td>
        <td>
            <asp:DropDownList ID="ddlIsStaffChild" runat="server">
                <asp:ListItem Value="True">True</asp:ListItem>
                <asp:ListItem Value="False">False</asp:ListItem>
            </asp:DropDownList>
        </td>
        <td colspan="2">
        </td>
    </tr>
    <tr>
        <td colspan="4">
            <fieldset>
                <legend>Current Address</legend>
                <uc1:AddressDetailUC ID="uxCurrentAddressUC" runat="server" />
            </fieldset>
        </td>
    </tr>
    <tr>
        <td colspan="4">
            <fieldset>
                <legend>Permanent Address</legend>
                <uc1:AddressDetailUC ID="uxPermanentAddressUC" runat="server" />
            </fieldset>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="lblPhoto" runat="server" Text="Photo"></asp:Label>
            <span style="color: Red">*</span>
        </td>
        <td colspan="3">
            <asp:FileUpload ID="fuPhoto" runat="server" />
        </td>
    </tr>
    <tr>
        <td colspan="4">
            <fieldset>
                <legend>Previous School Detail</legend>
                <uc4:PreviousSchoolEducationDetailUC ID="uxPreviousSchoolEducationDetailUC" runat="server" />
            </fieldset>
        </td>
    </tr>
    <tr>
        <td colspan="4">
            <fieldset>
                <legend>Father Detail</legend>
                <uc2:GuardianDetailUC ID="uxFatherUC" runat="server" />
            </fieldset>
        </td>
    </tr>
    <tr>
        <td colspan="4">
            <fieldset>
                <legend>Mother Detail</legend>
                <uc2:GuardianDetailUC ID="uxMotherUC" runat="server" />
            </fieldset>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label2" runat="server" Text="Is Guardian"></asp:Label>
        </td>
        <td colspan="3">
            <asp:RadioButtonList ID="rblGuardian" runat="server" AutoPostBack="false" RepeatDirection="Horizontal"
                onClick="ShowHideGuardianDetailPanel(this);">
                <asp:ListItem Text="Father" Value="1"></asp:ListItem>
                <asp:ListItem Text="Mother" Value="2"></asp:ListItem>
                <asp:ListItem Text="Other" Value="3" Selected="True"></asp:ListItem>
            </asp:RadioButtonList>
        </td>
    </tr>
    <tr id="rowGurdianDetail" runat="server">
        <td colspan="4">
            <fieldset>
                <legend>Guardian Detail</legend>
                <uc2:GuardianDetailUC ID="uxGuardianUC" runat="server" />
            </fieldset>
        </td>
    </tr>
    <tr id="Tr1" runat="server">
        <td colspan="4">
            <fieldset>
                <legend>Sibling Detail</legend>
                <uc5:SiblingDetailUC ID="uxSiblingDetailUC" runat="server" />
            </fieldset>
        </td>
    </tr>
</table>
