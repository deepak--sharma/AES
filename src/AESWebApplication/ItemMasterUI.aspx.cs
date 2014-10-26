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

public partial class ItemMasterUI : BasePage
{
	#region Page Variables
	ItemMaster objItemMaster = null;
	ItemMasterBL objItemMasterBL = null;
	ClassSubjectMapping objClassSubjectMapping = null;
	ClassSubjectMappingBL objClassSubjectMappingBL = null;
	MetadataMaster objMetadataMaster = null;
	MetadataMasterBL objMetadataMasterBL = null;
	RackMaster objRackMaster = null;
	RackMasterBL objRackMasterBL = null;
	ItemType objItemType = null;
	ItemTypeBL objItemTypeBL = null;

	private const int SELECT_COLUMN = 0;
	private const int ACTIVATE_COLUMN = 1;
	private const int DELETE_COLUMN = 2;

	private const int ITEM_ID_INDEX = 0;
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
			objItemMaster = BindItemMasterGrid(RecordStatus.Active);
			if (objItemMaster.DbOperationStatus != CommonConstant.SUCCEED)
			{
				btnAddNewRecord.Enabled = false;
				UIUtility.DisplayMessage(lblMessage, objItemMaster.DbOperationStatus);
				return;
			}

			ViewState[isControlsLoaded] = false;

