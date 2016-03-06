using Seggu.Daos.Interfaces;
using Seggu.Data;
using Seggu.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Seggu.Daos
{
    public sealed class FeeDao : IdParseEntityDao<Fee>, IFeeDao
    {
        public FeeDao(SegguDataModelContext context)
            : base(context)
        {

        }
        public IEnumerable<Fee> GetByPolicyId(long guid)
        {
            return this.Set
                .Where(f => f.PolicyId == guid);
        }
        public IEnumerable<Fee> GetByEndorseId(long guid)
        {
            return this.Set
                .Where(f => f.EndorseId == guid);
        }
        public IEnumerable<Fee> GetByCompanyId(long guid, DateTime dateFrom, DateTime dateTo)
        {
            return
                from f in this.Set
                join p in this.context.Policies on f.PolicyId equals p.Id
                join r in this.context.Risks on p.Risk.Id equals r.Id
                join co in this.context.Companies on r.CompanyId equals co.Id
                where co.Id == guid
                    && f.ExpirationDate >= dateFrom && f.ExpirationDate <= dateTo
                    && f.Annulated == false
                select f;
            //return this.Set.Include("Policy.Coverage.Risk.Company")
            //    .Where(f => f.Policy.Coverage.Risk.CompanyId == guid);
        }
        public IEnumerable<Fee> GetExpiredByCompanyId(long guid)
        {
            return
                from f in this.Set
                join p in this.context.Policies on f.PolicyId equals p.Id
                join r in this.context.Risks on p.Risk.Id equals r.Id
                join co in this.context.Companies on r.CompanyId equals co.Id
                where co.Id == guid
                    && f.ExpirationDate < DateTime.Today
                    && f.State == 0
                    && f.Annulated == false
                select f;
        }
        public IEnumerable<Fee> GetByFeeSelectionId(long guid)
        {
            return this.context.Fees
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
                join p in this.context.Policies on f.PolicyId equals p.Id
                join r in this.context.Risks on p.Risk.Id equals r.Id
                join co in this.context.Companies on r.CompanyId equals co.Id
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
                row["Status"] = (long)fee.State;
                table.Rows.Add(row);
            }

            var param = new SqlParameter("@FeesToUpdate", SqlDbType.Structured);
            param.Value = table;
            param.TypeName = "FeeSelectionAssigmentTable";

            var command = "EXEC FeeSelectionAssignment @FeesToUpdate;";

            try
            {
                this.context.Database.ExecuteSqlCommand(command, param);
                this.context.RefreshSet<Fee>();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public IEnumerable<Fee> GetOverdueEndorsesToday()
        {
            return this.Set.Where(x => x.ExpirationDate == DateTime.Today);
        }
        public IEnumerable<Fee> GetOverduePoliciesToday()
        {
            return this.Set.Where(x => x.ExpirationDate == DateTime.Today);
        }
    }
}
