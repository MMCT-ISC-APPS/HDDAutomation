using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MachineDLL.Entities;
using MachineDLL.DAO;

namespace MachineDLL
{
    public class ReworkProcess : UtilityDll
    {
        public ItemReworkInfoM SaveReworkModel(ItemReworkInfoM objItemM)
        {
            ReworkDAO objRework = new ReworkDAO();

            try
            {
                return objRework.SaveReworkModel(objItemM);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally {
                objRework = null;
            }
        }

        public ItemReworkInfoM GetModelRework(ItemReworkInfoM objItemM)
        {
            ReworkDAO objRework = new ReworkDAO();

            try
            {
                return objRework.GetModelRework (objItemM);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                objRework = null;
            }
        }

        public ItemReworkInfoM SaveRework2D(ItemReworkInfoM objItemM)
        {
            ReworkDAO objRework = new ReworkDAO();

            try
            {
                return objRework.SaveRework2D (objItemM);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                objRework = null;
            }
        }

        public ItemReworkInfoM GetModelReworkHistory(ItemReworkInfoM objItemM)
        {
            ReworkDAO objRework = new ReworkDAO();

            try
            {
                return objRework.GetModelReworkHistory (objItemM);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                objRework = null;
            }
        }

        public ItemReworkInfoM GetAllReworkCriteriaData(ItemReworkInfoM objItemM)
        {
            ReworkDAO objRework = new ReworkDAO();

            try
            {
                return objRework.GetAllReworkCriteriaData(objItemM);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                objRework = null;
            }
        }

        public String SaveLayoutReworkItem(ItemReworkInfoM objItemM)
        {
            ReworkDAO objRework = new ReworkDAO();

            try
            {
                return objRework.SaveLayoutReworkItem(objItemM);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                objRework = null;
            }
        }

    }
}
