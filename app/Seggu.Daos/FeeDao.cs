using Seggu.Daos.Interfaces;
using Seggu.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Seggu.Daos
{
    public sealed class FeeDao : GenericDao<Fee>, IFeeDao
    {
        public IEnumerable<Fee> GetByPolicyId(Guid guid)
        {
            return this.Set
                .Where(f => f.PolicyId == guid);
        }
        public IEnumerable<Fee> GetByEndorseId(Guid guid)
        {
            return this.Set
                .Where(f => f.EndorseId == guid);
        }
        public IEnumerable<Fee> GetByCompanyId(Guid guid, DateTime dateFrom, DateTime dateTo)
        {
            return
                from f in this.Set
                join p in this.container.Policies on f.PolicyId equals p.Id
                join r in this.container.Risks on p.Risk.Id equals r.Id
                join co in this.container.Companies on r.CompanyId equals co.Id
                where co.Id == guid
                    && f.ExpirationDate >= dateFrom && f.ExpirationDate <= dateTo
                    && f.Annulated == false
                select f;
            //return this.Set.Include("Policy.Coverage.Risk.Company")
            //    .Where(f => f.Policy.Coverage.Risk.CompanyId == guid);
        }
        public IEnumerable<Fee> GetExpiredByCompanyId(Guid guid)
        {
            return
                from f in this.Set
                join p in this.container.Policies on f.PolicyId equals p.Id
                join r in this.container.Risks on p.Risk.Id equals r.Id
                join co in this.container.Companies on r.CompanyId equals co.Id
                where co.Id == guid
                    && f.ExpirationDate < DateTime.Today
                    && f.State == 0
                    && f.Annulated == false
                select f;
        }
        public IEnumerable<Fee> GetByFeeSelectionId(Guid guid)
        {
            return this.container.Fees
                .Where(f => f.FeeSelectionId == guid);
        }
        public IEnumerable<Fee> GetTodayFees()
        {
            return this.Set
                .Where(f => f.ExpirationDate == DateTime.Today);
        }
        public IEnumerable<Fee> GetExpiredByCompanyId()
        {
            return
                from f in this.Set
                join p in this.container.Policies on f.PolicyId equals p.Id
                join r in this.container.Risks on p.Risk.Id equals r.Id
                join co in this.container.Companies on r.CompanyId equals co.Id
                where f.ExpirationDate < DateTime.Today
                    && f.State == 0
                    && f.Annulated == false
                select f;
        }
        public void AssignFeeSelection(IEnumerable<Fee> fees)
        {
            var table = new DataTable();
            table.Columns.Add("Id");
            table.Columns.Add("FeeSelectionId");
            table.Columns.Add("Status");

            foreach (var fee in fees)
            {
                var row = table.NewRow();
                row["Id"] = fee.Id;
                row["FeeSelectionId"] = fee.FeeSelectionId;
                row["Status"] = (int)fee.State;
                table.Rows.Add(row);
            }

            var param = new SqlParameter("@FeesToUpdate", SqlDbType.Structured);
            param.Value = table;
            param.TypeName = "FeeSelectionAssigmentTable";

            var command = "EXEC FeeSelectionAssignment @FeesToUpdate;";

            try

            {
                this.container.Database.ExecuteSqlCommand(command, param);
                SegguContainer.RefreshSet<Fee>();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
