<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SkillDetailUC.ascx.cs"
    Inherits="SkillDetailUC" %>
<fieldset>
    <legend>Skill Detail List</legend>
    <asp:GridView ID="grdSkillDetail" runat="server" DataKeyNames="Skill_Id,Member_Id,Member_Type_Id"
        AllowPaging="True" 
        AutoGenerateColumns="False" EmptyDataText="No Record Found" >
        <Columns>
         <asp:TemplateField HeaderText="Skill Name">
                <ItemTemplate>
                    <asp:Label ID="lblSkillName" runat="server" Text='<%# Eval("SKILL_NAME") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Yearofexp">
                <ItemTemplate>
                    <asp:TextBox ID="txtYearofexp" runat="server" Text='<%# Eval("YearOfExp") %>'></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Comment">
                <ItemTemplate>
                    <asp:TextBox ID="txtComment" runat="server" Text='<%# Eval("Comment") %>'></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</fieldset>

