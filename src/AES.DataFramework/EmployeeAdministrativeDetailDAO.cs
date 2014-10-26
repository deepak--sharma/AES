using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using SolutionFramework.EventLogger;
using AES.SolutionFramework;
using AES.ObjectFramework;

namespace AES.DataFramework
{
	public class EmployeeAdministrativeDetailDAO
	{
		List<SqlParameter> objParameterList = null ;
		private string strDBTableName = "EMPLOYEE_ADMINISTRATIVE_DETAIL";
		private string strSelectEmployeeAdministrativeDetail = "UDSP_SELECT_EMPLOYEE_ADMINISTRATIVE_DETAIL";
        private string strInsertEmployeeAdministrativeDetail = "SP_INSERT_EMPLOYEE_ADMINISTRATIVE_DETAIL";
        private string strUpdateEmployeeAdministrativeDetail = "SP_UPDATE_EMPLOYEE_ADMINISTRATIVE_DETAIL";
		private string dbExecuteStatus = "";

		public EmployeeAdministrativeDetail SelectEmployeeAdministrativeDetail(EmployeeAdministrativeDetail objEmployeeAdministrativeDetail)
		{
			objParameterList = new List<SqlParameter>();
			UDSP_SELECT_EMPLOYEE_ADMINISTRATIVE_DETAIL.EMPLOYEE_ADMINISTRATIVE_DETAIL_ID_PARAM(objParameterList , objEmployeeAdministrativeDetail.EmployeeAdministrativeDetailId);
			if (objEmployeeAdministrativeDetail.BranchObject != null)
			{
				UDSP_SELECT_EMPLOYEE_ADMINISTRATIVE_DETAIL.BRANCH_ID_PARAM(objParameterList , objEmployeeAdministrativeDetail.BranchObject.BranchId);
			}
			if (objEmployeeAdministrativeDetail.DepartmentObject != null)
			{
				UDSP_SELECT_EMPLOYEE_ADMINISTRATIVE_DETAIL.DEPARTMENT_ID_PARAM(objParameterList , objEmployeeAdministrativeDetail.DepartmentObject.DepartmentId);
			}
			if (objEmployeeAdministrativeDetail.DivisionObject != null)
			{
				UDSP_SELECT_EMPLOYEE_ADMINISTRATIVE_DETAIL.DIVISION_ID_PARAM(objParameterList , objEmployeeAdministrativeDetail.DivisionObject.DivisionId);
			}			
			if (objEmployeeAdministrativeDetail.DesignationObject != null)
			{
				UDSP_SELECT_EMPLOYEE_ADMINISTRATIVE_DETAIL.DESIGNATION_ID_PARAM(objParameterList , objEmployeeAdministrativeDetail.DesignationObject.DesignationId);
			}
			UDSP_SELECT_EMPLOYEE_ADMINISTRATIVE_DETAIL.DATE_OF_JOINING_PARAM(objParameterList , objEmployeeAdministrativeDetail.DateOfJoining);
			UDSP_SELECT_EMPLOYEE_ADMINISTRATIVE_DETAIL.USER_NAME_PARAM(objParameterList , objEmployeeAdministrativeDetail.UserName);
			if (objEmployeeAdministrativeDetail.GradeObject != null)
			{
				UDSP_SELECT_EMPLOYEE_ADMINISTRATIVE_DETAIL.GRADE_ID_PARAM(objParameterList , objEmployeeAdministrativeDetail.GradeObject.GradeId);
			}
			UDSP_SELECT_EMPLOYEE_ADMINISTRATIVE_DETAIL.PROBATION_UPTO_PARAM(objParameterList , objEmployeeAdministrativeDetail.ProbationUpto);
			UDSP_SELECT_EMPLOYEE_ADMINISTRATIVE_DETAIL.CONFIRMATION_DATE_PARAM(objParameterList , objEmployeeAdministrativeDetail.ConfirmationDate);
			UDSP_SELECT_EMPLOYEE_ADMINISTRATIVE_DETAIL.IS_SALARY_STOPPED_PARAM(objParameterList , objEmployeeAdministrativeDetail.IsSalaryStopped);
			UDSP_SELECT_EMPLOYEE_ADMINISTRATIVE_DETAIL.TERMINATION_DATE_PARAM(objParameterList , objEmployeeAdministrativeDetail.TerminationDate);
			UDSP_SELECT_EMPLOYEE_ADMINISTRATIVE_DETAIL.RESIGNATION_DATE_PARAM(objParameterList , objEmployeeAdministrativeDetail.ResignationDate);
			UDSP_SELECT_EMPLOYEE_ADMINISTRATIVE_DETAIL.DISCONTINUE_DATE_PARAM(objParameterList , objEmployeeAdministrativeDetail.DiscontinueDate);
			UDSP_SELECT_EMPLOYEE_ADMINISTRATIVE_DETAIL.TOTAL_EXPERIENCE_PARAM(objParameterList , objEmployeeAdministrativeDetail.TotalExperience);
			UDSP_SELECT_EMPLOYEE_ADMINISTRATIVE_DETAIL.RELEVANT_EXPERIENCE_PARAM(objParameterList , objEmployeeAdministrativeDetail.RelevantExperience);
			if (objEmployeeAdministrativeDetail.EmployeeTypeObject != null)
			{
				UDSP_SELECT_EMPLOYEE_ADMINISTRATIVE_DETAIL.EMPLOYEE_TYPE_ID_PARAM(objParameterList , objEmployeeAdministrativeDetail.EmployeeTypeObject.MetadataId);
			}
			UDSP_SELECT_EMPLOYEE_ADMINISTRATIVE_DETAIL.LWF_NO_PARAM(objParameterList , objEmployeeAdministrativeDetail.LwfNo);
			try
			{
				Logger.LogInfo("EmployeeAdministrativeDetailDAO.cs : SelectEmployeeAdministrativeDetail() is started.");
				objEmployeeAdministrativeDetail.ObjectDataSet = DBMANAGER.GetDataSet(objParameterList,strSelectEmployeeAdministrativeDetail, CommandType.StoredProcedure);
				objEmployeeAdministrativeDetail.DbOperationStatus = CommonConstant.SUCCEED;
				Logger.LogInfo("EmployeeAdministrativeDetailDAO.cs : SelectEmployeeAdministrativeDetail() is ended with success.");
			}
			catch (Exception ex)
			{
				objEmployeeAdministrativeDetail.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("EmployeeAdministrativeDetailDAO.cs : SelectEmployeeAdministrativeDetail() is ended with error.");
			}
			return objEmployeeAdministrativeDetail;
		}

