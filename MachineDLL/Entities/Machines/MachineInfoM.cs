using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineDLL.Entities
{
    public class MachineInfoM
    {
        public Int64 MachineID { get; set; }
        public String MachineName { get; set; }
        public DateTime  RegisterDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public String Status { get; set; }
        public String IPAddress { get; set; }
        public String Flag { get; set; }
        public String ResultPathFile  { get; set; }
        public String SolderHFile { get; set; }
        public FixtureResult FixtureResult { get; set; }

    }
}
