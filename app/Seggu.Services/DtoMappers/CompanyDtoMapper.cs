using Seggu.Domain;
using Seggu.Dtos;
using System;
using System.Linq;

namespace Seggu.Services.DtoMappers
{
    public static class CompanyDtoMapper
    {
        public static CompanyDto GetDto(Company c)
        {
            var dto = new CompanyDto();
            dto.Id = (int)c.Id;
            dto.Name = c.Name;
            dto.Phone = c.Phone;
            dto.Notes = c.Notes;
            dto.Mail = c.EMail;
            dto.CUIT = c.CUIT;
            dto.LiqDay1 = c.LiqDay1.ToString();
            dto.LiqDay2 = c.LiqDay2.ToString();
            dto.Convenio1 = c.PaymentDay1.ToString();
            dto.Convenio2 = c.PaymentDay2.ToString();
            dto.Active = c.Active;
            return dto;
        }

        public static Company GetObject(CompanyDto company)
        {
            var c = new Company();
            c.Id = company.Id; 
            c.Active = company.Active;
            c.CUIT = company.CUIT;
            c.LiqDay1 = string.IsNullOrEmpty(company.LiqDay1) ? (short?)null : short.Parse(company.LiqDay1);
            c.LiqDay2 = string.IsNullOrEmpty(company.LiqDay2) ? (short?)null : short.Parse(company.LiqDay2);
            c.PaymentDay1 = string.IsNullOrEmpty(company.Convenio1) ? (short)0 : short.Parse(company.Convenio1);
            c.PaymentDay2 = string.IsNullOrEmpty(company.Convenio2) ? (short)0 : short.Parse(company.Convenio2);
            c.EMail = company.Mail;
            c.Name = company.Name;
            c.Notes = company.Notes;
            c.Phone = company.Phone;
            return c;
        }

        public static CompanyFullDto GetFormDto(Company c)
        {
            var dto = new CompanyFullDto();
            dto.Id = (int)c.Id;
            dto.CUIT = c.CUIT;
            dto.LiqDay1 = c.LiqDay1.ToString();
            dto.LiqDay2 = c.LiqDay2.ToString();
            dto.Convenio1 = c.PaymentDay1.ToString();
            dto.Convenio2 = c.PaymentDay2.ToString();
            dto.Mail = c.EMail;
            dto.Name = c.Name;
            dto.Notes = c.Notes;
            dto.Phone = c.Phone;
            dto.Active = c.Active;
            dto.Contacts = c.Contacts.Select(con => ContactDtoMapper.GetDto(con)).ToList();
            dto.Producers = c.ProducerCodes.Select(pc => ProducerDtoMapper.GetProducerCompanyDto(pc)).ToList();
            dto.Risks = c.Risks.OrderBy(x => x.Name).Select(r => RiskDtoMapper.GetRiskCompanyDto(r)).ToList();
            dto.CoveragesPacks = c.Risks.SelectMany(x => x.CoveragesPacks.Select(cp => CoveragesPackDtoMapper.GetDto(cp))).ToList();
            return dto;
        }

        public static CompanyFullDto GetCompanyOnly(Company c)
        {
            var dto = new CompanyFullDto();
            dto.Id = (int)c.Id;
            dto.CUIT = c.CUIT;
            dto.LiqDay1 = c.LiqDay1.ToString();
            dto.LiqDay2 = c.LiqDay2.ToString();
            dto.Convenio1 = c.PaymentDay1.ToString();
            dto.Convenio2 = c.PaymentDay2.ToString();
            dto.Mail = c.EMail;
            dto.Name = c.Name;
            dto.Notes = c.Notes;
            dto.Phone = c.Phone;
            dto.Active = c.Active;
            dto.Producers = c.ProducerCodes.Select(pc => ProducerDtoMapper.GetProducerCompanyDto(pc)).ToList();
            return dto;
        }
    }
}
