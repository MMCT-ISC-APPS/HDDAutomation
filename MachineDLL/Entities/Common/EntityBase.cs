using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineDLL.Entities
{
    public abstract  class EntityBase
    {
        public string JobName { get; set; }
        public string ModelName { get; set; }
        public Int64 Id { get; protected set; }
        public string MachineName { get; set; }
        public string ComputerName { get; set; }
        public string PrinterName { get; set; }
        public string ProgramVersion { get; set; }
        public string ProgramName { get; set; }
        public string DatabaseName { get; set; }
        public string JobType { get; set; }
        public Int64 JobQty { get; set; }
        public string En { get; set; }
        public Int64 InventoryItemID { get; set; }
        public Int64 JobBuildID { get; set; }

    }
}
