using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineDLL.Entities.AutoDictate
{
    public class AutoDictConfigurationM
    {
        public string JobName { get; set; }
        public string ModelName { get; set; }
        public string ProdLineName { get; set; }
        public string LANE { get; set; }

        public IList<AutoDictModelConfigM> ModelConfigM { get; set; }
        //public IList<AutoDictProdLineConfigM> ProdLineM { get; set; }

    }
}
