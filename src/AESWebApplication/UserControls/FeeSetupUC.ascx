<%@ Control Language="C#" AutoEventWireup="true" CodeFile="FeeSetupUC.ascx.cs" Inherits="FeeSetupUC" %>
<fieldset id="fldRegistration" runat="server" visible="false">
    <legend>Registration Fee</legend>
    <asp:GridView ID="grdRegistrationFeeSetup" runat="server" DataKeyNames="FEE_SETUP_ID,FEE_STRUCTURE_DETAIL_ID,FEE_ID"
        AllowPaging="True" AutoGenerateColumns="False" EmptyDataText="No Record Found"
        PageSize="50" OnRowDataBound="grdFeeSetup_RowDataBound">
        <Columns>
            <asp:TemplateField HeaderText="Fee Code">
                <ItemTemplate>
                    <asp:Label ID="lblFeeCode" runat="server" Text='<%# Eval("FEE_CODE") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Fee Name">
                <ItemTemplate>
                    <asp:Label ID="lblFeeName" runat="server" Text='<%# Eval("FEE_NAME") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Frequency">
                <ItemTemplate>
                    <asp:Label ID="lblFrequency" runat="server" Text='<%# Eval("FREQUENCY_NAME") %>'>
                    </asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
           <asp:TemplateField HeaderText="Applicable To">
                <ItemTemplate>
                    <asp:Label ID="lblApplicableTo" runat="server" Text='<%# Eval("FEE_APPLICABLE_TO") %>'>
                    </asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Is Mandatory">
                <ItemTemplate>
                    <asp:Label ID="lblIsMandatory" runat="server" Text='<%# Eval("IS_MANDATORY") %>'>
                    </asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Is Refundable">
                <ItemTemplate>
                    <asp:Label ID="lblIsRefundable" runat="server" Text='<%# Eval("IS_REFUNDABLE") %>'>
                    </asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Fee Amount">
                <ItemTemplate>
                    <asp:TextBox ID="txtFeeAmount" runat="server" Text='<%# Eval("FEE_AMOUNT") %>'></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Start Month">
                <ItemTemplate>
                    <asp:DropDownList ID="ddlStartMonth" runat="server">
                        <asp:ListItem Value="1" Text="January" />
                        <asp:ListItem Value="2" Text="February" />
                        <asp:ListItem Value="3" Text="March" />
                        <asp:ListItem Value="4" Text="April" />
                        <asp:ListItem Value="5" Text="May" />
                        <asp:ListItem Value="6" Text="June" />
                        <asp:ListItem Value="7" Text="July" />
                        <asp:ListItem Value="8" Text="August" />
                        <asp:ListItem Value="9" Text="September" />
                        <asp:ListItem Value="10" Text="October" />
                        <asp:ListItem Value="11" Text="November" />
                        <asp:ListItem Value="12" Text="December" />
                    </asp:DropDownList>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Is Applicable">
                <ItemTemplate>
                    <asp:CheckBox ID="chkIsApplicable" runat="server" Checked='<%# Eval("IS_APPLICABLE") %>'>
                    </asp:CheckBox>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</fieldset>
