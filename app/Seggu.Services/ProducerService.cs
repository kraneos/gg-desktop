using Seggu.Daos.Interfaces;
using Seggu.Dtos;
using Seggu.Services.DtoMappers;
using Seggu.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Seggu.Services
{
    public class ProducerService : IProducerService
    {
        private IProducerCodeDao producerCodeDao;
        private IProducerDao producerDao;

        public ProducerService(IProducerDao producerDao, IProducerCodeDao producerCodeDao)
        {
            this.producerCodeDao = producerCodeDao;
            this.producerDao = producerDao;
        }
        public IEnumerable<ProducerDto> GetCollectors()
        {
            return this
                .producerDao
                .GetCollectors()
                .Select(x => ProducerDtoMapper.GetDto(x));
        }
        public IEnumerable<ProducerDto> GetProducers()
        {
            var list = this.producerDao.GetAll();
            return list.OrderBy(x => x.Name).Select(p => ProducerDtoMapper.GetDto(p));
        }

        public ProducerCompanyDto GetByIdAndCompanyId(int producerId, int companyId)
        {
            var one = this
                .producerCodeDao
                .GetAll()
                .Where(x => x.CompanyId == companyId && (x.ProducerId == producerId))
                .Select(x => ProducerDtoMapper.GetProducerCompanyDto(x)).Single();             
            return one;
        }
        public void Delete(int id)
        {
            var guid = id;
            producerDao.Delete(guid);
        }
        public void Save(ProducerDto producer)
        {
            var isNew = producer.Id== default(int);
            var prod = ProducerDtoMapper.GetObject(producer);
            if (isNew)
                this.producerDao.Save(prod);
            else
                this.producerDao.Update(prod);
        }

        public ProducerDto GetById(int producerId)
        {
            var id = producerId;
            var producer = producerDao.Get(id);
            return ProducerDtoMapper.GetDto(producer);
        }

        public bool GetByRegistrationNumber(string registrationNumber, int producerId)
        {
            if (producerId == default(int))
            {
                return producerDao.GetByRegistrationNumber(registrationNumber);
            }
            else
            {
                var id = producerId;
                return producerDao.GetByRegistrationNumberId(registrationNumber, id);
            }
        }

        public bool HasCompany(int producerId)
        {
            var validation = producerCodeDao.ProducerHasCompany(producerId);
            return validation; 
        }

        public IEnumerable<ProducerCodeDto> GetByCompanyId(int companyId)
        {
            var list = producerCodeDao.GetByCompany(companyId);
            return list.OrderBy(x => x.Code).Select(p => ProducerCodeDtoMapper.GetDto(p));
            
        }

        public bool HasPolicies(int producerId)
        {
            if (producerId != default(int))
            {
                var guid = producerId;

                return this.producerCodeDao.GetContainer().Policies.Any(x => x.ProducerId == guid || x.CollectorId == guid);
            }
            
            return false;
        }
    }
}
