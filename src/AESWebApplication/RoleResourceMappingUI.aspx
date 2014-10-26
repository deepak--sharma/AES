<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="RoleResourceMappingUI.aspx.cs" Inherits="RoleResourceMappingUI" MasterPageFile="~/MasterPage/MainMasterPage.master"%>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="Server">
	<title>RoleResourceMapping Page</title>
</asp:Content>
		<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
		<div>
			<asp:MultiView ID="MultiViewRoleResourceMapping" runat="server" ActiveViewIndex="0" > 
				<asp:View ID="ViewRoleResourceMappingGrid" runat="server">
				<fieldset><legend>Role Resource Mapping List</legend>
					<asp:Button ID="btnAddNewRecord" runat="server" Text="Add New Record" OnClick="btnAddNewRecord_Click" />
					<asp:Label ID="lblViewOnly" runat="server" Text="View only - "></asp:Label>
					<asp:RadioButton ID="rdbActiveRecord" runat="server" Text="Live Records" GroupName="DisplayMode" AutoPostBack="True" Checked="True" OnCheckedChanged="rdbActiveRecord_CheckedChanged" />
					<asp:RadioButton ID="rdbInActiveRecord" runat="server" Text="Deleted Records" GroupName="DisplayMode" AutoPostBack="True" OnCheckedChanged="rdbInActiveRecord_CheckedChanged" />
					<asp:GridView ID="grdRoleResourceMapping" runat="server" DataKeyNames="Role_Resource_Mapping_Id,Version" AllowPaging="True" OnRowDeleting="grdRoleResourceMapping_RowDeleting" OnPageIndexChanging="grdRoleResourceMapping_PageIndexChanging"
						AutoGenerateColumns="False" EmptyDataText="No Record Found" OnRowEditing="grdRoleResourceMapping_ActivatingObject" OnSelectedIndexChanged="grdRoleResourceMapping_SelectedIndexChanged">
					<Columns>
						<asp:CommandField ShowSelectButton="True" SelectText="Select" HeaderText="Select"/>
						<asp:CommandField ShowEditButton="True" EditText="Activate" HeaderText="Activate" Visible="false"/>
						<asp:CommandField ShowDeleteButton="True" DeleteText="Delete" HeaderText="Delete"/>
						<asp:TemplateField HeaderText="View" >
							<ItemTemplate>
								<asp:Label ID="lblView" runat="server" Text='<%# Eval("View") %>'></asp:Label> 
							</ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Create" >
							<ItemTemplate>
								<asp:Label ID="lblCreate" runat="server" Text='<%# Eval("Create") %>'></asp:Label> 
							</ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Edit" >
							<ItemTemplate>
								<asp:Label ID="lblEdit" runat="server" Text='<%# Eval("Edit") %>'></asp:Label> 
							</ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Delete" >
							<ItemTemplate>
								<asp:Label ID="lblDelete" runat="server" Text='<%# Eval("Delete") %>'></asp:Label> 
							</ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Download" >
							<ItemTemplate>
								<asp:Label ID="lblDownload" runat="server" Text='<%# Eval("Download") %>'></asp:Label> 
							</ItemTemplate>
						</asp:TemplateField>
					</Columns>
					</asp:GridView>
				</fieldset>
				</asp:View>
				<asp:View ID="ViewRoleResourceMappingControls" runat="server">
				<fieldset><legend>Role Resource Mapping</legend>
					<div id="dvRole" class="dvColumnLeft">
					<asp:Label ID="lblRole" runat="server" Text="Role Name"></asp:Label> 
					<asp:DropDownList ID="ddlRole" runat="server" DataValueField="Role_Id" DataTextField="Role_Name" ></asp:DropDownList> 
					</div>
					<div id="dvResource" class="dvColumnRight">
					<asp:Label ID="lblResource" runat="server" Text="Resource Name"></asp:Label> 
					<asp:DropDownList ID="ddlResource" runat="server" DataValueField="Resource_Id" DataTextField="Resource_Name" ></asp:DropDownList> 
					</div>
					<div id="dvView" class="dvColumnLeft">
					<asp:Label ID="lblView" runat="server" Text="View"></asp:Label> 
					<asp:DropDownList ID="ddlView" runat="server">
						<asp:ListItem Value="-Select-">-Select-</asp:ListItem>
						<asp:ListItem Value="True">True</asp:ListItem>
						<asp:ListItem Value="False">False</asp:ListItem>
					</asp:DropDownList>
					</div>
					<div id="dvCreate" class="dvColumnRight">
					<asp:Label ID="lblCreate" runat="server" Text="Create"></asp:Label> 
					<asp:DropDownList ID="ddlCreate" runat="server">
						<asp:ListItem Value="-Select-">-Select-</asp:ListItem>
						<asp:ListItem Value="True">True</asp:ListItem>
						<asp:ListItem Value="False">False</asp:ListItem>
					</asp:DropDownList>
					</div>
					<div id="dvEdit" class="dvColumnLeft">
					<asp:Label ID="lblEdit" runat="server" Text="Edit"></asp:Label> 
					<asp:DropDownList ID="ddlEdit" runat="server">
						<asp:ListItem Value="-Select-">-Select-</asp:ListItem>
						<asp:ListItem Value="True">True</asp:ListItem>
						<asp:ListItem Value="False">False</asp:ListItem>
					</asp:DropDownList>
					</div>
					<div id="dvDelete" class="dvColumnRight">
					<asp:Label ID="lblDelete" runat="server" Text="Delete"></asp:Label> 
					<asp:DropDownList ID="ddlDelete" runat="server">
						<asp:ListItem Value="-Select-">-Select-</asp:ListItem>
						<asp:ListItem Value="True">True</asp:ListItem>
						<asp:ListItem Value="False">False</asp:ListItem>
					</asp:DropDownList>
					</div>
					<div id="dvDownload" class="dvColumnLeft">
					<asp:Label ID="lblDownload" runat="server" Text="Download"></asp:Label> 
					<asp:DropDownList ID="ddlDownload" runat="server">
						<asp:ListItem Value="-Select-">-Select-</asp:ListItem>
						<asp:ListItem Value="True">True</asp:ListItem>
						<asp:ListItem Value="False">False</asp:ListItem>
					</asp:DropDownList>
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
