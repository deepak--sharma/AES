<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RegistrationMasterUI.aspx.cs"
    Inherits="RegistrationMasterUI" MasterPageFile="~/MasterPage/MainMasterPage.master" %>

<%@ Register Src="UserControls/ReservationDetailUC.ascx" TagName="ReservationDetailUC"
    TagPrefix="uc1" %>
<%@ Register Src="UserControls/RegistrationEligibilityUC.ascx" TagName="RegistrationEligibilityUC"
    TagPrefix="uc1" %>
<%@ Register Src="UserControls/Calender.ascx" TagName="CalenderUC" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="Server">
    <title>RegistrationMaster Page</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:MultiView ID="MultiViewRegistrationMaster" runat="server" ActiveViewIndex="0">
        <asp:View ID="ViewRegistrationMasterGrid" runat="server">
            <div style="border-bottom: 2px solid #000000; margin-bottom: 15px;">
                <h3>
                    View Registration Master</h3>
            </div>
            <asp:Button ID="btnAddNewRecord" runat="server" Text="Add New Record" OnClick="btnAddNewRecord_Click" />
            <asp:Label ID="lblViewOnly" runat="server" Text="View only - "></asp:Label>
            <asp:RadioButton ID="rdbActiveRecord" runat="server" Text="Live Records" GroupName="DisplayMode"
                AutoPostBack="True" Checked="True" OnCheckedChanged="rdbActiveRecord_CheckedChanged" />
            <asp:RadioButton ID="rdbInActiveRecord" runat="server" Text="Deleted Records" GroupName="DisplayMode"
                AutoPostBack="True" OnCheckedChanged="rdbInActiveRecord_CheckedChanged" />
            <asp:GridView ID="grdRegistrationMaster" runat="server" DataKeyNames="Registration_Id,Version"
                AllowPaging="True" OnRowDeleting="grdRegistrationMaster_RowDeleting" OnPageIndexChanging="grdRegistrationMaster_PageIndexChanging"
                AutoGenerateColumns="False" EmptyDataText="No Record Found" OnRowEditing="grdRegistrationMaster_ActivatingObject"
                OnSelectedIndexChanged="grdRegistrationMaster_SelectedIndexChanged" Width="100%"
                SkinID="GridView">
                <Columns>
                    <asp:CommandField ShowSelectButton="True" SelectText="Select" HeaderText="Select" />
                    <asp:CommandField ShowEditButton="True" EditText="Activate" HeaderText="Activate"
                        Visible="false" />
                    <asp:CommandField ShowDeleteButton="True" DeleteText="Delete" HeaderText="Delete" />
                    <asp:TemplateField HeaderText="Registration Name">
                        <ItemTemplate>
                            <asp:Label ID="lblRegistrationName" runat="server" Text='<%# Eval("Registration_Name") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Start_Date" HeaderText="Start Date" DataFormatString='{0:dd-MMM-yyyy}' />
                    <asp:BoundField DataField="End_Date" HeaderText="End Date" DataFormatString='{0:dd-MMM-yyyy}' />
                    <asp:TemplateField HeaderText="Total Seat">
                        <ItemTemplate>
                            <asp:Label ID="lblTotalSeat" runat="server" Text='<%# Eval("Total_Seat") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Management Seat">
                        <ItemTemplate>
                            <asp:Label ID="lblManagementSeat" runat="server" Text='<%# Eval("Management_Seat") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Registration Fee">
                        <ItemTemplate>
                            <asp:Label ID="lblRegistrationFee" runat="server" Text='<%# Eval("Registration_Fee") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Registration Status">
                        <ItemTemplate>
                            <asp:Label ID="lblRegistrationStatus" runat="server" Text='<%# Eval("Registration_Status_Name") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </asp:View>
        <asp:View ID="ViewRegistrationMasterControls" runat="server">
            <div style="border-bottom: 2px solid #000000; margin-bottom: 15px;">
                <h3>
                    Add/Edit Registration Master</h3>
            </div>
            <%-- <div id="maindiv">
                    <div id="divContaintRight">
                        <div id="UserFormWizard">--%>
            <asp:Wizard Width="100%" ID="wzdRegistrationMaster" runat="server" ActiveStepIndex="0"
                OnFinishButtonClick="wzdRegistrationMaster_FinishButtonClick" DisplaySideBar="False"
                DisplayCancelButton="true" OnCancelButtonClick="wzdRegistrationMaster_CancelButtonClick">
                <WizardSteps>
                    <asp:WizardStep ID="WizardStep1" runat="server" Title="Basic Detail">
                        <table width="100%" cellpadding="5" cellspacing="5">
                            <tr>
                                <td style="width: 20%">
                                    <asp:Label ID="lblRegistrationName" runat="server" Text="Registration Name"></asp:Label><span
                                        style="color: Red">*</span>
                                </td>
                                <td style="width: 30%" colspan="2">
                                    <asp:TextBox ID="txtRegistrationName" runat="server" Width="90%"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvRegistrationName" runat="server" ControlToValidate="txtRegistrationName"
                                        Display="Static" ToolTip="Enter Registration Name">
                                                        <span style="color:Red">*</span>
                                    </asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 20%">
                                    <asp:Label ID="lblBranch" runat="server" Text="Branch Name"></asp:Label><span style="color: Red">*</span>
                                </td>
                                <td style="width: 30%" colspan="2">
                                    <asp:DropDownList ID="ddlBranch" runat="server" DataValueField="Branch_Id" DataTextField="Branch_Name">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvBranch" runat="server" ControlToValidate="ddlBranch"
                                        InitialValue='<%# UIUtility.DEFAULT_DDL_VALUE %>' Display="Static" ToolTip="Select Branch Name">
                                            <span style="color:Red">*</span>
                                    </asp:RequiredFieldValidator>
                                </td>
                                <td style="width: 20%">
                                    <asp:Label ID="lblAcademic" runat="server" Text="Session Name"></asp:Label>
                                </td>
                                <td style="width: 30%">
                                    <asp:DropDownList ID="ddlAcademic" runat="server" DataValueField="Session_Id" DataTextField="Session_Name">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblClass" runat="server" Text="Class Name"></asp:Label><span style="color: Red">*</span>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlClass" runat="server" DataValueField="Class_Id" DataTextField="Class_Name">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvClass" runat="server" ControlToValidate="ddlClass"
                                        InitialValue='<%# UIUtility.DEFAULT_DDL_VALUE %>' Display="Static" ToolTip="Select Class Name">
                                            <span style="color:Red">*</span>
                                    </asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    <asp:Label ID="lblStream" runat="server" Text="Stream Name"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlStream" runat="server" DataValueField="Stream_Id" DataTextField="Stream_Name">
                                    </asp:DropDownList>
                                    <%--<asp:RequiredFieldValidator ID="rfvStream" runat="server" ControlToValidate="ddlStream"
                                        InitialValue='<%# UIUtility.DEFAULT_DDL_VALUE %>' Display="Static" ToolTip="Select Stream Name">
                                            <span style="color:Red">*</span>
                                    </asp:RequiredFieldValidator>--%>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblStartDate" runat="server" Text="Start Date"></asp:Label>
                                </td>
                                <td>
                                    <uc2:CalenderUC ID="txtStartDate" runat="server" EnableRFValidator="false" />
                                </td>
                                <td>
                                    <asp:Label ID="lblEndDate" runat="server" Text="End Date"></asp:Label>
                                </td>
                                <td>
                                    <uc2:CalenderUC ID="txtEndDate" runat="server" EnableRFValidator="false" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblTotalSeat" runat="server" Text="Total Seat"></asp:Label><span style="color: Red">*</span>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtTotalSeat" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvTotalSeat" runat="server" ControlToValidate="txtTotalSeat"
                                        Display="Static" ToolTip="Enter Total number of Seat">
                                            <span style="color:Red">*</span>
                                    </asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    <asp:Label ID="lblManagementSeat" runat="server" Text="Management Seat"></asp:Label><span
                                        style="color: Red">*</span>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtManagementSeat" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvManagementSeat" runat="server" ControlToValidate="txtManagementSeat"
                                        Display="Static" ToolTip="Enter No. of Management Seat">
                                            <span style="color:Red">*</span>
                                    </asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblRegistrationFee" runat="server" Text="Registration Fee"></asp:Label><span
                                        style="color: Red">*</span>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtRegistrationFee" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvRegistrationFee" runat="server" ControlToValidate="txtRegistrationFee"
                                        Display="Static" ToolTip="Enter Registration Fee">
                                            <span style="color:Red">*</span>
                                    </asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    <asp:Label ID="lblIsPartialFeeAllowed" runat="server" Text="Is Partial Fee Allowed"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlIsPartialFeeAllowed" runat="server">
                                        <asp:ListItem Value="True">True</asp:ListItem>
                                        <asp:ListItem Value="False">False</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblInstruction" runat="server" Text="Instruction"></asp:Label>
                                </td>
                                <td colspan="3">
                                    <asp:TextBox ID="txtInstruction" runat="server" TextMode="MultiLine" Width="95%"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblDisclaimer" runat="server" Text="Disclaimer"></asp:Label>
                                </td>
                                <td colspan="3">
                                    <asp:TextBox ID="txtDisclaimer" runat="server" TextMode="MultiLine" Width="95%"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </asp:WizardStep>
                    <asp:WizardStep ID="WizardStep2" runat="server" Title="Registration Eligibility Detail">
                        <uc1:RegistrationEligibilityUC ID="uxRegistrationEligibilityUC" runat="server" />
                    </asp:WizardStep>
                    <asp:WizardStep ID="WizardStep3" runat="server" Title="Reservation Detail">
                        <uc1:ReservationDetailUC ID="uxReservationDetailUC" runat="server" />
                    </asp:WizardStep>
                </WizardSteps>
            </asp:Wizard>
            <%--</div>
                    </div>
                </div>--%>
        </asp:View>
    </asp:MultiView>
    <asp:Label ID="lblMessage" runat="server" EnableViewState="False"></asp:Label>
</asp:Content>
