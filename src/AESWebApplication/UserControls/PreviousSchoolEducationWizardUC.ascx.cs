using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using AES.SolutionFramework;
using AES.BusinessFramework;
using AES.ObjectFramework;

public partial class PreviousSchoolEducationWizardUC : System.Web.UI.UserControl
{
    #region Page Variables
    PreviousSchoolEducationDetail objPreviousSchoolEducationDetail = null;
    //PreviousSchoolEducationDetailBL objPreviousSchoolEducationDetailBL = null;
    //SchoolMaster objSchoolMaster = null;
    //SchoolMasterBL objSchoolMasterBL = null;
    ClassMaster objClassMaster = null;
    ClassMasterBL objClassMasterBL = null;
    AcademicSessionMaster objAcademicSessionMaster = null;
    AcademicSessionMasterBL objAcademicSessionMasterBL = null;
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        string jScript = String.Format("return EnableDisable(this.checked,'{0}');", tblPreviousEducation.ClientID);
        chkSchoolDetailRequired.Attributes.Add("onclick", jScript);
    }

    #region Controls Events and Functions
    public void InitializeControl()
    {
        if (!Convert.ToBoolean(hfIsControlsLoaded.Value))
        {
            //objSchoolMasterBL = new SchoolMasterBL();
            //objSchoolMaster = new SchoolMaster();
            //objSchoolMaster.RecordStatus = Convert.ToInt16(RecordStatus.Active);
            //objSchoolMaster = objSchoolMasterBL.SelectSchoolMaster(objSchoolMaster);
            //ddlSchool.DataSource = objSchoolMaster.ObjectDataSet.Tables[0];
            //ddlSchool.DataBind();
            //ddlSchool.Items.Insert(0, UIUtility.DEFAULT_DDL_VALUE);

            objClassMasterBL = new ClassMasterBL();
            objClassMaster = new ClassMaster();
            objClassMaster.RecordStatus = Convert.ToInt16(RecordStatus.Active);
            objClassMaster = objClassMasterBL.SelectClassMaster(objClassMaster);
            ddlClass.DataSource = objClassMaster.ObjectDataSet.Tables[0];
            ddlClass.DataBind();
            ddlClass.Items.Insert(0, UIUtility.DEFAULT_DDL_VALUE);

            objAcademicSessionMasterBL = new AcademicSessionMasterBL();
            objAcademicSessionMaster = new AcademicSessionMaster();
            objAcademicSessionMaster.RecordStatus = Convert.ToInt16(RecordStatus.Active);
            objAcademicSessionMaster = objAcademicSessionMasterBL.SelectAcademicSessionMaster(objAcademicSessionMaster);
            ddlAcademic.DataSource = objAcademicSessionMaster.ObjectDataSet.Tables[0];
            ddlAcademic.DataBind();
            ddlAcademic.Items.Insert(0, UIUtility.DEFAULT_DDL_VALUE);

            uxPreviousSchoolEducationMarksWizardUC.InitializeControl();

            hfIsControlsLoaded.Value = true.ToString();
        }
    }
    public void SetControlData(PreviousSchoolEducationDetail objPreviousSchoolEducationDetail)
    {
        if (Convert.ToBoolean(objPreviousSchoolEducationDetail.IsRequired))
        {
            //if (objPreviousSchoolEducationDetail.SchoolObject != null)
            //{
            //    UIUtility.SelectCurrentListItem(ddlSchool, objPreviousSchoolEducationDetail.SchoolObject.SchoolId, BindListItem.ByValue, true);
            //}
            txtSchoolName.Text = objPreviousSchoolEducationDetail.SchoolName;
            txtSchoolAddress.Text = objPreviousSchoolEducationDetail.SchoolAddress;
            txtSchoolContacts.Text = objPreviousSchoolEducationDetail.SchoolContacts;
            if (objPreviousSchoolEducationDetail.ClassObject != null)
            {
                UIUtility.SelectCurrentListItem(ddlClass, objPreviousSchoolEducationDetail.ClassObject.ClassId, BindListItem.ByValue, true);
            }
            txtRegistrationNumber.Text = objPreviousSchoolEducationDetail.RegistrationNumber;
            if (objPreviousSchoolEducationDetail.AcademicSessionObject != null)
            {
                UIUtility.SelectCurrentListItem(ddlAcademic, objPreviousSchoolEducationDetail.AcademicSessionObject.SessionId, BindListItem.ByValue, true);
            }
            txtResultStatus.Text = objPreviousSchoolEducationDetail.ResultStatus;
            txtMarksPercent.Text = objPreviousSchoolEducationDetail.MarksPercent.ToString();
            // txtSupportedDocuments.Text = objPreviousSchoolEducationDetail.SupportedDocuments;            
            chkSchoolDetailRequired.Checked = true;

            uxPreviousSchoolEducationMarksWizardUC.SetControlData(objPreviousSchoolEducationDetail.PreviousSchoolEducationMarksDetailData);
        }
        else
        {
            chkSchoolDetailRequired.Checked = false;
        }
    }
    #endregion

    #region Helper Functions

    public PreviousSchoolEducationDetail GetControlData()
    {
        objPreviousSchoolEducationDetail = new PreviousSchoolEducationDetail();
        if (chkSchoolDetailRequired.Checked)
        {
            //if (ddlSchool.SelectedIndex != 0)
            //{
            //    objPreviousSchoolEducationDetail.SchoolObject = new SchoolMaster();
            //    objPreviousSchoolEducationDetail.SchoolObject.SchoolId = Convert.ToInt32(ddlSchool.SelectedItem.Value);
            //}
            objPreviousSchoolEducationDetail.SchoolName = txtSchoolName.Text;
            objPreviousSchoolEducationDetail.SchoolAddress = txtSchoolAddress.Text;
            objPreviousSchoolEducationDetail.SchoolContacts = txtSchoolContacts.Text;
            if (ddlClass.SelectedIndex != 0)
            {
                objPreviousSchoolEducationDetail.ClassObject = new ClassMaster();
                objPreviousSchoolEducationDetail.ClassObject.ClassId = Convert.ToInt32(ddlClass.SelectedItem.Value);
            }
            objPreviousSchoolEducationDetail.RegistrationNumber = txtRegistrationNumber.Text;
            if (ddlAcademic.SelectedIndex != 0)
            {
                objPreviousSchoolEducationDetail.AcademicSessionObject = new AcademicSessionMaster();
                objPreviousSchoolEducationDetail.AcademicSessionObject.SessionId = Convert.ToInt32(ddlAcademic.SelectedItem.Value);
            }
            objPreviousSchoolEducationDetail.ResultStatus = txtResultStatus.Text;
            objPreviousSchoolEducationDetail.MarksPercent = Convert.ToDecimal(txtMarksPercent.Text);
            //objPreviousSchoolEducationDetail.SupportedDocuments = txtSupportedDocuments.Text;
            objPreviousSchoolEducationDetail.IsRequired = true;

            objPreviousSchoolEducationDetail.PreviousSchoolEducationMarksDetailString = uxPreviousSchoolEducationMarksWizardUC.GetPreviousSchoolMarksString();
        }
        else
        {
            objPreviousSchoolEducationDetail.AcademicSessionObject = new AcademicSessionMaster();
            objPreviousSchoolEducationDetail.AcademicSessionObject.SessionId = Convert.ToInt32(ddlAcademic.Items[1].Value);
            objPreviousSchoolEducationDetail.ResultStatus = "Pass";
            objPreviousSchoolEducationDetail.IsRequired = false;
        }
        return objPreviousSchoolEducationDetail;
    }
    #endregion

}
