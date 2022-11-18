using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Topshelf;
using MachineDLL;
using MachineDLL.Entities;

namespace AOITRI
{
    public class Application : ServiceControl
    {
        private dynamic configuration;

        private List<FileScanner> scanners;

        Machine objMachine = new Machine();

        
        public bool Start(HostControl hostControl)
        {

            configuration = Newtonsoft.Json.JsonConvert.DeserializeObject<ExpandoObject>(File.ReadAllText("configuration.json"));
            
            string failFolder = (string)configuration.failFolder;
            
            Console.WriteLine("[{0} {1}] - Connect Server", Thread.CurrentThread.ManagedThreadId, DateTime.Now.ToString());

            if (!Directory.Exists(failFolder))
                Directory.CreateDirectory(failFolder);

            List<object> folders = configuration.folders;

            scanners = new List<FileScanner>();

            int delay = (int)configuration.scanInterval / folders.Count;

            Console.Title = "AOITRI:" + configuration.computername;

            foreach (var folder in folders)
            {
                FileScanner scanner = new FileScanner(folder.ToString(), failFolder, (int)configuration.scanInterval , configuration.heightfolder , configuration.computername);
                scanner.OnFoundNewFile += Scanner_OnFoundNewFile;
                scanners.Add(scanner);
                scanner.Start();

                Thread.Sleep(delay);

            }

            return true;
        }


//        private async void Scanner_OnFoundHeight(object sender, FixtureFile e)
//        {
//            try
//            {
//                Console.WriteLine("[{0}] - found Height {1}", Thread.CurrentThread.ManagedThreadId, e.FileInfo.FullName);
//                await Task.Factory.StartNew(() =>
//                {

//                }

//            }
//            catch (Exception ex) 
//{
//            }
//        }

