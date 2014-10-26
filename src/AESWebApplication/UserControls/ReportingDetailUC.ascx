<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ReportingDetailUC.ascx.cs"
    Inherits="ReportingDetailUC" %>
<%--<fieldset>
    <legend>Reporting Detail List</legend>--%>
    <asp:GridView ID="grdReportingDetail" runat="server" DataKeyNames="EMPLOYEE_ID" AllowPaging="True"
        OnRowDataBound="grdReportingDetail_RowDataBound" AutoGenerateColumns="False" EmptyDataText="No Record Found">
        <Columns>  
            <asp:TemplateField HeaderText="Supervisor Detail">
                <ItemTemplate>
                    <asp:DropDownList ID="ddlSupervisorDetail" runat="server" DataTextField="EMPLOYEE_NAME" DataValueField="EMPLOYEE_ID" ></asp:DropDownList>
                </ItemTemplate>
            </asp:TemplateField>         
            <asp:TemplateField HeaderText="Other Detail">
                <ItemTemplate>
                    <asp:TextBox ID="txtOtherDetail" runat="server" Text='<%# Eval("Other_Detail") %>'></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Is Primary">
                <ItemTemplate>
                    <asp:CheckBox ID="chkIsPrimary" runat="server" checked='<%# Eval("Is_Primary") %>'></asp:CheckBox>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
<%--</fieldset>--%>