<fieldset id="fldAdmission" runat="server" visible="false">
    <legend>Admission Fee</legend>
    <asp:GridView ID="grdAdmissionFeeSetup" runat="server" DataKeyNames="FEE_SETUP_ID,FEE_STRUCTURE_DETAIL_ID,FEE_ID"
        AllowPaging="True" AutoGenerateColumns="False" EmptyDataText="No Record Found"
        PageSize="50" OnRowDataBound="grdFeeSetup_RowDataBound">
        <Columns>
            <asp:TemplateField HeaderText="Fee Code">
                <ItemTemplate>
                    <asp:Label ID="lblFeeCode" runat="server" Text='<%# Eval("FEE_CODE") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Fee Name">
                <ItemTemplate>
                    <asp:Label ID="lblFeeName" runat="server" Text='<%# Eval("FEE_NAME") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Frequency">
                <ItemTemplate>
                    <asp:Label ID="lblFrequency" runat="server" Text='<%# Eval("FREQUENCY_NAME") %>'>
                    </asp:Label>
                </ItemTemplate>
            </asp:TemplateField>           
            <asp:TemplateField HeaderText="Applicable To">
                <ItemTemplate>
                    <asp:Label ID="lblApplicableTo" runat="server" Text='<%# Eval("FEE_APPLICABLE_TO") %>'>
                    </asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Is Mandatory">
                <ItemTemplate>
                    <asp:Label ID="lblIsMandatory" runat="server" Text='<%# Eval("IS_MANDATORY") %>'>
                    </asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Is Refundable">
                <ItemTemplate>
                    <asp:Label ID="lblIsRefundable" runat="server" Text='<%# Eval("IS_REFUNDABLE") %>'>
                    </asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Fee Amount">
                <ItemTemplate>
                    <asp:TextBox ID="txtFeeAmount" runat="server" Text='<%# Eval("FEE_AMOUNT") %>'></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Start Month">
                <ItemTemplate>
                    <asp:DropDownList ID="ddlStartMonth" runat="server">
                        <asp:ListItem Value="1" Text="January" />
                        <asp:ListItem Value="2" Text="February" />
                        <asp:ListItem Value="3" Text="March" />
                        <asp:ListItem Value="4" Text="April" />
                        <asp:ListItem Value="5" Text="May" />
                        <asp:ListItem Value="6" Text="June" />
                        <asp:ListItem Value="7" Text="July" />
                        <asp:ListItem Value="8" Text="August" />
                        <asp:ListItem Value="9" Text="September" />
                        <asp:ListItem Value="10" Text="October" />
                        <asp:ListItem Value="11" Text="November" />
                        <asp:ListItem Value="12" Text="December" />
                    </asp:DropDownList>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Is Applicable">
                <ItemTemplate>
                    <asp:CheckBox ID="chkIsApplicable" runat="server" Checked='<%# Eval("IS_APPLICABLE") %>'>
                    </asp:CheckBox>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</fieldset>
<fieldset id="fldRegularOneTime" runat="server" visible="false">
    <legend>Regular Fee - One Time</legend>
    <asp:GridView ID="grdRegularOneTimeFeeSetup" runat="server" DataKeyNames="FEE_SETUP_ID,FEE_STRUCTURE_DETAIL_ID,FEE_ID"
        AllowPaging="True" AutoGenerateColumns="False" EmptyDataText="No Record Found"
        PageSize="50" OnRowDataBound="grdFeeSetup_RowDataBound">
        <Columns>
            <asp:TemplateField HeaderText="Fee Code">
                <ItemTemplate>
                    <asp:Label ID="lblFeeCode" runat="server" Text='<%# Eval("FEE_CODE") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Fee Name">
                <ItemTemplate>
                    <asp:Label ID="lblFeeName" runat="server" Text='<%# Eval("FEE_NAME") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
           <asp:TemplateField HeaderText="Applicable To">
                <ItemTemplate>
                    <asp:Label ID="lblApplicableTo" runat="server" Text='<%# Eval("FEE_APPLICABLE_TO") %>'>
                    </asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Is Mandatory">
                <ItemTemplate>
                    <asp:Label ID="lblIsMandatory" runat="server" Text='<%# Eval("IS_MANDATORY") %>'>
                    </asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Is Refundable">
                <ItemTemplate>
                    <asp:Label ID="lblIsRefundable" runat="server" Text='<%# Eval("IS_REFUNDABLE") %>'>
                    </asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Fee Amount">
                <ItemTemplate>
                    <asp:TextBox ID="txtFeeAmount" runat="server" Text='<%# Eval("FEE_AMOUNT") %>'></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Start Month">
                <ItemTemplate>
                    <asp:DropDownList ID="ddlStartMonth" runat="server">
                        <asp:ListItem Value="1" Text="January" />
                        <asp:ListItem Value="2" Text="February" />
                        <asp:ListItem Value="3" Text="March" />
                        <asp:ListItem Value="4" Text="April" />
                        <asp:ListItem Value="5" Text="May" />
                        <asp:ListItem Value="6" Text="June" />
                        <asp:ListItem Value="7" Text="July" />
                        <asp:ListItem Value="8" Text="August" />
                        <asp:ListItem Value="9" Text="September" />
                        <asp:ListItem Value="10" Text="October" />
                        <asp:ListItem Value="11" Text="November" />
                        <asp:ListItem Value="12" Text="December" />
                    </asp:DropDownList>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Is Applicable">
                <ItemTemplate>
                    <asp:CheckBox ID="chkIsApplicable" runat="server" Checked='<%# Eval("IS_APPLICABLE") %>'>
                    </asp:CheckBox>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</fieldset>
