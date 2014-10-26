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

public partial class EmployeePreviousOrganisationDetailUC : System.Web.UI.UserControl
{
	#region Page Variables
	EmployeePreviousOrganisationDetail objEmployeePreviousOrganisationDetail = null;
	EmployeePreviousOrganisationDetailBL objEmployeePreviousOrganisationDetailBL = null;
	MetadataMaster objMetadataMaster = null;
	MetadataMasterBL objMetadataMasterBL = null;
	AddressDetail objAddressDetail = null;
	AddressDetailBL objAddressDetailBL = null;
	private string editIndexKey = "EditIndexEmployeePreviousOrganisationDetailKey";
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
			objEmployeePreviousOrganisationDetailBL = new EmployeePreviousOrganisationDetailBL();
			objEmployeePreviousOrganisationDetail = new EmployeePreviousOrganisationDetail();
			objEmployeePreviousOrganisationDetail.EmployeeObject = new EmployeeDetail();
			objEmployeePreviousOrganisationDetail.EmployeeObject.EmployeeId = dataKey;
            objEmployeePreviousOrganisationDetail.CurrencyObject = new MetadataMaster();
            objEmployeePreviousOrganisationDetail.CurrencyObject.DataHolder = Convert.ToInt32(MetadataTypeEnum.Currency).ToString();

			objEmployeePreviousOrganisationDetail = objEmployeePreviousOrganisationDetailBL.SelectEmployeePreviousOrganisationDetail(objEmployeePreviousOrganisationDetail);
			grdEmployeePreviousOrganisationDetail.DataSource = objEmployeePreviousOrganisationDetail.ObjectDataSet.Tables[0];
			grdEmployeePreviousOrganisationDetail.DataBind();

			Session[hfSessionDataKey.Value] = objEmployeePreviousOrganisationDetail.ObjectDataSet.Tables[0];
			MultiViewEmployeePreviousOrganisationDetail.ActiveViewIndex = 0;

