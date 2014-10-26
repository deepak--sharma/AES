<%@ Page Language="C#" MasterPageFile="~/MasterPage/MainMasterPage.master" AutoEventWireup="true"
    CodeFile="StudentAdmissionDetailUI.aspx.cs" Inherits="StudentAdmissionDetailUI"
    Title="Untitled Page" %>

<%@ Register Src="UserControls/Calender.ascx" TagName="Calender" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div id="divContainer">

        <script type="text/javascript">
function OpenPopUp(url,name)
{
      window.open(url);
      return false;
}
        </script>

        <asp:MultiView ID="MultiViewStudentDetail" runat="server" ActiveViewIndex="1">
            <asp:View ID="ViewStudentDetail" runat="server">
                <asp:Label ID="lblAdmissionStatus" runat="server" EnableViewState="False"></asp:Label>
                <asp:Button ID="btnOk" runat="server" Text="OK" OnClick="btnOk_Click" />
            </asp:View>
            <asp:View ID="ViewStudentDetailControls" runat="server">
                <div id="dvRegistrationNumber" class="dvColumnLeft">
                    <asp:Label ID="lblRegistrationNumber" runat="server" Text="Registration Number"></asp:Label>
                    <asp:TextBox ID="txtRegistrationNumber" runat="server" ReadOnly="true">
                    </asp:TextBox>
                </div>
                <div id="dvRegistrationDate" class="dvColumnRight">
                    <asp:Label ID="lblRegistrationDate" runat="server" Text="Registration Date"></asp:Label>
                    <uc1:Calender ID="txtRegistrationDate" runat="server" ReadOnlyDateInputBox="true" />
                </div>
                <div id="dvClassName" class="dvColumnLeft">
                    <asp:Label ID="lblClassName" runat="server" Text="Class Name"></asp:Label>
                    <asp:DropDownList ID="ddlClassName" runat="server" Enabled="true" DataValueField="Class_Id"
                        DataTextField="Class_Name">
                    </asp:DropDownList>
                </div>
                <div id="dvBranch" class="dvColumnRight">
                    <asp:Label ID="lblBranch" runat="server" Text="Branch Name"></asp:Label>
                    <asp:DropDownList ID="ddlBranch" runat="server" DataValueField="Branch_Id" DataTextField="Branch_Name">
                    </asp:DropDownList>
                </div>
                <div id="dvCandidateName" class="dvColumnLeft">
                    <asp:Label ID="lblCandidateName" runat="server" Text="Candidate Name"></asp:Label>
                    <asp:TextBox ID="txtCandidateName" runat="server" ReadOnly="true"></asp:TextBox>
                </div>
                <div id="dvDOB" class="dvColumnRight">
                    <asp:Label ID="lblDOB" runat="server" Text="Date of Birth"></asp:Label>
                    <uc1:Calender ID="txtDOB" runat="server" ReadOnlyDateInputBox="true" />
                </div>
                <div id="dvGuardianName" class="dvColumnLeft">
                    <asp:Label ID="lblGuardianName" runat="server" Text="Guardian Name"></asp:Label>
                    <asp:TextBox ID="txtGuardianName" runat="server"></asp:TextBox>
                </div>
                <div id="dvComment" class="dvColumnRight">
                    <asp:Label ID="lblComment" runat="server" Text="Comment"></asp:Label>
                    <asp:TextBox ID="txtComment" runat="server" ReadOnly="true" TextMode="MultiLine"> </asp:TextBox>
                </div>
                <div id="dvAdmissionDate" class="dvColumnLeft">
                    <asp:Label ID="lblAdmissionDate" runat="server" Text="Admission Date"></asp:Label>
                    <uc1:Calender ID="txtAdmissionDate" runat="server" />
                </div>
                <div id="dvViewDetail" class="dvColumnRight">
                    <asp:LinkButton ID="lnkViewDetail" runat="server" Text="View Detail" />
                </div>
                <table style="height: 50px">
                    <tr>
                        <td>
                        </td>
                    </tr>
                </table>
                <div style="border-bottom: 2px solid #000000; margin-bottom: 15px;">
                    <h3>
                        Upload Documents</h3>
                </div>
                <table style="height: 50px">
                    <tr>
                        <td>
                        </td>
                    </tr>
                </table>
                <div style="border-bottom: 2px solid #000000; margin-bottom: 15px;">
                    <h3>
                        Process Fee</h3>
                </div>
                <table style="height: 50px">
                    <tr>
                        <td>
                        </td>
                    </tr>
                </table>
                <asp:Button ID="btnSubmit" runat="server" Text="Submit Record" OnClick="btnSubmit_Click" />
                <asp:Button ID="btnCancelRollback" runat="server" Text="Cancel / Rollback" OnClick="btnCancelRollback_Click" />
            </asp:View>
        </asp:MultiView>
        <asp:Label ID="lblMessage" runat="server" EnableViewState="False"></asp:Label>
    </div>
</asp:Content>
