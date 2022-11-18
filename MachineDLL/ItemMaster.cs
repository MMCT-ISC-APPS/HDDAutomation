using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MachineDLL.Entities;
using MachineDLL.DAO;

namespace MachineDLL
{
    public class ItemMaster
    {

        public ItemMasterM GetItemMaster(ItemMasterM objItemM)
        {
            ItemMasterDAO objItemDAO = new ItemMasterDAO();

            try
            {
                return objItemDAO.GetItemMaster(objItemM);
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        public ItemMasterM GetOnhandByJobandLot(ItemMasterM objItemM)
        {
            ItemMasterDAO objItemDAO = new ItemMasterDAO();
            try
            {
                return objItemDAO.GetOnhandByJobandLot (objItemM);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
