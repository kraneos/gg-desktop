using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iTextSharp.text;
using Seggu.Dtos;

namespace Seggu.Services.Interfaces
{
    public interface IPrintService
    {
        void CreateFeesPdf(List<FeeDto> feeDto);
        void PrintReceipt(FeeChargeDto printFee);
        void EndorsePDF(EndorseFullDto endorse, ClientIndexDto client, PolicyFullDto policy);
        void PolicyPDF(ClientIndexDto client, PolicyFullDto policy, string selectedPlate);
    }
}
