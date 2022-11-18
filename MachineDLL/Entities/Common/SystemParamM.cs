using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineDLL.Entities
{
    class SystemParamM
    {
        private Int64 paramID;
        private String paramName;
        private String paramValue;
        private String paramDesc;
        private String enditable;

        public Int64 ParamID
        {
            get { return this.paramID; }
            set { this.paramID = value; }
        }

        public String ParamName
        {
            get { return this.paramName; }
            set { this.paramName = value; }
        }

        public String ParamValue
        {
            get { return this.paramValue; }
            set { this.paramValue = value; }
        }

        public String ParamDesc
        {
            get { return this.paramDesc; }
            set { this.paramDesc = value; }
        }

        public String Enditable
        {
            get { return this.enditable; }
            set { this.enditable = value; }
        }

        public Boolean IsEnditable
        {
            get { if (this.enditable == "Y") { return true; } else { return false; } }
        }

    }
}
