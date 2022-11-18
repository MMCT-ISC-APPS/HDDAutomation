using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineDLL.Common
{
    class SystemUtility
    {
        public  string GetComputerName()
        {
            return System.Environment.MachineName;
        }

        public  string getVersion()
        {
            System.Reflection.Assembly ProjectAssembly;
            ProjectAssembly = System.Reflection.Assembly.GetExecutingAssembly();
            return ProjectAssembly.GetName().Version.ToString() ;
        }

        public string getApplicationPath()
        {
            System.Reflection.Assembly ProjectAssembly;
            ProjectAssembly = System.Reflection.Assembly.GetExecutingAssembly();
            String sPath = System.IO.Path.GetDirectoryName(ProjectAssembly.Location.ToString());
            return sPath;
        }

    }
}
