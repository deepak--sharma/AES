<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SectionMasterUI.aspx.cs"
    Inherits="SectionMasterUI" MasterPageFile="~/MasterPage/MainMasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="Server">
    <title>SectionMaster Page</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div>
        <asp:MultiView ID="MultiViewSectionMaster" runat="server" ActiveViewIndex="0">
            <asp:View ID="ViewSectionMasterGrid" runat="server">
                <fieldset>
                    <legend>Section Master List</legend>
                    <asp:Button ID="btnAddNewRecord" runat="server" Text="Add New Record" OnClick="btnAddNewRecord_Click" />
                    <asp:Label ID="lblViewOnly" runat="server" Text="View only - "></asp:Label>
                    <asp:RadioButton ID="rdbActiveRecord" runat="server" Text="Live Records" GroupName="DisplayMode"
                        AutoPostBack="True" Checked="True" OnCheckedChanged="rdbActiveRecord_CheckedChanged" />
                    <asp:RadioButton ID="rdbInActiveRecord" runat="server" Text="Deleted Records" GroupName="DisplayMode"
                        AutoPostBack="True" OnCheckedChanged="rdbInActiveRecord_CheckedChanged" />
                    <asp:GridView ID="grdSectionMaster" runat="server" DataKeyNames="Section_Id,Version"
                        AllowPaging="True" OnRowDeleting="grdSectionMaster_RowDeleting" OnPageIndexChanging="grdSectionMaster_PageIndexChanging"
                        AutoGenerateColumns="False" EmptyDataText="No Record Found" OnRowEditing="grdSectionMaster_ActivatingObject"
                        OnSelectedIndexChanged="grdSectionMaster_SelectedIndexChanged">
                        <Columns>
                            <asp:CommandField ShowSelectButton="True" SelectText="Select" HeaderText="Select" />
                            <asp:CommandField ShowEditButton="True" EditText="Activate" HeaderText="Activate"
                                Visible="false" />
                            <asp:CommandField ShowDeleteButton="True" DeleteText="Delete" HeaderText="Delete" />                          
                            <asp:TemplateField HeaderText="Section Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblSectionName" runat="server" Text='<%# Eval("Section_Name") %>'></asp:Label>
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
            <asp:View ID="ViewSectionMasterControls" runat="server">
                <fieldset>
                    <legend>Section Master</legend>                  
                    <div id="dvSectionName" class="dvColumnLeft">
                        <asp:Label ID="lblSectionName" runat="server" Text="Section Name"></asp:Label>
                        <asp:TextBox ID="txtSectionName" runat="server"></asp:TextBox>
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
