using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineDLL.Entities
{
    public class FixtureResult : EntityBase
    {
        public string FilePath { get; set; }
        public string FixtureId { get; set; }        
        public string PanelID { get; set; }
        public string Position { get; set; }
        public string Result { get; set; }
        public string Model { get; set; }
        public string Status { get; set; }
        public string DefectCode { get; set; }
        public string AOIPath { get; set; }
        public string AOI_Height_Path { get; set; }
        public DateTime CreatedDate { get; set; }
        public int RecordID { get; set; }
    }
}