		public EmployeeAdministrativeDetail InsertEmployeeAdministrativeDetail(EmployeeAdministrativeDetail objEmployeeAdministrativeDetail)
		{
			objParameterList = new List<SqlParameter>();
				
			if (objEmployeeAdministrativeDetail.BranchObject != null)
			{
				UDSP_INSERT_EMPLOYEE_ADMINISTRATIVE_DETAIL.BRANCH_ID_PARAM(objParameterList , objEmployeeAdministrativeDetail.BranchObject.BranchId);
			}
			if (objEmployeeAdministrativeDetail.DepartmentObject != null)
			{
				UDSP_INSERT_EMPLOYEE_ADMINISTRATIVE_DETAIL.DEPARTMENT_ID_PARAM(objParameterList , objEmployeeAdministrativeDetail.DepartmentObject.DepartmentId);
			}
			if (objEmployeeAdministrativeDetail.DivisionObject != null)
			{
				UDSP_INSERT_EMPLOYEE_ADMINISTRATIVE_DETAIL.DIVISION_ID_PARAM(objParameterList , objEmployeeAdministrativeDetail.DivisionObject.DivisionId);
			}
			
			if (objEmployeeAdministrativeDetail.DesignationObject != null)
			{
				UDSP_INSERT_EMPLOYEE_ADMINISTRATIVE_DETAIL.DESIGNATION_ID_PARAM(objParameterList , objEmployeeAdministrativeDetail.DesignationObject.DesignationId);
			}
			UDSP_INSERT_EMPLOYEE_ADMINISTRATIVE_DETAIL.DATE_OF_JOINING_PARAM(objParameterList , objEmployeeAdministrativeDetail.DateOfJoining);
			UDSP_INSERT_EMPLOYEE_ADMINISTRATIVE_DETAIL.USER_NAME_PARAM(objParameterList , objEmployeeAdministrativeDetail.UserName);
			if (objEmployeeAdministrativeDetail.GradeObject != null)
			{
				UDSP_INSERT_EMPLOYEE_ADMINISTRATIVE_DETAIL.GRADE_ID_PARAM(objParameterList , objEmployeeAdministrativeDetail.GradeObject.GradeId);
			}
			UDSP_INSERT_EMPLOYEE_ADMINISTRATIVE_DETAIL.PROBATION_UPTO_PARAM(objParameterList , objEmployeeAdministrativeDetail.ProbationUpto);
			UDSP_INSERT_EMPLOYEE_ADMINISTRATIVE_DETAIL.CONFIRMATION_DATE_PARAM(objParameterList , objEmployeeAdministrativeDetail.ConfirmationDate);
			UDSP_INSERT_EMPLOYEE_ADMINISTRATIVE_DETAIL.IS_SALARY_STOPPED_PARAM(objParameterList , objEmployeeAdministrativeDetail.IsSalaryStopped);
			UDSP_INSERT_EMPLOYEE_ADMINISTRATIVE_DETAIL.TERMINATION_DATE_PARAM(objParameterList , objEmployeeAdministrativeDetail.TerminationDate);
			UDSP_INSERT_EMPLOYEE_ADMINISTRATIVE_DETAIL.RESIGNATION_DATE_PARAM(objParameterList , objEmployeeAdministrativeDetail.ResignationDate);
			UDSP_INSERT_EMPLOYEE_ADMINISTRATIVE_DETAIL.DISCONTINUE_DATE_PARAM(objParameterList , objEmployeeAdministrativeDetail.DiscontinueDate);
			UDSP_INSERT_EMPLOYEE_ADMINISTRATIVE_DETAIL.TOTAL_EXPERIENCE_PARAM(objParameterList , objEmployeeAdministrativeDetail.TotalExperience);
			UDSP_INSERT_EMPLOYEE_ADMINISTRATIVE_DETAIL.RELEVANT_EXPERIENCE_PARAM(objParameterList , objEmployeeAdministrativeDetail.RelevantExperience);
			if (objEmployeeAdministrativeDetail.EmployeeTypeObject != null)
			{
				UDSP_INSERT_EMPLOYEE_ADMINISTRATIVE_DETAIL.EMPLOYEE_TYPE_ID_PARAM(objParameterList , objEmployeeAdministrativeDetail.EmployeeTypeObject.MetadataId);
			}
			UDSP_INSERT_EMPLOYEE_ADMINISTRATIVE_DETAIL.LWF_NO_PARAM(objParameterList , objEmployeeAdministrativeDetail.LwfNo);
            NEWPARAMETERS.ADDPARAMETERS(objParameterList, "@MODIFIED_BY", objEmployeeAdministrativeDetail.ModifiedBy);
            NEWPARAMETERS.ADDPARAMETERS(objParameterList, "@PARENT_ID", objEmployeeAdministrativeDetail.ParentId);
            NEWPARAMETERS.ADDPARAMETERS(objParameterList, "@PARENT_VERSION", objEmployeeAdministrativeDetail.ParentVersion);

            try
			{
				Logger.LogInfo("EmployeeAdministrativeDetailDAO.cs : InsertEmployeeAdministrativeDetail() is started.");
				dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList,strInsertEmployeeAdministrativeDetail, CommandType.StoredProcedure).ToString();
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) > 0 )
					{
						objEmployeeAdministrativeDetail.EmployeeAdministrativeDetailId = Convert.ToInt32(dbExecuteStatus);
						objEmployeeAdministrativeDetail.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else
					{
						objEmployeeAdministrativeDetail.DbOperationStatus = CommonConstant.DUPLICATE;
					}
					Logger.LogInfo("EmployeeAdministrativeDetailDAO.cs : InsertEmployeeAdministrativeDetail() is ended with success.");
				}
				else
				{
					objEmployeeAdministrativeDetail.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("EmployeeAdministrativeDetailDAO.cs : InsertEmployeeAdministrativeDetail() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objEmployeeAdministrativeDetail.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("EmployeeAdministrativeDetailDAO.cs : InsertEmployeeAdministrativeDetail() is ended with error.");
			}
			return objEmployeeAdministrativeDetail;
		}

