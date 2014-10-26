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
	public class MetadataMasterBL
	{
		private MetadataMasterDAO objMetadataMasterDAO = null;

		public MetadataMaster SelectMetadataMaster(MetadataMaster objMetadataMaster)
		{
			objMetadataMasterDAO= new MetadataMasterDAO();
			objMetadataMaster = objMetadataMasterDAO.SelectMetadataMaster(objMetadataMaster);
			return objMetadataMaster;
		}

		public MetadataMaster InsertMetadataMaster(MetadataMaster objMetadataMaster)
		{
			objMetadataMasterDAO= new MetadataMasterDAO();
			objMetadataMaster = objMetadataMasterDAO.InsertMetadataMaster(objMetadataMaster);
			return objMetadataMaster;
		}

		public MetadataMaster UpdateMetadataMaster(MetadataMaster objMetadataMaster)
		{
			objMetadataMasterDAO= new MetadataMasterDAO();
			objMetadataMaster = objMetadataMasterDAO.UpdateMetadataMaster(objMetadataMaster);
			return objMetadataMaster;
		}

		public MetadataMaster ActivateDeactivateMetadataMaster(MetadataMaster objMetadataMaster)
		{
			objMetadataMasterDAO= new MetadataMasterDAO();
			objMetadataMaster = objMetadataMasterDAO.ActivateDeactivateMetadataMaster(objMetadataMaster);
			return objMetadataMaster;
		}

		public MetadataMaster SelectRecordById(MetadataMaster objMetadataMaster)
		{
			objMetadataMasterDAO = new MetadataMasterDAO();
			objMetadataMaster = objMetadataMasterDAO.SelectRecordById(objMetadataMaster);
			if (!Convert.ToBoolean(objMetadataMaster.IsRecordChanged)
					&& objMetadataMaster.DbOperationStatus==CommonConstant.SUCCEED)
			{
				objMetadataMaster.ConvertToObjectFromDataset(1);
			}
			return objMetadataMaster ;
		}
	}
}
