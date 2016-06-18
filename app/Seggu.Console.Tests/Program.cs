using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Seggu.Data;
using Seggu.Service.Services;

namespace Seggu.Console.Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            SynchronizationService.InitializeParseClasses();
            SynchronizationService.Initialize();
            Thread.Sleep(30000);
            var eventLog = new EventLog();
            eventLog = new System.Diagnostics.EventLog();
            ((System.ComponentModel.ISupportInitialize)(eventLog)).BeginInit();
            eventLog.Source = "test";
            eventLog.Log = "test";

            eventLog.WriteEntry("The service has started.");

            //var ServiceName = "SegguService";
            ((System.ComponentModel.ISupportInitialize)(eventLog)).EndInit();

            using (var context = new SegguDataModelContext(@"Data Source=C:\Users\poloagustin\git\seggu\app\Seggu.Desktop\bin\Debug\seggu.sqlite;"))
            {
                var syncService = new SynchronizationService(context, eventLog);

                syncService.SynchronizeParseEntities();
            }
        }
    }
}
