<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DocumentDetailUC.ascx.cs" Inherits="DocumentDetailUC" %>

				<fieldset><legend>Document Detail</legend>
					<asp:HiddenField ID="hfDocumentDetailId" runat="server" />
					<div id="dvMemberId" class="dvColumnLeft">
					<asp:Label ID="lblMemberId" runat="server" Text="Member Id"></asp:Label> 
					<asp:TextBox ID="txtMemberId" runat="server"></asp:TextBox>
					</div>
					<div id="dvMember" class="dvColumnRight">
					<asp:Label ID="lblMember" runat="server" Text="Member Type"></asp:Label> 
					<asp:DropDownList ID="ddlMember" runat="server" DataValueField="Metadata_Id" DataTextField="Metadata_Name" ></asp:DropDownList> 
					</div>
					<div id="dvDocument" class="dvColumnLeft">
					<asp:Label ID="lblDocument" runat="server" Text="Document"></asp:Label> 
					<asp:DropDownList ID="ddlDocument" runat="server" DataValueField="Metadata_Id" DataTextField="Metadata_Name" ></asp:DropDownList> 
					</div>
					<div id="dvDocumentDescription" class="dvColumnRight">
					<asp:Label ID="lblDocumentDescription" runat="server" Text="Document Description"></asp:Label> 
					<asp:TextBox ID="txtDocumentDescription" runat="server"></asp:TextBox>
					</div>
					<div id="dvDocumentPath" class="dvColumnLeft">
					<asp:Label ID="lblDocumentPath" runat="server" Text="Document Path"></asp:Label> 
					<asp:TextBox ID="txtDocumentPath" runat="server"></asp:TextBox>
					</div>
					<div id="dvComments" class="dvColumnRight">
					<asp:Label ID="lblComments" runat="server" Text="Comments"></asp:Label> 
					<asp:TextBox ID="txtComments" runat="server"></asp:TextBox>
					</div>
					<div id="dvUploadDate" class="dvColumnLeft">
					<asp:Label ID="lblUploadDate" runat="server" Text="Upload Date"></asp:Label> 
					<asp:TextBox ID="txtUploadDate" runat="server"></asp:TextBox>
					</div>
				</fieldset>

