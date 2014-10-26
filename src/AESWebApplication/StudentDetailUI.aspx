<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StudentDetailUI.aspx.cs"
    Inherits="StudentDetailUI" MasterPageFile="~/MasterPage/MainMasterPage.master" %>

<%@ Register Src="UserControls/CandidateDetailUC.ascx" TagName="CandidateDetailUC"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="Server">
    <title>StudentDetail Page</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
   <div id="divContainer">
        <asp:MultiView ID="MultiViewStudentDetail" runat="server" ActiveViewIndex="0">
            <asp:View ID="ViewStudentDetailGrid" runat="server">
                <fieldset>
                    <legend>Student Detail List</legend>
                    <asp:Button ID="btnAddNewRecord" runat="server" Text="Add New Record" OnClick="btnAddNewRecord_Click" />
                    <asp:Label ID="lblViewOnly" runat="server" Text="View only - "></asp:Label>
                    <asp:RadioButton ID="rdbActiveRecord" runat="server" Text="Live Records" GroupName="DisplayMode"
                        AutoPostBack="True" Checked="True" OnCheckedChanged="rdbActiveRecord_CheckedChanged" />
                    <asp:RadioButton ID="rdbInActiveRecord" runat="server" Text="Deleted Records" GroupName="DisplayMode"
                        AutoPostBack="True" OnCheckedChanged="rdbInActiveRecord_CheckedChanged" />
                    <asp:GridView ID="grdStudentDetail" runat="server" DataKeyNames="Student_Id,Version"
                        AllowPaging="True" OnRowDeleting="grdStudentDetail_RowDeleting" OnPageIndexChanging="grdStudentDetail_PageIndexChanging"
                        AutoGenerateColumns="False" EmptyDataText="No Record Found" OnRowEditing="grdStudentDetail_ActivatingObject"
                        OnSelectedIndexChanged="grdStudentDetail_SelectedIndexChanged">
                        <Columns>
                            <asp:CommandField ShowSelectButton="True" SelectText="Select" HeaderText="Select" />
                            <asp:CommandField ShowEditButton="True" EditText="Activate" HeaderText="Activate"
                                Visible="false" />
                            <asp:CommandField ShowDeleteButton="True" DeleteText="Delete" HeaderText="Delete" />
                            <asp:TemplateField HeaderText="Roll No">
                                <ItemTemplate>
                                    <asp:Label ID="lblRollNo" runat="server" Text='<%# Eval("Roll_No") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Session Id">
                                <ItemTemplate>
                                    <asp:Label ID="lblSessionId" runat="server" Text='<%# Eval("Session_Id") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Admission Date">
                                <ItemTemplate>
                                    <asp:Label ID="lblAdmissionDate" runat="server" Text='<%# Eval("Admission_Date") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </fieldset>
            </asp:View>
            <asp:View ID="ViewStudentDetailControls" runat="server">
                <fieldset>
                    <legend>Student Detail</legend>
                    <fieldset>
                        <legend>Candidate Detail</legend>
                        <uc1:CandidateDetailUC ID="uxCandidateUC" runat="server" />
                    </fieldset>
                    <div id="dvClass" class="dvColumnLeft">
                        <asp:Label ID="lblClass" runat="server" Text="Class Name"></asp:Label>
                        <asp:DropDownList ID="ddlClass" runat="server" DataValueField="Class_Id"
                            DataTextField="Class_Name">
                        </asp:DropDownList>
                    </div>
                    <div id="dvSection" class="dvColumnRight">
                        <asp:Label ID="lblSection" runat="server" Text="Class Section Name"></asp:Label>
                        <asp:DropDownList ID="ddlSection" runat="server" DataValueField="Class_Section_Id"
                            DataTextField="Class_Section_Name">
                        </asp:DropDownList>
                    </div>
                    <div id="dvStream" class="dvColumnLeft">
                        <asp:Label ID="lblStream" runat="server" Text="Stream Name"></asp:Label>
                        <asp:DropDownList ID="ddlStream" runat="server" DataValueField="Stream_Id" DataTextField="Stream_Name">
                        </asp:DropDownList>
                    </div>
                    <div id="dvRollNo" class="dvColumnRight">
                        <asp:Label ID="lblRollNo" runat="server" Text="Roll No"></asp:Label>
                        <asp:TextBox ID="txtRollNo" runat="server"></asp:TextBox>
                    </div>
                    <div id="dvSessionId" class="dvColumnLeft">
                        <asp:Label ID="lblSessionId" runat="server" Text="Session Id"></asp:Label>
                        <asp:TextBox ID="txtSessionId" runat="server"></asp:TextBox>
                    </div>
                    <div id="dvFee" class="dvColumnRight">
                        <asp:Label ID="lblFee" runat="server" Text="Fee Structure Name"></asp:Label>
                        <asp:DropDownList ID="ddlFee" runat="server" DataValueField="Fee_Structure_Id" DataTextField="Fee_Structure_Name">
                        </asp:DropDownList>
                    </div>
                    <div id="dvAdmissionDate" class="dvColumnLeft">
                        <asp:Label ID="lblAdmissionDate" runat="server" Text="Admission Date"></asp:Label>
                        <asp:TextBox ID="txtAdmissionDate" runat="server"></asp:TextBox>
                    </div>
                </fieldset>
                <asp:Button ID="btnSave" runat="server" Enabled="False" OnClick="btnSave_Click" Text="Save Record" />
                <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit Record" />
                <asp:Button ID="btnCancelRollback" runat="server" OnClick="btnCancelRollback_Click"
                    Text="Cancel / Rollback" />
            </asp:View>
        </asp:MultiView>
        <asp:Label ID="lblMessage" runat="server" EnableViewState="False"></asp:Label>
    </div>
</asp:Content>
