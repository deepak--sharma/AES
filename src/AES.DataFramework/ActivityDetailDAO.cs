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
    public class ActivityDetailDAO
    {
        List<SqlParameter> objParameterList = null;
        private string strDBTableName = "ACTIVITY_DETAIL";
        private string strSelectActivityDetail = "SP_SELECT_ACTIVITY_DETAIL";
        private string strInsertActivityDetail = "UDSP_INSERT_ACTIVITY_DETAIL";
        private string strUpdateActivityDetail = "UDSP_UPDATE_ACTIVITY_DETAIL";
        private string dbExecuteStatus = "";

        public ActivityDetail SelectActivityDetail(ActivityDetail objActivityDetail)
        {
            objParameterList = new List<SqlParameter>();
            UDSP_SELECT_ACTIVITY_DETAIL.ACTIVITY_DETAIL_ID_PARAM(objParameterList, objActivityDetail.ActivityDetailId);
            if (objActivityDetail.ActivityObject != null)
            {
                UDSP_SELECT_ACTIVITY_DETAIL.ACTIVITY_ID_PARAM(objParameterList, objActivityDetail.ActivityObject.ActivityId);
            }
            if (objActivityDetail.SessionObject != null)
            {
                UDSP_SELECT_ACTIVITY_DETAIL.SESSION_ID_PARAM(objParameterList, objActivityDetail.SessionObject.SessionId);
            }
            if (objActivityDetail.BranchObject != null)
            {
                UDSP_SELECT_ACTIVITY_DETAIL.BRANCH_ID_PARAM(objParameterList, objActivityDetail.BranchObject.BranchId);
            }
            if (objActivityDetail.ClassObject != null)
            {
                UDSP_SELECT_ACTIVITY_DETAIL.CLASS_ID_PARAM(objParameterList, objActivityDetail.ClassObject.ClassId);
            }
            if (objActivityDetail.SubjectObject != null)
            {
                UDSP_SELECT_ACTIVITY_DETAIL.SUBJECT_ID_PARAM(objParameterList, objActivityDetail.SubjectObject.SubjectId);
            }
            if (objActivityDetail.SectionObject != null)
            {
                UDSP_SELECT_ACTIVITY_DETAIL.SECTION_ID_PARAM(objParameterList, objActivityDetail.SectionObject.SectionId);
            }
            if (objActivityDetail.StreamObject != null)
            {
                UDSP_SELECT_ACTIVITY_DETAIL.STREAM_ID_PARAM(objParameterList, objActivityDetail.StreamObject.StreamId);
            }
            UDSP_SELECT_ACTIVITY_DETAIL.START_DATE_PARAM(objParameterList, objActivityDetail.StartDate);
            UDSP_SELECT_ACTIVITY_DETAIL.END_DATE_PARAM(objParameterList, objActivityDetail.EndDate);
            if (objActivityDetail.ActivityOwnerObject != null)
            {
                UDSP_SELECT_ACTIVITY_DETAIL.ACTIVITY_OWNER_ID_PARAM(objParameterList, objActivityDetail.ActivityOwnerObject.EmployeeId);
            }
            UDSP_SELECT_ACTIVITY_DETAIL.DESCRIPTION_PARAM(objParameterList, objActivityDetail.Description);
            UDSP_SELECT_ACTIVITY_DETAIL.RECORD_STATUS_PARAM(objParameterList, objActivityDetail.RecordStatus);
            try
            {
                Logger.LogInfo("ActivityDetailDAO.cs : SelectActivityDetail() is started.");
                objActivityDetail.ObjectDataSet = DBMANAGER.GetDataSet(objParameterList, strSelectActivityDetail, CommandType.StoredProcedure);
                objActivityDetail.DbOperationStatus = CommonConstant.SUCCEED;
                Logger.LogInfo("ActivityDetailDAO.cs : SelectActivityDetail() is ended with success.");
            }
            catch (Exception ex)
            {
                objActivityDetail.DbOperationStatus = CommonConstant.FAIL;
                Logger.LogError(ex.Message);
                Logger.LogInfo("ActivityDetailDAO.cs : SelectActivityDetail() is ended with error.");
            }
            return objActivityDetail;
        }

        public ActivityDetail InsertActivityDetail(ActivityDetail objActivityDetail)
        {
            objParameterList = new List<SqlParameter>();

            if (objActivityDetail.ActivityObject != null)
            {
                UDSP_INSERT_ACTIVITY_DETAIL.ACTIVITY_ID_PARAM(objParameterList, objActivityDetail.ActivityObject.ActivityId);
            }
            if (objActivityDetail.SessionObject != null)
            {
                UDSP_INSERT_ACTIVITY_DETAIL.SESSION_ID_PARAM(objParameterList, objActivityDetail.SessionObject.SessionId);
            }
            if (objActivityDetail.BranchObject != null)
            {
                UDSP_INSERT_ACTIVITY_DETAIL.BRANCH_ID_PARAM(objParameterList, objActivityDetail.BranchObject.BranchId);
            }
            if (objActivityDetail.ClassObject != null)
            {
                UDSP_INSERT_ACTIVITY_DETAIL.CLASS_ID_PARAM(objParameterList, objActivityDetail.ClassObject.ClassId);
            }
            if (objActivityDetail.SubjectObject != null)
            {
                UDSP_INSERT_ACTIVITY_DETAIL.SUBJECT_ID_PARAM(objParameterList, objActivityDetail.SubjectObject.SubjectId);
            }
            if (objActivityDetail.SectionObject != null)
            {
                UDSP_INSERT_ACTIVITY_DETAIL.SECTION_ID_PARAM(objParameterList, objActivityDetail.SectionObject.SectionId);
            }
            if (objActivityDetail.StreamObject != null)
            {
                UDSP_INSERT_ACTIVITY_DETAIL.STREAM_ID_PARAM(objParameterList, objActivityDetail.StreamObject.StreamId);
            }
            UDSP_INSERT_ACTIVITY_DETAIL.START_DATE_PARAM(objParameterList, objActivityDetail.StartDate);
            UDSP_INSERT_ACTIVITY_DETAIL.END_DATE_PARAM(objParameterList, objActivityDetail.EndDate);
            if (objActivityDetail.ActivityOwnerObject != null)
            {
                UDSP_INSERT_ACTIVITY_DETAIL.ACTIVITY_OWNER_ID_PARAM(objParameterList, objActivityDetail.ActivityOwnerObject.EmployeeId);
            }
            UDSP_INSERT_ACTIVITY_DETAIL.DESCRIPTION_PARAM(objParameterList, objActivityDetail.Description);
            UDSP_INSERT_ACTIVITY_DETAIL.VERSION_PARAM(objParameterList, objActivityDetail.Version);
            UDSP_INSERT_ACTIVITY_DETAIL.CREATED_BY_PARAM(objParameterList, objActivityDetail.CreatedBy);
            UDSP_INSERT_ACTIVITY_DETAIL.CREATED_ON_PARAM(objParameterList, objActivityDetail.CreatedOn);
            UDSP_INSERT_ACTIVITY_DETAIL.MODIFIED_BY_PARAM(objParameterList, objActivityDetail.ModifiedBy);
            UDSP_INSERT_ACTIVITY_DETAIL.MODIFIED_ON_PARAM(objParameterList, objActivityDetail.ModifiedOn);
            UDSP_INSERT_ACTIVITY_DETAIL.RECORD_STATUS_PARAM(objParameterList, objActivityDetail.RecordStatus);
            try
            {
                Logger.LogInfo("ActivityDetailDAO.cs : InsertActivityDetail() is started.");
                dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList, strInsertActivityDetail, CommandType.StoredProcedure).ToString();
                if (GeneralUtility.IsInteger(dbExecuteStatus))
                {
                    if (Convert.ToInt32(dbExecuteStatus) > 0)
                    {
                        objActivityDetail.ActivityDetailId = Convert.ToInt32(dbExecuteStatus);
                        objActivityDetail.DbOperationStatus = CommonConstant.SUCCEED;
                    }
                    else
                    {
                        objActivityDetail.DbOperationStatus = CommonConstant.DUPLICATE;
                    }
                    Logger.LogInfo("ActivityDetailDAO.cs : InsertActivityDetail() is ended with success.");
                }
                else
                {
                    objActivityDetail.DbOperationStatus = CommonConstant.FAIL;
                    Logger.LogInfo(dbExecuteStatus);
                    Logger.LogInfo("ActivityDetailDAO.cs : InsertActivityDetail() is ended with error.");
                }
            }
            catch (Exception ex)
            {
                objActivityDetail.DbOperationStatus = CommonConstant.FAIL;
                Logger.LogError(ex.Message);
                Logger.LogInfo("ActivityDetailDAO.cs : InsertActivityDetail() is ended with error.");
            }
            return objActivityDetail;
        }

        public ActivityDetail UpdateActivityDetail(ActivityDetail objActivityDetail)
        {
            objParameterList = new List<SqlParameter>();

            UDSP_UPDATE_ACTIVITY_DETAIL.ACTIVITY_DETAIL_ID_PARAM(objParameterList, objActivityDetail.ActivityDetailId);
            if (objActivityDetail.ActivityObject != null)
            {
                UDSP_UPDATE_ACTIVITY_DETAIL.ACTIVITY_ID_PARAM(objParameterList, objActivityDetail.ActivityObject.ActivityId);
            }
            if (objActivityDetail.SessionObject != null)
            {
                UDSP_UPDATE_ACTIVITY_DETAIL.SESSION_ID_PARAM(objParameterList, objActivityDetail.SessionObject.SessionId);
            }
            if (objActivityDetail.BranchObject != null)
            {
                UDSP_UPDATE_ACTIVITY_DETAIL.BRANCH_ID_PARAM(objParameterList, objActivityDetail.BranchObject.BranchId);
            }
            if (objActivityDetail.ClassObject != null)
            {
                UDSP_UPDATE_ACTIVITY_DETAIL.CLASS_ID_PARAM(objParameterList, objActivityDetail.ClassObject.ClassId);
            }
            if (objActivityDetail.SubjectObject != null)
            {
                UDSP_UPDATE_ACTIVITY_DETAIL.SUBJECT_ID_PARAM(objParameterList, objActivityDetail.SubjectObject.SubjectId);
            }
            if (objActivityDetail.SectionObject != null)
            {
                UDSP_UPDATE_ACTIVITY_DETAIL.SECTION_ID_PARAM(objParameterList, objActivityDetail.SectionObject.SectionId);
            }
            if (objActivityDetail.StreamObject != null)
            {
                UDSP_UPDATE_ACTIVITY_DETAIL.STREAM_ID_PARAM(objParameterList, objActivityDetail.StreamObject.StreamId);
            }
            UDSP_UPDATE_ACTIVITY_DETAIL.START_DATE_PARAM(objParameterList, objActivityDetail.StartDate);
            UDSP_UPDATE_ACTIVITY_DETAIL.END_DATE_PARAM(objParameterList, objActivityDetail.EndDate);
            if (objActivityDetail.ActivityOwnerObject != null)
            {
                UDSP_UPDATE_ACTIVITY_DETAIL.ACTIVITY_OWNER_ID_PARAM(objParameterList, objActivityDetail.ActivityOwnerObject.EmployeeId);
            }
            UDSP_UPDATE_ACTIVITY_DETAIL.DESCRIPTION_PARAM(objParameterList, objActivityDetail.Description);
            UDSP_UPDATE_ACTIVITY_DETAIL.VERSION_PARAM(objParameterList, objActivityDetail.Version);
            UDSP_UPDATE_ACTIVITY_DETAIL.CREATED_BY_PARAM(objParameterList, objActivityDetail.CreatedBy);
            UDSP_UPDATE_ACTIVITY_DETAIL.CREATED_ON_PARAM(objParameterList, objActivityDetail.CreatedOn);
            UDSP_UPDATE_ACTIVITY_DETAIL.MODIFIED_BY_PARAM(objParameterList, objActivityDetail.ModifiedBy);
            UDSP_UPDATE_ACTIVITY_DETAIL.MODIFIED_ON_PARAM(objParameterList, objActivityDetail.ModifiedOn);
            UDSP_UPDATE_ACTIVITY_DETAIL.RECORD_STATUS_PARAM(objParameterList, objActivityDetail.RecordStatus);
            try
            {
                Logger.LogInfo("ActivityDetailDAO.cs : UpdateActivityDetail() is started.");
                dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList, strUpdateActivityDetail, CommandType.StoredProcedure).ToString();
                if (GeneralUtility.IsInteger(dbExecuteStatus))
                {
                    if (Convert.ToInt32(dbExecuteStatus) == CommonConstant.SUCCEED)
                    {
                        objActivityDetail.DbOperationStatus = CommonConstant.SUCCEED;
                    }
                    else if (Convert.ToInt32(dbExecuteStatus) == CommonConstant.INVALID)
                    {
                        objActivityDetail.DbOperationStatus = CommonConstant.INVALID;
                    }
                    else
                    {
                        objActivityDetail.DbOperationStatus = CommonConstant.DUPLICATE;
                    }
                    Logger.LogInfo("ActivityDetailDAO.cs : UpdateActivityDetail() is ended with success.");
                }
                else
                {
                    objActivityDetail.DbOperationStatus = CommonConstant.FAIL;
                    Logger.LogInfo(dbExecuteStatus);
                    Logger.LogInfo("ActivityDetailDAO.cs : UpdateActivityDetail() is ended with error.");
                }
            }
            catch (Exception ex)
            {
                objActivityDetail.DbOperationStatus = CommonConstant.FAIL;
                Logger.LogError(ex.Message);
                Logger.LogInfo("ActivityDetailDAO.cs : UpdateActivityDetail() is ended with error.");
            }
            return objActivityDetail;
        }

        public ActivityDetail ActivateDeactivateActivityDetail(ActivityDetail objActivityDetail)
        {
            try
            {
                Logger.LogInfo("ActivityDetailDAO.cs : ActivateDeactivateActivityDetailDAO() is started.");
                dbExecuteStatus = DataUtility.ActivateDeactivateObject(strDBTableName, objActivityDetail.ActivityDetailId,
                                        objActivityDetail.Version, objActivityDetail.RecordStatus, objActivityDetail.ModifiedBy);
                if (GeneralUtility.IsInteger(dbExecuteStatus))
                {
                    if (Convert.ToInt32(dbExecuteStatus) == CommonConstant.SUCCEED)
                    {
                        objActivityDetail.DbOperationStatus = CommonConstant.SUCCEED;
                        Logger.LogInfo("ActivityDetailDAO.cs : ActivateDeactivateActivityDetail() is ended with success.");
                    }
                    else
                    {
                        objActivityDetail.DbOperationStatus = CommonConstant.INVALID;
                        Logger.LogInfo("ActivityDetailDAO.cs : ActivateDeactivateActivityDetail() is ended with success.");
                    }
                }
                else
                {
                    objActivityDetail.DbOperationStatus = CommonConstant.FAIL;
                    Logger.LogInfo(dbExecuteStatus);
                    Logger.LogInfo("ActivityDetailDAO.cs : ActivateDeactivateActivityDetail() is ended with error.");
                }
            }
            catch (Exception ex)
            {
                objActivityDetail.DbOperationStatus = CommonConstant.FAIL;
                Logger.LogError(ex.Message);
                Logger.LogInfo("ActivityDetailDAO.cs : ActivateDeactivateActivityDetail() is ended with error.");
            }
            return objActivityDetail;
        }

        public ActivityDetail SelectRecordById(ActivityDetail objActivityDetail)
        {
            try
            {
                Logger.LogInfo("ActivityDetailDAO.cs : SelectRecordById() is started.");
                objActivityDetail.ObjectDataSet = DataUtility.SelectRecordById(strDBTableName, objActivityDetail.ActivityDetailId, objActivityDetail.Version, strSelectActivityDetail);
                if (GeneralUtility.IsInteger(objActivityDetail.ObjectDataSet.Tables[0].Rows[0][0]) && (objActivityDetail.ObjectDataSet.Tables[1].Columns.Count > 1))
                {
                    if (Convert.ToInt32(objActivityDetail.ObjectDataSet.Tables[0].Rows[0][0]) > 0)
                    {
                        objActivityDetail.IsRecordChanged = false;
                        objActivityDetail.DbOperationStatus = CommonConstant.SUCCEED;
                    }
                    else
                    {
                        objActivityDetail.IsRecordChanged = true;
                        objActivityDetail.DbOperationStatus = CommonConstant.INVALID;
                    }
                    Logger.LogInfo("ActivityDetailDAO.cs : SelectRecordById() is ended with success.");
                }
                else
                {
                    objActivityDetail.DbOperationStatus = CommonConstant.FAIL;
                    dbExecuteStatus = objActivityDetail.ObjectDataSet.Tables[0].Rows[0][0].ToString() + " " + objActivityDetail.ObjectDataSet.Tables[1].Rows[0][0].ToString();
                    Logger.LogInfo(dbExecuteStatus);
                    Logger.LogInfo("ActivityDetailDAO.cs : SelectRecordById() is ended with error.");
                }
            }
            catch (Exception ex)
            {
                objActivityDetail.DbOperationStatus = CommonConstant.FAIL;
                Logger.LogError(ex.Message);
                Logger.LogInfo("ActivityDetailDAO.cs : SelectRecordById() is ended with error.");
            }
            return objActivityDetail;
        }
    }
}
