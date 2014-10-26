<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PreviousSchoolEducationWizardUC.ascx.cs"
    Inherits="PreviousSchoolEducationWizardUC" %>
<%@ Register Src="~/UserControls/PreviousSchoolEducationMarksWizardUC.ascx" TagName="PreviousSchoolEducationMarksWizardUC"
    TagPrefix="uc1" %>
<fieldset>
    <legend>
        <asp:CheckBox ID="chkSchoolDetailRequired" runat="server" Checked="true" Text="Please uncheck if details are not applicable" />
    </legend>
    <table id="tblPreviousEducation" runat="server" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td>
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
                    <asp:Label ID="lblClass" runat="server" Text="Class Name"></asp:Label>
                    <asp:DropDownList ID="ddlClass" runat="server" DataValueField="Class_Id" DataTextField="Class_Name">
                    </asp:DropDownList>
                </div>
                <div id="dvRegistrationNumber" class="dvColumnLeft">
                    <asp:Label ID="lblRegistrationNumber" runat="server" Text="Registration Number"></asp:Label>
                    <asp:TextBox ID="txtRegistrationNumber" runat="server"></asp:TextBox>
                </div>
                <div id="dvAcademic" class="dvColumnRight">
                    <asp:Label ID="lblAcademic" runat="server" Text="Session Name"></asp:Label>
                    <asp:DropDownList ID="ddlAcademic" runat="server" DataValueField="Session_Id" DataTextField="Session_Name">
                    </asp:DropDownList>
                </div>
                <div id="dvResultStatus" class="dvColumnLeft">
                    <asp:Label ID="lblResultStatus" runat="server" Text="Result Status"></asp:Label>
                    <asp:TextBox ID="txtResultStatus" runat="server"></asp:TextBox>
                </div>
                <div id="dvMarksPercent" class="dvColumnRight">
                    <asp:Label ID="lblMarksPercent" runat="server" Text="Marks Percent"></asp:Label>
                    <asp:TextBox ID="txtMarksPercent" runat="server"></asp:TextBox>
                </div>
                <%-- <div id="dvSupportedDocuments" class="dvColumnLeft">
                <asp:Label ID="lblSupportedDocuments" runat="server" Text="Supported Documents"></asp:Label>
                <asp:TextBox ID="txtSupportedDocuments" runat="server"></asp:TextBox>
            </div>--%>
            </td>
        </tr>
        <tr>
            <td align="left">
                <br />
                <asp:HiddenField ID="hfIsControlsLoaded" runat="server" Value="false" />
                <uc1:PreviousSchoolEducationMarksWizardUC ID="uxPreviousSchoolEducationMarksWizardUC"
                    runat="server" />
            </td>
        </tr>
    </table>
</fieldset>
