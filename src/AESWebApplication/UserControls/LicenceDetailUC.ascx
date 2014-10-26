<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LicenceDetailUC.ascx.cs"
    Inherits="LicenceDetailUC" %>
<asp:MultiView ID="MultiViewLicenceDetail" runat="server" ActiveViewIndex="0">
    <asp:View ID="ViewLicenceDetailGrid" runat="server">
        <%--<fieldset>
            <legend>Licence Detail List</legend>--%>
        <div style="width: 750px; overflow: auto;">
            <asp:Button ID="btnAddRecord" runat="server" Text="Add Record" OnClick="btnAddRecord_Click" style="margin:0px 0px 0px 0px;" />
            <asp:GridView ID="grdLicenceDetail" runat="server" DataKeyNames="Licence_Detail_ID,Member_Type_Id,Licence_Type_Id"
                AllowPaging="True" OnRowDeleting="grdLicenceDetail_RowDeleting" OnPageIndexChanging="grdLicenceDetail_PageIndexChanging"
                AutoGenerateColumns="False" EmptyDataText="No Record Found" OnSelectedIndexChanged="grdLicenceDetail_SelectedIndexChanged">
                <Columns>
                    <asp:CommandField ShowSelectButton="True" SelectText="Select" HeaderText="Select" />
                    <asp:CommandField ShowDeleteButton="True" DeleteText="Delete" HeaderText="Delete" />
                    <asp:TemplateField HeaderText="Licence Number">
                        <ItemTemplate>
                            <asp:Label ID="lblLicenceNumber" runat="server" Text='<%# Eval("Licence_Number") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Issue Date">
                        <ItemTemplate>
                            <asp:Label ID="lblIssueDate" runat="server" Text='<%# Eval("Issue_Date") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Exp Date">
                        <ItemTemplate>
                            <asp:Label ID="lblExpDate" runat="server" Text='<%# Eval("Exp_Date") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Comments">
                        <ItemTemplate>
                            <asp:Label ID="lblComments" runat="server" Text='<%# Eval("Comments") %>'></asp:Label>
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
        <%--  </fieldset>--%>
    </asp:View>
    <asp:View ID="ViewLicenceDetailControls" runat="server">
        <%--<fieldset>
            <legend>Licence Detail</legend>--%>
        <asp:HiddenField ID="hfSessionDataKey" runat="server" />
        <asp:HiddenField ID="hfIsControlsLoaded" runat="server" />
        <asp:HiddenField ID="hfEditIndexKey" runat="server" />
        <div id="dvLicence" class="dvColumnLeft">
            <asp:Label ID="lblLicence" runat="server" Text="Licence Type"></asp:Label>
            <asp:DropDownList ID="ddlLicence" runat="server" DataValueField="Metadata_Id" DataTextField="Metadata_Name">
            </asp:DropDownList>
        </div>
        <div id="dvLicenceNumber" class="dvColumnRight">
            <asp:Label ID="lblLicenceNumber" runat="server" Text="Licence Number"></asp:Label>
            <asp:TextBox ID="txtLicenceNumber" runat="server"></asp:TextBox>
        </div>
        <div id="dvIssueDate" class="dvColumnLeft">
            <asp:Label ID="lblIssueDate" runat="server" Text="Issue Date"></asp:Label>
            <asp:TextBox ID="txtIssueDate" runat="server"></asp:TextBox>
        </div>
        <div id="dvExpDate" class="dvColumnRight">
            <asp:Label ID="lblExpDate" runat="server" Text="Exp Date"></asp:Label>
            <asp:TextBox ID="txtExpDate" runat="server"></asp:TextBox>
        </div>
        <div id="dvComments" class="dvColumnLeft">
            <asp:Label ID="lblComments" runat="server" Text="Comments"></asp:Label>
            <asp:TextBox ID="txtComments" runat="server"></asp:TextBox>
        </div>
        <%--</fieldset>--%>
        
        <div style="float: left;width:100%;text-align:right;">
            <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Add" />
            <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Cancel" />
        </div>
    </asp:View>
</asp:MultiView>
<asp:Label ID="lblMessage" runat="server" EnableViewState="False"></asp:Label>
