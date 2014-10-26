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

public partial class ItemTypeUI : BasePage
{
	#region Page Variables
	ItemType objItemType = null;
	ItemTypeBL objItemTypeBL = null;

	private const int SELECT_COLUMN = 0;
	private const int ACTIVATE_COLUMN = 1;
	private const int DELETE_COLUMN = 2;

	private const int ITEM_TYPE_ID_INDEX = 0;
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
			objItemType = BindItemTypeGrid(RecordStatus.Active);
			if (objItemType.DbOperationStatus != CommonConstant.SUCCEED)
			{
				btnAddNewRecord.Enabled = false;
				UIUtility.DisplayMessage(lblMessage, objItemType.DbOperationStatus);
				return;
			}

			ViewState[isControlsLoaded] = false;

			if (grdItemType.Rows.Count == 0)
			{
				BindItemTypeControls();
				MultiViewItemType.ActiveViewIndex = 1;
			}
		}
		else
		{
			if (rdbActiveRecord.Checked)
			{
				objItemType = BindItemTypeGrid(RecordStatus.Active);
				if (objItemType.DbOperationStatus != CommonConstant.SUCCEED)
				{
					UIUtility.DisplayMessage(lblMessage, objItemType.DbOperationStatus);
					return;
				}
				ViewActivateColumn(false);
			}
			else
			{
				objItemType = BindItemTypeGrid(RecordStatus.InActive);
				if (objItemType.DbOperationStatus != CommonConstant.SUCCEED)
				{
					UIUtility.DisplayMessage(lblMessage, objItemType.DbOperationStatus);
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
			grdItemType.Columns[SELECT_COLUMN].Visible = false;
			grdItemType.Columns[ACTIVATE_COLUMN].Visible = true;
			grdItemType.Columns[DELETE_COLUMN].Visible = false;
		}
		else
		{
			grdItemType.Columns[SELECT_COLUMN].Visible = true;
			grdItemType.Columns[ACTIVATE_COLUMN].Visible = false;
			grdItemType.Columns[DELETE_COLUMN].Visible = true;
		}
	}
	#endregion

	#region Grid Events and Functions
	protected void grdItemType_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			objItemType = SelectRecordById(grdItemType.SelectedIndex);
			if (!objItemType.DbOperationStatus.Equals(CommonConstant.FAIL))
			{
				if(!Convert.ToBoolean(objItemType.IsRecordChanged))
				{
					ActivateControlsView(false, objItemType, grdItemType.SelectedIndex);
				}
				else
				{
					UIUtility.DisplayMessage(lblMessage, objItemType.DbOperationStatus);
					InitializeForm();
				}
			}
			else
			{
				UIUtility.DisplayMessage(lblMessage, objItemType.DbOperationStatus);
			}
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdItemType_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
		try
		{
			objItemTypeBL = new ItemTypeBL();
			objItemType = GetObjectForActivateDeactivate(e.RowIndex,RecordStatus.InActive);
			objItemType = objItemTypeBL.ActivateDeactivateItemType(objItemType);
			UIUtility.DisplayMessage(lblMessage, objItemType.DbOperationStatus);
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdItemType_ActivatingObject(object sender, GridViewEditEventArgs e)
	{
		try
		{
			objItemTypeBL = new ItemTypeBL();
			objItemType = GetObjectForActivateDeactivate(e.NewEditIndex, RecordStatus.Active);
			objItemType = objItemTypeBL.ActivateDeactivateItemType(objItemType);
			UIUtility.DisplayMessage(lblMessage, objItemType.DbOperationStatus);
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdItemType_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		try
		{
			grdItemType.PageIndex = e.NewPageIndex;
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected ItemType BindItemTypeGrid(RecordStatus objRecordStatus)
	{
		objItemTypeBL = new ItemTypeBL();
		objItemType = new ItemType();
		objItemType.RecordStatus = Convert.ToInt16(objRecordStatus);

		objItemType = objItemTypeBL.SelectItemType(objItemType);
		if (objItemType.DbOperationStatus == CommonConstant.SUCCEED)
		{
			grdItemType.DataSource = objItemType.ObjectDataSet.Tables[0];
			grdItemType.DataBind();
		}
		return objItemType;
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
				objItemType = GetObjectForInsertUpdate();
				objItemTypeBL = new ItemTypeBL();
				if (objItemType.ItemTypeId == null)
				{
					objItemType = objItemTypeBL.InsertItemType(objItemType);
				}
				else
				{
					objItemType = objItemTypeBL.UpdateItemType(objItemType);
				}
				if (objItemType.DbOperationStatus == CommonConstant.SUCCEED
							|| objItemType.DbOperationStatus == CommonConstant.INVALID)
				{
					InitializeForm();
					MultiViewItemType.ActiveViewIndex = 0;
				}
				UIUtility.DisplayMessage(lblMessage, objItemType.DbOperationStatus);
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
			MultiViewItemType.ActiveViewIndex = 0;
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
	protected void BindItemTypeControls()
	{
		if (!Convert.ToBoolean(ViewState[isControlsLoaded]))
		{
			ViewState[isControlsLoaded] = true;
		}
	}
	protected void ActivateControlsView(bool isNewRecord, ItemType objItemType,int? editIndex)
	{
		if (isNewRecord)
		{
			ViewState[editIndexKey] = null;
			BindItemTypeControls();
			UIUtility.InitializeControls(ViewItemTypeControls);
		}
		else
		{
			ViewState[editIndexKey] = editIndex;
			BindItemTypeControls();
			PopulateControlsData(objItemType);
		}
		MultiViewItemType.ActiveViewIndex = 1;
	}
	private void PopulateControlsData(ItemType objItemType)
	{
		txtItemTypeName.Text = objItemType.ItemTypeName;
		txtOrderByFields.Text = objItemType.OrderByFields;
		txtDescription.Text = objItemType.Description;
	}
	#endregion

	#region Helper Functions
	private bool ValidateObject()
	{
		return true;
	}
	private ItemType GetObjectForInsertUpdate()
	{
		objItemType = new ItemType();

		if (ViewState[editIndexKey] == null)
		{
			objItemType.Version = BusinessUtility.RECORD_VERSION;
			objItemType.CreatedBy = LoggedInUser;
			objItemType.CreatedOn = GeneralUtility.CurrentDateTime;
		}
		else
		{
			objItemType.ItemTypeId = Convert.ToInt32(grdItemType.DataKeys[Convert.ToInt32(ViewState[editIndexKey])].Values[ITEM_TYPE_ID_INDEX].ToString());
			objItemType.Version = Convert.ToInt16(grdItemType.DataKeys[Convert.ToInt16(ViewState[editIndexKey])].Values[VERSION_INDEX].ToString()) + 1;
		}

		objItemType.ItemTypeName = txtItemTypeName.Text;
		objItemType.OrderByFields = txtOrderByFields.Text;
		objItemType.Description = txtDescription.Text;
		objItemType.ModifiedBy = LoggedInUser;
		objItemType.ModifiedOn = GeneralUtility.CurrentDateTime;
		objItemType.RecordStatus = Convert.ToInt16(RecordStatus.Active);
		return objItemType;
	}
	private ItemType GetObjectForActivateDeactivate(int editIndex,RecordStatus objStatus)
	{
		objItemType = new ItemType();
		objItemType.ItemTypeId = Convert.ToInt32(grdItemType.DataKeys[editIndex].Values[ITEM_TYPE_ID_INDEX].ToString());
		objItemType.Version = Convert.ToInt16(grdItemType.DataKeys[editIndex].Values[VERSION_INDEX].ToString()) + 1;
		objItemType.ModifiedBy = LoggedInUser;
		objItemType.RecordStatus = Convert.ToInt16(objStatus);
		return objItemType;
	}
	private ItemType SelectRecordById(int editIndex)
	{
		objItemTypeBL = new ItemTypeBL();
		objItemType = new ItemType();
		objItemType.ItemTypeId = Convert.ToInt32(grdItemType.DataKeys[editIndex].Values[ITEM_TYPE_ID_INDEX].ToString());
		objItemType.Version = Convert.ToInt16(grdItemType.DataKeys[editIndex].Values[VERSION_INDEX].ToString());
		objItemType = objItemTypeBL.SelectRecordById(objItemType);
		return objItemType;
	}
	#endregion
}
