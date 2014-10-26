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
	public class CandidateDetailDAO
	{
		List<SqlParameter> objParameterList = null ;
		private string strDBTableName = "CANDIDATE_DETAIL";
		private string strSelectCandidateDetail = "UDSP_SELECT_CANDIDATE_DETAIL";
		private string strInsertCandidateDetail = "UDSP_INSERT_CANDIDATE_DETAIL";
		private string strUpdateCandidateDetail = "SP_UPDATE_CANDIDATE_DETAIL";
		private string dbExecuteStatus = "";

		public CandidateDetail SelectCandidateDetail(CandidateDetail objCandidateDetail)
		{
			objParameterList = new List<SqlParameter>();
			UDSP_SELECT_CANDIDATE_DETAIL.CANDIDATE_ID_PARAM(objParameterList , objCandidateDetail.CandidateId);
			UDSP_SELECT_CANDIDATE_DETAIL.FIRST_NAME_PARAM(objParameterList , objCandidateDetail.FirstName);
			UDSP_SELECT_CANDIDATE_DETAIL.MIDDLE_NAME_PARAM(objParameterList , objCandidateDetail.MiddleName);
			UDSP_SELECT_CANDIDATE_DETAIL.LAST_NAME_PARAM(objParameterList , objCandidateDetail.LastName);
			UDSP_SELECT_CANDIDATE_DETAIL.DATE_OF_BIRTH_PARAM(objParameterList , objCandidateDetail.DateOfBirth);
			if (objCandidateDetail.FatherObject != null)
			{
				UDSP_SELECT_CANDIDATE_DETAIL.FATHER_ID_PARAM(objParameterList , objCandidateDetail.FatherObject.GuardianId);
			}
			if (objCandidateDetail.MotherObject != null)
			{
				UDSP_SELECT_CANDIDATE_DETAIL.MOTHER_ID_PARAM(objParameterList , objCandidateDetail.MotherObject.GuardianId);
			}
			if (objCandidateDetail.GuardianObject != null)
			{
				UDSP_SELECT_CANDIDATE_DETAIL.GUARDIAN_ID_PARAM(objParameterList , objCandidateDetail.GuardianObject.GuardianId);
			}
			if (objCandidateDetail.GenderObject != null)
			{
				UDSP_SELECT_CANDIDATE_DETAIL.GENDER_ID_PARAM(objParameterList , objCandidateDetail.GenderObject.MetadataId);
			}
			if (objCandidateDetail.CategoryObject != null)
			{
				UDSP_SELECT_CANDIDATE_DETAIL.CATEGORY_ID_PARAM(objParameterList , objCandidateDetail.CategoryObject.MetadataId);
			}
			if (objCandidateDetail.ReligionObject != null)
			{
				UDSP_SELECT_CANDIDATE_DETAIL.RELIGION_ID_PARAM(objParameterList , objCandidateDetail.ReligionObject.MetadataId);
			}
			if (objCandidateDetail.MaritialStatusObject != null)
			{
				UDSP_SELECT_CANDIDATE_DETAIL.MARITIAL_STATUS_ID_PARAM(objParameterList , objCandidateDetail.MaritialStatusObject.MetadataId);
			}
			UDSP_SELECT_CANDIDATE_DETAIL.IS_STAFF_CHILD_PARAM(objParameterList , objCandidateDetail.IsStaffChild);
			if (objCandidateDetail.CurrentAddressObject != null)
			{
				UDSP_SELECT_CANDIDATE_DETAIL.CURRENT_ADDRESS_ID_PARAM(objParameterList , objCandidateDetail.CurrentAddressObject.AddressId);
			}
			if (objCandidateDetail.PermanentAddressObject != null)
			{
				UDSP_SELECT_CANDIDATE_DETAIL.PERMANENT_ADDRESS_ID_PARAM(objParameterList , objCandidateDetail.PermanentAddressObject.AddressId);
			}
			UDSP_SELECT_CANDIDATE_DETAIL.PHOTO_PARAM(objParameterList , objCandidateDetail.Photo);
			try
			{
				Logger.LogInfo("CandidateDetailDAO.cs : SelectCandidateDetail() is started.");
				objCandidateDetail.ObjectDataSet = DBMANAGER.GetDataSet(objParameterList,strSelectCandidateDetail, CommandType.StoredProcedure);
				objCandidateDetail.DbOperationStatus = CommonConstant.SUCCEED;
				Logger.LogInfo("CandidateDetailDAO.cs : SelectCandidateDetail() is ended with success.");
			}
			catch (Exception ex)
			{
				objCandidateDetail.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("CandidateDetailDAO.cs : SelectCandidateDetail() is ended with error.");
			}
			return objCandidateDetail;
		}

		public CandidateDetail InsertCandidateDetail(CandidateDetail objCandidateDetail)
		{
			objParameterList = new List<SqlParameter>();
				
			UDSP_INSERT_CANDIDATE_DETAIL.FIRST_NAME_PARAM(objParameterList , objCandidateDetail.FirstName);
			UDSP_INSERT_CANDIDATE_DETAIL.MIDDLE_NAME_PARAM(objParameterList , objCandidateDetail.MiddleName);
			UDSP_INSERT_CANDIDATE_DETAIL.LAST_NAME_PARAM(objParameterList , objCandidateDetail.LastName);
			UDSP_INSERT_CANDIDATE_DETAIL.DATE_OF_BIRTH_PARAM(objParameterList , objCandidateDetail.DateOfBirth);
			if (objCandidateDetail.FatherObject != null)
			{
				UDSP_INSERT_CANDIDATE_DETAIL.FATHER_ID_PARAM(objParameterList , objCandidateDetail.FatherObject.GuardianId);
			}
			if (objCandidateDetail.MotherObject != null)
			{
				UDSP_INSERT_CANDIDATE_DETAIL.MOTHER_ID_PARAM(objParameterList , objCandidateDetail.MotherObject.GuardianId);
			}
			if (objCandidateDetail.GuardianObject != null)
			{
				UDSP_INSERT_CANDIDATE_DETAIL.GUARDIAN_ID_PARAM(objParameterList , objCandidateDetail.GuardianObject.GuardianId);
			}
			if (objCandidateDetail.GenderObject != null)
			{
				UDSP_INSERT_CANDIDATE_DETAIL.GENDER_ID_PARAM(objParameterList , objCandidateDetail.GenderObject.MetadataId);
			}
			if (objCandidateDetail.CategoryObject != null)
			{
				UDSP_INSERT_CANDIDATE_DETAIL.CATEGORY_ID_PARAM(objParameterList , objCandidateDetail.CategoryObject.MetadataId);
			}
			if (objCandidateDetail.ReligionObject != null)
			{
				UDSP_INSERT_CANDIDATE_DETAIL.RELIGION_ID_PARAM(objParameterList , objCandidateDetail.ReligionObject.MetadataId);
			}
			if (objCandidateDetail.MaritialStatusObject != null)
			{
				UDSP_INSERT_CANDIDATE_DETAIL.MARITIAL_STATUS_ID_PARAM(objParameterList , objCandidateDetail.MaritialStatusObject.MetadataId);
			}
			UDSP_INSERT_CANDIDATE_DETAIL.IS_STAFF_CHILD_PARAM(objParameterList , objCandidateDetail.IsStaffChild);
			if (objCandidateDetail.CurrentAddressObject != null)
			{
				UDSP_INSERT_CANDIDATE_DETAIL.CURRENT_ADDRESS_ID_PARAM(objParameterList , objCandidateDetail.CurrentAddressObject.AddressId);
			}
			if (objCandidateDetail.PermanentAddressObject != null)
			{
				UDSP_INSERT_CANDIDATE_DETAIL.PERMANENT_ADDRESS_ID_PARAM(objParameterList , objCandidateDetail.PermanentAddressObject.AddressId);
			}
			UDSP_INSERT_CANDIDATE_DETAIL.PHOTO_PARAM(objParameterList , objCandidateDetail.Photo);
			try
			{
				Logger.LogInfo("CandidateDetailDAO.cs : InsertCandidateDetail() is started.");
				dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList,strInsertCandidateDetail, CommandType.StoredProcedure).ToString();
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) > 0 )
					{
						objCandidateDetail.CandidateId = Convert.ToInt32(dbExecuteStatus);
						objCandidateDetail.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else
					{
						objCandidateDetail.DbOperationStatus = CommonConstant.DUPLICATE;
					}
					Logger.LogInfo("CandidateDetailDAO.cs : InsertCandidateDetail() is ended with success.");
				}
				else
				{
					objCandidateDetail.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("CandidateDetailDAO.cs : InsertCandidateDetail() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objCandidateDetail.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("CandidateDetailDAO.cs : InsertCandidateDetail() is ended with error.");
			}
			return objCandidateDetail;
		}

		public CandidateDetail UpdateCandidateDetail(CandidateDetail objCandidateDetail)
		{
			objParameterList = new List<SqlParameter>();
				
			UDSP_UPDATE_CANDIDATE_DETAIL.CANDIDATE_ID_PARAM(objParameterList , objCandidateDetail.CandidateId);
			UDSP_UPDATE_CANDIDATE_DETAIL.FIRST_NAME_PARAM(objParameterList , objCandidateDetail.FirstName);
			UDSP_UPDATE_CANDIDATE_DETAIL.MIDDLE_NAME_PARAM(objParameterList , objCandidateDetail.MiddleName);
			UDSP_UPDATE_CANDIDATE_DETAIL.LAST_NAME_PARAM(objParameterList , objCandidateDetail.LastName);
			UDSP_UPDATE_CANDIDATE_DETAIL.DATE_OF_BIRTH_PARAM(objParameterList , objCandidateDetail.DateOfBirth);
			
			if (objCandidateDetail.GenderObject != null)
			{
				UDSP_UPDATE_CANDIDATE_DETAIL.GENDER_ID_PARAM(objParameterList , objCandidateDetail.GenderObject.MetadataId);
			}
			if (objCandidateDetail.CategoryObject != null)
			{
				UDSP_UPDATE_CANDIDATE_DETAIL.CATEGORY_ID_PARAM(objParameterList , objCandidateDetail.CategoryObject.MetadataId);
			}
			if (objCandidateDetail.ReligionObject != null)
			{
				UDSP_UPDATE_CANDIDATE_DETAIL.RELIGION_ID_PARAM(objParameterList , objCandidateDetail.ReligionObject.MetadataId);
			}
			if (objCandidateDetail.MaritialStatusObject != null)
			{
				UDSP_UPDATE_CANDIDATE_DETAIL.MARITIAL_STATUS_ID_PARAM(objParameterList , objCandidateDetail.MaritialStatusObject.MetadataId);
			}
			UDSP_UPDATE_CANDIDATE_DETAIL.IS_STAFF_CHILD_PARAM(objParameterList , objCandidateDetail.IsStaffChild);
			if (objCandidateDetail.CurrentAddressObject != null)
			{
				UDSP_UPDATE_CANDIDATE_DETAIL.CURRENT_ADDRESS_ID_PARAM(objParameterList , objCandidateDetail.CurrentAddressObject.AddressId);
			}			
			UDSP_UPDATE_CANDIDATE_DETAIL.PHOTO_PARAM(objParameterList , objCandidateDetail.Photo);
			try
			{
				Logger.LogInfo("CandidateDetailDAO.cs : UpdateCandidateDetail() is started.");
				dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList,strUpdateCandidateDetail, CommandType.StoredProcedure).ToString();
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.SUCCEED)
					{
						objCandidateDetail.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.INVALID)
					{
						objCandidateDetail.DbOperationStatus = CommonConstant.INVALID;
					}
					else
					{
						objCandidateDetail.DbOperationStatus = CommonConstant.DUPLICATE;
					}
					Logger.LogInfo("CandidateDetailDAO.cs : UpdateCandidateDetail() is ended with success.");
				}
				else
				{
					objCandidateDetail.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("CandidateDetailDAO.cs : UpdateCandidateDetail() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objCandidateDetail.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("CandidateDetailDAO.cs : UpdateCandidateDetail() is ended with error.");
			}
			return objCandidateDetail;
		}

		public CandidateDetail SelectRecordById(CandidateDetail objCandidateDetail)
		{
			try
			{
				Logger.LogInfo("CandidateDetailDAO.cs : SelectRecordById() is started.");
				objCandidateDetail.ObjectDataSet = DataUtility.SelectRecordById(strDBTableName, objCandidateDetail.CandidateId, objCandidateDetail.Version, strSelectCandidateDetail);
				if (GeneralUtility.IsInteger(objCandidateDetail.ObjectDataSet.Tables[0].Rows[0][0]) && (objCandidateDetail.ObjectDataSet.Tables[1].Columns.Count > 1))
				{
					if (Convert.ToInt32(objCandidateDetail.ObjectDataSet.Tables[0].Rows[0][0]) > 0)
					{
						objCandidateDetail.IsRecordChanged = false;
						objCandidateDetail.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else
					{
						objCandidateDetail.IsRecordChanged = true;
						objCandidateDetail.DbOperationStatus = CommonConstant.INVALID;
					}
					Logger.LogInfo("CandidateDetailDAO.cs : SelectRecordById() is ended with success.");
				}
				else
				{
					objCandidateDetail.DbOperationStatus = CommonConstant.FAIL;
					dbExecuteStatus = objCandidateDetail.ObjectDataSet.Tables[0].Rows[0][0].ToString() + " " + objCandidateDetail.ObjectDataSet.Tables[1].Rows[0][0].ToString();
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("CandidateDetailDAO.cs : SelectRecordById() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objCandidateDetail.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("CandidateDetailDAO.cs : SelectRecordById() is ended with error.");
			}
			return objCandidateDetail;
		}
                
	}
}
