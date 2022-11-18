using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineDLL.Entities
{
    public class BundleInfoM : EntityBase
    {
        public string BundleNo { get; set; }
        public Int64 BundleID { get; set; }
        public Int64 StandardSize { get; set; } 
        public Int64 TotalQty { get; set; }
        public Int64 TotalJob { get; set; }
        public Int64 Traysize { get; set; }
        public Int64 PackCounter { get; set; }
        public Int64 GoodQty { get; set; }
        public Int64 NGQty { get; set; }
        public string PrefixCustomer { get; set; }        
        public string UserName { get; set; }
        public string PrimaryUOM { get; set; }
        public string TempSerialno { get; set; }
        public string Grade { get; set; }
        public Int64 PrintCopy { get; set; }
        public IList<JobinfoM> JobBuildInfo { get; set; }
        public IList<PrintinfoM > Serials { get; set; }
        public string SIBundle { get; set; }


    }
}
