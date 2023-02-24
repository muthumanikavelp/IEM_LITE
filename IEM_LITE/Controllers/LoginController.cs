using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using IEM_LITE.BAL;
using IEM_LITE.DAL;
using System.Data;
using Newtonsoft.Json;
using System.IO;
using System.Web.Configuration;
using System.Configuration;
using System.DirectoryServices;


namespace IEM_LITE.Controllers
{
    public class LoginController : ApiController
    {
        #region Declrations
        LoginData Obj_data = new LoginData();
        LoginModule Obj_model = new LoginModule();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        string Data = string.Empty;
        string Employeecode = string.Empty, Branchcode = string.Empty, EmployeeID = string.Empty,
        Assetcode = string.Empty, AssetSerialNo = string.Empty, AssetDetailgid = string.Empty, Assetgid = string.Empty,
        PvPeriod = string.Empty, Message = string.Empty, URLType = string.Empty, EncodedPicture = string.Empty;
        int Lastgid = 0, result = 0;
        string loginstatus = "";
        string autheticate = "";
        log4net.ILog logger4net = log4net.LogManager.GetLogger(typeof(LoginController));
        #endregion

       
        //[Route("Login")]
        [HttpPost]
        public IHttpActionResult EmployeeLogin([FromBody]LoginModule LoginModule)
        {

            logger4net.Info("Before Try");

            try
            {
                logger4net.Info("Try");
                //string dominName = string.Empty;
                //string adPath = string.Empty;
                //string strError = string.Empty;
                //string LoginFor = System.Configuration.ConfigurationManager.AppSettings["LoginFor"].ToString();
                //string Loginmode = System.Configuration.ConfigurationManager.AppSettings["LoginMode"].ToString();
                //string userName = LoginModule.EmployeeCode;

                //if (LoginFor == "production")
                //{

                //    foreach (string key in System.Configuration.ConfigurationManager.AppSettings.Keys)
                //    {
                //        dominName = key.Contains("DirectoryDomain") ? System.Configuration.ConfigurationManager.AppSettings[key] : dominName;
                //        adPath = key.Contains("DirectoryPath") ? System.Configuration.ConfigurationManager.AppSettings[key] : adPath;
                //        if (!String.IsNullOrEmpty(dominName) && !String.IsNullOrEmpty(adPath))
                //        {
                //            if (true == AuthenticateUser(dominName, userName, LoginModule.Password, adPath, out strError))
                //            {
                //                result = 1;
                //            }
                //            else
                //            {
                //                result = 0;
                //            }
                //            dominName = string.Empty;
                //            adPath = string.Empty;

                //            if (String.IsNullOrEmpty(strError)) break;
                //        }
                //    }
                //    if (!string.IsNullOrEmpty(strError))
                //    {
                //        autheticate = "Invalid user name or Password!";

                //    }
                //    else
                //    {

                //        string IP = string.Empty;
                //        ds = Obj_data.GetLoginDetails(LoginModule);
                //        if (LoginModule.Type == "FICC" && Loginmode == "Self")
                //        {
                //            IP = ConfigurationManager.AppSettings["ficc"].ToString();
                //        }
                //        else if (LoginModule.Type == "HFC" && Loginmode == "Self")
                //        {
                //            IP = ConfigurationManager.AppSettings["hfc"].ToString();
                //        }

                //        if (ds.Tables.Count > 0)
                //        {

                //            EmployeeID = ds.Tables[0].Rows[0][0].ToString();
                //            Employeecode = ds.Tables[0].Rows[0][1].ToString();
                //            Branchcode = ds.Tables[0].Rows[0][2].ToString();
                //            PvPeriod = "Mar19";
                //            URLType = IP;
                //        }
                //        else
                //        {
                //            autheticate = "Invalid user name or Password!";
                //        }
                //    }

                //}

                //else
                //{
                //    string IP = string.Empty;
                //    ds = Obj_data.GetLoginDetails(LoginModule);

                //    if (LoginModule.Type == "FICC")
                //    {
                //        IP = ConfigurationManager.AppSettings["ficc"].ToString();
                //    }
                //    else if (LoginModule.Type == "HFC")
                //    {
                //        IP = ConfigurationManager.AppSettings["hfc"].ToString();
                //    }

                //    if (ds.Tables.Count > 0)
                //    {

                //        EmployeeID = ds.Tables[0].Rows[0][0].ToString();
                //        Employeecode = ds.Tables[0].Rows[0][1].ToString();
                //        Branchcode = ds.Tables[0].Rows[0][2].ToString();
                //        PvPeriod = "Mar19";
                //        URLType = IP;
                //    }
                //}
                logger4net.Info("HI");
                logger4net.Error("Hiii");
                string IP = string.Empty;
                logger4net.Error("Before DB");
                ds = Obj_data.GetLoginDetails(LoginModule);
                logger4net.Error("After DBConcurrencyException");
                if (LoginModule.Type == "FICC")
                {
                    IP = ConfigurationManager.AppSettings["ficc"].ToString();
                }
                else if (LoginModule.Type == "HFC")
                {
                    IP = ConfigurationManager.AppSettings["hfc"].ToString();
                }
                logger4net.Error("IP - " + IP);
                if (ds.Tables.Count > 0)
                {

                    logger4net.Error("Empid - " + ds.Tables[0].Rows[0][0].ToString());

                    EmployeeID = ds.Tables[0].Rows[0][0].ToString();
                    Employeecode = ds.Tables[0].Rows[0][1].ToString();
                    Branchcode = ds.Tables[0].Rows[0][2].ToString();
                    PvPeriod = "Mar19";
                    URLType = IP;
                }
                logger4net.Error("Return - Before Return ");
                return Json(new { EmployeeID, Employeecode, Branchcode, PvPeriod, URLType });

            }
            catch (Exception ex)
            {
                logger4net.Error(ex.ToString());
                throw ex;
            }




        }

