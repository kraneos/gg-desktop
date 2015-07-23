using Seggu.Dtos;
using System;
using System.Collections.Generic;

namespace Seggu.Services.Interfaces
{
    public interface IFeeService
    {
        int TodayExpirationFeesCount();
        IEnumerable<FeeDto> GetByPolicyId(string p);
        IEnumerable<FeeDto> GetByEndorseId(string id);
        IEnumerable<FeeDto> GetByFeeSelectionId(string id);
        IEnumerable<FeeDto> GetCandidatesByCompany(string companyId, DateTime dateFrom, DateTime dateTo);
        IEnumerable<FeeDto> GetPayedByCompany(string id, DateTime dateFrom, DateTime dateTo);
        FeeDto GetById(string Id);
        void Update(FeeDto fee);
        void UpdateMany(IEnumerable<FeeDto> fees);
        void UpdateFeeStates();
    }
}
