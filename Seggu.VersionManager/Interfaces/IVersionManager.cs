using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seggu.VersionManager.Interfaces
{
    public interface IVersionManager
    {
        void RunAllVersions();
        void RunAllVersions(Action delegateAction);
        int GetVersionCountToRun();
    }
}
