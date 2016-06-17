using Microsoft.Win32;
using Parse;
using Seggu.Desktop.Forms;
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
                    ApplicationId = "seggu-api",
                    Server = "https://seggu-api-develop.herokuapp.com/parse/",
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