        [Route("PVPeriod")]
        [HttpPost]
        public DataTable GetPeriods()
        {
            try
            {
                Stream data = this.Request.Content.ReadAsStreamAsync().Result;
                StreamReader reader = new StreamReader(data);
                string post_data = reader.ReadToEnd();
                Obj_model = (LoginModule)JsonConvert.DeserializeObject(post_data, Obj_model.GetType());
                dt = Obj_data.GetPvPeriod(Obj_model);
                return dt;
            }
            catch (Exception ex)
            {
                logger4net.Error(ex.ToString());
                throw ex;
            }
        }

        [Route("Barcode")]
        [HttpPost]
        public IHttpActionResult Barcode([FromBody]LoginModule LoginModule)
        {
            try
            {


                ds = Obj_data.GetBarcodeAssetdetails(LoginModule);
                if (ds.Tables.Count > 0)
                {
                    Assetcode = ds.Tables[0].Rows[0][0].ToString();
                    AssetSerialNo = ds.Tables[0].Rows[0][1].ToString();
                    AssetDetailgid = ds.Tables[0].Rows[0][2].ToString();
                    Assetgid = ds.Tables[0].Rows[0][3].ToString();
                    Branchcode = ds.Tables[0].Rows[0][4].ToString();
                }
                return Json(new { Assetcode, AssetSerialNo, AssetDetailgid, Assetgid, Branchcode });
            }
            catch (Exception ex)
            {
                logger4net.Error(ex.ToString());
                throw ex;
            }
        }

        [Route("NotBarcode")]
        [HttpPost]
        public IHttpActionResult NotBarcode([FromBody]LoginModule LoginModule)
        {
            try
            {
                ds = Obj_data.GetNotBarcodeAssetdetails(LoginModule);
                if (ds.Tables.Count > 0)
                {
                    AssetSerialNo = ds.Tables[0].Rows[0][0].ToString();
                    Assetcode = ds.Tables[0].Rows[0][1].ToString();
                    AssetDetailgid = ds.Tables[0].Rows[0][2].ToString();
                    Assetgid = ds.Tables[0].Rows[0][3].ToString();
                    Branchcode = ds.Tables[0].Rows[0][4].ToString();
                }
                return Json(new { AssetSerialNo, Assetcode, AssetDetailgid, Assetgid, Branchcode });
            }
            catch (Exception ex)
            {
                logger4net.Error(ex.ToString());
                throw ex;
            }
        }

