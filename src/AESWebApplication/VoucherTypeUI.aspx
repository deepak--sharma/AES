<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="VoucherTypeUI.aspx.cs" Inherits="VoucherTypeUI" MasterPageFile="~/MasterPage/MainMasterPage.master"%>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="Server">
	<title>VoucherType Page</title>
</asp:Content>
		<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
		<div>
			<asp:MultiView ID="MultiViewVoucherType" runat="server" ActiveViewIndex="0" > 
				<asp:View ID="ViewVoucherTypeGrid" runat="server">
				<fieldset><legend>Voucher Type List</legend>
					<asp:Button ID="btnAddNewRecord" runat="server" Text="Add New Record" OnClick="btnAddNewRecord_Click" />
					<asp:Label ID="lblViewOnly" runat="server" Text="View only - "></asp:Label>
					<asp:RadioButton ID="rdbActiveRecord" runat="server" Text="Live Records" GroupName="DisplayMode" AutoPostBack="True" Checked="True" OnCheckedChanged="rdbActiveRecord_CheckedChanged" />
					<asp:RadioButton ID="rdbInActiveRecord" runat="server" Text="Deleted Records" GroupName="DisplayMode" AutoPostBack="True" OnCheckedChanged="rdbInActiveRecord_CheckedChanged" />
					<asp:GridView ID="grdVoucherType" runat="server" DataKeyNames="Voucher_Type_Id,Version" AllowPaging="True" OnRowDeleting="grdVoucherType_RowDeleting" OnPageIndexChanging="grdVoucherType_PageIndexChanging"
						AutoGenerateColumns="False" EmptyDataText="No Record Found" OnRowEditing="grdVoucherType_ActivatingObject" OnSelectedIndexChanged="grdVoucherType_SelectedIndexChanged">
					<Columns>
						<asp:CommandField ShowSelectButton="True" SelectText="Select" HeaderText="Select"/>
						<asp:CommandField ShowEditButton="True" EditText="Activate" HeaderText="Activate" Visible="false"/>
						<asp:CommandField ShowDeleteButton="True" DeleteText="Delete" HeaderText="Delete"/>
						<asp:TemplateField HeaderText="Voucher Type Name" >
							<ItemTemplate>
								<asp:Label ID="lblVoucherTypeName" runat="server" Text='<%# Eval("Voucher_Type_Name") %>'></asp:Label> 
							</ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Serial Number Mode" >
							<ItemTemplate>
								<asp:Label ID="lblSerialNumberMode" runat="server" Text='<%# Eval("Serial_Number_Mode") %>'></asp:Label> 
							</ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Serial Number Prefix" >
							<ItemTemplate>
								<asp:Label ID="lblSerialNumberPrefix" runat="server" Text='<%# Eval("Serial_Number_Prefix") %>'></asp:Label> 
							</ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Numerical Width" >
							<ItemTemplate>
								<asp:Label ID="lblNumericalWidth" runat="server" Text='<%# Eval("Numerical_Width") %>'></asp:Label> 
							</ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Is Zero Prefix" >
							<ItemTemplate>
								<asp:Label ID="lblIsZeroPrefix" runat="server" Text='<%# Eval("Is_Zero_Prefix") %>'></asp:Label> 
							</ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Starting Number" >
							<ItemTemplate>
								<asp:Label ID="lblStartingNumber" runat="server" Text='<%# Eval("Starting_Number") %>'></asp:Label> 
							</ItemTemplate>
						</asp:TemplateField>
					</Columns>
					</asp:GridView>
				</fieldset>
				</asp:View>
				<asp:View ID="ViewVoucherTypeControls" runat="server">
				<fieldset><legend>Voucher Type</legend>
					<div id="dvVoucherTypeName" class="dvColumnLeft">
					<asp:Label ID="lblVoucherTypeName" runat="server" Text="Voucher Type Name"></asp:Label> 
					<asp:TextBox ID="txtVoucherTypeName" runat="server"></asp:TextBox>
					</div>
					<div id="dvSerialNumberMode" class="dvColumnRight">
					<asp:Label ID="lblSerialNumberMode" runat="server" Text="Serial Number Mode"></asp:Label> 
					<asp:TextBox ID="txtSerialNumberMode" runat="server"></asp:TextBox>
					</div>
					<div id="dvSerialNumberPrefix" class="dvColumnLeft">
					<asp:Label ID="lblSerialNumberPrefix" runat="server" Text="Serial Number Prefix"></asp:Label> 
					<asp:TextBox ID="txtSerialNumberPrefix" runat="server"></asp:TextBox>
					</div>
					<div id="dvNumericalWidth" class="dvColumnRight">
					<asp:Label ID="lblNumericalWidth" runat="server" Text="Numerical Width"></asp:Label> 
					<asp:TextBox ID="txtNumericalWidth" runat="server"></asp:TextBox>
					</div>
					<div id="dvIsZeroPrefix" class="dvColumnLeft">
					<asp:Label ID="lblIsZeroPrefix" runat="server" Text="Is Zero Prefix"></asp:Label> 
					<asp:DropDownList ID="ddlIsZeroPrefix" runat="server">
						<asp:ListItem Value="-Select-">-Select-</asp:ListItem>
						<asp:ListItem Value="True">True</asp:ListItem>
						<asp:ListItem Value="False">False</asp:ListItem>
					</asp:DropDownList>
					</div>
					<div id="dvStartingNumber" class="dvColumnRight">
					<asp:Label ID="lblStartingNumber" runat="server" Text="Starting Number"></asp:Label> 
					<asp:TextBox ID="txtStartingNumber" runat="server"></asp:TextBox>
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
