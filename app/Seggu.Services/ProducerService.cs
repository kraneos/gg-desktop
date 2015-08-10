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

        public ProducerCompanyDto GetByIdAndCompanyId(string producerId, string companyId)
        {
            var one = this
                .producerCodeDao
                .GetAll()
                .Where(x => x.CompanyId == new Guid(companyId) && (x.ProducerId == new Guid(producerId)))
                .Select(x => ProducerDtoMapper.GetProducerCompanyDto(x)).Single();             
            return one;
        }
        public void Delete(string id)
        {
            var guid = new Guid(id);
            producerDao.Delete(guid);
        }
        public void Save(ProducerDto producer)
        {
            var isNew = string.IsNullOrEmpty(producer.Id);
            var prod = ProducerDtoMapper.GetObject(producer);
            if (isNew)
                this.producerDao.Save(prod);
            else
                this.producerDao.Update(prod);
        }

        public ProducerDto GetById(string producerId)
        {
            var id = new Guid(producerId);
            var producer = producerDao.Get(id);
            return ProducerDtoMapper.GetDto(producer);
        }

        public bool GetByRegistrationNumber(string registrationNumber, String producerId)
        {
            if (producerId == null)
            {
                return producerDao.GetByRegistrationNumber(registrationNumber);
            }
            else
            {
                Guid id = new Guid(producerId);
                return producerDao.GetByRegistrationNumberId(registrationNumber, id);
            }
        }

        public bool HasCompany(string producerId)
        {
            var id = new Guid(producerId);
            var validation = producerCodeDao.ProducerHasCompany(id);
            return validation; 
        }

        public IEnumerable<ProducerCodeDto> GetByCompanyId(string companyId)
        {
            var id = new Guid(companyId);
            var list = producerCodeDao.GetByCompany(id);
            return list.OrderBy(x => x.Code).Select(p => ProducerCodeDtoMapper.GetDto(p));
            
        }

        public bool HasPolicies(string producerId)
        {
            if (!string.IsNullOrWhiteSpace(producerId))
            {
                var guid = new Guid(producerId);

                return this.producerCodeDao.GetContainer().Policies.Any(x => x.ProducerId == guid);
            }
            
            return false;
        }
    }
}