			if (grdItemMaster.Rows.Count == 0)
			{
				BindItemMasterControls();
				MultiViewItemMaster.ActiveViewIndex = 1;
			}
		}
		else
		{
			if (rdbActiveRecord.Checked)
			{
				objItemMaster = BindItemMasterGrid(RecordStatus.Active);
				if (objItemMaster.DbOperationStatus != CommonConstant.SUCCEED)
				{
					UIUtility.DisplayMessage(lblMessage, objItemMaster.DbOperationStatus);
					return;
				}
				ViewActivateColumn(false);
			}
			else
			{
				objItemMaster = BindItemMasterGrid(RecordStatus.InActive);
				if (objItemMaster.DbOperationStatus != CommonConstant.SUCCEED)
				{
					UIUtility.DisplayMessage(lblMessage, objItemMaster.DbOperationStatus);
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
			grdItemMaster.Columns[SELECT_COLUMN].Visible = false;
			grdItemMaster.Columns[ACTIVATE_COLUMN].Visible = true;
			grdItemMaster.Columns[DELETE_COLUMN].Visible = false;
		}
		else
		{
			grdItemMaster.Columns[SELECT_COLUMN].Visible = true;
			grdItemMaster.Columns[ACTIVATE_COLUMN].Visible = false;
			grdItemMaster.Columns[DELETE_COLUMN].Visible = true;
		}
	}
	#endregion

	#region Grid Events and Functions
	protected void grdItemMaster_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			objItemMaster = SelectRecordById(grdItemMaster.SelectedIndex);
			if (!objItemMaster.DbOperationStatus.Equals(CommonConstant.FAIL))
			{
				if(!Convert.ToBoolean(objItemMaster.IsRecordChanged))
				{
					ActivateControlsView(false, objItemMaster, grdItemMaster.SelectedIndex);
				}
				else
				{
					UIUtility.DisplayMessage(lblMessage, objItemMaster.DbOperationStatus);
					InitializeForm();
				}
			}
			else
			{
				UIUtility.DisplayMessage(lblMessage, objItemMaster.DbOperationStatus);
			}
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdItemMaster_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
		try
		{
			objItemMasterBL = new ItemMasterBL();
			objItemMaster = GetObjectForActivateDeactivate(e.RowIndex,RecordStatus.InActive);
			objItemMaster = objItemMasterBL.ActivateDeactivateItemMaster(objItemMaster);
			UIUtility.DisplayMessage(lblMessage, objItemMaster.DbOperationStatus);
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdItemMaster_ActivatingObject(object sender, GridViewEditEventArgs e)
	{
		try
		{
			objItemMasterBL = new ItemMasterBL();
			objItemMaster = GetObjectForActivateDeactivate(e.NewEditIndex, RecordStatus.Active);
			objItemMaster = objItemMasterBL.ActivateDeactivateItemMaster(objItemMaster);
			UIUtility.DisplayMessage(lblMessage, objItemMaster.DbOperationStatus);
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdItemMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		try
		{
			grdItemMaster.PageIndex = e.NewPageIndex;
			InitializeForm();
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected ItemMaster BindItemMasterGrid(RecordStatus objRecordStatus)
	{
		objItemMasterBL = new ItemMasterBL();
		objItemMaster = new ItemMaster();
		objItemMaster.RecordStatus = Convert.ToInt16(objRecordStatus);

		objItemMaster = objItemMasterBL.SelectItemMaster(objItemMaster);
		if (objItemMaster.DbOperationStatus == CommonConstant.SUCCEED)
		{
			grdItemMaster.DataSource = objItemMaster.ObjectDataSet.Tables[0];
			grdItemMaster.DataBind();
		}
		return objItemMaster;
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
				objItemMaster = GetObjectForInsertUpdate();
				objItemMasterBL = new ItemMasterBL();
				if (objItemMaster.ItemId == null)
				{
					objItemMaster = objItemMasterBL.InsertItemMaster(objItemMaster);
				}
				else
				{
					objItemMaster = objItemMasterBL.UpdateItemMaster(objItemMaster);
				}
				if (objItemMaster.DbOperationStatus == CommonConstant.SUCCEED
							|| objItemMaster.DbOperationStatus == CommonConstant.INVALID)
				{
					InitializeForm();
					MultiViewItemMaster.ActiveViewIndex = 0;
				}
				UIUtility.DisplayMessage(lblMessage, objItemMaster.DbOperationStatus);
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
			MultiViewItemMaster.ActiveViewIndex = 0;
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
	protected void BindItemMasterControls()
	{
		if (!Convert.ToBoolean(ViewState[isControlsLoaded]))
		{
			objClassSubjectMappingBL = new ClassSubjectMappingBL();
			objClassSubjectMapping = new ClassSubjectMapping();
			objClassSubjectMapping.RecordStatus = Convert.ToInt16(RecordStatus.Active);
			objClassSubjectMapping = objClassSubjectMappingBL.SelectClassSubjectMapping(objClassSubjectMapping);
			ddlClass.DataSource = objClassSubjectMapping.ObjectDataSet.Tables[0];
			ddlClass.DataBind();
			ddlClass.Items.Insert(0, UIUtility.DEFAULT_DDL_VALUE);

			objMetadataMasterBL = new MetadataMasterBL();
			objMetadataMaster = new MetadataMaster();
			objMetadataMaster.RecordStatus = Convert.ToInt16(RecordStatus.Active);
			objMetadataMaster = objMetadataMasterBL.SelectMetadataMaster(objMetadataMaster);
			ddlMedium.DataSource = objMetadataMaster.ObjectDataSet.Tables[0];
			ddlMedium.DataBind();
			ddlMedium.Items.Insert(0, UIUtility.DEFAULT_DDL_VALUE);

			objRackMasterBL = new RackMasterBL();
			objRackMaster = new RackMaster();
			objRackMaster.RecordStatus = Convert.ToInt16(RecordStatus.Active);
			objRackMaster = objRackMasterBL.SelectRackMaster(objRackMaster);
			ddlRack.DataSource = objRackMaster.ObjectDataSet.Tables[0];
			ddlRack.DataBind();
			ddlRack.Items.Insert(0, UIUtility.DEFAULT_DDL_VALUE);

			objItemTypeBL = new ItemTypeBL();
			objItemType = new ItemType();
			objItemType.RecordStatus = Convert.ToInt16(RecordStatus.Active);
			objItemType = objItemTypeBL.SelectItemType(objItemType);
			ddlItem.DataSource = objItemType.ObjectDataSet.Tables[0];
			ddlItem.DataBind();
			ddlItem.Items.Insert(0, UIUtility.DEFAULT_DDL_VALUE);

			ViewState[isControlsLoaded] = true;
		}
	}
	protected void ActivateControlsView(bool isNewRecord, ItemMaster objItemMaster,int? editIndex)
	{
		if (isNewRecord)
		{
			ViewState[editIndexKey] = null;
			BindItemMasterControls();
			UIUtility.InitializeControls(ViewItemMasterControls);
		}
		else
		{
			ViewState[editIndexKey] = editIndex;
			BindItemMasterControls();
			PopulateControlsData(objItemMaster);
		}
		MultiViewItemMaster.ActiveViewIndex = 1;
	}
	private void PopulateControlsData(ItemMaster objItemMaster)
	{
		txtItemCode.Text = objItemMaster.ItemCode;
		txtBarCode.Text = objItemMaster.BarCode;
		UIUtility.SelectCurrentListItem(ddlClass, objItemMaster.ClassSubjectObject.ClassSubjectMappingId, BindListItem.ByValue, true);
		txtWriterName.Text = objItemMaster.WriterName;
		txtPublisherName.Text = objItemMaster.PublisherName;
		UIUtility.SelectCurrentListItem(ddlMedium, objItemMaster.MediumObject.MetadataId, BindListItem.ByValue, true);
		txtEdition.Text = objItemMaster.Edition;
		txtPublishDate.Text = objItemMaster.PublishDate.ToString();
		txtVolume.Text = objItemMaster.Volume;
		UIUtility.SelectCurrentListItem(ddlRack, objItemMaster.RackObject.RackId, BindListItem.ByValue, true);
		txtCellId.Text = objItemMaster.CellId;
		UIUtility.SelectCurrentListItem(ddlItem, objItemMaster.ItemTypeObject.ItemTypeId, BindListItem.ByValue, true);
	}
	#endregion

	#region Helper Functions
	private bool ValidateObject()
	{
		return true;
	}
	private ItemMaster GetObjectForInsertUpdate()
	{
		objItemMaster = new ItemMaster();

		if (ViewState[editIndexKey] == null)
		{
			objItemMaster.Version = BusinessUtility.RECORD_VERSION;
			objItemMaster.CreatedBy = LoggedInUser;
			objItemMaster.CreatedOn = GeneralUtility.CurrentDateTime;
		}
		else
		{
			objItemMaster.ItemId = Convert.ToInt32(grdItemMaster.DataKeys[Convert.ToInt32(ViewState[editIndexKey])].Values[ITEM_ID_INDEX].ToString());
			objItemMaster.Version = Convert.ToInt16(grdItemMaster.DataKeys[Convert.ToInt16(ViewState[editIndexKey])].Values[VERSION_INDEX].ToString()) + 1;
		}

		objItemMaster.ItemCode = txtItemCode.Text;
		objItemMaster.BarCode = txtBarCode.Text;
		if (ddlClass.SelectedIndex != 0)
		{
			objItemMaster.ClassSubjectObject = new ClassSubjectMapping();
			objItemMaster.ClassSubjectObject.ClassSubjectMappingId = Convert.ToInt32(ddlClass.SelectedItem.Value);
		}
		objItemMaster.WriterName = txtWriterName.Text;
		objItemMaster.PublisherName = txtPublisherName.Text;
		if (ddlMedium.SelectedIndex != 0)
		{
			objItemMaster.MediumObject = new MetadataMaster();
			objItemMaster.MediumObject.MetadataId = Convert.ToInt32(ddlMedium.SelectedItem.Value);
		}
		objItemMaster.Edition = txtEdition.Text;
		objItemMaster.PublishDate = Convert.ToDateTime(txtPublishDate.Text);
		objItemMaster.Volume = txtVolume.Text;
		if (ddlRack.SelectedIndex != 0)
		{
			objItemMaster.RackObject = new RackMaster();
			objItemMaster.RackObject.RackId = Convert.ToInt32(ddlRack.SelectedItem.Value);
		}
		objItemMaster.CellId = txtCellId.Text;
		if (ddlItem.SelectedIndex != 0)
		{
			objItemMaster.ItemTypeObject = new ItemType();
			objItemMaster.ItemTypeObject.ItemTypeId = Convert.ToInt32(ddlItem.SelectedItem.Value);
		}
		objItemMaster.ModifiedBy = LoggedInUser;
		objItemMaster.ModifiedOn = GeneralUtility.CurrentDateTime;
		objItemMaster.RecordStatus = Convert.ToInt16(RecordStatus.Active);
		return objItemMaster;
	}
	private ItemMaster GetObjectForActivateDeactivate(int editIndex,RecordStatus objStatus)
	{
		objItemMaster = new ItemMaster();
		objItemMaster.ItemId = Convert.ToInt32(grdItemMaster.DataKeys[editIndex].Values[ITEM_ID_INDEX].ToString());
		objItemMaster.Version = Convert.ToInt16(grdItemMaster.DataKeys[editIndex].Values[VERSION_INDEX].ToString()) + 1;
		objItemMaster.ModifiedBy = LoggedInUser;
		objItemMaster.RecordStatus = Convert.ToInt16(objStatus);
		return objItemMaster;
	}
	private ItemMaster SelectRecordById(int editIndex)
	{
		objItemMasterBL = new ItemMasterBL();
		objItemMaster = new ItemMaster();
		objItemMaster.ItemId = Convert.ToInt32(grdItemMaster.DataKeys[editIndex].Values[ITEM_ID_INDEX].ToString());
		objItemMaster.Version = Convert.ToInt16(grdItemMaster.DataKeys[editIndex].Values[VERSION_INDEX].ToString());
		objItemMaster = objItemMasterBL.SelectRecordById(objItemMaster);
		return objItemMaster;
	}
	#endregion
}
