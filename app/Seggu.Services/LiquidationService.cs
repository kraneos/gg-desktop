using Seggu.Daos.Interfaces;
using Seggu.Dtos;
using Seggu.Services.DtoMappers;
using Seggu.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;


namespace Seggu.Services
{
    public sealed class LiquidationService : ILiquidationService
    {
        private ILiquidationDao liquidationDao;
        public LiquidationService(ILiquidationDao liquidationDao)
        {
            this.liquidationDao = liquidationDao;
        }
        public IEnumerable<LiquidationDto> GetAll()
        {
            var list = this.liquidationDao.GetAll();
            return list.OrderByDescending(x => x.Date).Select(x => LiquidationDtoMapper.GetDto(x));
        }
        public void Save(LiquidationDto liquidation)
        {
            bool isNew = liquidation.Total == 0 ? true : false;
            var liqui = LiquidationDtoMapper.GetObject(liquidation);
            if (isNew)
                liquidationDao.Create(liqui, liquidation.Id);
                //¿por qué no se usa el genericDao?¿para qué necesito el ID?
                //porque necesitaba generar el Id antes de guardarlo para los feeSelection o algo así
            else
                liquidationDao.Update(liqui);
        }
        public void Delete(LiquidationDto dto)
        {
            var x = LiquidationDtoMapper.GetObject(dto);
            liquidationDao.Delete(x.Id);
        } 
    }
}
