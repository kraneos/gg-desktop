using Seggu.Daos.Interfaces;
using Seggu.Data;
using Seggu.Dtos;
using Seggu.Services.DtoMappers;
using Seggu.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Seggu.Services
{
    public sealed class FeeService : IFeeService
    {
        private IFeeDao feeDao;
        private ICompanyDao companyDao;
        public FeeService(ICompanyDao companyDao, IFeeDao feeDao)
        {
            this.feeDao = feeDao;
            this.companyDao = companyDao;
        }
        public IEnumerable<FeeDto> GetByPolicyId(string id)
        {
            var policyId = new Guid(id);
            var fees = this.feeDao.GetByPolicyId(policyId).OrderBy(X => X.ExpirationDate).ThenBy(x => x.Number);
            return fees.Select(x => FeeDtoMapper.GetDto(x));
        }
        public IEnumerable<FeeDto> GetByEndorseId(string id)
        {
            var endorseId = new Guid(id);
            var fees = this.feeDao.GetByEndorseId(endorseId).OrderBy(X => X.ExpirationDate).ThenBy(x => x.Number);
            return fees.Select(x => FeeDtoMapper.GetDto(x));
        }
        public IEnumerable<FeeDto> GetByFeeSelectionId(string id)
        {
            var list = this.feeDao.GetByFeeSelectionId(new Guid(id))
                .OrderBy(x => x.Number)
                .ThenBy(x => x.FeeSelectionId);

            return list.Select(x => FeeDtoMapper.GetDto(x)).OrderBy(x => x.Cliente);
        }
        public IEnumerable<FeeDto> GetCandidatesByCompany(string id, DateTime dateFrom, DateTime dateTo)
        {
            var companyId = new Guid(id);
            var fees = this.feeDao.GetByCompanyId(companyId, dateFrom, dateTo);
            var list = fees.Select(x => FeeDtoMapper.GetDto(x)).OrderBy(x => x.Cliente)
                .Where(x => x.FeeSelectionId == "");
            return list;
        }
        public IEnumerable<FeeDto> GetPayedByCompany(string company_Id, DateTime dateFrom, DateTime dateTo)
        {
            var companyId = new Guid(company_Id);
            var fees = this.feeDao.GetByCompanyId(companyId, dateFrom, dateTo);
            return fees.Select(x => FeeDtoMapper.GetDto(x)).OrderBy(x => x.Cliente).Where(x => x.Estado == "Pagado");
        }
        public FeeDto GetById(string Id)
        {
            var id = new Guid(Id);
            var fee = this.feeDao.Get(id);
            return FeeDtoMapper.GetDto(fee);

        }
        public void Update(FeeDto fee)
        {
            feeDao.Update(FeeDtoMapper.GetObject(fee));
        }
        public void UpdateMany(IEnumerable<FeeDto> fees)
        {
            IEnumerable<Seggu.Data.Fee> objs = fees.Select(x => FeeDtoMapper.GetObject(x));
            feeDao.AssignFeeSelection(objs);
        }
        public int TodayExpirationFeesCount()
        {
            var fees = this.feeDao.GetTodayFees().ToList();
            return fees.Count();
        }
        public void UpdateFeeStates()
        {
            var companies = companyDao.GetAll();
            foreach (Company c in companies)
            {
                var convenio = this.GetLastPaymentDay(c.Id);
                var fees = feeDao.GetExpiredByCompanyId(c.Id).ToList();
                foreach (Fee f in fees)
                {
                    f.State = convenio < f.ExpirationDate ? FeeStateDtoMapper.ToEnum("Sin Cobertura")
                        : FeeStateDtoMapper.ToEnum("Moroso");
                    feeDao.Update(f);
                }
            }
        }
            private DateTime GetLastPaymentDay(Guid companyId)
            {
                var company = companyDao.GetById(companyId);
                int today = DateTime.Today.Day;
                int year = DateTime.Today.Year;
                int month = DateTime.Today.Month;
                DateTime paymentDay2 = new DateTime(year, month, company.PaymentDay2);
                DateTime paymentDay1 = new DateTime(year, month, company.PaymentDay1);
                DateTime prevPaymentDay1 = new DateTime(year, month - 1, company.PaymentDay1);
                if (DateTime.Today < paymentDay2)
                    return prevPaymentDay1;
                else if (DateTime.Today > paymentDay1)
                    return paymentDay1;
                else
                    return paymentDay2;
            }
    }

}
