<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="RoomMasterUI.aspx.cs" Inherits="RoomMasterUI" MasterPageFile="~/MasterPage/MainMasterPage.master"%>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="Server">
	<title>RoomMaster Page</title>
</asp:Content>
		<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
		<div>
			<asp:MultiView ID="MultiViewRoomMaster" runat="server" ActiveViewIndex="0" > 
				<asp:View ID="ViewRoomMasterGrid" runat="server">
				<fieldset><legend>Room Master List</legend>
					<asp:Button ID="btnAddNewRecord" runat="server" Text="Add New Record" OnClick="btnAddNewRecord_Click" />
					<asp:Label ID="lblViewOnly" runat="server" Text="View only - "></asp:Label>
					<asp:RadioButton ID="rdbActiveRecord" runat="server" Text="Live Records" GroupName="DisplayMode" AutoPostBack="True" Checked="True" OnCheckedChanged="rdbActiveRecord_CheckedChanged" />
					<asp:RadioButton ID="rdbInActiveRecord" runat="server" Text="Deleted Records" GroupName="DisplayMode" AutoPostBack="True" OnCheckedChanged="rdbInActiveRecord_CheckedChanged" />
					<asp:GridView ID="grdRoomMaster" runat="server" DataKeyNames="Room_Id,Version" AllowPaging="True" OnRowDeleting="grdRoomMaster_RowDeleting" OnPageIndexChanging="grdRoomMaster_PageIndexChanging"
						AutoGenerateColumns="False" EmptyDataText="No Record Found" OnRowEditing="grdRoomMaster_ActivatingObject" OnSelectedIndexChanged="grdRoomMaster_SelectedIndexChanged">
					<Columns>
						<asp:CommandField ShowSelectButton="True" SelectText="Select" HeaderText="Select"/>
						<asp:CommandField ShowEditButton="True" EditText="Activate" HeaderText="Activate" Visible="false"/>
						<asp:CommandField ShowDeleteButton="True" DeleteText="Delete" HeaderText="Delete"/>
						<asp:TemplateField HeaderText="Room Name" >
							<ItemTemplate>
								<asp:Label ID="lblRoomName" runat="server" Text='<%# Eval("Room_Name") %>'></asp:Label> 
							</ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Sitting Capacity" >
							<ItemTemplate>
								<asp:Label ID="lblSittingCapacity" runat="server" Text='<%# Eval("Sitting_Capacity") %>'></asp:Label> 
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
				<asp:View ID="ViewRoomMasterControls" runat="server">
				<fieldset><legend>Room Master</legend>
					<div id="dvRoomName" class="dvColumnLeft">
					<asp:Label ID="lblRoomName" runat="server" Text="Room Name"></asp:Label> 
					<asp:TextBox ID="txtRoomName" runat="server"></asp:TextBox>
					</div>
					<div id="dvRoom" class="dvColumnRight">
					<asp:Label ID="lblRoom" runat="server" Text="Room Type"></asp:Label> 
					<asp:DropDownList ID="ddlRoom" runat="server" DataValueField="Metadata_Id" DataTextField="Metadata_Name" ></asp:DropDownList> 
					</div>
					<div id="dvSittingCapacity" class="dvColumnLeft">
					<asp:Label ID="lblSittingCapacity" runat="server" Text="Sitting Capacity"></asp:Label> 
					<asp:TextBox ID="txtSittingCapacity" runat="server"></asp:TextBox>
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
