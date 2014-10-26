<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EmployeeAdministrativeDetailUC.ascx.cs"
    Inherits="EmployeeAdministrativeDetailUC" %>
    
<%@ Register Src="~/UserControls/Calender.ascx" TagName="CalenderUC" TagPrefix="uc1" %>
    
<%--<fieldset>
    <legend>Employee Administrative Detail</legend>--%>
    <asp:HiddenField ID="hfEmployeeAdministrativeDetailId" runat="server" />
    <div id="dvBranch" class="dvColumnLeft">
        <asp:Label ID="lblBranch" runat="server" Text="Branch Name"></asp:Label>
        <asp:DropDownList ID="ddlBranch" runat="server" DataValueField="Branch_Id" DataTextField="Branch_Name">
        </asp:DropDownList>
    </div>
    <div id="dvDepartment" class="dvColumnRight">
        <asp:Label ID="lblDepartment" runat="server" Text="Department Name"></asp:Label>
        <asp:DropDownList ID="ddlDepartment" runat="server" DataValueField="Department_Id"
            DataTextField="Department_Name">
        </asp:DropDownList>
    </div>
    <div id="dvDivision" class="dvColumnLeft">
        <asp:Label ID="lblDivision" runat="server" Text="Division Name"></asp:Label>
        <asp:DropDownList ID="ddlDivision" runat="server" DataValueField="Division_Id" DataTextField="Division_Name">
        </asp:DropDownList>
    </div>  
    <div id="dvDesignation" class="dvColumnLeft">
        <asp:Label ID="lblDesignation" runat="server" Text="Designation Name"></asp:Label>
        <asp:DropDownList ID="ddlDesignation" runat="server" DataValueField="Designation_Id"
            DataTextField="Designation_Name">
        </asp:DropDownList>
    </div>
    <div id="dvDateOfJoining" class="dvColumnRight">
        <asp:Label ID="lblDateOfJoining" runat="server" Text="Date Of Joining"></asp:Label>
        <%--<asp:TextBox ID="txtDateOfJoining" runat="server"></asp:TextBox>--%>
        <uc1:CalenderUC ID="txtDateOfJoining" runat="server" />
    </div>
    <div id="dvUserName" class="dvColumnLeft">
        <asp:Label ID="lblUserName" runat="server" Text="User Name"></asp:Label>
        <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
    </div>
    <div id="dvGrade" class="dvColumnRight">
        <asp:Label ID="lblGrade" runat="server" Text="Grade Name"></asp:Label>
        <asp:DropDownList ID="ddlGrade" runat="server" DataValueField="Grade_Id" DataTextField="Grade_Name">
        </asp:DropDownList>
    </div>
    <div id="dvProbationUpto" class="dvColumnLeft">
        <asp:Label ID="lblProbationUpto" runat="server" Text="Probation Upto"></asp:Label>
        <asp:TextBox ID="txtProbationUpto" runat="server"></asp:TextBox>
    </div>
    <div id="dvConfirmationDate" class="dvColumnRight">
        <asp:Label ID="lblConfirmationDate" runat="server" Text="Confirmation Date"></asp:Label>
        <%--<asp:TextBox ID="txtConfirmationDate" runat="server"></asp:TextBox>--%>
        <uc1:CalenderUC ID="txtConfirmationDate" runat="server" />
    </div>
    <div id="dvIsSalaryStopped" class="dvColumnLeft">
        <asp:Label ID="lblIsSalaryStopped" runat="server" Text="Is Salary Stopped"></asp:Label>
        <asp:DropDownList ID="ddlIsSalaryStopped" runat="server">
            <asp:ListItem Value="-Select-">-Select-</asp:ListItem>
            <asp:ListItem Value="True">True</asp:ListItem>
            <asp:ListItem Value="False">False</asp:ListItem>
        </asp:DropDownList>
    </div>
    <div id="dvTerminationDate" class="dvColumnRight">
        <asp:Label ID="lblTerminationDate" runat="server" Text="Termination Date"></asp:Label>
        <%--<asp:TextBox ID="txtTerminationDate" runat="server"></asp:TextBox>--%>
        <uc1:CalenderUC ID="txtTerminationDate" runat="server" />
    </div>
    <div id="dvResignationDate" class="dvColumnLeft">
        <asp:Label ID="lblResignationDate" runat="server" Text="Resignation Date"></asp:Label>
        <%--<asp:TextBox ID="txtResignationDate" runat="server"></asp:TextBox>--%>
        <uc1:CalenderUC ID="txtResignationDate" runat="server" />        
    </div>
    <div id="dvDiscontinueDate" class="dvColumnRight">
        <asp:Label ID="lblDiscontinueDate" runat="server" Text="Discontinue Date"></asp:Label>
        <%--<asp:TextBox ID="txtDiscontinueDate" runat="server"></asp:TextBox>--%>
        <uc1:CalenderUC ID="txtDiscontinueDate" runat="server" />                
    </div>
    <div id="dvTotalExperience" class="dvColumnLeft">
        <asp:Label ID="lblTotalExperience" runat="server" Text="Total Experience"></asp:Label>
        <asp:TextBox ID="txtTotalExperience" runat="server"></asp:TextBox>
    </div>
    <div id="dvRelevantExperience" class="dvColumnRight">
        <asp:Label ID="lblRelevantExperience" runat="server" Text="Relevant Experience"></asp:Label>
        <asp:TextBox ID="txtRelevantExperience" runat="server"></asp:TextBox>
    </div>
    <div id="dvEmployee" class="dvColumnLeft">
        <asp:Label ID="lblEmployee" runat="server" Text="Employee Type"></asp:Label>
        <asp:DropDownList ID="ddlEmployee" runat="server" DataValueField="Metadata_Id" DataTextField="Metadata_Name">
        </asp:DropDownList>
    </div>
    <div id="dvLwfNo" class="dvColumnRight">
        <asp:Label ID="lblLwfNo" runat="server" Text="Lwf No"></asp:Label>
        <asp:TextBox ID="txtLwfNo" runat="server"></asp:TextBox>
    </div>
<%--</fieldset>--%>
