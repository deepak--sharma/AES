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

public partial class PreviousSchoolEducationDetailUC : System.Web.UI.UserControl
{
	#region Page Variables
	PreviousSchoolEducationDetail objPreviousSchoolEducationDetail = null;
	PreviousSchoolEducationDetailBL objPreviousSchoolEducationDetailBL = null;
	SchoolMaster objSchoolMaster = null;
	SchoolMasterBL objSchoolMasterBL = null;
	ClassMaster objClassMaster = null;
	ClassMasterBL objClassMasterBL = null;
	AcademicSessionMaster objAcademicSessionMaster = null;
	AcademicSessionMasterBL objAcademicSessionMasterBL = null;
	private string editIndexKey = "EditIndexPreviousSchoolEducationDetailKey";
	#endregion

	#region Page Events and Functions
	protected void Page_Load(object sender, EventArgs e)
	{
	}
	public void InitializeUserControl(int? dataKey,string strSessionDataKey)
	{
		if(!string.IsNullOrEmpty(strSessionDataKey))
		{hfSessionDataKey.Value = strSessionDataKey;}

		if (Session[hfSessionDataKey.Value] == null)
		{
			hfIsControlsLoaded.Value = false.ToString();
			objPreviousSchoolEducationDetailBL = new PreviousSchoolEducationDetailBL();
			objPreviousSchoolEducationDetail = new PreviousSchoolEducationDetail();
			objPreviousSchoolEducationDetail.CandidateObject = new CandidateDetail();
			objPreviousSchoolEducationDetail.CandidateObject.CandidateId = dataKey;

			objPreviousSchoolEducationDetail = objPreviousSchoolEducationDetailBL.SelectPreviousSchoolEducationDetail(objPreviousSchoolEducationDetail);
			grdPreviousSchoolEducationDetail.DataSource = objPreviousSchoolEducationDetail.ObjectDataSet.Tables[0];
			grdPreviousSchoolEducationDetail.DataBind();

			Session[hfSessionDataKey.Value] = objPreviousSchoolEducationDetail.ObjectDataSet.Tables[0];
			MultiViewPreviousSchoolEducationDetail.ActiveViewIndex = 0;

			if (grdPreviousSchoolEducationDetail.Rows.Count == 0)
			{
				hfEditIndexKey.Value = string.Empty;
				BindPreviousSchoolEducationDetailControls();
				UIUtility.InitializeControls(ViewPreviousSchoolEducationDetailControls);
				MultiViewPreviousSchoolEducationDetail.ActiveViewIndex = 1;
			}
		}
		else
		{
			grdPreviousSchoolEducationDetail.DataSource = (DataTable)Session[hfSessionDataKey.Value];
			grdPreviousSchoolEducationDetail.DataBind();
		}
	}
	#endregion

	#region Grid Events and Functions

