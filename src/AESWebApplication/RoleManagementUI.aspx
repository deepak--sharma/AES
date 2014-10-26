<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="RoleManagementUI.aspx.cs" Inherits="RoleManagementUI" MasterPageFile="~/MasterPage/MainMasterPage.master"%>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="Server">
	<title>RoleManagement Page</title>
</asp:Content>
		<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
		<div>
			<asp:MultiView ID="MultiViewRoleManagement" runat="server" ActiveViewIndex="0" > 
				<asp:View ID="ViewRoleManagementGrid" runat="server">
				<fieldset><legend>Role Management List</legend>
					<asp:Button ID="btnAddNewRecord" runat="server" Text="Add New Record" OnClick="btnAddNewRecord_Click" />
					<asp:Label ID="lblViewOnly" runat="server" Text="View only - "></asp:Label>
					<asp:RadioButton ID="rdbActiveRecord" runat="server" Text="Live Records" GroupName="DisplayMode" AutoPostBack="True" Checked="True" OnCheckedChanged="rdbActiveRecord_CheckedChanged" />
					<asp:RadioButton ID="rdbInActiveRecord" runat="server" Text="Deleted Records" GroupName="DisplayMode" AutoPostBack="True" OnCheckedChanged="rdbInActiveRecord_CheckedChanged" />
					<asp:GridView ID="grdRoleManagement" runat="server" DataKeyNames="Role_Id,Version" AllowPaging="True" OnRowDeleting="grdRoleManagement_RowDeleting" OnPageIndexChanging="grdRoleManagement_PageIndexChanging"
						AutoGenerateColumns="False" EmptyDataText="No Record Found" OnRowEditing="grdRoleManagement_ActivatingObject" OnSelectedIndexChanged="grdRoleManagement_SelectedIndexChanged">
					<Columns>
						<asp:CommandField ShowSelectButton="True" SelectText="Select" HeaderText="Select"/>
						<asp:CommandField ShowEditButton="True" EditText="Activate" HeaderText="Activate" Visible="false"/>
						<asp:CommandField ShowDeleteButton="True" DeleteText="Delete" HeaderText="Delete"/>
						<asp:TemplateField HeaderText="Role Name" >
							<ItemTemplate>
								<asp:Label ID="lblRoleName" runat="server" Text='<%# Eval("Role_Name") %>'></asp:Label> 
							</ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Description" >
							<ItemTemplate>
								<asp:Label ID="lblDescription" runat="server" Text='<%# Eval("Description") %>'></asp:Label> 
							</ItemTemplate>
						</asp:TemplateField>
					</Columns>
					</asp:GridView>
				</fieldset>
				</asp:View>
				<asp:View ID="ViewRoleManagementControls" runat="server">
				<fieldset><legend>Role Management</legend>
					<div id="dvRoleName" class="dvColumnLeft">
					<asp:Label ID="lblRoleName" runat="server" Text="Role Name"></asp:Label> 
					<asp:TextBox ID="txtRoleName" runat="server"></asp:TextBox>
					</div>
					<div id="dvDescription" class="dvColumnRight">
					<asp:Label ID="lblDescription" runat="server" Text="Description"></asp:Label> 
					<asp:TextBox ID="txtDescription" runat="server"></asp:TextBox>
					</div>
				</fieldset>

				<asp:Button ID="btnSave" runat="server" Enabled="False" OnClick="btnSave_Click" Text="Save Record" />
				<asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit Record" />
				<asp:Button ID="btnCancelRollback" runat="server" OnClick="btnCancelRollback_Click" Text="Cancel / Rollback" />
				</asp:View>
			</asp:MultiView>
			<asp:Label ID="lblMessage" runat="server" EnableViewState="False"></asp:Label>
		</div>
</asp:Content>
