using Seggu.Daos.Interfaces;
using Seggu.Domain;
using Seggu.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seggu.Services
{
    public class VersionService : IVersionService
    {
        private IImplementedVersionDao implementedVersionDao;
        
        public VersionService(IImplementedVersionDao implementedVersionDao)
        {
            this.implementedVersionDao = implementedVersionDao;
        }

        public bool VersionWasRun(string versionName)
        {
            return this.implementedVersionDao.Exists(versionName);
        }

        public void SaveVersion(string versionName)
        {
            var version = new ImplementedVersion();
            version.Name = versionName;
            this.implementedVersionDao.Save(version);
        }
    }
}
