using Seggu.Domain;
using System;
using System.Collections.Generic;

namespace Seggu.Daos.Interfaces
{
    public interface IFeeDao : IParseIdEntityDao<Fee>
    {
        List<Fee> GetByPolicyId(long guid);
        List<Fee> GetByEndorseId(long guid);
        List<Fee> GetByFeeSelectionId(long guid);
        List<Fee> GetByCompanyId(long companyId, DateTime dateFrom, DateTime dateTo);
        List<Fee> GetExpiredByCompanyId(long guid);
        //void DeleteMany(List<Fee> feesToDelete);
        List<Fee> GetTodayFees();
        List<Fee> GetExpiredByCompanyId();
        void AssignFeeSelection(List<Fee> fees);

        List<Fee> GetOverdueEndorsesToday();

        List<Fee> GetOverduePoliciesToday();
    }
}
