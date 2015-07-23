using Seggu.Daos.Interfaces;
using Seggu.Dtos;
using Seggu.Services.DtoMappers;
using Seggu.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Seggu.Services
{
    public sealed class CoverageService : ICoverageService
    {
        private ICoverageDao coverageDao;

        public CoverageService(ICoverageDao coverageDao)
        {
            this.coverageDao = coverageDao;
        }

        public IEnumerable<CoverageDto> GetAllByRiskId(string Id)
        {
            var coverage = this.coverageDao.GetAll();
            return coverage
                .Where(c => c.RiskId == new Guid(Id))
                .Select(c => CoverageDtoMapper.GetDto(c))
                .OrderBy(x => x.Name);
        }
        public IEnumerable<CoverageDto> GetByPackId(string Id)
        {
            var id = new Guid(Id);
            var coverage = this.coverageDao.GetContainer().CoveragesPacks.Single(x => x.Id == id).Coverages.ToList();
            //.Where(c => c.CoveragesPacks.Any(cp => cp.Id == new Guid(Id)))
            //.Select(c => CoverageDtoMapper.GetDto(c))
            //.OrderBy(x => x.Name)
            //.ToList();
            return coverage.Select(c => CoverageDtoMapper.GetDto(c));
        }

        public void Delete(string id)
        {
            try
            {
                var guid = new Guid(id);
                coverageDao.Delete(guid);
            }
            catch (Exception) { throw; }
        }
        public void DeleteMany(IEnumerable<CoverageDto> coverageDtos)
        {
            var coverages = coverageDtos.Select(c => CoverageDtoMapper.GetObject(c));
            foreach (var cov in coverages)
            {
                coverageDao.Delete(cov.Id);
            }
            //coverageDao.DeleteMany(coverages);
        }
        public void Update(CoverageDto coverage)
        {
            var c = CoverageDtoMapper.GetObject(coverage);
            coverageDao.Update(c);
        }
        public void Save(CoverageDto coverage)
        {
            var c = CoverageDtoMapper.GetObject(coverage);
            coverageDao.Save(c);
        }


        public bool ExistName(string name)
        {
            return coverageDao.GetByName(name);
        }


        public bool ExistNameId(string name, string id, string riskId)
        {
            if (id == null )
            {
                return true;
            }

            if (riskId == null)
            {
                return true;
            }

            Guid coverageId = new Guid(id);
            Guid riskIds = new Guid(riskId);
            return coverageDao.BetByNameId(name, coverageId, riskIds);
        }


        public bool ExistNameRisk(string name, string idRisk)
        {
            
            if (idRisk == null)
            {
                return true;
            }
            Guid id = new Guid(idRisk);
            return coverageDao.BetByNameRisk(name, id);
        }
    }
}
