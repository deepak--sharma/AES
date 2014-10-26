<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EmployeeJoiningDetailUC.ascx.cs"
    Inherits="EmployeeJoiningDetailUC" %>
<%--<fieldset>
    <legend>Employee Joining Detail List</legend>--%>
    <asp:GridView ID="grdEmployeeJoiningDetail" runat="server" DataKeyNames="EMPLOYEE_ID,JOINING_ID"
        AllowPaging="True" AutoGenerateColumns="False" EmptyDataText="No Record Found">
        <Columns>
           <asp:TemplateField HeaderText="Joining Detail">
                <ItemTemplate>
                    <asp:Label ID="lblJoiningDetail" runat="server" Text='<%# Eval("JOINING_NAME") %>'></asp:Label>
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
