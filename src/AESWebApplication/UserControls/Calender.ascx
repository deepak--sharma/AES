<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Calender.ascx.cs" Inherits="UserControls_Calender" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

    <asp:TextBox ID="txtDate" runat="server" Width="135"></asp:TextBox>
    <asp:ImageButton ID="imgBtnCalender" runat="server" CausesValidation="False" ImageUrl="~/Images/Calendar.png"
        Style="vertical-align: middle" TabIndex="6" ToolTip="Click to open calender"
        Width="15px" Height="20px" />
    <ajaxToolkit:CalendarExtender ID="ceDate" runat="server" TargetControlID="txtDate"
        Format="dd-MMM-yyyy" PopupButtonID="imgBtnCalender">
    </ajaxToolkit:CalendarExtender>
    <br />
    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" Enabled="false"
        ClearMaskOnLostFocus="False" CultureName="en-GB" Mask="99-LLL-9999" TargetControlID="txtDate"
        UserDateFormat="DayMonthYear">
    </ajaxToolkit:MaskedEditExtender>
    <asp:RegularExpressionValidator ID="regexDate" runat="server" style="width:0px;height:0px;" Enabled="false" ControlToValidate="txtDate"
        ErrorMessage="Invalid Date" ValidationExpression="^(0?[1-9]|[12][0-9]|3[01])-(Jan|Feb|Mar|Apr|May|Jun|Jul|Aug|Sep|Oct|Nov|Dec)-(19|20)\d\d$"></asp:RegularExpressionValidator>
    <asp:RequiredFieldValidator ID="rfvDate" runat="server" Enabled="false" ErrorMessage="Enter date"
        ControlToValidate="txtDate" Display="None"></asp:RequiredFieldValidator>

