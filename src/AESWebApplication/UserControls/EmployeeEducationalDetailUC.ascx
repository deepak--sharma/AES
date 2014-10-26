<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EmployeeEducationalDetailUC.ascx.cs"
    Inherits="EmployeeEducationalDetailUC" %>
<asp:MultiView ID="MultiViewEmployeeEducationalDetail" runat="server" ActiveViewIndex="0">
    <asp:View ID="ViewEmployeeEducationalDetailGrid" runat="server">
        <%-- <fieldset>
            <legend>Employee Educational Detail List</legend>--%>
        <div style="width: 750px; overflow: auto;">
            <asp:Button ID="btnAddRecord" runat="server" Text="Add Record" OnClick="btnAddRecord_Click"
                Style="margin: 0px 0px 0px 0px;" />
            <asp:GridView ID="grdEmployeeEducationalDetail" runat="server" DataKeyNames="Employee_Educational_Detail_Id,COURSE_Id,Stream_Id"
                AllowPaging="True" OnRowDeleting="grdEmployeeEducationalDetail_RowDeleting" OnPageIndexChanging="grdEmployeeEducationalDetail_PageIndexChanging"
                AutoGenerateColumns="False" EmptyDataText="No Record Found" OnSelectedIndexChanged="grdEmployeeEducationalDetail_SelectedIndexChanged">
                <Columns>
                    <asp:CommandField ShowSelectButton="True" SelectText="Select" HeaderText="Select" />
                    <asp:CommandField ShowDeleteButton="True" DeleteText="Delete" HeaderText="Delete" />
                    <asp:TemplateField HeaderText="Period From">
                        <ItemTemplate>
                            <asp:Label ID="lblPeriodFrom" runat="server" Text='<%# Eval("Period_From") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Period To">
                        <ItemTemplate>
                            <asp:Label ID="lblPeriodTo" runat="server" Text='<%# Eval("Period_To") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Marks Percentage">
                        <ItemTemplate>
                            <asp:Label ID="lblMarksPercentage" runat="server" Text='<%# Eval("Marks_Percentage") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="School College Institute Name">
                        <ItemTemplate>
                            <asp:Label ID="lblSchoolCollegeInstituteName" runat="server" Text='<%# Eval("School_College_Institute_Name") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Address">
                        <ItemTemplate>
                            <asp:Label ID="lblAddress" runat="server" Text='<%# Eval("Address") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Board University Name">
                        <ItemTemplate>
                            <asp:Label ID="lblBoardUniversityName" runat="server" Text='<%# Eval("Board_University_Name") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Remarks">
                        <ItemTemplate>
                            <asp:Label ID="lblRemarks" runat="server" Text='<%# Eval("Remarks") %>'></asp:Label>
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
        <%--</fieldset>--%>
    </asp:View>
    <asp:View ID="ViewEmployeeEducationalDetailControls" runat="server">
        <%--<fieldset><legend>Employee Educational Detail</legend>--%>
        <asp:HiddenField ID="hfSessionDataKey" runat="server" />
        <asp:HiddenField ID="hfIsControlsLoaded" runat="server" />
        <asp:HiddenField ID="hfEditIndexKey" runat="server" />
        <div id="dvClass" class="dvColumnLeft">
            <asp:Label ID="lblClass" runat="server" Text="Class Course"></asp:Label>
            <asp:DropDownList ID="ddlClass" runat="server" DataValueField="Class_Id"
                DataTextField="Class_Name">
            </asp:DropDownList>
        </div>
        <div id="dvStream" class="dvColumnRight">
            <asp:Label ID="lblStream" runat="server" Text="Stream Name"></asp:Label>
            <asp:DropDownList ID="ddlStream" runat="server" DataValueField="Stream_Id" DataTextField="Stream_Name">
            </asp:DropDownList>
        </div>
        <div id="dvPeriodFrom" class="dvColumnLeft">
            <asp:Label ID="lblPeriodFrom" runat="server" Text="Period From"></asp:Label>
            <asp:TextBox ID="txtPeriodFrom" runat="server"></asp:TextBox>
        </div>
        <div id="dvPeriodTo" class="dvColumnRight">
            <asp:Label ID="lblPeriodTo" runat="server" Text="Period To"></asp:Label>
            <asp:TextBox ID="txtPeriodTo" runat="server"></asp:TextBox>
        </div>
        <div id="dvMarksPercentage" class="dvColumnLeft">
            <asp:Label ID="lblMarksPercentage" runat="server" Text="Marks Percentage"></asp:Label>
            <asp:TextBox ID="txtMarksPercentage" runat="server"></asp:TextBox>
        </div>
        <div id="dvSchoolCollegeInstituteName" class="dvColumnRight">
            <asp:Label ID="lblSchoolCollegeInstituteName" runat="server" Text="School Name"></asp:Label>
            <asp:TextBox ID="txtSchoolCollegeInstituteName" runat="server"></asp:TextBox>
        </div>
        <div id="dvAddress" class="dvColumnLeft">
            <asp:Label ID="lblAddress" runat="server" Text="Address"></asp:Label>
            <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
        </div>
        <div id="dvBoardUniversityName" class="dvColumnRight">
            <asp:Label ID="lblBoardUniversityName" runat="server" Text="Board University Name"></asp:Label>
            <asp:TextBox ID="txtBoardUniversityName" runat="server"></asp:TextBox>
        </div>
        <div id="dvRemarks" class="dvColumnLeft">
            <asp:Label ID="lblRemarks" runat="server" Text="Remarks"></asp:Label>
            <asp:TextBox ID="txtRemarks" runat="server"></asp:TextBox>
        </div>
        <%--</fieldset>--%>
        <div style="float: left;width:100%;text-align:right;">
            <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Add" />
            <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Cancel" />
        </div>
    </asp:View>
</asp:MultiView>
<asp:Label ID="lblMessage" runat="server" EnableViewState="False"></asp:Label>
