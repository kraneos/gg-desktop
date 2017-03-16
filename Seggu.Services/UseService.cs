using Seggu.Daos.Interfaces;
using Seggu.Dtos;
using Seggu.Services.DtoMappers;
using Seggu.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seggu.Services
{
    public sealed class UseService : IUseService
    {
        private IUseDao useDao;

        public UseService(IUseDao useDao)
        {
            this.useDao = useDao;
        }

        public IEnumerable<UseDto> GetAll()
        {
            var uses = this.useDao.GetAll();
            return uses.OrderBy(x => x.Name).Select(u => UseDtoMapper.GetDto(u));
        }

        public void Save(UseDto use)
        {
            //use.Id = new Guid().ToString();
            this.useDao.Save(UseDtoMapper.GetUse(use));
        }

        public void Update(UseDto use)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            try
            {
                var guid = id;
                useDao.Delete(guid);
            }
            catch
            {
                throw;
            }
        }

        public bool ExistName(string name)
        {
            return useDao.GetByName(name);
        }

        public IEnumerable<UseDto> GetByVehicleType(int vehicleTypeId)
        {
            var uses = this.useDao.GetByVehicleType(vehicleTypeId);
            return uses.Select(x => UseDtoMapper.GetDto(x));
        }

        public void SaveChanges(VehicleTypeDto vehicleTypeDto, IEnumerable<UseDto> existing)
        {
            this.useDao.SaveChanges(VehicleTypeDtoMapper.GetObject(vehicleTypeDto), existing.Select(x => UseDtoMapper.GetUse(x)));
        }
    }
}
