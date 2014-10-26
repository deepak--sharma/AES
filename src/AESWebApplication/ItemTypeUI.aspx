<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="ItemTypeUI.aspx.cs" Inherits="ItemTypeUI" MasterPageFile="~/MasterPage/MainMasterPage.master"%>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="Server">
	<title>ItemType Page</title>
</asp:Content>
		<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
		<div>
			<asp:MultiView ID="MultiViewItemType" runat="server" ActiveViewIndex="0" > 
				<asp:View ID="ViewItemTypeGrid" runat="server">
				<fieldset><legend>Item Type List</legend>
					<asp:Button ID="btnAddNewRecord" runat="server" Text="Add New Record" OnClick="btnAddNewRecord_Click" />
					<asp:Label ID="lblViewOnly" runat="server" Text="View only - "></asp:Label>
					<asp:RadioButton ID="rdbActiveRecord" runat="server" Text="Live Records" GroupName="DisplayMode" AutoPostBack="True" Checked="True" OnCheckedChanged="rdbActiveRecord_CheckedChanged" />
					<asp:RadioButton ID="rdbInActiveRecord" runat="server" Text="Deleted Records" GroupName="DisplayMode" AutoPostBack="True" OnCheckedChanged="rdbInActiveRecord_CheckedChanged" />
					<asp:GridView ID="grdItemType" runat="server" DataKeyNames="Item_Type_ID,Version" AllowPaging="True" OnRowDeleting="grdItemType_RowDeleting" OnPageIndexChanging="grdItemType_PageIndexChanging"
						AutoGenerateColumns="False" EmptyDataText="No Record Found" OnRowEditing="grdItemType_ActivatingObject" OnSelectedIndexChanged="grdItemType_SelectedIndexChanged">
					<Columns>
						<asp:CommandField ShowSelectButton="True" SelectText="Select" HeaderText="Select"/>
						<asp:CommandField ShowEditButton="True" EditText="Activate" HeaderText="Activate" Visible="false"/>
						<asp:CommandField ShowDeleteButton="True" DeleteText="Delete" HeaderText="Delete"/>
						<asp:TemplateField HeaderText="Item Type Name" >
							<ItemTemplate>
								<asp:Label ID="lblItemTypeName" runat="server" Text='<%# Eval("Item_Type_Name") %>'></asp:Label> 
							</ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Order By Fields" >
							<ItemTemplate>
								<asp:Label ID="lblOrderByFields" runat="server" Text='<%# Eval("Order_By_Fields") %>'></asp:Label> 
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
				<asp:View ID="ViewItemTypeControls" runat="server">
				<fieldset><legend>Item Type</legend>
					<div id="dvItemTypeName" class="dvColumnLeft">
					<asp:Label ID="lblItemTypeName" runat="server" Text="Item Type Name"></asp:Label> 
					<asp:TextBox ID="txtItemTypeName" runat="server"></asp:TextBox>
					</div>
					<div id="dvOrderByFields" class="dvColumnRight">
					<asp:Label ID="lblOrderByFields" runat="server" Text="Order By Fields"></asp:Label> 
					<asp:TextBox ID="txtOrderByFields" runat="server"></asp:TextBox>
					</div>
					<div id="dvDescription" class="dvColumnLeft">
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
