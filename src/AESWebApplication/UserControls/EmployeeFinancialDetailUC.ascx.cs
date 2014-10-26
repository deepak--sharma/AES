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

public partial class EmployeeFinancialDetailUC : System.Web.UI.UserControl
{
    #region Page Variables
    EmployeeFinancialDetail objEmployeeFinancialDetail = null;
    MetadataMaster objMetadataMaster = null;
    MetadataMasterBL objMetadataMasterBL = null;
    BankMaster objBankMaster = null;
    BankMasterBL objBankMasterBL = null;

    #endregion

    #region Page Events and Functions
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    #endregion

    #region Helper Functions
    public bool ValidateObject()
    {
        return true;
    }
    public void BindUCControls()
    {
        UIController.BindMetadataDDL(ddlAccount, MetadataTypeEnum.AccountType);
        UIController.BindMetadataDDL(ddlPaymentMode, MetadataTypeEnum.PaymentMode);
        objBankMasterBL = new BankMasterBL();
        objBankMaster = new BankMaster();
        objBankMaster.RecordStatus = Convert.ToInt16(RecordStatus.Active);
        objBankMaster = objBankMasterBL.SelectBankMaster(objBankMaster);
        ddlBank.DataSource = objBankMaster.ObjectDataSet.Tables[0];
        ddlBank.DataBind();
        ddlBank.Items.Insert(0, UIUtility.DEFAULT_DDL_VALUE);

    }
    public EmployeeFinancialDetail GetUserControlData()
    {
        objEmployeeFinancialDetail = new EmployeeFinancialDetail();
        if (!string.IsNullOrEmpty(hfEmployeeFinancialDetailId.Value))
        { objEmployeeFinancialDetail.EmployeeFinancialDetailId = Convert.ToInt32(hfEmployeeFinancialDetailId.Value); }
        objEmployeeFinancialDetail.PanCardNo = txtPanCardNo.Text;
        objEmployeeFinancialDetail.PfNo = txtPfNo.Text;
        objEmployeeFinancialDetail.EsiNo = txtEsiNo.Text;
        objEmployeeFinancialDetail.IsPanApproved = Convert.ToBoolean(ddlIsPanApproved.SelectedItem.Value);
        objEmployeeFinancialDetail.AccountNo = txtAccountNo.Text;
        if (ddlAccount.SelectedIndex != 0)
        {
            objEmployeeFinancialDetail.AccountTypeObject = new MetadataMaster();
            objEmployeeFinancialDetail.AccountTypeObject.MetadataId = Convert.ToInt32(ddlAccount.SelectedItem.Value);
        }
        objEmployeeFinancialDetail.VpfPercent = Convert.ToDecimal(txtVpfPercent.Text);
        objEmployeeFinancialDetail.VpfAmount = Convert.ToDecimal(txtVpfAmount.Text);
        objEmployeeFinancialDetail.IsConsentForEcs = Convert.ToBoolean(ddlIsConsentForEcs.SelectedItem.Value);
        objEmployeeFinancialDetail.IsVpfEligible = Convert.ToBoolean(ddlIsVpfEligible.SelectedItem.Value);
        objEmployeeFinancialDetail.IsPfDeducted = Convert.ToBoolean(ddlIsPfDeducted.SelectedItem.Value);
        objEmployeeFinancialDetail.LedgerId = Convert.ToInt32(txtLedgerId.Text);
        objEmployeeFinancialDetail.IsSalaryHold = Convert.ToBoolean(ddlIsSalaryHold.SelectedItem.Value);
        if (ddlPaymentMode.SelectedIndex != 0)
        {
            objEmployeeFinancialDetail.PaymentModeObject = new MetadataMaster();
            objEmployeeFinancialDetail.PaymentModeObject.MetadataId = Convert.ToInt32(ddlPaymentMode.SelectedItem.Value);
        }
        if (ddlBank.SelectedIndex != 0)
        {
            objEmployeeFinancialDetail.BankObject = new BankMaster();
            objEmployeeFinancialDetail.BankObject.BankId = Convert.ToInt32(ddlBank.SelectedItem.Value);
        }
        return objEmployeeFinancialDetail;
    }
    public void SetUserControlData(EmployeeFinancialDetail _objEmployeeFinancialDetail)
    {
        hfEmployeeFinancialDetailId.Value = _objEmployeeFinancialDetail.EmployeeFinancialDetailId.ToString();
        txtPanCardNo.Text = _objEmployeeFinancialDetail.PanCardNo;
        txtPfNo.Text = _objEmployeeFinancialDetail.PfNo;
        txtEsiNo.Text = _objEmployeeFinancialDetail.EsiNo;
        UIUtility.SelectCurrentListItem(ddlIsPanApproved, _objEmployeeFinancialDetail.IsPanApproved, BindListItem.ByValue, true);
        txtAccountNo.Text = _objEmployeeFinancialDetail.AccountNo;
        UIUtility.SelectCurrentListItem(ddlAccount, _objEmployeeFinancialDetail.AccountTypeObject.MetadataId, BindListItem.ByValue, true);
        txtVpfPercent.Text = _objEmployeeFinancialDetail.VpfPercent.ToString();
        txtVpfAmount.Text = _objEmployeeFinancialDetail.VpfAmount.ToString();
        UIUtility.SelectCurrentListItem(ddlIsConsentForEcs, _objEmployeeFinancialDetail.IsConsentForEcs, BindListItem.ByValue, true);
        UIUtility.SelectCurrentListItem(ddlIsVpfEligible, _objEmployeeFinancialDetail.IsVpfEligible, BindListItem.ByValue, true);
        UIUtility.SelectCurrentListItem(ddlIsPfDeducted, _objEmployeeFinancialDetail.IsPfDeducted, BindListItem.ByValue, true);
        txtLedgerId.Text = _objEmployeeFinancialDetail.LedgerId.ToString();
        UIUtility.SelectCurrentListItem(ddlIsSalaryHold, _objEmployeeFinancialDetail.IsSalaryHold, BindListItem.ByValue, true);
        UIUtility.SelectCurrentListItem(ddlPaymentMode, _objEmployeeFinancialDetail.PaymentModeObject.MetadataId, BindListItem.ByValue, true);
        UIUtility.SelectCurrentListItem(ddlBank, _objEmployeeFinancialDetail.BankObject.BankId, BindListItem.ByValue, true);
    }
    #endregion
}
