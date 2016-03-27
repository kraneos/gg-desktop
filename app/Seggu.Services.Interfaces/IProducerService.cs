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
        ProducerCompanyDto GetByIdAndCompanyId(int producerId, int companyId);
        Boolean HasCompany(int producerId);
        ProducerDto GetById(int producerId);
        bool GetByRegistrationNumber(string registrationNumber, int producerId);
        void Delete(int id);
        void Save(ProducerDto producer);
        IEnumerable<ProducerCodeDto> GetByCompanyId(int companyId);
        bool HasPolicies(int p);
        IEnumerable<KeyValueDto> GetByCompanyIdCombobox(int companyId);
    }
}
