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

public partial class MetadataTypeUI : BasePage
{
	#region Page Variables
	MetadataType objMetadataType = null;
	MetadataTypeBL objMetadataTypeBL = null;

	private const int SELECT_COLUMN = 0;
	private const int ACTIVATE_COLUMN = 1;
	private const int DELETE_COLUMN = 2;

	private const int METADATA_TYPE_ID_INDEX = 0;
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
			objMetadataType = BindMetadataTypeGrid(RecordStatus.Active);
			if (objMetadataType.DbOperationStatus != CommonConstant.SUCCEED)
			{
				btnAddNewRecord.Enabled = false;
				UIUtility.DisplayMessage(lblMessage, objMetadataType.DbOperationStatus);
				return;
			}

			ViewState[isControlsLoaded] = false;

			if (grdMetadataType.Rows.Count == 0)
			{
				BindMetadataTypeControls();
				MultiViewMetadataType.ActiveViewIndex = 1;
			}
		}
		else
		{
			if (rdbActiveRecord.Checked)
			{
				objMetadataType = BindMetadataTypeGrid(RecordStatus.Active);
				if (objMetadataType.DbOperationStatus != CommonConstant.SUCCEED)
				{
					UIUtility.DisplayMessage(lblMessage, objMetadataType.DbOperationStatus);
					return;
				}
				ViewActivateColumn(false);
			}
			else
			{
				objMetadataType = BindMetadataTypeGrid(RecordStatus.InActive);
				if (objMetadataType.DbOperationStatus != CommonConstant.SUCCEED)
				{
					UIUtility.DisplayMessage(lblMessage, objMetadataType.DbOperationStatus);
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
			grdMetadataType.Columns[SELECT_COLUMN].Visible = false;
			grdMetadataType.Columns[ACTIVATE_COLUMN].Visible = true;
			grdMetadataType.Columns[DELETE_COLUMN].Visible = false;
		}
		else
		{
			grdMetadataType.Columns[SELECT_COLUMN].Visible = true;
			grdMetadataType.Columns[ACTIVATE_COLUMN].Visible = false;
			grdMetadataType.Columns[DELETE_COLUMN].Visible = true;
		}
	}
	#endregion

	#region Grid Events and Functions
	protected void grdMetadataType_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			objMetadataType = SelectRecordById(grdMetadataType.SelectedIndex);
			if (!objMetadataType.DbOperationStatus.Equals(CommonConstant.FAIL))
			{
				if(!Convert.ToBoolean(objMetadataType.IsRecordChanged))
				{
					ActivateControlsView(false, objMetadataType, grdMetadataType.SelectedIndex);
				}
				else
				{
					UIUtility.DisplayMessage(lblMessage, objMetadataType.DbOperationStatus);
					InitializeForm();
				}
			}
			else
			{
				UIUtility.DisplayMessage(lblMessage, objMetadataType.DbOperationStatus);
			}
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdMetadataType_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
		try
		{
			objMetadataTypeBL = new MetadataTypeBL();
			objMetadataType = GetObjectForActivateDeactivate(e.RowIndex,RecordStatus.InActive);
			objMetadataType = objMetadataTypeBL.ActivateDeactivateMetadataType(objMetadataType);
			UIUtility.DisplayMessage(lblMessage, objMetadataType.DbOperationStatus);
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdMetadataType_ActivatingObject(object sender, GridViewEditEventArgs e)
	{
		try
		{
			objMetadataTypeBL = new MetadataTypeBL();
			objMetadataType = GetObjectForActivateDeactivate(e.NewEditIndex, RecordStatus.Active);
			objMetadataType = objMetadataTypeBL.ActivateDeactivateMetadataType(objMetadataType);
			UIUtility.DisplayMessage(lblMessage, objMetadataType.DbOperationStatus);
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdMetadataType_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		try
		{
			grdMetadataType.PageIndex = e.NewPageIndex;
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected MetadataType BindMetadataTypeGrid(RecordStatus objRecordStatus)
	{
		objMetadataTypeBL = new MetadataTypeBL();
		objMetadataType = new MetadataType();
		objMetadataType.RecordStatus = Convert.ToInt16(objRecordStatus);

		objMetadataType = objMetadataTypeBL.SelectMetadataType(objMetadataType);
		if (objMetadataType.DbOperationStatus == CommonConstant.SUCCEED)
		{
			grdMetadataType.DataSource = objMetadataType.ObjectDataSet.Tables[0];
			grdMetadataType.DataBind();
		}
		return objMetadataType;
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
				objMetadataType = GetObjectForInsertUpdate();
				objMetadataTypeBL = new MetadataTypeBL();
				if (objMetadataType.MetadataTypeId == null)
				{
					objMetadataType = objMetadataTypeBL.InsertMetadataType(objMetadataType);
				}
				else
				{
					objMetadataType = objMetadataTypeBL.UpdateMetadataType(objMetadataType);
				}
				if (objMetadataType.DbOperationStatus == CommonConstant.SUCCEED
							|| objMetadataType.DbOperationStatus == CommonConstant.INVALID)
				{
					InitializeForm();
					MultiViewMetadataType.ActiveViewIndex = 0;
				}
				UIUtility.DisplayMessage(lblMessage, objMetadataType.DbOperationStatus);
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
			MultiViewMetadataType.ActiveViewIndex = 0;
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
	protected void BindMetadataTypeControls()
	{
		if (!Convert.ToBoolean(ViewState[isControlsLoaded]))
		{
			ViewState[isControlsLoaded] = true;
		}
	}
	protected void ActivateControlsView(bool isNewRecord, MetadataType objMetadataType,int? editIndex)
	{
		if (isNewRecord)
		{
			ViewState[editIndexKey] = null;
			BindMetadataTypeControls();
			UIUtility.InitializeControls(ViewMetadataTypeControls);
		}
		else
		{
			ViewState[editIndexKey] = editIndex;
			BindMetadataTypeControls();
			PopulateControlsData(objMetadataType);
		}
		MultiViewMetadataType.ActiveViewIndex = 1;
	}
	private void PopulateControlsData(MetadataType objMetadataType)
	{
		txtMetadataTypeName.Text = objMetadataType.MetadataTypeName;
	}
	#endregion

	#region Helper Functions
	private bool ValidateObject()
	{
		return true;
	}
	private MetadataType GetObjectForInsertUpdate()
	{
		objMetadataType = new MetadataType();

		if (ViewState[editIndexKey] == null)
		{
			objMetadataType.Version = BusinessUtility.RECORD_VERSION;
			objMetadataType.CreatedBy = LoggedInUser;
			objMetadataType.CreatedOn = GeneralUtility.CurrentDateTime;
		}
		else
		{
			objMetadataType.MetadataTypeId = Convert.ToInt32(grdMetadataType.DataKeys[Convert.ToInt32(ViewState[editIndexKey])].Values[METADATA_TYPE_ID_INDEX].ToString());
			objMetadataType.Version = Convert.ToInt16(grdMetadataType.DataKeys[Convert.ToInt16(ViewState[editIndexKey])].Values[VERSION_INDEX].ToString()) + 1;
		}

		objMetadataType.MetadataTypeName = txtMetadataTypeName.Text;
		objMetadataType.ModifiedBy = LoggedInUser;
		objMetadataType.ModifiedOn = GeneralUtility.CurrentDateTime;
		objMetadataType.RecordStatus = Convert.ToInt16(RecordStatus.Active);
		return objMetadataType;
	}
	private MetadataType GetObjectForActivateDeactivate(int editIndex,RecordStatus objStatus)
	{
		objMetadataType = new MetadataType();
		objMetadataType.MetadataTypeId = Convert.ToInt32(grdMetadataType.DataKeys[editIndex].Values[METADATA_TYPE_ID_INDEX].ToString());
		objMetadataType.Version = Convert.ToInt16(grdMetadataType.DataKeys[editIndex].Values[VERSION_INDEX].ToString()) + 1;
		objMetadataType.ModifiedBy = LoggedInUser;
		objMetadataType.RecordStatus = Convert.ToInt16(objStatus);
		return objMetadataType;
	}
	private MetadataType SelectRecordById(int editIndex)
	{
		objMetadataTypeBL = new MetadataTypeBL();
		objMetadataType = new MetadataType();
		objMetadataType.MetadataTypeId = Convert.ToInt32(grdMetadataType.DataKeys[editIndex].Values[METADATA_TYPE_ID_INDEX].ToString());
		objMetadataType.Version = Convert.ToInt16(grdMetadataType.DataKeys[editIndex].Values[VERSION_INDEX].ToString());
		objMetadataType = objMetadataTypeBL.SelectRecordById(objMetadataType);
		return objMetadataType;
	}
	#endregion
}
