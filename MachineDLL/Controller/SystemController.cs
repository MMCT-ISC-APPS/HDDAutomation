using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.ApplicationServices;
using MachineDLL.Entities;
using MachineDLL.Services;

namespace MachineDLL
{
    public static class SystemController
    {
        //public const String HTTP_PATH = "http://localhost:60197/"; // Webservice
        //public const String HTTP_PATH = "http://HDD-WS.MEKTEC.CO.TH/"; // Webservice
        public const String HTTP_PATH = "http://HDD-WS.MEKTEC.CO.TH:15002/"; // Webservice
        //public const String HTTP_PATH = "http://HDD-WS.MEKTEC.CO.TH:15003/"; // Webservice

        public const String WSSERVER = "HDD-WS.MEKTEC.CO.TH"; // Webservice

        public const String SESSION_NAME_LANGUAGE = "LANG";
        public const String SESSION_NAME_MT_APP_TYPE = "MT_APP_TYPE";
        public const String SESSION_NAME_BARCODE_DATA = "BARCODEDATA";

        public static UserInfoM CurrentUserLogIn
        {
            get { return Services.AuthenticationService.GetCurrentUserLogIn(); }
            set { Services.AuthenticationService.SetCurrentUserLogIn(value); }
        }

        public static String AppType
        {
            get
            {
                String result = "";

                if (HttpContext.Current.Session[SESSION_NAME_MT_APP_TYPE] != null)
                {
                    result = (String)HttpContext.Current.Session[SESSION_NAME_MT_APP_TYPE];
                }

                return result;

            }

            set { HttpContext.Current.Session[SESSION_NAME_MT_APP_TYPE] = value; }

        }



    }
}
