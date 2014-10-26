<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="ClassSubjectMappingUI.aspx.cs" Inherits="ClassSubjectMappingUI" MasterPageFile="~/MasterPage/MainMasterPage.master"%>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="Server">
	<title>ClassSubjectMapping Page</title>
</asp:Content>
		<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
		<div>
			<asp:MultiView ID="MultiViewClassSubjectMapping" runat="server" ActiveViewIndex="0" > 
				<asp:View ID="ViewClassSubjectMappingGrid" runat="server">
				<fieldset><legend>Class Subject Mapping List</legend>
					<asp:Button ID="btnAddNewRecord" runat="server" Text="Add New Record" OnClick="btnAddNewRecord_Click" />
					<asp:Label ID="lblViewOnly" runat="server" Text="View only - "></asp:Label>
					<asp:RadioButton ID="rdbActiveRecord" runat="server" Text="Live Records" GroupName="DisplayMode" AutoPostBack="True" Checked="True" OnCheckedChanged="rdbActiveRecord_CheckedChanged" />
					<asp:RadioButton ID="rdbInActiveRecord" runat="server" Text="Deleted Records" GroupName="DisplayMode" AutoPostBack="True" OnCheckedChanged="rdbInActiveRecord_CheckedChanged" />
					<asp:GridView ID="grdClassSubjectMapping" runat="server" DataKeyNames="Class_Subject_Mapping_Id,Version" AllowPaging="True" OnRowDeleting="grdClassSubjectMapping_RowDeleting" OnPageIndexChanging="grdClassSubjectMapping_PageIndexChanging"
						AutoGenerateColumns="False" EmptyDataText="No Record Found" OnRowEditing="grdClassSubjectMapping_ActivatingObject" OnSelectedIndexChanged="grdClassSubjectMapping_SelectedIndexChanged">
					<Columns>
						<asp:CommandField ShowSelectButton="True" SelectText="Select" HeaderText="Select"/>
						<asp:CommandField ShowEditButton="True" EditText="Activate" HeaderText="Activate" Visible="false"/>
						<asp:CommandField ShowDeleteButton="True" DeleteText="Delete" HeaderText="Delete"/>
						<asp:TemplateField HeaderText="Class Subject Mapping Name" >
							<ItemTemplate>
								<asp:Label ID="lblClassSubjectMappingName" runat="server" Text='<%# Eval("Class_Subject_Mapping_Name") %>'></asp:Label> 
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
				<asp:View ID="ViewClassSubjectMappingControls" runat="server">
				<fieldset><legend>Class Subject Mapping</legend>
					<div id="dvClassSubjectMappingName" class="dvColumnLeft">
					<asp:Label ID="lblClassSubjectMappingName" runat="server" Text="Class Subject Mapping Name"></asp:Label> 
					<asp:TextBox ID="txtClassSubjectMappingName" runat="server"></asp:TextBox>
					</div>
					<div id="dvClass" class="dvColumnRight">
					<asp:Label ID="lblClass" runat="server" Text="Class Name"></asp:Label> 
					<asp:DropDownList ID="ddlClass" runat="server" DataValueField="Class_Id" DataTextField="Class_Name" ></asp:DropDownList> 
					</div>
					<div id="dvSubject" class="dvColumnLeft">
					<asp:Label ID="lblSubject" runat="server" Text="Subject Name"></asp:Label> 
					<asp:DropDownList ID="ddlSubject" runat="server" DataValueField="Subject_Id" DataTextField="Subject_Name" ></asp:DropDownList> 
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
