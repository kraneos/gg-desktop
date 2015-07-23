using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seggu.Services.Interfaces
{
    public interface IMasterDataService
    {
        IEnumerable<string> GetMaritalStatuses();

        IEnumerable<string> GetIvas();

        IEnumerable<string> GetSexs();

        IEnumerable<string> GetIdTypes();

        IEnumerable<string> GetPeriods();

        IEnumerable<string> GetRiskTypes();

        IEnumerable<string> GetVehicleOrigin();

        IEnumerable<string> GetEndorseTypes();
    }
}
