<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="ResourceManagementUI.aspx.cs" Inherits="ResourceManagementUI" MasterPageFile="~/MasterPage/MainMasterPage.master"%>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="Server">
	<title>ResourceManagement Page</title>
</asp:Content>
		<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
		<div>
			<asp:MultiView ID="MultiViewResourceManagement" runat="server" ActiveViewIndex="0" > 
				<asp:View ID="ViewResourceManagementGrid" runat="server">
				<fieldset><legend>Resource Management List</legend>
					<asp:Button ID="btnAddNewRecord" runat="server" Text="Add New Record" OnClick="btnAddNewRecord_Click" />
					<asp:Label ID="lblViewOnly" runat="server" Text="View only - "></asp:Label>
					<asp:RadioButton ID="rdbActiveRecord" runat="server" Text="Live Records" GroupName="DisplayMode" AutoPostBack="True" Checked="True" OnCheckedChanged="rdbActiveRecord_CheckedChanged" />
					<asp:RadioButton ID="rdbInActiveRecord" runat="server" Text="Deleted Records" GroupName="DisplayMode" AutoPostBack="True" OnCheckedChanged="rdbInActiveRecord_CheckedChanged" />
					<asp:GridView ID="grdResourceManagement" runat="server" DataKeyNames="Resource_Id,Version" AllowPaging="True" OnRowDeleting="grdResourceManagement_RowDeleting" OnPageIndexChanging="grdResourceManagement_PageIndexChanging"
						AutoGenerateColumns="False" EmptyDataText="No Record Found" OnRowEditing="grdResourceManagement_ActivatingObject" OnSelectedIndexChanged="grdResourceManagement_SelectedIndexChanged">
					<Columns>
						<asp:CommandField ShowSelectButton="True" SelectText="Select" HeaderText="Select"/>
						<asp:CommandField ShowEditButton="True" EditText="Activate" HeaderText="Activate" Visible="false"/>
						<asp:CommandField ShowDeleteButton="True" DeleteText="Delete" HeaderText="Delete"/>
						<asp:TemplateField HeaderText="Resource Name" >
							<ItemTemplate>
								<asp:Label ID="lblResourceName" runat="server" Text='<%# Eval("Resource_Name") %>'></asp:Label> 
							</ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Url" >
							<ItemTemplate>
								<asp:Label ID="lblUrl" runat="server" Text='<%# Eval("URL") %>'></asp:Label> 
							</ItemTemplate>
						</asp:TemplateField>
					</Columns>
					</asp:GridView>
				</fieldset>
				</asp:View>
				<asp:View ID="ViewResourceManagementControls" runat="server">
				<fieldset><legend>Resource Management</legend>
					<div id="dvResourceName" class="dvColumnLeft">
					<asp:Label ID="lblResourceName" runat="server" Text="Resource Name"></asp:Label> 
					<asp:TextBox ID="txtResourceName" runat="server"></asp:TextBox>
					</div>
					<div id="dvUrl" class="dvColumnRight">
					<asp:Label ID="lblUrl" runat="server" Text="Url"></asp:Label> 
					<asp:TextBox ID="txtUrl" runat="server"></asp:TextBox>
					</div>
					<div id="dvParent" class="dvColumnLeft">
					<asp:Label ID="lblParent" runat="server" Text="Resource Name"></asp:Label> 
					<asp:DropDownList ID="ddlParent" runat="server" DataValueField="Resource_Id" DataTextField="Resource_Name" ></asp:DropDownList> 
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
