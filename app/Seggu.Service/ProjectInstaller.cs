using System.ComponentModel;
using System.Configuration.Install;
using System.ServiceProcess;

namespace Seggu.Service
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : Installer
    {
        public ProjectInstaller()
        {
            InitializeComponent();
            serviceInstaller1.AfterInstall += (sender, args) => new ServiceController(serviceInstaller1.ServiceName).Start();
        }
    }
}
