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

public partial class FeeDiscountSetupUI : BasePage
{
	#region Page Variables
	FeeDiscountSetup objFeeDiscountSetup = null;
	FeeDiscountSetupBL objFeeDiscountSetupBL = null;
	FeeStructureDetail objFeeStructureDetail = null;
	FeeStructureDetailBL objFeeStructureDetailBL = null;
	FeeMaster objFeeMaster = null;
	FeeMasterBL objFeeMasterBL = null;

	private const int SELECT_COLUMN = 0;
	private const int ACTIVATE_COLUMN = 1;
	private const int DELETE_COLUMN = 2;

	private const int FEE_DISCOUNT_ID_INDEX = 0;
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
			objFeeDiscountSetup = BindFeeDiscountSetupGrid(RecordStatus.Active);
			if (objFeeDiscountSetup.DbOperationStatus != CommonConstant.SUCCEED)
			{
				btnAddNewRecord.Enabled = false;
				UIUtility.DisplayMessage(lblMessage, objFeeDiscountSetup.DbOperationStatus);
				return;
			}

			ViewState[isControlsLoaded] = false;

			if (grdFeeDiscountSetup.Rows.Count == 0)
			{
				BindFeeDiscountSetupControls();
				MultiViewFeeDiscountSetup.ActiveViewIndex = 1;
			}
		}
		else
		{
			if (rdbActiveRecord.Checked)
			{
				objFeeDiscountSetup = BindFeeDiscountSetupGrid(RecordStatus.Active);
				if (objFeeDiscountSetup.DbOperationStatus != CommonConstant.SUCCEED)
				{
					UIUtility.DisplayMessage(lblMessage, objFeeDiscountSetup.DbOperationStatus);
					return;
				}
				ViewActivateColumn(false);
			}
			else
			{
				objFeeDiscountSetup = BindFeeDiscountSetupGrid(RecordStatus.InActive);
				if (objFeeDiscountSetup.DbOperationStatus != CommonConstant.SUCCEED)
				{
					UIUtility.DisplayMessage(lblMessage, objFeeDiscountSetup.DbOperationStatus);
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
			grdFeeDiscountSetup.Columns[SELECT_COLUMN].Visible = false;
			grdFeeDiscountSetup.Columns[ACTIVATE_COLUMN].Visible = true;
			grdFeeDiscountSetup.Columns[DELETE_COLUMN].Visible = false;
		}
		else
		{
			grdFeeDiscountSetup.Columns[SELECT_COLUMN].Visible = true;
			grdFeeDiscountSetup.Columns[ACTIVATE_COLUMN].Visible = false;
			grdFeeDiscountSetup.Columns[DELETE_COLUMN].Visible = true;
		}
	}
	#endregion

	#region Grid Events and Functions
	protected void grdFeeDiscountSetup_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			objFeeDiscountSetup = SelectRecordById(grdFeeDiscountSetup.SelectedIndex);
			if (!objFeeDiscountSetup.DbOperationStatus.Equals(CommonConstant.FAIL))
			{
				if(!Convert.ToBoolean(objFeeDiscountSetup.IsRecordChanged))
				{
					ActivateControlsView(false, objFeeDiscountSetup, grdFeeDiscountSetup.SelectedIndex);
				}
				else
				{
					UIUtility.DisplayMessage(lblMessage, objFeeDiscountSetup.DbOperationStatus);
					InitializeForm();
				}
			}
			else
			{
				UIUtility.DisplayMessage(lblMessage, objFeeDiscountSetup.DbOperationStatus);
			}
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdFeeDiscountSetup_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
		try
		{
			objFeeDiscountSetupBL = new FeeDiscountSetupBL();
			objFeeDiscountSetup = GetObjectForActivateDeactivate(e.RowIndex,RecordStatus.InActive);
			objFeeDiscountSetup = objFeeDiscountSetupBL.ActivateDeactivateFeeDiscountSetup(objFeeDiscountSetup);
			UIUtility.DisplayMessage(lblMessage, objFeeDiscountSetup.DbOperationStatus);
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdFeeDiscountSetup_ActivatingObject(object sender, GridViewEditEventArgs e)
	{
		try
		{
			objFeeDiscountSetupBL = new FeeDiscountSetupBL();
			objFeeDiscountSetup = GetObjectForActivateDeactivate(e.NewEditIndex, RecordStatus.Active);
			objFeeDiscountSetup = objFeeDiscountSetupBL.ActivateDeactivateFeeDiscountSetup(objFeeDiscountSetup);
			UIUtility.DisplayMessage(lblMessage, objFeeDiscountSetup.DbOperationStatus);
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdFeeDiscountSetup_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		try
		{
			grdFeeDiscountSetup.PageIndex = e.NewPageIndex;
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected FeeDiscountSetup BindFeeDiscountSetupGrid(RecordStatus objRecordStatus)
	{
		objFeeDiscountSetupBL = new FeeDiscountSetupBL();
		objFeeDiscountSetup = new FeeDiscountSetup();
		objFeeDiscountSetup.RecordStatus = Convert.ToInt16(objRecordStatus);

		objFeeDiscountSetup = objFeeDiscountSetupBL.SelectFeeDiscountSetup(objFeeDiscountSetup);
		if (objFeeDiscountSetup.DbOperationStatus == CommonConstant.SUCCEED)
		{
			grdFeeDiscountSetup.DataSource = objFeeDiscountSetup.ObjectDataSet.Tables[0];
			grdFeeDiscountSetup.DataBind();
		}
		return objFeeDiscountSetup;
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
				objFeeDiscountSetup = GetObjectForInsertUpdate();
				objFeeDiscountSetupBL = new FeeDiscountSetupBL();
				if (objFeeDiscountSetup.FeeDiscountId == null)
				{
					objFeeDiscountSetup = objFeeDiscountSetupBL.InsertFeeDiscountSetup(objFeeDiscountSetup);
				}
				else
				{
					objFeeDiscountSetup = objFeeDiscountSetupBL.UpdateFeeDiscountSetup(objFeeDiscountSetup);
				}
				if (objFeeDiscountSetup.DbOperationStatus == CommonConstant.SUCCEED
							|| objFeeDiscountSetup.DbOperationStatus == CommonConstant.INVALID)
				{
					InitializeForm();
					MultiViewFeeDiscountSetup.ActiveViewIndex = 0;
				}
				UIUtility.DisplayMessage(lblMessage, objFeeDiscountSetup.DbOperationStatus);
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
			MultiViewFeeDiscountSetup.ActiveViewIndex = 0;
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
	protected void BindFeeDiscountSetupControls()
	{
		if (!Convert.ToBoolean(ViewState[isControlsLoaded]))
		{
			objFeeStructureDetailBL = new FeeStructureDetailBL();
			objFeeStructureDetail = new FeeStructureDetail();
			objFeeStructureDetail.RecordStatus = Convert.ToInt16(RecordStatus.Active);
			objFeeStructureDetail = objFeeStructureDetailBL.SelectFeeStructureDetail(objFeeStructureDetail);
			ddlFee.DataSource = objFeeStructureDetail.ObjectDataSet.Tables[0];
			ddlFee.DataBind();
			ddlFee.Items.Insert(0, UIUtility.DEFAULT_DDL_VALUE);

			objFeeMasterBL = new FeeMasterBL();
			objFeeMaster = new FeeMaster();
			objFeeMaster.RecordStatus = Convert.ToInt16(RecordStatus.Active);
			objFeeMaster = objFeeMasterBL.SelectFeeMaster(objFeeMaster);
			ddlDiscount.DataSource = objFeeMaster.ObjectDataSet.Tables[0];
			ddlDiscount.DataBind();
			ddlDiscount.Items.Insert(0, UIUtility.DEFAULT_DDL_VALUE);

			ViewState[isControlsLoaded] = true;
		}
	}
	protected void ActivateControlsView(bool isNewRecord, FeeDiscountSetup objFeeDiscountSetup,int? editIndex)
	{
		if (isNewRecord)
		{
			ViewState[editIndexKey] = null;
			BindFeeDiscountSetupControls();
			UIUtility.InitializeControls(ViewFeeDiscountSetupControls);
		}
		else
		{
			ViewState[editIndexKey] = editIndex;
			BindFeeDiscountSetupControls();
			PopulateControlsData(objFeeDiscountSetup);
		}
		MultiViewFeeDiscountSetup.ActiveViewIndex = 1;
	}
	private void PopulateControlsData(FeeDiscountSetup objFeeDiscountSetup)
	{
		UIUtility.SelectCurrentListItem(ddlFee, objFeeDiscountSetup.FeeStructureDetailObject.FeeStructureDetailId, BindListItem.ByValue, true);
		UIUtility.SelectCurrentListItem(ddlDiscount, objFeeDiscountSetup.DiscountTypeObject.FeeId, BindListItem.ByValue, true);
		txtDiscountTypeValue.Text = objFeeDiscountSetup.DiscountTypeValue.ToString();
		txtDiscountAmount.Text = objFeeDiscountSetup.DiscountAmount.ToString();
		UIUtility.SelectCurrentListItem(ddlIsPercent, objFeeDiscountSetup.IsPercent, BindListItem.ByValue, true);
		txtEffectiveDate.Text = objFeeDiscountSetup.EffectiveDate.ToString();
	}
	#endregion

	#region Helper Functions
	private bool ValidateObject()
	{
		return true;
	}
	private FeeDiscountSetup GetObjectForInsertUpdate()
	{
		objFeeDiscountSetup = new FeeDiscountSetup();

		if (ViewState[editIndexKey] == null)
		{
			objFeeDiscountSetup.Version = BusinessUtility.RECORD_VERSION;
			objFeeDiscountSetup.CreatedBy = LoggedInUser;
			objFeeDiscountSetup.CreatedOn = GeneralUtility.CurrentDateTime;
		}
		else
		{
			objFeeDiscountSetup.FeeDiscountId = Convert.ToInt32(grdFeeDiscountSetup.DataKeys[Convert.ToInt32(ViewState[editIndexKey])].Values[FEE_DISCOUNT_ID_INDEX].ToString());
			objFeeDiscountSetup.Version = Convert.ToInt16(grdFeeDiscountSetup.DataKeys[Convert.ToInt16(ViewState[editIndexKey])].Values[VERSION_INDEX].ToString()) + 1;
		}

		if (ddlFee.SelectedIndex != 0)
		{
			objFeeDiscountSetup.FeeStructureDetailObject = new FeeStructureDetail();
			objFeeDiscountSetup.FeeStructureDetailObject.FeeStructureDetailId = Convert.ToInt32(ddlFee.SelectedItem.Value);
		}
		if (ddlDiscount.SelectedIndex != 0)
		{
			objFeeDiscountSetup.DiscountTypeObject = new FeeMaster();
			objFeeDiscountSetup.DiscountTypeObject.FeeId = Convert.ToInt32(ddlDiscount.SelectedItem.Value);
		}
		objFeeDiscountSetup.DiscountTypeValue = Convert.ToDateTime(txtDiscountTypeValue.Text);
		objFeeDiscountSetup.DiscountAmount = Convert.ToDecimal(txtDiscountAmount.Text);
		objFeeDiscountSetup.IsPercent = Convert.ToBoolean(ddlIsPercent.SelectedItem.Value);
		objFeeDiscountSetup.EffectiveDate = Convert.ToDateTime(txtEffectiveDate.Text);
		objFeeDiscountSetup.ModifiedBy = LoggedInUser;
		objFeeDiscountSetup.ModifiedOn = GeneralUtility.CurrentDateTime;
		objFeeDiscountSetup.RecordStatus = Convert.ToInt16(RecordStatus.Active);
		return objFeeDiscountSetup;
	}
	private FeeDiscountSetup GetObjectForActivateDeactivate(int editIndex,RecordStatus objStatus)
	{
		objFeeDiscountSetup = new FeeDiscountSetup();
		objFeeDiscountSetup.FeeDiscountId = Convert.ToInt32(grdFeeDiscountSetup.DataKeys[editIndex].Values[FEE_DISCOUNT_ID_INDEX].ToString());
		objFeeDiscountSetup.Version = Convert.ToInt16(grdFeeDiscountSetup.DataKeys[editIndex].Values[VERSION_INDEX].ToString()) + 1;
		objFeeDiscountSetup.ModifiedBy = LoggedInUser;
		objFeeDiscountSetup.RecordStatus = Convert.ToInt16(objStatus);
		return objFeeDiscountSetup;
	}
	private FeeDiscountSetup SelectRecordById(int editIndex)
	{
		objFeeDiscountSetupBL = new FeeDiscountSetupBL();
		objFeeDiscountSetup = new FeeDiscountSetup();
		objFeeDiscountSetup.FeeDiscountId = Convert.ToInt32(grdFeeDiscountSetup.DataKeys[editIndex].Values[FEE_DISCOUNT_ID_INDEX].ToString());
		objFeeDiscountSetup.Version = Convert.ToInt16(grdFeeDiscountSetup.DataKeys[editIndex].Values[VERSION_INDEX].ToString());
		objFeeDiscountSetup = objFeeDiscountSetupBL.SelectRecordById(objFeeDiscountSetup);
		return objFeeDiscountSetup;
	}
	#endregion
}
