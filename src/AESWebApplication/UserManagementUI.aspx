<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserManagementUI.aspx.cs"
    Inherits="UserManagementUI" MasterPageFile="~/MasterPage/MainMasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="Server">
    <title>UserManagement Page</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div>
        <asp:MultiView ID="MultiViewUserManagement" runat="server" ActiveViewIndex="0">
            <asp:View ID="ViewUserManagementGrid" runat="server">
                <fieldset>
                    <legend>User Management List</legend>
                    <asp:Button ID="btnAddNewRecord" runat="server" Text="Add New Record" OnClick="btnAddNewRecord_Click" />
                    <asp:Label ID="lblViewOnly" runat="server" Text="View only - "></asp:Label>
                    <asp:RadioButton ID="rdbActiveRecord" runat="server" Text="Live Records" GroupName="DisplayMode"
                        AutoPostBack="True" Checked="True" OnCheckedChanged="rdbActiveRecord_CheckedChanged" />
                    <asp:RadioButton ID="rdbInActiveRecord" runat="server" Text="Deleted Records" GroupName="DisplayMode"
                        AutoPostBack="True" OnCheckedChanged="rdbInActiveRecord_CheckedChanged" />
                    <asp:GridView ID="grdUserManagement" runat="server" DataKeyNames="User_Id,Version"
                        AllowPaging="True" OnRowDeleting="grdUserManagement_RowDeleting" OnPageIndexChanging="grdUserManagement_PageIndexChanging"
                        AutoGenerateColumns="False" EmptyDataText="No Record Found" OnRowEditing="grdUserManagement_ActivatingObject"
                        OnSelectedIndexChanged="grdUserManagement_SelectedIndexChanged">
                        <Columns>
                            <asp:CommandField ShowSelectButton="True" SelectText="Select" HeaderText="Select" />
                            <asp:CommandField ShowEditButton="True" EditText="Activate" HeaderText="Activate"
                                Visible="false" />
                            <asp:CommandField ShowDeleteButton="True" DeleteText="Delete" HeaderText="Delete" />
                            <asp:TemplateField HeaderText="User Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblUserName" runat="server" Text='<%# Eval("User_Name") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Password">
                                <ItemTemplate>
                                    <asp:Label ID="lblPassword" runat="server" Text='<%# Eval("Password") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Last Login">
                                <ItemTemplate>
                                    <asp:Label ID="lblLastLogin" runat="server" Text='<%# Eval("Last_Login") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Status">
                                <ItemTemplate>
                                    <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("Status") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </fieldset>
            </asp:View>
            <asp:View ID="ViewUserManagementControls" runat="server">
                <fieldset>
                    <legend>User Management</legend>
                    <div id="UserForm">
                        <div id="dvUserName" class="dvColumnLeft">
                            <asp:Label ID="lblUserName" runat="server" Text="User Name"></asp:Label>
                            <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
                        </div>
                        <div id="dvPassword" class="dvColumnRight">
                            <asp:Label ID="lblPassword" runat="server" Text="Password"></asp:Label>
                            <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
                        </div>
                        <div id="dvUser" class="dvColumnLeft">
                            <asp:Label ID="lblUser" runat="server" Text="User Type"></asp:Label>
                            <asp:DropDownList ID="ddlUser" runat="server" DataValueField="Metadata_Id" DataTextField="Metadata_Name">
                            </asp:DropDownList>
                        </div>
                        <div id="dvLastLogin" class="dvColumnRight">
                            <asp:Label ID="lblLastLogin" runat="server" Text="Last Login"></asp:Label>
                            <asp:TextBox ID="txtLastLogin" runat="server"></asp:TextBox>
                        </div>
                        <div id="dvStatus" class="dvColumnLeft">
                            <asp:Label ID="lblStatus" runat="server" Text="Status"></asp:Label>
                            <asp:DropDownList ID="ddlStatus" runat="server">
                                <asp:ListItem Value="-Select-">-Select-</asp:ListItem>
                                <asp:ListItem Value="True">True</asp:ListItem>
                                <asp:ListItem Value="False">False</asp:ListItem>
                            </asp:DropDownList>
                        </div>
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