			if (grdEmployeePreviousOrganisationDetail.Rows.Count == 0)
			{
				hfEditIndexKey.Value = string.Empty;
				BindEmployeePreviousOrganisationDetailControls();
				UIUtility.InitializeControls(ViewEmployeePreviousOrganisationDetailControls);
				MultiViewEmployeePreviousOrganisationDetail.ActiveViewIndex = 1;
			}
		}
		else
		{
			grdEmployeePreviousOrganisationDetail.DataSource = (DataTable)Session[hfSessionDataKey.Value];
			grdEmployeePreviousOrganisationDetail.DataBind();
		}
	}
	#endregion

	#region Grid Events and Functions

	protected void grdEmployeePreviousOrganisationDetail_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			ActivateControlsView(false, grdEmployeePreviousOrganisationDetail.SelectedIndex);
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void grdEmployeePreviousOrganisationDetail_RowDeleting(object sender, GridViewDeleteEventArgs e)
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
	protected void grdEmployeePreviousOrganisationDetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		try
		{
			grdEmployeePreviousOrganisationDetail.PageIndex = e.NewPageIndex;
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
				objEmployeePreviousOrganisationDetail = GetEmployeePreviousOrganisationDetailForDataTable();
				if (string.IsNullOrEmpty(hfEditIndexKey.Value))
				{
                    int _rowIndex = grdEmployeePreviousOrganisationDetail.Rows.Count;
					objEmployeePreviousOrganisationDetail.AddObjectToTable((DataTable)Session[hfSessionDataKey.Value]);
                    ((DataTable)Session[hfSessionDataKey.Value]).Rows[_rowIndex]["CURRENCY"] = ddlCurrency.SelectedItem.Text;
				}
				else
				{
					int _rowIndex = Convert.ToInt32(hfEditIndexKey.Value);
					objEmployeePreviousOrganisationDetail.UpdateTableFromObject((DataTable)Session[hfSessionDataKey.Value], _rowIndex);
                    ((DataTable)Session[hfSessionDataKey.Value]).Rows[_rowIndex]["CURRENCY"] = ddlCurrency.SelectedItem.Text;
				}

				UIUtility.DisplayMessage(lblMessage, CommonConstant.SUCCEED);
				InitializeUserControl(null,null);
				MultiViewEmployeePreviousOrganisationDetail.ActiveViewIndex = 0;
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
			MultiViewEmployeePreviousOrganisationDetail.ActiveViewIndex = 0;
		}
		catch (Exception ex)
		{
			lblMessage.Text = ex.Message;
		}
	}
	protected void BindEmployeePreviousOrganisationDetailControls()
	{
        if (string.IsNullOrEmpty(hfIsControlsLoaded.Value) || !Convert.ToBoolean(hfIsControlsLoaded.Value))
		{
            UIController.BindMetadataDDL(ddlCurrency, MetadataTypeEnum.Currency);

			hfIsControlsLoaded.Value = true.ToString();
		}
	}
	protected void ActivateControlsView(bool isNewRecord, int? editEmployeePreviousOrganisationDetailIndex)
	{
		if (isNewRecord)
		{
			hfEditIndexKey.Value=string.Empty;
			BindEmployeePreviousOrganisationDetailControls();
			UIUtility.InitializeControls(ViewEmployeePreviousOrganisationDetailControls);
		}
		else
		{
			int _rowIndex = Convert.ToInt32(editEmployeePreviousOrganisationDetailIndex);
			hfEditIndexKey.Value = _rowIndex.ToString();
			BindEmployeePreviousOrganisationDetailControls();
			PopulateControlsData(_rowIndex);
		}
		MultiViewEmployeePreviousOrganisationDetail.ActiveViewIndex = 1;
	}
	private void PopulateControlsData(int rowIndex)
	{
		objEmployeePreviousOrganisationDetail = new EmployeePreviousOrganisationDetail();
		objEmployeePreviousOrganisationDetail.ConvertToObjectFromDataRow((DataTable)Session[hfSessionDataKey.Value], rowIndex);
		txtOrganisationName.Text = objEmployeePreviousOrganisationDetail.OrganisationName;
		txtPeriodFrom.Text = objEmployeePreviousOrganisationDetail.PeriodFrom.ToString();
		txtPeriodTo.Text = objEmployeePreviousOrganisationDetail.PeriodTo.ToString();
		txtCtc.Text = objEmployeePreviousOrganisationDetail.Ctc.ToString();
		UIUtility.SelectCurrentListItem(ddlCurrency, objEmployeePreviousOrganisationDetail.CurrencyObject.MetadataId, BindListItem.ByValue, true);
		txtEntryDesignation.Text = objEmployeePreviousOrganisationDetail.EntryDesignation;
		txtExitDesignation.Text = objEmployeePreviousOrganisationDetail.ExitDesignation;
		txtSupervisorName.Text = objEmployeePreviousOrganisationDetail.SupervisorName;
		txtSupervisorContact.Text = objEmployeePreviousOrganisationDetail.SupervisorContact;
		txtSupervisorDesignation.Text = objEmployeePreviousOrganisationDetail.SupervisorDesignation;
		txtDepartment.Text = objEmployeePreviousOrganisationDetail.Department;
		txtNatureOfWork.Text = objEmployeePreviousOrganisationDetail.NatureOfWork;
        txtOrganisation.Text = objEmployeePreviousOrganisationDetail.OrganisationAddress;
		txtWebAddress.Text = objEmployeePreviousOrganisationDetail.WebAddress;
		txtReasonForLeaving.Text = objEmployeePreviousOrganisationDetail.ReasonForLeaving;
		txtRecentOrder.Text = objEmployeePreviousOrganisationDetail.RecentOrder.ToString();
	}
	#endregion

	#region Helper Functions
	private bool ValidateObject()
	{
		return true;
	}

	private EmployeePreviousOrganisationDetail GetEmployeePreviousOrganisationDetailForDataTable()
	{
		objEmployeePreviousOrganisationDetail = new EmployeePreviousOrganisationDetail();
		objEmployeePreviousOrganisationDetail.OrganisationName = txtOrganisationName.Text;
		objEmployeePreviousOrganisationDetail.PeriodFrom = Convert.ToDateTime(txtPeriodFrom.Text);
		objEmployeePreviousOrganisationDetail.PeriodTo = Convert.ToDateTime(txtPeriodTo.Text);
		objEmployeePreviousOrganisationDetail.Ctc = Convert.ToDecimal(txtCtc.Text);
		if (ddlCurrency.SelectedIndex != 0)
		{
			objEmployeePreviousOrganisationDetail.CurrencyObject = new MetadataMaster();
			objEmployeePreviousOrganisationDetail.CurrencyObject.MetadataId = Convert.ToInt32(ddlCurrency.SelectedItem.Value);
		}
		objEmployeePreviousOrganisationDetail.EntryDesignation = txtEntryDesignation.Text;
		objEmployeePreviousOrganisationDetail.ExitDesignation = txtExitDesignation.Text;
		objEmployeePreviousOrganisationDetail.SupervisorName = txtSupervisorName.Text;
		objEmployeePreviousOrganisationDetail.SupervisorContact = txtSupervisorContact.Text;
		objEmployeePreviousOrganisationDetail.SupervisorDesignation = txtSupervisorDesignation.Text;
		objEmployeePreviousOrganisationDetail.Department = txtDepartment.Text;
		objEmployeePreviousOrganisationDetail.NatureOfWork = txtNatureOfWork.Text;
        objEmployeePreviousOrganisationDetail.OrganisationAddress = txtOrganisation.Text;		
		objEmployeePreviousOrganisationDetail.WebAddress = txtWebAddress.Text;
		objEmployeePreviousOrganisationDetail.ReasonForLeaving = txtReasonForLeaving.Text;
		objEmployeePreviousOrganisationDetail.RecentOrder = Convert.ToInt32(txtRecentOrder.Text);
		return objEmployeePreviousOrganisationDetail;
	}
	#endregion
}
