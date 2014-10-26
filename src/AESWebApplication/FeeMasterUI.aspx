<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FeeMasterUI.aspx.cs" Inherits="FeeMasterUI"
    MasterPageFile="~/MasterPage/MainMasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="Server">
    <title>FeeMaster Page</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div id="divContainer">
        <asp:MultiView ID="MultiViewFeeMaster" runat="server" ActiveViewIndex="0">
            <asp:View ID="ViewFeeMasterGrid" runat="server">
                <fieldset>
                    <legend>Fee Master List</legend>
                    <asp:Button ID="btnAddNewRecord" runat="server" Text="Add New Record" OnClick="btnAddNewRecord_Click" />
                    <asp:Label ID="lblViewOnly" runat="server" Text="View only - "></asp:Label>
                    <asp:RadioButton ID="rdbActiveRecord" runat="server" Text="Live Records" GroupName="DisplayMode"
                        AutoPostBack="True" Checked="True" OnCheckedChanged="rdbActiveRecord_CheckedChanged" />
                    <asp:RadioButton ID="rdbInActiveRecord" runat="server" Text="Deleted Records" GroupName="DisplayMode"
                        AutoPostBack="True" OnCheckedChanged="rdbInActiveRecord_CheckedChanged" />
                    <asp:GridView ID="grdFeeMaster" runat="server" DataKeyNames="Fee_Id,Version" AllowPaging="True"
                        OnRowDeleting="grdFeeMaster_RowDeleting" OnPageIndexChanging="grdFeeMaster_PageIndexChanging"
                        PageSize="50" AutoGenerateColumns="False" EmptyDataText="No Record Found" OnRowEditing="grdFeeMaster_ActivatingObject"
                        OnSelectedIndexChanged="grdFeeMaster_SelectedIndexChanged">
                        <Columns>
                            <asp:CommandField ShowSelectButton="True" SelectText="Select" HeaderText="Select" />
                            <asp:CommandField ShowEditButton="True" EditText="Activate" HeaderText="Activate"
                                Visible="false" />
                            <asp:CommandField ShowDeleteButton="True" DeleteText="Delete" HeaderText="Delete" />
                            <asp:TemplateField HeaderText="Fee Code">
                                <ItemTemplate>
                                    <asp:Label ID="lblFeeCode" runat="server" Text='<%# Eval("Fee_Code") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Fee Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblFeeName" runat="server" Text='<%# Eval("Fee_Name") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Frequency">
                                <ItemTemplate>
                                    <asp:Label ID="lblFrequency" runat="server" Text='<%# Eval("FEE_FREQUENCY") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Fee Group">
                                <ItemTemplate>
                                    <asp:Label ID="lblFeeGroup" runat="server" Text='<%# Eval("FEE_GROUP") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Applicable To">
                                <ItemTemplate>
                                    <asp:Label ID="lblApplicableTo" runat="server" Text='<%# Eval("FEE_APPLICABLE_TO") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Is Mandatory">
                                <ItemTemplate>
                                    <asp:Label ID="lblIsMandatory" runat="server" Text='<%# Eval("Is_Mandatory") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Is Refundable">
                                <ItemTemplate>
                                    <asp:Label ID="lblIsRefundable" runat="server" Text='<%# Eval("Is_Refundable") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Description">
                                <ItemTemplate>
                                    <asp:Label ID="lblDescription" runat="server" Text='<%# Eval("Description") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </fieldset>
            </asp:View>
            <asp:View ID="ViewFeeMasterControls" runat="server">
                <fieldset>
                    <legend>Fee Master</legend>
                    <div id="UserForm">
                        <div id="dvFeeCode" class="dvColumnLeft">
                            <asp:Label ID="lblFeeCode" runat="server" Text="Fee Code"></asp:Label>
                            <asp:TextBox ID="txtFeeCode" runat="server"></asp:TextBox>
                        </div>
                        <div id="dvFeeName" class="dvColumnRight">
                            <asp:Label ID="lblFeeName" runat="server" Text="Fee Name"></asp:Label>
                            <asp:TextBox ID="txtFeeName" runat="server"></asp:TextBox>
                        </div>
                        <div id="dvFee" class="dvColumnLeft">
                            <asp:Label ID="lblFee" runat="server" Text="Fee Group"></asp:Label>
                            <asp:DropDownList ID="ddlFeeGroup" runat="server" DataValueField="Metadata_Id" DataTextField="Metadata_Name">
                            </asp:DropDownList>
                        </div>
                        <div id="dvFrequency" class="dvColumnRight">
                            <asp:Label ID="lblFrequency" runat="server" Text="Frequency"></asp:Label>
                            <asp:DropDownList ID="ddlFrequency" runat="server" DataValueField="Metadata_Id" DataTextField="Metadata_Name">
                            </asp:DropDownList>
                        </div>
                        <div id="dvIsMandatory" class="dvColumnLeft">
                            <asp:Label ID="lblIsMandatory" runat="server" Text="Is Mandatory"></asp:Label>
                            <asp:DropDownList ID="ddlIsMandatory" runat="server">
                                <asp:ListItem Value="-Select-">-Select-</asp:ListItem>
                                <asp:ListItem Value="True">True</asp:ListItem>
                                <asp:ListItem Value="False">False</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div id="dvIsRefundable" class="dvColumnRight">
                            <asp:Label ID="lblIsRefundable" runat="server" Text="Is Refundable"></asp:Label>
                            <asp:DropDownList ID="ddlIsRefundable" runat="server">
                                <asp:ListItem Value="-Select-">-Select-</asp:ListItem>
                                <asp:ListItem Value="True">True</asp:ListItem>
                                <asp:ListItem Value="False">False</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div id="dvApplicable" class="dvColumnLeft">
                            <asp:Label ID="lblApplicable" runat="server" Text="Applicable To"></asp:Label>
                            <asp:DropDownList ID="ddlApplicable" runat="server" DataValueField="Metadata_Id"
                                DataTextField="Metadata_Name">
                            </asp:DropDownList>
                        </div>
                        <div id="dvDescription" class="dvColumnRight">
                            <asp:Label ID="lblDescription" runat="server" Text="Description"></asp:Label>
                            <asp:TextBox ID="txtDescription" runat="server"></asp:TextBox>
                        </div>
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
