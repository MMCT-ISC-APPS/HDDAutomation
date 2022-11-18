using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MachineDLL.Entities
{
    public  class  ReworkInfoM
    {
        public Int32 LocationX { get; set; }
        public Int32 LocationY { get; set; }                
        public String PartNo { get; set; }
        public String JobName { get; set; }
        public String Position { get; set; }
        public String CriteriaName { get; set; }
        public String GetCriteriaData { get; set; }

    }
}
