using Seggu.Domain;
using System;
using System.Collections.Generic;

namespace Seggu.Daos.Interfaces
{
    public interface IFeeDao : IIdEntityDao<Fee>
    {
        IEnumerable<Fee> GetByPolicyId(long guid);
        IEnumerable<Fee> GetByEndorseId(long guid);
        IEnumerable<Fee> GetByFeeSelectionId(long guid);
        IEnumerable<Fee> GetByCompanyId(long companyId, DateTime dateFrom, DateTime dateTo);
        IEnumerable<Fee> GetExpiredByCompanyId(long guid);
        //void DeleteMany(IEnumerable<Fee> feesToDelete);
        IEnumerable<Fee> GetTodayFees();
        IEnumerable<Fee> GetExpiredByCompanyId();
        void AssignFeeSelection(IEnumerable<Fee> fees);
    }
}
