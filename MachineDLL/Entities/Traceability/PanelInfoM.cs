using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Data;

namespace MachineDLL.Entities
{
    public class PanelInfoM : EntityBase
    {

        private Dictionary<Int32, CavityM> objCavityNo;

        private string sPanelType;
        private Image imgPanel;
        private int iMiniSheet;
        private double lngAspecratio;

        private double dWidth;
        private double dHeight;

        public string Status { get; set; }        
        
        public string Model { get; set; }
        public string PanelNo { get; set; }
        public string ErrorMsg { get; set; }
        public string Layout { get; set; }

        public string FixtureNo { get; set; }

        public string Jigsaw { get; set; }

        public DataTable FixtureInfoData { get; set; }

        public DataTable ImageData { get; set; }

        public double Height
        {
            get
            {
                return dHeight;
            }
            set
            {
                dHeight = value;
            }
        }

        public double Width
        {
            get
            {
                return dWidth;
            }
            set
            {
                dWidth = value;
            }
        }

        public double Aspecratio
        {
            get
            {
                return lngAspecratio;
            }
            set
            {
                lngAspecratio = value;
            }
        }

        public int MiniSheet
        {
            get
            {
                return iMiniSheet;
            }
            set
            {
                iMiniSheet = value;
            }
        }

        public Image ImagePanel
        {
            get
            {
                return imgPanel;
            }
            set
            {
                imgPanel = value;
            }
        }

        public string PanelType
        {
            get
            {
                return sPanelType;
            }
            set
            {
                sPanelType = value;
            }
        }

        public Dictionary<Int32, CavityM> Cavity
        {
            get
            {
                if (objCavityNo == null)
                    objCavityNo = new Dictionary<Int32, CavityM>();
                return objCavityNo;
            }
            set
            {
                objCavityNo = value;
            }
        }
    }

    public class CavityM
    {
        private int iCavityNo;
        private int iPixelX;

        private int iPixelY;
        public int PixelY
        {
            get
            {
                return iPixelY;
            }
            set
            {
                iPixelY = value;
            }
        }

        public int PixelX
        {
            get
            {
                return iPixelX;
            }
            set
            {
                iPixelX = value;
            }
        }
        public int CavityNo
        {
            get
            {
                return iCavityNo;
            }
            set
            {
                iCavityNo = value;
            }
        }
    }
}
