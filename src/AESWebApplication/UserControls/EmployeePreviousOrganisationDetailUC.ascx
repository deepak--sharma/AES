<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EmployeePreviousOrganisationDetailUC.ascx.cs"
    Inherits="EmployeePreviousOrganisationDetailUC" %>
<asp:MultiView ID="MultiViewEmployeePreviousOrganisationDetail" runat="server" ActiveViewIndex="0">
    <asp:View ID="ViewEmployeePreviousOrganisationDetailGrid" runat="server">
        <%--<fieldset><legend>Employee Previous Organisation Detail List</legend>--%>
         <div style="width: 750px; overflow: auto;">
        <asp:Button ID="btnAddRecord" runat="server" Text="Add Record" OnClick="btnAddRecord_Click" style="margin:0px 0px 0px 0px" />
        <asp:GridView ID="grdEmployeePreviousOrganisationDetail" runat="server" DataKeyNames="Employee_Previous_Org_Detail_Id,Currency_Id"
            AllowPaging="True" OnRowDeleting="grdEmployeePreviousOrganisationDetail_RowDeleting"
            OnPageIndexChanging="grdEmployeePreviousOrganisationDetail_PageIndexChanging"
            AutoGenerateColumns="False" EmptyDataText="No Record Found" OnSelectedIndexChanged="grdEmployeePreviousOrganisationDetail_SelectedIndexChanged">
            <Columns>
                <asp:CommandField ShowSelectButton="True" SelectText="Select" HeaderText="Select" />
                <asp:CommandField ShowDeleteButton="True" DeleteText="Delete" HeaderText="Delete" />
                <asp:TemplateField HeaderText="Organisation Name">
                    <ItemTemplate>
                        <asp:Label ID="lblOrganisationName" runat="server" Text='<%# Eval("Organisation_Name") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
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
                <asp:TemplateField HeaderText="Ctc">
                    <ItemTemplate>
                        <asp:Label ID="lblCtc" runat="server" Text='<%# Eval("CTC") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Entry Designation">
                    <ItemTemplate>
                        <asp:Label ID="lblEntryDesignation" runat="server" Text='<%# Eval("Entry_Designation") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Exit Designation">
                    <ItemTemplate>
                        <asp:Label ID="lblExitDesignation" runat="server" Text='<%# Eval("Exit_Designation") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Supervisor Name">
                    <ItemTemplate>
                        <asp:Label ID="lblSupervisorName" runat="server" Text='<%# Eval("Supervisor_Name") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Supervisor Contact">
                    <ItemTemplate>
                        <asp:Label ID="lblSupervisorContact" runat="server" Text='<%# Eval("Supervisor_Contact") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Supervisor Designation">
                    <ItemTemplate>
                        <asp:Label ID="lblSupervisorDesignation" runat="server" Text='<%# Eval("Supervisor_Designation") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Supervisor Designation">
                    <ItemTemplate>
                        <asp:Label ID="lblSupervisorDesignation" runat="server" Text='<%# Eval("Organisation_Address") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Department">
                    <ItemTemplate>
                        <asp:Label ID="lblDepartment" runat="server" Text='<%# Eval("Department") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Nature Of Work">
                    <ItemTemplate>
                        <asp:Label ID="lblNatureOfWork" runat="server" Text='<%# Eval("Nature_Of_Work") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Web Address">
                    <ItemTemplate>
                        <asp:Label ID="lblWebAddress" runat="server" Text='<%# Eval("Web_Address") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Reason For Leaving">
                    <ItemTemplate>
                        <asp:Label ID="lblReasonForLeaving" runat="server" Text='<%# Eval("Reason_For_Leaving") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Recent Order">
                    <ItemTemplate>
                        <asp:Label ID="lblRecentOrder" runat="server" Text='<%# Eval("Recent_Order") %>'></asp:Label>
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
    <asp:View ID="ViewEmployeePreviousOrganisationDetailControls" runat="server">
        <%--<fieldset><legend>Employee Previous Organisation Detail</legend>--%>
        <asp:HiddenField ID="hfSessionDataKey" runat="server" />
        <asp:HiddenField ID="hfIsControlsLoaded" runat="server" />
        <asp:HiddenField ID="hfEditIndexKey" runat="server" />
        <div id="dvOrganisationName" class="dvColumnLeft">
            <asp:Label ID="lblOrganisationName" runat="server" Text="Organisation Name"></asp:Label>
            <asp:TextBox ID="txtOrganisationName" runat="server"></asp:TextBox>
        </div>
        <div id="dvPeriodFrom" class="dvColumnRight">
            <asp:Label ID="lblPeriodFrom" runat="server" Text="Period From"></asp:Label>
            <asp:TextBox ID="txtPeriodFrom" runat="server"></asp:TextBox>
        </div>
        <div id="dvPeriodTo" class="dvColumnLeft">
            <asp:Label ID="lblPeriodTo" runat="server" Text="Period To"></asp:Label>
            <asp:TextBox ID="txtPeriodTo" runat="server"></asp:TextBox>
        </div>
        <div id="dvCtc" class="dvColumnRight">
            <asp:Label ID="lblCtc" runat="server" Text="Ctc"></asp:Label>
            <asp:TextBox ID="txtCtc" runat="server"></asp:TextBox>
        </div>
        <div id="dvCurrency" class="dvColumnLeft">
            <asp:Label ID="lblCurrency" runat="server" Text="Currency"></asp:Label>
            <asp:DropDownList ID="ddlCurrency" runat="server" DataValueField="Metadata_Id" DataTextField="Metadata_Name">
            </asp:DropDownList>
        </div>
        <div id="dvEntryDesignation" class="dvColumnRight">
            <asp:Label ID="lblEntryDesignation" runat="server" Text="Entry Designation"></asp:Label>
            <asp:TextBox ID="txtEntryDesignation" runat="server"></asp:TextBox>
        </div>
        <div id="dvExitDesignation" class="dvColumnLeft">
            <asp:Label ID="lblExitDesignation" runat="server" Text="Exit Designation"></asp:Label>
            <asp:TextBox ID="txtExitDesignation" runat="server"></asp:TextBox>
        </div>
        <div id="dvSupervisorName" class="dvColumnRight">
            <asp:Label ID="lblSupervisorName" runat="server" Text="Supervisor Name"></asp:Label>
            <asp:TextBox ID="txtSupervisorName" runat="server"></asp:TextBox>
        </div>
        <div id="dvSupervisorContact" class="dvColumnLeft">
            <asp:Label ID="lblSupervisorContact" runat="server" Text="Supervisor Contact"></asp:Label>
            <asp:TextBox ID="txtSupervisorContact" runat="server"></asp:TextBox>
        </div>
        <div id="dvSupervisorDesignation" class="dvColumnRight">
            <asp:Label ID="lblSupervisorDesignation" runat="server" Text="Supervisor Designation"></asp:Label>
            <asp:TextBox ID="txtSupervisorDesignation" runat="server"></asp:TextBox>
        </div>
        <div id="dvDepartment" class="dvColumnLeft">
            <asp:Label ID="lblDepartment" runat="server" Text="Department"></asp:Label>
            <asp:TextBox ID="txtDepartment" runat="server"></asp:TextBox>
        </div>
        <div id="dvNatureOfWork" class="dvColumnRight">
            <asp:Label ID="lblNatureOfWork" runat="server" Text="Nature Of Work"></asp:Label>
            <asp:TextBox ID="txtNatureOfWork" runat="server"></asp:TextBox>
        </div>
        <div id="dvOrganisation" class="dvColumnLeft">
            <asp:Label ID="lblOrganisation" runat="server" Text="Organisation Address"></asp:Label>
            <asp:TextBox ID="txtOrganisation" runat="server"></asp:TextBox>
        </div>
        <div id="dvWebAddress" class="dvColumnRight">
            <asp:Label ID="lblWebAddress" runat="server" Text="Web Address"></asp:Label>
            <asp:TextBox ID="txtWebAddress" runat="server"></asp:TextBox>
        </div>
        <div id="dvReasonForLeaving" class="dvColumnLeft">
            <asp:Label ID="lblReasonForLeaving" runat="server" Text="Reason For Leaving"></asp:Label>
            <asp:TextBox ID="txtReasonForLeaving" runat="server"></asp:TextBox>
        </div>
        <div id="dvRecentOrder" class="dvColumnRight">
            <asp:Label ID="lblRecentOrder" runat="server" Text="Recent Order"></asp:Label>
            <asp:TextBox ID="txtRecentOrder" runat="server"></asp:TextBox>
        </div>
        <%--</fieldset>--%>
        <div style="float:left; width:100%;text-align:right;">
        <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Add" />
        <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Cancel" />
        </div>
    </asp:View>
</asp:MultiView>
<asp:Label ID="lblMessage" runat="server" EnableViewState="False"></asp:Label>
