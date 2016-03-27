using Seggu.Infrastructure;
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
        private static System.Diagnostics.EventLog eventLog = new EventLog();
        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[]
                {
                    //DependencyResolver.Instance.Resolve<SegguService>()
                    new SegguService()
                };
                ServiceBase.Run(ServicesToRun);
        }
    }
}
