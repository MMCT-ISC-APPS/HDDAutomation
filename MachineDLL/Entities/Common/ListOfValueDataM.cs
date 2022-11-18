using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineDLL.Entities
{
    public class ListOfValueDataM
    {

        private String fieldName;
        private String dataValue;
        private String dataDisplayTH;
        private String dataDisplayEN;
        private bool isDefault;
        private bool isDisplay;
        private int index;

        public String FieldName
        {
            get { return this.fieldName; }
            set { this.fieldName = value; }
        }

        public String DataValue
        {
            get { return this.dataValue; }
            set { this.dataValue = value; }
        }

        public String DataDisplayTH
        {
            get { return this.dataDisplayTH; }
            set { this.dataDisplayTH = value; }
        }

        public String DataDisplayEN
        {
            get { return this.dataDisplayEN; }
            set { this.dataDisplayEN = value; }
        }

        public bool IsDefault
        {
            get { return this.isDefault; }
            set { this.isDefault = value; }
        }


        public String Default
        {
            get
            {
                if (this.isDefault) { return "Y"; }
                else { return "N"; }
            }
            set
            {
                if ("Y" == value) { this.isDefault = true; }
                else { this.isDefault = false; }
            }
        }

        public bool IsDisplay
        {
            get { return this.isDisplay; }
            set { this.isDisplay = value; }
        }

        public String Display
        {
            get
            {
                if (this.isDisplay) { return "Y"; }
                else { return "N"; }
            }
            set
            {
                if ("Y" == value) { this.isDisplay = true; }
                else { this.isDisplay = false; }
            }
        }

        public int Index
        {
            get { return this.index; }
            set { this.index = value; }
        }

    }
}
