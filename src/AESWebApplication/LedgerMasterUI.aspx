<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="LedgerMasterUI.aspx.cs" Inherits="LedgerMasterUI" MasterPageFile="~/MasterPage/MainMasterPage.master"%>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="Server">
	<title>LedgerMaster Page</title>
</asp:Content>
		<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
		<div>
			<asp:MultiView ID="MultiViewLedgerMaster" runat="server" ActiveViewIndex="0" > 
				<asp:View ID="ViewLedgerMasterGrid" runat="server">
				<fieldset><legend>Ledger Master List</legend>
					<asp:Button ID="btnAddNewRecord" runat="server" Text="Add New Record" OnClick="btnAddNewRecord_Click" />
					<asp:Label ID="lblViewOnly" runat="server" Text="View only - "></asp:Label>
					<asp:RadioButton ID="rdbActiveRecord" runat="server" Text="Live Records" GroupName="DisplayMode" AutoPostBack="True" Checked="True" OnCheckedChanged="rdbActiveRecord_CheckedChanged" />
					<asp:RadioButton ID="rdbInActiveRecord" runat="server" Text="Deleted Records" GroupName="DisplayMode" AutoPostBack="True" OnCheckedChanged="rdbInActiveRecord_CheckedChanged" />
					<asp:GridView ID="grdLedgerMaster" runat="server" DataKeyNames="Ledger_Id,Version" AllowPaging="True" OnRowDeleting="grdLedgerMaster_RowDeleting" OnPageIndexChanging="grdLedgerMaster_PageIndexChanging"
						AutoGenerateColumns="False" EmptyDataText="No Record Found" OnRowEditing="grdLedgerMaster_ActivatingObject" OnSelectedIndexChanged="grdLedgerMaster_SelectedIndexChanged">
					<Columns>
						<asp:CommandField ShowSelectButton="True" SelectText="Select" HeaderText="Select"/>
						<asp:CommandField ShowEditButton="True" EditText="Activate" HeaderText="Activate" Visible="false"/>
						<asp:CommandField ShowDeleteButton="True" DeleteText="Delete" HeaderText="Delete"/>
						<asp:TemplateField HeaderText="Ledger Name" >
							<ItemTemplate>
								<asp:Label ID="lblLedgerName" runat="server" Text='<%# Eval("Ledger_Name") %>'></asp:Label> 
							</ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Opening Balance" >
							<ItemTemplate>
								<asp:Label ID="lblOpeningBalance" runat="server" Text='<%# Eval("Opening_Balance") %>'></asp:Label> 
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
				<asp:View ID="ViewLedgerMasterControls" runat="server">
				<fieldset><legend>Ledger Master</legend>
					<div id="dvLedgerName" class="dvColumnLeft">
					<asp:Label ID="lblLedgerName" runat="server" Text="Ledger Name"></asp:Label> 
					<asp:TextBox ID="txtLedgerName" runat="server"></asp:TextBox>
					</div>
					<div id="dvGroup" class="dvColumnRight">
					<asp:Label ID="lblGroup" runat="server" Text="Group Name"></asp:Label> 
					<asp:DropDownList ID="ddlGroup" runat="server" DataValueField="Group_Id" DataTextField="Group_Name" ></asp:DropDownList> 
					</div>
					<div id="dvOpeningBalance" class="dvColumnLeft">
					<asp:Label ID="lblOpeningBalance" runat="server" Text="Opening Balance"></asp:Label> 
					<asp:TextBox ID="txtOpeningBalance" runat="server"></asp:TextBox>
					</div>
					<div id="dvOpeningDate" class="dvColumnRight">
					<asp:Label ID="lblOpeningDate" runat="server" Text="Opening Date"></asp:Label> 
					<asp:TextBox ID="txtOpeningDate" runat="server"></asp:TextBox>
					</div>
					<div id="dvDrCr" class="dvColumnLeft">
					<asp:Label ID="lblDrCr" runat="server" Text="Dr Cr"></asp:Label> 
					<asp:TextBox ID="txtDrCr" runat="server"></asp:TextBox>
					</div>
					<div id="dvOnDate" class="dvColumnRight">
					<asp:Label ID="lblOnDate" runat="server" Text="On Date"></asp:Label> 
					<asp:TextBox ID="txtOnDate" runat="server"></asp:TextBox>
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
