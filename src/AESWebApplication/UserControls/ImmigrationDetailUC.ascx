<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ImmigrationDetailUC.ascx.cs"
    Inherits="ImmigrationDetailUC" %>
<asp:MultiView ID="MultiViewImmigrationDetail" runat="server" ActiveViewIndex="0">
    <asp:View ID="ViewImmigrationDetailGrid" runat="server">
        <%-- <fieldset>
            <legend>Immigration Detail List</legend>--%>
        <div style="width: 750px; overflow: auto;">
            <asp:Button ID="btnAddRecord" runat="server" Text="Add Record" OnClick="btnAddRecord_Click" Style="margin:0px 0px 0px 0px;" />
            <asp:GridView ID="grdImmigrationDetail" runat="server" DataKeyNames="Immigration_ID,Member_Type_ID,Status_Id"
                AllowPaging="True" OnRowDeleting="grdImmigrationDetail_RowDeleting" OnPageIndexChanging="grdImmigrationDetail_PageIndexChanging"
                AutoGenerateColumns="False" EmptyDataText="No Record Found" OnSelectedIndexChanged="grdImmigrationDetail_SelectedIndexChanged">
                <Columns>
                    <asp:CommandField ShowSelectButton="True" SelectText="Select" HeaderText="Select" />
                    <asp:CommandField ShowDeleteButton="True" DeleteText="Delete" HeaderText="Delete" />
                    <asp:TemplateField HeaderText="Passport No">
                        <ItemTemplate>
                            <asp:Label ID="lblPassportNo" runat="server" Text='<%# Eval("Passport_No") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Passport Detail">
                        <ItemTemplate>
                            <asp:Label ID="lblPassportDetail" runat="server" Text='<%# Eval("Passport_Detail") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Issue Date">
                        <ItemTemplate>
                            <asp:Label ID="lblIssueDate" runat="server" Text='<%# Eval("Issue_Date") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Expiry Date">
                        <ItemTemplate>
                            <asp:Label ID="lblExpiryDate" runat="server" Text='<%# Eval("Expiry_Date") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Revise Date">
                        <ItemTemplate>
                            <asp:Label ID="lblReviseDate" runat="server" Text='<%# Eval("Revise_Date") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Sponsor">
                        <ItemTemplate>
                            <asp:Label ID="lblSponsor" runat="server" Text='<%# Eval("Sponsor") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Comment">
                        <ItemTemplate>
                            <asp:Label ID="lblComment" runat="server" Text='<%# Eval("Comment") %>'></asp:Label>
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
    <asp:View ID="ViewImmigrationDetailControls" runat="server">
        <%-- <fieldset>
            <legend>Immigration Detail</legend>--%>
        <asp:HiddenField ID="hfSessionDataKey" runat="server" />
        <asp:HiddenField ID="hfIsControlsLoaded" runat="server" />
        <asp:HiddenField ID="hfEditIndexKey" runat="server" />
        <div id="dvPassportNo" class="dvColumnLeft">
            <asp:Label ID="lblPassportNo" runat="server" Text="Passport No"></asp:Label>
            <asp:TextBox ID="txtPassportNo" runat="server"></asp:TextBox>
        </div>
        <div id="dvPassportDetail" class="dvColumnRight">
            <asp:Label ID="lblPassportDetail" runat="server" Text="Passport Detail"></asp:Label>
            <asp:TextBox ID="txtPassportDetail" runat="server"></asp:TextBox>
        </div>
        <div id="dvIssueDate" class="dvColumnLeft">
            <asp:Label ID="lblIssueDate" runat="server" Text="Issue Date"></asp:Label>
            <asp:TextBox ID="txtIssueDate" runat="server"></asp:TextBox>
        </div>
        <div id="dvExpiryDate" class="dvColumnRight">
            <asp:Label ID="lblExpiryDate" runat="server" Text="Expiry Date"></asp:Label>
            <asp:TextBox ID="txtExpiryDate" runat="server"></asp:TextBox>
        </div>
        <div id="dvReviseDate" class="dvColumnLeft">
            <asp:Label ID="lblReviseDate" runat="server" Text="Revise Date"></asp:Label>
            <asp:TextBox ID="txtReviseDate" runat="server"></asp:TextBox>
        </div>
        <div id="dvSponsor" class="dvColumnRight">
            <asp:Label ID="lblSponsor" runat="server" Text="Sponsor"></asp:Label>
            <asp:TextBox ID="txtSponsor" runat="server"></asp:TextBox>
        </div>
        <div id="dvStatus" class="dvColumnLeft">
            <asp:Label ID="lblStatus" runat="server" Text="Status"></asp:Label>
            <asp:DropDownList ID="ddlStatus" runat="server" DataValueField="Metadata_Id" DataTextField="Metadata_Name">
            </asp:DropDownList>
        </div>
        <div id="dvComment" class="dvColumnRight">
            <asp:Label ID="lblComment" runat="server" Text="Comment"></asp:Label>
            <asp:TextBox ID="txtComment" runat="server"></asp:TextBox>
        </div>
        <%--</fieldset>--%>
        <div style="float: left;width:100%;text-align:right;">
            <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Add" />
            <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Cancel" />
        </div>
    </asp:View>
</asp:MultiView>
<asp:Label ID="lblMessage" runat="server" EnableViewState="False"></asp:Label>
