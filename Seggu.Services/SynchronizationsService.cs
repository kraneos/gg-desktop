using Seggu.Daos.Interfaces;
using Seggu.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seggu.Services
{
    public class SynchronizationsService : ISynchronizationsService
    {
        private ISynchronizationProcessesDao synchronizationProcessesDao;

        public SynchronizationsService(ISynchronizationProcessesDao synchronizationProcessesDao)
        {
            this.synchronizationProcessesDao = synchronizationProcessesDao;
        }

        public bool IsHappening()
        {
            var latestSync = this.synchronizationProcessesDao.GetLatest();
            return latestSync?.Type == Domain.SynchronizationProcessType.IN_PROGRESS;
        }
    }
}
