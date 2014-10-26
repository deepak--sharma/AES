using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using AjaxControlToolkit;

public partial class ImagePreviwUC : System.Web.UI.UserControl
{      

    protected void OnAsyncFileUploadComplete(object sender, AsyncFileUploadEventArgs e)
    {
        if (asyncFileUpload.PostedFile != null)
        {           
            HttpPostedFile file = asyncFileUpload.PostedFile;

            byte[] data = ReadFile(file);
            Session[UserDataKeys.UPLOADED_IMAGE] = data;
        }
    }

    private byte[] ReadFile(HttpPostedFile file)
    {
        byte[] data = new Byte[file.ContentLength];
        file.InputStream.Read(data, 0, file.ContentLength);
        return data;
    }
}
