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
	public class PreviousSchoolEducationMarksDetailDAO
	{
		List<SqlParameter> objParameterList = null ;
		private string strDBTableName = "PREVIOUS_SCHOOL_EDUCATION_MARKS_DETAIL";
		private string strSelectPreviousSchoolEducationMarksDetail = "SP_SELECT_PREVIOUS_SCHOOL_EDUCATION_MARKS_DETAIL";
		private string strInsertPreviousSchoolEducationMarksDetail = "UDSP_INSERT_PREVIOUS_SCHOOL_EDUCATION_MARKS_DETAIL";
		private string strUpdatePreviousSchoolEducationMarksDetail = "UDSP_UPDATE_PREVIOUS_SCHOOL_EDUCATION_MARKS_DETAIL";
		private string dbExecuteStatus = "";

		public PreviousSchoolEducationMarksDetail SelectPreviousSchoolEducationMarksDetail(PreviousSchoolEducationMarksDetail objPreviousSchoolEducationMarksDetail)
		{
			objParameterList = new List<SqlParameter>();

			if (objPreviousSchoolEducationMarksDetail.PreviousSchoolEducationObject != null)
			{
				UDSP_SELECT_PREVIOUS_SCHOOL_EDUCATION_MARKS_DETAIL.PREVIOUS_SCHOOL_EDUCATION_ID_PARAM(objParameterList , objPreviousSchoolEducationMarksDetail.PreviousSchoolEducationObject.PreviousSchoolEducationId);
			}
			if (objPreviousSchoolEducationMarksDetail.RegistrationObject != null)
			{
                NEWPARAMETERS.ADDPARAMETERS(objParameterList,"@REGISTRATION_ID",objPreviousSchoolEducationMarksDetail.RegistrationObject.RegistrationId);
			}
			try
			{
				Logger.LogInfo("PreviousSchoolEducationMarksDetailDAO.cs : SelectPreviousSchoolEducationMarksDetail() is started.");
				objPreviousSchoolEducationMarksDetail.ObjectDataSet = DBMANAGER.GetDataSet(objParameterList,strSelectPreviousSchoolEducationMarksDetail, CommandType.StoredProcedure);
				objPreviousSchoolEducationMarksDetail.DbOperationStatus = CommonConstant.SUCCEED;
				Logger.LogInfo("PreviousSchoolEducationMarksDetailDAO.cs : SelectPreviousSchoolEducationMarksDetail() is ended with success.");
			}
			catch (Exception ex)
			{
				objPreviousSchoolEducationMarksDetail.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("PreviousSchoolEducationMarksDetailDAO.cs : SelectPreviousSchoolEducationMarksDetail() is ended with error.");
			}
			return objPreviousSchoolEducationMarksDetail;
		}
		public PreviousSchoolEducationMarksDetail SubmitPreviousSchoolEducationMarksDetailData(PreviousSchoolEducationMarksDetail objPreviousSchoolEducationMarksDetail)
		{
			objParameterList = new List<SqlParameter>();
			UDSP_SELECT_PREVIOUS_SCHOOL_EDUCATION_MARKS_DETAIL.PREVIOUS_SCHOOL_EDUCATION_ID_PARAM(objParameterList , objPreviousSchoolEducationMarksDetail.PreviousSchoolEducationMarksId);
			if (objPreviousSchoolEducationMarksDetail.PreviousSchoolEducationObject != null)
			{
				UDSP_SELECT_PREVIOUS_SCHOOL_EDUCATION_MARKS_DETAIL.PREVIOUS_SCHOOL_EDUCATION_ID_PARAM(objParameterList , objPreviousSchoolEducationMarksDetail.PreviousSchoolEducationObject.PreviousSchoolEducationId);
			}
			if (objPreviousSchoolEducationMarksDetail.SubjectObject != null)
			{
				UDSP_SELECT_PREVIOUS_SCHOOL_EDUCATION_MARKS_DETAIL.PREVIOUS_SCHOOL_EDUCATION_ID_PARAM(objParameterList , objPreviousSchoolEducationMarksDetail.SubjectObject.SubjectId);
			}
			try
			{
				Logger.LogInfo("PreviousSchoolEducationMarksDetailDAO.cs : SubmitPreviousSchoolEducationMarksDetailData() is started.");
				dbExecuteStatus = DBMANAGER.ExecuteDataSet(objParameterList,objPreviousSchoolEducationMarksDetail.ObjectDataSet,strSelectPreviousSchoolEducationMarksDetail, CommandType.StoredProcedure).ToString();
				objPreviousSchoolEducationMarksDetail.DbOperationStatus = CommonConstant.SUCCEED;
				Logger.LogInfo("PreviousSchoolEducationMarksDetailDAO.cs : SubmitPreviousSchoolEducationMarksDetailData() is ended with success.");
			}
			catch (Exception ex)
			{
				objPreviousSchoolEducationMarksDetail.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("PreviousSchoolEducationMarksDetailDAO.cs : SubmitPreviousSchoolEducationMarksDetailData() is ended with error.");
			}
			return objPreviousSchoolEducationMarksDetail;
		}

	}
}
