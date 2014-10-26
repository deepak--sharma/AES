<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="MetadataTypeUI.aspx.cs" Inherits="MetadataTypeUI" MasterPageFile="~/MasterPage/MainMasterPage.master"%>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="Server">
	<title>MetadataType Page</title>
</asp:Content>
		<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
		<div>
			<asp:MultiView ID="MultiViewMetadataType" runat="server" ActiveViewIndex="0" > 
				<asp:View ID="ViewMetadataTypeGrid" runat="server">
				<fieldset><legend>Metadata Type List</legend>
					<asp:Button ID="btnAddNewRecord" runat="server" Text="Add New Record" OnClick="btnAddNewRecord_Click" />
					<asp:Label ID="lblViewOnly" runat="server" Text="View only - "></asp:Label>
					<asp:RadioButton ID="rdbActiveRecord" runat="server" Text="Live Records" GroupName="DisplayMode" AutoPostBack="True" Checked="True" OnCheckedChanged="rdbActiveRecord_CheckedChanged" />
					<asp:RadioButton ID="rdbInActiveRecord" runat="server" Text="Deleted Records" GroupName="DisplayMode" AutoPostBack="True" OnCheckedChanged="rdbInActiveRecord_CheckedChanged" />
					<asp:GridView ID="grdMetadataType" runat="server" DataKeyNames="Metadata_Type_Id,Version" AllowPaging="True" OnRowDeleting="grdMetadataType_RowDeleting" OnPageIndexChanging="grdMetadataType_PageIndexChanging"
						AutoGenerateColumns="False" EmptyDataText="No Record Found" OnRowEditing="grdMetadataType_ActivatingObject" OnSelectedIndexChanged="grdMetadataType_SelectedIndexChanged">
					<Columns>
						<asp:CommandField ShowSelectButton="True" SelectText="Select" HeaderText="Select"/>
						<asp:CommandField ShowEditButton="True" EditText="Activate" HeaderText="Activate" Visible="false"/>
						<asp:CommandField ShowDeleteButton="True" DeleteText="Delete" HeaderText="Delete"/>
						<asp:TemplateField HeaderText="Metadata Type Name" >
							<ItemTemplate>
								<asp:Label ID="lblMetadataTypeName" runat="server" Text='<%# Eval("Metadata_Type_Name") %>'></asp:Label> 
							</ItemTemplate>
						</asp:TemplateField>
					</Columns>
					</asp:GridView>
				</fieldset>
				</asp:View>
				<asp:View ID="ViewMetadataTypeControls" runat="server">
				<fieldset><legend>Metadata Type</legend>
					<div id="dvMetadataTypeName" class="dvColumnLeft">
					<asp:Label ID="lblMetadataTypeName" runat="server" Text="Metadata Type Name"></asp:Label> 
					<asp:TextBox ID="txtMetadataTypeName" runat="server"></asp:TextBox>
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
