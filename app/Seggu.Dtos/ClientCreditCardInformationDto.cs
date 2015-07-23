using System;

namespace Seggu.Dtos
{
    [Serializable]
    public class ClientCreditCardInformationDto
    {
        public string ClientId { get; set; }
        public string CreditCardId { get; set; }
        public string BankId { get; set; }
    }
}
