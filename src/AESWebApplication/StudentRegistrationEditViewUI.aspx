<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StudentRegistrationEditViewUI.aspx.cs"
    Inherits="StudentRegistrationEditViewUI" MasterPageFile="~/MasterPage/MainMasterPage.master" %>

<%@ Register Src="UserControls/CandidateWizardUC.ascx" TagName="CandidateWizardUC"
    TagPrefix="uc2" %>
<%@ Register Src="UserControls/PreviousSchoolEducationWizardUC.ascx" TagName="PreviousSchoolEducationWizardUC"
    TagPrefix="uc3" %>
<%@ Register Src="UserControls/SiblingWizardUC.ascx" TagName="SiblingWizardUC" TagPrefix="uc4" %>
<%@ Register Src="UserControls/GuardianWizardUC.ascx" TagName="GuardianWizardUC"
    TagPrefix="uc5" %>
<%@ Register Src="~/UserControls/Calender.ascx" TagName="CalenderUC" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="Server">
    <title>Employee Detail</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div id="maindiv">
        <div class="listmenu">
            <ul>
                <li>
                    <asp:LinkButton ID="lnkBasicDetail" runat="server" Text="Basic Detail" OnClick="lnkBasicDetail_Click"
                        CausesValidation="false"></asp:LinkButton></li>
                <li>
                    <asp:LinkButton ID="lnkEducationalDetail" runat="server" Text="Educational Detail"
                        OnClick="lnkEducationalDetail_Click" CausesValidation="false"></asp:LinkButton></li>
                <li>
                    <asp:LinkButton ID="lnkGuardianDetail" runat="server" Text="Guardian Detail" OnClick="lnkGuardianDetail_Click"
                        CausesValidation="false"></asp:LinkButton></li>
                <li>
                    <asp:LinkButton ID="lnkSiblingDetail" runat="server" Text="Sibling Detail" OnClick="lnkSiblingDetail_Click"
                        CausesValidation="false"></asp:LinkButton></li>
            </ul>
        </div>
        <div id="divContaintRightwithMenu">
            <div id="UserForm">
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr id="UpdateStatusButtonPanel" runat="server" visible="false">
                        <td>
                            <table width="100%" cellpadding="0" cellspacing="0" border="0">
                                <tr>
                                    <td style="height: 100px">
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblComment" runat="server" Text="Comment"></asp:Label>
                                        <asp:TextBox ID="txtComment" runat="server" TextMode="MultiLine" Height="100px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblRegistrationStatus" runat="server" Text="Registration Status"></asp:Label>
                                        <asp:DropDownList ID="ddlRegistrationStatus" runat="server" DataTextField="Metadata_Name"
                                            DataValueField="Metadata_Id" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Button ID="btnProceed" runat="server" Text="Proceed" OnClick="btnProceed_Click"
                                            CausesValidation="false" />
                                        <asp:Label ID="lblMsg" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table width="100%" cellpadding="0" cellspacing="0" border="0">
                                <tr>
                                    <td align="right">
                                        <asp:HyperLink ID="lnkBack" runat="server" Text="Back" NavigateUrl="~/StudentRegistrationDetailUI.aspx" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div id="dvBasicDetail" runat="server">
                                            <div style="border-bottom: 2px solid #000000; margin-bottom: 15px;">
                                                <h3>
                                                    Basic Information</h3>
                                            </div>
                                            <div class="dvColumnLeft">
                                                <asp:Label ID="Label1" runat="server" Text="Registration Name:"></asp:Label>
                                                <asp:Label ID="lblRegistration" runat="server" Style="width: 200px;"></asp:Label>
                                            </div>
                                            <div class="dvColumnLeft">
                                                <asp:Label ID="lblRegistrationNumber" runat="server" Text="Registration Number"></asp:Label>
                                                <asp:Label ID="lblRegistrationNumberValue" runat="server" Style="width: 200px;"></asp:Label>
                                            </div>
                                            <div class="dvColumnLeft">
                                                <asp:Label ID="lblRegistrationDate" runat="server" Text="Registration Date"></asp:Label>
                                                <uc1:CalenderUC ID="calenderRegistrationDate" runat="server" />
                                            </div>
                                            <div class="dvColumnRight">
                                                <asp:Label ID="lblFeeSubmited" runat="server" Text="Fee Submited(in Rs.)"></asp:Label>
                                                <asp:TextBox ID="txtFeeSubmited" runat="server" MaxLength="18"></asp:TextBox>
                                            </div>
                                            <div class="dvColumnLeft">
                                                <asp:Label ID="lblBoarding" runat="server" Text="Boarding Type"></asp:Label>
                                                <asp:DropDownList ID="ddlBoarding" runat="server" DataValueField="Metadata_Id" DataTextField="Metadata_Name">
                                                </asp:DropDownList>
                                            </div>
                                            <div class="dvColumnRight">
                                                <asp:Label ID="lblIsTransportRequired" runat="server" Text="Transport Required"></asp:Label>
                                                <asp:DropDownList ID="ddlIsTransportRequired" runat="server">
                                                    <asp:ListItem Value="-Select-">-Select-</asp:ListItem>
                                                    <asp:ListItem Value="True">True</asp:ListItem>
                                                    <asp:ListItem Value="False">False</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <div class="dvColumnLeft">
                                                <asp:Label ID="lblDistance" runat="server" Text="Distance(in KM)"></asp:Label>
                                                <asp:TextBox ID="txtDistance" runat="server" MaxLength="3"></asp:TextBox>
                                            </div>
                                            <table width="100%" cellspacing="0" cellpadding="0" border="0">
                                                <tr>
                                                    <td>
                                                        <div style="border-bottom: 2px solid #000000; margin-bottom: 15px;">
                                                            <h3>
                                                                Candidate Detail</h3>
                                                        </div>
                                                        <uc2:CandidateWizardUC ID="uxCandidateWizardUC" runat="server" />
                                                    </td>
                                                </tr>
                                                <tr id="BasicDetailButton" runat="server">
                                                    <td align="right" colspan="4">
                                                        <asp:Button ID="btnCancelBasic" runat="server" Text="Cancel" OnClick="btnCancelBasic_Click">
                                                        </asp:Button>
                                                        <asp:Button ID="btnSaveBasic" runat="server" Text="Save" OnClick="btnSaveBasic_Click">
                                                        </asp:Button>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <div id="dvEducationalDetail" runat="server" visible="false">
                                            <table width="100%" cellpadding="0" cellspacing="0" border="0">
                                                <tr>
                                                    <td>
                                                        <div style="border-bottom: 2px solid #000000; margin-bottom: 15px;">
                                                            <h3>
                                                                Previous Educational Detail</h3>
                                                        </div>
                                                        <uc3:PreviousSchoolEducationWizardUC ID="uxPreviousSchoolEducationWizardUC" runat="server" />
                                                    </td>
                                                </tr>
                                                <tr id="EducationalDetailButton" runat="server">
                                                    <td align="right">
                                                        <asp:Button ID="btnCancelEducational" runat="server" Text="Cancel" OnClick="btnCancelEducational_Click">
                                                        </asp:Button>
                                                        <asp:Button ID="btnSaveEducational" runat="server" Text="Save" OnClick="btnSaveEducational_Click">
                                                        </asp:Button>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <div id="dvGuardianDetail" runat="server" visible="false">
                                            <table width="100%">
                                                <tr>
                                                    <td>
                                                        <div style="border-bottom: 2px solid #000000; margin-bottom: 15px;">
                                                            <h3>
                                                                Father
                                                                <asp:RadioButton ID="rdbFatherGuardion" runat="server" Checked="true" Text="Is Guardian"
                                                                    GroupName="GuardianDetail" /></h3>
                                                        </div>
                                                        <div style="float: left">
                                                            <uc5:GuardianWizardUC ID="uxFatherWizardUC" runat="server" />
                                                        </div>
                                                        <div style="border-bottom: 2px solid #000000; margin-bottom: 15px;">
                                                            <h3>
                                                                Mother
                                                                <asp:RadioButton ID="rdbMotherGuardion" runat="server" Text="Is Guardian" GroupName="GuardianDetail" /></h3>
                                                        </div>
                                                        <div style="float: left">
                                                            <uc5:GuardianWizardUC ID="uxMotherWizardUC" runat="server" />
                                                        </div>
                                                        <div style="border-bottom: 2px solid #000000; margin-bottom: 15px;">
                                                            <h3>
                                                                Guardian<asp:RadioButton ID="rdbGuardion" runat="server" Text="Is Guardian" GroupName="GuardianDetail" /></h3>
                                                        </div>
                                                        <div style="float: left;">
                                                            <uc5:GuardianWizardUC ID="uxGuardianWizardUC" runat="server" RelationRequired="true" />
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr id="GuardianDetailButton" runat="server">
                                                    <td align="right">
                                                        <asp:Button ID="btnCancelGuardian" runat="server" Text="Cancel" OnClick="btnCancelGuardian_Click">
                                                        </asp:Button>
                                                        <asp:Button ID="btnSaveGuardian" runat="server" Text="Save" OnClick="btnSaveGuardian_Click">
                                                        </asp:Button>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <div id="dvSiblingDetail" runat="server" visible="false">
                                            <table width="100%">
                                                <tr>
                                                    <td>
                                                        <div style="border-bottom: 2px solid #000000; margin-bottom: 15px;">
                                                            <h3>
                                                                Sibling - 1</h3>
                                                        </div>
                                                        <div style="float: left;">
                                                            <uc4:SiblingWizardUC ID="uxSiblingWizardUC1" runat="server" />
                                                        </div>
                                                        <div style="border-bottom: 2px solid #000000; margin-bottom: 15px;">
                                                            <h3>
                                                                Sibling - 2</h3>
                                                        </div>
                                                        <div style="float: left;">
                                                            <uc4:SiblingWizardUC ID="uxSiblingWizardUC2" runat="server" />
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr id="SiblingDetailButton" runat="server">
                                                    <td align="right">
                                                        <asp:Button ID="btnCancelSibling" runat="server" Text="Cancel" OnClick="btnCancelSibling_Click">
                                                        </asp:Button>
                                                        <asp:Button ID="btnSaveSibling" runat="server" Text="Save" OnClick="btnSaveSibling_Click">
                                                        </asp:Button>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        <asp:Label ID="lblMessage" runat="server" EnableViewState="False" Width="100%"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
