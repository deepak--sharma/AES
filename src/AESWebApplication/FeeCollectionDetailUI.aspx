<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="FeeCollectionDetailUI.aspx.cs" Inherits="FeeCollectionDetailUI" MasterPageFile="~/MasterPage/MainMasterPage.master"%>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="Server">
	<title>FeeCollectionDetail Page</title>
</asp:Content>
		<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
		<div>
			<asp:MultiView ID="MultiViewFeeCollectionDetail" runat="server" ActiveViewIndex="0" > 
				<asp:View ID="ViewFeeCollectionDetailGrid" runat="server">
				<fieldset><legend>Fee Collection Detail List</legend>
					<asp:Button ID="btnAddNewRecord" runat="server" Text="Add New Record" OnClick="btnAddNewRecord_Click" />
					<asp:Label ID="lblViewOnly" runat="server" Text="View only - "></asp:Label>
					<asp:RadioButton ID="rdbActiveRecord" runat="server" Text="Live Records" GroupName="DisplayMode" AutoPostBack="True" Checked="True" OnCheckedChanged="rdbActiveRecord_CheckedChanged" />
					<asp:RadioButton ID="rdbInActiveRecord" runat="server" Text="Deleted Records" GroupName="DisplayMode" AutoPostBack="True" OnCheckedChanged="rdbInActiveRecord_CheckedChanged" />
					<asp:GridView ID="grdFeeCollectionDetail" runat="server" DataKeyNames="Fee_Collection_Id,Version" AllowPaging="True" OnRowDeleting="grdFeeCollectionDetail_RowDeleting" OnPageIndexChanging="grdFeeCollectionDetail_PageIndexChanging"
						AutoGenerateColumns="False" EmptyDataText="No Record Found" OnRowEditing="grdFeeCollectionDetail_ActivatingObject" OnSelectedIndexChanged="grdFeeCollectionDetail_SelectedIndexChanged">
					<Columns>
						<asp:CommandField ShowSelectButton="True" SelectText="Select" HeaderText="Select"/>
						<asp:CommandField ShowEditButton="True" EditText="Activate" HeaderText="Activate" Visible="false"/>
						<asp:CommandField ShowDeleteButton="True" DeleteText="Delete" HeaderText="Delete"/>
						<asp:TemplateField HeaderText="Base Fee" >
							<ItemTemplate>
								<asp:Label ID="lblBaseFee" runat="server" Text='<%# Eval("Base_Fee") %>'></asp:Label> 
							</ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Discount Fee" >
							<ItemTemplate>
								<asp:Label ID="lblDiscountFee" runat="server" Text='<%# Eval("Discount_Fee") %>'></asp:Label> 
							</ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Late Fee" >
							<ItemTemplate>
								<asp:Label ID="lblLateFee" runat="server" Text='<%# Eval("Late_Fee") %>'></asp:Label> 
							</ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Fine" >
							<ItemTemplate>
								<asp:Label ID="lblFine" runat="server" Text='<%# Eval("Fine") %>'></asp:Label> 
							</ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Total Fee" >
							<ItemTemplate>
								<asp:Label ID="lblTotalFee" runat="server" Text='<%# Eval("Total_Fee") %>'></asp:Label> 
							</ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Previous Balance" >
							<ItemTemplate>
								<asp:Label ID="lblPreviousBalance" runat="server" Text='<%# Eval("Previous_Balance") %>'></asp:Label> 
							</ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Fee Deposite" >
							<ItemTemplate>
								<asp:Label ID="lblFeeDeposite" runat="server" Text='<%# Eval("Fee_Deposite") %>'></asp:Label> 
							</ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Current Balance" >
							<ItemTemplate>
								<asp:Label ID="lblCurrentBalance" runat="server" Text='<%# Eval("Current_Balance") %>'></asp:Label> 
							</ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Submition Date" >
							<ItemTemplate>
								<asp:Label ID="lblSubmitionDate" runat="server" Text='<%# Eval("Submition_Date") %>'></asp:Label> 
							</ItemTemplate>
						</asp:TemplateField>
					</Columns>
					</asp:GridView>
				</fieldset>
				</asp:View>
				<asp:View ID="ViewFeeCollectionDetailControls" runat="server">
				<fieldset><legend>Fee Collection Detail</legend>
					<div id="dvStudent" class="dvColumnLeft">
					<asp:Label ID="lblStudent" runat="server" Text="Student Name"></asp:Label> 
					<asp:DropDownList ID="ddlStudent" runat="server" DataValueField="Student_Id" DataTextField="Student_Name" ></asp:DropDownList> 
					</div>
					<div id="dvBaseFee" class="dvColumnRight">
					<asp:Label ID="lblBaseFee" runat="server" Text="Base Fee"></asp:Label> 
					<asp:TextBox ID="txtBaseFee" runat="server"></asp:TextBox>
					</div>
					<div id="dvDiscountFee" class="dvColumnLeft">
					<asp:Label ID="lblDiscountFee" runat="server" Text="Discount Fee"></asp:Label> 
					<asp:TextBox ID="txtDiscountFee" runat="server"></asp:TextBox>
					</div>
					<div id="dvLateFee" class="dvColumnRight">
					<asp:Label ID="lblLateFee" runat="server" Text="Late Fee"></asp:Label> 
					<asp:TextBox ID="txtLateFee" runat="server"></asp:TextBox>
					</div>
					<div id="dvFine" class="dvColumnLeft">
					<asp:Label ID="lblFine" runat="server" Text="Fine"></asp:Label> 
					<asp:TextBox ID="txtFine" runat="server"></asp:TextBox>
					</div>
					<div id="dvTotalFee" class="dvColumnRight">
					<asp:Label ID="lblTotalFee" runat="server" Text="Total Fee"></asp:Label> 
					<asp:TextBox ID="txtTotalFee" runat="server"></asp:TextBox>
					</div>
					<div id="dvPreviousBalance" class="dvColumnLeft">
					<asp:Label ID="lblPreviousBalance" runat="server" Text="Previous Balance"></asp:Label> 
					<asp:TextBox ID="txtPreviousBalance" runat="server"></asp:TextBox>
					</div>
					<div id="dvFeeDeposite" class="dvColumnRight">
					<asp:Label ID="lblFeeDeposite" runat="server" Text="Fee Deposite"></asp:Label> 
					<asp:TextBox ID="txtFeeDeposite" runat="server"></asp:TextBox>
					</div>
					<div id="dvCurrentBalance" class="dvColumnLeft">
					<asp:Label ID="lblCurrentBalance" runat="server" Text="Current Balance"></asp:Label> 
					<asp:TextBox ID="txtCurrentBalance" runat="server"></asp:TextBox>
					</div>
					<div id="dvSubmitionDate" class="dvColumnRight">
					<asp:Label ID="lblSubmitionDate" runat="server" Text="Submition Date"></asp:Label> 
					<asp:TextBox ID="txtSubmitionDate" runat="server"></asp:TextBox>
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
