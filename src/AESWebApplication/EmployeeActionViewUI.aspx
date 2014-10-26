<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EmployeeActionViewUI.aspx.cs"
    Inherits="EmployeeActionViewUI" MasterPageFile="~/MasterPage/MainMasterPage.master" %>

<%@ Register Src="UserControls/EmployeeAdministrativeDetailUC.ascx" TagName="EmployeeAdministrativeDetailUC"
    TagPrefix="uc1" %>
<%@ Register Src="UserControls/EmployeeFinancialDetailUC.ascx" TagName="EmployeeFinancialDetailUC"
    TagPrefix="uc1" %>
<%@ Register Src="UserControls/AddressDetailUC.ascx" TagName="AddressDetailUC" TagPrefix="uc1" %>
<%@ Register Src="UserControls/EmergencyDetailUC.ascx" TagName="EmergencyDetailUC"
    TagPrefix="uc1" %>
<%@ Register Src="UserControls/EmployeeJoiningDetailUC.ascx" TagName="EmployeeJoiningDetailUC"
    TagPrefix="uc1" %>
<%@ Register Src="UserControls/ReportingDetailUC.ascx" TagName="ReportingDetailUC"
    TagPrefix="uc1" %>
<%@ Register Src="UserControls/SkillDetailUC.ascx" TagName="SkillDetailUC" TagPrefix="uc1" %>
<%@ Register Src="UserControls/KnownLanguageUC.ascx" TagName="KnownLanguageUC" TagPrefix="uc1" %>
<%@ Register Src="UserControls/ImmigrationDetailUC.ascx" TagName="ImmigrationDetailUC"
    TagPrefix="uc1" %>
<%@ Register Src="UserControls/LicenceDetailUC.ascx" TagName="LicenceDetailUC" TagPrefix="uc1" %>
<%@ Register Src="UserControls/EmployeePreviousOrganisationDetailUC.ascx" TagName="EmployeePreviousOrganisationDetailUC"
    TagPrefix="uc1" %>
<%@ Register Src="UserControls/EmployeeFamilyDetailUC.ascx" TagName="EmployeeFamilyDetailUC"
    TagPrefix="uc1" %>
<%@ Register Src="UserControls/EmployeeEducationalDetailUC.ascx" TagName="EmployeeEducationalDetailUC"
    TagPrefix="uc1" %>
<%@ Register Src="UserControls/EmployeeMedicalDetailUC.ascx" TagName="EmployeeMedicalDetailUC"
    TagPrefix="uc1" %>
