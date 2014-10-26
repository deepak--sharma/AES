<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="BranchMasterUI.aspx.cs" Inherits="BranchMasterUI" MasterPageFile="~/MasterPage/MainMasterPage.master"%>
<%@ Register Src="UserControls/AddressDetailUC.ascx" TagName="AddressDetailUC" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="Server">
	<title>BranchMaster Page</title>
</asp:Content>
		<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
		<div>
			<asp:MultiView ID="MultiViewBranchMaster" runat="server" ActiveViewIndex="0" > 
				<asp:View ID="ViewBranchMasterGrid" runat="server">
				<fieldset><legend>Branch Master List</legend>
					<asp:Button ID="btnAddNewRecord" runat="server" Text="Add New Record" OnClick="btnAddNewRecord_Click" />
					<asp:Label ID="lblViewOnly" runat="server" Text="View only - "></asp:Label>
					<asp:RadioButton ID="rdbActiveRecord" runat="server" Text="Live Records" GroupName="DisplayMode" AutoPostBack="True" Checked="True" OnCheckedChanged="rdbActiveRecord_CheckedChanged" />
					<asp:RadioButton ID="rdbInActiveRecord" runat="server" Text="Deleted Records" GroupName="DisplayMode" AutoPostBack="True" OnCheckedChanged="rdbInActiveRecord_CheckedChanged" />
					<asp:GridView ID="grdBranchMaster" runat="server" DataKeyNames="Branch_Id,Version" AllowPaging="True" OnRowDeleting="grdBranchMaster_RowDeleting" OnPageIndexChanging="grdBranchMaster_PageIndexChanging"
						AutoGenerateColumns="False" EmptyDataText="No Record Found" OnRowEditing="grdBranchMaster_ActivatingObject" OnSelectedIndexChanged="grdBranchMaster_SelectedIndexChanged">
					<Columns>
						<asp:CommandField ShowSelectButton="True" SelectText="Select" HeaderText="Select"/>
						<asp:CommandField ShowEditButton="True" EditText="Activate" HeaderText="Activate" Visible="false"/>
						<asp:CommandField ShowDeleteButton="True" DeleteText="Delete" HeaderText="Delete"/>
						<asp:TemplateField HeaderText="Branch Code" >
							<ItemTemplate>
								<asp:Label ID="lblBranchCode" runat="server" Text='<%# Eval("Branch_Code") %>'></asp:Label> 
							</ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Branch Name" >
							<ItemTemplate>
								<asp:Label ID="lblBranchName" runat="server" Text='<%# Eval("Branch_Name") %>'></asp:Label> 
							</ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Established On" >
							<ItemTemplate>
								<asp:Label ID="lblEstablishedOn" runat="server" Text='<%# Eval("Established_On") %>'></asp:Label> 
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
				<asp:View ID="ViewBranchMasterControls" runat="server">
				<fieldset><legend>Branch Master</legend>
					<div id="dvBranchCode" class="dvColumnLeft">
					<asp:Label ID="lblBranchCode" runat="server" Text="Branch Code"></asp:Label> 
					<asp:TextBox ID="txtBranchCode" runat="server"></asp:TextBox>
					</div>
					<div id="dvBranchName" class="dvColumnRight">
					<asp:Label ID="lblBranchName" runat="server" Text="Branch Name"></asp:Label> 
					<asp:TextBox ID="txtBranchName" runat="server"></asp:TextBox>
					</div>
					<div id="dvBranch" class="dvColumnLeft">
					<asp:Label ID="lblBranch" runat="server" Text="First Name"></asp:Label> 
					<asp:DropDownList ID="ddlBranch" runat="server" DataValueField="Employee_Id" DataTextField="First_Name" ></asp:DropDownList> 
					</div>
					<div id="dvEstablishedOn" class="dvColumnRight">
					<asp:Label ID="lblEstablishedOn" runat="server" Text="Established On"></asp:Label> 
					<asp:TextBox ID="txtEstablishedOn" runat="server"></asp:TextBox>
					</div>
			<fieldset>
				<legend>Address Detail</legend>
				<uc1:AddressDetailUC ID="uxBranchAddressUC" runat="server" />
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
