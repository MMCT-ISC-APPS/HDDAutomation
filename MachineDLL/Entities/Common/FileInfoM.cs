using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MachineDLL.Entities
{
    public class FileInfoM
    {
        public MultipartFormDataContent Content { get; set; }
        public string MachineName { get; set; }
        public string ProgramVersion { get; set; }
        public string ProgramName { get; set; }
        public string DatabaseName { get; set; }
        public string BUType { get; set; }
        public string SourcePath { get; set; }
        public string DestinationPath { get; set; }
        public string ServerName { get; set; }
        public string Module { get; set; }
        public string Status { get; set; }
        public DateTime CreatedTimestamp { get; set; }
        public DateTime UpdatedTimestamp { get; set; }
        public String ContentTypes { get; set; }
        public String FileName { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public Int64 FileLength { get; set; }

    }
}
