<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="SubjectMasterUI.aspx.cs" Inherits="SubjectMasterUI" MasterPageFile="~/MasterPage/MainMasterPage.master"%>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="Server">
	<title>SubjectMaster Page</title>
</asp:Content>
		<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
		<div>
			<asp:MultiView ID="MultiViewSubjectMaster" runat="server" ActiveViewIndex="0" > 
				<asp:View ID="ViewSubjectMasterGrid" runat="server">
				<fieldset><legend>Subject Master List</legend>
					<asp:Button ID="btnAddNewRecord" runat="server" Text="Add New Record" OnClick="btnAddNewRecord_Click" />
					<asp:Label ID="lblViewOnly" runat="server" Text="View only - "></asp:Label>
					<asp:RadioButton ID="rdbActiveRecord" runat="server" Text="Live Records" GroupName="DisplayMode" AutoPostBack="True" Checked="True" OnCheckedChanged="rdbActiveRecord_CheckedChanged" />
					<asp:RadioButton ID="rdbInActiveRecord" runat="server" Text="Deleted Records" GroupName="DisplayMode" AutoPostBack="True" OnCheckedChanged="rdbInActiveRecord_CheckedChanged" />
					<asp:GridView ID="grdSubjectMaster" runat="server" DataKeyNames="Subject_Id,Version" AllowPaging="True" OnRowDeleting="grdSubjectMaster_RowDeleting" OnPageIndexChanging="grdSubjectMaster_PageIndexChanging"
						AutoGenerateColumns="False" EmptyDataText="No Record Found" OnRowEditing="grdSubjectMaster_ActivatingObject" OnSelectedIndexChanged="grdSubjectMaster_SelectedIndexChanged">
					<Columns>
						<asp:CommandField ShowSelectButton="True" SelectText="Select" HeaderText="Select"/>
						<asp:CommandField ShowEditButton="True" EditText="Activate" HeaderText="Activate" Visible="false"/>
						<asp:CommandField ShowDeleteButton="True" DeleteText="Delete" HeaderText="Delete"/>
						<asp:TemplateField HeaderText="Subject Code" >
							<ItemTemplate>
								<asp:Label ID="lblSubjectCode" runat="server" Text='<%# Eval("Subject_Code") %>'></asp:Label> 
							</ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Subject Name" >
							<ItemTemplate>
								<asp:Label ID="lblSubjectName" runat="server" Text='<%# Eval("Subject_Name") %>'></asp:Label> 
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
				<asp:View ID="ViewSubjectMasterControls" runat="server">
				<fieldset><legend>Subject Master</legend>
					<div id="dvSubjectCode" class="dvColumnLeft">
					<asp:Label ID="lblSubjectCode" runat="server" Text="Subject Code"></asp:Label> 
					<asp:TextBox ID="txtSubjectCode" runat="server"></asp:TextBox>
					</div>
					<div id="dvSubjectName" class="dvColumnRight">
					<asp:Label ID="lblSubjectName" runat="server" Text="Subject Name"></asp:Label> 
					<asp:TextBox ID="txtSubjectName" runat="server"></asp:TextBox>
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
