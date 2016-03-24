using iTextSharp.text;
using Seggu.Dtos;
using System;
using System.Collections.Generic;

namespace Seggu.Services.Interfaces
{
    public interface IPolicyService
    {
        IEnumerable<PolicyGridItemDto> GetValidsByClient(long clientId);
        IEnumerable<PolicyGridItemDto> GetNotValidsByClient(long clientId);
        void SavePolicy(PolicyFullDto policy);
        PolicyFullDto GetById(long policyId);
        IEnumerable<PolicyFullDto> GetByPlate(string plate);
        IEnumerable<PolicyFullDto> GetByPolicyNumber(string polNum);
        IEnumerable<PolicyRosViewDto> GetRosView(DateTime from, DateTime to);
    }
}
