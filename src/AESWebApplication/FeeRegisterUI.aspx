<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="FeeRegisterUI.aspx.cs" Inherits="FeeRegisterUI" MasterPageFile="~/MasterPage/MainMasterPage.master"%>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="Server">
	<title>FeeRegister Page</title>
</asp:Content>
		<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
		<div>
			<asp:MultiView ID="MultiViewFeeRegister" runat="server" ActiveViewIndex="0" > 
				<asp:View ID="ViewFeeRegisterGrid" runat="server">
				<fieldset><legend>Fee Register List</legend>
					<asp:Button ID="btnAddNewRecord" runat="server" Text="Add New Record" OnClick="btnAddNewRecord_Click" />
					<asp:Label ID="lblViewOnly" runat="server" Text="View only - "></asp:Label>
					<asp:RadioButton ID="rdbActiveRecord" runat="server" Text="Live Records" GroupName="DisplayMode" AutoPostBack="True" Checked="True" OnCheckedChanged="rdbActiveRecord_CheckedChanged" />
					<asp:RadioButton ID="rdbInActiveRecord" runat="server" Text="Deleted Records" GroupName="DisplayMode" AutoPostBack="True" OnCheckedChanged="rdbInActiveRecord_CheckedChanged" />
					<asp:GridView ID="grdFeeRegister" runat="server" DataKeyNames="Fee_Register_Id,Version" AllowPaging="True" OnRowDeleting="grdFeeRegister_RowDeleting" OnPageIndexChanging="grdFeeRegister_PageIndexChanging"
						AutoGenerateColumns="False" EmptyDataText="No Record Found" OnRowEditing="grdFeeRegister_ActivatingObject" OnSelectedIndexChanged="grdFeeRegister_SelectedIndexChanged">
					<Columns>
						<asp:CommandField ShowSelectButton="True" SelectText="Select" HeaderText="Select"/>
						<asp:CommandField ShowEditButton="True" EditText="Activate" HeaderText="Activate" Visible="false"/>
						<asp:CommandField ShowDeleteButton="True" DeleteText="Delete" HeaderText="Delete"/>
						<asp:TemplateField HeaderText="Component Amount" >
							<ItemTemplate>
								<asp:Label ID="lblComponentAmount" runat="server" Text='<%# Eval("Component_Amount") %>'></asp:Label> 
							</ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Component Type" >
							<ItemTemplate>
								<asp:Label ID="lblComponentType" runat="server" Text='<%# Eval("Component_Type") %>'></asp:Label> 
							</ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Process Date" >
							<ItemTemplate>
								<asp:Label ID="lblProcessDate" runat="server" Text='<%# Eval("Process_Date") %>'></asp:Label> 
							</ItemTemplate>
						</asp:TemplateField>
					</Columns>
					</asp:GridView>
				</fieldset>
				</asp:View>
				<asp:View ID="ViewFeeRegisterControls" runat="server">
				<fieldset><legend>Fee Register</legend>
					<div id="dvFee" class="dvColumnLeft">
					<asp:Label ID="lblFee" runat="server" Text="Fee Structure Name"></asp:Label> 
					<asp:DropDownList ID="ddlFee" runat="server" DataValueField="Fee_Structure_Id" DataTextField="Fee_Structure_Name" ></asp:DropDownList> 
					</div>
					<div id="dvStudent" class="dvColumnRight">
					<asp:Label ID="lblStudent" runat="server" Text="Student Name"></asp:Label> 
					<asp:DropDownList ID="ddlStudent" runat="server" DataValueField="Student_Id" DataTextField="Student_Name" ></asp:DropDownList> 
					</div>
					<div id="dvComponent" class="dvColumnLeft">
					<asp:Label ID="lblComponent" runat="server" Text="Fee Name"></asp:Label> 
					<asp:DropDownList ID="ddlComponent" runat="server" DataValueField="Fee_Id" DataTextField="Fee_Name" ></asp:DropDownList> 
					</div>
					<div id="dvComponentAmount" class="dvColumnRight">
					<asp:Label ID="lblComponentAmount" runat="server" Text="Component Amount"></asp:Label> 
					<asp:TextBox ID="txtComponentAmount" runat="server"></asp:TextBox>
					</div>
					<div id="dvComponentType" class="dvColumnLeft">
					<asp:Label ID="lblComponentType" runat="server" Text="Component Type"></asp:Label> 
					<asp:TextBox ID="txtComponentType" runat="server"></asp:TextBox>
					</div>
					<div id="dvProcessDate" class="dvColumnRight">
					<asp:Label ID="lblProcessDate" runat="server" Text="Process Date"></asp:Label> 
					<asp:TextBox ID="txtProcessDate" runat="server"></asp:TextBox>
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
