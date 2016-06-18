﻿using Seggu.Daos.Interfaces;
using Seggu.Dtos;
using Seggu.Services.DtoMappers;
using Seggu.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Seggu.Services
{
    public sealed class RiskService : IRiskService
    {
        private IRiskDao riskDao;
        private ICoverageDao coverageDao;
        private ICoveragesPackDao coveragePackDao;

        public RiskService(IRiskDao riskDao, ICoverageDao coverageDao, ICoveragesPackDao coveragePackDao)
        {
            this.riskDao = riskDao;
            this.coverageDao = coverageDao;
            this.coveragePackDao = coveragePackDao;
        }

        public IEnumerable<RiskCompanyDto> GetByCompany(long id)
        {
            var companyId = id;
            var risks = this.riskDao.GetByCompanyWithCoveragePacks(companyId);
            return risks.Select(x => RiskDtoMapper.GetRiskCompanyDto(x));
        }

        public void Delete(long id)
        {
            var guid = id;
            riskDao.Delete(guid);
        }

        public void Create(RiskCompanyDto risk)
        {
            riskDao.Save(RiskDtoMapper.GetObject(risk));
        }

        public bool ExistName(string name)
        {
            return riskDao.GetByName(name);
        }

        public void Update(RiskCompanyDto risk)
        {
            riskDao.Update(RiskDtoMapper.GetObject(risk));
        }

        public bool ExistNameId(string name, long id)
        {
            if (id == default(int))
            {
                return true;
            }

            var riskId = id;
            return riskDao.BetByNameId(name, riskId);
        }

        public bool HasCoverages(long id)
        {
            if (id == default(int))
            {
                return true;
            }

            var riskId = id;
            return coverageDao.RiskHasCoverage(riskId);
        }

        public bool HasPackages(long id)
        {
            if (id == default(int))
            {
                return true;
            }

            var riskId = id;
            return coveragePackDao.HasRiskPackege(riskId);
        }

        public IEnumerable<RiskItemDto> GetByCompanyCombobox(long companyId)
        {
            return this.riskDao.GetAll()
                .Where(x => x.CompanyId == companyId)
                .OrderBy(x => x.Name)
                .Select(x => new RiskItemDto { Id = (int)x.Id, Name = x.Name, RiskType = x.RiskType });
        }

        public IEnumerable<RiskCompanyDto> GetByCompanyAndRiskType(long id, string riskType)
        {
            return riskDao.GetByCompanyAndRiskType(id, RiskTypeDtoMapper.ToEnum(riskType)).Select(RiskDtoMapper.GetRiskCompanyDto);
        }
    }
}
