﻿using Seggu.Domain;
using Seggu.Dtos;
using System;

namespace Seggu.Services.DtoMappers
{
    public static class BankDtoMapper
    {
        public static BankDto GetDto(Bank bank)
        {
            var dto = new BankDto();
            dto.Id = (int)bank.Id;
            dto.Name = bank.Name;
            dto.Number = bank.Number;
            return dto;
        }

        public static Bank GetBank(BankDto dto)
        {
            var bank = new Bank();
            
            bank.Name = dto.Name;
            bank.Number = dto.Number;
            return bank;
        }

        public static Bank GetBankUpdate(BankDto dto)
        {
            var bank = new Bank();
            var id = dto.Id;
            bank.Id = id;
            bank.Name = dto.Name;
            bank.Number = dto.Number;
            return bank;
        }
    }
}