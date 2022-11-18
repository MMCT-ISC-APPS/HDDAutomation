using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineDLL.Entities.AutoDictate
{
    public class AutoDictLayoutM : BaseDate
    {
        public int LayoutID { get; set; }
        public string LayoutName { get; set; }
        public string LayoutContext { get; set; }
        public string LayoutFileName { get; set; }
        public string ExtensionFile { get; set; }

    }
}
