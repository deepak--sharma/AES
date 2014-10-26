<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="RackMasterUI.aspx.cs" Inherits="RackMasterUI" MasterPageFile="~/MasterPage/MainMasterPage.master"%>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="Server">
	<title>RackMaster Page</title>
</asp:Content>
		<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
		<div>
			<asp:MultiView ID="MultiViewRackMaster" runat="server" ActiveViewIndex="0" > 
				<asp:View ID="ViewRackMasterGrid" runat="server">
				<fieldset><legend>Rack Master List</legend>
					<asp:Button ID="btnAddNewRecord" runat="server" Text="Add New Record" OnClick="btnAddNewRecord_Click" />
					<asp:Label ID="lblViewOnly" runat="server" Text="View only - "></asp:Label>
					<asp:RadioButton ID="rdbActiveRecord" runat="server" Text="Live Records" GroupName="DisplayMode" AutoPostBack="True" Checked="True" OnCheckedChanged="rdbActiveRecord_CheckedChanged" />
					<asp:RadioButton ID="rdbInActiveRecord" runat="server" Text="Deleted Records" GroupName="DisplayMode" AutoPostBack="True" OnCheckedChanged="rdbInActiveRecord_CheckedChanged" />
					<asp:GridView ID="grdRackMaster" runat="server" DataKeyNames="Rack_ID,Version" AllowPaging="True" OnRowDeleting="grdRackMaster_RowDeleting" OnPageIndexChanging="grdRackMaster_PageIndexChanging"
						AutoGenerateColumns="False" EmptyDataText="No Record Found" OnRowEditing="grdRackMaster_ActivatingObject" OnSelectedIndexChanged="grdRackMaster_SelectedIndexChanged">
					<Columns>
						<asp:CommandField ShowSelectButton="True" SelectText="Select" HeaderText="Select"/>
						<asp:CommandField ShowEditButton="True" EditText="Activate" HeaderText="Activate" Visible="false"/>
						<asp:CommandField ShowDeleteButton="True" DeleteText="Delete" HeaderText="Delete"/>
						<asp:TemplateField HeaderText="Rack Code" >
							<ItemTemplate>
								<asp:Label ID="lblRackCode" runat="server" Text='<%# Eval("Rack_Code") %>'></asp:Label> 
							</ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="No Of Rows" >
							<ItemTemplate>
								<asp:Label ID="lblNoOfRows" runat="server" Text='<%# Eval("No_Of_Rows") %>'></asp:Label> 
							</ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="No Of Columns" >
							<ItemTemplate>
								<asp:Label ID="lblNoOfColumns" runat="server" Text='<%# Eval("No_Of_Columns") %>'></asp:Label> 
							</ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Descripition" >
							<ItemTemplate>
								<asp:Label ID="lblDescripition" runat="server" Text='<%# Eval("Descripition") %>'></asp:Label> 
							</ItemTemplate>
						</asp:TemplateField>
					</Columns>
					</asp:GridView>
				</fieldset>
				</asp:View>
				<asp:View ID="ViewRackMasterControls" runat="server">
				<fieldset><legend>Rack Master</legend>
					<div id="dvRackCode" class="dvColumnLeft">
					<asp:Label ID="lblRackCode" runat="server" Text="Rack Code"></asp:Label> 
					<asp:TextBox ID="txtRackCode" runat="server"></asp:TextBox>
					</div>
					<div id="dvNoOfRows" class="dvColumnRight">
					<asp:Label ID="lblNoOfRows" runat="server" Text="No Of Rows"></asp:Label> 
					<asp:TextBox ID="txtNoOfRows" runat="server"></asp:TextBox>
					</div>
					<div id="dvNoOfColumns" class="dvColumnLeft">
					<asp:Label ID="lblNoOfColumns" runat="server" Text="No Of Columns"></asp:Label> 
					<asp:TextBox ID="txtNoOfColumns" runat="server"></asp:TextBox>
					</div>
					<div id="dvRack" class="dvColumnRight">
					<asp:Label ID="lblRack" runat="server" Text="Rack Group Name"></asp:Label> 
					<asp:DropDownList ID="ddlRack" runat="server" DataValueField="Rack_Group_ID" DataTextField="Rack_Group_Name" ></asp:DropDownList> 
					</div>
					<div id="dvDescripition" class="dvColumnLeft">
					<asp:Label ID="lblDescripition" runat="server" Text="Descripition"></asp:Label> 
					<asp:TextBox ID="txtDescripition" runat="server"></asp:TextBox>
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
