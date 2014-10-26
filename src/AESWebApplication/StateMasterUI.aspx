<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="StateMasterUI.aspx.cs" Inherits="StateMasterUI" MasterPageFile="~/MasterPage/MainMasterPage.master"%>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="Server">
	<title>StateMaster Page</title>
</asp:Content>
		<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
		<div>
			<asp:MultiView ID="MultiViewStateMaster" runat="server" ActiveViewIndex="0" > 
				<asp:View ID="ViewStateMasterGrid" runat="server">
				<fieldset><legend>State Master List</legend>
					<asp:Button ID="btnAddNewRecord" runat="server" Text="Add New Record" OnClick="btnAddNewRecord_Click" />
					<asp:Label ID="lblViewOnly" runat="server" Text="View only - "></asp:Label>
					<asp:RadioButton ID="rdbActiveRecord" runat="server" Text="Live Records" GroupName="DisplayMode" AutoPostBack="True" Checked="True" OnCheckedChanged="rdbActiveRecord_CheckedChanged" />
					<asp:RadioButton ID="rdbInActiveRecord" runat="server" Text="Deleted Records" GroupName="DisplayMode" AutoPostBack="True" OnCheckedChanged="rdbInActiveRecord_CheckedChanged" />
					<asp:GridView ID="grdStateMaster" runat="server" DataKeyNames="State_Id,Version" AllowPaging="True" OnRowDeleting="grdStateMaster_RowDeleting" OnPageIndexChanging="grdStateMaster_PageIndexChanging"
						AutoGenerateColumns="False" EmptyDataText="No Record Found" OnRowEditing="grdStateMaster_ActivatingObject" OnSelectedIndexChanged="grdStateMaster_SelectedIndexChanged">
					<Columns>
						<asp:CommandField ShowSelectButton="True" SelectText="Select" HeaderText="Select"/>
						<asp:CommandField ShowEditButton="True" EditText="Activate" HeaderText="Activate" Visible="false"/>
						<asp:CommandField ShowDeleteButton="True" DeleteText="Delete" HeaderText="Delete"/>
						<asp:TemplateField HeaderText="State Name" >
							<ItemTemplate>
								<asp:Label ID="lblStateName" runat="server" Text='<%# Eval("State_Name") %>'></asp:Label> 
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
				<asp:View ID="ViewStateMasterControls" runat="server">
				<fieldset><legend>State Master</legend>
					<div id="dvStateName" class="dvColumnLeft">
					<asp:Label ID="lblStateName" runat="server" Text="State Name"></asp:Label> 
					<asp:TextBox ID="txtStateName" runat="server"></asp:TextBox>
					</div>
					<div id="dvCountry" class="dvColumnRight">
					<asp:Label ID="lblCountry" runat="server" Text="Country Name"></asp:Label> 
					<asp:DropDownList ID="ddlCountry" runat="server" DataValueField="Country_Id" DataTextField="Country_Name" ></asp:DropDownList> 
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
