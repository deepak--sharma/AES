<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="DepartmentMasterUI.aspx.cs" Inherits="DepartmentMasterUI" MasterPageFile="~/MasterPage/MainMasterPage.master"%>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="Server">
	<title>DepartmentMaster Page</title>
</asp:Content>
		<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
		<div>
			<asp:MultiView ID="MultiViewDepartmentMaster" runat="server" ActiveViewIndex="0" > 
				<asp:View ID="ViewDepartmentMasterGrid" runat="server">
				<fieldset><legend>Department Master List</legend>
					<asp:Button ID="btnAddNewRecord" runat="server" Text="Add New Record" OnClick="btnAddNewRecord_Click" />
					<asp:Label ID="lblViewOnly" runat="server" Text="View only - "></asp:Label>
					<asp:RadioButton ID="rdbActiveRecord" runat="server" Text="Live Records" GroupName="DisplayMode" AutoPostBack="True" Checked="True" OnCheckedChanged="rdbActiveRecord_CheckedChanged" />
					<asp:RadioButton ID="rdbInActiveRecord" runat="server" Text="Deleted Records" GroupName="DisplayMode" AutoPostBack="True" OnCheckedChanged="rdbInActiveRecord_CheckedChanged" />
					<asp:GridView ID="grdDepartmentMaster" runat="server" DataKeyNames="Department_Id,Version" AllowPaging="True" OnRowDeleting="grdDepartmentMaster_RowDeleting" OnPageIndexChanging="grdDepartmentMaster_PageIndexChanging"
						AutoGenerateColumns="False" EmptyDataText="No Record Found" OnRowEditing="grdDepartmentMaster_ActivatingObject" OnSelectedIndexChanged="grdDepartmentMaster_SelectedIndexChanged">
					<Columns>
						<asp:CommandField ShowSelectButton="True" SelectText="Select" HeaderText="Select"/>
						<asp:CommandField ShowEditButton="True" EditText="Activate" HeaderText="Activate" Visible="false"/>
						<asp:CommandField ShowDeleteButton="True" DeleteText="Delete" HeaderText="Delete"/>
						<asp:TemplateField HeaderText="Department Code" >
							<ItemTemplate>
								<asp:Label ID="lblDepartmentCode" runat="server" Text='<%# Eval("Department_Code") %>'></asp:Label> 
							</ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Department Name" >
							<ItemTemplate>
								<asp:Label ID="lblDepartmentName" runat="server" Text='<%# Eval("Department_Name") %>'></asp:Label> 
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
				<asp:View ID="ViewDepartmentMasterControls" runat="server">
				<fieldset><legend>Department Master</legend>
					<div id="dvDepartmentCode" class="dvColumnLeft">
					<asp:Label ID="lblDepartmentCode" runat="server" Text="Department Code"></asp:Label> 
					<asp:TextBox ID="txtDepartmentCode" runat="server"></asp:TextBox>
					</div>
					<div id="dvDepartmentName" class="dvColumnRight">
					<asp:Label ID="lblDepartmentName" runat="server" Text="Department Name"></asp:Label> 
					<asp:TextBox ID="txtDepartmentName" runat="server"></asp:TextBox>
					</div>
					<div id="dvDescription" class="dvColumnLeft">
					<asp:Label ID="lblDescription" runat="server" Text="Description"></asp:Label> 
					<asp:TextBox ID="txtDescription" runat="server"></asp:TextBox>
					</div>
					<div id="dvHod" class="dvColumnRight">
					<asp:Label ID="lblHod" runat="server" Text="First Name"></asp:Label> 
					<asp:DropDownList ID="ddlHod" runat="server" DataValueField="Employee_Id" DataTextField="First_Name" ></asp:DropDownList> 
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
