<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HomePage.aspx.cs" Inherits="NewHomePage_HomePage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sheen Solution Home Page</title>
    <link href="NewHomePage/templatemo_style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <div id="templatemo_header_wrapper">
        <div id="templatemo_header">
            <div id="site_title">
                <h1>
                    <a href="#" target="_parent">
                        <img src="NewHomePage/images/templatemo_logo.png" alt="Image logo" />
                        <span>Seen Solution</span> </a>
                </h1>
            </div>
            <p>
                Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla aliquet, ipsum bibendum
                pretium volutpat, diam magna facilisis ante.</p>
        </div>
    </div>
    <div id="templatemo_menu_wrapper">
        <div id="templatemo_menu">
            <ul>
                <li><a href="#" class="current">Home</a></li>
                <li><a href="#" target="_parent">Templates</a></li>
                <li><a href="#" target="_parent">Flash Files</a></li>
                <li><a href="#" target="_parent">Gallery</a></li>
                <li><a href="#">Members</a></li>
                <li><a href="#">Contact</a></li>
            </ul>
        </div>
    </div>
    <div id="templatemo_content_wrapper">
        <div id="templatemo_sidebar">
            <div class="sidebar_box">
                <div style="height: 350px">
                    <h2>
                        News & Events</h2>
                    <marquee id="ml" style="text-align: center" direction="up" width="195" height="170"
                        scrolldelay="20" scrollamount="1" onmouseover="this.stop()" onmouseout="this.start()">
                    <hr style="height: 1px; color: #F5C6B2;"><p><br />
                    <asp:DataList ID="dlActiveRegistration" runat="server" DataKeyField="REGISTRATION_ID">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Eval("REGISTRATION_ID","~/StudentRegistrationWizardUI.aspx?RegMasterId={0}") %>'>
                                            <asp:Label ID="lblActiveRegistration" runat="server" Text='<%# Bind("REGISTRATION_NAME")%>' Font-Bold="false" ></asp:Label>
                                            <img src="NewHomePage/images/New.gif"/>
                                            </asp:HyperLink><br />                                                                                                         
                                        </ItemTemplate>
                                    </asp:DataList></p>                           
                  <hr style="height: 1px; color: #F5C6B2;"/>
                  <br />                  
                    </marquee>
                </div>
            </div>
            <div class="sidebar_box_bottom">
            </div>
            <div class="sidebar_box">
                <h2>
                    Login</h2>
                <form runat="server">
                <div>
                    <div>
                        <label>
                            User name</label>
                        <input id="txtLoginId" name="txtLoginId" maxlength="20" type="text" tabindex="1"
                            value='Username' onclick="javascript:WatermarkFocus(this,'Username');" onblur="javascript:WatermarkBlur(this,'Username');" />
                    </div>
                    <div>
                        <label>
                            Password</label><input id="txtPassword" name="txtPassword" type="password" maxlength="20"
                                tabindex="2" value='Password' onfocus="javascript:WatermarkFocus(this, 'Password');"
                                onblur="javascript:WatermarkBlur(this, 'Password');" onkeypress="return clickButton(event,'btnSubmit');" />
                    </div>
                    <div>
                        <asp:LinkButton ID="lbForgetPassword" runat="server" Text="Forgot Password?" Font-Underline="false"
                            Font-Names="font:normal 12px/17px Arial, Helvetica, sans-serif;" CausesValidation="false"></asp:LinkButton>
                        <%--<asp:HyperLink ID="lnkLogIn" runat="server" NavigateUrl="~/WelcomePage.aspx" Text="LogIn"
                            CssClass="go"></asp:HyperLink>--%>
                        <asp:LinkButton ID="lnkLogIn" runat="server" Text="LogIn" CssClass="go" OnClick="lnkLogIn_Click"></asp:LinkButton>
                    </div>
                </div>
                </form>
                <div class="cleaner">
                </div>
            </div>
            <div class="sidebar_box_bottom">
            </div>
        </div>
        <!-- end of sidebar -->
        <div id="templatemo_content">
            <div class="content_box">
                <h2>
                    Welcome to Education System</h2>
                <p>
                    <a href="#" target="_parent">Free CSS Templates</a> are provided by <a href="#" target="_parent">
                        templatemo.com</a> for everyone. Feel free to download, edit and apply this
                    template for your personal or business websites. Validate <a href="#">XHTML</a>
                    &amp; <a href="#">CSS</a>. Credit goes to <a href="#">Public Domain Pictures</a>
                    for photos used in this template. Nam ut libero at lacus feugiat tincidunt vitae
                    sed ipsum.</p>
                <div class="cleaner_h20">
                </div>
                <div class="image_fl">
                    <img src="NewHomePage/images/templatemo_images01.jpg" alt="image" />
                </div>
                <div class="section_w250 float_r">
                    <ul class="list_01">
                        <li>Praesent condimentum magna ut </li>
                        <li>Nunc luctus eros eu enim gravida ut </li>
                        <li>Phasellus nec ante eget felis </li>
                        <li>Morbi pellentesque tellus adipiscing </li>
                        <li>Nunc accumsan sagittis sem, ut </li>
                        <li>Nunc luctus eros eu enim gravida ut </li>
                        <li>Phasellus nec ante eget felis </li>
                    </ul>
                </div>
                <div class="cleaner">
                </div>
            </div>
            <div class="content_box_bottom">
            </div>
            <div class="content_box">
                <h2>
                    Photo Gallery</h2>
                <div class="section_w250 float_l">
                    <h3>
                        Praesent sollicitudin</h3>
                    <p>
                        Nullam faucibus volutpat sapien sit amet tristique. Suspendisse venenatis, urna
                        nec rhoncus suscipit, turpis turpis auctor nisi.</p>
                </div>
                <div class="section_w250 float_r">
                    <h3>
                        Quisque blandit</h3>
                    <p>
                        Morbi blandit ipsum sed purus vestibulum bibendum. Lorem ipsum dolor sit amet, consectetur
                        adipiscing elit. Sed nec nibh sed tellus.</p>
                </div>
                <div class="cleaner">
                </div>
            </div>
            <div class="content_box_bottom">
            </div>
        </div>
        <!-- end of content -->
        <div class="cleaner">
        </div>
    </div>
    <div id="templatemo_footer_wrapper">
        <div id="templatemo_footer">
            <ul class="footer_menu">
                <li><a href="#">Home</a></li>
                <li><a href="#" target="_parent">Templates</a></li>
                <li><a href="#" target="_parent">Flash Files</a></li>
                <li><a href="#" target="_parent">Gallery</a></li>
                <li><a href="#">Members</a></li>
                <li class="last_menu"><a href="#">Contact Us</a></li>
            </ul>
            <a href="#">Copyright &copy; 2011 Sheen Solutions. All Rights Reserved. Powered by AES</a>
        </div>
    </div>
</body>
</html>
