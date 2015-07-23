using Seggu.Dtos;
using System;
using System.Collections.Generic;

namespace Seggu.Services.Interfaces
{
    public interface ICompanyService
    {
        IEnumerable<CompanyDto> GetAll();
        CompanyFullDto GetFullById(string id);
        CompanyDto GetById(string id);
        void DeleteProducerCode(string companyId, string producerId);
        void AddProducer(ProducerCodeDto prodCode);
        void DeleteCompany(CompanyDto company);
        void Create(CompanyDto company);
        void Update(CompanyDto company);
        bool ExistName(string name);
    }
}
