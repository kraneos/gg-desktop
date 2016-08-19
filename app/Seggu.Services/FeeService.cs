using Seggu.Daos.Interfaces;
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
        private readonly IFeeDao feeDao;
        private readonly ICompanyDao companyDao;
        public FeeService(ICompanyDao companyDao, IFeeDao feeDao)
        {
            this.feeDao = feeDao;
            this.companyDao = companyDao;
        }
        public IEnumerable<FeeDto> GetByPolicyId(int id)
        {
            var policyId = id;
            var fees = feeDao.GetByPolicyId(policyId).OrderBy(x => x.ExpirationDate).ThenBy(x => x.Number);
            return fees.Select(FeeDtoMapper.GetDto);
        }
        public IEnumerable<FeeDto> GetByEndorseId(int id)
        {
            var endorseId = id;
            var fees = feeDao.GetByEndorseId(endorseId).OrderBy(x => x.ExpirationDate).ThenBy(x => x.Number);
            return fees.Select(FeeDtoMapper.GetDto);
        }
        public IEnumerable<FeeDto> GetByFeeSelectionId(int id)
        {
            var list = feeDao.GetByFeeSelectionId(id)
                .OrderBy(x => x.Number)
                .ThenBy(x => x.FeeSelectionId);

            return list.Select(FeeDtoMapper.GetDto).OrderBy(x => x.Cliente);
        }
        public IEnumerable<FeeDto> GetCandidatesByCompany(int id, DateTime dateFrom, DateTime dateTo)
        {
            var companyId = id;
            var fees = feeDao.GetByCompanyId(companyId, dateFrom, dateTo);
            var list = fees.Select(FeeDtoMapper.GetDto).OrderBy(x => x.Cliente)
                .Where(x => x.FeeSelectionId == default(int));
            return list;
        }
        public IEnumerable<FeeDto> GetPayedByCompany(int company_Id, DateTime dateFrom, DateTime dateTo)
        {
            var companyId = company_Id;
            var fees = this.feeDao.GetByCompanyId(companyId, dateFrom, dateTo);
            return fees.Select(FeeDtoMapper.GetDto).OrderBy(x => x.Cliente).Where(x => x.Estado == "Pagado");
        }
        public FeeDto GetById(int Id)
        {
            var id = Id;
            var fee = feeDao.Get(id);
            return FeeDtoMapper.GetDto(fee);

        }
        public void Update(FeeDto fee)
        {
            feeDao.Update(FeeDtoMapper.GetObject(fee));
        }
        public void UpdateMany(IEnumerable<FeeDto> fees)
        {
            var objs = fees.Select(FeeDtoMapper.GetObject);
            feeDao.AssignFeeSelection(objs.ToList());
        }
        public int TodayExpirationFeesCount()
        {
            var fees = feeDao.GetTodayFees().ToList();
            return fees.Count;
        }
        public void UpdateFeeStates()
        {
            var companies = companyDao.GetAll();
            foreach (var c in companies)
            {
                var convenio = GetLastPaymentDay((int)c.Id);
                var fees = feeDao.GetExpiredByCompanyId(c.Id).ToList();
                foreach (var f in fees)
                {
                    f.State = convenio < f.ExpirationDate ? FeeStateDtoMapper.ToEnum("Sin Cobertura")
                        : FeeStateDtoMapper.ToEnum("Moroso");
                    feeDao.Update(f);
                }
            }
        }
        private DateTime GetLastPaymentDay(int companyId)
        {
            var company = companyDao.GetById(companyId);
            var year = DateTime.Today.Year;
            var month = DateTime.Today.Month;
            var paymentDay2 = new DateTime(year, month, company.PaymentDay2);
            var paymentDay1 = new DateTime(year, month, company.PaymentDay1);
            var prevPaymentDay1 = new DateTime(year, month - 1, company.PaymentDay1);
            if (DateTime.Today < paymentDay2)
                return prevPaymentDay1;
            else if (DateTime.Today > paymentDay1)
                return paymentDay1;
            else
                return paymentDay2;
        }
        public IEnumerable<FeeIndexDto> GetOverduePoliciesToday()
        {
            var fees = feeDao.GetOverduePoliciesToday()
                .Select(x => new
                {
                    FeeNumber = x.Number,
                    FeeValue = x.Value,
                    PolicyNumber = x.Policy.Number,
                    ClientFirstName = x.Policy.Client.FirstName,
                    ClientLastName = x.Policy.Client.LastName
                }).ToList();
            return fees.Select(x =>
            {
                var dto = new FeeIndexDto
                {
                    ClientName = x.ClientFirstName + " " + x.ClientLastName,
                    FeeNumber = x.FeeNumber.ToString(),
                    FeeValue = x.FeeValue,
                    PolicyNumber = x.PolicyNumber
                };
                return dto;
            });
        }
        public IEnumerable<FeeIndexDto> GetOverdueEndorsesToday()
        {
            var fees = feeDao.GetOverdueEndorsesToday()
                .Select(x => new
                {
                    FeeNumber = x.Number,
                    FeeValue = x.Value,
                    PolicyNumber = x.Endorse.Policy.Number,
                    ClientFirstName = x.Policy.Client.FirstName,
                    ClientLastName = x.Policy.Client.LastName,
                    ClientName = x.Policy.Client.FirstName + " " + x.Policy.Client.LastName
                }).ToList();
            return fees.Select(x =>
            {
                var dto = new FeeIndexDto
                {
                    ClientName = x.ClientFirstName + " " + x.ClientLastName,
                    FeeNumber = x.FeeNumber.ToString(),
                    FeeValue = x.FeeValue,
                    PolicyNumber = x.PolicyNumber
                };
                return dto;
            });
        }
    }

}
