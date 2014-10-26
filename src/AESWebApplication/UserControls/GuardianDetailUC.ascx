<%@ Control Language="C#" AutoEventWireup="true" CodeFile="GuardianDetailUC.ascx.cs" Inherits="GuardianDetailUC" %>

				<fieldset><legend>Guardian Detail</legend>
					<asp:HiddenField ID="hfGuardianId" runat="server" />
					<div id="dvFullName" class="dvColumnLeft">
					<asp:Label ID="lblFullName" runat="server" Text="Full Name"></asp:Label> 
					<asp:TextBox ID="txtFullName" runat="server"></asp:TextBox>
					</div>
					<div id="dvDateOfBirth" class="dvColumnRight">
					<asp:Label ID="lblDateOfBirth" runat="server" Text="Date Of Birth"></asp:Label> 
					<asp:TextBox ID="txtDateOfBirth" runat="server"></asp:TextBox>
					</div>
					<div id="dvContactNo" class="dvColumnLeft">
					<asp:Label ID="lblContactNo" runat="server" Text="Contact No"></asp:Label> 
					<asp:TextBox ID="txtContactNo" runat="server"></asp:TextBox>
					</div>
					<div id="dvDesignation" class="dvColumnRight">
					<asp:Label ID="lblDesignation" runat="server" Text="Designation"></asp:Label> 
					<asp:TextBox ID="txtDesignation" runat="server"></asp:TextBox>
					</div>
					<div id="dvQualification" class="dvColumnLeft">
					<asp:Label ID="lblQualification" runat="server" Text="Qualification"></asp:Label> 
					<asp:TextBox ID="txtQualification" runat="server"></asp:TextBox>
					</div>
					<div id="dvNationality" class="dvColumnRight">
					<asp:Label ID="lblNationality" runat="server" Text="Nationality"></asp:Label> 
					<asp:DropDownList ID="ddlNationality" runat="server" DataValueField="Metadata_Id" DataTextField="Metadata_Name" ></asp:DropDownList> 
					</div>
					<div id="dvRelation" class="dvColumnLeft">
					<asp:Label ID="lblRelation" runat="server" Text="Relation"></asp:Label> 
					<asp:TextBox ID="txtRelation" runat="server"></asp:TextBox>
					</div>
					<div id="dvIsGuardian" class="dvColumnRight">
					<asp:Label ID="lblIsGuardian" runat="server" Text="Is Guardian"></asp:Label> 
					<asp:DropDownList ID="ddlIsGuardian" runat="server">
						<asp:ListItem Value="-Select-">-Select-</asp:ListItem>
						<asp:ListItem Value="True">True</asp:ListItem>
						<asp:ListItem Value="False">False</asp:ListItem>
					</asp:DropDownList>
					</div>
					<div id="dvIsStaff" class="dvColumnLeft">
					<asp:Label ID="lblIsStaff" runat="server" Text="Is Staff"></asp:Label> 
					<asp:DropDownList ID="ddlIsStaff" runat="server">
						<asp:ListItem Value="-Select-">-Select-</asp:ListItem>
						<asp:ListItem Value="True">True</asp:ListItem>
						<asp:ListItem Value="False">False</asp:ListItem>
					</asp:DropDownList>
					</div>
					<div id="dvWasStudent" class="dvColumnRight">
					<asp:Label ID="lblWasStudent" runat="server" Text="Was Student"></asp:Label> 
					<asp:DropDownList ID="ddlWasStudent" runat="server">
						<asp:ListItem Value="-Select-">-Select-</asp:ListItem>
						<asp:ListItem Value="True">True</asp:ListItem>
						<asp:ListItem Value="False">False</asp:ListItem>
					</asp:DropDownList>
					</div>
					<div id="dvOfficeDetail" class="dvColumnLeft">
					<asp:Label ID="lblOfficeDetail" runat="server" Text="Office Detail"></asp:Label> 
					<asp:TextBox ID="txtOfficeDetail" runat="server"></asp:TextBox>
					</div>
				</fieldset>

