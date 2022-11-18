using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineDLL.Entities
{
    public abstract class BaseDate
    {
        public DateTime CreationDate { get; set; }
        public DateTime DisableDate { get; set; }
        public DateTime Lstdte { get; set; }
        public string MachineName { get; set; }
        public string ComputerName { get; set; }
        public string PrinterName { get; set; }
        public string ProgramVersion { get; set; }
        public string ProgramName { get; set; }

    }
}
