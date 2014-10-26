<%@ Control Language="C#" AutoEventWireup="true" CodeFile="FeeDiscountSetupUC.ascx.cs" Inherits="FeeDiscountSetupUC" %>

			<asp:MultiView ID="MultiViewFeeDiscountSetup" runat="server" ActiveViewIndex="0" > 
				<asp:View ID="ViewFeeDiscountSetupGrid" runat="server">
				<fieldset><legend>Fee Discount Setup List</legend>
					<asp:Button ID="btnAddRecord" runat="server" Text="Add Record" OnClick="btnAddRecord_Click" />
					<asp:GridView ID="grdFeeDiscountSetup" runat="server" DataKeyNames="Fee_Discount_Id,Discount_Type_Id" AllowPaging="True" OnRowDeleting="grdFeeDiscountSetup_RowDeleting" OnPageIndexChanging="grdFeeDiscountSetup_PageIndexChanging"
						AutoGenerateColumns="False" EmptyDataText="No Record Found" OnSelectedIndexChanged="grdFeeDiscountSetup_SelectedIndexChanged">
					<Columns>
						<asp:CommandField ShowSelectButton="True" SelectText="Select" HeaderText="Select"/>
						<asp:CommandField ShowDeleteButton="True" DeleteText="Delete" HeaderText="Delete"/>
						<asp:TemplateField HeaderText="Discount Type Value" >
							<ItemTemplate>
								<asp:Label ID="lblDiscountTypeValue" runat="server" Text='<%# Eval("Discount_Type_Value") %>'></asp:Label> 
							</ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Discount Amount" >
							<ItemTemplate>
								<asp:Label ID="lblDiscountAmount" runat="server" Text='<%# Eval("Discount_Amount") %>'></asp:Label> 
							</ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Is Percent" >
							<ItemTemplate>
								<asp:Label ID="lblIsPercent" runat="server" Text='<%# Eval("Is_Percent") %>'></asp:Label> 
							</ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Effective Date" >
							<ItemTemplate>
								<asp:Label ID="lblEffectiveDate" runat="server" Text='<%# Eval("Effective_Date") %>'></asp:Label> 
							</ItemTemplate>
						</asp:TemplateField>
					</Columns>
					</asp:GridView>
				</fieldset>
				</asp:View>
				<asp:View ID="ViewFeeDiscountSetupControls" runat="server">
				<fieldset><legend>Fee Discount Setup</legend>
					<asp:HiddenField ID="hfSessionDataKey" runat="server" />
					<asp:HiddenField ID="hfIsControlsLoaded" runat="server" />
					<asp:HiddenField ID="hfEditIndexKey" runat="server" />
					<div id="dvDiscount" class="dvColumnLeft">
					<asp:Label ID="lblDiscount" runat="server" Text="Fee Name"></asp:Label> 
					<asp:DropDownList ID="ddlDiscount" runat="server" DataValueField="Fee_Id" DataTextField="Fee_Name" ></asp:DropDownList> 
					</div>
					<div id="dvDiscountTypeValue" class="dvColumnRight">
					<asp:Label ID="lblDiscountTypeValue" runat="server" Text="Discount Type Value"></asp:Label> 
					<asp:TextBox ID="txtDiscountTypeValue" runat="server"></asp:TextBox>
					</div>
					<div id="dvDiscountAmount" class="dvColumnLeft">
					<asp:Label ID="lblDiscountAmount" runat="server" Text="Discount Amount"></asp:Label> 
					<asp:TextBox ID="txtDiscountAmount" runat="server"></asp:TextBox>
					</div>
					<div id="dvIsPercent" class="dvColumnRight">
					<asp:Label ID="lblIsPercent" runat="server" Text="Is Percent"></asp:Label> 
					<asp:DropDownList ID="ddlIsPercent" runat="server">
						<asp:ListItem Value="-Select-">-Select-</asp:ListItem>
						<asp:ListItem Value="True">True</asp:ListItem>
						<asp:ListItem Value="False">False</asp:ListItem>
					</asp:DropDownList>
					</div>
					<div id="dvEffectiveDate" class="dvColumnLeft">
					<asp:Label ID="lblEffectiveDate" runat="server" Text="Effective Date"></asp:Label> 
					<asp:TextBox ID="txtEffectiveDate" runat="server"></asp:TextBox>
					</div>
				</fieldset>

				<asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save" />
				<asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Cancel" />
				</asp:View>
			</asp:MultiView>
			<asp:Label ID="lblMessage" runat="server" EnableViewState="False"></asp:Label>
