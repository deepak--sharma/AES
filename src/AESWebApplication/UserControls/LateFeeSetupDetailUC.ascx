<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LateFeeSetupDetailUC.ascx.cs"
    Inherits="LateFeeSetupDetailUC" %>
<fieldset>
    <legend>Late Fee Setup Detail List</legend>
    <asp:GridView ID="grdLateFeeSetupDetail" runat="server" DataKeyNames="Late_Fee_Setup_Detail_Id,Frequency_Id"
        AllowPaging="True" OnRowDataBound="grdLateFeeSetupDetail_RowDataBound" AutoGenerateColumns="False"
        EmptyDataText="No Record Found" OnRowDeleting="grdLateFeeSetupDetail_RowDeleting">
        <Columns>
            <asp:CommandField ShowDeleteButton="True" DeleteText="Delete" HeaderText="Delete" />
            <asp:TemplateField HeaderText="Start Range">
                <ItemTemplate>
                    <asp:TextBox ID="txtStartRange" runat="server" Text='<%# Eval("Start_Range") %>'></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="End Range">
                <ItemTemplate>
                    <asp:TextBox ID="txtEndRange" runat="server" Text='<%# Eval("End_Range") %>'></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Amount">
                <ItemTemplate>
                    <asp:TextBox ID="txtAmount" runat="server" Text='<%# Eval("Amount") %>'></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Frequency">
                <ItemTemplate>
                    <asp:DropDownList ID="ddlFrequency" runat="server" DataValueField="Metadata_Id" DataTextField="Metadata_Name">
                    </asp:DropDownList>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:Button ID="btnAddMore" runat="server" Text="Add More" OnClick="btnAddMore_Click" />
</fieldset>
