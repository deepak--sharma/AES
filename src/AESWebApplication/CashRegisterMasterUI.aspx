<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="CashRegisterMasterUI.aspx.cs" Inherits="CashRegisterMasterUI" MasterPageFile="~/MasterPage/MainMasterPage.master"%>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="Server">
	<title>CashRegisterMaster Page</title>
</asp:Content>
		<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
		<div>
			<asp:MultiView ID="MultiViewCashRegisterMaster" runat="server" ActiveViewIndex="0" > 
				<asp:View ID="ViewCashRegisterMasterGrid" runat="server">
				<fieldset><legend>Cash Register Master List</legend>
					<asp:Button ID="btnAddNewRecord" runat="server" Text="Add New Record" OnClick="btnAddNewRecord_Click" />
					<asp:Label ID="lblViewOnly" runat="server" Text="View only - "></asp:Label>
					<asp:RadioButton ID="rdbActiveRecord" runat="server" Text="Live Records" GroupName="DisplayMode" AutoPostBack="True" Checked="True" OnCheckedChanged="rdbActiveRecord_CheckedChanged" />
					<asp:RadioButton ID="rdbInActiveRecord" runat="server" Text="Deleted Records" GroupName="DisplayMode" AutoPostBack="True" OnCheckedChanged="rdbInActiveRecord_CheckedChanged" />
					<asp:GridView ID="grdCashRegisterMaster" runat="server" DataKeyNames="Cash_Register_Id,Version" AllowPaging="True" OnRowDeleting="grdCashRegisterMaster_RowDeleting" OnPageIndexChanging="grdCashRegisterMaster_PageIndexChanging"
						AutoGenerateColumns="False" EmptyDataText="No Record Found" OnRowEditing="grdCashRegisterMaster_ActivatingObject" OnSelectedIndexChanged="grdCashRegisterMaster_SelectedIndexChanged">
					<Columns>
						<asp:CommandField ShowSelectButton="True" SelectText="Select" HeaderText="Select"/>
						<asp:CommandField ShowEditButton="True" EditText="Activate" HeaderText="Activate" Visible="false"/>
						<asp:CommandField ShowDeleteButton="True" DeleteText="Delete" HeaderText="Delete"/>
						<asp:TemplateField HeaderText="Cash Register Name" >
							<ItemTemplate>
								<asp:Label ID="lblCashRegisterName" runat="server" Text='<%# Eval("Cash_Register_Name") %>'></asp:Label> 
							</ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Opening Date" >
							<ItemTemplate>
								<asp:Label ID="lblOpeningDate" runat="server" Text='<%# Eval("Opening_Date") %>'></asp:Label> 
							</ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Dr Cr" >
							<ItemTemplate>
								<asp:Label ID="lblDrCr" runat="server" Text='<%# Eval("DR_CR") %>'></asp:Label> 
							</ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="On Date" >
							<ItemTemplate>
								<asp:Label ID="lblOnDate" runat="server" Text='<%# Eval("On_Date") %>'></asp:Label> 
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
				<asp:View ID="ViewCashRegisterMasterControls" runat="server">
				<fieldset><legend>Cash Register Master</legend>
					<div id="dvCashRegisterName" class="dvColumnLeft">
					<asp:Label ID="lblCashRegisterName" runat="server" Text="Cash Register Name"></asp:Label> 
					<asp:TextBox ID="txtCashRegisterName" runat="server"></asp:TextBox>
					</div>
					<div id="dvGroup" class="dvColumnRight">
					<asp:Label ID="lblGroup" runat="server" Text="Group Name"></asp:Label> 
					<asp:DropDownList ID="ddlGroup" runat="server" DataValueField="Group_Id" DataTextField="Group_Name" ></asp:DropDownList> 
					</div>
					<div id="dvOpeningDate" class="dvColumnLeft">
					<asp:Label ID="lblOpeningDate" runat="server" Text="Opening Date"></asp:Label> 
					<asp:TextBox ID="txtOpeningDate" runat="server"></asp:TextBox>
					</div>
					<div id="dvDrCr" class="dvColumnRight">
					<asp:Label ID="lblDrCr" runat="server" Text="Dr Cr"></asp:Label> 
					<asp:TextBox ID="txtDrCr" runat="server"></asp:TextBox>
					</div>
					<div id="dvOnDate" class="dvColumnLeft">
					<asp:Label ID="lblOnDate" runat="server" Text="On Date"></asp:Label> 
					<asp:TextBox ID="txtOnDate" runat="server"></asp:TextBox>
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
