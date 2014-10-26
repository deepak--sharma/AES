<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ActivityDetailUI.aspx.cs"
    Inherits="ActivityDetailUI" MasterPageFile="~/MasterPage/MainMasterPage.master" %>

<%@ Register Src="UserControls/StudentAttendanceUC.ascx" TagName="StudentAttendanceUC"
    TagPrefix="uc1" %>
    <%@ Register Src="~/UserControls/Calender.ascx" TagName="CalenderUC" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="Server">
    <title>ActivityDetail Page</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
     <div id="divContainer">
        <asp:MultiView ID="MultiViewActivityDetail" runat="server" ActiveViewIndex="0">
            <asp:View ID="ViewActivityDetailGrid" runat="server">
                <fieldset>
                    <legend>Activity Detail List</legend>
                    <asp:Button ID="btnAddNewRecord" runat="server" Text="Add New Record" OnClick="btnAddNewRecord_Click" />
                    <asp:Label ID="lblViewOnly" runat="server" Text="View only - "></asp:Label>
                    <asp:RadioButton ID="rdbActiveRecord" runat="server" Text="Live Records" GroupName="DisplayMode"
                        AutoPostBack="True" Checked="True" OnCheckedChanged="rdbActiveRecord_CheckedChanged" />
                    <asp:RadioButton ID="rdbInActiveRecord" runat="server" Text="Deleted Records" GroupName="DisplayMode"
                        AutoPostBack="True" OnCheckedChanged="rdbInActiveRecord_CheckedChanged" />
                    <asp:GridView ID="grdActivityDetail" runat="server" DataKeyNames="Activity_Detail_Id,Version"
                        AllowPaging="True" OnRowDeleting="grdActivityDetail_RowDeleting" OnPageIndexChanging="grdActivityDetail_PageIndexChanging"
                        AutoGenerateColumns="False" EmptyDataText="No Record Found" OnRowEditing="grdActivityDetail_ActivatingObject"
                        OnSelectedIndexChanged="grdActivityDetail_SelectedIndexChanged">
                        <Columns>
                            <asp:CommandField ShowSelectButton="True" SelectText="Select" HeaderText="Select" />
                            <asp:CommandField ShowEditButton="True" EditText="Activate" HeaderText="Activate"
                                Visible="false" />
                            <asp:CommandField ShowDeleteButton="True" DeleteText="Delete" HeaderText="Delete" />
                            
                             <asp:TemplateField HeaderText="Activity Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblActivityName" runat="server" Text='<%# Eval("ACTIVITY_NAME") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Session Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblSessionName" runat="server" Text='<%# Eval("SESSION_NAME") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>                            
                             <asp:TemplateField HeaderText="Branch Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblBranchName" runat="server" Text='<%# Eval("BRANCH_NAME") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Class-Stram-Section">
                                <ItemTemplate>
                                    <asp:Label ID="lblClassStreamSection" runat="server" Text='<%# Eval("CLASS_STREAM_SECTION") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Subject Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblSubjectName" runat="server" Text='<%# Eval("SUBJECT_NAME") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Activity Owner">
                                <ItemTemplate>
                                    <asp:Label ID="lblActivityOwner" runat="server" Text='<%# Eval("EMPOLYEE_NAME") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="Start Date">
                                <ItemTemplate>
                                    <asp:Label ID="lblStartDate" runat="server" Text='<%# Eval("Start_Date") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="End Date">
                                <ItemTemplate>
                                    <asp:Label ID="lblEndDate" runat="server" Text='<%# Eval("End_Date") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Description">
                                <ItemTemplate>
                                    <asp:Label ID="lblDescription" runat="server" Text='<%# Eval("Description") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </fieldset>
            </asp:View>
            <asp:View ID="ViewActivityDetailControls" runat="server">
               <fieldset>
            <legend>Activity Detail</legend>
            <div id="dvActivityDetail" class="dvColumnLeft">
                <asp:Label ID="lblActivityDetail" runat="server" Text="Activity Name"></asp:Label>
                <asp:DropDownList ID="ddlActivityDetail" runat="server" DataValueField="Activity_Id" DataTextField="Activity_Name">
                </asp:DropDownList>
            </div>
            <div id="dvSession" class="dvColumnRight">
                <asp:Label ID="lblSession" runat="server" Text="Session"></asp:Label>
                <asp:DropDownList ID="ddlSession" runat="server" DataValueField="Session_Id" DataTextField="Session_Name">
                </asp:DropDownList>
            </div>
            <div id="dvStream" class="dvColumnLeft">
                <asp:Label ID="lblStream" runat="server" Text="Stream"></asp:Label>
                <asp:DropDownList ID="ddlStream" runat="server" DataValueField="Stream_Id" DataTextField="Stream_Name">
                </asp:DropDownList>
            </div>
            <div id="dvBranch" class="dvColumnRight">
                <asp:Label ID="lblBranch" runat="server" Text="Branch Name"></asp:Label>
                <asp:DropDownList ID="ddlBranch" runat="server" DataValueField="Branch_Id" DataTextField="Branch_Name">
                </asp:DropDownList>
            </div>
            <div id="dvClass" class="dvColumnLeft">
                <asp:Label ID="lblClass" runat="server" Text="Class Name"></asp:Label>
                <asp:DropDownList ID="ddlClass" runat="server" DataValueField="Class_Id" DataTextField="Class_Name">
                </asp:DropDownList>
            </div>
            <div id="dvSubject" class="dvColumnRight">
                <asp:Label ID="lblSubject" runat="server" Text="Subject Name"></asp:Label>
                <asp:DropDownList ID="ddlSubject" runat="server" DataValueField="Subject_Id" DataTextField="Subject_Name">
                </asp:DropDownList>
            </div>
            <div id="dvSection" class="dvColumnLeft">
                <asp:Label ID="lblSection" runat="server" Text="Section Name"></asp:Label>
                <asp:DropDownList ID="ddlSection" runat="server" DataValueField="Section_Id"
                    DataTextField="Section_Name">
                </asp:DropDownList>
            </div>
            <div id="dvStartDate" class="dvColumnRight">
                <asp:Label ID="lblStartDate" runat="server" Text="Start Date"></asp:Label>
                    <uc1:CalenderUC ID="calenderStartDate" runat="server" />
            </div>
            <div id="dvEndDate" class="dvColumnLeft">
                <asp:Label ID="lblEndDate" runat="server" Text="End Date"></asp:Label>
                 <uc1:CalenderUC ID="calenderEndDate" runat="server" />
            </div>
            <div id="dvActivityOwner" class="dvColumnLeft">
                <asp:Label ID="lblActivityOwner" runat="server" Text="Activity Owner"></asp:Label>
                <asp:DropDownList ID="ddlActivityOwner" runat="server" DataValueField="Employee_Id" DataTextField="EMPOLYEE_NAME">
                </asp:DropDownList>
            </div>
            <div id="dvDescription" class="dvColumnRight">
                <asp:Label ID="lblDescription" runat="server" Text="Description"></asp:Label>
                <asp:TextBox ID="txtDescription" runat="server"></asp:TextBox>
            </div>
            <div id="dvGo" class="dvColumnLeft">
                <asp:Button ID="btnGo" runat="server" Text="Go" OnClick="btnGo_Click"></asp:Button>
            </div>
        </fieldset>
        <fieldset>
            <legend>Student Attendance</legend>
            <uc1:StudentAttendanceUC ID="uxStudentAttendanceUC" runat="server" />
        </fieldset>             
                <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit Record" />
                <asp:Button ID="btnCancelRollback" runat="server" OnClick="btnCancelRollback_Click"
                    Text="Cancel / Rollback" />
            </asp:View>
        </asp:MultiView>
        <asp:Label ID="lblMessage" runat="server" EnableViewState="False"></asp:Label>
    </div>
</asp:Content>
