﻿using System.Collections.Generic;
using Seggu.Dtos;

namespace Seggu.Services.Interfaces
{
    public interface IPrintService
    {
        void CreateFeesPdf(List<FeeDto> feeDto);
        void VehicleReceipt(FeeChargeDto printFee);
        void PolicyVehiclePDF(PolicyFullDto policy, string selectedPlate);
        void PolicyIntegralPDF(PolicyFullDto policy, string province, string district);
        void PolicyLifePDF(PolicyFullDto policy);
        void EndorseVehiclePDF(EndorseFullDto endorse);
        void EndorseLifePDF(EndorseFullDto endorse);
        void EndorseIntegralPDF(EndorseFullDto endorse, string province, string district);
        void LifeReceiptPDF(FeeLifeDto printFee);
        void IntegralReceiptPDF(FeeDto printFee);
        //void GetNames();
    }
}
