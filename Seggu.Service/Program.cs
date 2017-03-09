using System.Diagnostics;
using System.ServiceProcess;

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
                new SegguService()
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}
