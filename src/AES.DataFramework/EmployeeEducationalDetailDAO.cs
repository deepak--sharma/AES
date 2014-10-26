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
	public class EmployeeEducationalDetailDAO
	{
		List<SqlParameter> objParameterList = null ;
		private string strDBTableName = "EMPLOYEE_EDUCATIONAL_DETAIL";
		private string strSelectEmployeeEducationalDetail = "SP_SELECT_EMPLOYEE_EDUCATIONAL_DETAIL";
        private string strGetEmployeeEducationalDetail = "SP_GET_EMPLOYEE_EDUCATIONAL_DETAIL";
		private string strInsertEmployeeEducationalDetail = "UDSP_INSERT_EMPLOYEE_EDUCATIONAL_DETAIL";
		private string strUpdateEmployeeEducationalDetail = "UDSP_UPDATE_EMPLOYEE_EDUCATIONAL_DETAIL";
		private string dbExecuteStatus = "";

		public EmployeeEducationalDetail SelectEmployeeEducationalDetail(EmployeeEducationalDetail objEmployeeEducationalDetail)
		{
			objParameterList = new List<SqlParameter>();
			UDSP_SELECT_EMPLOYEE_EDUCATIONAL_DETAIL.EMPLOYEE_EDUCATIONAL_DETAIL_ID_PARAM(objParameterList , objEmployeeEducationalDetail.EmployeeEducationalDetailId);
			if (objEmployeeEducationalDetail.EmployeeObject != null)
			{
				UDSP_SELECT_EMPLOYEE_EDUCATIONAL_DETAIL.EMPLOYEE_ID_PARAM(objParameterList , objEmployeeEducationalDetail.EmployeeObject.EmployeeId);
			}
			if (objEmployeeEducationalDetail.ClassObject != null)
			{
				UDSP_SELECT_EMPLOYEE_EDUCATIONAL_DETAIL.COURSE_ID_PARAM(objParameterList , objEmployeeEducationalDetail.ClassObject.ClassId);
			}
			if (objEmployeeEducationalDetail.StreamObject != null)
			{
				UDSP_SELECT_EMPLOYEE_EDUCATIONAL_DETAIL.STREAM_ID_PARAM(objParameterList , objEmployeeEducationalDetail.StreamObject.StreamId);
			}
			UDSP_SELECT_EMPLOYEE_EDUCATIONAL_DETAIL.PERIOD_FROM_PARAM(objParameterList , objEmployeeEducationalDetail.PeriodFrom);
			UDSP_SELECT_EMPLOYEE_EDUCATIONAL_DETAIL.PERIOD_TO_PARAM(objParameterList , objEmployeeEducationalDetail.PeriodTo);
			UDSP_SELECT_EMPLOYEE_EDUCATIONAL_DETAIL.MARKS_PERCENTAGE_PARAM(objParameterList , objEmployeeEducationalDetail.MarksPercentage);
			UDSP_SELECT_EMPLOYEE_EDUCATIONAL_DETAIL.SCHOOL_COLLEGE_INSTITUTE_NAME_PARAM(objParameterList , objEmployeeEducationalDetail.SchoolCollegeInstituteName);
			UDSP_SELECT_EMPLOYEE_EDUCATIONAL_DETAIL.ADDRESS_PARAM(objParameterList , objEmployeeEducationalDetail.Address);
			UDSP_SELECT_EMPLOYEE_EDUCATIONAL_DETAIL.BOARD_UNIVERSITY_NAME_PARAM(objParameterList , objEmployeeEducationalDetail.BoardUniversityName);
			UDSP_SELECT_EMPLOYEE_EDUCATIONAL_DETAIL.REMARKS_PARAM(objParameterList , objEmployeeEducationalDetail.Remarks);
			try
			{
				Logger.LogInfo("EmployeeEducationalDetailDAO.cs : SelectEmployeeEducationalDetail() is started.");
				objEmployeeEducationalDetail.ObjectDataSet = DBMANAGER.GetDataSet(objParameterList,strSelectEmployeeEducationalDetail, CommandType.StoredProcedure);
				objEmployeeEducationalDetail.DbOperationStatus = CommonConstant.SUCCEED;
				Logger.LogInfo("EmployeeEducationalDetailDAO.cs : SelectEmployeeEducationalDetail() is ended with success.");
			}
			catch (Exception ex)
			{
				objEmployeeEducationalDetail.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("EmployeeEducationalDetailDAO.cs : SelectEmployeeEducationalDetail() is ended with error.");
			}
			return objEmployeeEducationalDetail;
		}
		public EmployeeEducationalDetail SubmitEmployeeEducationalDetailData(EmployeeEducationalDetail objEmployeeEducationalDetail)
		{
			objParameterList = new List<SqlParameter>();
			UDSP_SELECT_EMPLOYEE_EDUCATIONAL_DETAIL.EMPLOYEE_EDUCATIONAL_DETAIL_ID_PARAM(objParameterList , objEmployeeEducationalDetail.EmployeeEducationalDetailId);
			if (objEmployeeEducationalDetail.EmployeeObject != null)
			{
				UDSP_SELECT_EMPLOYEE_EDUCATIONAL_DETAIL.EMPLOYEE_ID_PARAM(objParameterList , objEmployeeEducationalDetail.EmployeeObject.EmployeeId);
			}
			if (objEmployeeEducationalDetail.ClassObject != null)
			{
				UDSP_SELECT_EMPLOYEE_EDUCATIONAL_DETAIL.COURSE_ID_PARAM(objParameterList , objEmployeeEducationalDetail.ClassObject.ClassId);
			}
			if (objEmployeeEducationalDetail.StreamObject != null)
			{
				UDSP_SELECT_EMPLOYEE_EDUCATIONAL_DETAIL.STREAM_ID_PARAM(objParameterList , objEmployeeEducationalDetail.StreamObject.StreamId);
			}
			UDSP_SELECT_EMPLOYEE_EDUCATIONAL_DETAIL.PERIOD_FROM_PARAM(objParameterList , objEmployeeEducationalDetail.PeriodFrom);
			UDSP_SELECT_EMPLOYEE_EDUCATIONAL_DETAIL.PERIOD_TO_PARAM(objParameterList , objEmployeeEducationalDetail.PeriodTo);
			UDSP_SELECT_EMPLOYEE_EDUCATIONAL_DETAIL.MARKS_PERCENTAGE_PARAM(objParameterList , objEmployeeEducationalDetail.MarksPercentage);
			UDSP_SELECT_EMPLOYEE_EDUCATIONAL_DETAIL.SCHOOL_COLLEGE_INSTITUTE_NAME_PARAM(objParameterList , objEmployeeEducationalDetail.SchoolCollegeInstituteName);
			UDSP_SELECT_EMPLOYEE_EDUCATIONAL_DETAIL.ADDRESS_PARAM(objParameterList , objEmployeeEducationalDetail.Address);
			UDSP_SELECT_EMPLOYEE_EDUCATIONAL_DETAIL.BOARD_UNIVERSITY_NAME_PARAM(objParameterList , objEmployeeEducationalDetail.BoardUniversityName);
			UDSP_SELECT_EMPLOYEE_EDUCATIONAL_DETAIL.REMARKS_PARAM(objParameterList , objEmployeeEducationalDetail.Remarks);
			try
			{
				Logger.LogInfo("EmployeeEducationalDetailDAO.cs : SubmitEmployeeEducationalDetailData() is started.");
                dbExecuteStatus = DBMANAGER.ExecuteDataSet(objParameterList, objEmployeeEducationalDetail.ObjectDataSet, strGetEmployeeEducationalDetail, CommandType.StoredProcedure).ToString();
				objEmployeeEducationalDetail.DbOperationStatus = CommonConstant.SUCCEED;
				Logger.LogInfo("EmployeeEducationalDetailDAO.cs : SubmitEmployeeEducationalDetailData() is ended with success.");
			}
			catch (Exception ex)
			{
				objEmployeeEducationalDetail.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("EmployeeEducationalDetailDAO.cs : SubmitEmployeeEducationalDetailData() is ended with error.");
			}
			return objEmployeeEducationalDetail;
		}        

	}
}
