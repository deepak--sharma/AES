<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EmployeeFinancialDetailUC.ascx.cs"
    Inherits="EmployeeFinancialDetailUC" %>
<%--<fieldset>
    <legend>Employee Financial Detail</legend>--%>
    <asp:HiddenField ID="hfEmployeeFinancialDetailId" runat="server" />
    <div id="dvPanCardNo" class="dvColumnLeft">
        <asp:Label ID="lblPanCardNo" runat="server" Text="Pan Card No"></asp:Label>
        <asp:TextBox ID="txtPanCardNo" runat="server"></asp:TextBox>
    </div>
    <div id="dvPfNo" class="dvColumnRight">
        <asp:Label ID="lblPfNo" runat="server" Text="Pf No"></asp:Label>
        <asp:TextBox ID="txtPfNo" runat="server"></asp:TextBox>
    </div>
    <div id="dvEsiNo" class="dvColumnLeft">
        <asp:Label ID="lblEsiNo" runat="server" Text="Esi No"></asp:Label>
        <asp:TextBox ID="txtEsiNo" runat="server"></asp:TextBox>
    </div>
    <div id="dvIsPanApproved" class="dvColumnRight">
        <asp:Label ID="lblIsPanApproved" runat="server" Text="Is Pan Approved"></asp:Label>
        <asp:DropDownList ID="ddlIsPanApproved" runat="server">
            <asp:ListItem Value="-Select-">-Select-</asp:ListItem>
            <asp:ListItem Value="True">True</asp:ListItem>
            <asp:ListItem Value="False">False</asp:ListItem>
        </asp:DropDownList>
    </div>
    <div id="dvAccountNo" class="dvColumnLeft">
        <asp:Label ID="lblAccountNo" runat="server" Text="Account No"></asp:Label>
        <asp:TextBox ID="txtAccountNo" runat="server"></asp:TextBox>
    </div>
    <div id="dvAccount" class="dvColumnRight">
        <asp:Label ID="lblAccount" runat="server" Text="Account Type"></asp:Label>
        <asp:DropDownList ID="ddlAccount" runat="server" DataValueField="Metadata_Id" DataTextField="Metadata_Name">
        </asp:DropDownList>
    </div>
    <div id="dvVpfPercent" class="dvColumnLeft">
        <asp:Label ID="lblVpfPercent" runat="server" Text="Vpf Percent"></asp:Label>
        <asp:TextBox ID="txtVpfPercent" runat="server"></asp:TextBox>
    </div>
    <div id="dvVpfAmount" class="dvColumnRight">
        <asp:Label ID="lblVpfAmount" runat="server" Text="Vpf Amount"></asp:Label>
        <asp:TextBox ID="txtVpfAmount" runat="server"></asp:TextBox>
    </div>
    <div id="dvIsConsentForEcs" class="dvColumnLeft">
        <asp:Label ID="lblIsConsentForEcs" runat="server" Text="Is Consent For Ecs"></asp:Label>
        <asp:DropDownList ID="ddlIsConsentForEcs" runat="server">
            <asp:ListItem Value="-Select-">-Select-</asp:ListItem>
            <asp:ListItem Value="True">True</asp:ListItem>
            <asp:ListItem Value="False">False</asp:ListItem>
        </asp:DropDownList>
    </div>
    <div id="dvIsVpfEligible" class="dvColumnRight">
        <asp:Label ID="lblIsVpfEligible" runat="server" Text="Is Vpf Eligible"></asp:Label>
        <asp:DropDownList ID="ddlIsVpfEligible" runat="server">
            <asp:ListItem Value="-Select-">-Select-</asp:ListItem>
            <asp:ListItem Value="True">True</asp:ListItem>
            <asp:ListItem Value="False">False</asp:ListItem>
        </asp:DropDownList>
    </div>
    <div id="dvIsPfDeducted" class="dvColumnLeft">
        <asp:Label ID="lblIsPfDeducted" runat="server" Text="Is Pf Deducted"></asp:Label>
        <asp:DropDownList ID="ddlIsPfDeducted" runat="server">
            <asp:ListItem Value="-Select-">-Select-</asp:ListItem>
            <asp:ListItem Value="True">True</asp:ListItem>
            <asp:ListItem Value="False">False</asp:ListItem>
        </asp:DropDownList>
    </div>
    <div id="dvLedgerId" class="dvColumnRight">
        <asp:Label ID="lblLedgerId" runat="server" Text="Ledger Id"></asp:Label>
        <asp:TextBox ID="txtLedgerId" runat="server"></asp:TextBox>
    </div>
    <div id="dvIsSalaryHold" class="dvColumnLeft">
        <asp:Label ID="lblIsSalaryHold" runat="server" Text="Is Salary Hold"></asp:Label>
        <asp:DropDownList ID="ddlIsSalaryHold" runat="server">
            <asp:ListItem Value="-Select-">-Select-</asp:ListItem>
            <asp:ListItem Value="True">True</asp:ListItem>
            <asp:ListItem Value="False">False</asp:ListItem>
        </asp:DropDownList>
    </div>
    <div id="dvPaymentMode" class="dvColumnRight">
        <asp:Label ID="lblPaymentMode" runat="server" Text="Payment Mode"></asp:Label>
        <asp:DropDownList ID="ddlPaymentMode" runat="server" DataValueField="Metadata_Id"
            DataTextField="Metadata_Name">
        </asp:DropDownList>
    </div>
    <div id="dvBank" class="dvColumnLeft">
        <asp:Label ID="lblBank" runat="server" Text="Bank Name"></asp:Label>
        <asp:DropDownList ID="ddlBank" runat="server" DataValueField="Bank_Id" DataTextField="Bank_Name">
        </asp:DropDownList>
    </div>
<%--</fieldset>--%>
