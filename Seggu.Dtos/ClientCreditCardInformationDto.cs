using System;

namespace Seggu.Dtos
{
    [Serializable]
    public class ClientCreditCardInformationDto
    {
        public int ClientId { get; set; }
        public int CreditCardId { get; set; }
        public int BankId { get; set; }
    }
}
