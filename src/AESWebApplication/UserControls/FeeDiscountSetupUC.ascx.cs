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

public partial class FeeDiscountSetupUC : System.Web.UI.UserControl
{
	#region Page Variables
	FeeDiscountSetup objFeeDiscountSetup = null;
	FeeDiscountSetupBL objFeeDiscountSetupBL = null;
	FeeMaster objFeeMaster = null;
	FeeMasterBL objFeeMasterBL = null;
	private string editIndexKey = "EditIndexFeeDiscountSetupKey";
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
			objFeeDiscountSetupBL = new FeeDiscountSetupBL();
			objFeeDiscountSetup = new FeeDiscountSetup();
			objFeeDiscountSetup.FeeStructureDetailObject = new FeeStructureDetail();
			objFeeDiscountSetup.FeeStructureDetailObject.FeeStructureDetailId = dataKey;

			objFeeDiscountSetup = objFeeDiscountSetupBL.SelectFeeDiscountSetup(objFeeDiscountSetup);
			grdFeeDiscountSetup.DataSource = objFeeDiscountSetup.ObjectDataSet.Tables[0];
			grdFeeDiscountSetup.DataBind();

			Session[hfSessionDataKey.Value] = objFeeDiscountSetup.ObjectDataSet.Tables[0];
			MultiViewFeeDiscountSetup.ActiveViewIndex = 0;

			if (grdFeeDiscountSetup.Rows.Count == 0)
			{
				hfEditIndexKey.Value = string.Empty;
				BindFeeDiscountSetupControls();
				UIUtility.InitializeControls(ViewFeeDiscountSetupControls);
				MultiViewFeeDiscountSetup.ActiveViewIndex = 1;
			}
		}
		else
		{
			grdFeeDiscountSetup.DataSource = (DataTable)Session[hfSessionDataKey.Value];
			grdFeeDiscountSetup.DataBind();
		}
	}
	#endregion

	#region Grid Events and Functions

	protected void grdFeeDiscountSetup_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			ActivateControlsView(false, grdFeeDiscountSetup.SelectedIndex);
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
			DataTable _objTable =(DataTable) Session[hfSessionDataKey.Value];
			_objTable.Rows.RemoveAt(e.RowIndex);
			InitializeUserControl(null,string.Empty);
			UIUtility.DisplayMessage(lblMessage, CommonConstant.SUCCEED);
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
				objFeeDiscountSetup = GetFeeDiscountSetupForDataTable();
				if (string.IsNullOrEmpty(hfEditIndexKey.Value))
				{
					objFeeDiscountSetup.AddObjectToTable((DataTable)Session[hfSessionDataKey.Value]);
				}
				else
				{
					int _rowIndex = Convert.ToInt32(hfEditIndexKey.Value);
					objFeeDiscountSetup.UpdateTableFromObject((DataTable)Session[hfSessionDataKey.Value], _rowIndex);
				}

				UIUtility.DisplayMessage(lblMessage, CommonConstant.SUCCEED);
				InitializeUserControl(null,null);
				MultiViewFeeDiscountSetup.ActiveViewIndex = 0;
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
			MultiViewFeeDiscountSetup.ActiveViewIndex = 0;
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void BindFeeDiscountSetupControls()
	{
		if (!Convert.ToBoolean(hfIsControlsLoaded.Value))
		{
			objFeeMasterBL = new FeeMasterBL();
			objFeeMaster = new FeeMaster();
			objFeeMaster.RecordStatus = Convert.ToInt16(RecordStatus.Active);
			objFeeMaster = objFeeMasterBL.SelectFeeMaster(objFeeMaster);
			ddlDiscount.DataSource = objFeeMaster.ObjectDataSet.Tables[0];
			ddlDiscount.DataBind();
			ddlDiscount.Items.Insert(0, UIUtility.DEFAULT_DDL_VALUE);

			hfIsControlsLoaded.Value = true.ToString();
		}
	}
	protected void ActivateControlsView(bool isNewRecord, int? editFeeDiscountSetupIndex)
	{
		if (isNewRecord)
		{
			hfEditIndexKey.Value=string.Empty;
			BindFeeDiscountSetupControls();
			UIUtility.InitializeControls(ViewFeeDiscountSetupControls);
		}
		else
		{
			int _rowIndex = Convert.ToInt32(editFeeDiscountSetupIndex);
			hfEditIndexKey.Value = _rowIndex.ToString();
			BindFeeDiscountSetupControls();
			PopulateControlsData(_rowIndex);
		}
		MultiViewFeeDiscountSetup.ActiveViewIndex = 1;
	}
	private void PopulateControlsData(int rowIndex)
	{
		objFeeDiscountSetup = new FeeDiscountSetup();
		objFeeDiscountSetup.ConvertToObjectFromDataRow((DataTable)Session[hfSessionDataKey.Value], rowIndex);
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

	private FeeDiscountSetup GetFeeDiscountSetupForDataTable()
	{
		objFeeDiscountSetup = new FeeDiscountSetup();
		if (ddlDiscount.SelectedIndex != 0)
		{
			objFeeDiscountSetup.DiscountTypeObject = new FeeMaster();
			objFeeDiscountSetup.DiscountTypeObject.FeeId = Convert.ToInt32(ddlDiscount.SelectedItem.Value);
		}
		objFeeDiscountSetup.DiscountTypeValue = Convert.ToDateTime(txtDiscountTypeValue.Text);
		objFeeDiscountSetup.DiscountAmount = Convert.ToDecimal(txtDiscountAmount.Text);
		objFeeDiscountSetup.IsPercent = Convert.ToBoolean(ddlIsPercent.SelectedItem.Value);
		objFeeDiscountSetup.EffectiveDate = Convert.ToDateTime(txtEffectiveDate.Text);
		return objFeeDiscountSetup;
	}
	#endregion
}
