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
    public class SkillDetailDAO
    {
        List<SqlParameter> objParameterList = null;
        private string strDBTableName = "SKILL_DETAIL";
        private string strSelectSkillDetail = "SP_SELECT_SKILL_DETAIL";
        private string strInsertSkillDetail = "SP_INSERT_SKILL_DETAIL";
        private string strUpdateSkillDetail = "UDSP_UPDATE_SKILL_DETAIL";
        private string dbExecuteStatus = "";

        public SkillDetail SelectSkillDetail(SkillDetail objSkillDetail)
        {
            objParameterList = new List<SqlParameter>();
            UDSP_SELECT_SKILL_DETAIL.MEMBER_ID_PARAM(objParameterList, objSkillDetail.MemberId);
            if (objSkillDetail.MemberTypeObject != null)
            {
                UDSP_SELECT_SKILL_DETAIL.MEMBER_TYPE_ID_PARAM(objParameterList, objSkillDetail.MemberTypeObject.MetadataId);
            }
            try
            {
                Logger.LogInfo("SkillDetailDAO.cs : SelectSkillDetail() is started.");
                objSkillDetail.ObjectDataSet = DBMANAGER.GetDataSet(objParameterList, strSelectSkillDetail, CommandType.StoredProcedure);
                objSkillDetail.DbOperationStatus = CommonConstant.SUCCEED;
                Logger.LogInfo("SkillDetailDAO.cs : SelectSkillDetail() is ended with success.");
            }
            catch (Exception ex)
            {
                objSkillDetail.DbOperationStatus = CommonConstant.FAIL;
                Logger.LogError(ex.Message);
                Logger.LogInfo("SkillDetailDAO.cs : SelectSkillDetail() is ended with error.");
            }
            return objSkillDetail;
        }
        public SkillDetail SubmitSkillDetailData(SkillDetail objSkillDetail)
        {
            objParameterList = new List<SqlParameter>();
            UDSP_INSERT_SKILL_DETAIL.MEMBER_ID_PARAM(objParameterList, objSkillDetail.MemberId);
            UDSP_INSERT_SKILL_DETAIL.MEMBER_TYPE_ID_PARAM(objParameterList, objSkillDetail.MemberTypeObject.MetadataId);
            UDSP_INSERT_SKILL_DETAIL.SKILL_ID_PARAM(objParameterList, objSkillDetail.SkillObject.SkillId);
            UDSP_INSERT_SKILL_DETAIL.YEAROFEXP_PARAM(objParameterList, objSkillDetail.Yearofexp);
            UDSP_INSERT_SKILL_DETAIL.COMMENT_PARAM(objParameterList, objSkillDetail.Comment);
            try
            {
                Logger.LogInfo("SkillDetailDAO.cs : SubmitSkillDetailData() is started.");
                dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList, strInsertSkillDetail, CommandType.StoredProcedure).ToString();
                if (GeneralUtility.IsInteger(dbExecuteStatus))
                {
                    if (Convert.ToInt32(dbExecuteStatus) > 0)
                    {
                        objSkillDetail.DbOperationStatus = CommonConstant.SUCCEED;
                    }
                    else
                    {
                        objSkillDetail.DbOperationStatus = CommonConstant.DUPLICATE;
                    }
                    Logger.LogInfo("SkillDetailDAO.cs : SubmitSkillDetailData() is ended with success.");
                }
                else
                {
                    objSkillDetail.DbOperationStatus = CommonConstant.FAIL;
                    Logger.LogInfo(dbExecuteStatus);
                    Logger.LogInfo("SkillDetailDAO.cs : SubmitSkillDetailData() is ended with error.");
                }
            }
            catch (Exception ex)
            {
                objSkillDetail.DbOperationStatus = CommonConstant.FAIL;
                Logger.LogError(ex.Message);
                Logger.LogInfo("SkillDetailDAO.cs : SubmitSkillDetailData() is ended with error.");
            }
            return objSkillDetail;
        }

    }
}
