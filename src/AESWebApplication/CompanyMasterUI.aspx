<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="CompanyMasterUI.aspx.cs" Inherits="CompanyMasterUI" MasterPageFile="~/MasterPage/MainMasterPage.master"%>
<%@ Register Src="UserControls/AddressDetailUC.ascx" TagName="AddressDetailUC" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="Server">
	<title>CompanyMaster Page</title>
</asp:Content>
		<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
		<div>
			<asp:MultiView ID="MultiViewCompanyMaster" runat="server" ActiveViewIndex="0" > 
				<asp:View ID="ViewCompanyMasterGrid" runat="server">
				<fieldset><legend>Company Master List</legend>
					<asp:Button ID="btnAddNewRecord" runat="server" Text="Add New Record" OnClick="btnAddNewRecord_Click" />
					<asp:Label ID="lblViewOnly" runat="server" Text="View only - "></asp:Label>
					<asp:RadioButton ID="rdbActiveRecord" runat="server" Text="Live Records" GroupName="DisplayMode" AutoPostBack="True" Checked="True" OnCheckedChanged="rdbActiveRecord_CheckedChanged" />
					<asp:RadioButton ID="rdbInActiveRecord" runat="server" Text="Deleted Records" GroupName="DisplayMode" AutoPostBack="True" OnCheckedChanged="rdbInActiveRecord_CheckedChanged" />
					<asp:GridView ID="grdCompanyMaster" runat="server" DataKeyNames="Company_Id,Version" AllowPaging="True" OnRowDeleting="grdCompanyMaster_RowDeleting" OnPageIndexChanging="grdCompanyMaster_PageIndexChanging"
						AutoGenerateColumns="False" EmptyDataText="No Record Found" OnRowEditing="grdCompanyMaster_ActivatingObject" OnSelectedIndexChanged="grdCompanyMaster_SelectedIndexChanged">
					<Columns>
						<asp:CommandField ShowSelectButton="True" SelectText="Select" HeaderText="Select"/>
						<asp:CommandField ShowEditButton="True" EditText="Activate" HeaderText="Activate" Visible="false"/>
						<asp:CommandField ShowDeleteButton="True" DeleteText="Delete" HeaderText="Delete"/>
						<asp:TemplateField HeaderText="Company Name" >
							<ItemTemplate>
								<asp:Label ID="lblCompanyName" runat="server" Text='<%# Eval("Company_Name") %>'></asp:Label> 
							</ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Lst No" >
							<ItemTemplate>
								<asp:Label ID="lblLstNo" runat="server" Text='<%# Eval("LST_No") %>'></asp:Label> 
							</ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Cst No" >
							<ItemTemplate>
								<asp:Label ID="lblCstNo" runat="server" Text='<%# Eval("CST_No") %>'></asp:Label> 
							</ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Excise No" >
							<ItemTemplate>
								<asp:Label ID="lblExciseNo" runat="server" Text='<%# Eval("Excise_No") %>'></asp:Label> 
							</ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Ecc No" >
							<ItemTemplate>
								<asp:Label ID="lblEccNo" runat="server" Text='<%# Eval("ECC_No") %>'></asp:Label> 
							</ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Ien No" >
							<ItemTemplate>
								<asp:Label ID="lblIenNo" runat="server" Text='<%# Eval("IEN_No") %>'></asp:Label> 
							</ItemTemplate>
						</asp:TemplateField>
					</Columns>
					</asp:GridView>
				</fieldset>
				</asp:View>
				<asp:View ID="ViewCompanyMasterControls" runat="server">
				<fieldset><legend>Company Master</legend>
					<div id="dvCompanyName" class="dvColumnLeft">
					<asp:Label ID="lblCompanyName" runat="server" Text="Company Name"></asp:Label> 
					<asp:TextBox ID="txtCompanyName" runat="server"></asp:TextBox>
					</div>
					<div id="dvLstNo" class="dvColumnRight">
					<asp:Label ID="lblLstNo" runat="server" Text="Lst No"></asp:Label> 
					<asp:TextBox ID="txtLstNo" runat="server"></asp:TextBox>
					</div>
					<div id="dvCstNo" class="dvColumnLeft">
					<asp:Label ID="lblCstNo" runat="server" Text="Cst No"></asp:Label> 
					<asp:TextBox ID="txtCstNo" runat="server"></asp:TextBox>
					</div>
					<div id="dvExciseNo" class="dvColumnRight">
					<asp:Label ID="lblExciseNo" runat="server" Text="Excise No"></asp:Label> 
					<asp:TextBox ID="txtExciseNo" runat="server"></asp:TextBox>
					</div>
					<div id="dvEccNo" class="dvColumnLeft">
					<asp:Label ID="lblEccNo" runat="server" Text="Ecc No"></asp:Label> 
					<asp:TextBox ID="txtEccNo" runat="server"></asp:TextBox>
					</div>
					<div id="dvIenNo" class="dvColumnRight">
					<asp:Label ID="lblIenNo" runat="server" Text="Ien No"></asp:Label> 
					<asp:TextBox ID="txtIenNo" runat="server"></asp:TextBox>
					</div>
			<fieldset>
				<legend>Address Detail</legend>
				<uc1:AddressDetailUC ID="uxCompanyAddressUC" runat="server" />
			</fieldset>
				</fieldset>

				<asp:Button ID="btnSave" runat="server" Enabled="False" OnClick="btnSave_Click" Text="Save Record" />
				<asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit Record" />
				<asp:Button ID="btnCancelRollback" runat="server" OnClick="btnCancelRollback_Click" Text="Cancel / Rollback" />
				</asp:View>
			</asp:MultiView>
			<asp:Label ID="lblMessage" runat="server" EnableViewState="False"></asp:Label>
		</div>
</asp:Content>
