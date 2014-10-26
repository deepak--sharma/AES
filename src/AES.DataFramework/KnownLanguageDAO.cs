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
    public class KnownLanguageDAO
    {
        List<SqlParameter> objParameterList = null;
        private string strDBTableName = "KNOWN_LANGUAGE";
        private string strSelectKnownLanguage = "SP_SELECT_KNOWN_LANGUAGE";
        private string strInsertKnownLanguage = "SP_INSERT_KNOWN_LANGUAGE";
        private string strUpdateKnownLanguage = "UDSP_UPDATE_KNOWN_LANGUAGE";
        private string dbExecuteStatus = "";

        public KnownLanguage SelectKnownLanguage(KnownLanguage objKnownLanguage)
        {
            objParameterList = new List<SqlParameter>();
            UDSP_SELECT_KNOWN_LANGUAGE.MEMBER_ID_PARAM(objParameterList, objKnownLanguage.MemberId);

            if (objKnownLanguage.MemberTypeObject != null)
            {
                UDSP_SELECT_KNOWN_LANGUAGE.MEMBER_TYPE_ID_PARAM(objParameterList, objKnownLanguage.MemberTypeObject.MetadataId);
            }
            NEWPARAMETERS.ADDPARAMETERS(objParameterList, "@METADATA_TYPE_ID", objKnownLanguage.DataHolder);
            try
            {
                Logger.LogInfo("KnownLanguageDAO.cs : SelectKnownLanguage() is started.");
                objKnownLanguage.ObjectDataSet = DBMANAGER.GetDataSet(objParameterList, strSelectKnownLanguage, CommandType.StoredProcedure);
                objKnownLanguage.DbOperationStatus = CommonConstant.SUCCEED;
                Logger.LogInfo("KnownLanguageDAO.cs : SelectKnownLanguage() is ended with success.");
            }
            catch (Exception ex)
            {
                objKnownLanguage.DbOperationStatus = CommonConstant.FAIL;
                Logger.LogError(ex.Message);
                Logger.LogInfo("KnownLanguageDAO.cs : SelectKnownLanguage() is ended with error.");
            }
            return objKnownLanguage;
        }
        public KnownLanguage SubmitKnownLanguageData(KnownLanguage objKnownLanguage)
        {
            objParameterList = new List<SqlParameter>();
            UDSP_INSERT_KNOWN_LANGUAGE.MEMBER_ID_PARAM(objParameterList, objKnownLanguage.MemberId);
            UDSP_INSERT_KNOWN_LANGUAGE.MEMBER_TYPE_ID_PARAM(objParameterList, objKnownLanguage.MemberTypeObject.MetadataId);
            UDSP_INSERT_KNOWN_LANGUAGE.LANGUAGE_ID_PARAM(objParameterList, objKnownLanguage.LanguageObject.MetadataId);
            UDSP_INSERT_KNOWN_LANGUAGE.CAN_READ_PARAM(objParameterList, objKnownLanguage.CanRead);
            UDSP_INSERT_KNOWN_LANGUAGE.CAN_WRITE_PARAM(objParameterList, objKnownLanguage.CanWrite);
            UDSP_INSERT_KNOWN_LANGUAGE.CAN_SPEAK_PARAM(objParameterList, objKnownLanguage.CanSpeak);
            try
            {
                Logger.LogInfo("KnownLanguageDAO.cs : SubmitKnownLanguageData() is started.");
                dbExecuteStatus = DBMANAGER.GetScalerValue(objParameterList,  strInsertKnownLanguage, CommandType.StoredProcedure).ToString();
                if (GeneralUtility.IsInteger(dbExecuteStatus))
                {
                    if (Convert.ToInt32(dbExecuteStatus) > 0)
                    {
                        objKnownLanguage.DbOperationStatus = CommonConstant.SUCCEED;
                    }
                    else
                    {
                        objKnownLanguage.DbOperationStatus = CommonConstant.DUPLICATE;
                    }
                    Logger.LogInfo("KnownLanguageDAO.cs : SubmitKnownLanguageData() is ended with success.");
                }
                else
                {
                    objKnownLanguage.DbOperationStatus = CommonConstant.FAIL;
                    Logger.LogInfo(dbExecuteStatus);
                    Logger.LogInfo("KnownLanguageDAO.cs : SubmitKnownLanguageData() is ended with error.");
                }
            }
            catch (Exception ex)
            {
                objKnownLanguage.DbOperationStatus = CommonConstant.FAIL;
                Logger.LogError(ex.Message);
                Logger.LogInfo("KnownLanguageDAO.cs : SubmitKnownLanguageData() is ended with error.");
            }
            return objKnownLanguage;
        }
    }
}
