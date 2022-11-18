using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using MachineDLL;
using MachineDLL.Entities;


namespace AOIClientUploader
{
    public class FixtureFile
    {
        /// <summary>
        /// Fixture Id
        /// </summary>
        public string FixtureId { get; private set; }

        public FileInfo FileInfo { get; private set; }
        public String FailFloder { get; private set; }
        public String ComputerName { get; private set; }

        public FileInfo HeightFileInfo { get; private set; }

        /// <summary>
        /// Raw file content
        /// </summary>
        public string Content { get; private set; }

        /// <summary>
        /// Contains Position & Result
        /// </summary>
        public Dictionary<string, List<string>> Results { get; set; }

        public FixtureFile(string path, MachineInfoM objMachineM  )
        {
            this.FileInfo = new FileInfo(path);
            this.ComputerName = objMachineM.MachineName ;            
        }

        public void Validate()
        {
            try
            {                
                this.Content = File.ReadAllText(this.FileInfo.FullName);             
            }
            catch (Exception ex)
            {
                throw new FormatException(ex.Message, ex);
            }
        }

        public void Pick()
        {
            try
            {
                File.Delete(this.FileInfo.FullName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
