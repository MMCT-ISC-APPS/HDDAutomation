using AOITRI;
using Newtonsoft.Json.Linq;
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





namespace AOITRI
{
    class Program
    {

        static int Main(string[] args)
        {

            var exitcode = HostFactory.Run(x =>
            {
                ThreadPool.SetMinThreads(300, 300);
                CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-US");
                CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en-US");

                x.SetStartTimeout(TimeSpan.FromSeconds(120));
                x.SetStopTimeout(TimeSpan.FromSeconds(120));

                x.Service<Application>();
                
                x.SetDescription("HSG AOI TRI");
                x.SetDisplayName("AOITri");
                x.SetServiceName("AOITri");
                
                x.StartAutomatically();
                x.RunAsLocalSystem();

                x.EnableServiceRecovery(r =>
                {
                    r.RestartService(1);

                    //should this be true for crashed or non-zero exits
                    r.OnCrashOnly();

                    //number of days until the error count resets
                    r.SetResetPeriod(1);
                });

            });
            return (int)exitcode;


        }

    }
}
