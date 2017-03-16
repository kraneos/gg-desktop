using Seggu.Daos.Interfaces;
using Seggu.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Seggu.Data;

namespace Seggu.Daos
{
    public class SynchronizationProcessesDao : IdEntityDao<SynchronizationProcess>, ISynchronizationProcessesDao
    {
        public SynchronizationProcessesDao(SegguDataModelContext context) : base(context)
        {
        }

        public SynchronizationProcess GetLatest()
        {
            return this.context.SynchronizationProcesses
                .OrderByDescending(x => x.Date)
                .FirstOrDefault();
        }

        public override void Update(SynchronizationProcess obj)
        {
            throw new NotImplementedException();
        }
    }
}
