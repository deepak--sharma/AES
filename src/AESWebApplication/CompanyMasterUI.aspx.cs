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

public partial class CompanyMasterUI : BasePage
{
	#region Page Variables
	CompanyMaster objCompanyMaster = null;
	CompanyMasterBL objCompanyMasterBL = null;

	private const int SELECT_COLUMN = 0;
	private const int ACTIVATE_COLUMN = 1;
	private const int DELETE_COLUMN = 2;

	private const int COMPANY_ID_INDEX = 0;
	private const int VERSION_INDEX = 1;
	private string isControlsLoaded = "ControlsLoaded";
	private string editIndexKey = "EditIndexKey";
	#endregion

	#region Page Events and Functions
	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			if (!Page.IsPostBack)
			{
				InitializeForm();
			}
		}
		catch (Exception ex)
		{
			btnAddNewRecord.Enabled = false;
			lblMessage.Text = ex.Message;
		}
	}
	private void InitializeForm()
	{
		if (!Page.IsPostBack)
		{
			objCompanyMaster = BindCompanyMasterGrid(RecordStatus.Active);
			if (objCompanyMaster.DbOperationStatus != CommonConstant.SUCCEED)
			{
				btnAddNewRecord.Enabled = false;
				UIUtility.DisplayMessage(lblMessage, objCompanyMaster.DbOperationStatus);
				return;
			}

			ViewState[isControlsLoaded] = false;

			if (grdCompanyMaster.Rows.Count == 0)
			{
				BindCompanyMasterControls();
				MultiViewCompanyMaster.ActiveViewIndex = 1;
			}
		}
		else
		{
			if (rdbActiveRecord.Checked)
			{
				objCompanyMaster = BindCompanyMasterGrid(RecordStatus.Active);
				if (objCompanyMaster.DbOperationStatus != CommonConstant.SUCCEED)
				{
					UIUtility.DisplayMessage(lblMessage, objCompanyMaster.DbOperationStatus);
					return;
				}
				ViewActivateColumn(false);
			}
			else
			{
				objCompanyMaster = BindCompanyMasterGrid(RecordStatus.InActive);
				if (objCompanyMaster.DbOperationStatus != CommonConstant.SUCCEED)
				{
					UIUtility.DisplayMessage(lblMessage, objCompanyMaster.DbOperationStatus);
					return;
				}
				ViewActivateColumn(true);
			}
		}
		btnAddNewRecord.Enabled = true;
	}
	private void ViewActivateColumn(bool view)
	{
		if (view)
		{
			grdCompanyMaster.Columns[SELECT_COLUMN].Visible = false;
			grdCompanyMaster.Columns[ACTIVATE_COLUMN].Visible = true;
			grdCompanyMaster.Columns[DELETE_COLUMN].Visible = false;
		}
		else
		{
			grdCompanyMaster.Columns[SELECT_COLUMN].Visible = true;
			grdCompanyMaster.Columns[ACTIVATE_COLUMN].Visible = false;
			grdCompanyMaster.Columns[DELETE_COLUMN].Visible = true;
		}
	}
	#endregion

	#region Grid Events and Functions
	protected void grdCompanyMaster_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			objCompanyMaster = SelectRecordById(grdCompanyMaster.SelectedIndex);
			if (!objCompanyMaster.DbOperationStatus.Equals(CommonConstant.FAIL))
			{
				if(!Convert.ToBoolean(objCompanyMaster.IsRecordChanged))
				{
					ActivateControlsView(false, objCompanyMaster, grdCompanyMaster.SelectedIndex);
				}
				else
				{
					UIUtility.DisplayMessage(lblMessage, objCompanyMaster.DbOperationStatus);
					InitializeForm();
				}
			}
			else
			{
				UIUtility.DisplayMessage(lblMessage, objCompanyMaster.DbOperationStatus);
			}
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdCompanyMaster_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
		try
		{
			objCompanyMasterBL = new CompanyMasterBL();
			objCompanyMaster = GetObjectForActivateDeactivate(e.RowIndex,RecordStatus.InActive);
			objCompanyMaster = objCompanyMasterBL.ActivateDeactivateCompanyMaster(objCompanyMaster);
			UIUtility.DisplayMessage(lblMessage, objCompanyMaster.DbOperationStatus);
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdCompanyMaster_ActivatingObject(object sender, GridViewEditEventArgs e)
	{
		try
		{
			objCompanyMasterBL = new CompanyMasterBL();
			objCompanyMaster = GetObjectForActivateDeactivate(e.NewEditIndex, RecordStatus.Active);
			objCompanyMaster = objCompanyMasterBL.ActivateDeactivateCompanyMaster(objCompanyMaster);
			UIUtility.DisplayMessage(lblMessage, objCompanyMaster.DbOperationStatus);
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdCompanyMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		try
		{
			grdCompanyMaster.PageIndex = e.NewPageIndex;
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected CompanyMaster BindCompanyMasterGrid(RecordStatus objRecordStatus)
	{
		objCompanyMasterBL = new CompanyMasterBL();
		objCompanyMaster = new CompanyMaster();
		objCompanyMaster.RecordStatus = Convert.ToInt16(objRecordStatus);

		objCompanyMaster = objCompanyMasterBL.SelectCompanyMaster(objCompanyMaster);
		if (objCompanyMaster.DbOperationStatus == CommonConstant.SUCCEED)
		{
			grdCompanyMaster.DataSource = objCompanyMaster.ObjectDataSet.Tables[0];
			grdCompanyMaster.DataBind();
		}
		return objCompanyMaster;
	}
	#endregion

	#region Controls Events and Functions
	protected void btnAddNewRecord_Click(object sender, EventArgs e)
	{
		try
		{
			ActivateControlsView(true, null, null);
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void btnSave_Click(object sender, EventArgs e)
	{

	}
	protected void btnSubmit_Click(object sender, EventArgs e)
	{
		try
		{
			if (ValidateObject())
			{
				objCompanyMaster = GetObjectForInsertUpdate();
				objCompanyMasterBL = new CompanyMasterBL();
				if (objCompanyMaster.CompanyId == null)
				{
					objCompanyMaster = objCompanyMasterBL.InsertCompanyMaster(objCompanyMaster);
				}
				else
				{
					objCompanyMaster = objCompanyMasterBL.UpdateCompanyMaster(objCompanyMaster);
				}
				if (objCompanyMaster.DbOperationStatus == CommonConstant.SUCCEED
							|| objCompanyMaster.DbOperationStatus == CommonConstant.INVALID)
				{
					InitializeForm();
					MultiViewCompanyMaster.ActiveViewIndex = 0;
				}
				UIUtility.DisplayMessage(lblMessage, objCompanyMaster.DbOperationStatus);
			}
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void btnCancelRollback_Click(object sender, EventArgs e)
	{
		try
		{
			MultiViewCompanyMaster.ActiveViewIndex = 0;
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void rdbActiveRecord_CheckedChanged(object sender, EventArgs e)
	{
		try
		{
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void rdbInActiveRecord_CheckedChanged(object sender, EventArgs e)
	{
		try
		{
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void BindCompanyMasterControls()
	{
		if (!Convert.ToBoolean(ViewState[isControlsLoaded]))
		{
			uxCompanyAddressUC.BindUCControls();
			ViewState[isControlsLoaded] = true;
		}
	}
	protected void ActivateControlsView(bool isNewRecord, CompanyMaster objCompanyMaster,int? editIndex)
	{
		if (isNewRecord)
		{
			ViewState[editIndexKey] = null;
			BindCompanyMasterControls();
			UIUtility.InitializeControls(ViewCompanyMasterControls);
		}
		else
		{
			ViewState[editIndexKey] = editIndex;
			BindCompanyMasterControls();
			PopulateControlsData(objCompanyMaster);
		}
		MultiViewCompanyMaster.ActiveViewIndex = 1;
	}
	private void PopulateControlsData(CompanyMaster objCompanyMaster)
	{
		txtCompanyName.Text = objCompanyMaster.CompanyName;
		txtLstNo.Text = objCompanyMaster.LstNo;
		txtCstNo.Text = objCompanyMaster.CstNo;
		txtExciseNo.Text = objCompanyMaster.ExciseNo;
		txtEccNo.Text = objCompanyMaster.EccNo;
		txtIenNo.Text = objCompanyMaster.IenNo;
		uxCompanyAddressUC.SetUserControlData(objCompanyMaster.CompanyAddressObject);
	}
	#endregion

	#region Helper Functions
	private bool ValidateObject()
	{
		return true;
	}
	private CompanyMaster GetObjectForInsertUpdate()
	{
		objCompanyMaster = new CompanyMaster();

		if (ViewState[editIndexKey] == null)
		{
			objCompanyMaster.Version = BusinessUtility.RECORD_VERSION;
			objCompanyMaster.CreatedBy = LoggedInUser;
			objCompanyMaster.CreatedOn = GeneralUtility.CurrentDateTime;
		}
		else
		{
			objCompanyMaster.CompanyId = Convert.ToInt32(grdCompanyMaster.DataKeys[Convert.ToInt32(ViewState[editIndexKey])].Values[COMPANY_ID_INDEX].ToString());
			objCompanyMaster.Version = Convert.ToInt16(grdCompanyMaster.DataKeys[Convert.ToInt16(ViewState[editIndexKey])].Values[VERSION_INDEX].ToString()) + 1;
		}

		objCompanyMaster.CompanyName = txtCompanyName.Text;
		objCompanyMaster.LstNo = txtLstNo.Text;
		objCompanyMaster.CstNo = txtCstNo.Text;
		objCompanyMaster.ExciseNo = txtExciseNo.Text;
		objCompanyMaster.EccNo = txtEccNo.Text;
		objCompanyMaster.IenNo = txtIenNo.Text;
		objCompanyMaster.CompanyAddressObject = uxCompanyAddressUC.GetUserControlData();
		objCompanyMaster.ModifiedBy = LoggedInUser;
		objCompanyMaster.ModifiedOn = GeneralUtility.CurrentDateTime;
		objCompanyMaster.RecordStatus = Convert.ToInt16(RecordStatus.Active);
		return objCompanyMaster;
	}
	private CompanyMaster GetObjectForActivateDeactivate(int editIndex,RecordStatus objStatus)
	{
		objCompanyMaster = new CompanyMaster();
		objCompanyMaster.CompanyId = Convert.ToInt32(grdCompanyMaster.DataKeys[editIndex].Values[COMPANY_ID_INDEX].ToString());
		objCompanyMaster.Version = Convert.ToInt16(grdCompanyMaster.DataKeys[editIndex].Values[VERSION_INDEX].ToString()) + 1;
		objCompanyMaster.ModifiedBy = LoggedInUser;
		objCompanyMaster.RecordStatus = Convert.ToInt16(objStatus);
		return objCompanyMaster;
	}
	private CompanyMaster SelectRecordById(int editIndex)
	{
		objCompanyMasterBL = new CompanyMasterBL();
		objCompanyMaster = new CompanyMaster();
		objCompanyMaster.CompanyId = Convert.ToInt32(grdCompanyMaster.DataKeys[editIndex].Values[COMPANY_ID_INDEX].ToString());
		objCompanyMaster.Version = Convert.ToInt16(grdCompanyMaster.DataKeys[editIndex].Values[VERSION_INDEX].ToString());
		objCompanyMaster = objCompanyMasterBL.SelectRecordById(objCompanyMaster);
		return objCompanyMaster;
	}
	#endregion
}
