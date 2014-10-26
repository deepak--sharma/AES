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
    public class AddressDetailBL
    {
        private AddressDetailDAO objAddressDetailDAO = null;

        public AddressDetail SelectAddressDetail(AddressDetail objAddressDetail)
        {
            objAddressDetailDAO = new AddressDetailDAO();
            objAddressDetail = objAddressDetailDAO.SelectAddressDetail(objAddressDetail);
            return objAddressDetail;
        }

        public AddressDetail InsertAddressDetail(AddressDetail objAddressDetail)
        {
            objAddressDetailDAO = new AddressDetailDAO();
            objAddressDetail = objAddressDetailDAO.InsertAddressDetail(objAddressDetail);
            return objAddressDetail;
        }

        public AddressDetail UpdateAddressDetail(AddressDetail objAddressDetail)
        {
            objAddressDetailDAO = new AddressDetailDAO();
            objAddressDetail = objAddressDetailDAO.UpdateAddressDetail(objAddressDetail);
            return objAddressDetail;
        }

        public AddressDetail SelectRecordById(AddressDetail objAddressDetail)
        {
            objAddressDetailDAO = new AddressDetailDAO();
            objAddressDetail = objAddressDetailDAO.SelectRecordById(objAddressDetail);
            if (!Convert.ToBoolean(objAddressDetail.IsRecordChanged)
                    && objAddressDetail.DbOperationStatus == CommonConstant.SUCCEED)
            {
                objAddressDetail.ConvertToObjectFromDataset(1);
            }
            return objAddressDetail;
        }

        public AddressDetail SelectDefaultCoutryStateCity(AddressDetail objAddressDetail)
        {
            objAddressDetailDAO = new AddressDetailDAO();
            objAddressDetail = objAddressDetailDAO.SelectDefaultCoutryStateCity(objAddressDetail);
            return objAddressDetail;
        }

        public AddressDetail EditEmployeeContactInfo(AddressDetail objCurrentAddress, AddressDetail objPermanentAddress,
            EmergencyDetail objPrimaryEmergencyDetail, EmergencyDetail objSecondryEmergencyDetail)
        {
            objAddressDetailDAO = new AddressDetailDAO();
            EmergencyDetailDAO objEmergencyDetailDAO = new EmergencyDetailDAO();
            using (TransactionScope objTransactionScope = new TransactionScope())
            {
                objCurrentAddress = objAddressDetailDAO.EditEmployeeAddress(objCurrentAddress);
                if (objCurrentAddress.DbOperationStatus != CommonConstant.SUCCEED)
                {
                    return objCurrentAddress;
                }

                objPermanentAddress = objAddressDetailDAO.EditEmployeeAddress(objPermanentAddress);
                if (objPermanentAddress.DbOperationStatus != CommonConstant.SUCCEED)
                {
                    objCurrentAddress.DbOperationStatus = objPermanentAddress.DbOperationStatus;
                    return objCurrentAddress;
                }
                objPrimaryEmergencyDetail = objEmergencyDetailDAO.EditEmployeeEmergencyDetail(objPrimaryEmergencyDetail);
                if (objPrimaryEmergencyDetail.DbOperationStatus != CommonConstant.SUCCEED)
                {
                    objCurrentAddress.DbOperationStatus = objPrimaryEmergencyDetail.DbOperationStatus;
                    return objCurrentAddress;
                }
                objSecondryEmergencyDetail = objEmergencyDetailDAO.EditEmployeeEmergencyDetail(objSecondryEmergencyDetail);
                if (objSecondryEmergencyDetail.DbOperationStatus != CommonConstant.SUCCEED)
                {
                    objCurrentAddress.DbOperationStatus = objSecondryEmergencyDetail.DbOperationStatus;
                    return objCurrentAddress;
                }

                objTransactionScope.Complete();
            }

            return objCurrentAddress;
        }

        public AddressDetail SaveEmployeeContactInfo(AddressDetail objCurrentAddress, AddressDetail objPermanentAddress,
             EmergencyDetail objPrimaryEmergencyDetail, EmergencyDetail objSecondryEmergencyDetail)
        {
            objAddressDetailDAO = new AddressDetailDAO();
            EmergencyDetailDAO objEmergencyDetailDAO = new EmergencyDetailDAO();
            using (TransactionScope objTransactionScope = new TransactionScope())
            {
                objCurrentAddress = objAddressDetailDAO.SaveEmployeeAddress(objCurrentAddress);
                if (objCurrentAddress.DbOperationStatus != CommonConstant.SUCCEED)
                {
                    return objCurrentAddress;
                }

                objPermanentAddress = objAddressDetailDAO.SaveEmployeeAddress(objPermanentAddress);
                if (objPermanentAddress.DbOperationStatus != CommonConstant.SUCCEED)
                {
                    objCurrentAddress.DbOperationStatus = objPermanentAddress.DbOperationStatus;
                    return objCurrentAddress;
                }
                objPrimaryEmergencyDetail = objEmergencyDetailDAO.SaveEmployeeEmergencyDetail(objPrimaryEmergencyDetail);
                if (objPrimaryEmergencyDetail.DbOperationStatus != CommonConstant.SUCCEED)
                {
                    objCurrentAddress.DbOperationStatus = objPrimaryEmergencyDetail.DbOperationStatus;
                    return objCurrentAddress;
                }
                objSecondryEmergencyDetail = objEmergencyDetailDAO.SaveEmployeeEmergencyDetail(objSecondryEmergencyDetail);
                if (objSecondryEmergencyDetail.DbOperationStatus != CommonConstant.SUCCEED)
                {
                    objCurrentAddress.DbOperationStatus = objSecondryEmergencyDetail.DbOperationStatus;
                    return objCurrentAddress;
                }

                objTransactionScope.Complete();
            }

            return objCurrentAddress;
        }
    }
}
