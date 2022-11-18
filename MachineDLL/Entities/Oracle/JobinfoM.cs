using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace MachineDLL.Entities
{
    public class JobinfoM : EntityBase
    {
        public string PanelNo { get; set; }
        public string CPN { get; set; }
        public string Status { get; set; }
        public string Master2D { get; set; }
        public Int64 PanelSize { get; set; }
        public Int64 Remain { get; set; }
        public string QueStatus { get; set; }
        public string WIPID { get; set; }
        public int CheckIn { get; set; }
        public int CheckOut { get; set; }
        public int SeqNo { get; set; }
        public String ICLot { get; set; }
        public String SubLot { get; set; }
        public String PrimaryUOM { get; set; }
        public String Username { get; set; }
        public String CompletedSubinventory { get; set; }
        public String ClassCode { get; set; }
        public String PrefixCust { get; set; }
        public String Prefix2D { get; set; }
        public Int64 StandardPackSize { get; set; }
        public Int64 OnhandQty { get; set; }
        public Int64 TotalQtyBarcode { get; set; }
        public Int64 TotalQtyBarcodePrinted { get; set; }
        public String CustomerName { get; set; }
        public String PrefixBarcode { get; set; }
        public String UserNo { get; set; }
        public String Arr2D { get; set; }
        public Dictionary<string, Int16> SubLots { get; set; }
        public IList<PrintinfoM> Serials { get; set; }
    }
}
