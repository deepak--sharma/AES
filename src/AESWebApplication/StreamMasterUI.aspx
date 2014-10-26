<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="StreamMasterUI.aspx.cs" Inherits="StreamMasterUI" MasterPageFile="~/MasterPage/MainMasterPage.master"%>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="Server">
	<title>StreamMaster Page</title>
</asp:Content>
		<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
		<div>
			<asp:MultiView ID="MultiViewStreamMaster" runat="server" ActiveViewIndex="0" > 
				<asp:View ID="ViewStreamMasterGrid" runat="server">
				<fieldset><legend>Stream Master List</legend>
					<asp:Button ID="btnAddNewRecord" runat="server" Text="Add New Record" OnClick="btnAddNewRecord_Click" />
					<asp:Label ID="lblViewOnly" runat="server" Text="View only - "></asp:Label>
					<asp:RadioButton ID="rdbActiveRecord" runat="server" Text="Live Records" GroupName="DisplayMode" AutoPostBack="True" Checked="True" OnCheckedChanged="rdbActiveRecord_CheckedChanged" />
					<asp:RadioButton ID="rdbInActiveRecord" runat="server" Text="Deleted Records" GroupName="DisplayMode" AutoPostBack="True" OnCheckedChanged="rdbInActiveRecord_CheckedChanged" />
					<asp:GridView ID="grdStreamMaster" runat="server" DataKeyNames="Stream_Id,Version" AllowPaging="True" OnRowDeleting="grdStreamMaster_RowDeleting" OnPageIndexChanging="grdStreamMaster_PageIndexChanging"
						AutoGenerateColumns="False" EmptyDataText="No Record Found" OnRowEditing="grdStreamMaster_ActivatingObject" OnSelectedIndexChanged="grdStreamMaster_SelectedIndexChanged">
					<Columns>
						<asp:CommandField ShowSelectButton="True" SelectText="Select" HeaderText="Select"/>
						<asp:CommandField ShowEditButton="True" EditText="Activate" HeaderText="Activate" Visible="false"/>
						<asp:CommandField ShowDeleteButton="True" DeleteText="Delete" HeaderText="Delete"/>
						<asp:TemplateField HeaderText="Stream Name" >
							<ItemTemplate>
								<asp:Label ID="lblStreamName" runat="server" Text='<%# Eval("Stream_Name") %>'></asp:Label> 
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
				<asp:View ID="ViewStreamMasterControls" runat="server">
				<fieldset><legend>Stream Master</legend>
					<div id="dvClass" class="dvColumnLeft">
					<asp:Label ID="lblClass" runat="server" Text="Class Name"></asp:Label> 
					<asp:DropDownList ID="ddlClass" runat="server" DataValueField="Class_Id" DataTextField="Class_Name" ></asp:DropDownList> 
					</div>
					<div id="dvStreamName" class="dvColumnRight">
					<asp:Label ID="lblStreamName" runat="server" Text="Stream Name"></asp:Label> 
					<asp:TextBox ID="txtStreamName" runat="server"></asp:TextBox>
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