<fieldset id="fldRegularYearly" runat="server" visible="false">
    <legend>Regular Fee - Yearly</legend>
    <asp:GridView ID="grdRegularYearlyFeeSetup" runat="server" DataKeyNames="FEE_SETUP_ID,FEE_STRUCTURE_DETAIL_ID,FEE_ID"
        AllowPaging="True" AutoGenerateColumns="False" EmptyDataText="No Record Found"
        PageSize="50" OnRowDataBound="grdFeeSetup_RowDataBound">
       <Columns>
            <asp:TemplateField HeaderText="Fee Code">
                <ItemTemplate>
                    <asp:Label ID="lblFeeCode" runat="server" Text='<%# Eval("FEE_CODE") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Fee Name">
                <ItemTemplate>
                    <asp:Label ID="lblFeeName" runat="server" Text='<%# Eval("FEE_NAME") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
           <asp:TemplateField HeaderText="Applicable To">
                <ItemTemplate>
                    <asp:Label ID="lblApplicableTo" runat="server" Text='<%# Eval("FEE_APPLICABLE_TO") %>'>
                    </asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Is Mandatory">
                <ItemTemplate>
                    <asp:Label ID="lblIsMandatory" runat="server" Text='<%# Eval("IS_MANDATORY") %>'>
                    </asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Is Refundable">
                <ItemTemplate>
                    <asp:Label ID="lblIsRefundable" runat="server" Text='<%# Eval("IS_REFUNDABLE") %>'>
                    </asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Fee Amount">
                <ItemTemplate>
                    <asp:TextBox ID="txtFeeAmount" runat="server" Text='<%# Eval("FEE_AMOUNT") %>'></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Start Month">
                <ItemTemplate>
                    <asp:DropDownList ID="ddlStartMonth" runat="server">
                        <asp:ListItem Value="1" Text="January" />
                        <asp:ListItem Value="2" Text="February" />
                        <asp:ListItem Value="3" Text="March" />
                        <asp:ListItem Value="4" Text="April" />
                        <asp:ListItem Value="5" Text="May" />
                        <asp:ListItem Value="6" Text="June" />
                        <asp:ListItem Value="7" Text="July" />
                        <asp:ListItem Value="8" Text="August" />
                        <asp:ListItem Value="9" Text="September" />
                        <asp:ListItem Value="10" Text="October" />
                        <asp:ListItem Value="11" Text="November" />
                        <asp:ListItem Value="12" Text="December" />
                    </asp:DropDownList>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Is Applicable">
                <ItemTemplate>
                    <asp:CheckBox ID="chkIsApplicable" runat="server" Checked='<%# Eval("IS_APPLICABLE") %>'>
                    </asp:CheckBox>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</fieldset>
<fieldset id="fldRegularHalfYearly" runat="server" visible="false">
    <legend>Regular Fee - Half Yearly</legend>
    <asp:GridView ID="grdRegularHalfYearlyFeeSetup" runat="server" DataKeyNames="FEE_SETUP_ID,FEE_STRUCTURE_DETAIL_ID,FEE_ID"
        AllowPaging="True" AutoGenerateColumns="False" EmptyDataText="No Record Found"
        PageSize="50" OnRowDataBound="grdFeeSetup_RowDataBound">
        <Columns>
            <asp:TemplateField HeaderText="Fee Code">
                <ItemTemplate>
                    <asp:Label ID="lblFeeCode" runat="server" Text='<%# Eval("FEE_CODE") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Fee Name">
                <ItemTemplate>
                    <asp:Label ID="lblFeeName" runat="server" Text='<%# Eval("FEE_NAME") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
           <asp:TemplateField HeaderText="Applicable To">
                <ItemTemplate>
                    <asp:Label ID="lblApplicableTo" runat="server" Text='<%# Eval("FEE_APPLICABLE_TO") %>'>
                    </asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Is Mandatory">
                <ItemTemplate>
                    <asp:Label ID="lblIsMandatory" runat="server" Text='<%# Eval("IS_MANDATORY") %>'>
                    </asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Is Refundable">
                <ItemTemplate>
                    <asp:Label ID="lblIsRefundable" runat="server" Text='<%# Eval("IS_REFUNDABLE") %>'>
                    </asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Fee Amount">
                <ItemTemplate>
                    <asp:TextBox ID="txtFeeAmount" runat="server" Text='<%# Eval("FEE_AMOUNT") %>'></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Start Month">
                <ItemTemplate>
                    <asp:DropDownList ID="ddlStartMonth" runat="server">
                        <asp:ListItem Value="1" Text="January" />
                        <asp:ListItem Value="2" Text="February" />
                        <asp:ListItem Value="3" Text="March" />
                        <asp:ListItem Value="4" Text="April" />
                        <asp:ListItem Value="5" Text="May" />
                        <asp:ListItem Value="6" Text="June" />
                        <asp:ListItem Value="7" Text="July" />
                        <asp:ListItem Value="8" Text="August" />
                        <asp:ListItem Value="9" Text="September" />
                        <asp:ListItem Value="10" Text="October" />
                        <asp:ListItem Value="11" Text="November" />
                        <asp:ListItem Value="12" Text="December" />
                    </asp:DropDownList>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Is Applicable">
                <ItemTemplate>
                    <asp:CheckBox ID="chkIsApplicable" runat="server" Checked='<%# Eval("IS_APPLICABLE") %>'>
                    </asp:CheckBox>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</fieldset>
