using iTextSharp.text;
using Seggu.Dtos;
using System.Collections.Generic;

namespace Seggu.Services.Interfaces
{
    public interface IPolicyService
    {
        IEnumerable<PolicyFullDto> GetValidsByClient(int clientId);
        IEnumerable<PolicyFullDto> GetNotValidsByClient(int clientId);
        void SavePolicy(PolicyFullDto policy);
        PolicyFullDto GetById(int policyId);
        IEnumerable<PolicyFullDto> GetByPlate(string plate);
        IEnumerable<PolicyFullDto> GetByPolicyNumber(string polNum);
    }
}
