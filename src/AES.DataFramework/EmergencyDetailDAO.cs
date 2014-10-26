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
	public class EmergencyDetailDAO
	{
		List<SqlParameter> objParameterList = null ;
		private string strDBTableName = "EMERGENCY_DETAIL";
		private string strSelectEmergencyDetail = "UDSP_SELECT_EMERGENCY_DETAIL";
		private string strInsertEmergencyDetail = "UDSP_INSERT_EMERGENCY_DETAIL";
		private string strUpdateEmergencyDetail = "UDSP_UPDATE_EMERGENCY_DETAIL";
        private string strInsertEmployeeEmergencyDetail = "UDSP_INSERT_EMPLOYEE_EMERGENCY_DETAIL";
        private string strUpdateEmployeeEmergencyDetail = "UDSP_UPDATE_EMPLOYEE_EMERGENCY_DETAIL";
        
		private string dbExecuteStatus = "";

		public EmergencyDetail SelectEmergencyDetail(EmergencyDetail objEmergencyDetail)
		{
			objParameterList = new List<SqlParameter>();
			UDSP_SELECT_EMERGENCY_DETAIL.EMERGENCY_DETAIL_ID_PARAM(objParameterList , objEmergencyDetail.EmergencyDetailId);
			UDSP_SELECT_EMERGENCY_DETAIL.CONTACT_PERSON_PARAM(objParameterList , objEmergencyDetail.ContactPerson);
			UDSP_SELECT_EMERGENCY_DETAIL.RELATION_PARAM(objParameterList , objEmergencyDetail.Relation);
			UDSP_SELECT_EMERGENCY_DETAIL.CONTACT_NUMBER_PARAM(objParameterList , objEmergencyDetail.ContactNumber);
			UDSP_SELECT_EMERGENCY_DETAIL.ADDRESS_PARAM(objParameterList , objEmergencyDetail.Address);
			UDSP_SELECT_EMERGENCY_DETAIL.EMAIL_ID_PARAM(objParameterList , objEmergencyDetail.EmailId);
			try
			{
				Logger.LogInfo("EmergencyDetailDAO.cs : SelectEmergencyDetail() is started.");
				objEmergencyDetail.ObjectDataSet = DBMANAGER.GetDataSet(objParameterList,strSelectEmergencyDetail, CommandType.StoredProcedure);
				objEmergencyDetail.DbOperationStatus = CommonConstant.SUCCEED;
				Logger.LogInfo("EmergencyDetailDAO.cs : SelectEmergencyDetail() is ended with success.");
			}
			catch (Exception ex)
			{
				objEmergencyDetail.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("EmergencyDetailDAO.cs : SelectEmergencyDetail() is ended with error.");
			}
			return objEmergencyDetail;
		}

		public EmergencyDetail InsertEmergencyDetail(EmergencyDetail objEmergencyDetail)
		{
			objParameterList = new List<SqlParameter>();
				
			UDSP_INSERT_EMERGENCY_DETAIL.CONTACT_PERSON_PARAM(objParameterList , objEmergencyDetail.ContactPerson);
			UDSP_INSERT_EMERGENCY_DETAIL.RELATION_PARAM(objParameterList , objEmergencyDetail.Relation);
			UDSP_INSERT_EMERGENCY_DETAIL.CONTACT_NUMBER_PARAM(objParameterList , objEmergencyDetail.ContactNumber);
			UDSP_INSERT_EMERGENCY_DETAIL.ADDRESS_PARAM(objParameterList , objEmergencyDetail.Address);
			UDSP_INSERT_EMERGENCY_DETAIL.EMAIL_ID_PARAM(objParameterList , objEmergencyDetail.EmailId);
			try
			{
				Logger.LogInfo("EmergencyDetailDAO.cs : InsertEmergencyDetail() is started.");
				dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList,strInsertEmergencyDetail, CommandType.StoredProcedure).ToString();
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) > 0 )
					{
						objEmergencyDetail.EmergencyDetailId = Convert.ToInt32(dbExecuteStatus);
						objEmergencyDetail.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else
					{
						objEmergencyDetail.DbOperationStatus = CommonConstant.DUPLICATE;
					}
					Logger.LogInfo("EmergencyDetailDAO.cs : InsertEmergencyDetail() is ended with success.");
				}
				else
				{
					objEmergencyDetail.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("EmergencyDetailDAO.cs : InsertEmergencyDetail() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objEmergencyDetail.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("EmergencyDetailDAO.cs : InsertEmergencyDetail() is ended with error.");
			}
			return objEmergencyDetail;
		}

		public EmergencyDetail UpdateEmergencyDetail(EmergencyDetail objEmergencyDetail)
		{
			objParameterList = new List<SqlParameter>();
				
			UDSP_UPDATE_EMERGENCY_DETAIL.EMERGENCY_DETAIL_ID_PARAM(objParameterList , objEmergencyDetail.EmergencyDetailId);
			UDSP_UPDATE_EMERGENCY_DETAIL.CONTACT_PERSON_PARAM(objParameterList , objEmergencyDetail.ContactPerson);
			UDSP_UPDATE_EMERGENCY_DETAIL.RELATION_PARAM(objParameterList , objEmergencyDetail.Relation);
			UDSP_UPDATE_EMERGENCY_DETAIL.CONTACT_NUMBER_PARAM(objParameterList , objEmergencyDetail.ContactNumber);
			UDSP_UPDATE_EMERGENCY_DETAIL.ADDRESS_PARAM(objParameterList , objEmergencyDetail.Address);
			UDSP_UPDATE_EMERGENCY_DETAIL.EMAIL_ID_PARAM(objParameterList , objEmergencyDetail.EmailId);
			try
			{
				Logger.LogInfo("EmergencyDetailDAO.cs : UpdateEmergencyDetail() is started.");
				dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList,strUpdateEmergencyDetail, CommandType.StoredProcedure).ToString();
				if (GeneralUtility.IsInteger(dbExecuteStatus))
				{
					if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.SUCCEED)
					{
						objEmergencyDetail.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else if(Convert.ToInt32(dbExecuteStatus) == CommonConstant.INVALID)
					{
						objEmergencyDetail.DbOperationStatus = CommonConstant.INVALID;
					}
					else
					{
						objEmergencyDetail.DbOperationStatus = CommonConstant.DUPLICATE;
					}
					Logger.LogInfo("EmergencyDetailDAO.cs : UpdateEmergencyDetail() is ended with success.");
				}
				else
				{
					objEmergencyDetail.DbOperationStatus = CommonConstant.FAIL;
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("EmergencyDetailDAO.cs : UpdateEmergencyDetail() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objEmergencyDetail.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("EmergencyDetailDAO.cs : UpdateEmergencyDetail() is ended with error.");
			}
			return objEmergencyDetail;
		}

		public EmergencyDetail SelectRecordById(EmergencyDetail objEmergencyDetail)
		{
			try
			{
				Logger.LogInfo("EmergencyDetailDAO.cs : SelectRecordById() is started.");
				objEmergencyDetail.ObjectDataSet = DataUtility.SelectRecordById(strDBTableName, objEmergencyDetail.EmergencyDetailId, objEmergencyDetail.Version, strSelectEmergencyDetail);
				if (GeneralUtility.IsInteger(objEmergencyDetail.ObjectDataSet.Tables[0].Rows[0][0]) && (objEmergencyDetail.ObjectDataSet.Tables[1].Columns.Count > 1))
				{
					if (Convert.ToInt32(objEmergencyDetail.ObjectDataSet.Tables[0].Rows[0][0]) > 0)
					{
						objEmergencyDetail.IsRecordChanged = false;
						objEmergencyDetail.DbOperationStatus = CommonConstant.SUCCEED;
					}
					else
					{
						objEmergencyDetail.IsRecordChanged = true;
						objEmergencyDetail.DbOperationStatus = CommonConstant.INVALID;
					}
					Logger.LogInfo("EmergencyDetailDAO.cs : SelectRecordById() is ended with success.");
				}
				else
				{
					objEmergencyDetail.DbOperationStatus = CommonConstant.FAIL;
					dbExecuteStatus = objEmergencyDetail.ObjectDataSet.Tables[0].Rows[0][0].ToString() + " " + objEmergencyDetail.ObjectDataSet.Tables[1].Rows[0][0].ToString();
					Logger.LogInfo(dbExecuteStatus);
					Logger.LogInfo("EmergencyDetailDAO.cs : SelectRecordById() is ended with error.");
				}
			}
			catch (Exception ex)
			{
				objEmergencyDetail.DbOperationStatus = CommonConstant.FAIL;
				Logger.LogError(ex.Message);
				Logger.LogInfo("EmergencyDetailDAO.cs : SelectRecordById() is ended with error.");
			}
			return objEmergencyDetail;
		}

        public EmergencyDetail SaveEmployeeEmergencyDetail(EmergencyDetail objEmergencyDetail)
        {
            objParameterList = new List<SqlParameter>();

            UDSP_INSERT_EMERGENCY_DETAIL.CONTACT_PERSON_PARAM(objParameterList, objEmergencyDetail.ContactPerson);
            UDSP_INSERT_EMERGENCY_DETAIL.RELATION_PARAM(objParameterList, objEmergencyDetail.Relation);
            UDSP_INSERT_EMERGENCY_DETAIL.CONTACT_NUMBER_PARAM(objParameterList, objEmergencyDetail.ContactNumber);
            UDSP_INSERT_EMERGENCY_DETAIL.ADDRESS_PARAM(objParameterList, objEmergencyDetail.Address);
            UDSP_INSERT_EMERGENCY_DETAIL.EMAIL_ID_PARAM(objParameterList, objEmergencyDetail.EmailId);
            NEWPARAMETERS.ADDPARAMETERS(objParameterList, "@PARENT_ID", objEmergencyDetail.ParentId);
            NEWPARAMETERS.ADDPARAMETERS(objParameterList, "@PARENT_VERSION", objEmergencyDetail.ParentVersion);
            try
            {
                Logger.LogInfo("EmergencyDetailDAO.cs : SaveEmployeeEmergencyDetail() is started.");
                dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList, strInsertEmployeeEmergencyDetail, CommandType.StoredProcedure).ToString();
                if (GeneralUtility.IsInteger(dbExecuteStatus))
                {
                    if (Convert.ToInt32(dbExecuteStatus) > 0)
                    {
                        objEmergencyDetail.EmergencyDetailId = Convert.ToInt32(dbExecuteStatus);
                        objEmergencyDetail.DbOperationStatus = CommonConstant.SUCCEED;
                    }
                    else
                    {
                        objEmergencyDetail.DbOperationStatus = CommonConstant.DUPLICATE;
                    }
                    Logger.LogInfo("EmergencyDetailDAO.cs : SaveEmployeeEmergencyDetail() is ended with success.");
                }
                else
                {
                    objEmergencyDetail.DbOperationStatus = CommonConstant.FAIL;
                    Logger.LogInfo(dbExecuteStatus);
                    Logger.LogInfo("EmergencyDetailDAO.cs : SaveEmployeeEmergencyDetail() is ended with error.");
                }
            }
            catch (Exception ex)
            {
                objEmergencyDetail.DbOperationStatus = CommonConstant.FAIL;
                Logger.LogError(ex.Message);
                Logger.LogInfo("EmergencyDetailDAO.cs : SaveEmployeeEmergencyDetail() is ended with error.");
            }
            return objEmergencyDetail;
        }

        public EmergencyDetail EditEmployeeEmergencyDetail(EmergencyDetail objEmergencyDetail)
        {
            objParameterList = new List<SqlParameter>();

            UDSP_UPDATE_EMERGENCY_DETAIL.EMERGENCY_DETAIL_ID_PARAM(objParameterList, objEmergencyDetail.EmergencyDetailId);
            UDSP_UPDATE_EMERGENCY_DETAIL.CONTACT_PERSON_PARAM(objParameterList, objEmergencyDetail.ContactPerson);
            UDSP_UPDATE_EMERGENCY_DETAIL.RELATION_PARAM(objParameterList, objEmergencyDetail.Relation);
            UDSP_UPDATE_EMERGENCY_DETAIL.CONTACT_NUMBER_PARAM(objParameterList, objEmergencyDetail.ContactNumber);
            UDSP_UPDATE_EMERGENCY_DETAIL.ADDRESS_PARAM(objParameterList, objEmergencyDetail.Address);
            UDSP_UPDATE_EMERGENCY_DETAIL.EMAIL_ID_PARAM(objParameterList, objEmergencyDetail.EmailId);
            try
            {
                Logger.LogInfo("EmergencyDetailDAO.cs : EditEmployeeEmergencyDetail() is started.");
                dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList, strUpdateEmployeeEmergencyDetail, CommandType.StoredProcedure).ToString();
                if (GeneralUtility.IsInteger(dbExecuteStatus))
                {
                    if (Convert.ToInt32(dbExecuteStatus) == CommonConstant.SUCCEED)
                    {
                        objEmergencyDetail.DbOperationStatus = CommonConstant.SUCCEED;
                    }
                    else if (Convert.ToInt32(dbExecuteStatus) == CommonConstant.INVALID)
                    {
                        objEmergencyDetail.DbOperationStatus = CommonConstant.INVALID;
                    }
                    else
                    {
                        objEmergencyDetail.DbOperationStatus = CommonConstant.DUPLICATE;
                    }
                    Logger.LogInfo("EmergencyDetailDAO.cs : EditEmployeeEmergencyDetail() is ended with success.");
                }
                else
                {
                    objEmergencyDetail.DbOperationStatus = CommonConstant.FAIL;
                    Logger.LogInfo(dbExecuteStatus);
                    Logger.LogInfo("EmergencyDetailDAO.cs : EditEmployeeEmergencyDetail() is ended with error.");
                }
            }
            catch (Exception ex)
            {
                objEmergencyDetail.DbOperationStatus = CommonConstant.FAIL;
                Logger.LogError(ex.Message);
                Logger.LogInfo("EmergencyDetailDAO.cs : EditEmployeeEmergencyDetail() is ended with error.");
            }
            return objEmergencyDetail;
        }
	}
}
