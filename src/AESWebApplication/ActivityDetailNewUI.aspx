<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ActivityDetailNewUI.aspx.cs"
    Inherits="ActivityDetailNewUI" MasterPageFile="~/MasterPage/MainMasterPage.master" %>

<%@ Register Src="UserControls/StudentAttendanceUC.ascx" TagName="StudentAttendanceUC"
    TagPrefix="uc1" %>
<%@ Register Src="~/UserControls/Calender.ascx" TagName="CalenderUC" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="Server">
    <title>ActivityDetail Page</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div id="divContainer">
        <fieldset>
            <legend>Activity Detail</legend>
            <div id="dvActivity" class="dvColumnLeft">
                <asp:Label ID="lblActivity" runat="server" Text="Activity Name"></asp:Label>
                <asp:DropDownList ID="ddlActivity" runat="server" DataValueField="Activity_Id" DataTextField="Activity_Name">
                </asp:DropDownList>
            </div>
            <div id="dvSession" class="dvColumnRight">
                <asp:Label ID="lblSession" runat="server" Text="Session"></asp:Label>
                <asp:DropDownList ID="ddlSession" runat="server" DataValueField="Session_Id" DataTextField="Session_Name">
                </asp:DropDownList>
            </div>
            <div id="dvStream" class="dvColumnLeft">
                <asp:Label ID="lblStream" runat="server" Text="Stream"></asp:Label>
                <asp:DropDownList ID="ddlStream" runat="server" DataValueField="Stream_Id" DataTextField="Stream_Name">
                </asp:DropDownList>
            </div>
            <div id="dvBranch" class="dvColumnRight">
                <asp:Label ID="lblBranch" runat="server" Text="Branch Name"></asp:Label>
                <asp:DropDownList ID="ddlBranch" runat="server" DataValueField="Branch_Id" DataTextField="Branch_Name">
                </asp:DropDownList>
            </div>
            <div id="dvClass" class="dvColumnLeft">
                <asp:Label ID="lblClass" runat="server" Text="Class Name"></asp:Label>
                <asp:DropDownList ID="ddlClass" runat="server" DataValueField="Class_Id" DataTextField="Class_Name">
                </asp:DropDownList>
            </div>
            <div id="dvSubject" class="dvColumnRight">
                <asp:Label ID="lblSubject" runat="server" Text="Subject Name"></asp:Label>
                <asp:DropDownList ID="ddlSubject" runat="server" DataValueField="Subject_Id" DataTextField="Subject_Name">
                </asp:DropDownList>
            </div>
            <div id="dvSection" class="dvColumnLeft">
                <asp:Label ID="lblSection" runat="server" Text="Section Name"></asp:Label>
                <asp:DropDownList ID="ddlSection" runat="server" DataValueField="Section_Id"
                    DataTextField="Section_Name">
                </asp:DropDownList>
            </div>
            <div id="dvStartDate" class="dvColumnRight">
                <asp:Label ID="lblStartDate" runat="server" Text="Start Date"></asp:Label>
                    <uc1:CalenderUC ID="calenderStartDate" runat="server" />
            </div>
            <div id="dvEndDate" class="dvColumnLeft">
                <asp:Label ID="lblEndDate" runat="server" Text="End Date"></asp:Label>
                 <uc1:CalenderUC ID="calenderEndDate" runat="server" />
            </div>
            <div id="dvDescription" class="dvColumnRight">
                <asp:Label ID="lblDescription" runat="server" Text="Description"></asp:Label>
                <asp:TextBox ID="txtDescription" runat="server"></asp:TextBox>
            </div>
            <div id="dvGo" class="dvColumnLeft">
                <asp:Button ID="btnGo" runat="server" Text="Go" OnClick="btnGo_Click"></asp:Button>
            </div>
        </fieldset>
        <fieldset>
            <legend>Student Attendance</legend>
            <uc1:StudentAttendanceUC ID="uxStudentAttendanceUC" runat="server" />
        </fieldset>
        <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit Record" />
        <asp:Button ID="btnCancelRollback" runat="server" OnClick="btnCancelRollback_Click"
            Text="Cancel / Rollback" />
        <asp:Label ID="lblMessage" runat="server" EnableViewState="False"></asp:Label>
    </div>
</asp:Content>
