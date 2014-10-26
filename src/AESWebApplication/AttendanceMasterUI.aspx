<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="AttendanceMasterUI.aspx.cs" Inherits="AttendanceMasterUI" MasterPageFile="~/MasterPage/MainMasterPage.master"%>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="Server">
	<title>AttendanceMaster Page</title>
</asp:Content>
		<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
		<div>
			<asp:MultiView ID="MultiViewAttendanceMaster" runat="server" ActiveViewIndex="0" > 
				<asp:View ID="ViewAttendanceMasterGrid" runat="server">
				<fieldset><legend>Attendance Master List</legend>
					<asp:Button ID="btnAddNewRecord" runat="server" Text="Add New Record" OnClick="btnAddNewRecord_Click" />
					<asp:Label ID="lblViewOnly" runat="server" Text="View only - "></asp:Label>
					<asp:RadioButton ID="rdbActiveRecord" runat="server" Text="Live Records" GroupName="DisplayMode" AutoPostBack="True" Checked="True" OnCheckedChanged="rdbActiveRecord_CheckedChanged" />
					<asp:RadioButton ID="rdbInActiveRecord" runat="server" Text="Deleted Records" GroupName="DisplayMode" AutoPostBack="True" OnCheckedChanged="rdbInActiveRecord_CheckedChanged" />
					<asp:GridView ID="grdAttendanceMaster" runat="server" DataKeyNames="Attendance_Id,Version" AllowPaging="True" OnRowDeleting="grdAttendanceMaster_RowDeleting" OnPageIndexChanging="grdAttendanceMaster_PageIndexChanging"
						AutoGenerateColumns="False" EmptyDataText="No Record Found" OnRowEditing="grdAttendanceMaster_ActivatingObject" OnSelectedIndexChanged="grdAttendanceMaster_SelectedIndexChanged">
					<Columns>
						<asp:CommandField ShowSelectButton="True" SelectText="Select" HeaderText="Select"/>
						<asp:CommandField ShowEditButton="True" EditText="Activate" HeaderText="Activate" Visible="false"/>
						<asp:CommandField ShowDeleteButton="True" DeleteText="Delete" HeaderText="Delete"/>
						<asp:TemplateField HeaderText="Member Id" >
							<ItemTemplate>
								<asp:Label ID="lblMemberId" runat="server" Text='<%# Eval("Member_Id") %>'></asp:Label> 
							</ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Activity Detail Id" >
							<ItemTemplate>
								<asp:Label ID="lblActivityDetailId" runat="server" Text='<%# Eval("Activity_Detail_Id") %>'></asp:Label> 
							</ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Attendance Date" >
							<ItemTemplate>
								<asp:Label ID="lblAttendanceDate" runat="server" Text='<%# Eval("Attendance_Date") %>'></asp:Label> 
							</ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="In Time" >
							<ItemTemplate>
								<asp:Label ID="lblInTime" runat="server" Text='<%# Eval("In_Time") %>'></asp:Label> 
							</ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Out Time" >
							<ItemTemplate>
								<asp:Label ID="lblOutTime" runat="server" Text='<%# Eval("Out_Time") %>'></asp:Label> 
							</ItemTemplate>
						</asp:TemplateField>
					</Columns>
					</asp:GridView>
				</fieldset>
				</asp:View>
				<asp:View ID="ViewAttendanceMasterControls" runat="server">
				<fieldset><legend>Attendance Master</legend>
					<div id="dvMemberId" class="dvColumnLeft">
					<asp:Label ID="lblMemberId" runat="server" Text="Member Id"></asp:Label> 
					<asp:TextBox ID="txtMemberId" runat="server"></asp:TextBox>
					</div>
					<div id="dvMember" class="dvColumnRight">
					<asp:Label ID="lblMember" runat="server" Text="Member Type"></asp:Label> 
					<asp:DropDownList ID="ddlMember" runat="server" DataValueField="Metadata_Id" DataTextField="Metadata_Name" ></asp:DropDownList> 
					</div>
					<div id="dvActivityDetailId" class="dvColumnLeft">
					<asp:Label ID="lblActivityDetailId" runat="server" Text="Activity Detail Id"></asp:Label> 
					<asp:TextBox ID="txtActivityDetailId" runat="server"></asp:TextBox>
					</div>
					<div id="dvAttendance" class="dvColumnRight">
					<asp:Label ID="lblAttendance" runat="server" Text="Attendance status"></asp:Label> 
					<asp:DropDownList ID="ddlAttendance" runat="server" DataValueField="Metadata_Id" DataTextField="Metadata_Name" ></asp:DropDownList> 
					</div>
					<div id="dvAttendanceDate" class="dvColumnLeft">
					<asp:Label ID="lblAttendanceDate" runat="server" Text="Attendance Date"></asp:Label> 
					<asp:TextBox ID="txtAttendanceDate" runat="server"></asp:TextBox>
					</div>
					<div id="dvInTime" class="dvColumnRight">
					<asp:Label ID="lblInTime" runat="server" Text="In Time"></asp:Label> 
					<asp:TextBox ID="txtInTime" runat="server"></asp:TextBox>
					</div>
					<div id="dvOutTime" class="dvColumnLeft">
					<asp:Label ID="lblOutTime" runat="server" Text="Out Time"></asp:Label> 
					<asp:TextBox ID="txtOutTime" runat="server"></asp:TextBox>
					</div>
					<div id="dvMarked" class="dvColumnRight">
					<asp:Label ID="lblMarked" runat="server" Text="First Name"></asp:Label> 
					<asp:DropDownList ID="ddlMarked" runat="server" DataValueField="Employee_Id" DataTextField="First_Name" ></asp:DropDownList> 
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
