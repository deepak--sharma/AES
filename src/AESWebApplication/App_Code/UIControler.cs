using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using AES.BusinessFramework;
using AES.ObjectFramework;
using AES.SolutionFramework;

/// <summary>
/// Summary description for UIControler
/// </summary>
public class UIController
{
    public const string META_DATA = "META_DATA";
    private static AddressDetail objAddressDetail = null;
    private static AddressDetailBL objAddressDetailBL = null;
    private static StateMaster objStateMaster = null;
    private static StateMasterBL objStateMasterBL = null;
    private static CityMaster objCityMaster = null;
    private static CityMasterBL objCityMasterBL = null;
    private static MetadataMaster objMetadataMaster = null;
    private static MetadataMasterBL objMetadataMasterBL = null;

    public UIController()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static void BindAddressDetailDDLs(DropDownList ddlCountryMaster, DropDownList ddlStateMaster, DropDownList ddlCityMaster, int? cityId)
    {
        objAddressDetail = new AddressDetail();
        objAddressDetailBL = new AddressDetailBL();
        objAddressDetail.RecordStatus = Convert.ToInt16(RecordStatus.Active);
        objAddressDetail.CountryObject = new CountryMaster();
        objAddressDetail.CountryObject.CountryId = BusinessController.DEFAULT_COUNTRY_ID;
        objAddressDetail.StateObject = new StateMaster();
        objAddressDetail.CityObject = new CityMaster();
        objAddressDetail.CityObject.CityId = cityId;
        objAddressDetail = objAddressDetailBL.SelectDefaultCoutryStateCity(objAddressDetail);

        if (objAddressDetail.DbOperationStatus == CommonConstant.SUCCEED)
        {
            ddlCountryMaster.SelectedIndex = -1;
            ddlCountryMaster.DataSource = objAddressDetail.ObjectDataSet.Tables[0];
            ddlCountryMaster.DataBind();
            ddlCountryMaster.Items.Insert(0, UIUtility.DEFAULT_DDL_VALUE);
            UIUtility.SelectCurrentListItem(ddlCountryMaster, objAddressDetail.CountryObject.CountryId, BindListItem.ByValue, true);

            ddlStateMaster.SelectedIndex = -1;
            ddlStateMaster.DataSource = objAddressDetail.ObjectDataSet.Tables[1];
            ddlStateMaster.DataBind();
            ddlStateMaster.Items.Insert(0, UIUtility.DEFAULT_DDL_VALUE);
            UIUtility.SelectCurrentListItem(ddlStateMaster, objAddressDetail.StateObject.StateId, BindListItem.ByValue, true);

            ddlCityMaster.SelectedIndex = -1;
            ddlCityMaster.DataSource = objAddressDetail.ObjectDataSet.Tables[2];
            ddlCityMaster.DataBind();
            ddlCityMaster.Items.Insert(0, UIUtility.DEFAULT_DDL_VALUE);
            UIUtility.SelectCurrentListItem(ddlCityMaster, objAddressDetail.CityObject.CityId, BindListItem.ByValue, true);
        }
        else
        {
            throw new Exception("An error has occurred while binding address Drop Down List.");
        }

    }

    public static void BindStateMasterDDL(DropDownList ddlStateMaster, StateMaster objStateMaster)
    {
        objStateMasterBL = new StateMasterBL();
        objStateMaster = objStateMasterBL.SelectStateMaster(objStateMaster);

        if (objStateMaster.DbOperationStatus == CommonConstant.SUCCEED)
        {
            ddlStateMaster.SelectedIndex = -1;
            ddlStateMaster.DataSource = objStateMaster.ObjectDataSet.Tables[0];
            ddlStateMaster.DataBind();
            ddlStateMaster.Items.Insert(0, UIUtility.DEFAULT_DDL_VALUE);
        }
        else
        {
            throw new Exception("An error has occurred while binding State Master Drop Down List.");
        }
    }

    public static void BindCityMasterDDL(DropDownList ddlCityMaster, CityMaster objCityMaster)
    {
        objCityMasterBL = new CityMasterBL();        
        objCityMaster = objCityMasterBL.SelectCityMaster(objCityMaster);

        if (objCityMaster.DbOperationStatus == CommonConstant.SUCCEED)
        {
            ddlCityMaster.SelectedIndex = -1;
            ddlCityMaster.DataSource = objCityMaster.ObjectDataSet.Tables[0];
            ddlCityMaster.DataBind();
            ddlCityMaster.Items.Insert(0, UIUtility.DEFAULT_DDL_VALUE);
        }
        else
        {
            throw new Exception("An error has occured while binding City Master Drop Down List.");
        }
    }

    public static void BindMetadataDDL(DropDownList ddlMetadata, MetadataTypeEnum objMetadataType)
    {
        ddlMetadata.DataSource = GetMetaData(objMetadataType);
        ddlMetadata.DataBind();
        ddlMetadata.Items.Insert(0, UIUtility.DEFAULT_DDL_VALUE);
    }

    private static DataTable GetMetaData(MetadataTypeEnum metadataType)
    {
        DataTable dtMetadata;
        dtMetadata = (DataTable)(UIUtility.ReadFromCache(META_DATA));

        //If meta data is not in cache then get from database
        if (dtMetadata == null || dtMetadata.Rows.Count == 0)
        {
            MetadataMasterBL objMetadataMasterBL = new MetadataMasterBL();
            MetadataMaster objMetadataMaster = new MetadataMaster();
            objMetadataMaster.RecordStatus = Convert.ToInt16(RecordStatus.Active);
            objMetadataMaster = objMetadataMasterBL.SelectMetadataMaster(objMetadataMaster);
            dtMetadata = objMetadataMaster.ObjectDataSet.Tables[0];
            //'Add to cache
            UIUtility.AddToCache(META_DATA, dtMetadata);
        }

        dtMetadata.DefaultView.RowFilter = "METADATA_TYPE_ID = " + Convert.ToInt32(metadataType);
        return dtMetadata.DefaultView.ToTable();

    }
}
