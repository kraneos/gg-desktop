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
        public IEnumerable<CoveragesPackDto> GetById(int selectedCovPackid)
        {
            var co = coveragesPackDao.GetAll();
            return co.Where(cp => cp.Id == selectedCovPackid)
                .Select(cp => CoveragesPackDtoMapper.GetDto(cp));
        }
        public IEnumerable<CoveragesPackDto> GetAllByRiskId(int riskId)
        {
            var coveragePack = this.coveragesPackDao.GetAll();
            var list = coveragePack.OrderBy(x => x.Name)
                .Where(c => c.RiskId == riskId)
                .Select(c => CoveragesPackDtoMapper.GetDto(c));
            return list;
        }
        public void Create(CoveragesPackDto coveragesPack)
        {
            coveragesPackDao.Save(CoveragesPackDtoMapper.GetObject(coveragesPack));
        }
        public int GetPackIdByCoverageId(int id, int riskId)
        {
            var coveragesPacks = coveragesPackDao.GetByRiskId(riskId);
            return coveragesPacks.FirstOrDefault(cp => cp.Coverages.Count != 0
                && cp.Coverages.Any(x => x.Id == id)).Id;
        }
        public void Update(CoveragesPackDto coveragesPack)
        {
            var c = CoveragesPackDtoMapper.GetObject(coveragesPack);
            coveragesPackDao.UpdateCoveragesPack(c);
        }
        public void Delete(int id)
        {
            var idPack = id;
            coveragesPackDao.Delete(idPack);
        }
        public bool ExistName(string name)
        {
            return coveragesPackDao.GetByName(name);
        }
        public bool ExistNameRisk(string name, int idRisk)
        {
            if (idRisk == null)
            {
                return true;
            }
            var id = idRisk;
            return coveragesPackDao.BetByNameRisk(name, id);
        }
        public bool ExistNameId(string name, int id, int riskId)
        {
            if (id == null)
            {
                return true;
            }

            if (riskId == null)
            {
                return true;
            }

            var coverageId = id;
            var riskIds = riskId;
            return coveragesPackDao.BetByNameId(name, coverageId, riskIds);
        }
    }
}
