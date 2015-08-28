using Seggu.Domain;
using Seggu.Domain;
using System;
using System.Collections.Generic;

namespace Seggu.Daos.Interfaces
{
    public interface IFeeDao : IGenericDao<Fee>
    {
        IEnumerable<Fee> GetByPolicyId(int guid);
        IEnumerable<Fee> GetByEndorseId(int guid);
        IEnumerable<Fee> GetByFeeSelectionId(int guid);
        IEnumerable<Fee> GetByCompanyId(int companyId, DateTime dateFrom, DateTime dateTo);
        IEnumerable<Fee> GetExpiredByCompanyId(int guid);
        //void DeleteMany(IEnumerable<Fee> feesToDelete);
        IEnumerable<Fee> GetTodayFees();
        IEnumerable<Fee> GetExpiredByCompanyId();
        void AssignFeeSelection(IEnumerable<Fee> fees);
    }
}
