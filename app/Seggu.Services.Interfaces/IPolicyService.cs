using iTextSharp.text;
using Seggu.Dtos;
using System.Collections.Generic;

namespace Seggu.Services.Interfaces
{
    public interface IPolicyService
    { 
        IEnumerable<PolicyFullDto> GetValidsByClient(string clientId);
        IEnumerable<PolicyFullDto> GetNotValidsByClient(string clientId);
        void SavePolicy(PolicyFullDto policy);
        PolicyFullDto GetById(string policyId);
        IEnumerable<PolicyFullDto> GetByPlate(string plate);
        IEnumerable<PolicyFullDto> GetByPolicyNumber(string polNum);
    }
}
