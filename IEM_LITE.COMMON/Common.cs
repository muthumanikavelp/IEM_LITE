using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using IEM_LITE.BAL;

namespace IEM_LITE.COMMON
{

    public class Common
    {
        public string objConnection;// = ConfigurationManager.ConnectionStrings["SQLMSDBHFC"].ConnectionString;
        //public string objConnection_FICC = ConfigurationManager.ConnectionStrings["SQLMSDBFICC"].ConnectionString;

        #region Strored Procedure CURD
        public string strSP = "";

        public readonly string SPValidateLogin = "SP_Validate_Login";
        public readonly string SPGetBarcodeAssetdetails = "SP_Get_AssetDetails";
        public readonly string SPGetNotBarcodeAssetdetails = "SP_Get_NotBarcodeAssetDetails";
        public readonly string SPGetNotBarcodePopulatedetails = "SP_Get_NotBarcodePopulateDetails";
        public readonly string SPGetAutoPopulateBranchDetails = "SP_Get_BranchCodeAutoPopulateDetails";
        public readonly string SPPVInsert = "SP_Insert_fa_trn_tpvperiodreport";
        public readonly string SPPVPeriod = "SP_Get_PVPeriod";
        public readonly string SPGetccPopulatedetails = "Sp_Get_CCDetails";
        public readonly string SPGetHSNPopulatedetails = "Sp_Get_HSNdetails";
        public readonly string SPGetInsertedAssetDetails = "SP_Get_InsertedAssetDetails";
        public readonly string SpGetEncodedPicture = "SP_Get_EncodedPicture";
        #endregion

        #region Stored Procedure Params
        public readonly string EmployeeCode = "@EmployeeCode";
        public readonly string Password = "@Password";
        public readonly string PvPeriod = "@Period";
        public readonly string BarcodeNo = "@BarcodeNo";
        public readonly string AssetDetailgid = "@Assetgid";
        public readonly string AssetDetailid = "@Assetid";
        public readonly string Branchcode = "@BranchCode";
        public readonly string Barcodeflag = "@Isbarcoded";
        public readonly string AssetPicture = "@AssetPicture";
        public readonly string AssestCode = "@AssetCode";
        public readonly string AssestSerialNo = "@AssestSerialNo";
        public readonly string Make = "@Make";
        public readonly string Model = "@Model";
        public readonly string Transferstatus = "@Transferstatus";
        public readonly string cccode = "@cc_gid";
        public readonly string hsn = "@hsn_gid";
        public readonly string PvPeriodgid = "@pvperiodrpt_gid";


        #endregion

        #region Operation Type(CURD)
        public readonly string Create = "C";
        public readonly string Read = "R";
        public readonly string Update = "U";
        public readonly string Delete = "D";
        #endregion

        public string Dataconnection(LoginModule Obj)
        {           
            if (Obj.Type == "FICC")
            {
                objConnection = ConfigurationManager.ConnectionStrings["SQLMSDBFICC"].ConnectionString;              
            }
            else if (Obj.Type == "HFC")
            {
                objConnection = ConfigurationManager.ConnectionStrings["SQLMSDBHFC"].ConnectionString;
               
            }
            return objConnection;
        }
    }

}
