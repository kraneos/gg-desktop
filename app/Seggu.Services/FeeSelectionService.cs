using Seggu.Daos.Interfaces;
using Seggu.Dtos;
using Seggu.Services.DtoMappers;
using Seggu.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Seggu.Services
{
    public sealed class FeeSelectionService : IFeeSelectionService
    {
        private IFeeSelectionDao feeSelectionDao;
        public FeeSelectionService(IFeeSelectionDao feeSelectionDao)
        {
            this.feeSelectionDao = feeSelectionDao;
        }
        public IEnumerable<FeeSelectionDto> GetByLiquidation(int liquidationId)
        {
            var list = this.feeSelectionDao.GetAll();
            return list.Where(x => x.LiquidationId == liquidationId)
                .OrderBy(x => x.Name).Select(x => FeeSelectionDtoMapper.GetDto(x));
        }
        public int Save(FeeSelectionDto feeSelection)
        {
            bool isNew = feeSelection.Id == default(int);
            var feeSelect = FeeSelectionDtoMapper.GetObject(feeSelection);
            if (isNew)
            {
                return feeSelectionDao.Save(feeSelect, default(int));
            }
            else
            {
                feeSelectionDao.Update(feeSelect);
                return feeSelection.Id;
            }
        }
        public void Delete(FeeSelectionDto dto)
        {
            var obj = FeeSelectionDtoMapper.GetObject(dto);
            feeSelectionDao.Delete(obj.Id);
        }
    }
}