        [Route("BranchAutoPopulate")]
        [HttpPost]
        public DataTable BranchAutoPopulate()
        {
            try
            {
                Stream data = this.Request.Content.ReadAsStreamAsync().Result;
                StreamReader reader = new StreamReader(data);
                string post_data = reader.ReadToEnd();
                Obj_model = (LoginModule)JsonConvert.DeserializeObject(post_data, Obj_model.GetType());
                dt = Obj_data.GetBranchAutoPopulate(Obj_model);
                return dt;
            }
            catch (Exception ex)
            {
                logger4net.Error(ex.ToString());
                throw ex;
            }
        }

        [Route("NotBarcodePopulate1")]
        [HttpPost]
        public DataTable NotBarcodePopulate1()
        {
            LoginModule obj = new LoginModule();
            DataTable dt = new DataTable();
            try
            {
                Stream data = this.Request.Content.ReadAsStreamAsync().Result;
                StreamReader reader = new StreamReader(data);
                string post_data = reader.ReadToEnd();
                Obj_model = (LoginModule)JsonConvert.DeserializeObject(post_data, Obj_model.GetType());
                dt = Obj_data.GetNotBarcodePopulatedetails1(Obj_model);
                return dt;
            }
            catch (Exception Ex)
            {
                logger4net.Error(Ex.ToString());
                return dt;
            }
        }

        // Barcode Save Details
        [Route("SaveBarcodedetail")]
        [HttpPost]
        public IHttpActionResult SaveBarcodedetail([FromBody]LoginModule LoginModule)
        {
            try
            {
                string IP = string.Empty;

                if (LoginModule.Type == "FICC")
                {
                    IP = ConfigurationManager.AppSettings["ficc"].ToString();
                    ds = Obj_data.SaveBarcodedetail(LoginModule);
                    if (ds.Tables.Count > 0)
                    {
                        Lastgid = Convert.ToInt32(ds.Tables[1].Rows[0][2].ToString());
                        FileSave(LoginModule, Lastgid);
                        result = Convert.ToInt32(ds.Tables[1].Rows[0][0]);
                        Message = ds.Tables[1].Rows[0][1].ToString();
                    }
                }
                else if (LoginModule.Type == "HFC")
                {
                    IP = ConfigurationManager.AppSettings["hfc"].ToString();
                    ds = Obj_data.SaveBarcodedetail(LoginModule);
                    if (ds.Tables.Count > 0)
                    {
                        Lastgid = Convert.ToInt32(ds.Tables[1].Rows[0][2].ToString());
                        FileSave(LoginModule, Lastgid);
                        result = Convert.ToInt32(ds.Tables[1].Rows[0][0]);
                        Message = ds.Tables[1].Rows[0][1].ToString();
                    }
                }


                //ds = Obj_data.SaveBarcodedetail(LoginModule);
                //if (ds.Tables.Count > 0)
                //{
                //    Lastgid = Convert.ToInt32(ds.Tables[1].Rows[0][2].ToString());
                //    FileSave(LoginModule, Lastgid);
                //    result = Convert.ToInt32(ds.Tables[1].Rows[0][0]);
                //    Message = ds.Tables[1].Rows[0][1].ToString();
                //}
                return Json(new { Message, result });
            }
            catch (Exception ex)
            {
                logger4net.Error(ex.ToString());
                throw ex;
            }
        }

        [HttpPost]
        public IHttpActionResult FileSave([FromBody]LoginModule LoginModule, int lastid)
        {
            try
            {
                var path = WebConfigurationManager.AppSettings["FileUpload"];
                string filebase = Convert.ToBase64String(LoginModule.picture);
                byte[] buf = Convert.FromBase64String(filebase);

                File.WriteAllBytes(string.Format(path + "{0}", lastid + ".jpeg"), buf);
                return Content(HttpStatusCode.OK, true);
            }
            catch (Exception ex)
            {
                logger4net.Error(ex.ToString());
                throw ex;
            }
        }

