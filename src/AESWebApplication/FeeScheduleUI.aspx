<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FeeScheduleUI.aspx.cs" Inherits="FeeScheduleUI"
    MasterPageFile="~/MasterPage/MainMasterPage.master" %>

<%@ Register Src="UserControls/FeeScheduleDetailUC.ascx" TagName="FeeScheduleDetailUC"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="Server">
    <title>FeeSchedule Page</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div id="divContainer">
        <asp:MultiView ID="MultiViewFeeSchedule" runat="server" ActiveViewIndex="0">
            <asp:View ID="ViewFeeScheduleGrid" runat="server">
                <fieldset>
                    <legend>Fee Schedule List</legend>
                    <asp:GridView ID="grdFeeSchedule" runat="server" DataKeyNames="Fee_Schedule_Id,Version,Branch_Id,Class_Id,Stream_Id"
                        AllowPaging="True" OnRowDeleting="grdFeeSchedule_RowDeleting" OnPageIndexChanging="grdFeeSchedule_PageIndexChanging"
                        OnRowDataBound="grdFeeSchedule_RowDataBound" AutoGenerateColumns="False" EmptyDataText="No Record Found"
                        OnRowEditing="grdFeeSchedule_ActivatingObject" OnSelectedIndexChanged="grdFeeSchedule_SelectedIndexChanged"
                        PageSize="50">
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
            <asp:View ID="ViewFeeScheduleControls" runat="server">
                <fieldset>
                    <legend>Fee Schedule</legend>
                    <div id="dvNoOfInstances" class="dvColumnLeft">
                        <asp:Label ID="lblNoOfInstances" runat="server" Text="No Of Instances"></asp:Label>
                        <asp:TextBox ID="txtNoOfInstances" runat="server"></asp:TextBox>
                    </div>
                    <div id="dvFee" class="dvColumnRight">
                        <asp:Label ID="lblFeeProcess" runat="server" Text="Fee Process Mode"></asp:Label>
                        <asp:DropDownList ID="ddlFeeProcess" runat="server" DataValueField="Metadata_Id"
                            DataTextField="Metadata_Name">
                        </asp:DropDownList>
                    </div>
                    <div id="dvBranch" class="dvColumnLeft">
                        <asp:Label ID="lblBranch" runat="server" Text="Branch Name"></asp:Label>
                        <asp:DropDownList ID="ddlBranch" runat="server" Enabled="false" DataValueField="Branch_Id" DataTextField="Branch_Name">
                        </asp:DropDownList>
                    </div>
                    <div id="dvClass" class="dvColumnRight">
                        <asp:Label ID="lblClass" runat="server" Text="Class Name"></asp:Label>
                        <asp:DropDownList ID="ddlClass" runat="server" Enabled="false" DataValueField="Class_Id" DataTextField="Class_Name">
                        </asp:DropDownList>
                    </div>
                    <div id="dvStream" class="dvColumnLeft">
                        <asp:Label ID="lblStream" runat="server" Text="Stream Name"></asp:Label>
                        <asp:DropDownList ID="ddlStream" runat="server" Enabled="false" DataValueField="Stream_Id" DataTextField="Stream_Name">
                        </asp:DropDownList>
                    </div>
                    <div id="dvGo" class="dvColumnRight">
                        <asp:Button ID="btnGo" runat="server" Text="GO" OnClick="btnGo_Click"></asp:Button>
                    </div>
                </fieldset>
                <fieldset id="fldFeeScheduleDetail" runat="server">
                    <legend>Fee Schedule Detail</legend>
                    <uc1:FeeScheduleDetailUC ID="uxFeeScheduleDetailUC" runat="server" />
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
