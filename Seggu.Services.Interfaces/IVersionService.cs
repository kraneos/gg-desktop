using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seggu.Services.Interfaces
{
    public interface IVersionService
    {
        bool VersionWasRun(string versionName);

        void SaveVersion(string versionName);
    }
}
