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
	public class EmployeeFamilyDetailDAO
	{
		List<SqlParameter> objParameterList = null ;
		private string strDBTableName = "EMPLOYEE_FAMILY_DETAIL";
		private string strSelectEmployeeFamilyDetail = "SP_SELECT_EMPLOYEE_FAMILY_DETAIL";
        private string strGetEmployeeFamilyDetail = "SP_GET_EMPLOYEE_FAMILY_DETAIL";
		private string strInsertEmployeeFamilyDetail = "UDSP_INSERT_EMPLOYEE_FAMILY_DETAIL";
		private string strUpdateEmployeeFamilyDetail = "UDSP_UPDATE_EMPLOYEE_FAMILY_DETAIL";
		private string dbExecuteStatus = "";

		public EmployeeFamilyDetail SelectEmployeeFamilyDetail(EmployeeFamilyDetail objEmployeeFamilyDetail)
		{
			objParameterList = new List<SqlParameter>();
			UDSP_SELECT_EMPLOYEE_FAMILY_DETAIL.EMPLOYEE_FAMILY_ID_PARAM(objParameterList , objEmployeeFamilyDetail.EmployeeFamilyId);
			if (objEmployeeFamilyDetail.EmployeeObject != null)
			{
				UDSP_SELECT_EMPLOYEE_FAMILY_DETAIL.EMPLOYEE_ID_PARAM(objParameterList , objEmployeeFamilyDetail.EmployeeObject.EmployeeId);
			}
			UDSP_SELECT_EMPLOYEE_FAMILY_DETAIL.FIRST_NAME_PARAM(objParameterList , objEmployeeFamilyDetail.FirstName);
			UDSP_SELECT_EMPLOYEE_FAMILY_DETAIL.MIDDLE_NAME_PARAM(objParameterList , objEmployeeFamilyDetail.MiddleName);
			UDSP_SELECT_EMPLOYEE_FAMILY_DETAIL.LAST_NAME_PARAM(objParameterList , objEmployeeFamilyDetail.LastName);
			if (objEmployeeFamilyDetail.GenderObject != null)
			{
				UDSP_SELECT_EMPLOYEE_FAMILY_DETAIL.GENDER_ID_PARAM(objParameterList , objEmployeeFamilyDetail.GenderObject.MetadataId);
			}
			if (objEmployeeFamilyDetail.RelationObject != null)
			{
				UDSP_SELECT_EMPLOYEE_FAMILY_DETAIL.RELATION_ID_PARAM(objParameterList , objEmployeeFamilyDetail.RelationObject.MetadataId);
			}
			UDSP_SELECT_EMPLOYEE_FAMILY_DETAIL.DATE_OF_BIRTH_PARAM(objParameterList , objEmployeeFamilyDetail.DateOfBirth);
			if (objEmployeeFamilyDetail.NationalityObject != null)
			{
				UDSP_SELECT_EMPLOYEE_FAMILY_DETAIL.NATIONALITY_ID_PARAM(objParameterList , objEmployeeFamilyDetail.NationalityObject.MetadataId);
			}
            NEWPARAMETERS.ADDPARAMETERS(objParameterList, "@NATIONALITY_METADATA_ID", objEmployeeFamilyDetail.NationalityObject.DataHolder);
            NEWPARAMETERS.ADDPARAMETERS(objParameterList, "@GENDER_METADATA_ID", objEmployeeFamilyDetail.GenderObject.DataHolder);
            NEWPARAMETERS.ADDPARAMETERS(objParameterList, "@RELATION_METADATA_ID", objEmployeeFamilyDetail.RelationObject.DataHolder);
			try
			{
				Logger.LogInfo("EmployeeFamilyDetailDAO.cs : SelectEmployeeFamilyDetail() is started.");
				objEmployeeFamilyDetail.ObjectDataSet = DBMANAGER.GetDataSet(objParameterList,strSelectEmployeeFamilyDetail, CommandType.StoredProcedure);
				objEmployeeFamilyDetail.DbOperationStatus = CommonConstant.SUCCEED;
				Logger.LogInfo("EmployeeFamilyDetailDAO.cs : SelectEmployeeFamilyDetail() is ended with success.");
			}
			catch (Exception ex)
			{
				objEmployeeFamilyDetail.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("EmployeeFamilyDetailDAO.cs : SelectEmployeeFamilyDetail() is ended with error.");
			}
			return objEmployeeFamilyDetail;
		}
		public EmployeeFamilyDetail SubmitEmployeeFamilyDetailData(EmployeeFamilyDetail objEmployeeFamilyDetail)
		{
			objParameterList = new List<SqlParameter>();
			UDSP_SELECT_EMPLOYEE_FAMILY_DETAIL.EMPLOYEE_FAMILY_ID_PARAM(objParameterList , objEmployeeFamilyDetail.EmployeeFamilyId);
			if (objEmployeeFamilyDetail.EmployeeObject != null)
			{
				UDSP_SELECT_EMPLOYEE_FAMILY_DETAIL.EMPLOYEE_ID_PARAM(objParameterList , objEmployeeFamilyDetail.EmployeeObject.EmployeeId);
			}
			UDSP_SELECT_EMPLOYEE_FAMILY_DETAIL.FIRST_NAME_PARAM(objParameterList , objEmployeeFamilyDetail.FirstName);
			UDSP_SELECT_EMPLOYEE_FAMILY_DETAIL.MIDDLE_NAME_PARAM(objParameterList , objEmployeeFamilyDetail.MiddleName);
			UDSP_SELECT_EMPLOYEE_FAMILY_DETAIL.LAST_NAME_PARAM(objParameterList , objEmployeeFamilyDetail.LastName);
			if (objEmployeeFamilyDetail.GenderObject != null)
			{
				UDSP_SELECT_EMPLOYEE_FAMILY_DETAIL.GENDER_ID_PARAM(objParameterList , objEmployeeFamilyDetail.GenderObject.MetadataId);
			}
			if (objEmployeeFamilyDetail.RelationObject != null)
			{
				UDSP_SELECT_EMPLOYEE_FAMILY_DETAIL.RELATION_ID_PARAM(objParameterList , objEmployeeFamilyDetail.RelationObject.MetadataId);
			}
			UDSP_SELECT_EMPLOYEE_FAMILY_DETAIL.DATE_OF_BIRTH_PARAM(objParameterList , objEmployeeFamilyDetail.DateOfBirth);
			if (objEmployeeFamilyDetail.NationalityObject != null)
			{
				UDSP_SELECT_EMPLOYEE_FAMILY_DETAIL.NATIONALITY_ID_PARAM(objParameterList , objEmployeeFamilyDetail.NationalityObject.MetadataId);
			}
			//UDSP_SELECT_EMPLOYEE_FAMILY_DETAIL.IS_DEPENDENT_PARAM(objParameterList , objEmployeeFamilyDetail.IsDependent);
			try
			{
				Logger.LogInfo("EmployeeFamilyDetailDAO.cs : SubmitEmployeeFamilyDetailData() is started.");
                dbExecuteStatus = DBMANAGER.ExecuteDataSet(objParameterList, objEmployeeFamilyDetail.ObjectDataSet, strGetEmployeeFamilyDetail, CommandType.StoredProcedure).ToString();
				objEmployeeFamilyDetail.DbOperationStatus = CommonConstant.SUCCEED;
				Logger.LogInfo("EmployeeFamilyDetailDAO.cs : SubmitEmployeeFamilyDetailData() is ended with success.");
			}
			catch (Exception ex)
			{
				objEmployeeFamilyDetail.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("EmployeeFamilyDetailDAO.cs : SubmitEmployeeFamilyDetailData() is ended with error.");
			}
			return objEmployeeFamilyDetail;
		}

	}
}
