using AutoMapper;
using Seggu.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seggu.Api
{
    public static class MapperConfiguration
    {
        public static void Initialize()
        {
            Mapper.CreateMap<string, Guid>().ConvertUsing(x => string.IsNullOrWhiteSpace((string)x.SourceValue) ? Guid.Empty : new Guid((string)x.SourceValue));
            Mapper.CreateMap<string, Guid?>().ConvertUsing(x => string.IsNullOrWhiteSpace((string)x.SourceValue) ? null : (Guid?)new Guid((string)x.SourceValue));

            Mapper.CreateMap<Guid, string>().ConvertUsing(x => (Guid)x.SourceValue == Guid.Empty ? null : x.SourceValue.ToString());
            Mapper.CreateMap<Guid?, string>().ConvertUsing(x => (Guid?)x.SourceValue == null ? null : ((Guid?)x.SourceValue).Value.ToString());

            Mapper.CreateMap<Domain.SegguClient, SegguClientVM>();
            Mapper.CreateMap<SegguClientVM, Domain.SegguClient>();

            Mapper.CreateMap<Domain.AccessoryType, AccessoryTypeVM>();
            Mapper.CreateMap<AccessoryTypeVM, Domain.AccessoryType>();

            Mapper.CreateMap<Domain.Asset, AssetVM>();
            Mapper.CreateMap<AssetVM, Domain.Asset>();

            Mapper.CreateMap<Domain.Bank, BankVM>();
            Mapper.CreateMap<BankVM, Domain.Bank>();

            Mapper.CreateMap<Domain.Bodywork, BodyworkVM>();
            Mapper.CreateMap<BodyworkVM, Domain.Bodywork>();

            Mapper.CreateMap<Domain.Brand, BrandVM>();
            Mapper.CreateMap<BrandVM, Domain.Brand>();

            Mapper.CreateMap<Domain.CasualtyType, CasualtyTypeVM>();
            Mapper.CreateMap<CasualtyTypeVM, Domain.CasualtyType>();

            Mapper.CreateMap<Domain.Client, ClientVM>();
            Mapper.CreateMap<ClientVM, Domain.Client>();

            Mapper.CreateMap<Domain.Company, CompanyVM>();
            Mapper.CreateMap<CompanyVM, Domain.Company>();

            Mapper.CreateMap<Domain.CreditCard, CreditCardVM>();
            Mapper.CreateMap<CreditCardVM, Domain.CreditCard>();

            Mapper.CreateMap<Domain.LedgerAccount, LedgerAccountVM>();
            Mapper.CreateMap<LedgerAccountVM, Domain.LedgerAccount>();

            Mapper.CreateMap<Domain.Producer, ProducerVM>();
            Mapper.CreateMap<ProducerVM, Domain.Producer>();

            Mapper.CreateMap<Domain.Province, ProvinceVM>();
            Mapper.CreateMap<ProvinceVM, Domain.Province>();

            Mapper.CreateMap<Domain.Use, UseVM>();
            Mapper.CreateMap<UseVM, Domain.Use>();

            Mapper.CreateMap<Domain.VehicleType, VehicleTypeVM>();
            Mapper.CreateMap<VehicleTypeVM, Domain.VehicleType>();

            Mapper.CreateMap<Domain.Cheque, ChequeVM>();
            Mapper.CreateMap<ChequeVM, Domain.Cheque>();

            Mapper.CreateMap<Domain.Contact, ContactVM>();
            Mapper.CreateMap<ContactVM, Domain.Contact>();

            Mapper.CreateMap<Domain.Liquidation, LiquidationVM>();
            Mapper.CreateMap<LiquidationVM, Domain.Liquidation>();

            Mapper.CreateMap<Domain.ProducerCode, ProducerCodeVM>();
            Mapper.CreateMap<ProducerCodeVM, Domain.ProducerCode>();

            Mapper.CreateMap<Domain.District, DistrictVM>();
            Mapper.CreateMap<DistrictVM, Domain.District>();

            Mapper.CreateMap<Domain.Locality, LocalityVM>();
            Mapper.CreateMap<LocalityVM, Domain.Locality>();

            Mapper.CreateMap<Domain.Risk, RiskVM>();
            Mapper.CreateMap<RiskVM, Domain.Risk>();

            Mapper.CreateMap<Domain.VehicleModel, VehicleModelVM>();
            Mapper.CreateMap<VehicleModelVM, Domain.VehicleModel>();

            Mapper.CreateMap<Domain.Policy, PolicyVM>();
            Mapper.CreateMap<PolicyVM, Domain.Policy>();

            Mapper.CreateMap<Domain.Endorse, EndorseVM>();
            Mapper.CreateMap<EndorseVM, Domain.Endorse>();

            Mapper.CreateMap<Domain.Employee, EmployeeVM>();
            Mapper.CreateMap<EmployeeVM, Domain.Employee>();

            Mapper.CreateMap<Domain.FeeSelection, FeeSelectionVM>();
            Mapper.CreateMap<FeeSelectionVM, Domain.FeeSelection>();

            Mapper.CreateMap<Domain.Fee, FeeVM>();
            Mapper.CreateMap<FeeVM, Domain.Fee>();

            Mapper.CreateMap<Domain.Vehicle, VehicleVM>();
            Mapper.CreateMap<VehicleVM, Domain.Vehicle>();

            Mapper.CreateMap<Domain.Accessory, AccessoryVM>();
            Mapper.CreateMap<AccessoryVM, Domain.Accessory>();

            Mapper.CreateMap<Domain.Integral, IntegralVM>();
            Mapper.CreateMap<IntegralVM, Domain.Integral>();

            Mapper.CreateMap<Domain.Address, AddressVM>();
            Mapper.CreateMap<AddressVM, Domain.Address>();

            Mapper.CreateMap<Domain.CashAccount, CashAccountVM>();
            Mapper.CreateMap<CashAccountVM, Domain.CashAccount>();
        }
    }
}
