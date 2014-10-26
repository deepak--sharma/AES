using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Transactions;
using AES.SolutionFramework;
using AES.DataFramework;
using AES.ObjectFramework;

namespace AES.BusinessFramework
{
	public class PreviousSchoolEducationMarksDetailBL
	{
		private PreviousSchoolEducationMarksDetailDAO objPreviousSchoolEducationMarksDetailDAO = null;

		public PreviousSchoolEducationMarksDetail SelectPreviousSchoolEducationMarksDetail(PreviousSchoolEducationMarksDetail objPreviousSchoolEducationMarksDetail)
		{
			objPreviousSchoolEducationMarksDetailDAO= new PreviousSchoolEducationMarksDetailDAO();
			objPreviousSchoolEducationMarksDetail = objPreviousSchoolEducationMarksDetailDAO.SelectPreviousSchoolEducationMarksDetail(objPreviousSchoolEducationMarksDetail);
			return objPreviousSchoolEducationMarksDetail;
		}

		public PreviousSchoolEducationMarksDetail SubmitPreviousSchoolEducationMarksDetailData(PreviousSchoolEducationMarksDetail objPreviousSchoolEducationMarksDetail)
		{
			objPreviousSchoolEducationMarksDetailDAO= new PreviousSchoolEducationMarksDetailDAO();
			objPreviousSchoolEducationMarksDetail = objPreviousSchoolEducationMarksDetailDAO.SubmitPreviousSchoolEducationMarksDetailData(objPreviousSchoolEducationMarksDetail);
			return objPreviousSchoolEducationMarksDetail;
		}

	}
}
