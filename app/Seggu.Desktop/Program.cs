using Microsoft.Win32;
using Seggu.Desktop.Forms;
using Seggu.Desktop.Properties;
using Seggu.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Seggu.Domain;
using Seggu.Service.Services;
using ParseClient = Parse.ParseClient;

namespace Seggu.Desktop
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                SynchronizationService.Initialize();
                SynchronizationService.InitializeParseClasses();
                ParseClient.Initialize(new ParseClient.Configuration
                {
                    ApplicationId = Settings.Default.ParseAppId,
                    Server = Settings.Default.ParseBaseUrl,
                });
                var form = (Layout)DependencyResolver.Instance.Resolve(typeof(Layout));
                Application.Run(form);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
