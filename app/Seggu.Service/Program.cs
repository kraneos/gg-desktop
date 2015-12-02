using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;

namespace Seggu.Service
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            ConfigureEventLog();
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[] 
            { 
                new SegguService()
            };
            ServiceBase.Run(ServicesToRun);
        }

        private static void ConfigureEventLog()
        {
        }
    }
}
