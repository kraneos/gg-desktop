using Seggu.VersionManager.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Seggu.Desktop.Forms
{
    public partial class Splash : Form
    {
        private IVersionManager versionManager;

        public Splash(IVersionManager versionManager)
        {
            InitializeComponent();
            this.versionManager = versionManager;
            this.backgroundWorker.RunWorkerAsync();
        }

        private void DoWork(object sender, DoWorkEventArgs e)
        {
            progressBar.Maximum = this.versionManager.GetVersionCountToRun();
            versionManager.RunAllVersions(NotifyProgress);
        }

        private void NotifyProgress()
        {
            Action action = () =>
                {
                    this.label1.Text = "Ejecutando pasos " + this.progressBar.Value + " de " + this.progressBar.Maximum + "...";
                    this.backgroundWorker.ReportProgress(1);
                };

            if (this.IsHandleCreated && this.InvokeRequired)
            {
                this.Invoke(action);
            }
            else
            {
                action();
            }
        }

        private void ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Thread.Sleep(1000);
        }

        private void RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Close();
        }
    }
}
