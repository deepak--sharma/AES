<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="BankMasterUI.aspx.cs" Inherits="BankMasterUI" MasterPageFile="~/MasterPage/MainMasterPage.master"%>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="Server">
	<title>BankMaster Page</title>
</asp:Content>
		<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
		<div>
			<asp:MultiView ID="MultiViewBankMaster" runat="server" ActiveViewIndex="0" > 
				<asp:View ID="ViewBankMasterGrid" runat="server">
				<fieldset><legend>Bank Master List</legend>
					<asp:Button ID="btnAddNewRecord" runat="server" Text="Add New Record" OnClick="btnAddNewRecord_Click" />
					<asp:Label ID="lblViewOnly" runat="server" Text="View only - "></asp:Label>
					<asp:RadioButton ID="rdbActiveRecord" runat="server" Text="Live Records" GroupName="DisplayMode" AutoPostBack="True" Checked="True" OnCheckedChanged="rdbActiveRecord_CheckedChanged" />
					<asp:RadioButton ID="rdbInActiveRecord" runat="server" Text="Deleted Records" GroupName="DisplayMode" AutoPostBack="True" OnCheckedChanged="rdbInActiveRecord_CheckedChanged" />
					<asp:GridView ID="grdBankMaster" runat="server" DataKeyNames="Bank_Id,Version" AllowPaging="True" OnRowDeleting="grdBankMaster_RowDeleting" OnPageIndexChanging="grdBankMaster_PageIndexChanging"
						AutoGenerateColumns="False" EmptyDataText="No Record Found" OnRowEditing="grdBankMaster_ActivatingObject" OnSelectedIndexChanged="grdBankMaster_SelectedIndexChanged">
					<Columns>
						<asp:CommandField ShowSelectButton="True" SelectText="Select" HeaderText="Select"/>
						<asp:CommandField ShowEditButton="True" EditText="Activate" HeaderText="Activate" Visible="false"/>
						<asp:CommandField ShowDeleteButton="True" DeleteText="Delete" HeaderText="Delete"/>
						<asp:TemplateField HeaderText="Bank Code" >
							<ItemTemplate>
								<asp:Label ID="lblBankCode" runat="server" Text='<%# Eval("Bank_Code") %>'></asp:Label> 
							</ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Bank Name" >
							<ItemTemplate>
								<asp:Label ID="lblBankName" runat="server" Text='<%# Eval("Bank_Name") %>'></asp:Label> 
							</ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Bank Address Id" >
							<ItemTemplate>
								<asp:Label ID="lblBankAddressId" runat="server" Text='<%# Eval("Bank_Address_Id") %>'></asp:Label> 
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
				<asp:View ID="ViewBankMasterControls" runat="server">
				<fieldset><legend>Bank Master</legend>
					<div id="dvBankCode" class="dvColumnLeft">
					<asp:Label ID="lblBankCode" runat="server" Text="Bank Code"></asp:Label> 
					<asp:TextBox ID="txtBankCode" runat="server"></asp:TextBox>
					</div>
					<div id="dvBankName" class="dvColumnRight">
					<asp:Label ID="lblBankName" runat="server" Text="Bank Name"></asp:Label> 
					<asp:TextBox ID="txtBankName" runat="server"></asp:TextBox>
					</div>
					<div id="dvBankAddressId" class="dvColumnLeft">
					<asp:Label ID="lblBankAddressId" runat="server" Text="Bank Address Id"></asp:Label> 
					<asp:TextBox ID="txtBankAddressId" runat="server"></asp:TextBox>
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
