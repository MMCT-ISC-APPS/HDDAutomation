using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MachineDLL.Entities;
using MachineDLL.DAO;

namespace MachineDLL
{
    public  class ToolingManagement : UtilityDll
    {

        private bool bOnline;
        public ToolingManagement(bool Online) : base(Online)
        {
            bOnline = Online;
        }

        public ToolingManagement() : base()
        {
            bOnline = true;
        }

        public String CheckToolingStatus(String ToolingNo, String Model)
        {

            return "OK";
        }



    }
}
