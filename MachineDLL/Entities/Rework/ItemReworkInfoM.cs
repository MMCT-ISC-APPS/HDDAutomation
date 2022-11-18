using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineDLL.Entities
{
   public class ItemReworkInfoM  : ReworkInfoM 
    {
        public String OldJobname { get; set; }
        public String OldModel { get; set; }
        public String OldPartNo { get; set; }
        public String SerialNo { get; set; }
        public String En { get; set; }
        public String reworkmodelid { get; set; }
        public DateTime ReworkDate { get; set; }
        public String Customer { get; set; }
        public Image imgPanel { get; set; }
        public String Model { get; set; }
        public String LotNo { get; set; }
        public int ReworkID { get; set; }
        public Byte[] BytePic { get; set; }        
        public List<ReworkCriteriaM> ReworkCriteria { get; set; }
        public List<ReworkCriteriaM> DisplayReworkCriteria { get; set; }
        public List<ReworkInfoM> PartsRework { get; set; }

    }
}