<fieldset id="fldRegularQuaterly" runat="server" visible="false">
    <legend>Regular Fee - Quaterly</legend>
    <asp:GridView ID="grdRegularQuaterlyFeeSetup" runat="server" DataKeyNames="FEE_SETUP_ID,FEE_STRUCTURE_DETAIL_ID,FEE_ID"
        AllowPaging="True" AutoGenerateColumns="False" EmptyDataText="No Record Found"
        PageSize="50" OnRowDataBound="grdFeeSetup_RowDataBound">
      <Columns>
            <asp:TemplateField HeaderText="Fee Code">
                <ItemTemplate>
                    <asp:Label ID="lblFeeCode" runat="server" Text='<%# Eval("FEE_CODE") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Fee Name">
                <ItemTemplate>
                    <asp:Label ID="lblFeeName" runat="server" Text='<%# Eval("FEE_NAME") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
           <asp:TemplateField HeaderText="Applicable To">
                <ItemTemplate>
                    <asp:Label ID="lblApplicableTo" runat="server" Text='<%# Eval("FEE_APPLICABLE_TO") %>'>
                    </asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Is Mandatory">
                <ItemTemplate>
                    <asp:Label ID="lblIsMandatory" runat="server" Text='<%# Eval("IS_MANDATORY") %>'>
                    </asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Is Refundable">
                <ItemTemplate>
                    <asp:Label ID="lblIsRefundable" runat="server" Text='<%# Eval("IS_REFUNDABLE") %>'>
                    </asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Fee Amount">
                <ItemTemplate>
                    <asp:TextBox ID="txtFeeAmount" runat="server" Text='<%# Eval("FEE_AMOUNT") %>'></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Start Month">
                <ItemTemplate>
                    <asp:DropDownList ID="ddlStartMonth" runat="server">
                        <asp:ListItem Value="1" Text="January" />
                        <asp:ListItem Value="2" Text="February" />
                        <asp:ListItem Value="3" Text="March" />
                        <asp:ListItem Value="4" Text="April" />
                        <asp:ListItem Value="5" Text="May" />
                        <asp:ListItem Value="6" Text="June" />
                        <asp:ListItem Value="7" Text="July" />
                        <asp:ListItem Value="8" Text="August" />
                        <asp:ListItem Value="9" Text="September" />
                        <asp:ListItem Value="10" Text="October" />
                        <asp:ListItem Value="11" Text="November" />
                        <asp:ListItem Value="12" Text="December" />
                    </asp:DropDownList>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Is Applicable">
                <ItemTemplate>
                    <asp:CheckBox ID="chkIsApplicable" runat="server" Checked='<%# Eval("IS_APPLICABLE") %>'>
                    </asp:CheckBox>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</fieldset>
