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
    public class StudentAttendanceDAO
    {
        List<SqlParameter> objParameterList = null;
        private string strDBTableName = "STUDENT_ATTENDANCE";
        private string strSelectStudentAttendance = "SP_SELECT_STUDENT_ATTENDANCE";
        private string strSelectStudentAttendanceSchema = "UDSP_SELECT_STUDENT_ATTENDANCE";
        private string strInsertStudentAttendance = "UDSP_INSERT_STUDENT_ATTENDANCE";
        private string strUpdateStudentAttendance = "UDSP_UPDATE_STUDENT_ATTENDANCE";
        private string dbExecuteStatus = "";

        public StudentAttendance SelectStudentAttendance(StudentAttendance objStudentAttendance)
        {
            objParameterList = new List<SqlParameter>();

            if (objStudentAttendance.ActivityDetailObject != null)
            {
                NEWPARAMETERS.ADDPARAMETERS(objParameterList, "@ACTIVITY_DETAIL_ID", objStudentAttendance.ActivityDetailObject.ActivityDetailId);
                SP_SELECT_STUDENT_ATTENDANCE.RECORD_STATUS_PARAM(objParameterList, objStudentAttendance.StudentObject.RecordStatus);
                NEWPARAMETERS.ADDPARAMETERS(objParameterList, "@ATTENDANCE_METADATA", objStudentAttendance.StudentObject.DataHolder);
            }
            else
            {
                SP_SELECT_STUDENT_ATTENDANCE.SESSION_ID_PARAM(objParameterList, objStudentAttendance.StudentObject.StudentRegistrationObject.RegistrationObject.AcademicSessionObject.SessionId);
                SP_SELECT_STUDENT_ATTENDANCE.BRANCH_ID_PARAM(objParameterList, objStudentAttendance.StudentObject.StudentRegistrationObject.RegistrationObject.BranchObject.BranchId);
                SP_SELECT_STUDENT_ATTENDANCE.CLASS_ID_PARAM(objParameterList, objStudentAttendance.StudentObject.StudentRegistrationObject.RegistrationObject.ClassObject.ClassId);
                if (objStudentAttendance.StudentObject.SectionObject.SectionId != null)
                {
                    SP_SELECT_STUDENT_ATTENDANCE.SECTION_ID_PARAM(objParameterList, objStudentAttendance.StudentObject.SectionObject.SectionId);
                }
                if (objStudentAttendance.StudentObject.StreamObject.StreamId != null)
                {
                    SP_SELECT_STUDENT_ATTENDANCE.STREAM_ID_PARAM(objParameterList, objStudentAttendance.StudentObject.StreamObject.StreamId);
                }
                SP_SELECT_STUDENT_ATTENDANCE.RECORD_STATUS_PARAM(objParameterList, objStudentAttendance.StudentObject.RecordStatus);
                NEWPARAMETERS.ADDPARAMETERS(objParameterList, "@ATTENDANCE_METADATA", objStudentAttendance.StudentObject.DataHolder);
            }

            try
            {
                Logger.LogInfo("StudentAttendanceDAO.cs : SelectStudentAttendance() is started.");
                objStudentAttendance.ObjectDataSet = DBMANAGER.GetDataSet(objParameterList, strSelectStudentAttendance, CommandType.StoredProcedure);
                objStudentAttendance.DbOperationStatus = CommonConstant.SUCCEED;
                Logger.LogInfo("StudentAttendanceDAO.cs : SelectStudentAttendance() is ended with success.");
            }
            catch (Exception ex)
            {
                objStudentAttendance.DbOperationStatus = CommonConstant.FAIL;
                Logger.LogError(ex.Message);
                Logger.LogInfo("StudentAttendanceDAO.cs : SelectStudentAttendance() is ended with error.");
            }
            return objStudentAttendance;
        }
        public StudentAttendance SelectStudentAttendanceSchema(StudentAttendance objStudentAttendance)
        {
            objParameterList = new List<SqlParameter>();
            UDSP_SELECT_STUDENT_ATTENDANCE.ACTIVITY_DETAIL_ID_PARAM(objParameterList, objStudentAttendance.ActivityDetailObject.ActivityDetailId);
            try
            {
                Logger.LogInfo("StudentAttendanceDAO.cs : SelectStudentAttendanceSchema() is started.");
                objStudentAttendance.ObjectDataSet = DBMANAGER.GetDataSet(objParameterList, strSelectStudentAttendanceSchema, CommandType.StoredProcedure);
                objStudentAttendance.DbOperationStatus = CommonConstant.SUCCEED;
                Logger.LogInfo("StudentAttendanceDAO.cs : SelectStudentAttendanceSchema() is ended with success.");
            }
            catch (Exception ex)
            {
                objStudentAttendance.DbOperationStatus = CommonConstant.FAIL;
                Logger.LogError(ex.Message);
                Logger.LogInfo("StudentAttendanceDAO.cs : SelectStudentAttendanceSchema() is ended with error.");
            }
            return objStudentAttendance;
        }
        public StudentAttendance SubmitStudentAttendanceData(StudentAttendance objStudentAttendance)
        {
            objParameterList = new List<SqlParameter>();            
            try
            {
                Logger.LogInfo("StudentAttendanceDAO.cs : SubmitStudentAttendanceData() is started.");
                dbExecuteStatus = DBMANAGER.ExecuteDataSet(objParameterList, objStudentAttendance.ObjectDataSet, strSelectStudentAttendanceSchema, CommandType.StoredProcedure).ToString();
                objStudentAttendance.DbOperationStatus = CommonConstant.SUCCEED;
                Logger.LogInfo("StudentAttendanceDAO.cs : SubmitStudentAttendanceData() is ended with success.");
            }
            catch (Exception ex)
            {
                objStudentAttendance.DbOperationStatus = CommonConstant.FAIL;
                Logger.LogError(ex.Message);
                Logger.LogInfo("StudentAttendanceDAO.cs : SubmitStudentAttendanceData() is ended with error.");
            }
            return objStudentAttendance;
        }

    }
}
