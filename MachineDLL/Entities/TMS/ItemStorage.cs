using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineDLL.Entities.TMS
{
    public class ItemStorage
    {
        public int ItemId { get; set; }

        public string ItemName { get; set; }

        public string TrackingNo { get; set; }

        public int CurrentStroke { get; set; }
        public int SafytyStroke { get; set; }

        public string Status { get; set; }

        public string StorageNo { get; set; }

        public string StorageName { get; set; }

        public int Qty { get; set; }

        public string ToolingStatus { get; set; }
        public DateTime StoredDate { get; set; }
    }
}