<%@ Register Src="~/UserControls/Calender.ascx" TagName="CalenderUC" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="Server">
    <title>EmployeeDetail Page</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:HiddenField ID="hdnfLinkName" runat="server" Value="AD" />
    <div id="maindiv">
        <div class="listmenu">
            <ul>
                <li>
                    <asp:LinkButton ID="linkbtnBI" runat="server" Text="Basic Information" OnClick="linkButton_Click"
                        CommandArgument="BI"></asp:LinkButton></li>
                <li>
                    <asp:LinkButton ID="LinkButton1" runat="server" Text="Administrator Detail" OnClick="linkButton_Click"
                        CommandArgument="AD"></asp:LinkButton></li>
                <li>
                    <asp:LinkButton ID="LinkButton2" runat="server" Text="Finance Detail" OnClick="linkButton_Click"
                        CommandArgument="FD"></asp:LinkButton></li>
                <li>
                    <asp:LinkButton ID="LinkButton3" runat="server" Text="Contact Information" OnClick="linkButton_Click"
                        CommandArgument="CI"></asp:LinkButton></li>
                <li>
                    <asp:LinkButton ID="LinkButton4" runat="server" Text="Joining Detail" OnClick="linkButton_Click"
                        CommandArgument="JD"></asp:LinkButton></li>
                <li>
                    <asp:LinkButton ID="LinkButton10" runat="server" Text="Reporting Detail" OnClick="linkButton_Click"
                        CommandArgument="RD"></asp:LinkButton></li>
                <li>
                    <asp:LinkButton ID="LinkButton6" runat="server" Text="Previous Organisation" OnClick="linkButton_Click"
                        CommandArgument="PO"></asp:LinkButton></li>
                <li>
                    <asp:LinkButton ID="LinkButton8" runat="server" Text="Medical Detail" OnClick="linkButton_Click"
                        CommandArgument="MD"></asp:LinkButton></li>
                <li>
                    <asp:LinkButton ID="LinkButton5" runat="server" Text="Educational Detail" OnClick="linkButton_Click"
                        CommandArgument="ED"></asp:LinkButton></li>
                <li>
                    <asp:LinkButton ID="LinkButton9" runat="server" Text="Others Detail" OnClick="linkButton_Click"
                        CommandArgument="OD"></asp:LinkButton></li>
            </ul>
        </div>
        <div id="divContaintRightwithMenu">
            <div id="UserForm">
                <asp:Panel ID="ads" runat="server" Style="vertical-align: middle; text-align: left;
                    float: right; border: 0px solid black;">
                    <asp:HyperLink ID="lnkBack" Text="Back" runat="server" NavigateUrl="EmployeeDetailUI.aspx" />
                </asp:Panel>
                <asp:Panel ID="divRightPage" runat="server" Style="width: 100%;">
                    <table cellpadding="0" cellspacing="0" width="98%">
                        <tr>
                            <td>
                                <div id="divBasicDetail" runat="server">
                                    <div class="pageline" style="border-bottom: 2px solid #000000; margin-bottom: 15px;">
                                        <h3>
                                            Basic Information</h3>
                                    </div>
                                    <div id="dvEmployeeCode" class="dvColumnLeft">
                                        <asp:Label ID="lblEmployeeCode" runat="server" Text="Employee Code"></asp:Label>
                                        <asp:TextBox ID="txtEmployeeCode" runat="server"></asp:TextBox>
                                    </div>
                                    <div id="dvFirstName" class="dvColumnRight">
                                        <asp:Label ID="lblFirstName" runat="server" Text="First Name"></asp:Label>
                                        <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
                                    </div>
                                    <div id="dvMiddleName" class="dvColumnLeft">
                                        <asp:Label ID="lblMiddleName" runat="server" Text="Middle Name"></asp:Label>
                                        <asp:TextBox ID="txtMiddleName" runat="server"></asp:TextBox>
                                    </div>
                                    <div id="dvLastName" class="dvColumnRight">
                                        <asp:Label ID="lblLastName" runat="server" Text="Last Name"></asp:Label>
                                        <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
                                    </div>
                                    <div id="dvFatherName" class="dvColumnLeft">
                                        <asp:Label ID="lblFatherName" runat="server" Text="Father Name"></asp:Label>
                                        <asp:TextBox ID="txtFatherName" runat="server"></asp:TextBox>
                                    </div>
                                    <div id="dvGender" class="dvColumnRight">
                                        <asp:Label ID="lblGender" runat="server" Text="Gender"></asp:Label>
                                        <asp:DropDownList ID="ddlGender" runat="server" DataValueField="Metadata_Id" DataTextField="Metadata_Name">
                                        </asp:DropDownList>
                                    </div>
                                    <div id="dvDateOfBirth" class="dvColumnLeft">
                                        <asp:Label ID="lblDateOfBirth" runat="server" Text="Date Of Birth"></asp:Label>
                                        <uc1:CalenderUC ID="txtDateOfBirth" runat="server" />
                                    </div>
                                    <div id="dvMaritial" class="dvColumnRight">
                                        <asp:Label ID="lblMaritial" runat="server" Text="Maritial Status"></asp:Label>
                                        <asp:DropDownList ID="ddlMaritial" runat="server" DataValueField="Metadata_Id" DataTextField="Metadata_Name">
                                        </asp:DropDownList>
                                    </div>
                                    <div id="dvMarriageDate" class="dvColumnRight">
                                        <asp:Label ID="lblMarriageDate" runat="server" Text="Marriage Date"></asp:Label>
                                        <uc1:CalenderUC ID="txtMarriageDate" runat="server" />
                                    </div>
                                    <div id="dvPhoto" class="dvColumnLeft">
                                        <asp:Label ID="lblPhoto" runat="server" Text="Photo"></asp:Label>
                                        <asp:TextBox ID="txtPhoto" runat="server"></asp:TextBox>
                                    </div>
                                    <div id="dvReligion" class="dvColumnLeft">
                                        <asp:Label ID="lblReligion" runat="server" Text="Religion"></asp:Label>
                                        <asp:DropDownList ID="ddlReligion" runat="server" DataValueField="Metadata_Id" DataTextField="Metadata_Name">
                                        </asp:DropDownList>
                                    </div>
                                    <div id="dvCastecategory" class="dvColumnRight">
                                        <asp:Label ID="lblCastecategory" runat="server" Text="Castecategory"></asp:Label>
                                        <asp:DropDownList ID="ddlCastecategory" runat="server" DataValueField="Metadata_Id"
                                            DataTextField="Metadata_Name">
                                        </asp:DropDownList>
                                    </div>
                                    <div id="dvNationality" class="dvColumnLeft">
                                        <asp:Label ID="lblNationality" runat="server" Text="Nationality"></asp:Label>
                                        <asp:DropDownList ID="ddlNationality" runat="server" DataValueField="Metadata_Id"
                                            DataTextField="Metadata_Name">
                                        </asp:DropDownList>
                                    </div>
                                    <div id="dvPersonalEmailId" class="dvColumnRight">
                                        <asp:Label ID="lblPersonalEmailId" runat="server" Text="Personal Email Id"></asp:Label>
                                        <asp:TextBox ID="txtPersonalEmailId" runat="server"></asp:TextBox>
                                    </div>
                                    <div id="dvOfficeEmailId" class="dvColumnLeft">
                                        <asp:Label ID="lblOfficeEmailId" runat="server" Text="Office Email Id"></asp:Label>
                                        <asp:TextBox ID="txtOfficeEmailId" runat="server"></asp:TextBox>
                                    </div>
                                    <div id="dvIsFresher" class="dvColumnRight">
                                        <asp:Label ID="lblIsFresher" runat="server" Text="Is Fresher"></asp:Label>
                                        <asp:DropDownList ID="ddlIsFresher" runat="server">
                                            <asp:ListItem Value="-Select-">-Select-</asp:ListItem>
                                            <asp:ListItem Value="True">True</asp:ListItem>
                                            <asp:ListItem Value="False">False</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div id="dvCompaign" class="dvColumnLeft">
                                        <asp:Label ID="lblCompaign" runat="server" Text="Compaign"></asp:Label>
                                        <asp:TextBox ID="txtCompaign" runat="server"></asp:TextBox>
                                    </div>
                                    <div id="dvSsnNo" class="dvColumnRight">
                                        <asp:Label ID="lblSsnNo" runat="server" Text="Ssn No"></asp:Label>
                                        <asp:TextBox ID="txtSsnNo" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div id="divAdministrativeDetail" runat="server">
                                    <div style="border-bottom: 2px solid #000000; margin-bottom: 15px;">
                                        <h3>
                                            Administrative Detail</h3>
                                    </div>
                                    <uc1:EmployeeAdministrativeDetailUC ID="uxEmployeeAdministrativeDetailUC" runat="server"
                                        Visible="true" />
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div id="divEmployeeFinancialDetail" runat="server">
                                    <div style="border-bottom: 2px solid #000000; margin-bottom: 15px;">
                                        <h3>
                                            Financial Detail</h3>
                                    </div>
                                    <uc1:EmployeeFinancialDetailUC ID="uxEmployeeFinancialDetailUC" runat="server" />
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div id="divContactInformation" runat="server">
                                    <div style="border-bottom: 2px solid #000000; margin-bottom: 15px;">
                                        <h3>
                                            Contact Information</h3>
                                    </div>
                                    <div>
                                        <div style="font-weight: bold; margin-bottom: 6px;">
                                            Current Address</div>
                                        <uc1:AddressDetailUC ID="uxCurrentAddressUC" runat="server" />
                                    </div>
                                    <div style="float: left; margin-top: 10px;">
                                        <div style="font-weight: bold; margin-bottom: 6px;">
                                            Permanent Address</div>
                                        <uc1:AddressDetailUC ID="uxPermanentAddressUC" runat="server" />
                                    </div>
                                    <div style="float: left; margin-top: 10px;">
                                        <div style="font-weight: bold; margin-bottom: 6px;">
                                            Primary Emergency Detail</div>
                                        <uc1:EmergencyDetailUC ID="uxPrimaryEmergencyUC" runat="server" />
                                    </div>
                                    <div style="float: left; margin-top: 10px;">
                                        <div style="font-weight: bold; margin-bottom: 6px;">
                                            Secondry Emergency Detail</div>
                                        <uc1:EmergencyDetailUC ID="uxSecondryEmergencyUC" runat="server" />
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div id="divJoiningDetail" runat="server">
                                    <div style="border-bottom: 2px solid #000000; margin-bottom: 15px;">
                                        <h3>
                                            Joining Detail</h3>
                                    </div>
                                    <uc1:EmployeeJoiningDetailUC ID="uxEmployeeJoiningDetailUC" runat="server" />
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div id="divReportingDetail" runat="server">
                                    <div style="border-bottom: 2px solid #000000; margin-bottom: 15px;">
                                        <h3>
                                            Reporting Detail</h3>
                                    </div>
                                    <uc1:ReportingDetailUC ID="uxReportingDetailUC" runat="server" />
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div id="divSkillDetail" runat="server">
                                    <div style="border-bottom: 2px solid #000000; margin-bottom: 15px;">
                                        <h3>
                                            Skill Detail</h3>
                                    </div>
                                    <div style="font-weight: bold; margin-bottom: 15px;">
                                        Skill Detail</div>
                                    <uc1:SkillDetailUC ID="uxSkillDetailUC" runat="server" />
                                    <div style="font-weight: bold; margin-bottom: 15px; margin-top: 15px;">
                                        Known Language</div>
                                    <uc1:KnownLanguageUC ID="uxKnownLanguageUC" runat="server" />
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div id="divMedicalDetail" runat="server">
                                    <div style="border-bottom: 2px solid #000000; margin-bottom: 15px;">
                                        <h3>
                                            Medical Detail</h3>
                                    </div>
                                    <uc1:EmployeeMedicalDetailUC ID="uxEmployeeMedicalDetailUC" runat="server" />
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div id="divEducationalDetail" runat="server">
                                    <div style="border-bottom: 2px solid #000000; margin-bottom: 15px;">
                                        <h3>
                                            Educational Detail</h3>
                                    </div>
                                    <uc1:EmployeeEducationalDetailUC ID="uxEmployeeEducationalDetailUC" runat="server" />
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div id="divPreviousOrganisationDetail" runat="server">
                                    <div style="border-bottom: 2px solid #000000; margin-bottom: 15px;">
                                        <h3>
                                            Organisation Detail</h3>
                                    </div>
                                    <uc1:EmployeePreviousOrganisationDetailUC ID="uxEmployeePreviousOrganisationDetailUC"
                                        runat="server" />
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div id="divOtherDetail" runat="server">
                                    <div style="border-bottom: 2px solid #000000; margin-bottom: 15px;">
                                        <h3>
                                            Other Detail</h3>
                                    </div>
                                    <div style="float: left; margin-top: 10px;">
                                        <div style="font-weight: bold; margin-bottom: 6px;">
                                            Family Detail</div>
                                        <uc1:EmployeeFamilyDetailUC ID="uxEmployeeFamilyDetailUC" runat="server" />
                                    </div>
                                    <div style="float: left; margin-top: 10px;">
                                        <div style="font-weight: bold; margin-bottom: 6px;">
                                            Licence Detail</div>
                                        <uc1:LicenceDetailUC ID="uxLicenceDetailUC" runat="server" />
                                    </div>
                                    <div style="float: left; margin-top: 10px;">
                                        <div style="font-weight: bold; margin-bottom: 6px;">
                                            Immigration Detail</div>
                                        <uc1:ImmigrationDetailUC ID="uxImmigrationDetailUC" runat="server" />
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="margin: 0px 0px 0px;">
                                <div>
                                    <asp:Button ID="btnCancel" runat="server" CssClass="button" Text="Cancel" OnClick="btnCancel_Click" />
                                    <asp:Button ID="btnSave" runat="server" CssClass="button" Text="Save" OnClick="btnSave_Click" />
                                </div>
                                <asp:Label ID="lblMessage" runat="server" EnableViewState="False"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </div>
        </div>
    </div>
    <asp:Label ID="lblMess" runat="server"></asp:Label>
</asp:Content>
