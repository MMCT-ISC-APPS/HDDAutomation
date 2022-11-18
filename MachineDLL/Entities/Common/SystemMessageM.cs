using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineDLL.Entities
{
    public class SystemMessageM
    {

        private Int64 msgID;
        private String msgCode;
        private String msgModule;
        private String msgSubModule;
        private String msgTitle;
        private String msgTH;
        private String msgEN;
        private String msgDefaultLang;

        public Int64 MsgID
        {
            get { return this.msgID; }
            set { this.msgID = value; }
        }

        public String MsgCode
        {
            get { return this.msgCode; }
            set { this.msgCode = value; }
        }

        public String MsgModule
        {
            get { return this.msgModule; }
            set { this.msgModule = value; }
        }

        public String MsgSubModule
        {
            get { return this.msgSubModule; }
            set { this.msgSubModule = value; }
        }

        public String MsgTitle
        {
            get { return this.msgTitle; }
            set { this.msgTitle = value; }
        }

        public String MsgTH
        {
            get { return this.msgTH; }
            set { this.msgTH = value; }
        }

        public String MsgEN
        {
            get { return this.msgEN; }
            set { this.msgEN = value; }
        }

    }
}
