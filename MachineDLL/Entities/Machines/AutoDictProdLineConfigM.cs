using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineDLL.Entities.AutoDictate
{
    public class AutoDictProdLineConfigM : BaseDate
    {
        public int ProdLineID { get; set; }
        public string ProdLineName { get; set; }
        public string OperCode { get; set; }
        public string OperName { get; set; }
        public string Path { get; set; }
        public AutoDictLayoutM LayoutM { get; set; }

    }
}
