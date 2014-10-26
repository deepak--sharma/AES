<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="CourseMasterUI.aspx.cs" Inherits="CourseMasterUI" MasterPageFile="~/MasterPage/MainMasterPage.master"%>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="Server">
	<title>CourseMaster Page</title>
</asp:Content>
		<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
		<div>
			<asp:MultiView ID="MultiViewCourseMaster" runat="server" ActiveViewIndex="0" > 
				<asp:View ID="ViewCourseMasterGrid" runat="server">
				<fieldset><legend>Course Master List</legend>
					<asp:Button ID="btnAddNewRecord" runat="server" Text="Add New Record" OnClick="btnAddNewRecord_Click" />
					<asp:Label ID="lblViewOnly" runat="server" Text="View only - "></asp:Label>
					<asp:RadioButton ID="rdbActiveRecord" runat="server" Text="Live Records" GroupName="DisplayMode" AutoPostBack="True" Checked="True" OnCheckedChanged="rdbActiveRecord_CheckedChanged" />
					<asp:RadioButton ID="rdbInActiveRecord" runat="server" Text="Deleted Records" GroupName="DisplayMode" AutoPostBack="True" OnCheckedChanged="rdbInActiveRecord_CheckedChanged" />
					<asp:GridView ID="grdCourseMaster" runat="server" DataKeyNames="Course_Id,Version" AllowPaging="True" OnRowDeleting="grdCourseMaster_RowDeleting" OnPageIndexChanging="grdCourseMaster_PageIndexChanging"
						AutoGenerateColumns="False" EmptyDataText="No Record Found" OnRowEditing="grdCourseMaster_ActivatingObject" OnSelectedIndexChanged="grdCourseMaster_SelectedIndexChanged">
					<Columns>
						<asp:CommandField ShowSelectButton="True" SelectText="Select" HeaderText="Select"/>
						<asp:CommandField ShowEditButton="True" EditText="Activate" HeaderText="Activate" Visible="false"/>
						<asp:CommandField ShowDeleteButton="True" DeleteText="Delete" HeaderText="Delete"/>
						<asp:TemplateField HeaderText="Course Name" >
							<ItemTemplate>
								<asp:Label ID="lblCourseName" runat="server" Text='<%# Eval("Course_Name") %>'></asp:Label> 
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
				<asp:View ID="ViewCourseMasterControls" runat="server">
				<fieldset><legend>Course Master</legend>
					<div id="dvCourseName" class="dvColumnLeft">
					<asp:Label ID="lblCourseName" runat="server" Text="Course Name"></asp:Label> 
					<asp:TextBox ID="txtCourseName" runat="server"></asp:TextBox>
					</div>
					<div id="dvDescription" class="dvColumnRight">
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