<fieldset id="fldRegularBiMonthly" runat="server" visible="false">
    <legend>Regular Fee - BiMonthly</legend>
    <asp:GridView ID="grdRegularBiMonthlyFeeSetup" runat="server" DataKeyNames="FEE_SETUP_ID,FEE_STRUCTURE_DETAIL_ID,FEE_ID"
        AllowPaging="True" AutoGenerateColumns="False" EmptyDataText="No Record Found"
        PageSize="50" OnRowDataBound="grdFeeSetup_RowDataBound">
       <Columns>
            <asp:TemplateField HeaderText="Fee Code">
                <ItemTemplate>
                    <asp:Label ID="lblFeeCode" runat="server" Text='<%# Eval("FEE_CODE") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Fee Name">
                <ItemTemplate>
                    <asp:Label ID="lblFeeName" runat="server" Text='<%# Eval("FEE_NAME") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
           <asp:TemplateField HeaderText="Applicable To">
                <ItemTemplate>
                    <asp:Label ID="lblApplicableTo" runat="server" Text='<%# Eval("FEE_APPLICABLE_TO") %>'>
                    </asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Is Mandatory">
                <ItemTemplate>
                    <asp:Label ID="lblIsMandatory" runat="server" Text='<%# Eval("IS_MANDATORY") %>'>
                    </asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Is Refundable">
                <ItemTemplate>
                    <asp:Label ID="lblIsRefundable" runat="server" Text='<%# Eval("IS_REFUNDABLE") %>'>
                    </asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Fee Amount">
                <ItemTemplate>
                    <asp:TextBox ID="txtFeeAmount" runat="server" Text='<%# Eval("FEE_AMOUNT") %>'></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Start Month">
                <ItemTemplate>
                    <asp:DropDownList ID="ddlStartMonth" runat="server">
                        <asp:ListItem Value="1" Text="January" />
                        <asp:ListItem Value="2" Text="February" />
                        <asp:ListItem Value="3" Text="March" />
                        <asp:ListItem Value="4" Text="April" />
                        <asp:ListItem Value="5" Text="May" />
                        <asp:ListItem Value="6" Text="June" />
                        <asp:ListItem Value="7" Text="July" />
                        <asp:ListItem Value="8" Text="August" />
                        <asp:ListItem Value="9" Text="September" />
                        <asp:ListItem Value="10" Text="October" />
                        <asp:ListItem Value="11" Text="November" />
                        <asp:ListItem Value="12" Text="December" />
                    </asp:DropDownList>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Is Applicable">
                <ItemTemplate>
                    <asp:CheckBox ID="chkIsApplicable" runat="server" Checked='<%# Eval("IS_APPLICABLE") %>'>
                    </asp:CheckBox>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</fieldset>
<fieldset id="fldRegularMonthly" runat="server" visible="false">
    <legend>Regular Fee - Monthly</legend>
    <asp:GridView ID="grdRegularMonthlyFeeSetup" runat="server" DataKeyNames="FEE_SETUP_ID,FEE_STRUCTURE_DETAIL_ID,FEE_ID"
        AllowPaging="True" AutoGenerateColumns="False" EmptyDataText="No Record Found"
        PageSize="50" OnRowDataBound="grdFeeSetup_RowDataBound">
       <Columns>
            <asp:TemplateField HeaderText="Fee Code">
                <ItemTemplate>
                    <asp:Label ID="lblFeeCode" runat="server" Text='<%# Eval("FEE_CODE") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Fee Name">
                <ItemTemplate>
                    <asp:Label ID="lblFeeName" runat="server" Text='<%# Eval("FEE_NAME") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
           <asp:TemplateField HeaderText="Applicable To">
                <ItemTemplate>
                    <asp:Label ID="lblApplicableTo" runat="server" Text='<%# Eval("FEE_APPLICABLE_TO") %>'>
                    </asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Is Mandatory">
                <ItemTemplate>
                    <asp:Label ID="lblIsMandatory" runat="server" Text='<%# Eval("IS_MANDATORY") %>'>
                    </asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Is Refundable">
                <ItemTemplate>
                    <asp:Label ID="lblIsRefundable" runat="server" Text='<%# Eval("IS_REFUNDABLE") %>'>
                    </asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Fee Amount">
                <ItemTemplate>
                    <asp:TextBox ID="txtFeeAmount" runat="server" Text='<%# Eval("FEE_AMOUNT") %>'></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Start Month">
                <ItemTemplate>
                    <asp:DropDownList ID="ddlStartMonth" runat="server">
                        <asp:ListItem Value="1" Text="January" />
                        <asp:ListItem Value="2" Text="February" />
                        <asp:ListItem Value="3" Text="March" />
                        <asp:ListItem Value="4" Text="April" />
                        <asp:ListItem Value="5" Text="May" />
                        <asp:ListItem Value="6" Text="June" />
                        <asp:ListItem Value="7" Text="July" />
                        <asp:ListItem Value="8" Text="August" />
                        <asp:ListItem Value="9" Text="September" />
                        <asp:ListItem Value="10" Text="October" />
                        <asp:ListItem Value="11" Text="November" />
                        <asp:ListItem Value="12" Text="December" />
                    </asp:DropDownList>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Is Applicable">
                <ItemTemplate>
                    <asp:CheckBox ID="chkIsApplicable" runat="server" Checked='<%# Eval("IS_APPLICABLE") %>'>
                    </asp:CheckBox>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</fieldset>
