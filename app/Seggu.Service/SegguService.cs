using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Seggu.Data;
using Seggu.Domain;
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
        private ParseClient client;
        private Timer myTimer;

        public SegguService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            // Event Log configuration.
            if (!EventLog.SourceExists(Properties.Settings.Default.EventLogSourceName))
            {
                EventLog.CreateEventSource(Properties.Settings.Default.EventLogSourceName, Properties.Settings.Default.EventLogName);
            }
            this.eventLog.Source = Properties.Settings.Default.EventLogSourceName;
            this.eventLog.Log = Properties.Settings.Default.EventLogName;

            this.eventLog.WriteEntry("The service has started.");

            // ApiClient configuration.
            this.client = new ParseClient();

            this.myTimer = new Timer(10000);
            this.myTimer.Elapsed += Process;
            this.myTimer.Start();

            // JsonConvert Configuration
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {

                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
        }

        protected override void OnStop()
        {
            this.eventLog.WriteEntry("The service has stopped.");
        }

        private void Process(object sender, System.EventArgs e)
        {
            this.eventLog.WriteEntry("Begin process.");
            try
            {
                this.eventLog.WriteEntry("Initialize context.");
                using (var context = new SegguDataModelContext())
                {
                    SendClientsToParse(context);
                    SendAddressesToParse(context);
                    SendPoliciesToParse(context);
                    SendFeesToParse(context);
                    SendVehiclesToParse(context);
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        private void SendVehiclesToParse(SegguDataModelContext context)
        {
            var newVehicles = context.Vehicles
                .Where(p => p.ObjectId == null).ToList();
            var updatedVehicles = context.Vehicles
                .Where(p => p.UpdatedAt < p.LocallyUpdatedAt).ToList();

            var parseCreatedVehicles = this.client.CreateVehicles(newVehicles);
            var parseUpdatedVehicles = this.client.UpdateVehicles(updatedVehicles);

            context.SaveChanges();
        }

        private void SendAddressesToParse(SegguDataModelContext context)
        {
            var newAddresses = context.Addresses
                .Where(p => p.ObjectId == null).ToList();
            var updatedAddresses = context.Addresses
                .Where(p => p.UpdatedAt < p.LocallyUpdatedAt).ToList();

            var parseCreatedAddresses = this.client.CreateAddresses(newAddresses);
            var parseUpdatedAddresses = this.client.UpdateAddresses(updatedAddresses);

            context.SaveChanges();
        }

        private void SendClientsToParse(SegguDataModelContext context)
        {
            var newClients = context.Clients
                .Where(p => p.ObjectId == null).ToList();
            var updatedClients = context.Clients
                .Where(p => p.UpdatedAt < p.LocallyUpdatedAt).ToList();

            var parseCreatedClients = this.client.CreateClients(newClients);
            var parseUpdatedClients = this.client.UpdateClients(updatedClients);

            context.SaveChanges();
        }

        private void SendFeesToParse(SegguDataModelContext context)
        {
            var newFees = context.Fees
                .Where(p => p.ObjectId == null).ToList();
            var updatedFees = context.Fees
                .Where(p => p.UpdatedAt < p.LocallyUpdatedAt).ToList();

            var parseCreatedFees = this.client.CreateFees(newFees);
            var parseUpdatedFees = this.client.UpdateFees(updatedFees);

            context.SaveChanges();
        }

        private void SendPoliciesToParse(SegguDataModelContext context)
        {
            var newPolicies = context.Policies
                .Where(p => p.ObjectId == null).ToList();
            var updatedPolicies = context.Policies
                .Where(p => p.UpdatedAt < p.LocallyUpdatedAt).ToList();

            var parseCreatedPolicies = this.client.CreatePolicies(newPolicies);
            var parseUpdatedPolicies = this.client.UpdatePolicies(updatedPolicies);

            context.SaveChanges();
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