		public EmployeeAdministrativeDetail UpdateEmployeeAdministrativeDetail(EmployeeAdministrativeDetail objEmployeeAdministrativeDetail)
		{
			objParameterList = new List<SqlParameter>();
				
			UDSP_UPDATE_EMPLOYEE_ADMINISTRATIVE_DETAIL.EMPLOYEE_ADMINISTRATIVE_DETAIL_ID_PARAM(objParameterList , objEmployeeAdministrativeDetail.EmployeeAdministrativeDetailId);
			if (objEmployeeAdministrativeDetail.BranchObject != null)
			{
				UDSP_UPDATE_EMPLOYEE_ADMINISTRATIVE_DETAIL.BRANCH_ID_PARAM(objParameterList , objEmployeeAdministrativeDetail.BranchObject.BranchId);
			}
			if (objEmployeeAdministrativeDetail.DepartmentObject != null)
			{
				UDSP_UPDATE_EMPLOYEE_ADMINISTRATIVE_DETAIL.DEPARTMENT_ID_PARAM(objParameterList , objEmployeeAdministrativeDetail.DepartmentObject.DepartmentId);
			}
			if (objEmployeeAdministrativeDetail.DivisionObject != null)
			{
				UDSP_UPDATE_EMPLOYEE_ADMINISTRATIVE_DETAIL.DIVISION_ID_PARAM(objParameterList , objEmployeeAdministrativeDetail.DivisionObject.DivisionId);
			}
			
			if (objEmployeeAdministrativeDetail.DesignationObject != null)
			{
				UDSP_UPDATE_EMPLOYEE_ADMINISTRATIVE_DETAIL.DESIGNATION_ID_PARAM(objParameterList , objEmployeeAdministrativeDetail.DesignationObject.DesignationId);
			}
			UDSP_UPDATE_EMPLOYEE_ADMINISTRATIVE_DETAIL.DATE_OF_JOINING_PARAM(objParameterList , objEmployeeAdministrativeDetail.DateOfJoining);
			UDSP_UPDATE_EMPLOYEE_ADMINISTRATIVE_DETAIL.USER_NAME_PARAM(objParameterList , objEmployeeAdministrativeDetail.UserName);
			if (objEmployeeAdministrativeDetail.GradeObject != null)
			{
				UDSP_UPDATE_EMPLOYEE_ADMINISTRATIVE_DETAIL.GRADE_ID_PARAM(objParameterList , objEmployeeAdministrativeDetail.GradeObject.GradeId);
			}
			UDSP_UPDATE_EMPLOYEE_ADMINISTRATIVE_DETAIL.PROBATION_UPTO_PARAM(objParameterList , objEmployeeAdministrativeDetail.ProbationUpto);
			UDSP_UPDATE_EMPLOYEE_ADMINISTRATIVE_DETAIL.CONFIRMATION_DATE_PARAM(objParameterList , objEmployeeAdministrativeDetail.ConfirmationDate);
			UDSP_UPDATE_EMPLOYEE_ADMINISTRATIVE_DETAIL.IS_SALARY_STOPPED_PARAM(objParameterList , objEmployeeAdministrativeDetail.IsSalaryStopped);
			UDSP_UPDATE_EMPLOYEE_ADMINISTRATIVE_DETAIL.TERMINATION_DATE_PARAM(objParameterList , objEmployeeAdministrativeDetail.TerminationDate);
			UDSP_UPDATE_EMPLOYEE_ADMINISTRATIVE_DETAIL.RESIGNATION_DATE_PARAM(objParameterList , objEmployeeAdministrativeDetail.ResignationDate);
			UDSP_UPDATE_EMPLOYEE_ADMINISTRATIVE_DETAIL.DISCONTINUE_DATE_PARAM(objParameterList , objEmployeeAdministrativeDetail.DiscontinueDate);
			UDSP_UPDATE_EMPLOYEE_ADMINISTRATIVE_DETAIL.TOTAL_EXPERIENCE_PARAM(objParameterList , objEmployeeAdministrativeDetail.TotalExperience);
			UDSP_UPDATE_EMPLOYEE_ADMINISTRATIVE_DETAIL.RELEVANT_EXPERIENCE_PARAM(objParameterList , objEmployeeAdministrativeDetail.RelevantExperience);
                        if (objEmployeeAdministrativeDetail.EmployeeTypeObject != null)
			{
				UDSP_UPDATE_EMPLOYEE_ADMINISTRATIVE_DETAIL.EMPLOYEE_TYPE_ID_PARAM(objParameterList , objEmployeeAdministrativeDetail.EmployeeTypeObject.MetadataId);
			}
			UDSP_UPDATE_EMPLOYEE_ADMINISTRATIVE_DETAIL.LWF_NO_PARAM(objParameterList , objEmployeeAdministrativeDetail.LwfNo);
            NEWPARAMETERS.ADDPARAMETERS(objParameterList, "@MODIFIED_BY", objEmployeeAdministrativeDetail.ModifiedBy);
            NEWPARAMETERS.ADDPARAMETERS(objParameterList, "@PARENT_ID", objEmployeeAdministrativeDetail.ParentId);
            NEWPARAMETERS.ADDPARAMETERS(objParameterList, "@PARENT_VERSION", objEmployeeAdministrativeDetail.ParentVersion);
			try
			{
				Logger.LogInfo("EmployeeAdministrativeDetailDAO.cs : UpdateEmployeeAdministrativeDetail() is started.");
				dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList,strUpdateEmployeeAdministrativeDetail, CommandType.StoredProcedure).ToString();
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.SUCCEED)
					{
						objEmployeeAdministrativeDetail.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.INVALID)
					{
						objEmployeeAdministrativeDetail.DbOperationStatus = CommonConstant.INVALID;
					}
					else
					{
						objEmployeeAdministrativeDetail.DbOperationStatus = CommonConstant.DUPLICATE;
					}
					Logger.LogInfo("EmployeeAdministrativeDetailDAO.cs : UpdateEmployeeAdministrativeDetail() is ended with success.");
				}
				else
				{
					objEmployeeAdministrativeDetail.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("EmployeeAdministrativeDetailDAO.cs : UpdateEmployeeAdministrativeDetail() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objEmployeeAdministrativeDetail.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("EmployeeAdministrativeDetailDAO.cs : UpdateEmployeeAdministrativeDetail() is ended with error.");
			}
			return objEmployeeAdministrativeDetail;
		}

		public EmployeeAdministrativeDetail SelectRecordById(EmployeeAdministrativeDetail objEmployeeAdministrativeDetail)
		{
			try
			{
				Logger.LogInfo("EmployeeAdministrativeDetailDAO.cs : SelectRecordById() is started.");
				objEmployeeAdministrativeDetail.ObjectDataSet = DataUtility.SelectRecordById(strDBTableName, objEmployeeAdministrativeDetail.EmployeeAdministrativeDetailId, objEmployeeAdministrativeDetail.Version, strSelectEmployeeAdministrativeDetail);
				if (GeneralUtility.IsInteger(objEmployeeAdministrativeDetail.ObjectDataSet.Tables[0].Rows[0][0]) && (objEmployeeAdministrativeDetail.ObjectDataSet.Tables[1].Columns.Count > 1))
				{
					if (Convert.ToInt32(objEmployeeAdministrativeDetail.ObjectDataSet.Tables[0].Rows[0][0]) > 0)
					{
						objEmployeeAdministrativeDetail.IsRecordChanged = false;
						objEmployeeAdministrativeDetail.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else
					{
						objEmployeeAdministrativeDetail.IsRecordChanged = true;
						objEmployeeAdministrativeDetail.DbOperationStatus = CommonConstant.INVALID;
					}
					Logger.LogInfo("EmployeeAdministrativeDetailDAO.cs : SelectRecordById() is ended with success.");
				}
				else
				{
					objEmployeeAdministrativeDetail.DbOperationStatus = CommonConstant.FAIL;
					dbExecuteStatus = objEmployeeAdministrativeDetail.ObjectDataSet.Tables[0].Rows[0][0].ToString() + " " + objEmployeeAdministrativeDetail.ObjectDataSet.Tables[1].Rows[0][0].ToString();
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("EmployeeAdministrativeDetailDAO.cs : SelectRecordById() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objEmployeeAdministrativeDetail.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("EmployeeAdministrativeDetailDAO.cs : SelectRecordById() is ended with error.");
			}
			return objEmployeeAdministrativeDetail;
		}
	}
}
