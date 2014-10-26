<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="UserRoleMappingUI.aspx.cs" Inherits="UserRoleMappingUI" MasterPageFile="~/MasterPage/MainMasterPage.master"%>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="Server">
	<title>UserRoleMapping Page</title>
</asp:Content>
		<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
		<div>
			<asp:MultiView ID="MultiViewUserRoleMapping" runat="server" ActiveViewIndex="0" > 
				<asp:View ID="ViewUserRoleMappingGrid" runat="server">
				<fieldset><legend>User Role Mapping List</legend>
					<asp:Button ID="btnAddNewRecord" runat="server" Text="Add New Record" OnClick="btnAddNewRecord_Click" />
					<asp:Label ID="lblViewOnly" runat="server" Text="View only - "></asp:Label>
					<asp:RadioButton ID="rdbActiveRecord" runat="server" Text="Live Records" GroupName="DisplayMode" AutoPostBack="True" Checked="True" OnCheckedChanged="rdbActiveRecord_CheckedChanged" />
					<asp:RadioButton ID="rdbInActiveRecord" runat="server" Text="Deleted Records" GroupName="DisplayMode" AutoPostBack="True" OnCheckedChanged="rdbInActiveRecord_CheckedChanged" />
					<asp:GridView ID="grdUserRoleMapping" runat="server" DataKeyNames="User_Role_Mapping_Id,Version" AllowPaging="True" OnRowDeleting="grdUserRoleMapping_RowDeleting" OnPageIndexChanging="grdUserRoleMapping_PageIndexChanging"
						AutoGenerateColumns="False" EmptyDataText="No Record Found" OnRowEditing="grdUserRoleMapping_ActivatingObject" OnSelectedIndexChanged="grdUserRoleMapping_SelectedIndexChanged">
					<Columns>
						<asp:CommandField ShowSelectButton="True" SelectText="Select" HeaderText="Select"/>
						<asp:CommandField ShowEditButton="True" EditText="Activate" HeaderText="Activate" Visible="false"/>
						<asp:CommandField ShowDeleteButton="True" DeleteText="Delete" HeaderText="Delete"/>
					</Columns>
					</asp:GridView>
				</fieldset>
				</asp:View>
				<asp:View ID="ViewUserRoleMappingControls" runat="server">
				<fieldset><legend>User Role Mapping</legend>
					<div id="dvUser" class="dvColumnLeft">
					<asp:Label ID="lblUser" runat="server" Text="User Name"></asp:Label> 
					<asp:DropDownList ID="ddlUser" runat="server" DataValueField="User_Id" DataTextField="User_Name" ></asp:DropDownList> 
					</div>
					<div id="dvRole" class="dvColumnRight">
					<asp:Label ID="lblRole" runat="server" Text="Role Name"></asp:Label> 
					<asp:DropDownList ID="ddlRole" runat="server" DataValueField="Role_Id" DataTextField="Role_Name" ></asp:DropDownList> 
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
