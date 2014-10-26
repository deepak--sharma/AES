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
	public class MetadataTypeBL
	{
		private MetadataTypeDAO objMetadataTypeDAO = null;

		public MetadataType SelectMetadataType(MetadataType objMetadataType)
		{
			objMetadataTypeDAO= new MetadataTypeDAO();
			objMetadataType = objMetadataTypeDAO.SelectMetadataType(objMetadataType);
			return objMetadataType;
		}

		public MetadataType InsertMetadataType(MetadataType objMetadataType)
		{
			objMetadataTypeDAO= new MetadataTypeDAO();
			objMetadataType = objMetadataTypeDAO.InsertMetadataType(objMetadataType);
			return objMetadataType;
		}

		public MetadataType UpdateMetadataType(MetadataType objMetadataType)
		{
			objMetadataTypeDAO= new MetadataTypeDAO();
			objMetadataType = objMetadataTypeDAO.UpdateMetadataType(objMetadataType);
			return objMetadataType;
		}

		public MetadataType ActivateDeactivateMetadataType(MetadataType objMetadataType)
		{
			objMetadataTypeDAO= new MetadataTypeDAO();
			objMetadataType = objMetadataTypeDAO.ActivateDeactivateMetadataType(objMetadataType);
			return objMetadataType;
		}

		public MetadataType SelectRecordById(MetadataType objMetadataType)
		{
			objMetadataTypeDAO = new MetadataTypeDAO();
			objMetadataType = objMetadataTypeDAO.SelectRecordById(objMetadataType);
			if (!Convert.ToBoolean(objMetadataType.IsRecordChanged)
					&& objMetadataType.DbOperationStatus==CommonConstant.SUCCEED)
			{
				objMetadataType.ConvertToObjectFromDataset(1);
			}
			return objMetadataType ;
		}
	}
}
