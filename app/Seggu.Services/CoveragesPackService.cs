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
            var pack = coveragesPacks.FirstOrDefault(cp => cp.Coverages.Count != 0
                && cp.Coverages.Any(x => x.Id == id));
            return pack == null ? -1 : (int)pack.Id;
        }
        public void Update(CoveragesPackDto coveragesPack)
        {
            var c = CoveragesPackDtoMapper.GetObject(coveragesPack);
            coveragesPackDao.UpdateCoveragesPack(c);
        }
        public void Delete(long id)
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
            if (idRisk == default(int))
            {
                return true;
            }
            var id = idRisk;
            return coveragesPackDao.GetByNameRisk(name, id);
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
            return coveragesPackDao.GetByNameId(name, coverageId, riskIds);
        }

        public IEnumerable<KeyValueDto> GetAllByRiskIdCombobox(int riskId)
        {
            return this.coveragesPackDao
                .GetByRiskId(riskId)
                .OrderBy(x => x.Name)
                .Select(x => new KeyValueDto { Id = (int)x.Id, Name = x.Name });
        }
    }
}
