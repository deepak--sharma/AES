<%@ Control Language="C#" AutoEventWireup="true" CodeFile="FeeScheduleDetailUC.ascx.cs"
    Inherits="FeeScheduleDetailUC" %>
<fieldset>
    <legend>Fee Schedule Detail List</legend>
    <asp:GridView ID="grdFeeScheduleDetail" runat="server" DataKeyNames="Fee_Schedule_Detail_Id,Fee_Schedule_Id"
        AllowPaging="True" AutoGenerateColumns="False" EmptyDataText="No Record Found" OnRowDataBound="grdFeeScheduleDetail_RowDataBound">
        <Columns>
        <asp:TemplateField HeaderText="S.No.">
                <ItemTemplate>
                      <asp:Label ID="lblSNo" runat="Server" Text='<%# Eval("ROW_NUM") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="From">
                <ItemTemplate>
                    <asp:DropDownList ID="ddlStartMonth" runat="Server" >
                        <asp:ListItem Text="January" Value="1"/>
                        <asp:ListItem Text="February" Value="2" />
                        <asp:ListItem Text="March" Value="3" />
                        <asp:ListItem Text="April" Value="4" />
                        <asp:ListItem Text="May" Value="5" />
                        <asp:ListItem Text="June" Value="6" />
                        <asp:ListItem Text="July" Value="7" />
                        <asp:ListItem Text="August" Value="8" />
                        <asp:ListItem Text="September" Value="9" />
                        <asp:ListItem Text="October" Value="10" />
                        <asp:ListItem Text="November" Value="11" />
                        <asp:ListItem Text="December" Value="12" />
                    </asp:DropDownList>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="To">
                <ItemTemplate>
                    <asp:DropDownList ID="ddlEndMonth" runat="Server" >
                        <asp:ListItem Text="January" Value="1"/>
                        <asp:ListItem Text="February" Value="2" />
                        <asp:ListItem Text="March" Value="3" />
                        <asp:ListItem Text="April" Value="4" />
                        <asp:ListItem Text="May" Value="5" />
                        <asp:ListItem Text="June" Value="6" />
                        <asp:ListItem Text="July" Value="7" />
                        <asp:ListItem Text="August" Value="8" />
                        <asp:ListItem Text="September" Value="9" />
                        <asp:ListItem Text="October" Value="10" />
                        <asp:ListItem Text="November" Value="11" />
                        <asp:ListItem Text="December" Value="12" />
                    </asp:DropDownList>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Fee Process Month">
                <ItemTemplate>
                   <asp:DropDownList ID="ddlProcessMonth" runat="Server" >
                        <asp:ListItem Text="January" Value="1"/>
                        <asp:ListItem Text="February" Value="2" />
                        <asp:ListItem Text="March" Value="3" />
                        <asp:ListItem Text="April" Value="4" />
                        <asp:ListItem Text="May" Value="5" />
                        <asp:ListItem Text="June" Value="6" />
                        <asp:ListItem Text="July" Value="7" />
                        <asp:ListItem Text="August" Value="8" />
                        <asp:ListItem Text="September" Value="9" />
                        <asp:ListItem Text="October" Value="10" />
                        <asp:ListItem Text="November" Value="11" />
                        <asp:ListItem Text="December" Value="12" />
                    </asp:DropDownList>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Collection Start Date">
                <ItemTemplate>
                    <asp:TextBox ID="txtCollectionStartDate" runat="server" Text='<%# Eval("Collection_Start_Date") %>'></asp:TextBox>
                    <asp:Label ID="lblCollectionStartDate" runat="Server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Collection Last Date">
                <ItemTemplate>
                    <asp:TextBox ID="txtCollectionLastDate" runat="server" Text='<%# Eval("Collection_Last_Date") %>'></asp:TextBox>
                     <asp:Label ID="lblCollectionLastDate" runat="Server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</fieldset>
