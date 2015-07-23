using Seggu.Data;
using System;
using System.Collections.Generic;

namespace Seggu.Daos.Interfaces
{
    public interface IFeeDao : IGenericDao<Fee>
    {
        IEnumerable<Fee> GetByPolicyId(Guid guid);
        IEnumerable<Fee> GetByEndorseId(Guid guid);
        IEnumerable<Fee> GetByFeeSelectionId(Guid guid);
        IEnumerable<Fee> GetByCompanyId(Guid companyId, DateTime dateFrom, DateTime dateTo);
        IEnumerable<Fee> GetExpiredByCompanyId(Guid guid);
        //void DeleteMany(IEnumerable<Fee> feesToDelete);
        IEnumerable<Fee> GetTodayFees();
        IEnumerable<Fee> GetExpiredByCompanyId();
        void AssignFeeSelection(IEnumerable<Fee> fees);
    }
}
