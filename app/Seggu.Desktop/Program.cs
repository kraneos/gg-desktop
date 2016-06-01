﻿using Microsoft.Win32;
using Parse;
using Seggu.Desktop.Forms;
using Seggu.Desktop.Properties;
using Seggu.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

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
