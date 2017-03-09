using iTextSharp.text;
using Seggu.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seggu.Services.Interfaces
{
    public interface ICollectionService
    {
        Document CreatePdfReceiptTemplate(FeeChargeDto feeChargeDto);
    }
}
