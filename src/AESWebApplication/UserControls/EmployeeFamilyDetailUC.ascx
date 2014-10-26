<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EmployeeFamilyDetailUC.ascx.cs"
    Inherits="EmployeeFamilyDetailUC" %>
<asp:MultiView ID="MultiViewEmployeeFamilyDetail" runat="server" ActiveViewIndex="0">
    <asp:View ID="ViewEmployeeFamilyDetailGrid" runat="server">
        <%--  <fieldset>
            <legend>Employee Family Detail List</legend>--%>
        <asp:Button ID="btnAddRecord" runat="server" Text="Add Record" OnClick="btnAddRecord_Click" />
        <div style="width: 750px; overflow: auto;">
            <asp:GridView ID="grdEmployeeFamilyDetail" runat="server" DataKeyNames="Employee_Family_Id,Gender_Id,Relation_Id,Nationality_Id"
                AllowPaging="True" OnRowDeleting="grdEmployeeFamilyDetail_RowDeleting" OnPageIndexChanging="grdEmployeeFamilyDetail_PageIndexChanging"
                AutoGenerateColumns="False" EmptyDataText="No Record Found" OnSelectedIndexChanged="grdEmployeeFamilyDetail_SelectedIndexChanged">
                <Columns>
                    <asp:CommandField ShowSelectButton="True" SelectText="Select" HeaderText="Select" />
                    <asp:CommandField ShowDeleteButton="True" DeleteText="Delete" HeaderText="Delete" />
                    <asp:TemplateField HeaderText="Full Name">
                        <ItemTemplate>
                            <asp:Label ID="lblFullName" runat="server" Text='<%# Eval("First_Name") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Date Of Birth">
                        <ItemTemplate>
                            <asp:Label ID="lblDateOfBirth" runat="server" Text='<%# Eval("Date_Of_Birth") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Is Dependent">
                        <ItemTemplate>
                            <asp:Label ID="lblIsDependent" runat="server" Text='<%# Eval("Is_Dependent") %>'></asp:Label>
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
        <%-- </fieldset>--%>
    </asp:View>
    <asp:View ID="ViewEmployeeFamilyDetailControls" runat="server">
        <%--<fieldset>
            <legend>Employee Family Detail</legend>--%>
        <asp:HiddenField ID="hfSessionDataKey" runat="server" />
        <asp:HiddenField ID="hfIsControlsLoaded" runat="server" />
        <asp:HiddenField ID="hfEditIndexKey" runat="server" />
        <div id="dvFirstName" class="dvColumnLeft">
            <asp:Label ID="lblFirstName" runat="server" Text="Full Name"></asp:Label>
            <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
        </div>
        <div id="dvGender" class="dvColumnRight">
            <asp:Label ID="lblGender" runat="server" Text="Gender"></asp:Label>
            <asp:DropDownList ID="ddlGender" runat="server" DataValueField="Metadata_Id" DataTextField="Metadata_Name">
            </asp:DropDownList>
        </div>
        <div id="dvRelation" class="dvColumnLeft">
            <asp:Label ID="lblRelation" runat="server" Text="Relation"></asp:Label>
            <asp:DropDownList ID="ddlRelation" runat="server" DataValueField="Metadata_Id" DataTextField="Metadata_Name">
            </asp:DropDownList>
        </div>
        <div id="dvDateOfBirth" class="dvColumnRight">
            <asp:Label ID="lblDateOfBirth" runat="server" Text="Date Of Birth"></asp:Label>
            <asp:TextBox ID="txtDateOfBirth" runat="server"></asp:TextBox>
        </div>
        <div id="dvNationality" class="dvColumnRight">
            <asp:Label ID="lblNationality" runat="server" Text="Nationality"></asp:Label>
            <asp:DropDownList ID="ddlNationality" runat="server" DataValueField="Metadata_Id"
                DataTextField="Metadata_Name">
            </asp:DropDownList>
        </div>
        <div id="dvIsDependent" class="dvColumnLeft">
            <asp:Label ID="lblIsDependent" runat="server" Text="Is Dependent"></asp:Label>
            <asp:CheckBox ID="chkIsDependent" runat="server"></asp:CheckBox>
        </div>
        <%--</fieldset>--%>
        <div style="float: left;width:100%;text-align:right;">
            <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Add" />
            <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Cancel" />
        </div>
    </asp:View>
</asp:MultiView>
<asp:Label ID="lblMessage" runat="server" EnableViewState="False"></asp:Label>
