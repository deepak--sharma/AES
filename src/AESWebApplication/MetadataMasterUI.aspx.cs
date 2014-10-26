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

public partial class MetadataMasterUI : BasePage
{
	#region Page Variables
	MetadataMaster objMetadataMaster = null;
	MetadataMasterBL objMetadataMasterBL = null;
	MetadataType objMetadataType = null;
	MetadataTypeBL objMetadataTypeBL = null;

	private const int SELECT_COLUMN = 0;
	private const int ACTIVATE_COLUMN = 1;
	private const int DELETE_COLUMN = 2;

	private const int METADATA_ID_INDEX = 0;
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
			objMetadataMaster = BindMetadataMasterGrid(RecordStatus.Active);
			if (objMetadataMaster.DbOperationStatus != CommonConstant.SUCCEED)
			{
				btnAddNewRecord.Enabled = false;
				UIUtility.DisplayMessage(lblMessage, objMetadataMaster.DbOperationStatus);
				return;
			}

			ViewState[isControlsLoaded] = false;

			if (grdMetadataMaster.Rows.Count == 0)
			{
				BindMetadataMasterControls();
				MultiViewMetadataMaster.ActiveViewIndex = 1;
			}
		}
		else
		{
			if (rdbActiveRecord.Checked)
			{
				objMetadataMaster = BindMetadataMasterGrid(RecordStatus.Active);
				if (objMetadataMaster.DbOperationStatus != CommonConstant.SUCCEED)
				{
					UIUtility.DisplayMessage(lblMessage, objMetadataMaster.DbOperationStatus);
					return;
				}
				ViewActivateColumn(false);
			}
			else
			{
				objMetadataMaster = BindMetadataMasterGrid(RecordStatus.InActive);
				if (objMetadataMaster.DbOperationStatus != CommonConstant.SUCCEED)
				{
					UIUtility.DisplayMessage(lblMessage, objMetadataMaster.DbOperationStatus);
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
			grdMetadataMaster.Columns[SELECT_COLUMN].Visible = false;
			grdMetadataMaster.Columns[ACTIVATE_COLUMN].Visible = true;
			grdMetadataMaster.Columns[DELETE_COLUMN].Visible = false;
		}
		else
		{
			grdMetadataMaster.Columns[SELECT_COLUMN].Visible = true;
			grdMetadataMaster.Columns[ACTIVATE_COLUMN].Visible = false;
			grdMetadataMaster.Columns[DELETE_COLUMN].Visible = true;
		}
	}
	#endregion

	#region Grid Events and Functions
	protected void grdMetadataMaster_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			objMetadataMaster = SelectRecordById(grdMetadataMaster.SelectedIndex);
			if (!objMetadataMaster.DbOperationStatus.Equals(CommonConstant.FAIL))
			{
				if(!Convert.ToBoolean(objMetadataMaster.IsRecordChanged))
				{
					ActivateControlsView(false, objMetadataMaster, grdMetadataMaster.SelectedIndex);
				}
				else
				{
					UIUtility.DisplayMessage(lblMessage, objMetadataMaster.DbOperationStatus);
					InitializeForm();
				}
			}
			else
			{
				UIUtility.DisplayMessage(lblMessage, objMetadataMaster.DbOperationStatus);
			}
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdMetadataMaster_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
		try
		{
			objMetadataMasterBL = new MetadataMasterBL();
			objMetadataMaster = GetObjectForActivateDeactivate(e.RowIndex,RecordStatus.InActive);
			objMetadataMaster = objMetadataMasterBL.ActivateDeactivateMetadataMaster(objMetadataMaster);
			UIUtility.DisplayMessage(lblMessage, objMetadataMaster.DbOperationStatus);
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdMetadataMaster_ActivatingObject(object sender, GridViewEditEventArgs e)
	{
		try
		{
			objMetadataMasterBL = new MetadataMasterBL();
			objMetadataMaster = GetObjectForActivateDeactivate(e.NewEditIndex, RecordStatus.Active);
			objMetadataMaster = objMetadataMasterBL.ActivateDeactivateMetadataMaster(objMetadataMaster);
			UIUtility.DisplayMessage(lblMessage, objMetadataMaster.DbOperationStatus);
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdMetadataMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		try
		{
			grdMetadataMaster.PageIndex = e.NewPageIndex;
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected MetadataMaster BindMetadataMasterGrid(RecordStatus objRecordStatus)
	{
		objMetadataMasterBL = new MetadataMasterBL();
		objMetadataMaster = new MetadataMaster();
		objMetadataMaster.RecordStatus = Convert.ToInt16(objRecordStatus);

		objMetadataMaster = objMetadataMasterBL.SelectMetadataMaster(objMetadataMaster);
		if (objMetadataMaster.DbOperationStatus == CommonConstant.SUCCEED)
		{
			grdMetadataMaster.DataSource = objMetadataMaster.ObjectDataSet.Tables[0];
			grdMetadataMaster.DataBind();
		}
		return objMetadataMaster;
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
				objMetadataMaster = GetObjectForInsertUpdate();
				objMetadataMasterBL = new MetadataMasterBL();
				if (objMetadataMaster.MetadataId == null)
				{
					objMetadataMaster = objMetadataMasterBL.InsertMetadataMaster(objMetadataMaster);
				}
				else
				{
					objMetadataMaster = objMetadataMasterBL.UpdateMetadataMaster(objMetadataMaster);
				}
				if (objMetadataMaster.DbOperationStatus == CommonConstant.SUCCEED
							|| objMetadataMaster.DbOperationStatus == CommonConstant.INVALID)
				{
					InitializeForm();
					MultiViewMetadataMaster.ActiveViewIndex = 0;
				}
				UIUtility.DisplayMessage(lblMessage, objMetadataMaster.DbOperationStatus);
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
			MultiViewMetadataMaster.ActiveViewIndex = 0;
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
	protected void BindMetadataMasterControls()
	{
		if (!Convert.ToBoolean(ViewState[isControlsLoaded]))
		{
			objMetadataTypeBL = new MetadataTypeBL();
			objMetadataType = new MetadataType();
			objMetadataType.RecordStatus = Convert.ToInt16(RecordStatus.Active);
			objMetadataType = objMetadataTypeBL.SelectMetadataType(objMetadataType);
			ddlMetadata.DataSource = objMetadataType.ObjectDataSet.Tables[0];
			ddlMetadata.DataBind();
			ddlMetadata.Items.Insert(0, UIUtility.DEFAULT_DDL_VALUE);

			ViewState[isControlsLoaded] = true;
		}
	}
	protected void ActivateControlsView(bool isNewRecord, MetadataMaster objMetadataMaster,int? editIndex)
	{
		if (isNewRecord)
		{
			ViewState[editIndexKey] = null;
			BindMetadataMasterControls();
			UIUtility.InitializeControls(ViewMetadataMasterControls);
		}
		else
		{
			ViewState[editIndexKey] = editIndex;
			BindMetadataMasterControls();
			PopulateControlsData(objMetadataMaster);
		}
		MultiViewMetadataMaster.ActiveViewIndex = 1;
	}
	private void PopulateControlsData(MetadataMaster objMetadataMaster)
	{
		UIUtility.SelectCurrentListItem(ddlMetadata, objMetadataMaster.MetadataTypeObject.MetadataTypeId, BindListItem.ByValue, true);
		txtMetadataName.Text = objMetadataMaster.MetadataName;
		txtMetadataCode.Text = objMetadataMaster.MetadataCode;
		UIUtility.SelectCurrentListItem(ddlIsSystemType, objMetadataMaster.IsSystemType, BindListItem.ByValue, true);
	}
	#endregion

	#region Helper Functions
	private bool ValidateObject()
	{
		return true;
	}
	private MetadataMaster GetObjectForInsertUpdate()
	{
		objMetadataMaster = new MetadataMaster();

		if (ViewState[editIndexKey] == null)
		{
			objMetadataMaster.Version = BusinessUtility.RECORD_VERSION;
			objMetadataMaster.CreatedBy = LoggedInUser;
			objMetadataMaster.CreatedOn = GeneralUtility.CurrentDateTime;
		}
		else
		{
			objMetadataMaster.MetadataId = Convert.ToInt32(grdMetadataMaster.DataKeys[Convert.ToInt32(ViewState[editIndexKey])].Values[METADATA_ID_INDEX].ToString());
			objMetadataMaster.Version = Convert.ToInt16(grdMetadataMaster.DataKeys[Convert.ToInt16(ViewState[editIndexKey])].Values[VERSION_INDEX].ToString()) + 1;
		}

		if (ddlMetadata.SelectedIndex != 0)
		{
			objMetadataMaster.MetadataTypeObject = new MetadataType();
			objMetadataMaster.MetadataTypeObject.MetadataTypeId = Convert.ToInt32(ddlMetadata.SelectedItem.Value);
		}
		objMetadataMaster.MetadataName = txtMetadataName.Text;
		objMetadataMaster.MetadataCode = txtMetadataCode.Text;
		objMetadataMaster.IsSystemType = Convert.ToBoolean(ddlIsSystemType.SelectedItem.Value);
		objMetadataMaster.ModifiedBy = LoggedInUser;
		objMetadataMaster.ModifiedOn = GeneralUtility.CurrentDateTime;
		objMetadataMaster.RecordStatus = Convert.ToInt16(RecordStatus.Active);
		return objMetadataMaster;
	}
	private MetadataMaster GetObjectForActivateDeactivate(int editIndex,RecordStatus objStatus)
	{
		objMetadataMaster = new MetadataMaster();
		objMetadataMaster.MetadataId = Convert.ToInt32(grdMetadataMaster.DataKeys[editIndex].Values[METADATA_ID_INDEX].ToString());
		objMetadataMaster.Version = Convert.ToInt16(grdMetadataMaster.DataKeys[editIndex].Values[VERSION_INDEX].ToString()) + 1;
		objMetadataMaster.ModifiedBy = LoggedInUser;
		objMetadataMaster.RecordStatus = Convert.ToInt16(objStatus);
		return objMetadataMaster;
	}
	private MetadataMaster SelectRecordById(int editIndex)
	{
		objMetadataMasterBL = new MetadataMasterBL();
		objMetadataMaster = new MetadataMaster();
		objMetadataMaster.MetadataId = Convert.ToInt32(grdMetadataMaster.DataKeys[editIndex].Values[METADATA_ID_INDEX].ToString());
		objMetadataMaster.Version = Convert.ToInt16(grdMetadataMaster.DataKeys[editIndex].Values[VERSION_INDEX].ToString());
		objMetadataMaster = objMetadataMasterBL.SelectRecordById(objMetadataMaster);
		return objMetadataMaster;
	}
	#endregion
}
