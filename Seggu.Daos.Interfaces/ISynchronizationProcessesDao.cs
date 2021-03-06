﻿using Seggu.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seggu.Daos.Interfaces
{
    public interface ISynchronizationProcessesDao : IGenericDao<SynchronizationProcess>
    {
        SynchronizationProcess GetLatest();
    }
}