        //private async void Scanner_OnFoundNewFile(object sender, FixtureFile e)
        private void Scanner_OnFoundNewFile(object sender, FixtureFile e )
        {            
            string ServerPath = "";

            try
            {
                
                Console.WriteLine("[{2} {0}] - found {1}", Thread.CurrentThread.ManagedThreadId, e.FileInfo.FullName ,DateTime.Now.ToString ());
                e.Validate();
                Console.WriteLine("[{0} {1}] - Validated", Thread.CurrentThread.ManagedThreadId , DateTime.Now.ToString ());

                //e.Pick();

                // insert into database
                //await Task.Factory.StartNew(() => 
                //{
                try
                {

                    //Task.Delay(36000);

                    string filedate = e.FileInfo.Name;            
                    
                    
                    String[] Temp = filedate.ToLower().Split('_');
                    FixtureResult objResult = new FixtureResult();
                    
                    objResult.ProgramName = "AOITRI_Service";
                    objResult.ProgramVersion = objMachine.GetVersion();
                    objResult.ComputerName = e.ComputerName; //objMachine.GetComputerName();
                    
                    int Position = Convert.ToInt16(Temp[2].Substring(0, Temp[2].IndexOf(".txt")));

                    //if (Temp[2].)

                    String[] Result = e.Content.Split(';');
                    String sDefect = "";

                    objResult.DefectCode = "WAITING";

                    //throw new Exception("Error test");
                    for (int i = 0; i <= Result.Length - 1; i++)
                    {
                        objResult.Model = Result[0].ToString();
                        objResult.PanelID = Result[1].ToString();
                        objResult.Position = Position.ToString();
                        objResult.CreatedDate = Convert.ToDateTime(Result[2].ToString());                        
                        if (Result[3].ToString().ToLower() == "pass")
                        {
                            objResult.Status = "PASS";
                            objResult.DefectCode = "";
                            break;
                        }
                        else
                        {
                            if (Result[3].ToString().ToLower() == "rpair")
                            {
                                objResult.Status = "FAIL";
                                objResult.DefectCode = "rpair";
                                break;
                            }
                            else
                            {
                                if (Result[3].ToString().ToLower() == "rpass")
                                {
                                    objResult.Status = "PASS";
                                    objResult.DefectCode = "";
                                    break;
                                }
                                else
                                {
                                    if (i >= 7)
                                    {
                                        if (sDefect == "")
                                        {
                                            sDefect = Result[i];
                                        }
                                        else
                                        {
                                            sDefect = sDefect + ";" + Result[i];
                                        }
                                    }
                                }
                            }
                        }

                    }

                        objResult.Result = sDefect;
                        
                        ServerPath = objMachine.UploadFileFromServer (e.FileInfo.FullName, "HSG_AOI" ,e.ComputerName );
                        objResult.AOIPath = ServerPath;

                       try
                        {
                            objResult = objMachine.UpdateAOIforTri(objResult);
                            Console.WriteLine("[{0}] - call UpdateAOIforTri:serialno", objResult.PanelID + ": Result:" + objResult.Status + ",DefectCode:" + objResult.DefectCode);
                            Console.WriteLine("[{0}] - call Upload file completed :serverpath:" + ServerPath, e.FileInfo.FullName);
                        }
                        catch (Exception ex)
                        {
                            string Datetime = DateTime.Now.ToString("dd/mm/yyyy");
                            string destination = Path.Combine((string)configuration.backupfolder  + "\\" + Datetime, e.FileInfo.Name);
                            string sError = "";
                            sError = ex.Message + "File:" + destination;

                            objMachine.WriteMachineErrorLogs(sError);

                            if (File.Exists(e.FileInfo.FullName))
                            {
                                if (File.Exists(destination))
                                    File.Delete(destination);

                                if (Directory.Exists((string)configuration.backupfolder) == false)
                                {
                                    Directory.CreateDirectory((string)configuration.backupfolder + "\\" + Datetime);
                                } 

                                File.Move(e.FileInfo.FullName, destination);
                             }
                                
                            Console.WriteLine("[{1}{0}] - Err", DateTime.Now.ToString(), sError);

                        //Console.WriteLine("[{1}{0}] - Err",DateTime.Now.ToString (), ex.Message);
                        }                                           
                        //if (File.Exists(e.FileInfo.FullName))
                        //{                            
                        //    try
                        //    {                            
                        //        File.Delete(e.FileInfo.FullName);                               
                        //    }
                        //    catch
                        //    {
                        //        throw new Exception();
                        //    }
                        //}
                                                

                    }
                   catch (Exception er)
                   {
                    String sError = "";
                    
                        string destination = Path.Combine((string)configuration.failFolder, e.FileInfo.Name);

                        sError = er.Message + "File:" + destination;

                        objMachine.WriteMachineErrorLogs(sError);

                        if (File.Exists(e.FileInfo.FullName))
                            {
                                if (File.Exists(destination))
                                    File.Delete(destination);

                                File.Move(e.FileInfo.FullName, destination);
                            }

                    
                        Console.WriteLine("[{1}{0}] - Err", DateTime.Now.ToString (),sError);

                        //if (File.Exists(e.FileInfo.FullName))
                        //{
                        //        Console.WriteLine("[{0}] - Err", er.Message);
                        //        string destination = Path.Combine((string)configuration.failFolder, e.FileInfo.Name);
                        //        File.Move(e.FileInfo.FullName, destination );

                        //        ServerPath = objMachine.UploadErrorFile(destination, "HSG_AOI");

                        //        Console.WriteLine("[{0}] - Err", er.Message);

                        //        File.Delete(e.FileInfo.FullName);


                        //        //try
                        //        //{
                        //        //        if (File.Exists(e.FileInfo.FullName) == true)
                        //        //        {
                        //        //            Console.WriteLine("[{0}] - Err", er.Message);
                        //        //            string destination = Path.Combine((string)configuration.failFolder, e.FileInfo.Name);
                        //        //            File.Move(e.FileInfo.FullName, destination);

                        //        //            ServerPath = objMachine.UploadErrorFile(destination, "HSG_AOI");

                        //        //            Console.WriteLine("[{0}] - Err", er.Message);

                        //        //            File.Delete(e.FileInfo.FullName);

                        //        //        }
                        //        //    }
                        //        //catch
                        //        //{
                        //        //    throw new Exception();
                        //        //}
                        //    }


                    }
                //});
                                
                e.Pick();

                Console.WriteLine("[{0} {1}] - Delete File", Thread.CurrentThread.ManagedThreadId, DateTime.Now.ToString());

            }
            catch (FormatException ex)
            {
                Console.WriteLine("Validated"  + ex.Message );
                /*
                string destination = Path.Combine((string)configuration.failFolder, e.FileInfo.Name);


                if (File.Exists(e.FileInfo.FullName))
                {
                    if (File.Exists(destination))
                        File.Delete(destination);
                    try { 
                    File.Move(e.FileInfo.FullName, destination);
                    }catch
                    {

                    }
                }
                */

            }

            catch (Exception ex)
            {
                Console.WriteLine("Validated" + ex.Message);
            }
            finally {
                //string destination = Path.Combine((string)configuration.backupfolder, e.FileInfo.Name);
                //if (File.Exists(e.FileInfo.FullName))
                //{
                //    try { 
                //    if (File.Exists(destination))
                //        File.Delete(destination);

                //   File.Move(e.FileInfo.FullName, destination);
                //    }
                //    catch
                //    {

                //    }
                //}
            }
        }

        public bool Stop(HostControl hostControl)
        {
            foreach (var scanner in scanners)
                scanner.Stop();

            return true;
        }
    }
}
