using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineDLL.Entities
{
    public class PrintinfoM : EntityBase
    {        
        public String Serialno { get; set; }     
        public String PanelID { get; set; }
        public DateTime  TestDate { get; set; }
        public String TestResult { get; set; }
        public int Printlocation { get; set; }
        public String TestNo { get; set; }
        public String PackingNo { get; set; }
        public String ScanGrade { get; set; }
        public String ScanResult { get; set; }
        public String Customer { get; set; }
        public String Score { get; set; }
        public int Sequence { get; set; }
        public String Result { get; set; }
    }
}
