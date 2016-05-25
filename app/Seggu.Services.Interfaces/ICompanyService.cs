using Seggu.Dtos;
using System;
using System.Collections.Generic;

namespace Seggu.Services.Interfaces
{
    public interface ICompanyService
    {
        IEnumerable<CompanyDto> GetAll();
        CompanyFullDto GetFullById(int id);
        CompanyDto GetById(int id);
        void DeleteProducerCode(int companyId, int producerId);
        void AddProducer(ProducerCodeDto prodCode);
        void DeleteCompany(CompanyDto company);
        void Create(CompanyDto company);
        void Update(CompanyDto company);
        bool ExistName(string name);
        IEnumerable<CompanyDto> GetActive();
        IEnumerable<KeyValueDto> GetAllCombobox();
    }
}
