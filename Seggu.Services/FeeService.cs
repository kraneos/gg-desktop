﻿using Seggu.Daos.Interfaces;
using Seggu.Domain;
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
        public IEnumerable<FeeDto> GetByPolicyId(int id)
        {
            var policyId = id;
            var fees = this.feeDao.GetByPolicyId(policyId).OrderBy(X => X.ExpirationDate).ThenBy(x => x.Number);
            return fees.Select(x => FeeDtoMapper.GetDto(x));
        }
        public IEnumerable<FeeDto> GetByEndorseId(int id)
        {
            var endorseId = id;
            var fees = this.feeDao.GetByEndorseId(endorseId).OrderBy(X => X.ExpirationDate).ThenBy(x => x.Number);
            return fees.Select(x => FeeDtoMapper.GetDto(x));
        }
        public IEnumerable<FeeDto> GetByFeeSelectionId(int id)
        {
            var list = this.feeDao.GetByFeeSelectionId(id)
                .OrderBy(x => x.Number)
                .ThenBy(x => x.FeeSelectionId);

            return list.Select(x => FeeDtoMapper.GetDto(x)).OrderBy(x => x.Cliente);
        }
        public IEnumerable<FeeDto> GetCandidatesByCompany(int id, DateTime dateFrom, DateTime dateTo)
        {
            var companyId = id;
            var fees = this.feeDao.GetByCompanyId(companyId, dateFrom, dateTo);
            var list = fees.Select(x => FeeDtoMapper.GetDto(x)).OrderBy(x => x.Cliente)
                .Where(x => x.FeeSelectionId == default(int));
            return list;
        }
        public IEnumerable<FeeDto> GetPayedByCompany(int company_Id, DateTime dateFrom, DateTime dateTo)
        {
            var companyId = company_Id;
            var fees = this.feeDao.GetByCompanyId(companyId, dateFrom, dateTo);
            return fees.Select(x => FeeDtoMapper.GetDto(x)).OrderBy(x => x.Cliente).Where(x => x.Estado == "Pagado");
        }
        public FeeDto GetById(int Id)
        {
            var id = Id;
            var fee = this.feeDao.Get(id);
            return FeeDtoMapper.GetDto(fee);

        }
        public void Update(FeeDto fee)
        {
            feeDao.Update(FeeDtoMapper.GetObject(fee));
        }
        public void UpdateMany(IEnumerable<FeeDto> fees)
        {
            IEnumerable<Fee> objs = fees.Select(x => FeeDtoMapper.GetObject(x));
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
                var convenio = this.GetLastPaymentDay((int)c.Id);
                var fees = feeDao.GetExpiredByCompanyId(c.Id).ToList();
                foreach (Fee f in fees)
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
        public IEnumerable<FeeIndexDto> GetOverduePoliciesToday()
        {
            var fees = this.feeDao.GetOverduePoliciesToday()
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
                var dto = new FeeIndexDto();
                dto.ClientName = x.ClientFirstName + " " + x.ClientLastName;
                dto.FeeNumber = x.FeeNumber.ToString();
                dto.FeeValue = x.FeeValue;
                dto.PolicyNumber = x.PolicyNumber;
                return dto;
            });
        }
        public IEnumerable<FeeIndexDto> GetOverdueEndorsesToday()
        {
            var fees = this.feeDao.GetOverdueEndorsesToday()
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
                var dto = new FeeIndexDto();
                dto.ClientName = x.ClientFirstName + " " + x.ClientLastName;
                dto.FeeNumber = x.FeeNumber.ToString();
                dto.FeeValue = x.FeeValue;
                dto.PolicyNumber = x.PolicyNumber;
                return dto;
            });
        }
    }

}
