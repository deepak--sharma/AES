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
	public class ReservationDetailBL
	{
		private ReservationDetailDAO objReservationDetailDAO = null;
		
        public ReservationDetail GetReservationDetail(ReservationDetail objReservationDetail)
        {
            objReservationDetailDAO = new ReservationDetailDAO();
            objReservationDetail = objReservationDetailDAO.GetReservationDetail(objReservationDetail);
            return objReservationDetail;
        }
        public ReservationDetail GetReservationDetailSchema(ReservationDetail objReservationDetail)
        {
            objReservationDetailDAO = new ReservationDetailDAO();
            objReservationDetail = objReservationDetailDAO.GetReservationDetailSchema(objReservationDetail);
            return objReservationDetail;
        }

		public ReservationDetail SubmitReservationDetailData(ReservationDetail objReservationDetail)
		{
			objReservationDetailDAO= new ReservationDetailDAO();
			objReservationDetail = objReservationDetailDAO.SubmitReservationDetailData(objReservationDetail);
			return objReservationDetail;
		}

	}
}
