using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineDLL.Entities.Traceability
{
    public class PanelWithSerialsM
    {
        public String PanelID { get; set; }
        public IList<String> List2D { get; set; }
        public IList<PrintinfoM> Serials { get; set; }

    }
}
