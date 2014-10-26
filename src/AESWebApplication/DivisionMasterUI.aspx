<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="DivisionMasterUI.aspx.cs" Inherits="DivisionMasterUI" MasterPageFile="~/MasterPage/MainMasterPage.master"%>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="Server">
	<title>DivisionMaster Page</title>
</asp:Content>
		<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
		<div>
			<asp:MultiView ID="MultiViewDivisionMaster" runat="server" ActiveViewIndex="0" > 
				<asp:View ID="ViewDivisionMasterGrid" runat="server">
				<fieldset><legend>Division Master List</legend>
					<asp:Button ID="btnAddNewRecord" runat="server" Text="Add New Record" OnClick="btnAddNewRecord_Click" />
					<asp:Label ID="lblViewOnly" runat="server" Text="View only - "></asp:Label>
					<asp:RadioButton ID="rdbActiveRecord" runat="server" Text="Live Records" GroupName="DisplayMode" AutoPostBack="True" Checked="True" OnCheckedChanged="rdbActiveRecord_CheckedChanged" />
					<asp:RadioButton ID="rdbInActiveRecord" runat="server" Text="Deleted Records" GroupName="DisplayMode" AutoPostBack="True" OnCheckedChanged="rdbInActiveRecord_CheckedChanged" />
					<asp:GridView ID="grdDivisionMaster" runat="server" DataKeyNames="Division_Id,Version" AllowPaging="True" OnRowDeleting="grdDivisionMaster_RowDeleting" OnPageIndexChanging="grdDivisionMaster_PageIndexChanging"
						AutoGenerateColumns="False" EmptyDataText="No Record Found" OnRowEditing="grdDivisionMaster_ActivatingObject" OnSelectedIndexChanged="grdDivisionMaster_SelectedIndexChanged">
					<Columns>
						<asp:CommandField ShowSelectButton="True" SelectText="Select" HeaderText="Select"/>
						<asp:CommandField ShowEditButton="True" EditText="Activate" HeaderText="Activate" Visible="false"/>
						<asp:CommandField ShowDeleteButton="True" DeleteText="Delete" HeaderText="Delete"/>
						<asp:TemplateField HeaderText="Division Code" >
							<ItemTemplate>
								<asp:Label ID="lblDivisionCode" runat="server" Text='<%# Eval("Division_Code") %>'></asp:Label> 
							</ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Division Name" >
							<ItemTemplate>
								<asp:Label ID="lblDivisionName" runat="server" Text='<%# Eval("Division_Name") %>'></asp:Label> 
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
				<asp:View ID="ViewDivisionMasterControls" runat="server">
				<fieldset><legend>Division Master</legend>
					<div id="dvDepartment" class="dvColumnLeft">
					<asp:Label ID="lblDepartment" runat="server" Text="Department Name"></asp:Label> 
					<asp:DropDownList ID="ddlDepartment" runat="server" DataValueField="Department_Id" DataTextField="Department_Name" ></asp:DropDownList> 
					</div>
					<div id="dvDivisionCode" class="dvColumnRight">
					<asp:Label ID="lblDivisionCode" runat="server" Text="Division Code"></asp:Label> 
					<asp:TextBox ID="txtDivisionCode" runat="server"></asp:TextBox>
					</div>
					<div id="dvDivisionName" class="dvColumnLeft">
					<asp:Label ID="lblDivisionName" runat="server" Text="Division Name"></asp:Label> 
					<asp:TextBox ID="txtDivisionName" runat="server"></asp:TextBox>
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
