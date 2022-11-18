using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineDLL.Entities
{
    class BoxInfoM
    {
        public string BoxNo { get; set; }
        public Int64 BoxQty { get; set; }
        public IList<BundleInfoM> BundleList { get; set; }

    }
}
