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

public partial class EmployeeAdministrativeDetailUC : System.Web.UI.UserControl
{
    #region Page Variables
    EmployeeAdministrativeDetail objEmployeeAdministrativeDetail = null;
    BranchMaster objBranchMaster = null;
    BranchMasterBL objBranchMasterBL = null;
    DepartmentMaster objDepartmentMaster = null;
    DepartmentMasterBL objDepartmentMasterBL = null;
    DivisionMaster objDivisionMaster = null;
    DivisionMasterBL objDivisionMasterBL = null;
    SectionMaster objSectionMaster = null;
    SectionMasterBL objSectionMasterBL = null;
    DesignationMaster objDesignationMaster = null;
    DesignationMasterBL objDesignationMasterBL = null;
    GradeMaster objGradeMaster = null;
    GradeMasterBL objGradeMasterBL = null;
    MetadataMaster objMetadataMaster = null;
    MetadataMasterBL objMetadataMasterBL = null;

    #endregion

    #region Helper Functions
    public bool ValidateObject()
    {
        return true;
    }
    public void BindUCControls()
    {
        objBranchMasterBL = new BranchMasterBL();
        objBranchMaster = new BranchMaster();
        objBranchMaster.RecordStatus = Convert.ToInt16(RecordStatus.Active);
        objBranchMaster = objBranchMasterBL.SelectBranchMaster(objBranchMaster);
        ddlBranch.DataSource = objBranchMaster.ObjectDataSet.Tables[0];
        ddlBranch.DataBind();
        ddlBranch.Items.Insert(0, UIUtility.DEFAULT_DDL_VALUE);

        objDepartmentMasterBL = new DepartmentMasterBL();
        objDepartmentMaster = new DepartmentMaster();
        objDepartmentMaster.RecordStatus = Convert.ToInt16(RecordStatus.Active);
        objDepartmentMaster = objDepartmentMasterBL.SelectDepartmentMaster(objDepartmentMaster);
        ddlDepartment.DataSource = objDepartmentMaster.ObjectDataSet.Tables[0];
        ddlDepartment.DataBind();
        ddlDepartment.Items.Insert(0, UIUtility.DEFAULT_DDL_VALUE);

        objDivisionMasterBL = new DivisionMasterBL();
        objDivisionMaster = new DivisionMaster();
        objDivisionMaster.RecordStatus = Convert.ToInt16(RecordStatus.Active);
        objDivisionMaster = objDivisionMasterBL.SelectDivisionMaster(objDivisionMaster);
        ddlDivision.DataSource = objDivisionMaster.ObjectDataSet.Tables[0];
        ddlDivision.DataBind();
        ddlDivision.Items.Insert(0, UIUtility.DEFAULT_DDL_VALUE);     

        objDesignationMasterBL = new DesignationMasterBL();
        objDesignationMaster = new DesignationMaster();
        objDesignationMaster.RecordStatus = Convert.ToInt16(RecordStatus.Active);
        objDesignationMaster = objDesignationMasterBL.SelectDesignationMaster(objDesignationMaster);
        ddlDesignation.DataSource = objDesignationMaster.ObjectDataSet.Tables[0];
        ddlDesignation.DataBind();
        ddlDesignation.Items.Insert(0, UIUtility.DEFAULT_DDL_VALUE);

        objGradeMasterBL = new GradeMasterBL();
        objGradeMaster = new GradeMaster();
        objGradeMaster.RecordStatus = Convert.ToInt16(RecordStatus.Active);
        objGradeMaster = objGradeMasterBL.SelectGradeMaster(objGradeMaster);
        ddlGrade.DataSource = objGradeMaster.ObjectDataSet.Tables[0];
        ddlGrade.DataBind();
        ddlGrade.Items.Insert(0, UIUtility.DEFAULT_DDL_VALUE);

        UIController.BindMetadataDDL(ddlEmployee, MetadataTypeEnum.EmployeeType);

    }
    public EmployeeAdministrativeDetail GetUserControlData()
    {
        objEmployeeAdministrativeDetail = new EmployeeAdministrativeDetail();
        if (!string.IsNullOrEmpty(hfEmployeeAdministrativeDetailId.Value))
        { objEmployeeAdministrativeDetail.EmployeeAdministrativeDetailId = Convert.ToInt32(hfEmployeeAdministrativeDetailId.Value); }
        if (ddlBranch.SelectedIndex != 0)
        {
            objEmployeeAdministrativeDetail.BranchObject = new BranchMaster();
            objEmployeeAdministrativeDetail.BranchObject.BranchId = Convert.ToInt32(ddlBranch.SelectedItem.Value);
        }
        if (ddlDepartment.SelectedIndex != 0)
        {
            objEmployeeAdministrativeDetail.DepartmentObject = new DepartmentMaster();
            objEmployeeAdministrativeDetail.DepartmentObject.DepartmentId = Convert.ToInt32(ddlDepartment.SelectedItem.Value);
        }
        if (ddlDivision.SelectedIndex != 0)
        {
            objEmployeeAdministrativeDetail.DivisionObject = new DivisionMaster();
            objEmployeeAdministrativeDetail.DivisionObject.DivisionId = Convert.ToInt32(ddlDivision.SelectedItem.Value);
        }      
        if (ddlDesignation.SelectedIndex != 0)
        {
            objEmployeeAdministrativeDetail.DesignationObject = new DesignationMaster();
            objEmployeeAdministrativeDetail.DesignationObject.DesignationId = Convert.ToInt32(ddlDesignation.SelectedItem.Value);
        }
        objEmployeeAdministrativeDetail.DateOfJoining = Convert.ToDateTime(txtDateOfJoining.Text);
        objEmployeeAdministrativeDetail.UserName = txtUserName.Text;
        if (ddlGrade.SelectedIndex != 0)
        {
            objEmployeeAdministrativeDetail.GradeObject = new GradeMaster();
            objEmployeeAdministrativeDetail.GradeObject.GradeId = Convert.ToInt32(ddlGrade.SelectedItem.Value);
        }
        objEmployeeAdministrativeDetail.ProbationUpto = Convert.ToDateTime(txtProbationUpto.Text);
        objEmployeeAdministrativeDetail.ConfirmationDate = Convert.ToDateTime(txtConfirmationDate.Text);
        objEmployeeAdministrativeDetail.IsSalaryStopped = Convert.ToBoolean(ddlIsSalaryStopped.SelectedItem.Value);
        objEmployeeAdministrativeDetail.TerminationDate = Convert.ToDateTime(txtTerminationDate.Text);
        objEmployeeAdministrativeDetail.ResignationDate = Convert.ToDateTime(txtResignationDate.Text);
        objEmployeeAdministrativeDetail.DiscontinueDate = Convert.ToDateTime(txtDiscontinueDate.Text);
        objEmployeeAdministrativeDetail.TotalExperience = Convert.ToDecimal(txtTotalExperience.Text);
        objEmployeeAdministrativeDetail.RelevantExperience = Convert.ToDecimal(txtRelevantExperience.Text);
        if (ddlEmployee.SelectedIndex != 0)
        {
            objEmployeeAdministrativeDetail.EmployeeTypeObject = new MetadataMaster();
            objEmployeeAdministrativeDetail.EmployeeTypeObject.MetadataId = Convert.ToInt32(ddlEmployee.SelectedItem.Value);
        }
        objEmployeeAdministrativeDetail.LwfNo = txtLwfNo.Text;
        return objEmployeeAdministrativeDetail;
    }
    public void SetUserControlData(EmployeeAdministrativeDetail _objEmployeeAdministrativeDetail)
    {
        hfEmployeeAdministrativeDetailId.Value = _objEmployeeAdministrativeDetail.EmployeeAdministrativeDetailId.ToString();
        UIUtility.SelectCurrentListItem(ddlBranch, _objEmployeeAdministrativeDetail.BranchObject.BranchId, BindListItem.ByValue, true);
        UIUtility.SelectCurrentListItem(ddlDepartment, _objEmployeeAdministrativeDetail.DepartmentObject.DepartmentId, BindListItem.ByValue, true);
        UIUtility.SelectCurrentListItem(ddlDivision, _objEmployeeAdministrativeDetail.DivisionObject.DivisionId, BindListItem.ByValue, true);
        UIUtility.SelectCurrentListItem(ddlDesignation, _objEmployeeAdministrativeDetail.DesignationObject.DesignationId, BindListItem.ByValue, true);
        txtDateOfJoining.Text = _objEmployeeAdministrativeDetail.DateOfJoining.ToString();
        txtUserName.Text = _objEmployeeAdministrativeDetail.UserName;
        UIUtility.SelectCurrentListItem(ddlGrade, _objEmployeeAdministrativeDetail.GradeObject.GradeId, BindListItem.ByValue, true);
        txtProbationUpto.Text = _objEmployeeAdministrativeDetail.ProbationUpto.ToString();
        txtConfirmationDate.Text = _objEmployeeAdministrativeDetail.ConfirmationDate.ToString();
        UIUtility.SelectCurrentListItem(ddlIsSalaryStopped, _objEmployeeAdministrativeDetail.IsSalaryStopped, BindListItem.ByValue, true);
        txtTerminationDate.Text = _objEmployeeAdministrativeDetail.TerminationDate.ToString();
        txtResignationDate.Text = _objEmployeeAdministrativeDetail.ResignationDate.ToString();
        txtDiscontinueDate.Text = _objEmployeeAdministrativeDetail.DiscontinueDate.ToString();
        txtTotalExperience.Text = _objEmployeeAdministrativeDetail.TotalExperience.ToString();
        txtRelevantExperience.Text = _objEmployeeAdministrativeDetail.RelevantExperience.ToString();
        UIUtility.SelectCurrentListItem(ddlEmployee, _objEmployeeAdministrativeDetail.EmployeeTypeObject.MetadataId, BindListItem.ByValue, true);
        txtLwfNo.Text = _objEmployeeAdministrativeDetail.LwfNo;
    }
    #endregion
}
