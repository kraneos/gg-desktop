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

        public IEnumerable<CoverageDto> GetAllByRiskId(int Id)
        {
            var coverages = coverageDao.GetAll();
            return coverages
                .Where(c => c.Risks.Any(r => r.Id == Id))
                .Select(c => CoverageDtoMapper.GetDto(c))
                .OrderBy(x => x.Name);
        }
        public IEnumerable<CoverageDto> GetAll()
        {
            var coverages = coverageDao.GetAll();
            return coverages.OrderBy(x => x.Name).Select(u => CoverageDtoMapper.GetDto(u));
        }
 
        public void Delete(int id)
        {
            try
            {
                var guid = id;
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
        public bool ExistNameId(string name, int id, int riskId)
        {
            if (id == default(int))
            {
                return true;
            }

            if (riskId == default(int))
            {
                return true;
            }

            var coverageId = id;
            var riskIds = riskId;
            return coverageDao.GetByNameId(name, coverageId, riskIds);
        }
        public bool ExistNameRisk(string name, int idRisk)
        {

            if (idRisk == default(int))
            {
                return true;
            }
            var id = idRisk;
            return coverageDao.GetByNameRisk(name, id);
        }
    }
}
