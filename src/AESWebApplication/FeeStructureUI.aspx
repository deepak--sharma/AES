<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FeeStructureUI.aspx.cs" Inherits="FeeStructureUI"
    MasterPageFile="~/MasterPage/MainMasterPage.master" %>

<%@ Register Src="UserControls/FeeSetupUC.ascx" TagName="FeeSetupUC" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="Server">
    <title>FeeStructure Page</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div id="divContainer">
        <asp:MultiView ID="MultiViewFeeStructure" runat="server" ActiveViewIndex="0">
            <asp:View ID="ViewFeeStructureGrid" runat="server">
                <fieldset>
                    <legend>Fee Structure List</legend>
                    <asp:Button ID="btnAddNewRecord" runat="server" Text="Add New Record" OnClick="btnAddNewRecord_Click" />
                    <asp:Label ID="lblViewOnly" runat="server" Text="View only - "></asp:Label>
                    <asp:RadioButton ID="rdbActiveRecord" runat="server" Text="Live Records" GroupName="DisplayMode"
                        AutoPostBack="True" Checked="True" OnCheckedChanged="rdbActiveRecord_CheckedChanged" />
                    <asp:RadioButton ID="rdbInActiveRecord" runat="server" Text="Deleted Records" GroupName="DisplayMode"
                        AutoPostBack="True" OnCheckedChanged="rdbInActiveRecord_CheckedChanged" />
                    <asp:GridView ID="grdFeeStructure" runat="server" DataKeyNames="Fee_Structure_Id,Version"
                        AllowPaging="True" OnRowDeleting="grdFeeStructure_RowDeleting" OnPageIndexChanging="grdFeeStructure_PageIndexChanging"
                        AutoGenerateColumns="False" EmptyDataText="No Record Found" OnRowEditing="grdFeeStructure_ActivatingObject"
                        OnSelectedIndexChanged="grdFeeStructure_SelectedIndexChanged">
                        <Columns>
                            <asp:CommandField ShowSelectButton="True" SelectText="Select" HeaderText="Select" />
                            <asp:CommandField ShowEditButton="True" EditText="Activate" HeaderText="Activate"
                                Visible="false" />
                            <asp:CommandField ShowDeleteButton="True" DeleteText="Delete" HeaderText="Delete" />
                            <asp:TemplateField HeaderText="Fee Structure Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblFeeStructureName" runat="server" Text='<%# Eval("Fee_Structure_Name") %>'></asp:Label>
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
            <asp:View ID="ViewFeeStructureControls" runat="server">
                <fieldset>
                    <legend>Fee Structure</legend>
                    <div id="dvFeeStructureName" class="dvColumnLeft">
                        <asp:Label ID="lblFeeStructureName" runat="server" Text="Fee Structure Name"></asp:Label>
                        <asp:TextBox ID="txtFeeStructureName" runat="server"></asp:TextBox>
                    </div>
                    <div id="dvDescription" class="dvColumnRight">
                        <asp:Label ID="lblDescription" runat="server" Text="Description"></asp:Label>
                        <asp:TextBox ID="txtDescription" runat="server"></asp:TextBox>
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
