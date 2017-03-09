using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seggu.Domain
{
    public enum SynchronizationProcessType
    {
        STARTING = 0,
        IN_PROGRESS = 1,
        FINISHING = 2,
        STOPPED = 3,
    }
}
