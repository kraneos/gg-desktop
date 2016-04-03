using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Seggu.Data;
using Seggu.Domain;
using Seggu.Infrastructure;
using Seggu.Service.Services;
using Seggu.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Timers;

namespace Seggu.Service
{
    partial class SegguService : ServiceBase
    {
        private Timer myTimer;

        public SegguService()
        {
            InitializeComponent();
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
            this.eventLog.WriteEntry("Begin process.");

            var syncService = DependencyResolver.Instance.Resolve<ISynchronizationService>();

            try
            {
                syncService.SynchronizeParseEntities();
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        private void HandleException(Exception ex)
        {
            this.eventLog.WriteEntry(ex.Message, EventLogEntryType.Error);
            if (ex.InnerException != null)
            {
                HandleException(ex.InnerException);
            }
        }
    }
}