        //CCCode
        [Route("CC")]
        [HttpPost]
        public DataTable CCPopulate()
        {
            try
            {
                Stream data = this.Request.Content.ReadAsStreamAsync().Result;
                StreamReader reader = new StreamReader(data);
                string post_data = reader.ReadToEnd();
                Obj_model = (LoginModule)JsonConvert.DeserializeObject(post_data, Obj_model.GetType());
                dt = Obj_data.GetccPopulate(Obj_model);
                return dt;
            }
            catch (Exception ex)
            {
                logger4net.Error(ex.ToString());
                throw ex;
            }
        }

        //HSNCode
        [Route("HSN")]
        [HttpPost]
        public DataTable HSNPopulate()
        {
            try
            {
                Stream data = this.Request.Content.ReadAsStreamAsync().Result;
                StreamReader reader = new StreamReader(data);
                string post_data = reader.ReadToEnd();
                Obj_model = (LoginModule)JsonConvert.DeserializeObject(post_data, Obj_model.GetType());
                dt = Obj_data.GetHSNPopulate(Obj_model);
                return dt;
            }
            catch (Exception ex)
            {
                logger4net.Error(ex.ToString());
                throw ex;
            }
        }

        //List of AssetDetails
        [Route("GetTotalAssetDetails")]
        [HttpPost]
        public DataTable GetInsertedAssetDetails()
        {
            try
            {
                Stream data = this.Request.Content.ReadAsStreamAsync().Result;
                StreamReader reader = new StreamReader(data);
                string post_data = reader.ReadToEnd();
                Obj_model = (LoginModule)JsonConvert.DeserializeObject(post_data, Obj_model.GetType());
                dt = Obj_data.GetInsertedAssetDetails(Obj_model);
                return dt;
            }
            catch (Exception ex)
            {
                logger4net.Error(ex.ToString());
                throw ex;
            }
        }

        //[Route("GetAssetDetailsEncodedPicture")]
        //[HttpPost]
        //public DataTable GetEncodedPicture()
        //{
        //    try
        //    {
        //        Stream data = this.Request.Content.ReadAsStreamAsync().Result;
        //        StreamReader reader = new StreamReader(data);
        //        string post_data = reader.ReadToEnd();
        //        Obj_model = (LoginModule)JsonConvert.DeserializeObject(post_data, Obj_model.GetType());
        //        dt = Obj_data.GetEncodedPicture(Obj_model);
        //        return dt;
        //    }
        //    catch (Exception ex)
        //    {
        //        logger4net.Error(ex.ToString());
        //        throw ex;
        //    }
        //}


        [Route("GetAssetDetailsEncodedPicture")]
        [HttpPost]
        public IHttpActionResult GetEncodedPicture([FromBody]LoginModule LoginModule)
        {
            try
            {
                Stream data = this.Request.Content.ReadAsStreamAsync().Result;
                StreamReader reader = new StreamReader(data);
                string post_data = reader.ReadToEnd();
                Obj_model = (LoginModule)JsonConvert.DeserializeObject(post_data, Obj_model.GetType());
                ds = Obj_data.GetEncodedPicture(LoginModule);
                if (ds.Tables.Count > 0)
                {
                    EncodedPicture = ds.Tables[0].Rows[0][0].ToString();
                }
                return Json(new { EncodedPicture });

            }
            catch (Exception ex)
            {
                logger4net.Error(ex.ToString());
                throw ex;
            }
        }


        public bool AuthenticateUser(string domain, string username, string password, string LdapPath, out string Errmsg)
        {
            Errmsg = "";
            string domainAndUsername = domain + @"\" + username;
            DirectoryEntry entry = new DirectoryEntry(LdapPath, domainAndUsername, password);
            try
            {
                // Bind to the native AdsObject to force authentication.
                Object obj = entry.NativeObject;
                DirectorySearcher search = new DirectorySearcher(entry);
                search.Filter = "(SAMAccountName=" + username + ")";
                search.PropertiesToLoad.Add("cn");
                SearchResult result = search.FindOne();
                if (null == result)
                {
                    return false;
                }

                LdapPath = result.Path;
                string _filterAttribute = (String)result.Properties["cn"][0];
            }
            catch (Exception ex)
            {
                Errmsg = ex.Message;
                //objErrorLog.WriteErrorLog(ex.Message.ToString(), ex.ToString());
                return false;

            }
            return true;
        }




    }
}
