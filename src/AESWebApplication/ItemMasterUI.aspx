<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="ItemMasterUI.aspx.cs" Inherits="ItemMasterUI" MasterPageFile="~/MasterPage/MainMasterPage.master"%>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="Server">
	<title>ItemMaster Page</title>
</asp:Content>
		<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
		<div>
			<asp:MultiView ID="MultiViewItemMaster" runat="server" ActiveViewIndex="0" > 
				<asp:View ID="ViewItemMasterGrid" runat="server">
				<fieldset><legend>Item Master List</legend>
					<asp:Button ID="btnAddNewRecord" runat="server" Text="Add New Record" OnClick="btnAddNewRecord_Click" />
					<asp:Label ID="lblViewOnly" runat="server" Text="View only - "></asp:Label>
					<asp:RadioButton ID="rdbActiveRecord" runat="server" Text="Live Records" GroupName="DisplayMode" AutoPostBack="True" Checked="True" OnCheckedChanged="rdbActiveRecord_CheckedChanged" />
					<asp:RadioButton ID="rdbInActiveRecord" runat="server" Text="Deleted Records" GroupName="DisplayMode" AutoPostBack="True" OnCheckedChanged="rdbInActiveRecord_CheckedChanged" />
					<asp:GridView ID="grdItemMaster" runat="server" DataKeyNames="Item_ID,Version" AllowPaging="True" OnRowDeleting="grdItemMaster_RowDeleting" OnPageIndexChanging="grdItemMaster_PageIndexChanging"
						AutoGenerateColumns="False" EmptyDataText="No Record Found" OnRowEditing="grdItemMaster_ActivatingObject" OnSelectedIndexChanged="grdItemMaster_SelectedIndexChanged">
					<Columns>
						<asp:CommandField ShowSelectButton="True" SelectText="Select" HeaderText="Select"/>
						<asp:CommandField ShowEditButton="True" EditText="Activate" HeaderText="Activate" Visible="false"/>
						<asp:CommandField ShowDeleteButton="True" DeleteText="Delete" HeaderText="Delete"/>
						<asp:TemplateField HeaderText="Item Code" >
							<ItemTemplate>
								<asp:Label ID="lblItemCode" runat="server" Text='<%# Eval("Item_Code") %>'></asp:Label> 
							</ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Bar Code" >
							<ItemTemplate>
								<asp:Label ID="lblBarCode" runat="server" Text='<%# Eval("Bar_Code") %>'></asp:Label> 
							</ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Writer Name" >
							<ItemTemplate>
								<asp:Label ID="lblWriterName" runat="server" Text='<%# Eval("Writer_Name") %>'></asp:Label> 
							</ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Publisher Name" >
							<ItemTemplate>
								<asp:Label ID="lblPublisherName" runat="server" Text='<%# Eval("Publisher_Name") %>'></asp:Label> 
							</ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Edition" >
							<ItemTemplate>
								<asp:Label ID="lblEdition" runat="server" Text='<%# Eval("Edition") %>'></asp:Label> 
							</ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Publish Date" >
							<ItemTemplate>
								<asp:Label ID="lblPublishDate" runat="server" Text='<%# Eval("Publish_Date") %>'></asp:Label> 
							</ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Volume" >
							<ItemTemplate>
								<asp:Label ID="lblVolume" runat="server" Text='<%# Eval("Volume") %>'></asp:Label> 
							</ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Cell Id" >
							<ItemTemplate>
								<asp:Label ID="lblCellId" runat="server" Text='<%# Eval("Cell_Id") %>'></asp:Label> 
							</ItemTemplate>
						</asp:TemplateField>
					</Columns>
					</asp:GridView>
				</fieldset>
				</asp:View>
				<asp:View ID="ViewItemMasterControls" runat="server">
				<fieldset><legend>Item Master</legend>
					<div id="dvItemCode" class="dvColumnLeft">
					<asp:Label ID="lblItemCode" runat="server" Text="Item Code"></asp:Label> 
					<asp:TextBox ID="txtItemCode" runat="server"></asp:TextBox>
					</div>
					<div id="dvBarCode" class="dvColumnRight">
					<asp:Label ID="lblBarCode" runat="server" Text="Bar Code"></asp:Label> 
					<asp:TextBox ID="txtBarCode" runat="server"></asp:TextBox>
					</div>
					<div id="dvClass" class="dvColumnLeft">
					<asp:Label ID="lblClass" runat="server" Text="Class Subject Mapping Name"></asp:Label> 
					<asp:DropDownList ID="ddlClass" runat="server" DataValueField="Class_Subject_Mapping_Id" DataTextField="Class_Subject_Mapping_Name" ></asp:DropDownList> 
					</div>
					<div id="dvWriterName" class="dvColumnRight">
					<asp:Label ID="lblWriterName" runat="server" Text="Writer Name"></asp:Label> 
					<asp:TextBox ID="txtWriterName" runat="server"></asp:TextBox>
					</div>
					<div id="dvPublisherName" class="dvColumnLeft">
					<asp:Label ID="lblPublisherName" runat="server" Text="Publisher Name"></asp:Label> 
					<asp:TextBox ID="txtPublisherName" runat="server"></asp:TextBox>
					</div>
					<div id="dvMedium" class="dvColumnRight">
					<asp:Label ID="lblMedium" runat="server" Text="Medium"></asp:Label> 
					<asp:DropDownList ID="ddlMedium" runat="server" DataValueField="Metadata_Id" DataTextField="Metadata_Name" ></asp:DropDownList> 
					</div>
					<div id="dvEdition" class="dvColumnLeft">
					<asp:Label ID="lblEdition" runat="server" Text="Edition"></asp:Label> 
					<asp:TextBox ID="txtEdition" runat="server"></asp:TextBox>
					</div>
					<div id="dvPublishDate" class="dvColumnRight">
					<asp:Label ID="lblPublishDate" runat="server" Text="Publish Date"></asp:Label> 
					<asp:TextBox ID="txtPublishDate" runat="server"></asp:TextBox>
					</div>
					<div id="dvVolume" class="dvColumnLeft">
					<asp:Label ID="lblVolume" runat="server" Text="Volume"></asp:Label> 
					<asp:TextBox ID="txtVolume" runat="server"></asp:TextBox>
					</div>
					<div id="dvRack" class="dvColumnRight">
					<asp:Label ID="lblRack" runat="server" Text="Rack Code"></asp:Label> 
					<asp:DropDownList ID="ddlRack" runat="server" DataValueField="Rack_ID" DataTextField="Rack_Code" ></asp:DropDownList> 
					</div>
					<div id="dvCellId" class="dvColumnLeft">
					<asp:Label ID="lblCellId" runat="server" Text="Cell Id"></asp:Label> 
					<asp:TextBox ID="txtCellId" runat="server"></asp:TextBox>
					</div>
					<div id="dvItem" class="dvColumnRight">
					<asp:Label ID="lblItem" runat="server" Text="Item Type Name"></asp:Label> 
					<asp:DropDownList ID="ddlItem" runat="server" DataValueField="Item_Type_ID" DataTextField="Item_Type_Name" ></asp:DropDownList> 
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
