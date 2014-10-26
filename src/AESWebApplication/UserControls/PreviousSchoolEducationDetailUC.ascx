<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PreviousSchoolEducationDetailUC.ascx.cs"
    Inherits="PreviousSchoolEducationDetailUC" %>
<%@ Register Src="~/UserControls/PreviousSchoolEducationMarksWizardUC.ascx" TagName="PreviousSchoolEducationMarksWizardUC"
    TagPrefix="uc1" %>
<p>
    &nbsp;
</p>
<asp:MultiView ID="MultiViewPreviousSchoolEducationDetail" runat="server" ActiveViewIndex="0">
    <asp:View ID="ViewPreviousSchoolEducationDetailGrid" runat="server">
        <%-- <fieldset>
            <legend>Previous School Education Detail List</legend>--%>
        <asp:Button ID="btnAddRecord" runat="server" Text="Add Record" OnClick="btnAddRecord_Click"
            CausesValidation="False" />
        <asp:GridView ID="grdPreviousSchoolEducationDetail" runat="server" DataKeyNames="Previous_School_Education_Id,School_Id,Class_Id,Academic_Session_Id"
            AllowPaging="True" OnRowDeleting="grdPreviousSchoolEducationDetail_RowDeleting"
            OnPageIndexChanging="grdPreviousSchoolEducationDetail_PageIndexChanging" AutoGenerateColumns="False"
            EmptyDataText="No Record Found" OnSelectedIndexChanged="grdPreviousSchoolEducationDetail_SelectedIndexChanged">
            <Columns>
                <asp:CommandField ShowSelectButton="True" SelectText="Select" HeaderText="Select" />
                <asp:CommandField ShowDeleteButton="True" DeleteText="Delete" HeaderText="Delete" />
                <asp:TemplateField HeaderText="School Name">
                    <ItemTemplate>
                        <asp:Label ID="lblSchoolName" runat="server" Text='<%# Eval("School_Name") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="School Address">
                    <ItemTemplate>
                        <asp:Label ID="lblSchoolAddress" runat="server" Text='<%# Eval("School_Address") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="School Contacts">
                    <ItemTemplate>
                        <asp:Label ID="lblSchoolContacts" runat="server" Text='<%# Eval("School_Contacts") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Registration Number">
                    <ItemTemplate>
                        <asp:Label ID="lblRegistrationNumber" runat="server" Text='<%# Eval("Registration_Number") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Result Status">
                    <ItemTemplate>
                        <asp:Label ID="lblResultStatus" runat="server" Text='<%# Eval("Result_Status") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Marks Percent">
                    <ItemTemplate>
                        <asp:Label ID="lblMarksPercent" runat="server" Text='<%# Eval("Marks_Percent") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Supported Documents">
                    <ItemTemplate>
                        <asp:Label ID="lblSupportedDocuments" runat="server" Text='<%# Eval("Supported_Documents") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <%-- </fieldset>--%>
    </asp:View>
    <asp:View ID="ViewPreviousSchoolEducationDetailControls" runat="server">
        <%--<fieldset>
            <legend>Previous School Education Detail</legend>--%>
        <asp:HiddenField ID="hfSessionDataKey" runat="server" />
        <asp:HiddenField ID="hfIsControlsLoaded" runat="server" />
        <asp:HiddenField ID="hfEditIndexKey" runat="server" />
        <div id="dvSchool" class="dvColumnLeft">
            <asp:Label ID="lblSchool" runat="server" Text="School Name"></asp:Label>
            <asp:DropDownList ID="ddlSchool" runat="server" DataValueField="School_Id" DataTextField="School_Name">
            </asp:DropDownList>
        </div>
        <div id="dvSchoolName" class="dvColumnRight">
            <asp:Label ID="lblSchoolName" runat="server" Text="School Name"></asp:Label>
            <asp:TextBox ID="txtSchoolName" runat="server"></asp:TextBox>
        </div>
        <div id="dvSchoolAddress" class="dvColumnLeft">
            <asp:Label ID="lblSchoolAddress" runat="server" Text="School Address"></asp:Label>
            <asp:TextBox ID="txtSchoolAddress" runat="server"></asp:TextBox>
        </div>
        <div id="dvSchoolContacts" class="dvColumnRight">
            <asp:Label ID="lblSchoolContacts" runat="server" Text="School Contacts"></asp:Label>
            <asp:TextBox ID="txtSchoolContacts" runat="server"></asp:TextBox>
        </div>
        <div id="dvClass" class="dvColumnLeft">
            <asp:Label ID="lblClass" runat="server" Text="Class Name"></asp:Label>
            <asp:DropDownList ID="ddlClass" runat="server" DataValueField="Class_Id" DataTextField="Class_Name">
            </asp:DropDownList>
        </div>
        <div id="dvRegistrationNumber" class="dvColumnRight">
            <asp:Label ID="lblRegistrationNumber" runat="server" Text="Registration Number"></asp:Label>
            <asp:TextBox ID="txtRegistrationNumber" runat="server"></asp:TextBox>
        </div>
        <div id="dvAcademic" class="dvColumnLeft">
            <asp:Label ID="lblAcademic" runat="server" Text="Session Name"></asp:Label>
            <asp:DropDownList ID="ddlAcademic" runat="server" DataValueField="Session_Id" DataTextField="Session_Name">
            </asp:DropDownList>
        </div>
        <div id="dvResultStatus" class="dvColumnRight">
            <asp:Label ID="lblResultStatus" runat="server" Text="Result Status"></asp:Label>
            <asp:TextBox ID="txtResultStatus" runat="server"></asp:TextBox>
        </div>
        <div id="dvMarksPercent" class="dvColumnLeft">
            <asp:Label ID="lblMarksPercent" runat="server" Text="Marks Percent"></asp:Label>
            <asp:TextBox ID="txtMarksPercent" runat="server"></asp:TextBox>
        </div>
        <div id="dvSupportedDocuments" class="dvColumnRight">
            <asp:Label ID="lblSupportedDocuments" runat="server" Text="Supported Documents"></asp:Label>
            <asp:TextBox ID="txtSupportedDocuments" runat="server"></asp:TextBox>
        </div>
        <%--</fieldset>--%>
        <fieldset>
            <legend>Previous School Education Marks Detail</legend>
            <uc1:PreviousSchoolEducationMarksWizardUC ID="uxPreviousSchoolEducationMarksWizardUC"
                runat="server" />
        </fieldset>
        <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save" CausesValidation="False" />
        <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Cancel" />
    </asp:View>
</asp:MultiView>
<asp:Label ID="lblMessage" runat="server" EnableViewState="False"></asp:Label>
