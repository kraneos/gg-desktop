using Seggu.Domain;
using Seggu.Services.DtoMappers;
using Seggu.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seggu.Services
{
    public class MasterDataService : IMasterDataService
    {
        public IEnumerable<string> GetMaritalStatuses()
        {
            return Enum
                .GetValues(typeof(MaritalStatus))
                .Cast<MaritalStatus>()
                .Select(x => MaritalStatusDtoMapper.ToString(x));
        }

        public IEnumerable<string> GetIvas()
        {
            return Enum
                .GetValues(typeof(IVA))
                .Cast<IVA>()
                .Select(x => IvaDtoMapper.ToString(x));
        }

        public IEnumerable<string> GetSexs()
        {
            return Enum
                .GetValues(typeof(Sex))
                .Cast<Sex>()
                .Select(x => SexDtoMapper.ToString(x));
        }

        public IEnumerable<string> GetIdTypes()
        {
            return Enum
                .GetValues(typeof(IdType))
                .Cast<IdType>()
                .Select(x => IdTypeDtoMapper.ToString(x));
        }

        public IEnumerable<string> GetPeriods()
        {
            return Enum
                .GetValues(typeof(Period))
                .Cast<Period>()
                .Select(x => PeriodDtoMapper.ToString(x));
        }

        public IEnumerable<string> GetRiskTypes()
        {
            return Enum
                .GetValues(typeof(RiskType))
                .Cast<RiskType>()
                .Select(x => RiskTypeDtoMapper.ToString(x));
        }

        public IEnumerable<string> GetVehicleOrigin()
        {
            return Enum
                .GetValues(typeof(Origin))
                .Cast<Origin>()
                .Select(x => OriginDtoMapper.ToString(x));
        }

        public IEnumerable<string> GetEndorseTypes()
        {
            return Enum
                .GetValues(typeof(EndorseType))
                .Cast<EndorseType>()
                .Select(x => EndorseTypeDtoMapper.ToString(x));
        }
    }
}
