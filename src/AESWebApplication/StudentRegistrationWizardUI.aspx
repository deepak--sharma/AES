<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StudentRegistrationWizardUI.aspx.cs"
    Inherits="StudentRegistrationWizardUI" MasterPageFile="~/MasterPage/MainMasterPage.master" %>

<%@ Register Src="UserControls/Calender.ascx" TagName="CalenderUC" TagPrefix="uc1" %>
<%@ Register Src="UserControls/CandidateWizardUC.ascx" TagName="CandidateWizardUC"
    TagPrefix="uc2" %>
<%@ Register Src="UserControls/PreviousSchoolEducationWizardUC.ascx" TagName="PreviousSchoolEducationWizardUC"
    TagPrefix="uc3" %>
<%@ Register Src="UserControls/SiblingWizardUC.ascx" TagName="SiblingWizardUC" TagPrefix="uc4" %>
<%@ Register Src="UserControls/GuardianWizardUC.ascx" TagName="GuardianWizardUC"
    TagPrefix="uc5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="Server">
    <title>Student Registration Detail</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div id="maindiv">
        <div id="divContaintRight">
            <div id="UserFormWizard">
                <asp:Wizard ID="wzdStudentRegistration" runat="server" DisplaySideBar="False" Width="100%"
                    OnFinishButtonClick="wzdStudentRegistration_FinishButtonClick" OnNextButtonClick="wzdStudentRegistration_NextButtonClick"
                    OnPreviousButtonClick="wzdStudentRegistration_PreviousButtonClick">
                    <WizardSteps>
                        <asp:WizardStep ID="WizardStep1" runat="server" Title="Candidate Detail">
                            <div>
                                <div style="background-color: #399bc6; color: White; height: 20px; vertical-align: middle;
                                    margin-bottom: 15px;">
                                    <h4>
                                        Registration Basic Information</h4>
                                </div>
                                <div class="dvColumnLeft">
                                    <asp:Label ID="lblRegistration" runat="server" Text="Registration Name"></asp:Label><span
                                        style="color: Red">*</span>
                                    <asp:DropDownList ID="ddlRegistration" runat="server" DataValueField="Registration_Id"
                                        DataTextField="Registration_Name" Width="60%">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvRegistrationName" runat="server" ControlToValidate="ddlRegistration"
                                        InitialValue='<%# UIUtility.DEFAULT_DDL_VALUE %>'  Display="Static" ToolTip="Select Registration Name">
                                           <img src="Images/Warning.png" alt=""/>
                                    </asp:RequiredFieldValidator>
                                </div>
                                <div id="divRegistrationDate" runat="server" class="dvColumnRight">
                                    <asp:Label ID="lblRegistrationDate" runat="server" Text="Registration Date"></asp:Label>
                                    <font style="color: Red; float: left;">*</font>
                                    <uc1:CalenderUC ID="calenderRegistrationDate" runat="server" EnableRFValidator="true"
                                        RFVMessage="Enter Registration Date" />
                                </div>
                                <div class="dvColumnLeft">
                                    <asp:Label ID="lblBoarding" runat="server" Text="Boarding Type"></asp:Label>
                                    <asp:DropDownList ID="ddlBoarding" runat="server" DataValueField="Metadata_Id" DataTextField="Metadata_Name">
                                    </asp:DropDownList>
                                </div>
                                <div class="dvColumnRight">
                                    <asp:Label ID="lblDistance" runat="server" Text="Distance(in KM)"></asp:Label>
                                    <asp:TextBox ID="txtDistance" runat="server" MaxLength="3"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDistance"
                                        ErrorMessage="Error" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                                <div class="dvColumnLeft">
                                    <asp:Label ID="lblIsTransportRequired" runat="server" Text="Transport Required"></asp:Label>
                                    <asp:RadioButtonList ID="rblIsTransportRequired" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Value="True">Yes</asp:ListItem>
                                        <asp:ListItem Value="False" Selected="True">No</asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                                <div class="dvColumnLeft">
                                    <uc2:CandidateWizardUC ID="uxCandidateWizardUC" runat="server" />
                                </div>
                            </div>
                        </asp:WizardStep>
                        <asp:WizardStep ID="WizardStep2" runat="server" Title="Educational Detail">
                            <div style="background-color: #399bc6; color: White; height: 20px; vertical-align: middle;
                                margin-bottom: 15px;">
                                <h4>
                                    Previous Education Detail</h4>
                            </div>
                            <uc3:PreviousSchoolEducationWizardUC ID="uxPreviousSchoolEducationWizardUC" runat="server" />
                        </asp:WizardStep>
                        <asp:WizardStep runat="server" Title="Guardian Detail">
                            <fieldset>
                                <legend>Father<asp:RadioButton ID="rdbFatherGuardion" runat="server" Checked="true"
                                    Text="Is Guardian" GroupName="GuardianDetail" /></legend>
                                <uc5:GuardianWizardUC ID="uxFatherWizardUC" runat="server" />
                            </fieldset>
                            <fieldset>
                                <legend>Mother<asp:RadioButton ID="rdbMotherGuardion" runat="server" Text="Is Guardian"
                                    GroupName="GuardianDetail" /></legend>
                                <uc5:GuardianWizardUC ID="uxMotherWizardUC" runat="server" />
                            </fieldset>
                            <fieldset>
                                <legend>Guardian<asp:RadioButton ID="rdbGuardion" runat="server" Text="Is Guardian"
                                    GroupName="GuardianDetail" /></legend>
                                <uc5:GuardianWizardUC ID="uxGuardianWizardUC" runat="server" RelationRequired="true" />
                            </fieldset>
                        </asp:WizardStep>
                        <asp:WizardStep runat="server" Title="Sibling Detail">
                            <fieldset>
                                <legend>Sibling - 1</legend>
                                <uc4:SiblingWizardUC ID="uxSiblingWizardUC1" runat="server" />
                            </fieldset>
                            <fieldset>
                                <legend>Sibling - 2</legend>
                                <uc4:SiblingWizardUC ID="uxSiblingWizardUC2" runat="server" />
                            </fieldset>
                        </asp:WizardStep>
                    </WizardSteps>
                    <%-- <StartNavigationTemplate>
                        <asp:Button ID="btnNext" runat="server" Text="Next1" CommandName="MoveNext" CausesValidation="true"
                            ValidationGroup="Form" />
                    </StartNavigationTemplate>
                    <StepNavigationTemplate>
                        <asp:Button ID="btnPrevious" runat="server" Text="Previous" CommandName="MovePrevious" />
                        <asp:Button ID="btnNext" runat="server" Text="Next" CommandName="MoveNext" CausesValidation="true"
                            ValidationGroup="Form" />
                    </StepNavigationTemplate>
                    <FinishNavigationTemplate>
                        <asp:Button ID="btnPrevious" runat="server" Text="Previous" CommandName="MovePrevious" ValidationGroup="Form" />
                        <asp:Button ID="btnFinish" runat="server" Text="Finish" CommandName="MoveFinish" ValidationGroup="Form" />
                    </FinishNavigationTemplate>--%>
                </asp:Wizard>
            </div>
        </div>
    </div>
</asp:Content>
