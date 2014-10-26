<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PreviousSchoolEducationMarksWizardUC.ascx.cs"
    Inherits="PreviousSchoolEducationMarksWizardUC" %>
<asp:HiddenField ID="hfIsControlsLoaded" runat="server" Value="false" />
<asp:GridView ID="grdPreviousSchoolEducationMarksDetail" runat="server" AutoGenerateColumns="False">
    <Columns>
        <asp:TemplateField HeaderText="S.No.">
            <ItemTemplate>
                <asp:Label ID="lblSNo" runat="server" Text='<%# Eval("S_NO") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Subject Name" >
            <ItemTemplate>
                <asp:TextBox ID="txtSubject" runat="server" Text='<%# Eval("SUBJECT_NAME") %>'></asp:TextBox>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Marks (Percent)">
            <ItemTemplate>
                <asp:TextBox ID="txtMarks" runat="server" Text='<%# Eval("MARKS_PERCENT") %>'></asp:TextBox>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
