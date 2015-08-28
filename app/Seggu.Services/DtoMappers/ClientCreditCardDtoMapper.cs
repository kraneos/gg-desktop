using Seggu.Domain;
using Seggu.Dtos;
using Seggu.Helpers;

namespace Seggu.Services.DtoMappers
{
    public static class ClientCreditCardDtoMapper
    {
        public static ClientCreditCardInformationDto GetInformationDto(ClientCreditCard obj)
        {
            var dto = new ClientCreditCardInformationDto();
            dto.ClientId = obj.ClientId;
            dto.CreditCardId = obj.CreditCardId;
            dto.BankId = obj.BankId;
            return dto;
        }

        public static ClientCreditCard GetObject(ClientCreditCardInformationDto cc)
        {
            var obj = new ClientCreditCard();
            obj.ClientId = cc.ClientId;
            obj.BankId = cc.BankId;
            obj.CreditCardId = cc.CreditCardId;
            return obj;
        }
    }
}