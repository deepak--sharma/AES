<%@ Control Language="C#" AutoEventWireup="true" CodeFile="KnownLanguageUC.ascx.cs"
    Inherits="KnownLanguageUC" %>
<fieldset>
    <legend>Known Language List</legend>
    <asp:GridView ID="grdKnownLanguage" runat="server" DataKeyNames="LANGUAGE_ID" AllowPaging="True"
        AutoGenerateColumns="False" EmptyDataText="No Record Found">
        <Columns>
            <asp:TemplateField HeaderText="Language">
                <ItemTemplate>
                    <asp:Label ID="lblLanguage" runat="server" Text='<%# Eval("LANGUAGE_NAME") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Can Read">
                <ItemTemplate>
                    <asp:CheckBox ID="chkCanRead" runat="server" Checked='<%# Eval("CAN_READ") %>'></asp:CheckBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Can Write">
                <ItemTemplate>
                    <asp:CheckBox ID="chkCanWrite" runat="server" Checked='<%# Eval("CAN_WRITE") %>'></asp:CheckBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Can Speak">
                <ItemTemplate>
                    <asp:CheckBox ID="chkCanSpeak" runat="server" Checked='<%# Eval("CAN_SPEAK") %>'></asp:CheckBox>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</fieldset>