	protected void grdPreviousSchoolEducationDetail_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			ActivateControlsView(false, grdPreviousSchoolEducationDetail.SelectedIndex);
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdPreviousSchoolEducationDetail_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
		try
		{
			DataTable _objTable =(DataTable) Session[hfSessionDataKey.Value];
			_objTable.Rows[e.RowIndex].Delete();
			InitializeUserControl(null,string.Empty);
			UIUtility.DisplayMessage(lblMessage, CommonConstant.SUCCEED);
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdPreviousSchoolEducationDetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		try
		{
			grdPreviousSchoolEducationDetail.PageIndex = e.NewPageIndex;
			InitializeUserControl(null,string.Empty);
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	#endregion

	#region Controls Events and Functions
	protected void btnAddRecord_Click(object sender, EventArgs e)
	{
		try
		{
			ActivateControlsView(true, null);
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void btnSave_Click(object sender, EventArgs e)
	{
		try
		{
			if (ValidateObject())
			{
				objPreviousSchoolEducationDetail = GetPreviousSchoolEducationDetailForDataTable();
				if (string.IsNullOrEmpty(hfEditIndexKey.Value))
				{
					objPreviousSchoolEducationDetail.AddObjectToTable((DataTable)Session[hfSessionDataKey.Value]);
				}
				else
				{
					int _rowIndex = Convert.ToInt32(hfEditIndexKey.Value);
					objPreviousSchoolEducationDetail.UpdateTableFromObject((DataTable)Session[hfSessionDataKey.Value], _rowIndex);
				}

				UIUtility.DisplayMessage(lblMessage, CommonConstant.SUCCEED);
				InitializeUserControl(null,null);
				MultiViewPreviousSchoolEducationDetail.ActiveViewIndex = 0;
			}
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void btnCancel_Click(object sender, EventArgs e)
	{
		try
		{
			MultiViewPreviousSchoolEducationDetail.ActiveViewIndex = 0;
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void BindPreviousSchoolEducationDetailControls()
	{
		if (!Convert.ToBoolean(hfIsControlsLoaded.Value))
		{
			objSchoolMasterBL = new SchoolMasterBL();
			objSchoolMaster = new SchoolMaster();
			objSchoolMaster.RecordStatus = Convert.ToInt16(RecordStatus.Active);
			objSchoolMaster = objSchoolMasterBL.SelectSchoolMaster(objSchoolMaster);
			ddlSchool.DataSource = objSchoolMaster.ObjectDataSet.Tables[0];
			ddlSchool.DataBind();
			ddlSchool.Items.Insert(0, UIUtility.DEFAULT_DDL_VALUE);

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

			hfIsControlsLoaded.Value = true.ToString();
		}
		
	}
	protected void ActivateControlsView(bool isNewRecord, int? editPreviousSchoolEducationDetailIndex)
	{
		if (isNewRecord)
		{
			hfEditIndexKey.Value=string.Empty;
			BindPreviousSchoolEducationDetailControls();
			UIUtility.InitializeControls(ViewPreviousSchoolEducationDetailControls);
		}
		else
		{
			int _rowIndex = Convert.ToInt32(editPreviousSchoolEducationDetailIndex);
			hfEditIndexKey.Value = _rowIndex.ToString();
			BindPreviousSchoolEducationDetailControls();
			PopulateControlsData(_rowIndex);
		}
		MultiViewPreviousSchoolEducationDetail.ActiveViewIndex = 1;
	}
	private void PopulateControlsData(int rowIndex)
	{
		objPreviousSchoolEducationDetail = new PreviousSchoolEducationDetail();
		objPreviousSchoolEducationDetail.ConvertToObjectFromDataRow((DataTable)Session[hfSessionDataKey.Value], rowIndex);
		UIUtility.SelectCurrentListItem(ddlSchool, objPreviousSchoolEducationDetail.SchoolObject.SchoolId, BindListItem.ByValue, true);
		txtSchoolName.Text = objPreviousSchoolEducationDetail.SchoolName;
		txtSchoolAddress.Text = objPreviousSchoolEducationDetail.SchoolAddress;
		txtSchoolContacts.Text = objPreviousSchoolEducationDetail.SchoolContacts;
		UIUtility.SelectCurrentListItem(ddlClass, objPreviousSchoolEducationDetail.ClassObject.ClassId, BindListItem.ByValue, true);
		txtRegistrationNumber.Text = objPreviousSchoolEducationDetail.RegistrationNumber;
		UIUtility.SelectCurrentListItem(ddlAcademic, objPreviousSchoolEducationDetail.AcademicSessionObject.SessionId, BindListItem.ByValue, true);
		txtResultStatus.Text = objPreviousSchoolEducationDetail.ResultStatus;
		txtMarksPercent.Text = objPreviousSchoolEducationDetail.MarksPercent.ToString();
		txtSupportedDocuments.Text = objPreviousSchoolEducationDetail.SupportedDocuments;
	}
	#endregion

	#region Helper Functions
	private bool ValidateObject()
	{
		return true;
	}

	private PreviousSchoolEducationDetail GetPreviousSchoolEducationDetailForDataTable()
	{
		objPreviousSchoolEducationDetail = new PreviousSchoolEducationDetail();
		if (ddlSchool.SelectedIndex != 0)
		{
			objPreviousSchoolEducationDetail.SchoolObject = new SchoolMaster();
			objPreviousSchoolEducationDetail.SchoolObject.SchoolId = Convert.ToInt32(ddlSchool.SelectedItem.Value);
		}
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
		objPreviousSchoolEducationDetail.SupportedDocuments = txtSupportedDocuments.Text;
		objPreviousSchoolEducationDetail.PreviousSchoolEducationMarksDetailData = ((DataTable)Session[UserDataKeys.PREVIOUSSCHOOLEDUCATIONMARKSDETAIL_PREVIOUSSCHOOLEDUCATIONID]).DataSet;
		return objPreviousSchoolEducationDetail;
	}
	#endregion
}
