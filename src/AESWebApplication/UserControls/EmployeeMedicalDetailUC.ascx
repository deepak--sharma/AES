<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EmployeeMedicalDetailUC.ascx.cs"
    Inherits="EmployeeMedicalDetailUC" %>
<%--<fieldset>
    <legend>Employee Medical Detail List</legend>--%>
    <asp:GridView ID="grdEmployeeMedicalDetail" runat="server" DataKeyNames="EMPLOYEE_ID,MEDICAL_ID"
        AllowPaging="True" AutoGenerateColumns="False" EmptyDataText="No Record Found">
        <Columns>
           <asp:TemplateField HeaderText="Medical Detail">
                <ItemTemplate>
                    <asp:Label ID="lblMedicalDetail" runat="server" Text='<%# Eval("MEDICAL_NAME") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Description">
                <ItemTemplate>
                    <asp:TextBox ID="txtDescription" runat="server" Text='<%# Eval("DESCRIPTION") %>'></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
<%--</fieldset>--%>
