using Seggu.Dtos;
using System;
using System.Collections.Generic;

namespace Seggu.Services.Interfaces
{
    public interface IFeeService
    {
        int TodayExpirationFeesCount();
        IEnumerable<FeeDto> GetByPolicyId(int p);
        IEnumerable<FeeDto> GetByEndorseId(int id);
        IEnumerable<FeeDto> GetByFeeSelectionId(int id);
        IEnumerable<FeeDto> GetCandidatesByCompany(int companyId, DateTime dateFrom, DateTime dateTo);
        IEnumerable<FeeDto> GetPayedByCompany(int id, DateTime dateFrom, DateTime dateTo);
        FeeDto GetById(int Id);
        void Update(FeeDto fee);
        void UpdateMany(IEnumerable<FeeDto> fees);
        void UpdateFeeStates();
        IEnumerable<FeeIndexDto> GetOverduePoliciesToday();
        IEnumerable<FeeIndexDto> GetOverdueEndorsesToday();
    }
}
