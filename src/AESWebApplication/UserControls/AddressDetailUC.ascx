<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AddressDetailUC.ascx.cs"
    Inherits="AddressDetailUC" %>
<div id="dvAddressLine1" class="dvColumnLeft">
    <asp:Label ID="lblAddressLine1" runat="server" Text="Address Line1"></asp:Label>
    <span style="color: Red">*</span>
    <asp:TextBox ID="txtAddressLine1" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvAddressLine1" runat="server" ControlToValidate="txtAddressLine1"
        Display="Static" ToolTip="Enter Address Line1">
        <span style="color:Red">*</span>
    </asp:RequiredFieldValidator>
</div>
<div id="dvAddressLine2" class="dvColumnRight">
    <asp:Label ID="lblAddressLine2" runat="server" Text="Address Line2"></asp:Label>
    <span style="color: Red">*</span>
    <asp:TextBox ID="txtAddressLine2" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvAddressLine2" runat="server" ControlToValidate="txtAddressLine2"
        Display="Static" ToolTip="Enter Address Line2">
        <span style="color:Red">*</span>
    </asp:RequiredFieldValidator>
</div>
<div id="dvCountryName" class="dvColumnLeft">
    <asp:Label ID="lblCountry" runat="server" Text="Country Name"></asp:Label>
    <span style="color: Red">*</span>
    <asp:DropDownList ID="ddlCountry" runat="server" DataValueField="Country_Id" DataTextField="Country_Name"
        AutoPostBack="True" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged">
    </asp:DropDownList>
    <asp:RequiredFieldValidator ID="rfvCountry" runat="server" ControlToValidate="ddlCountry"
        InitialValue='<%# UIUtility.DEFAULT_DDL_VALUE %>' Display="Static" ToolTip="Select Country">
        <span style="color:Red">*</span>
    </asp:RequiredFieldValidator>
</div>
<div id="dvStateName" class="dvColumnRight">
    <asp:Label ID="lblState" runat="server" Text="State Name"></asp:Label>
    <span style="color: Red">*</span>
    <asp:DropDownList ID="ddlState" runat="server" DataValueField="State_Id" DataTextField="State_Name"
        AutoPostBack="True" OnSelectedIndexChanged="ddlState_SelectedIndexChanged">
    </asp:DropDownList>
    <asp:RequiredFieldValidator ID="rfvState" runat="server" ControlToValidate="ddlState"
        InitialValue='<%# UIUtility.DEFAULT_DDL_VALUE %>' Display="Static" ToolTip="Select State">
                                            <span style="color:Red">*</span>
    </asp:RequiredFieldValidator>
</div>
<div id="dvCityName" class="dvColumnLeft">
    <asp:Label ID="lblCity" runat="server" Text="City Name"></asp:Label>
    <span style="color: Red">*</span>
    <asp:DropDownList ID="ddlCity" runat="server" DataValueField="City_Id" DataTextField="City_Name">
    </asp:DropDownList>
    <asp:RequiredFieldValidator ID="rfvCity" runat="server" ControlToValidate="ddlCity"
        InitialValue='<%# UIUtility.DEFAULT_DDL_VALUE %>' Display="Static" ToolTip="Select City">
                                            <span style="color:Red">*</span>
    </asp:RequiredFieldValidator>
</div>
<div id="dvDistrict" class="dvColumnRight">
    <asp:Label ID="lblDistrict" runat="server" Text="District"></asp:Label>
    <asp:TextBox ID="txtDistrict" runat="server"></asp:TextBox>
</div>
<div id="dvPinCod" class="dvColumnLeft">
    <asp:Label ID="lblPinCode" runat="server" Text="Pin Code"></asp:Label>
    <asp:TextBox ID="txtPinCode" runat="server"></asp:TextBox>
</div>
<div id="dvLandmark" class="dvColumnRight">
    <asp:Label ID="lblLandmark" runat="server" Text="Landmark"></asp:Label>
    <asp:TextBox ID="txtLandmark" runat="server"></asp:TextBox>
</div>
<div id="LandlineNo" class="dvColumnLeft">
    <asp:Label ID="lblLandlineNo" runat="server" Text="Landline No"></asp:Label>
    <asp:TextBox ID="txtLandlineNo" runat="server"></asp:TextBox>
</div>
<div id="MobileNo" class="dvColumnRight">
    <asp:Label ID="lblMobileNo" runat="server" Text="Mobile No"></asp:Label>
    <asp:TextBox ID="txtMobileNo" runat="server"></asp:TextBox>
</div>
<div id="EmailId" class="dvColumnLeft">
    <asp:Label ID="lblEmailId" runat="server" Text="Email Id"></asp:Label>
    <asp:TextBox ID="txtEmailId" runat="server"></asp:TextBox>
</div>
<asp:HiddenField ID="hfAddressId" runat="server" />
