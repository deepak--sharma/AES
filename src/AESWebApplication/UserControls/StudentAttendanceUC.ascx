<%@ Control Language="C#" AutoEventWireup="true" CodeFile="StudentAttendanceUC.ascx.cs"
    Inherits="StudentAttendanceUC" %>
<fieldset>
    <legend>Student Attendance List</legend>
    <asp:GridView ID="grdStudentAttendance" runat="server" DataKeyNames="Student_Id"
        AllowPaging="True" AutoGenerateColumns="False" 
        EmptyDataText="No Record Found" 
        onrowdatabound="grdStudentAttendance_RowDataBound" >
        <Columns>          
            <asp:TemplateField HeaderText="Student Name">
                <ItemTemplate>
                    <asp:Label ID="lblStudentName" runat="server" Text='<%# Eval("CANDIDATE_NAME") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Enrollment No">
                <ItemTemplate>
                    <asp:Label ID="lblEnrollmentNo" runat="server" Text='<%# Eval("ENROLLMENT_NO") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="Roll No">
                <ItemTemplate>
                    <asp:Label ID="lblRollNo" runat="server" Text='<%# Eval("ROLL_NO") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Class-Stream-Section">
                <ItemTemplate>
                    <asp:Label ID="lblClassStreamSection" runat="server" Text='<%# Eval("CLASS_STREAM_SECTION") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>        
             <asp:TemplateField HeaderText="Attendance Status">
                <ItemTemplate>
                    <asp:DropDownList ID="ddlAttendanceStatus" runat="server" DataTextField="Metadata_Name" DataValueField="Metadata_Id" ></asp:DropDownList>
                </ItemTemplate>
            </asp:TemplateField>      
            <asp:TemplateField HeaderText="In Time">
                <ItemTemplate>
                    <asp:TextBox ID="txtInTime" runat="server" ></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Out Time">
                <ItemTemplate>
                    <asp:TextBox ID="txtOutTime" runat="server" ></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            
             <asp:TemplateField HeaderText="Comments">
                <ItemTemplate>
                    <asp:TextBox ID="txtComments" runat="server" ></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            
        </Columns>
    </asp:GridView>
</fieldset>
