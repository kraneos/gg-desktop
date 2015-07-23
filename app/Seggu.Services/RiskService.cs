using Seggu.Daos.Interfaces;
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

        public IEnumerable<RiskCompanyDto> GetByCompany(string Id)
        {
            Guid companyId = new Guid(Id);
            var risks = this.riskDao.GetAll()
                .OrderBy(x => x.Name)
                .Where(r => r.Company.Id == companyId);
            return
                from x in risks
                select RiskDtoMapper.GetRiskCompanyDto(x);
        }
        public void Delete(string id)
        {
            var guid = new Guid(id);
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


        public bool ExistNameId(string name, string id)
        {
            if (id == null)
            {
                return true;
            }

            Guid riskId = new Guid(id);
            return riskDao.BetByNameId(name, riskId);
        }


        public bool HasCoverages(string id)
        {
            if (id == null)
            {
                return true;
            }

            Guid riskId = new Guid(id);
            return coverageDao.RiskHasCoverage(riskId);
        }


        public bool HasPackages(string id)
        {
            if (id == null)
            {
                return true;
            }

            Guid riskId = new Guid(id);
            return coveragePackDao.HasRiskPackege(riskId);
        }
    }
}
