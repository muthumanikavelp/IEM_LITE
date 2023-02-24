using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IEM_LITE.BAL;
using IEM_LITE.COMMON;
namespace IEM_LITE.DAL
{
    public class LoginData
    {
        #region
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        int res = 0;
        SQLHelper objSQLHelper = new SQLHelper();
        Common objCMNGeneral = new Common();
        #endregion

        public DataSet GetLoginDetails(LoginModule LoginModule)
        {
            LoginModule obj = new LoginModule();
            try
            {
                CommandType cmdType = CommandType.StoredProcedure;
                objCMNGeneral.strSP = objCMNGeneral.SPValidateLogin;
                SqlParameter[] cmdParms = {
                    
                    new SqlParameter(objCMNGeneral.EmployeeCode, LoginModule.EmployeeCode ?? DBNull.Value.ToString()),
                    new SqlParameter(objCMNGeneral.Password, LoginModule.Password ?? DBNull.Value.ToString()),                  
                };
                ds = objSQLHelper.ExecuteNonQueryReturnDataSet(objCMNGeneral.Dataconnection(LoginModule), cmdType, objCMNGeneral.strSP, cmdParms);

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return ds;
        }


        public DataTable GetPvPeriod(LoginModule LoginModule)
        {
            try
            {
                CommandType cmdType = CommandType.StoredProcedure;
                objCMNGeneral.strSP = objCMNGeneral.SPPVPeriod;
                SqlParameter[] cmdParms = {                                 
                };
                dt = objSQLHelper.ExecuteNonQueryReturnDataTable(objCMNGeneral.Dataconnection(LoginModule), cmdType, objCMNGeneral.strSP, cmdParms);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return dt;
        }


        public DataSet GetBarcodeAssetdetails(LoginModule LoginModule)
        {
            try
            {
                CommandType cmdType = CommandType.StoredProcedure;
                objCMNGeneral.strSP = objCMNGeneral.SPGetBarcodeAssetdetails;
                SqlParameter[] cmdParms = {
                    new SqlParameter(objCMNGeneral.BarcodeNo, LoginModule.BarcodeNo ?? DBNull.Value.ToString()) ,                   
                };
                ds = objSQLHelper.ExecuteNonQueryReturnDataSet(objCMNGeneral.Dataconnection(LoginModule), cmdType, objCMNGeneral.strSP, cmdParms);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return ds;
        }

        public DataSet GetNotBarcodeAssetdetails(LoginModule LoginModule)
        {
            try
            {
                CommandType cmdType = CommandType.StoredProcedure;
                objCMNGeneral.strSP = objCMNGeneral.SPGetNotBarcodeAssetdetails;
                SqlParameter[] cmdParms = {
                    //new SqlParameter(objCMNGeneral.AssetDetailgid, LoginModule.AssetDetailgid ) ,      
                    new SqlParameter(objCMNGeneral.AssetDetailid, LoginModule.AssetDetailid ) ,      
                };
                ds = objSQLHelper.ExecuteNonQueryReturnDataSet(objCMNGeneral.Dataconnection(LoginModule), cmdType, objCMNGeneral.strSP, cmdParms);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return ds;
        }


        public DataTable GetBranchAutoPopulate(LoginModule LoginModule)
        {
            try
            {
                CommandType cmdType = CommandType.StoredProcedure;
                objCMNGeneral.strSP = objCMNGeneral.SPGetAutoPopulateBranchDetails;
                SqlParameter[] cmdParms = {
                    new SqlParameter(objCMNGeneral.Branchcode, LoginModule.Branchcode ?? DBNull.Value.ToString()) ,                   
                };
                dt = objSQLHelper.ExecuteNonQueryReturnDataTable(objCMNGeneral.Dataconnection(LoginModule), cmdType, objCMNGeneral.strSP, cmdParms);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return dt;
        }

        public DataTable GetNotBarcodePopulatedetails1(LoginModule LoginModule)
        {
            try
            {
                CommandType cmdType = CommandType.StoredProcedure;
                objCMNGeneral.strSP = objCMNGeneral.SPGetNotBarcodePopulatedetails;
                SqlParameter[] cmdParms = {
                    new SqlParameter(objCMNGeneral.AssetDetailid, LoginModule.AssetDetailid),                
                                  
                };
                dt = objSQLHelper.ExecuteNonQueryReturnDataTable(objCMNGeneral.Dataconnection(LoginModule), cmdType, objCMNGeneral.strSP, cmdParms);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return dt;
        }

        // Barcode Save
        public DataSet SaveBarcodedetail(LoginModule LoginModule)
        {
            try
            {
                CommandType cmdType = CommandType.StoredProcedure;
                objCMNGeneral.strSP = objCMNGeneral.SPPVInsert;
                SqlParameter[] cmdParms = {
                    new SqlParameter(objCMNGeneral.EmployeeCode, LoginModule.EmployeeCode ?? DBNull.Value.ToString()) ,
                    new SqlParameter(objCMNGeneral.Branchcode, LoginModule.Branchcode ?? DBNull.Value.ToString()) ,
                     new SqlParameter(objCMNGeneral.PvPeriod, LoginModule.PvPeriod ?? DBNull.Value.ToString()) , 
                     new SqlParameter(objCMNGeneral.Barcodeflag, LoginModule.Barcodeflag ?? DBNull.Value.ToString()) ,                     
                    new SqlParameter(objCMNGeneral.AssetPicture, LoginModule.AssetPicture ?? DBNull.Value.ToString()) ,                     
                    new SqlParameter(objCMNGeneral.AssestCode, LoginModule.AssestCode ?? DBNull.Value.ToString()) ,     
                    new SqlParameter(objCMNGeneral.AssetDetailgid, LoginModule.AssetDetailgid ) ,     
                    new SqlParameter(objCMNGeneral.AssestSerialNo, LoginModule.AssestSerialNo ?? DBNull.Value.ToString()) ,
                    new SqlParameter(objCMNGeneral.Make, LoginModule.Make ?? DBNull.Value.ToString()) ,
                    new SqlParameter(objCMNGeneral.Model, LoginModule.Model ?? DBNull.Value.ToString()),  
                    new SqlParameter(objCMNGeneral.Transferstatus,LoginModule.Transferstatus ?? DBNull.Value.ToString()),
                   new SqlParameter(objCMNGeneral.cccode,LoginModule.cccode),
                   new SqlParameter(objCMNGeneral.hsn,LoginModule.hsn),                    
                     };
                ds = objSQLHelper.ExecuteNonQueryReturnDataSet(objCMNGeneral.Dataconnection(LoginModule), cmdType, objCMNGeneral.strSP, cmdParms);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return ds;
        }

        //cc

        public DataTable GetccPopulate(LoginModule LoginModule)
        {
            try
            {
                CommandType cmdType = CommandType.StoredProcedure;
                objCMNGeneral.strSP = objCMNGeneral.SPGetccPopulatedetails;
                SqlParameter[] cmdParms = {
                    new SqlParameter(objCMNGeneral.EmployeeCode, LoginModule.EmployeeCode),                
                                  
                };
                dt = objSQLHelper.ExecuteNonQueryReturnDataTable(objCMNGeneral.Dataconnection(LoginModule), cmdType, objCMNGeneral.strSP, cmdParms);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return dt;
        }

        //HSN

        public DataTable GetHSNPopulate(LoginModule LoginModule)
        {
            try
            {
                CommandType cmdType = CommandType.StoredProcedure;
                objCMNGeneral.strSP = objCMNGeneral.SPGetHSNPopulatedetails;
                SqlParameter[] cmdParms = {
                    new SqlParameter(objCMNGeneral.AssetDetailgid, LoginModule.AssetDetailgid),                
                                  
                };
                dt = objSQLHelper.ExecuteNonQueryReturnDataTable(objCMNGeneral.Dataconnection(LoginModule), cmdType, objCMNGeneral.strSP, cmdParms);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return dt;
        }

        public DataTable GetInsertedAssetDetails(LoginModule LoginModule)
        {
            try
            {
                CommandType cmdType = CommandType.StoredProcedure;
                objCMNGeneral.strSP = objCMNGeneral.SPGetInsertedAssetDetails;
                SqlParameter[] cmdParms = {
                     new SqlParameter(objCMNGeneral.EmployeeCode, LoginModule.EmployeeCode ?? DBNull.Value.ToString()),                    
                };
                dt = objSQLHelper.ExecuteNonQueryReturnDataTable(objCMNGeneral.Dataconnection(LoginModule), cmdType, objCMNGeneral.strSP, cmdParms);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return dt;
        }
        //public DataTable GetEncodedPicture(LoginModule LoginModule)
        //{
        //    try
        //    {
        //        CommandType cmdType = CommandType.StoredProcedure;
        //        objCMNGeneral.strSP = objCMNGeneral.SpGetEncodedPicture;
        //        SqlParameter[] cmdParms = {
        //             new SqlParameter(objCMNGeneral.PvPeriodgid,LoginModule.PvPeriodgid),

        //        };
        //        dt = objSQLHelper.ExecuteNonQueryReturnDataTable(objCMNGeneral.Dataconnection(LoginModule), cmdType, objCMNGeneral.strSP, cmdParms);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //    return dt;
        //}


        public DataSet GetEncodedPicture(LoginModule LoginModule)
        {
            LoginModule obj = new LoginModule();
            try
            {
                CommandType cmdType = CommandType.StoredProcedure;
                objCMNGeneral.strSP = objCMNGeneral.SpGetEncodedPicture;
                SqlParameter[] cmdParms = {                    
                    new SqlParameter(objCMNGeneral.PvPeriodgid,LoginModule.PvPeriodgid),
                             
                };
                ds = objSQLHelper.ExecuteNonQueryReturnDataSet(objCMNGeneral.Dataconnection(LoginModule), cmdType, objCMNGeneral.strSP, cmdParms);

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return ds;
        }
    }
}
