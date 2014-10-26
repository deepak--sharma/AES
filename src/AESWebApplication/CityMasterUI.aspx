<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="CityMasterUI.aspx.cs" Inherits="CityMasterUI" MasterPageFile="~/MasterPage/MainMasterPage.master"%>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="Server">
	<title>CityMaster Page</title>
</asp:Content>
		<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
		<div>
			<asp:MultiView ID="MultiViewCityMaster" runat="server" ActiveViewIndex="0" > 
				<asp:View ID="ViewCityMasterGrid" runat="server">
				<fieldset><legend>City Master List</legend>
					<asp:Button ID="btnAddNewRecord" runat="server" Text="Add New Record" OnClick="btnAddNewRecord_Click" />
					<asp:Label ID="lblViewOnly" runat="server" Text="View only - "></asp:Label>
					<asp:RadioButton ID="rdbActiveRecord" runat="server" Text="Live Records" GroupName="DisplayMode" AutoPostBack="True" Checked="True" OnCheckedChanged="rdbActiveRecord_CheckedChanged" />
					<asp:RadioButton ID="rdbInActiveRecord" runat="server" Text="Deleted Records" GroupName="DisplayMode" AutoPostBack="True" OnCheckedChanged="rdbInActiveRecord_CheckedChanged" />
					<asp:GridView ID="grdCityMaster" runat="server" DataKeyNames="City_Id,Version" AllowPaging="True" OnRowDeleting="grdCityMaster_RowDeleting" OnPageIndexChanging="grdCityMaster_PageIndexChanging"
						AutoGenerateColumns="False" EmptyDataText="No Record Found" OnRowEditing="grdCityMaster_ActivatingObject" OnSelectedIndexChanged="grdCityMaster_SelectedIndexChanged">
					<Columns>
						<asp:CommandField ShowSelectButton="True" SelectText="Select" HeaderText="Select"/>
						<asp:CommandField ShowEditButton="True" EditText="Activate" HeaderText="Activate" Visible="false"/>
						<asp:CommandField ShowDeleteButton="True" DeleteText="Delete" HeaderText="Delete"/>
						<asp:TemplateField HeaderText="City Name" >
							<ItemTemplate>
								<asp:Label ID="lblCityName" runat="server" Text='<%# Eval("City_Name") %>'></asp:Label> 
							</ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Is Default Selected" >
							<ItemTemplate>
								<asp:Label ID="lblIsDefaultSelected" runat="server" Text='<%# Eval("Is_Default_Selected") %>'></asp:Label> 
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
				<asp:View ID="ViewCityMasterControls" runat="server">
				<fieldset><legend>City Master</legend>
					<div id="dvCityName" class="dvColumnLeft">
					<asp:Label ID="lblCityName" runat="server" Text="City Name"></asp:Label> 
					<asp:TextBox ID="txtCityName" runat="server"></asp:TextBox>
					</div>
					<div id="dvState" class="dvColumnRight">
					<asp:Label ID="lblState" runat="server" Text="State Name"></asp:Label> 
					<asp:DropDownList ID="ddlState" runat="server" DataValueField="State_Id" DataTextField="State_Name" ></asp:DropDownList> 
					</div>
					<div id="dvIsDefaultSelected" class="dvColumnLeft">
					<asp:Label ID="lblIsDefaultSelected" runat="server" Text="Is Default Selected"></asp:Label> 
					<asp:DropDownList ID="ddlIsDefaultSelected" runat="server">
						<asp:ListItem Value="-Select-">-Select-</asp:ListItem>
						<asp:ListItem Value="True">True</asp:ListItem>
						<asp:ListItem Value="False">False</asp:ListItem>
					</asp:DropDownList>
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
