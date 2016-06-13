using System.Collections.Generic;
using Seggu.Dtos;

namespace Seggu.Services.Interfaces
{
    public interface IPrintService
    {
        void CreateFeesPdf(List<FeeDto> feeDto);
        void PrintReceipt(FeeChargeDto printFee);
        void PolicyVehiclePDF(PolicyFullDto policy, string selectedPlate);
        void PolicyIntegralPDF(PolicyFullDto policy);
        void PolicyLifePDF(PolicyFullDto policy);
        void EndorsePDF(EndorseFullDto endorse, ClientIndexDto client, PolicyFullDto policy);
        //void GetNames();
    }
}
