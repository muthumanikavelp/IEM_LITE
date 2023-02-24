using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEM_LITE.BAL
{
    public class LoginModule
    {
        public string EmployeeCode { get; set; }
        public string Password { get; set; }
        public string BarcodeNo { get; set; }
        public Int64 AssetDetailgid { get; set; }
        public string AssetDetailid { get; set; }
        public string Branchcode { get; set; }
        public string PvPeriod { get; set; }
        public string Barcodeflag { get; set; }
        public string AssetPicture { get; set; }
        public string AssestCode { get; set; }
        public string AssestSerialNo { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Type { get; set; }
        public string Assetgid { get; set; }
        public byte[] picture { get; set; }
        public string Transferstatus { get; set; }
        public int PvPeriodgid { get; set; }
        public int cccode { get; set; }
        public int hsn { get; set; }
        public string LoginMode { get; set; }

    }
}
