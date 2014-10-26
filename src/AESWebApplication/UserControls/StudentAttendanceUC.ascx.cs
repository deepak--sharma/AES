using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using AES.SolutionFramework;
using AES.BusinessFramework;
using AES.ObjectFramework;

public partial class StudentAttendanceUC : System.Web.UI.UserControl
{
    #region Page Variables
    StudentAttendance objStudentAttendance = null;
    StudentAttendanceBL objStudentAttendanceBL = null;
    StudentDetail objStudentDetail = null;
    StudentDetailBL objStudentDetailBL = null;
    MetadataMaster objMetadataMaster = null;
    MetadataMasterBL objMetadataMasterBL = null;
    EmployeeDetail objEmployeeDetail = null;
    EmployeeDetailBL objEmployeeDetailBL = null;
    private const int STUDENT_ID_INDEX = 0;
    string StartDate, EndDate;

    #endregion

    #region Page Events and Functions
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    public void InitializeUserControl(StudentDetail objStudentDetail,string strStartDate,string strEndDate)
    {
        StartDate = strStartDate;
        EndDate = strEndDate;
        objStudentAttendanceBL = new StudentAttendanceBL();
        objStudentAttendance = new StudentAttendance();
        objStudentAttendance.StudentObject = objStudentDetail; 

        objStudentAttendance = objStudentAttendanceBL.SelectStudentAttendance(objStudentAttendance);
        grdStudentAttendance.DataSource = objStudentAttendance.ObjectDataSet.Tables[0];
        grdStudentAttendance.DataBind();      

    }
    #endregion
    #region Grid Events....
    protected void grdStudentAttendance_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        DataTable objTable = objStudentAttendance.ObjectDataSet.Tables[1];
        DataTable objAttendanceTable = objStudentAttendance.ObjectDataSet.Tables[0];

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DropDownList ddlAttendanceStatus = e.Row.FindControl("ddlAttendanceStatus") as DropDownList;
            ddlAttendanceStatus.DataSource = objTable;
            ddlAttendanceStatus.DataBind();
            if (objAttendanceTable.Rows[e.Row.RowIndex]["ATTENDANCE_STATUS_ID"] == DBNull.Value)
            {
                ddlAttendanceStatus.SelectedValue = AttendanceStatus.Present.ToString();
                TextBox txtStartDate = e.Row.FindControl("txtInTime") as TextBox;
                txtStartDate.Text = StartDate;
                TextBox txtEndDate = e.Row.FindControl("txtOutTime") as TextBox;
                txtEndDate.Text = EndDate;
            }
            else
            {
                ddlAttendanceStatus.SelectedValue = objAttendanceTable.Rows[e.Row.RowIndex]["ATTENDANCE_STATUS_ID"].ToString();
                TextBox txtStartDate = e.Row.FindControl("txtInTime") as TextBox;
                txtStartDate.Text = objAttendanceTable.Rows[e.Row.RowIndex]["IN_TIME"].ToString(); 
                TextBox txtEndDate = e.Row.FindControl("txtOutTime") as TextBox;
                txtEndDate.Text = objAttendanceTable.Rows[e.Row.RowIndex]["OUT_TIME"].ToString();
                TextBox txtComments = e.Row.FindControl("txtComments") as TextBox;
                txtComments.Text = objAttendanceTable.Rows[e.Row.RowIndex]["COMMENTS"].ToString(); 
            }            
        }
    }
    #endregion
    #region Helper Functions  
    public DataSet GetStudentAttendanceData(int? _activityId)
    {
        objStudentAttendanceBL = new StudentAttendanceBL();
        objStudentAttendance = new StudentAttendance();
        objStudentAttendance.ActivityDetailObject=new ActivityDetail();
        objStudentAttendance.ActivityDetailObject.ActivityDetailId = _activityId;
        objStudentAttendance = objStudentAttendanceBL.SelectStudentAttendanceSchema(objStudentAttendance);

        DataTable objAttendanceTable = objStudentAttendance.ObjectDataSet.Tables[0];
        bool hasRows = (objAttendanceTable.Rows.Count > 0);
        foreach (GridViewRow objRow in grdStudentAttendance.Rows)
        {
            DataRow objDataRow;
            if (!hasRows)
            {
                objDataRow = objAttendanceTable.NewRow();
            }
            else
            {
                objDataRow = objAttendanceTable.Rows[objRow.RowIndex];
            }
            objDataRow["Student_Id"] = Convert.ToInt32(grdStudentAttendance.DataKeys[Convert.ToInt32(objRow.RowIndex)].Values[STUDENT_ID_INDEX].ToString());
            objDataRow["Attendance_status_Id"] = Convert.ToInt32((objRow.FindControl("ddlAttendanceStatus") as DropDownList).SelectedValue);
            objDataRow["Attendance_Date"] = GeneralUtility.CurrentDateTime;
            objDataRow["In_Time"] = (objRow.FindControl("txtInTime") as TextBox).Text;
            objDataRow["Out_Time"] = (objRow.FindControl("txtOutTime") as TextBox).Text;
            //objDataRow["Marked_By"] = 1; //To add current logged in User Id
            objDataRow["Comments"] = (objRow.FindControl("txtComments") as TextBox).Text;
            if (!hasRows)
            {
                objAttendanceTable.Rows.Add(objDataRow);
            }
        }

        return objAttendanceTable.DataSet;
    }

    public void SetUserControlData(ActivityDetail objActivityDetail)
    {
        objStudentAttendanceBL = new StudentAttendanceBL();
        objStudentAttendance = new StudentAttendance();
        objStudentAttendance.ActivityDetailObject = objActivityDetail;
        objStudentAttendance.StudentObject = new StudentDetail();
        objStudentAttendance.StudentObject.RecordStatus = Convert.ToInt32(RecordStatus.Active);
        objStudentAttendance.StudentObject.DataHolder = Convert.ToInt32(MetadataTypeEnum.AttendanceStatus).ToString();       

        objStudentAttendance = objStudentAttendanceBL.SelectStudentAttendance(objStudentAttendance);
        grdStudentAttendance.DataSource = objStudentAttendance.ObjectDataSet.Tables[0];
        grdStudentAttendance.DataBind();  
    }
    #endregion
    
}
