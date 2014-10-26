<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="ClassMasterUI.aspx.cs" Inherits="ClassMasterUI" MasterPageFile="~/MasterPage/MainMasterPage.master"%>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="Server">
	<title>ClassMaster Page</title>
</asp:Content>
		<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
		<div>
			<asp:MultiView ID="MultiViewClassMaster" runat="server" ActiveViewIndex="0" > 
				<asp:View ID="ViewClassMasterGrid" runat="server">
				<fieldset><legend>Class Master List</legend>
					<asp:Button ID="btnAddNewRecord" runat="server" Text="Add New Record" OnClick="btnAddNewRecord_Click" />
					<asp:Label ID="lblViewOnly" runat="server" Text="View only - "></asp:Label>
					<asp:RadioButton ID="rdbActiveRecord" runat="server" Text="Live Records" GroupName="DisplayMode" AutoPostBack="True" Checked="True" OnCheckedChanged="rdbActiveRecord_CheckedChanged" />
					<asp:RadioButton ID="rdbInActiveRecord" runat="server" Text="Deleted Records" GroupName="DisplayMode" AutoPostBack="True" OnCheckedChanged="rdbInActiveRecord_CheckedChanged" />
					<asp:GridView ID="grdClassMaster" runat="server" DataKeyNames="Class_Id,Version" AllowPaging="True" OnRowDeleting="grdClassMaster_RowDeleting" OnPageIndexChanging="grdClassMaster_PageIndexChanging"
						AutoGenerateColumns="False" EmptyDataText="No Record Found" OnRowEditing="grdClassMaster_ActivatingObject" OnSelectedIndexChanged="grdClassMaster_SelectedIndexChanged">
					<Columns>
						<asp:CommandField ShowSelectButton="True" SelectText="Select" HeaderText="Select"/>
						<asp:CommandField ShowEditButton="True" EditText="Activate" HeaderText="Activate" Visible="false"/>
						<asp:CommandField ShowDeleteButton="True" DeleteText="Delete" HeaderText="Delete"/>
						<asp:TemplateField HeaderText="Class Code" >
							<ItemTemplate>
								<asp:Label ID="lblClassCode" runat="server" Text='<%# Eval("Class_Code") %>'></asp:Label> 
							</ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Class Name" >
							<ItemTemplate>
								<asp:Label ID="lblClassName" runat="server" Text='<%# Eval("Class_Name") %>'></asp:Label> 
							</ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="ColoumA" >
							<ItemTemplate>
								<asp:Label ID="lblClassName" runat="server" Text='<%# Eval("ColoumA") %>'></asp:Label> 
							</ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="ColoumB" >
							<ItemTemplate>
								<asp:Label ID="lblClassName" runat="server" Text='<%# Eval("ColoumB") %>'></asp:Label> 
							</ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="ColoumC" >
							<ItemTemplate>
								<asp:Label ID="lblClassName" runat="server" Text='<%# Eval("ColoumC") %>'></asp:Label> 
							</ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Description" >
							<ItemTemplate>
								<asp:Label ID="lblDescription" runat="server" Text='<%# Eval("Description") %>'></asp:Label> 
							</ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Is Student" >
							<ItemTemplate>
								<asp:Label ID="lblIsStudent" runat="server" Text='<%# Eval("Is_Student") %>'></asp:Label> 
							</ItemTemplate>
						</asp:TemplateField>
					</Columns>
					</asp:GridView>
				</fieldset>
				</asp:View>
				<asp:View ID="ViewClassMasterControls" runat="server">
				<fieldset><legend>Class Master</legend>
					<div id="dvClassCode" class="dvColumnLeft">
					<asp:Label ID="lblClassCode" runat="server" Text="Class Code"></asp:Label> 
					<asp:TextBox ID="txtClassCode" runat="server"></asp:TextBox>
					</div>
					<div id="dvClassName" class="dvColumnRight">
					<asp:Label ID="lblClassName" runat="server" Text="Class Name"></asp:Label> 
					<asp:TextBox ID="txtClassName" runat="server"></asp:TextBox>
					</div>
					<div id="dvDescription" class="dvColumnLeft">
					<asp:Label ID="lblDescription" runat="server" Text="Description"></asp:Label> 
					<asp:TextBox ID="txtDescription" runat="server"></asp:TextBox>
					</div>
					<div id="dvIsStudent" class="dvColumnRight">
					<asp:Label ID="lblIsStudent" runat="server" Text="Is Student"></asp:Label> 
					<asp:DropDownList ID="ddlIsStudent" runat="server">
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
