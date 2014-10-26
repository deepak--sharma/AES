<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LateFeeSetupUI.aspx.cs" Inherits="LateFeeSetupUI"
    MasterPageFile="~/MasterPage/MainMasterPage.master" %>

<%@ Register Src="UserControls/LateFeeSetupDetailUC.ascx" TagName="LateFeeSetupDetailUC"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="Server">
    <title>LateFeeSetup Page</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div id="divContainer">
        <asp:MultiView ID="MultiViewLateFeeSetup" runat="server" ActiveViewIndex="0">
            <asp:View ID="ViewLateFeeSetupGrid" runat="server">
                <fieldset>
                    <legend>Late Fee Setup List</legend>                   
                    <asp:GridView ID="grdLateFeeSetup" runat="server" DataKeyNames="Late_Fee_Id,Version,Branch_Id,Class_Id,Stream_Id"
                        AllowPaging="True" OnRowDeleting="grdLateFeeSetup_RowDeleting" OnPageIndexChanging="grdLateFeeSetup_PageIndexChanging"
                        AutoGenerateColumns="False" EmptyDataText="No Record Found" OnRowEditing="grdLateFeeSetup_ActivatingObject"
                        OnSelectedIndexChanged="grdLateFeeSetup_SelectedIndexChanged" PageSize="50" OnRowDataBound="grdLateFeeSetup_RowDataBound">
                        <Columns>
                            <asp:CommandField ShowSelectButton="True" SelectText="Select" HeaderText="Select" />
                            <asp:CommandField ShowEditButton="True" EditText="Activate" HeaderText="Activate"
                                Visible="false" />
                            <asp:CommandField ShowDeleteButton="True" DeleteText="Delete" HeaderText="Delete" />
                             <asp:TemplateField HeaderText="Branch Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblBranchName" runat="server" Text='<%# Eval("BRANCH_NAME") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Class Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblClassName" runat="server" Text='<%# Eval("CLASS_NAME") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Stream Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblStreamName" runat="server" Text='<%# Eval("STREAM_NAME") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Status">
                                <ItemTemplate>
                                    <asp:Label ID="lblStatus" runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </fieldset>
            </asp:View>
            <asp:View ID="ViewLateFeeSetupControls" runat="server">
                <fieldset>
                    <legend>Late Fee Setup</legend>
                    <div id="dvBranch" class="dvColumnLeft">
                        <asp:Label ID="lblBranch" runat="server" Text="Branch Name"></asp:Label>
                        <asp:DropDownList ID="ddlBranch" runat="server" DataValueField="Branch_Id" DataTextField="Branch_Name" Enabled="false">
                        </asp:DropDownList>
                    </div>
                    <div id="dvClass" class="dvColumnRight">
                        <asp:Label ID="lblClass" runat="server" Text="Class Name"></asp:Label>
                        <asp:DropDownList ID="ddlClass" runat="server" DataValueField="Class_Id" DataTextField="Class_Name" Enabled="false">
                        </asp:DropDownList>
                    </div>
                    <div id="dvStream" class="dvColumnLeft">
                        <asp:Label ID="lblStream" runat="server" Text="Stream Name"></asp:Label>
                        <asp:DropDownList ID="ddlStream" runat="server" DataValueField="Stream_Id" DataTextField="Stream_Name" Enabled="false">
                        </asp:DropDownList>
                    </div>
                </fieldset>
                <fieldset>
                    <legend>Late Fee Setup Detail</legend>
                    <uc1:LateFeeSetupDetailUC ID="uxLateFeeSetupDetailUC" runat="server" />
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
