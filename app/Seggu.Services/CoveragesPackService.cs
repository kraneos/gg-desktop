using Seggu.Daos.Interfaces;
using Seggu.Dtos;
using Seggu.Services.DtoMappers;
using Seggu.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Seggu.Services
{
    public sealed class CoveragesPackService : ICoveragesPackService
    {
        ICoveragesPackDao coveragesPackDao;
               
        public CoveragesPackService(ICoveragesPackDao coveragesPackDao)
        {
            this.coveragesPackDao = coveragesPackDao;
        }
        public IEnumerable<CoveragesPackDto> GetById(string selectedCovPackid)
        {
            var co =  coveragesPackDao.GetAll();
            return co.Where(cp => cp.Id == new Guid(selectedCovPackid))
                .Select(cp => CoveragesPackDtoMapper.GetDto(cp));
        }
        public IEnumerable<CoveragesPackDto> GetAllByRiskId(string riskId)
        {
            var coveragePack = this.coveragesPackDao.GetAll();
            var list = coveragePack.OrderBy(x => x.Name)
                .Where(c => c.RiskId == new Guid(riskId))
                .Select(c => CoveragesPackDtoMapper.GetDto(c));
            return list;
        }
        public void Create(CoveragesPackDto coveragesPack)
        {
            coveragesPackDao.Save(CoveragesPackDtoMapper.GetObject(coveragesPack));
        }
        public string GetPackIdByCoverageId(string id, string riskId)
        {
            var coveragesPacks = coveragesPackDao.GetByRiskId(new Guid(riskId));
            return coveragesPacks.FirstOrDefault(cp => cp.Coverages.Count != 0
                && cp.Coverages.Any(x => x.Id == new Guid(id))).Id.ToString();
        }
        public void Update(CoveragesPackDto coveragesPack)
        {
            var c = CoveragesPackDtoMapper.GetObject(coveragesPack);
            coveragesPackDao.UpdateCoveragesPack(c);
        }


        public void Delete(string id)
        {
            var idPack = new Guid(id);
            coveragesPackDao.Delete(idPack);
        }


        public bool ExistName(string name)
        {
            return coveragesPackDao.GetByName(name);
        }

        public bool ExistNameRisk(string name, string idRisk)
        {
            if (idRisk == null)
            {
                return true;
            }
            Guid id = new Guid(idRisk);
            return coveragesPackDao.BetByNameRisk(name, id);
        }

        public bool ExistNameId(string name, string id, string riskId)
        {
            if (id == null)
            {
                return true;
            }

            if (riskId == null)
            {
                return true;
            }

            Guid coverageId = new Guid(id);
            Guid riskIds = new Guid(riskId);
            return coveragesPackDao.BetByNameId(name, coverageId, riskIds);
        }
    }

}
