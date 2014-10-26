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

public class UserDataKeys
{
	public const string EMPLOYEEJOININGDETAIL_EMPLOYEEID = "EMPLOYEEJOININGDETAIL_EMPLOYEEID_DATA";
	public const string REPORTINGDETAIL_EMPLOYEEID = "REPORTINGDETAIL_EMPLOYEEID_DATA";
	public const string SKILLDETAIL_MEMBERID = "SKILLDETAIL_MEMBERID_DATA";
	public const string KNOWNLANGUAGE_MEMBERID = "KNOWNLANGUAGE_MEMBERID_DATA";
	public const string IMMIGRATIONDETAIL_MEMBERID = "IMMIGRATIONDETAIL_MEMBERID_DATA";
	public const string LICENCEDETAIL_MEMBERID = "LICENCEDETAIL_MEMBERID_DATA";
	public const string EMPLOYEEPREVIOUSORGANISATIONDETAIL_EMPLOYEEID = "EMPLOYEEPREVIOUSORGANISATIONDETAIL_EMPLOYEEID_DATA";
	public const string EMPLOYEEFAMILYDETAIL_EMPLOYEEID = "EMPLOYEEFAMILYDETAIL_EMPLOYEEID_DATA";
	public const string EMPLOYEEEDUCATIONALDETAIL_EMPLOYEEID = "EMPLOYEEEDUCATIONALDETAIL_EMPLOYEEID_DATA";
	public const string EMPLOYEEMEDICALDETAIL_EMPLOYEEID = "EMPLOYEEMEDICALDETAIL_EMPLOYEEID_DATA";
	public const string PREVIOUSSCHOOLEDUCATIONMARKSDETAIL_PREVIOUSSCHOOLEDUCATIONID = "PREVIOUSSCHOOLEDUCATIONMARKSDETAIL_PREVIOUSSCHOOLEDUCATIONID_DATA";
	public const string RESERVATIONDETAIL_REGISTRATIONID = "RESERVATIONDETAIL_REGISTRATIONID_DATA";
	public const string REGISTRATIONELIGIBILITY_REGISTRATIONID = "REGISTRATIONELIGIBILITY_REGISTRATIONID_DATA";
    public const string SIBLINGDETAIL_CANDIDATEID = "SIBLINGDETAIL_CANDIDATEID_DATA";
    public const string PREVIOUSSCHOOLDETAIL_CANDIDATEID = "PREVIOUSSCHOOLDETAIL_CANDIDATEID_DATA";
    public const string PREVIOUSSCHOOLDETAIL_REGISTRATIONID = "PREVIOUSSCHOOLDETAIL_REGISTRATIONID_DATA";
    public const string STUDENTATTENDANCE_ACTIVITYDETAILID = "STUDENTATTENDANCE_ACTIVITYDETAILID_DATA";
    public const string FEESCHEDULEDETAIL_FEESCHEDULEID = "FEESCHEDULEDETAIL_FEESCHEDULEID_DATA";
    public const string LATEFEEDETAIL_DATA = "LATEFEEDETAIL_DATA";
    public static readonly string UPLOADED_IMAGE = "UPLOADED_IMAGE_DATA";
}