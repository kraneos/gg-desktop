using AutoMapper;
using Seggu.Daos.Interfaces;
using Seggu.Data;
using Seggu.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Seggu.Daos
{
    public sealed class FeeDao : IdParseEntityDao<Fee>, IFeeDao
    {
        public FeeDao()
            : base()
        {

        }
        public List<Fee> GetByPolicyId(long guid)
        {
            using (var context = SegguDataModelContext.Create())
            {
                return context.Fees
                    .Where(f => f.PolicyId == guid).ToList();
            }
        }
        public List<Fee> GetByEndorseId(long guid)
        {
            using (var context = SegguDataModelContext.Create())
            {
                return context.Fees
                    .Where(f => f.EndorseId == guid).ToList();
            }
        }
        public List<Fee> GetByCompanyId(long guid, DateTime dateFrom, DateTime dateTo)
        {
            using (var context = SegguDataModelContext.Create())
            {
                return
                    (from f in context.Fees
                     join p in context.Policies on f.PolicyId equals p.Id
                     join r in context.Risks on p.Risk.Id equals r.Id
                     join co in context.Companies on r.CompanyId equals co.Id
                     where co.Id == guid
                         && f.ExpirationDate >= dateFrom && f.ExpirationDate <= dateTo
                         && f.Annulated == false
                     select f).ToList();
            }
            //return this.Set.Include("Policy.Coverage.Risk.Company")
            //    .Where(f => f.Policy.Coverage.Risk.CompanyId == guid);
        }
        public List<Fee> GetExpiredByCompanyId(long guid)
        {
            using (var context = SegguDataModelContext.Create())
            {
                return
                    (from f in context.Fees
                     join p in context.Policies on f.PolicyId equals p.Id
                     join r in context.Risks on p.Risk.Id equals r.Id
                     join co in context.Companies on r.CompanyId equals co.Id
                     where co.Id == guid
                         && f.ExpirationDate < DateTime.Today
                         && f.State == 0
                         && f.Annulated == false
                     select f).ToList();
            }
        }
        public List<Fee> GetByFeeSelectionId(long guid)
        {
            using (var context = SegguDataModelContext.Create())
            {
                return context.Fees
                    .Where(f => f.FeeSelectionId == guid).ToList();
            }
        }
        public List<Fee> GetTodayFees()
        {
            using (var context = SegguDataModelContext.Create())
            {
                return context.Fees
                    .Where(f => f.ExpirationDate == DateTime.Today).ToList();
            }
        }
        public List<Fee> GetExpiredByCompanyId()
        {
            using (var context = SegguDataModelContext.Create())
            {
                return
                    (from f in context.Fees
                     join p in context.Policies on f.PolicyId equals p.Id
                     join r in context.Risks on p.Risk.Id equals r.Id
                     join co in context.Companies on r.CompanyId equals co.Id
                     where f.ExpirationDate < DateTime.Today
                         && f.State == 0
                         && f.Annulated == false
                     select f).ToList();
            }
        }
        public void AssignFeeSelection(List<Fee> fees)
        {
            using (var context = SegguDataModelContext.Create())
            {
                var modifiedFees = new List<Fee>();
                foreach (var fee in fees)
                {
                    var existingFee = context.Fees.Find(fee.Id);
                    existingFee.FeeSelectionId = fee.FeeSelectionId;
                    existingFee.State = fee.State;
                    modifiedFees.Add(existingFee);
                }
                context.SaveChanges();
            }
        }
        public List<Fee> GetOverdueEndorsesToday()
        {
            using (var context = SegguDataModelContext.Create())
            {
                return context.Fees.Where(x => x.ExpirationDate == DateTime.Today).ToList();
            }
        }
        public List<Fee> GetOverduePoliciesToday()
        {
            using (var context = SegguDataModelContext.Create())
            {
                return context.Fees.Where(x => x.ExpirationDate == DateTime.Today).ToList();
            }
        }

        public override void Update(Fee obj)
        {
            using (var context = SegguDataModelContext.Create())
            {
                var orig = context.Fees.Find(obj.Id);
                Mapper.Map<Fee, Fee>(obj, orig);
                context.SaveChanges();
            }
        }
    }
}
