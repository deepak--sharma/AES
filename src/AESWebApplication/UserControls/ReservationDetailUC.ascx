<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ReservationDetailUC.ascx.cs"
    Inherits="ReservationDetailUC" %>
<div style="border-bottom: 2px solid #000000; margin-bottom: 15px;">
    <h3>
        Reservation Detail</h3>
</div>
<asp:Panel ID="pnlFreeSeat" runat="server" GroupingText="Free Seat Reservation">
    <asp:GridView ID="grdFreeSeatReservationDetail" runat="server" AllowPaging="True"
        Width="98%" EmptyDataText="No Record Found" AutoGenerateColumns="False" OnRowDataBound="gridView_RowDataBound"
        CellPadding="4" ForeColor="#333333" GridLines="None" DataKeyNames="Reservation_Type_Id,Reservation_Criteria_Id,Reservation_Sub_Criteria_Id">
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <Columns>
            <asp:TemplateField HeaderText="Reservation Criteria">
                <ItemTemplate>
                    <asp:Label ID="lblReservationCriteria" runat="server" Text='<%# Eval("RESERVATION_CRITERIA_NAME") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Reservation Sub-Criteria">
                <ItemTemplate>
                    <asp:Label ID="lblReservationSubCriteria" runat="server" Text='<%# Eval("RESERVATION_SUB_CRITERIA_NAME") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Value">
                <ItemTemplate>
                    <asp:TextBox ID="txtValue" runat="server" Text='<%# Eval("Value") %>'></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Is Percent/Fixed">
                <ItemTemplate>
                    <asp:DropDownList ID="ddlIsPercent" runat="server">
                        <asp:ListItem Text="Fixed" Value="0"></asp:ListItem>
                        <asp:ListItem Text="Percent" Value="1"></asp:ListItem>
                    </asp:DropDownList>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#999999" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    </asp:GridView>
</asp:Panel>
<br />
<asp:Panel ID="pnlManagementSeat" runat="server" GroupingText="Management Seat Reservation">
    <asp:GridView ID="grdManagementSeatReservationDetail" runat="server" AllowPaging="True"
        Width="98%" EmptyDataText="No Record Found" AutoGenerateColumns="False" OnRowDataBound="gridView_RowDataBound"
        CellPadding="4" ForeColor="#333333" GridLines="None" DataKeyNames="Reservation_Type_Id,Reservation_Criteria_Id,Reservation_Sub_Criteria_Id">
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <Columns>
            <asp:TemplateField HeaderText="Reservation Criteria">
                <ItemTemplate>
                    <asp:Label ID="lblReservationCriteria" runat="server" Text='<%# Eval("RESERVATION_CRITERIA_NAME") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Reservation Sub-Criteria">
                <ItemTemplate>
                    <asp:Label ID="lblReservationSubCriteria" runat="server" Text='<%# Eval("RESERVATION_SUB_CRITERIA_NAME") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Value">
                <ItemTemplate>
                    <asp:TextBox ID="txtValue" runat="server" Text='<%# Eval("Value") %>'></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Is Percent/Fixed">
                <ItemTemplate>
                    <asp:DropDownList ID="ddlIsPercent" runat="server">
                        <asp:ListItem Text="Fixed" Value="0"></asp:ListItem>
                        <asp:ListItem Text="Percent" Value="1"></asp:ListItem>
                    </asp:DropDownList>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#999999" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    </asp:GridView>
</asp:Panel>
