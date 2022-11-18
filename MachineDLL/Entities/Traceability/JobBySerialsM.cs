using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineDLL.Entities.Traceability
{
    public class JobBySerialsM
    {
        public String JobName { get; set; }
        public int JobSize { get; set; }
        public int remain { get; set; }
        public String Model { get; set; }
        public String Master2D { get; set; }
        public String Status { get; set; }
        public String ICLots { get; set; }
        public String ProgramVersion { get; set; }
        public String CPN { get; set; }
        public int PanelSize { get; set; }
        public String ICVerndor { get; set; }
        public String MachineName { get; set; }

        public IList<PanelWithSerialsM> PanelID { get; set; }
    }
}
