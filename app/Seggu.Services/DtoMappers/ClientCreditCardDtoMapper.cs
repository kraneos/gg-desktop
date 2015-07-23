using Seggu.Data;
using Seggu.Dtos;
using Seggu.Helpers;

namespace Seggu.Services.DtoMappers
{
    public static class ClientCreditCardDtoMapper
    {
        public static ClientCreditCardInformationDto GetInformationDto(ClientCreditCard obj)
        {
            var dto = new ClientCreditCardInformationDto();
            dto.ClientId = obj.ClientId.ToString();
            dto.CreditCardId = obj.CreditCardId.ToString();
            dto.BankId = obj.BankId.ToString();
            return dto;
        }

        public static ClientCreditCard GetObject(ClientCreditCardInformationDto cc)
        {
            var obj = new ClientCreditCard();
            obj.ClientId = cc.ClientId.ToGuid();
            obj.BankId = cc.BankId.ToGuid();
            obj.CreditCardId = cc.CreditCardId.ToGuid();
            return obj;
        }
    }
}