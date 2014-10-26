<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SiblingDetailUC.ascx.cs" Inherits="SiblingDetailUC" %>

			<asp:MultiView ID="MultiViewSiblingDetail" runat="server" ActiveViewIndex="0" > 
				<asp:View ID="ViewSiblingDetailGrid" runat="server">
				<fieldset><legend>Sibling Detail List</legend>
					<asp:Button ID="btnAddRecord" runat="server" Text="Add Record" 
                        OnClick="btnAddRecord_Click" CausesValidation="False" />
					<asp:GridView ID="grdSiblingDetail" runat="server" DataKeyNames="Sibling_Id,Gender_Id,School_Id,Class_Id" AllowPaging="True" OnRowDeleting="grdSiblingDetail_RowDeleting" OnPageIndexChanging="grdSiblingDetail_PageIndexChanging"
						AutoGenerateColumns="False" EmptyDataText="No Record Found" OnSelectedIndexChanged="grdSiblingDetail_SelectedIndexChanged">
					<Columns>
						<asp:CommandField ShowSelectButton="True" SelectText="Select" HeaderText="Select"/>
						<asp:CommandField ShowDeleteButton="True" DeleteText="Delete" HeaderText="Delete"/>
						<asp:TemplateField HeaderText="Full Name" >
							<ItemTemplate>
								<asp:Label ID="lblFullName" runat="server" Text='<%# Eval("Full_Name") %>'></asp:Label> 
							</ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Date Of Birth" >
							<ItemTemplate>
								<asp:Label ID="lblDateOfBirth" runat="server" Text='<%# Eval("Date_Of_Birth") %>'></asp:Label> 
							</ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="School Name" >
							<ItemTemplate>
								<asp:Label ID="lblSchoolName" runat="server" Text='<%# Eval("School_Name") %>'></asp:Label> 
							</ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="School Address" >
							<ItemTemplate>
								<asp:Label ID="lblSchoolAddress" runat="server" Text='<%# Eval("School_Address") %>'></asp:Label> 
							</ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="School Contacts" >
							<ItemTemplate>
								<asp:Label ID="lblSchoolContacts" runat="server" Text='<%# Eval("School_Contacts") %>'></asp:Label> 
							</ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Registration Number" >
							<ItemTemplate>
								<asp:Label ID="lblRegistrationNumber" runat="server" Text='<%# Eval("Registration_Number") %>'></asp:Label> 
							</ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Is Candidate" >
							<ItemTemplate>
								<asp:Label ID="lblIsCandidate" runat="server" Text='<%# Eval("Is_Candidate") %>'></asp:Label> 
							</ItemTemplate>
						</asp:TemplateField>
					</Columns>
					</asp:GridView>
				</fieldset>
				</asp:View>
				<asp:View ID="ViewSiblingDetailControls" runat="server">
				<fieldset><legend>Sibling Detail</legend>
					<asp:HiddenField ID="hfSessionDataKey" runat="server" />
					<asp:HiddenField ID="hfIsControlsLoaded" runat="server" />
					<asp:HiddenField ID="hfEditIndexKey" runat="server" />
					<div id="dvFullName" class="dvColumnLeft">
					<asp:Label ID="lblFullName" runat="server" Text="Full Name"></asp:Label> 
					<asp:TextBox ID="txtFullName" runat="server"></asp:TextBox>
					</div>	
					<div id="dvDateOfBirth" class="dvColumnRight">
					<asp:Label ID="lblDateOfBirth" runat="server" Text="Date Of Birth"></asp:Label> 
					<asp:TextBox ID="txtDateOfBirth" runat="server"></asp:TextBox>
					</div>
					<div id="dvGender" class="dvColumnLeft">
					<asp:Label ID="lblGender" runat="server" Text="Gender"></asp:Label> 
					<asp:DropDownList ID="ddlGender" runat="server" DataValueField="Metadata_Id" DataTextField="Metadata_Name" ></asp:DropDownList> 
					</div>
					<div id="dvSchool" class="dvColumnRight">
					<asp:Label ID="lblSchool" runat="server" Text="School Name"></asp:Label> 
					<asp:DropDownList ID="ddlSchool" runat="server" DataValueField="School_Id" DataTextField="School_Name" ></asp:DropDownList> 
					</div>
					<div id="dvSchoolName" class="dvColumnLeft">
					<asp:Label ID="lblSchoolName" runat="server" Text="School Name"></asp:Label> 
					<asp:TextBox ID="txtSchoolName" runat="server"></asp:TextBox>
					</div>
					<div id="dvSchoolAddress" class="dvColumnRight">
					<asp:Label ID="lblSchoolAddress" runat="server" Text="School Address"></asp:Label> 
					<asp:TextBox ID="txtSchoolAddress" runat="server"></asp:TextBox>
					</div>
					<div id="dvSchoolContacts" class="dvColumnLeft">
					<asp:Label ID="lblSchoolContacts" runat="server" Text="School Contacts"></asp:Label> 
					<asp:TextBox ID="txtSchoolContacts" runat="server"></asp:TextBox>
					</div>
					<div id="dvClass" class="dvColumnRight">
					<asp:Label ID="lblClass" runat="server" Text="Class Name"></asp:Label> 
					<asp:DropDownList ID="ddlClass" runat="server" DataValueField="Class_Id" DataTextField="Class_Name" ></asp:DropDownList> 
					</div>
					<div id="dvRegistrationNumber" class="dvColumnLeft">
					<asp:Label ID="lblRegistrationNumber" runat="server" Text="Registration Number"></asp:Label> 
					<asp:TextBox ID="txtRegistrationNumber" runat="server"></asp:TextBox>
					</div>
					<div id="dvIsCandidate" class="dvColumnRight">
					<asp:Label ID="lblIsCandidate" runat="server" Text="Is Candidate"></asp:Label> 
					<asp:DropDownList ID="ddlIsCandidate" runat="server">
						<asp:ListItem Value="-Select-">-Select-</asp:ListItem>
						<asp:ListItem Value="True">True</asp:ListItem>
						<asp:ListItem Value="False">False</asp:ListItem>
					</asp:DropDownList>
					</div>
				</fieldset>

				<asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save" 
                        CausesValidation="False" />
				<asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Cancel" />
				</asp:View>
			</asp:MultiView>
			<asp:Label ID="lblMessage" runat="server" EnableViewState="False"></asp:Label>
