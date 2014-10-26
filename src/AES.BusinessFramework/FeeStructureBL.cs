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
	public class FeeStructureBL
	{
		private FeeStructureDAO objFeeStructureDAO = null;		

		public FeeStructure SelectFeeStructure(FeeStructure objFeeStructure)
		{
			objFeeStructureDAO= new FeeStructureDAO();
			objFeeStructure = objFeeStructureDAO.SelectFeeStructure(objFeeStructure);
			return objFeeStructure;
		}

		public FeeStructure InsertFeeStructure(FeeStructure objFeeStructure)
		{
            objFeeStructureDAO = new FeeStructureDAO();
            objFeeStructure = objFeeStructureDAO.InsertFeeStructure(objFeeStructure);
            return objFeeStructure;
		}

		public FeeStructure UpdateFeeStructure(FeeStructure objFeeStructure)
		{
            objFeeStructureDAO = new FeeStructureDAO();
            objFeeStructure = objFeeStructureDAO.UpdateFeeStructure(objFeeStructure);
            return objFeeStructure;
		}

		public FeeStructure ActivateDeactivateFeeStructure(FeeStructure objFeeStructure)
		{
			objFeeStructureDAO= new FeeStructureDAO();
			objFeeStructure = objFeeStructureDAO.ActivateDeactivateFeeStructure(objFeeStructure);
			return objFeeStructure;
		}

		public FeeStructure SelectRecordById(FeeStructure objFeeStructure)
		{
			objFeeStructureDAO = new FeeStructureDAO();
			objFeeStructure = objFeeStructureDAO.SelectRecordById(objFeeStructure);
			if (!Convert.ToBoolean(objFeeStructure.IsRecordChanged)
					&& objFeeStructure.DbOperationStatus==CommonConstant.SUCCEED)
			{
				objFeeStructure.ConvertToObjectFromDataset(1);
			}
			return objFeeStructure ;
		}
	}
}
