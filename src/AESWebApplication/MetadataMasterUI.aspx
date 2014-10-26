<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="MetadataMasterUI.aspx.cs" Inherits="MetadataMasterUI" MasterPageFile="~/MasterPage/MainMasterPage.master"%>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="Server">
	<title>MetadataMaster Page</title>
</asp:Content>
		<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
		<div>
			<asp:MultiView ID="MultiViewMetadataMaster" runat="server" ActiveViewIndex="0" > 
				<asp:View ID="ViewMetadataMasterGrid" runat="server">
				<fieldset><legend>Metadata Master List</legend>
					<asp:Button ID="btnAddNewRecord" runat="server" Text="Add New Record" OnClick="btnAddNewRecord_Click" />
					<asp:Label ID="lblViewOnly" runat="server" Text="View only - "></asp:Label>
					<asp:RadioButton ID="rdbActiveRecord" runat="server" Text="Live Records" GroupName="DisplayMode" AutoPostBack="True" Checked="True" OnCheckedChanged="rdbActiveRecord_CheckedChanged" />
					<asp:RadioButton ID="rdbInActiveRecord" runat="server" Text="Deleted Records" GroupName="DisplayMode" AutoPostBack="True" OnCheckedChanged="rdbInActiveRecord_CheckedChanged" />
					<asp:GridView ID="grdMetadataMaster" runat="server" DataKeyNames="Metadata_Id,Version" AllowPaging="True" OnRowDeleting="grdMetadataMaster_RowDeleting" OnPageIndexChanging="grdMetadataMaster_PageIndexChanging"
						AutoGenerateColumns="False" EmptyDataText="No Record Found" OnRowEditing="grdMetadataMaster_ActivatingObject" OnSelectedIndexChanged="grdMetadataMaster_SelectedIndexChanged">
					<Columns>
						<asp:CommandField ShowSelectButton="True" SelectText="Select" HeaderText="Select"/>
						<asp:CommandField ShowEditButton="True" EditText="Activate" HeaderText="Activate" Visible="false"/>
						<asp:CommandField ShowDeleteButton="True" DeleteText="Delete" HeaderText="Delete"/>
						<asp:TemplateField HeaderText="Metadata Name" >
							<ItemTemplate>
								<asp:Label ID="lblMetadataName" runat="server" Text='<%# Eval("Metadata_Name") %>'></asp:Label> 
							</ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Metadata Code" >
							<ItemTemplate>
								<asp:Label ID="lblMetadataCode" runat="server" Text='<%# Eval("Metadata_Code") %>'></asp:Label> 
							</ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Is System Type" >
							<ItemTemplate>
								<asp:Label ID="lblIsSystemType" runat="server" Text='<%# Eval("Is_System_Type") %>'></asp:Label> 
							</ItemTemplate>
						</asp:TemplateField>
					</Columns>
					</asp:GridView>
				</fieldset>
				</asp:View>
				<asp:View ID="ViewMetadataMasterControls" runat="server">
				<fieldset><legend>Metadata Master</legend>
					<div id="dvMetadata" class="dvColumnLeft">
					<asp:Label ID="lblMetadata" runat="server" Text="Metadata Type Name"></asp:Label> 
					<asp:DropDownList ID="ddlMetadata" runat="server" DataValueField="Metadata_Type_Id" DataTextField="Metadata_Type_Name" ></asp:DropDownList> 
					</div>
					<div id="dvMetadataName" class="dvColumnRight">
					<asp:Label ID="lblMetadataName" runat="server" Text="Metadata Name"></asp:Label> 
					<asp:TextBox ID="txtMetadataName" runat="server"></asp:TextBox>
					</div>
					<div id="dvMetadataCode" class="dvColumnLeft">
					<asp:Label ID="lblMetadataCode" runat="server" Text="Metadata Code"></asp:Label> 
					<asp:TextBox ID="txtMetadataCode" runat="server"></asp:TextBox>
					</div>
					<div id="dvIsSystemType" class="dvColumnRight">
					<asp:Label ID="lblIsSystemType" runat="server" Text="Is System Type"></asp:Label> 
					<asp:DropDownList ID="ddlIsSystemType" runat="server">
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
