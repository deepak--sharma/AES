<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="AcademicSessionMasterUI.aspx.cs" Inherits="AcademicSessionMasterUI" MasterPageFile="~/MasterPage/MainMasterPage.master"%>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="Server">
	<title>AcademicSessionMaster Page</title>
</asp:Content>
		<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
		<div>
			<asp:MultiView ID="MultiViewAcademicSessionMaster" runat="server" ActiveViewIndex="0" > 
				<asp:View ID="ViewAcademicSessionMasterGrid" runat="server">
				<fieldset><legend>Academic Session Master List</legend>
					<asp:Button ID="btnAddNewRecord" runat="server" Text="Add New Record" OnClick="btnAddNewRecord_Click" />
					<asp:Label ID="lblViewOnly" runat="server" Text="View only - "></asp:Label>
					<asp:RadioButton ID="rdbActiveRecord" runat="server" Text="Live Records" GroupName="DisplayMode" AutoPostBack="True" Checked="True" OnCheckedChanged="rdbActiveRecord_CheckedChanged" />
					<asp:RadioButton ID="rdbInActiveRecord" runat="server" Text="Deleted Records" GroupName="DisplayMode" AutoPostBack="True" OnCheckedChanged="rdbInActiveRecord_CheckedChanged" />
					<asp:GridView ID="grdAcademicSessionMaster" runat="server" DataKeyNames="Session_Id,Version" AllowPaging="True" OnRowDeleting="grdAcademicSessionMaster_RowDeleting" OnPageIndexChanging="grdAcademicSessionMaster_PageIndexChanging"
						AutoGenerateColumns="False" EmptyDataText="No Record Found" OnRowEditing="grdAcademicSessionMaster_ActivatingObject" OnSelectedIndexChanged="grdAcademicSessionMaster_SelectedIndexChanged">
					<Columns>
						<asp:CommandField ShowSelectButton="True" SelectText="Select" HeaderText="Select"/>
						<asp:CommandField ShowEditButton="True" EditText="Activate" HeaderText="Activate" Visible="false"/>
						<asp:CommandField ShowDeleteButton="True" DeleteText="Delete" HeaderText="Delete"/>
						<asp:TemplateField HeaderText="Session Name" >
							<ItemTemplate>
								<asp:Label ID="lblSessionName" runat="server" Text='<%# Eval("Session_Name") %>'></asp:Label> 
							</ItemTemplate>
						</asp:TemplateField>
					</Columns>
					</asp:GridView>
				</fieldset>
				</asp:View>
				<asp:View ID="ViewAcademicSessionMasterControls" runat="server">
				<fieldset><legend>Academic Session Master</legend>
					<div id="dvSessionName" class="dvColumnLeft">
					<asp:Label ID="lblSessionName" runat="server" Text="Session Name"></asp:Label> 
					<asp:TextBox ID="txtSessionName" runat="server"></asp:TextBox>
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
