using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineDLL.Entities.AutoDictate
{
    public class AutoDictModelConfigM : BaseDate
    {
        public int ConfigID { get; set; }
        public string Model { get; set; }
        public string OperCode { get; set; }
        public string OperName { get; set; }
        public string SizeView { get; set; }
        public IList<AutoDictProdLineConfigM> ProdLineM { get; set; }

    }
}
