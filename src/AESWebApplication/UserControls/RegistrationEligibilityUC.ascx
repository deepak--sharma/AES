<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RegistrationEligibilityUC.ascx.cs"
    Inherits="RegistrationEligibilityUC" %>
    
<fieldset>
    <legend>Registration Eligibility </legend>
    <asp:GridView ID="grdRegistrationEligibility" runat="server" DataKeyNames="Eligibility_Factor_Id"
        AllowPaging="True" AutoGenerateColumns="False" EmptyDataText="No Record Found"
        OnRowDataBound="gridView_RowDataBound">
        <Columns>
            <asp:TemplateField HeaderText="Eligibility">
                <ItemTemplate>
                    <asp:Label ID="lblEligibility" runat="server" Text='<%# Eval("Eligibility_Factor_Name") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Min Value">
                <ItemTemplate>
                    <asp:TextBox ID="txtMinValue" runat="server" Text='<%# Eval("Eligibility_Min_Value") %>'></asp:TextBox>
                    <asp:RegularExpressionValidator ID="revMinValue" runat="server" ControlToValidate="txtMinValue"
                        Display="Static" SetFocusOnError="true" CssClass="rfvValidate" ValidationExpression="^\d*">
                        <img src ="Images/Warning.png" alt ="Image not available" title ="Enter a valid number" class ="imgValidate"/>
                    </asp:RegularExpressionValidator>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Max Value">
                <ItemTemplate>
                    <asp:TextBox ID="txtMaxValue" runat="server" Text='<%# Eval("Eligibility_Max_Value") %>'></asp:TextBox>
                    <asp:RegularExpressionValidator ID="revMaxValue" runat="server" ControlToValidate="txtMaxValue"
                        Display="Static" SetFocusOnError="true" CssClass="rfvValidate" ValidationExpression="^\d*">
                        <img src ="Images/Warning.png" alt ="Image not available" title ="Enter a valid number" class ="imgValidate"/>
                    </asp:RegularExpressionValidator>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Description">
                <ItemTemplate>
                    <asp:TextBox ID="txtDescription" runat="server" Text='<%# Eval("Description") %>'></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <div>
        <p>
            <b>Note:</b></p>
        <p>
            1. Enter Age in years. Enter both Value(Min Value) and Max Value.
        </p>
        <p>
            2. Enter Nationality comma separated string of Country names.</p>
        <p>
            3. Enter Minimum Guardian Income in Value column in Rupees format.</p>
    </div>
</fieldset>
