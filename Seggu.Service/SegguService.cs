using Seggu.Infrastructure;
using Seggu.Service.Services;
using Seggu.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.ServiceProcess;
using System.Timers;
using Seggu.Data;

namespace Seggu.Service
{
    partial class SegguService : ServiceBase
    {
        private Timer myTimer;
        private static volatile bool isRunning;

        public SegguService()
        {
            InitializeComponent();
            SynchronizationService.InitializeParseClasses();
            SynchronizationService.Initialize();
        }

        protected override void OnStart(string[] args)
        {
            // Event Log configuration.
            this.eventLog.Source = Properties.Settings.Default.EventLogSourceName;
            this.eventLog.Log = Properties.Settings.Default.EventLogName;

            this.eventLog.WriteEntry("The service has started.");

            this.myTimer = new Timer(Properties.Settings.Default.Interval);
            this.myTimer.Elapsed += Process;
            this.myTimer.Start();
        }

        protected override void OnStop()
        {
            this.eventLog.WriteEntry("The service has stopped.");
        }

        private void Process(object sender, System.EventArgs e)
        {
            if (isRunning) return;
            isRunning = true;

            this.eventLog.WriteEntry("Begin process.");

            //var syncService = DependencyResolver.PerThreadInstance.Resolve<ISynchronizationService>(new Dictionary<string, object> { { "eventLog", this.eventLog } });
            try
            {
                var context = new SegguDataModelContext("Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "seggu.sqlite");
                var syncService = new SynchronizationService(context, this.eventLog);
                syncService.MarkStart();
                syncService.SynchronizeParseEntities();
                syncService.MarkEnd();
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
            finally
            {
                isRunning = false;
            }
        }

        private void HandleException(Exception ex)
        {
            this.eventLog.WriteEntry(ex.Message + "\n" + ex.StackTrace, EventLogEntryType.Error);
            if (ex.InnerException != null)
            {
                HandleException(ex.InnerException);
            }
        }
    }
}
