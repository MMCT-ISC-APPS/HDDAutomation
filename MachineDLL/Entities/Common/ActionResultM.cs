using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MachineDLL.Common;
using MachineDLL.Infrastructure;

namespace MachineDLL.Entities
{
    public class ActionResultM
    {
        private Boolean status;
        private String code;
        private String message;
        private Object returnObj;

        public String Code
        {
            get { return this.code; }
            set { this.code = value; }
        }

        public String Message
        {
            get { return this.message; }
            set { this.message = value; }
        }

        public Object ReturnObj
        {
            get { return this.returnObj; }
            set { this.returnObj = value; }
        }

        public Boolean Status
        {
            get { if (this.code == DBFactory.CONST_DB_RES_CODE_SUCCESS) { return true; } else { return false; } }
        }

    }
}