<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FeeDiscountSetupUI.aspx.cs"
    Inherits="FeeDiscountSetupUI" MasterPageFile="~/MasterPage/MainMasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="Server">
    <title>FeeDiscountSetup Page</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div id="divContainer">
        <asp:MultiView ID="MultiViewFeeDiscountSetup" runat="server" ActiveViewIndex="0">
            <asp:View ID="ViewFeeDiscountSetupGrid" runat="server">
                <fieldset>
                    <legend>Fee Discount Setup List</legend>
                    <asp:Button ID="btnAddNewRecord" runat="server" Text="Add New Record" OnClick="btnAddNewRecord_Click" />
                    <asp:Label ID="lblViewOnly" runat="server" Text="View only - "></asp:Label>
                    <asp:RadioButton ID="rdbActiveRecord" runat="server" Text="Live Records" GroupName="DisplayMode"
                        AutoPostBack="True" Checked="True" OnCheckedChanged="rdbActiveRecord_CheckedChanged" />
                    <asp:RadioButton ID="rdbInActiveRecord" runat="server" Text="Deleted Records" GroupName="DisplayMode"
                        AutoPostBack="True" OnCheckedChanged="rdbInActiveRecord_CheckedChanged" />
                    <asp:GridView ID="grdFeeDiscountSetup" runat="server" DataKeyNames="Fee_Discount_Id,Version"
                        AllowPaging="True" OnRowDeleting="grdFeeDiscountSetup_RowDeleting" OnPageIndexChanging="grdFeeDiscountSetup_PageIndexChanging"
                        AutoGenerateColumns="False" EmptyDataText="No Record Found" OnRowEditing="grdFeeDiscountSetup_ActivatingObject"
                        OnSelectedIndexChanged="grdFeeDiscountSetup_SelectedIndexChanged">
                        <Columns>
                            <asp:CommandField ShowSelectButton="True" SelectText="Select" HeaderText="Select" />
                            <asp:CommandField ShowEditButton="True" EditText="Activate" HeaderText="Activate"
                                Visible="false" />
                            <asp:CommandField ShowDeleteButton="True" DeleteText="Delete" HeaderText="Delete" />
                            <asp:TemplateField HeaderText="Discount Type Value">
                                <ItemTemplate>
                                    <asp:Label ID="lblDiscountTypeValue" runat="server" Text='<%# Eval("Discount_Type_Value") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Discount Amount">
                                <ItemTemplate>
                                    <asp:Label ID="lblDiscountAmount" runat="server" Text='<%# Eval("Discount_Amount") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Is Percent">
                                <ItemTemplate>
                                    <asp:Label ID="lblIsPercent" runat="server" Text='<%# Eval("Is_Percent") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Effective Date">
                                <ItemTemplate>
                                    <asp:Label ID="lblEffectiveDate" runat="server" Text='<%# Eval("Effective_Date") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </fieldset>
            </asp:View>
            <asp:View ID="ViewFeeDiscountSetupControls" runat="server">
                <fieldset>
                    <legend>Fee Discount Setup</legend>
                    <div id="dvFee" class="dvColumnLeft">
                        <asp:Label ID="lblFee" runat="server" Text="Fee Structure Id"></asp:Label>
                        <asp:DropDownList ID="ddlFee" runat="server" DataValueField="Fee_Structure_Detail_Id"
                            DataTextField="Fee_Structure_Id">
                        </asp:DropDownList>
                    </div>
                    <div id="dvDiscount" class="dvColumnRight">
                        <asp:Label ID="lblDiscount" runat="server" Text="Fee Name"></asp:Label>
                        <asp:DropDownList ID="ddlDiscount" runat="server" DataValueField="Fee_Id" DataTextField="Fee_Name">
                        </asp:DropDownList>
                    </div>
                    <div id="dvDiscountTypeValue" class="dvColumnLeft">
                        <asp:Label ID="lblDiscountTypeValue" runat="server" Text="Discount Type Value"></asp:Label>
                        <asp:TextBox ID="txtDiscountTypeValue" runat="server"></asp:TextBox>
                    </div>
                    <div id="dvDiscountAmount" class="dvColumnRight">
                        <asp:Label ID="lblDiscountAmount" runat="server" Text="Discount Amount"></asp:Label>
                        <asp:TextBox ID="txtDiscountAmount" runat="server"></asp:TextBox>
                    </div>
                    <div id="dvIsPercent" class="dvColumnLeft">
                        <asp:Label ID="lblIsPercent" runat="server" Text="Is Percent"></asp:Label>
                        <asp:DropDownList ID="ddlIsPercent" runat="server">
                            <asp:ListItem Value="-Select-">-Select-</asp:ListItem>
                            <asp:ListItem Value="True">True</asp:ListItem>
                            <asp:ListItem Value="False">False</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div id="dvEffectiveDate" class="dvColumnRight">
                        <asp:Label ID="lblEffectiveDate" runat="server" Text="Effective Date"></asp:Label>
                        <asp:TextBox ID="txtEffectiveDate" runat="server"></asp:TextBox>
                    </div>
                </fieldset>
                <asp:Button ID="btnSave" runat="server" Enabled="False" OnClick="btnSave_Click" Text="Save Record" />
                <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit Record" />
                <asp:Button ID="btnCancelRollback" runat="server" OnClick="btnCancelRollback_Click"
                    Text="Cancel / Rollback" />
            </asp:View>
        </asp:MultiView>
        <asp:Label ID="lblMessage" runat="server" EnableViewState="False"></asp:Label>
    </div>
</asp:Content>
