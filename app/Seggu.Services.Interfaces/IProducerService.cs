using Seggu.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seggu.Services.Interfaces
{
    public interface IProducerService
    {
        IEnumerable<ProducerDto> GetCollectors();
        IEnumerable<ProducerDto> GetProducers();
        ProducerCompanyDto GetByIdAndCompanyId(string producerId, string companyId);
        Boolean HasCompany(string producerId);
        ProducerDto GetById(string producerId);
        bool GetByRegistrationNumber(string registrationNumber, string producerId);
        void Delete(string id);
        void Save(ProducerDto producer);
        IEnumerable<ProducerCodeDto> GetByCompanyId(string companyId);
    }
}
