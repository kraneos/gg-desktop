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
        IEnumerable<PolicyGridItemDto> GetByPolicyNumber(string polNum);
        IEnumerable<PolicyGridItemDto> GetByPlate(string plate);
        void SavePolicy(PolicyFullDto policy);
        PolicyFullDto GetById(long policyId);
        IEnumerable<PolicyRosViewDto> GetRosView(DateTime from, DateTime to);
    }
}
