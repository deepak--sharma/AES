<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="SchoolMasterUI.aspx.cs" Inherits="SchoolMasterUI" MasterPageFile="~/MasterPage/MainMasterPage.master"%>
<%@ Register Src="UserControls/AddressDetailUC.ascx" TagName="AddressDetailUC" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="Server">
	<title>SchoolMaster Page</title>
</asp:Content>
		<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
		<div>
			<asp:MultiView ID="MultiViewSchoolMaster" runat="server" ActiveViewIndex="0" > 
				<asp:View ID="ViewSchoolMasterGrid" runat="server">
				<fieldset><legend>School Master List</legend>
					<asp:Button ID="btnAddNewRecord" runat="server" Text="Add New Record" OnClick="btnAddNewRecord_Click" />
					<asp:Label ID="lblViewOnly" runat="server" Text="View only - "></asp:Label>
					<asp:RadioButton ID="rdbActiveRecord" runat="server" Text="Live Records" GroupName="DisplayMode" AutoPostBack="True" Checked="True" OnCheckedChanged="rdbActiveRecord_CheckedChanged" />
					<asp:RadioButton ID="rdbInActiveRecord" runat="server" Text="Deleted Records" GroupName="DisplayMode" AutoPostBack="True" OnCheckedChanged="rdbInActiveRecord_CheckedChanged" />
					<asp:GridView ID="grdSchoolMaster" runat="server" DataKeyNames="School_Id,Version" AllowPaging="True" OnRowDeleting="grdSchoolMaster_RowDeleting" OnPageIndexChanging="grdSchoolMaster_PageIndexChanging"
						AutoGenerateColumns="False" EmptyDataText="No Record Found" OnRowEditing="grdSchoolMaster_ActivatingObject" OnSelectedIndexChanged="grdSchoolMaster_SelectedIndexChanged">
					<Columns>
						<asp:CommandField ShowSelectButton="True" SelectText="Select" HeaderText="Select"/>
						<asp:CommandField ShowEditButton="True" EditText="Activate" HeaderText="Activate" Visible="false"/>
						<asp:CommandField ShowDeleteButton="True" DeleteText="Delete" HeaderText="Delete"/>
						<asp:TemplateField HeaderText="School Code" >
							<ItemTemplate>
								<asp:Label ID="lblSchoolCode" runat="server" Text='<%# Eval("School_Code") %>'></asp:Label> 
							</ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="School Name" >
							<ItemTemplate>
								<asp:Label ID="lblSchoolName" runat="server" Text='<%# Eval("School_Name") %>'></asp:Label> 
							</ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="School Head" >
							<ItemTemplate>
								<asp:Label ID="lblSchoolHead" runat="server" Text='<%# Eval("School_Head") %>'></asp:Label> 
							</ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Established On" >
							<ItemTemplate>
								<asp:Label ID="lblEstablishedOn" runat="server" Text='<%# Eval("Established_On") %>'></asp:Label> 
							</ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Logo" >
							<ItemTemplate>
								<asp:Label ID="lblLogo" runat="server" Text='<%# Eval("Logo") %>'></asp:Label> 
							</ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Web Address" >
							<ItemTemplate>
								<asp:Label ID="lblWebAddress" runat="server" Text='<%# Eval("Web_Address") %>'></asp:Label> 
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
				<asp:View ID="ViewSchoolMasterControls" runat="server">
				<fieldset><legend>School Master</legend>
					<div id="dvSchoolCode" class="dvColumnLeft">
					<asp:Label ID="lblSchoolCode" runat="server" Text="School Code"></asp:Label> 
					<asp:TextBox ID="txtSchoolCode" runat="server"></asp:TextBox>
					</div>
					<div id="dvSchoolName" class="dvColumnRight">
					<asp:Label ID="lblSchoolName" runat="server" Text="School Name"></asp:Label> 
					<asp:TextBox ID="txtSchoolName" runat="server"></asp:TextBox>
					</div>
					<div id="dvSchoolHead" class="dvColumnLeft">
					<asp:Label ID="lblSchoolHead" runat="server" Text="School Head"></asp:Label> 
					<asp:TextBox ID="txtSchoolHead" runat="server"></asp:TextBox>
					</div>
					<div id="dvEstablishedOn" class="dvColumnRight">
					<asp:Label ID="lblEstablishedOn" runat="server" Text="Established On"></asp:Label> 
					<asp:TextBox ID="txtEstablishedOn" runat="server"></asp:TextBox>
					</div>
					<div id="dvLogo" class="dvColumnLeft">
					<asp:Label ID="lblLogo" runat="server" Text="Logo"></asp:Label> 
					<asp:TextBox ID="txtLogo" runat="server"></asp:TextBox>
					</div>
					<div id="dvWebAddress" class="dvColumnRight">
					<asp:Label ID="lblWebAddress" runat="server" Text="Web Address"></asp:Label> 
					<asp:TextBox ID="txtWebAddress" runat="server"></asp:TextBox>
					</div>
			<fieldset>
				<legend>Address Detail</legend>
				<uc1:AddressDetailUC ID="uxSchoolAddressUC" runat="server" />
			</fieldset>
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
