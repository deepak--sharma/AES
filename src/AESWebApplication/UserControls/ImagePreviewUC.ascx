<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ImagePreviewUC.ascx.cs"
    Inherits="ImagePreviwUC" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%--<asp:ToolkitScriptManager ID="toolKitScriptManager" runat="server">
</asp:ToolkitScriptManager>--%>
<div>
    <asp:AsyncFileUpload ID="asyncFileUpload" runat="server" OnClientUploadComplete="OnClientAsyncFileUploadComplete"
        OnUploadedComplete="OnAsyncFileUploadComplete" UploadingBackColor="#FFCCCC" Width="150px" />
</div>
<div id="dvImage" style="width:150px;height:150px;">
    <asp:Image runat="server" ID="previewImage" Width="150" Height="150" ImageUrl="~/Images/unknown_person.jpg"/>
</div>
<div id="dvEditImage" style="visibility: hidden">
    <a id="lnkEditImage" onclick="return ShowHideFileUploadControl(false);">Edit</a>
    <a id="lnkCancel" onclick="return ShowHideFileUploadControl(true);">Cancel</a>
</div>

<script language="javascript" type="text/javascript">
        function getRandomNumber() {
            var randomnumber = Math.random(10000);
            return randomnumber;
        }
        function OnClientAsyncFileUploadComplete(sender, args) 
        {
            var handlerPage = '<%= Page.ResolveClientUrl("~/ImageHandler.ashx")%>';
            var queryString = '?randomno=' + getRandomNumber();
            var src = handlerPage + queryString;
            var fileUploadClientId = document.getElementById('<%=asyncFileUpload.ClientID %>');
            var imageClientId = document.getElementById('<%=previewImage.ClientID %>');
            imageClientId.setAttribute("src", src);  
            //document.getElementById('dvImage').style.visibility='visible';
            //imageClientId.style.visibility='visible';
            document.getElementById('dvEditImage').style.visibility='visible';                        
            fileUploadClientId.style.visibility='hidden';                                  
        }
        function ShowHideFileUploadControl(showImage)
        {         
            var fileUploadClientId = document.getElementById('<%=asyncFileUpload.ClientID %>');
            //var imageClientId = document.getElementById('<%=previewImage.ClientID %>');
                       
            if(showImage == true)
            {
                  //imageClientId.style.visibility='visible';
                  fileUploadClientId.style.visibility='hidden'
            }
            else{
                   //imageClientId.style.visibility='hidden';
                   fileUploadClientId.style.visibility='visible'
            }
           
            return false;
        }
      
</script>

