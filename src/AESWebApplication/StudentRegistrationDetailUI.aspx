<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StudentRegistrationDetailUI.aspx.cs"
    Inherits="StudentRegistrationDetailUI" MasterPageFile="~/MasterPage/MainMasterPage.master" %>

<%@ Register Src="~/UserControls/Calender.ascx" TagName="CalenderUC" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="Server">
    <title>StudentRegistrationDetail Page</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">

    <div id="divContaintRight">
        <div id="UserForm">
            <div id="dvFilterRegistration">
                <div style="border-bottom: 2px solid #000000; margin-bottom: 15px; margin-top: 3px;">
                    <h3>
                        Search Registration Request</h3>
                </div>
                <div id="dvSearchByRegistrationNumber" runat="server">
                    <asp:Label ID="lblRegNumber" runat="server" Text="Registration Number"></asp:Label>
                    <asp:TextBox ID="txtRegNumber" runat="server"></asp:TextBox>
                </div>
                <div id="dvAdvanceSearch" runat="server">
                    <div class="dvColumnLeft">
                        <asp:Label ID="lblStartDate" runat="server" Text="Start Date"></asp:Label>
                        <uc1:CalenderUC ID="txtStartDate" runat="server" EnableRFValidator="false" />
                    </div>
                    <div class="dvColumnRight">
                        <asp:Label ID="lblEndDate" runat="server" Text="End Date"></asp:Label>
                        <uc1:CalenderUC ID="txtEndDate" runat="server" EnableRFValidator="false" />
                    </div>
                    <div class="dvColumnLeft">
                        <asp:Label ID="lblRegStatus" runat="server" Text="Registration Status"></asp:Label>
                        <asp:DropDownList ID="ddlSearchRegistrationStatus" runat="server" DataTextField="Metadata_Name"
                            DataValueField="Metadata_Id" />
                    </div>
                </div>
                <div>
                    <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click"
                        CssClass="button" />
                </div>
            </div>
            <div id="GridPanel" runat="server" style="width: 100%; overflow: auto" visible="false">
                <div style="border-bottom: 2px solid #000000; margin-bottom: 15px;">
                    <h3>
                        View Registration Request</h3>
                </div>
                <asp:GridView ID="grdStudentRegistrationDetail" runat="server" DataKeyNames="Student_Registration_Id,Version,Registration_Status_Id"
                    AllowPaging="True" OnPageIndexChanging="grdStudentRegistrationDetail_PageIndexChanging"
                    OnRowDataBound="grdStudentRegistrationDetail_RowDataBound" AutoGenerateColumns="False"
                    EmptyDataText="No Record Found" Width="100%" OnRowCreated="grdStudentRegistrationDetail_RowCreated">
                    <Columns>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:CheckBox ID="chkSelectAll" runat="server"></asp:CheckBox>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkSelectItem" runat="server"></asp:CheckBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Select">
                            <ItemTemplate>
                                <asp:HyperLink ID="lnkSelect" runat="server" Text="Select" NavigateUrl='<%#"StudentRegistrationEditViewUI.aspx?RegId="+Eval("Student_Registration_Id") %>'></asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Process Admission">
                            <ItemTemplate>
                                <asp:HyperLink ID="lnkProcessAdmission" runat="server" Text="Proceed" NavigateUrl='<%#"StudentAdmissionDetailUI.aspx?RegId="+Eval("Student_Registration_Id") %>'></asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Registration Number">
                            <ItemTemplate>
                                <asp:Label ID="lblRegistrationNumber" runat="server" Text='<%# Eval("Registration_Number") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Registration_Date" HeaderText="Registration Date" DataFormatString='{0:dd-MMM-yyyy}' />
                        <asp:BoundField DataField="CLASS_NAME" HeaderText="Class Name" />
                        <asp:BoundField DataField="CANDIDATE_NAME" HeaderText="Candidate Name" />
                        <asp:BoundField DataField="DATE_OF_BIRTH" HeaderText="DOB" DataFormatString='{0:dd-MMM-yyyy}' />
                        <asp:TemplateField HeaderText="Fee Received (in Rs)">
                            <ItemTemplate>
                                <asp:Label ID="lblFeeSubmited" runat="server" Text='<%# Eval("Fee_Submited") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Registration Status">
                            <ItemTemplate>
                                <asp:Label ID="lblRegistrationStatus" runat="server" Text='<%# Eval("Registration_Status_Name") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Comment">
                            <ItemTemplate>
                                <asp:Label ID="lblComment" runat="server" Text='<%# MakeShort(Convert.ToString(Eval("Comment"))) %>'
                                    ToolTip='<%# Eval("Comment") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            <div id="dvChangeRegistrationStatus" runat="server">
                <div>
                    <b>Note:</b> To change registration status, select record, select new registration
                    status and click submit button.</div>
                <br />
                <div class="dvColumnLeft">
                    <asp:Label ID="lblRegistrationStatus" runat="server" Text="Change Registration Status"></asp:Label>
                    <asp:DropDownList ID="ddlUpdatedRegistrationStatus" runat="server" DataTextField="Metadata_Name"
                        DataValueField="Metadata_Id" />
                    <span style="padding-left: 2px;">
                        <asp:Button ID="btnChangeRegistrationStatus" runat="server" Text="Submit" OnClick="btnChangeRegistrationStatus_Click" />
                    </span>
                </div>
            </div>
            <asp:Button ID="btnAddNewRecord" runat="server" Text="Add New Registration Request"
                OnClick="btnAddNewRecord_Click" CssClass="button" Width="200" />
            <asp:Label ID="lblMessage" runat="server" EnableViewState="False" Width="100%"></asp:Label>
        </div>
    </div>
</asp:Content>
