<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SiblingWizardUC.ascx.cs"
    Inherits="SiblingWizardUC" %>
<%@ Register Src="~/UserControls/Calender.ascx" TagName="CalenderUC" TagPrefix="uc1" %>
<asp:HiddenField ID="hfIsControlsLoaded" runat="server" Value="false" />
<table cellpadding="0" cellspacing="0" width="100%">
    <tr>
        <td style="padding-bottom: 10px;">
            <asp:CheckBox ID="chkSiblingRequired" Checked="true" Text="Please uncheck if details are not applicable"
                runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            <div id="dvFullName" class="dvColumnLeft">
                <asp:Label ID="lblName" runat="server" Text="Full Name"></asp:Label> <span style="color:Red">*</span>
                <asp:TextBox ID="txtFullName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvFullName" runat="server" ControlToValidate="txtFullName"
        Display="Static" ToolTip="Enter Full Name">
                                                        <span style="color:Red">*</span>
    </asp:RequiredFieldValidator>
            </div>
            <div id="dvDateOfBirth" class="dvColumnRight">
                <asp:Label ID="lblDateOfBirth" runat="server" Text="Date Of Birth"></asp:Label>  <span style="color:Red">*</span>
                <uc1:CalenderUC ID="txtDateOfBirth" runat="server" EnableRFValidator="true" RFVMessage="Enter Date Of Birth"></uc1:CalenderUC>
            </div>
            <div id="dvGender" class="dvColumnLeft">
                <asp:Label ID="lblGender" runat="server" Text="Gender"></asp:Label><span style="color:Red">*</span>
                <asp:DropDownList ID="ddlGender" runat="server" DataValueField="Metadata_Id" DataTextField="Metadata_Name">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvGender" runat="server" ControlToValidate="ddlGender"
                    InitialValue='<%# UIUtility.DEFAULT_DDL_VALUE %>' Display="Static" ToolTip="Select Gender">
                     <span style="color:Red">*</span>
                </asp:RequiredFieldValidator>
            </div>
            <div id="dvSchoolName" class="dvColumnLeft">
                <asp:Label ID="lblSchoolName" runat="server" Text="School Name"></asp:Label>
                <asp:TextBox ID="txtSchoolName" runat="server"></asp:TextBox>
            </div>
            <div id="dvSchoolAddress" class="dvColumnRight">
                <asp:Label ID="lblSchoolAddress" runat="server" Text="School Address"></asp:Label>
                <asp:TextBox ID="txtSchoolAddress" runat="server" TextMode="MultiLine"></asp:TextBox>
            </div>
            <div id="dvSchoolContacts" class="dvColumnLeft">
                <asp:Label ID="lblSchoolContacts" runat="server" Text="School Contacts"></asp:Label>
                <asp:TextBox ID="txtSchoolContacts" runat="server"></asp:TextBox>
            </div>
            <div id="dvClass" class="dvColumnRight">
                <asp:Label ID="lblClass" runat="server" Text="Class Name"></asp:Label> <%--<span style="color:Red">*</span>--%>
                <asp:DropDownList ID="ddlClass" runat="server" DataValueField="Class_Id" DataTextField="Class_Name">
                </asp:DropDownList>
                <%--<asp:RequiredFieldValidator ID="rfvClass" runat="server" ControlToValidate="ddlClass"
                    InitialValue='<%# UIUtility.DEFAULT_DDL_VALUE %>' Display="Static" ToolTip="Select Class Name">
                                            <span style="color:Red">*</span>
                </asp:RequiredFieldValidator>--%>
            </div>
            <div id="dvRegistrationNumber" class="dvColumnLeft">
                <asp:Label ID="lblRegistrationNumber" runat="server" Text="Registration Number"></asp:Label>
                <asp:TextBox ID="txtRegistrationNumber" runat="server"></asp:TextBox>
            </div>
            <div id="dvIsCandidate" class="dvColumnRight">
                <asp:Label ID="lblIsCandidate" runat="server" Text="Is Candidate"></asp:Label>
                <asp:RadioButtonList ID="rblIsCandidate" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Value="True">Yes</asp:ListItem>
                    <asp:ListItem Value="False">No</asp:ListItem>
                </asp:RadioButtonList>
            </div>
        </td>
    </tr>
</table>
