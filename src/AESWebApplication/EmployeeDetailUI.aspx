<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EmployeeDetailUI.aspx.cs"
    Inherits="EmployeeDetailUI" MasterPageFile="~/MasterPage/MainMasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="Server">
    <title>EmployeeDetail Page</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div id="divContainer">
        <div>
            <table cellpadding="0" cellspacing="0" border="0">
                <tr>
                    <td>
                        <div style="border-bottom: 2px solid #000000; margin-bottom: 8px; margin-top: 5px;">
                            <h3>
                                Employee Detail List</h3>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div style="float: left;">
                            <asp:Button ID="btnAddNewRecord" runat="server" Text="Add New Record" OnClick="btnAddNewRecord_Click"
                                PostBackUrl="EmployeeActionViewUI.aspx" Width="150" Style="margin-left: auto;" />
                        </div>
                        <div style="float: left;">
                            <asp:Label ID="lblViewOnly" runat="server" Text="View only - " Style="width: auto;"></asp:Label>
                            <asp:RadioButton ID="rdbActiveRecord" runat="server" Text="Live Records" GroupName="DisplayMode"
                                AutoPostBack="True" Checked="True" OnCheckedChanged="rdbActiveRecord_CheckedChanged" />
                            <asp:RadioButton ID="rdbInActiveRecord" runat="server" Text="Deleted Records" GroupName="DisplayMode"
                                AutoPostBack="True" OnCheckedChanged="rdbInActiveRecord_CheckedChanged" />
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div style="width: 980px; overflow: auto;">
                            <asp:GridView ID="grdEmployeeDetail" runat="server" DataKeyNames="Employee_Id,Version"
                                AllowPaging="True" OnRowDeleting="grdEmployeeDetail_RowDeleting" OnPageIndexChanging="grdEmployeeDetail_PageIndexChanging"
                                AutoGenerateColumns="False" EmptyDataText="No Record Found" OnRowEditing="grdEmployeeDetail_ActivatingObject"
                                OnRowDataBound="grdEmployeeDetail_RowDataBound">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:HyperLink ID="lnkSelect" runat="server" Text="Select"></asp:HyperLink>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:CommandField ShowEditButton="True" EditText="Activate" HeaderText="Activate"
                                        Visible="false" />
                                    <asp:CommandField ShowDeleteButton="True" DeleteText="Delete" HeaderText="Delete" />
                                    <asp:TemplateField HeaderText="Employee Code">
                                        <ItemTemplate>
                                            <asp:Label ID="lblEmployeeCode" runat="server" Text='<%# Eval("Employee_Code") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="First Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblFirstName" runat="server" Text='<%# Eval("First_Name") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Middle Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblMiddleName" runat="server" Text='<%# Eval("Middle_Name") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Last Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblLastName" runat="server" Text='<%# Eval("Last_Name") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Father Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblFatherName" runat="server" Text='<%# Eval("Father_Name") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Date Of Birth">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDateOfBirth" runat="server" Text='<%# Eval("Date_Of_Birth") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Marriage Date">
                                        <ItemTemplate>
                                            <asp:Label ID="lblMarriageDate" runat="server" Text='<%# Eval("Marriage_Date") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Personal Email Id">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPersonalEmailId" runat="server" Text='<%# Eval("Personal_Email_Id") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Office Email Id">
                                        <ItemTemplate>
                                            <asp:Label ID="lblOfficeEmailId" runat="server" Text='<%# Eval("Office_Email_Id") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Is Fresher">
                                        <ItemTemplate>
                                            <asp:Label ID="lblIsFresher" runat="server" Text='<%# Eval("Is_Fresher") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Compaign">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCompaign" runat="server" Text='<%# Eval("Compaign") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Ssn No">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSsnNo" runat="server" Text='<%# Eval("SSN_No") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <RowStyle CssClass="RowStyle" />
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <PagerStyle CssClass="PagerStyle" />
                                <SelectedRowStyle CssClass="SelectedRowStyle" />
                                <HeaderStyle CssClass="HeaderStyle" />
                                <EditRowStyle CssClass="EditRowStyle" />
                                <AlternatingRowStyle CssClass="AltRowStyle" />
                            </asp:GridView>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblMessage" runat="server" EnableViewState="False" CssClass="lblMsg"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
