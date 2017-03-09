
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/25/2014 23:54:26
-- Generated from EDMX file: E:\codeplex\seggu\app-seminario\Seggu.Data\SegguDataModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Seggu];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_LocalityAddress]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Addresses] DROP CONSTRAINT [FK_LocalityAddress];
GO
IF OBJECT_ID(N'[dbo].[FK_ClientPolicy]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Policies] DROP CONSTRAINT [FK_ClientPolicy];
GO
IF OBJECT_ID(N'[dbo].[FK_CasualtyTypeCasualty]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Casualties] DROP CONSTRAINT [FK_CasualtyTypeCasualty];
GO
IF OBJECT_ID(N'[dbo].[FK_ClientClientCreditCard]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ClientCreditCards] DROP CONSTRAINT [FK_ClientClientCreditCard];
GO
IF OBJECT_ID(N'[dbo].[FK_ClientCreditCardCreditCard]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ClientCreditCards] DROP CONSTRAINT [FK_ClientCreditCardCreditCard];
GO
IF OBJECT_ID(N'[dbo].[FK_BankClientCreditCard]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ClientCreditCards] DROP CONSTRAINT [FK_BankClientCreditCard];
GO
IF OBJECT_ID(N'[dbo].[FK_AccessoryTypeAccessory]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Accessories] DROP CONSTRAINT [FK_AccessoryTypeAccessory];
GO
IF OBJECT_ID(N'[dbo].[FK_ProducerProducerCode]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProducerCodes] DROP CONSTRAINT [FK_ProducerProducerCode];
GO
IF OBJECT_ID(N'[dbo].[FK_CompanyProducerCode]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProducerCodes] DROP CONSTRAINT [FK_CompanyProducerCode];
GO
IF OBJECT_ID(N'[dbo].[FK_BankCheque]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Cheques] DROP CONSTRAINT [FK_BankCheque];
GO
IF OBJECT_ID(N'[dbo].[FK_LedgerAccountCashAccount]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CashAccounts] DROP CONSTRAINT [FK_LedgerAccountCashAccount];
GO
IF OBJECT_ID(N'[dbo].[FK_PolicyFee]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Fees] DROP CONSTRAINT [FK_PolicyFee];
GO
IF OBJECT_ID(N'[dbo].[FK_CreditCardCompany_CreditCard]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CreditCardCompany] DROP CONSTRAINT [FK_CreditCardCompany_CreditCard];
GO
IF OBJECT_ID(N'[dbo].[FK_CreditCardCompany_Company]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CreditCardCompany] DROP CONSTRAINT [FK_CreditCardCompany_Company];
GO
IF OBJECT_ID(N'[dbo].[FK_ProducerCashAccount]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CashAccounts] DROP CONSTRAINT [FK_ProducerCashAccount];
GO
IF OBJECT_ID(N'[dbo].[FK_PolicyCasualty]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Casualties] DROP CONSTRAINT [FK_PolicyCasualty];
GO
IF OBJECT_ID(N'[dbo].[FK_AssetCashAccount]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CashAccounts] DROP CONSTRAINT [FK_AssetCashAccount];
GO
IF OBJECT_ID(N'[dbo].[FK_VehicleTypeUse_VehicleType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[VehicleTypeUse] DROP CONSTRAINT [FK_VehicleTypeUse_VehicleType];
GO
IF OBJECT_ID(N'[dbo].[FK_VehicleTypeUse_Use]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[VehicleTypeUse] DROP CONSTRAINT [FK_VehicleTypeUse_Use];
GO
IF OBJECT_ID(N'[dbo].[FK_VehicleAccessory]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Accessories] DROP CONSTRAINT [FK_VehicleAccessory];
GO
IF OBJECT_ID(N'[dbo].[FK_PolicyEmployee]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Employees] DROP CONSTRAINT [FK_PolicyEmployee];
GO
IF OBJECT_ID(N'[dbo].[FK_FeeCashAccount]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CashAccounts] DROP CONSTRAINT [FK_FeeCashAccount];
GO
IF OBJECT_ID(N'[dbo].[FK_BodyworkVehicleType_Bodywork]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BodyworkVehicleType] DROP CONSTRAINT [FK_BodyworkVehicleType_Bodywork];
GO
IF OBJECT_ID(N'[dbo].[FK_BodyworkVehicleType_VehicleType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BodyworkVehicleType] DROP CONSTRAINT [FK_BodyworkVehicleType_VehicleType];
GO
IF OBJECT_ID(N'[dbo].[FK_PolicyVehicle]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Vehicles] DROP CONSTRAINT [FK_PolicyVehicle];
GO
IF OBJECT_ID(N'[dbo].[FK_PolicyEndorse]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Endorses] DROP CONSTRAINT [FK_PolicyEndorse];
GO
IF OBJECT_ID(N'[dbo].[FK_EndorseEmployee]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Employees] DROP CONSTRAINT [FK_EndorseEmployee];
GO
IF OBJECT_ID(N'[dbo].[FK_EndorseVehicle]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Vehicles] DROP CONSTRAINT [FK_EndorseVehicle];
GO
IF OBJECT_ID(N'[dbo].[FK_ClientEndorse]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Endorses] DROP CONSTRAINT [FK_ClientEndorse];
GO
IF OBJECT_ID(N'[dbo].[FK_CompanyContact]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Contacts] DROP CONSTRAINT [FK_CompanyContact];
GO
IF OBJECT_ID(N'[dbo].[FK_CompanyRisk]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Risks] DROP CONSTRAINT [FK_CompanyRisk];
GO
IF OBJECT_ID(N'[dbo].[FK_ProducerPolicy]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Policies] DROP CONSTRAINT [FK_ProducerPolicy];
GO
IF OBJECT_ID(N'[dbo].[FK_BrandVehicleModel]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[VehicleModels] DROP CONSTRAINT [FK_BrandVehicleModel];
GO
IF OBJECT_ID(N'[dbo].[FK_VehicleTypeVehicleModel]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[VehicleModels] DROP CONSTRAINT [FK_VehicleTypeVehicleModel];
GO
IF OBJECT_ID(N'[dbo].[FK_VehicleModelVehicle]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Vehicles] DROP CONSTRAINT [FK_VehicleModelVehicle];
GO
IF OBJECT_ID(N'[dbo].[FK_UseVehicle]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Vehicles] DROP CONSTRAINT [FK_UseVehicle];
GO
IF OBJECT_ID(N'[dbo].[FK_BodyworkVehicle]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Vehicles] DROP CONSTRAINT [FK_BodyworkVehicle];
GO
IF OBJECT_ID(N'[dbo].[FK_LiquidationFeeSelection]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FeeSelections] DROP CONSTRAINT [FK_LiquidationFeeSelection];
GO
IF OBJECT_ID(N'[dbo].[FK_FeeSelectionFee]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Fees] DROP CONSTRAINT [FK_FeeSelectionFee];
GO
IF OBJECT_ID(N'[dbo].[FK_CompanyLiquidation]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Liquidations] DROP CONSTRAINT [FK_CompanyLiquidation];
GO
IF OBJECT_ID(N'[dbo].[FK_EndorseFee]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Fees] DROP CONSTRAINT [FK_EndorseFee];
GO
IF OBJECT_ID(N'[dbo].[FK_ProducerPolicyCollector]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Policies] DROP CONSTRAINT [FK_ProducerPolicyCollector];
GO
IF OBJECT_ID(N'[dbo].[FK_ProvinceDistrict]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Districts] DROP CONSTRAINT [FK_ProvinceDistrict];
GO
IF OBJECT_ID(N'[dbo].[FK_DistrictLocality]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Localities] DROP CONSTRAINT [FK_DistrictLocality];
GO
IF OBJECT_ID(N'[dbo].[FK_EndorseAttachedFile]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AttachedFiles] DROP CONSTRAINT [FK_EndorseAttachedFile];
GO
IF OBJECT_ID(N'[dbo].[FK_PolicyAttachedFile]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AttachedFiles] DROP CONSTRAINT [FK_PolicyAttachedFile];
GO
IF OBJECT_ID(N'[dbo].[FK_CasualtyAttachedFile]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AttachedFiles] DROP CONSTRAINT [FK_CasualtyAttachedFile];
GO
IF OBJECT_ID(N'[dbo].[FK_CashAccountAttachedFile]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AttachedFiles] DROP CONSTRAINT [FK_CashAccountAttachedFile];
GO
IF OBJECT_ID(N'[dbo].[FK_IntegralCoverage_Integral]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[IntegralCoverage] DROP CONSTRAINT [FK_IntegralCoverage_Integral];
GO
IF OBJECT_ID(N'[dbo].[FK_IntegralCoverage_Coverage]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[IntegralCoverage] DROP CONSTRAINT [FK_IntegralCoverage_Coverage];
GO
IF OBJECT_ID(N'[dbo].[FK_EmployeeCoverage_Employee]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EmployeeCoverage] DROP CONSTRAINT [FK_EmployeeCoverage_Employee];
GO
IF OBJECT_ID(N'[dbo].[FK_EmployeeCoverage_Coverage]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EmployeeCoverage] DROP CONSTRAINT [FK_EmployeeCoverage_Coverage];
GO
IF OBJECT_ID(N'[dbo].[FK_VehicleCoverage_Vehicle]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[VehicleCoverage] DROP CONSTRAINT [FK_VehicleCoverage_Vehicle];
GO
IF OBJECT_ID(N'[dbo].[FK_VehicleCoverage_Coverage]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[VehicleCoverage] DROP CONSTRAINT [FK_VehicleCoverage_Coverage];
GO
IF OBJECT_ID(N'[dbo].[FK_RiskCoveragesPack]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CoveragesPacks] DROP CONSTRAINT [FK_RiskCoveragesPack];
GO
IF OBJECT_ID(N'[dbo].[FK_RiskPolicy]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Policies] DROP CONSTRAINT [FK_RiskPolicy];
GO
IF OBJECT_ID(N'[dbo].[FK_RiskCoverage]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Coverages] DROP CONSTRAINT [FK_RiskCoverage];
GO
IF OBJECT_ID(N'[dbo].[FK_CoveragesPackCoverage_CoveragesPack]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CoveragesPackCoverage] DROP CONSTRAINT [FK_CoveragesPackCoverage_CoveragesPack];
GO
IF OBJECT_ID(N'[dbo].[FK_CoveragesPackCoverage_Coverage]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CoveragesPackCoverage] DROP CONSTRAINT [FK_CoveragesPackCoverage_Coverage];
GO
IF OBJECT_ID(N'[dbo].[FK_ClientAddress]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Addresses] DROP CONSTRAINT [FK_ClientAddress];
GO
IF OBJECT_ID(N'[dbo].[FK_PolicyIntegral]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Integrals] DROP CONSTRAINT [FK_PolicyIntegral];
GO
IF OBJECT_ID(N'[dbo].[FK_EndorseIntegral]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Integrals] DROP CONSTRAINT [FK_EndorseIntegral];
GO
IF OBJECT_ID(N'[dbo].[FK_IntegralAddress]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Addresses] DROP CONSTRAINT [FK_IntegralAddress];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Localities]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Localities];
GO
IF OBJECT_ID(N'[dbo].[Provinces]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Provinces];
GO
IF OBJECT_ID(N'[dbo].[Addresses]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Addresses];
GO
IF OBJECT_ID(N'[dbo].[Clients]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Clients];
GO
IF OBJECT_ID(N'[dbo].[Policies]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Policies];
GO
IF OBJECT_ID(N'[dbo].[Endorses]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Endorses];
GO
IF OBJECT_ID(N'[dbo].[Risks]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Risks];
GO
IF OBJECT_ID(N'[dbo].[Vehicles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Vehicles];
GO
IF OBJECT_ID(N'[dbo].[Brands]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Brands];
GO
IF OBJECT_ID(N'[dbo].[Companies]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Companies];
GO
IF OBJECT_ID(N'[dbo].[CasualtyTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CasualtyTypes];
GO
IF OBJECT_ID(N'[dbo].[Casualties]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Casualties];
GO
IF OBJECT_ID(N'[dbo].[AccessoryTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AccessoryTypes];
GO
IF OBJECT_ID(N'[dbo].[Accessories]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Accessories];
GO
IF OBJECT_ID(N'[dbo].[CreditCards]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CreditCards];
GO
IF OBJECT_ID(N'[dbo].[Banks]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Banks];
GO
IF OBJECT_ID(N'[dbo].[Producers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Producers];
GO
IF OBJECT_ID(N'[dbo].[ClientCreditCards]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ClientCreditCards];
GO
IF OBJECT_ID(N'[dbo].[Bodyworks]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Bodyworks];
GO
IF OBJECT_ID(N'[dbo].[Uses]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Uses];
GO
IF OBJECT_ID(N'[dbo].[ProducerCodes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProducerCodes];
GO
IF OBJECT_ID(N'[dbo].[Cheques]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Cheques];
GO
IF OBJECT_ID(N'[dbo].[LedgerAccounts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LedgerAccounts];
GO
IF OBJECT_ID(N'[dbo].[CashAccounts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CashAccounts];
GO
IF OBJECT_ID(N'[dbo].[Fees]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Fees];
GO
IF OBJECT_ID(N'[dbo].[Coverages]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Coverages];
GO
IF OBJECT_ID(N'[dbo].[Employees]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Employees];
GO
IF OBJECT_ID(N'[dbo].[Assets]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Assets];
GO
IF OBJECT_ID(N'[dbo].[Liquidations]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Liquidations];
GO
IF OBJECT_ID(N'[dbo].[VehicleTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[VehicleTypes];
GO
IF OBJECT_ID(N'[dbo].[Integrals]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Integrals];
GO
IF OBJECT_ID(N'[dbo].[Contacts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Contacts];
GO
IF OBJECT_ID(N'[dbo].[VehicleModels]', 'U') IS NOT NULL
    DROP TABLE [dbo].[VehicleModels];
GO
IF OBJECT_ID(N'[dbo].[FeeSelections]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FeeSelections];
GO
IF OBJECT_ID(N'[dbo].[Districts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Districts];
GO
IF OBJECT_ID(N'[dbo].[AttachedFiles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AttachedFiles];
GO
IF OBJECT_ID(N'[dbo].[CoveragesPacks]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CoveragesPacks];
GO
IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO
IF OBJECT_ID(N'[dbo].[CreditCardCompany]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CreditCardCompany];
GO
IF OBJECT_ID(N'[dbo].[VehicleTypeUse]', 'U') IS NOT NULL
    DROP TABLE [dbo].[VehicleTypeUse];
GO
IF OBJECT_ID(N'[dbo].[BodyworkVehicleType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BodyworkVehicleType];
GO
IF OBJECT_ID(N'[dbo].[IntegralCoverage]', 'U') IS NOT NULL
    DROP TABLE [dbo].[IntegralCoverage];
GO
IF OBJECT_ID(N'[dbo].[EmployeeCoverage]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EmployeeCoverage];
GO
IF OBJECT_ID(N'[dbo].[VehicleCoverage]', 'U') IS NOT NULL
    DROP TABLE [dbo].[VehicleCoverage];
GO
IF OBJECT_ID(N'[dbo].[CoveragesPackCoverage]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CoveragesPackCoverage];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Localities'
CREATE TABLE [dbo].[Localities] (
    [Id] uniqueidentifier  NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [DistrictId] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'Provinces'
CREATE TABLE [dbo].[Provinces] (
    [Id] uniqueidentifier  NOT NULL,
    [Name] nvarchar(40)  NOT NULL
);
GO

-- Creating table 'Addresses'
CREATE TABLE [dbo].[Addresses] (
    [Id] uniqueidentifier  NOT NULL,
    [Street] nvarchar(max)  NOT NULL,
    [Phone] nvarchar(max)  NULL,
    [Number] nvarchar(max)  NOT NULL,
    [Floor] nvarchar(max)  NULL,
    [Appartment] nvarchar(max)  NULL,
    [LocalityId] uniqueidentifier  NULL,
    [PostalCode] nvarchar(max)  NULL,
    [AddressType] int  NOT NULL,
    [ClientId] uniqueidentifier  NULL,
    [Integral_Id] uniqueidentifier  NULL
);
GO

-- Creating table 'Clients'
CREATE TABLE [dbo].[Clients] (
    [Id] uniqueidentifier  NOT NULL,
    [FirstName] nvarchar(max)  NOT NULL,
    [LastName] nvarchar(max)  NOT NULL,
    [CellPhone] nvarchar(max)  NULL,
    [Mail] nvarchar(max)  NULL,
    [Document] nvarchar(max)  NOT NULL,
    [BirthDate] datetime  NULL,
    [Cuit] nvarchar(max)  NULL,
    [IngresosBrutos] nvarchar(max)  NULL,
    [CollectionTimeRange] nvarchar(max)  NULL,
    [BankingCode] nvarchar(max)  NULL,
    [Notes] nvarchar(max)  NULL,
    [IsSmoker] bit  NOT NULL,
    [Sex] int  NOT NULL,
    [IVA] int  NOT NULL,
    [MaritalStatus] int  NOT NULL,
    [DocumentType] int  NOT NULL,
    [Occupation] nvarchar(max)  NULL
);
GO

-- Creating table 'Policies'
CREATE TABLE [dbo].[Policies] (
    [Id] uniqueidentifier  NOT NULL,
    [PreviousNumber] nvarchar(max)  NULL,
    [ClientId] uniqueidentifier  NOT NULL,
    [Period] int  NOT NULL,
    [StartDate] datetime  NOT NULL,
    [EndDate] datetime  NOT NULL,
    [RequestDate] datetime  NOT NULL,
    [ReceptionDate] datetime  NULL,
    [EmissionDate] datetime  NULL,
    [Prima] decimal(18,0)  NOT NULL,
    [Premium] decimal(18,0)  NOT NULL,
    [Surcharge] decimal(18,0)  NOT NULL,
    [Bonus] decimal(18,0)  NULL,
    [Value] decimal(18,0)  NOT NULL,
    [Notes] nvarchar(max)  NULL,
    [Number] nvarchar(max)  NULL,
    [IsRenovated] bit  NOT NULL,
    [IsAnnulled] bit  NOT NULL,
    [AnnulationDate] datetime  NULL,
    [IsRemoved] bit  NOT NULL,
    [ProducerId] uniqueidentifier  NOT NULL,
    [CollectorId] uniqueidentifier  NULL,
    [RiskId] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'Endorses'
CREATE TABLE [dbo].[Endorses] (
    [Id] uniqueidentifier  NOT NULL,
    [EndorseType] smallint  NOT NULL,
    [Number] nvarchar(max)  NULL,
    [Cause] nvarchar(max)  NOT NULL,
    [PolicyId] uniqueidentifier  NOT NULL,
    [ClientId] uniqueidentifier  NULL,
    [StartDate] datetime  NOT NULL,
    [EndDate] datetime  NOT NULL,
    [RequestDate] datetime  NOT NULL,
    [ReceptionDate] datetime  NULL,
    [EmissionDate] datetime  NULL,
    [Prima] decimal(18,0)  NULL,
    [Premium] decimal(18,0)  NULL,
    [Surcharge] decimal(18,0)  NULL,
    [Value] decimal(18,0)  NULL,
    [Notes] nvarchar(max)  NULL,
    [IsAnnulled] bit  NULL,
    [AnnulationDate] datetime  NULL,
    [IsRemoved] bit  NULL
);
GO

-- Creating table 'Risks'
CREATE TABLE [dbo].[Risks] (
    [Id] uniqueidentifier  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [RiskType] int  NOT NULL,
    [CompanyId] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'Vehicles'
CREATE TABLE [dbo].[Vehicles] (
    [Id] uniqueidentifier  NOT NULL,
    [Plate] nvarchar(max)  NOT NULL,
    [Engine] nvarchar(max)  NOT NULL,
    [Year] nvarchar(max)  NOT NULL,
    [Chassis] nvarchar(max)  NOT NULL,
    [PolicyId] uniqueidentifier  NOT NULL,
    [EndorseId] uniqueidentifier  NULL,
    [VehicleModelId] uniqueidentifier  NOT NULL,
    [UseId] uniqueidentifier  NOT NULL,
    [BodyworkId] uniqueidentifier  NOT NULL,
    [IsRemoved] bit  NULL
);
GO

-- Creating table 'Brands'
CREATE TABLE [dbo].[Brands] (
    [Id] uniqueidentifier  NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Companies'
CREATE TABLE [dbo].[Companies] (
    [Id] uniqueidentifier  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Phone] nvarchar(max)  NOT NULL,
    [Notes] nvarchar(max)  NULL,
    [Active] bit  NOT NULL,
    [EMail] nvarchar(max)  NOT NULL,
    [CUIT] nvarchar(max)  NULL,
    [LiqDay1] smallint  NULL,
    [LiqDay2] smallint  NULL,
    [PaymentDay1] smallint  NOT NULL,
    [PaymentDay2] smallint  NOT NULL
);
GO

-- Creating table 'CasualtyTypes'
CREATE TABLE [dbo].[CasualtyTypes] (
    [Id] uniqueidentifier  NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Casualties'
CREATE TABLE [dbo].[Casualties] (
    [Id] uniqueidentifier  NOT NULL,
    [PolicyId] uniqueidentifier  NOT NULL,
    [Number] smallint  NOT NULL,
    [CasualtyTypeId] uniqueidentifier  NOT NULL,
    [OurCharge] bit  NOT NULL,
    [OccurredDate] datetime  NOT NULL,
    [ReceiveDate] datetime  NOT NULL,
    [PoliceReportDate] datetime  NULL,
    [EstimatedCompensation] decimal(18,0)  NOT NULL,
    [DefinedCompensation] decimal(18,0)  NOT NULL,
    [Notes] nvarchar(max)  NULL
);
GO

-- Creating table 'AccessoryTypes'
CREATE TABLE [dbo].[AccessoryTypes] (
    [Id] uniqueidentifier  NOT NULL,
    [Name] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'Accessories'
CREATE TABLE [dbo].[Accessories] (
    [Id] uniqueidentifier  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Stamp] nvarchar(50)  NOT NULL,
    [ExpirationDate] datetime  NOT NULL,
    [AccessoryTypeId] uniqueidentifier  NOT NULL,
    [Value] decimal(18,0)  NOT NULL,
    [VehicleId] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'CreditCards'
CREATE TABLE [dbo].[CreditCards] (
    [Id] uniqueidentifier  NOT NULL,
    [Name] nvarchar(15)  NOT NULL
);
GO

-- Creating table 'Banks'
CREATE TABLE [dbo].[Banks] (
    [Id] uniqueidentifier  NOT NULL,
    [Number] nvarchar(max)  NOT NULL,
    [Name] nvarchar(15)  NOT NULL
);
GO

-- Creating table 'Producers'
CREATE TABLE [dbo].[Producers] (
    [Id] uniqueidentifier  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [RegistrationNumber] nvarchar(max)  NOT NULL,
    [IsCollector] bit  NOT NULL
);
GO

-- Creating table 'ClientCreditCards'
CREATE TABLE [dbo].[ClientCreditCards] (
    [Id] uniqueidentifier  NOT NULL,
    [Number] bigint  NULL,
    [ClientId] uniqueidentifier  NOT NULL,
    [CreditCardId] uniqueidentifier  NOT NULL,
    [BankId] uniqueidentifier  NOT NULL,
    [ExpirationDate] datetime  NULL
);
GO

-- Creating table 'Bodyworks'
CREATE TABLE [dbo].[Bodyworks] (
    [Id] uniqueidentifier  NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Uses'
CREATE TABLE [dbo].[Uses] (
    [Id] uniqueidentifier  NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ProducerCodes'
CREATE TABLE [dbo].[ProducerCodes] (
    [ProducerId] uniqueidentifier  NOT NULL,
    [CompanyId] uniqueidentifier  NOT NULL,
    [Code] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Cheques'
CREATE TABLE [dbo].[Cheques] (
    [Id] uniqueidentifier  NOT NULL,
    [Number] nvarchar(max)  NOT NULL,
    [BankId] uniqueidentifier  NOT NULL,
    [Value] decimal(18,0)  NOT NULL,
    [Date] datetime  NOT NULL
);
GO

-- Creating table 'LedgerAccounts'
CREATE TABLE [dbo].[LedgerAccounts] (
    [Id] uniqueidentifier  NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'CashAccounts'
CREATE TABLE [dbo].[CashAccounts] (
    [Id] uniqueidentifier  NOT NULL,
    [AssetId] uniqueidentifier  NOT NULL,
    [LedgerAccountId] uniqueidentifier  NOT NULL,
    [Date] datetime  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [Amount] decimal(18,0)  NOT NULL,
    [Balance] decimal(18,0)  NOT NULL,
    [ProducerId] uniqueidentifier  NOT NULL,
    [FeeId] uniqueidentifier  NULL,
    [ReceiptNumber] nvarchar(max)  NULL
);
GO

-- Creating table 'Fees'
CREATE TABLE [dbo].[Fees] (
    [Id] uniqueidentifier  NOT NULL,
    [PolicyId] uniqueidentifier  NOT NULL,
    [ExpirationDate] datetime  NOT NULL,
    [Number] smallint  NOT NULL,
    [Value] decimal(18,0)  NOT NULL,
    [Balance] decimal(18,0)  NOT NULL,
    [CompanyPayment] decimal(18,0)  NOT NULL,
    [Annulated] bit  NOT NULL,
    [FeeSelectionId] uniqueidentifier  NULL,
    [State] smallint  NOT NULL,
    [EndorseId] uniqueidentifier  NULL,
    [RegisteredLiqDate] nvarchar(max)  NULL
);
GO

-- Creating table 'Coverages'
CREATE TABLE [dbo].[Coverages] (
    [Id] uniqueidentifier  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [RiskId] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'Employees'
CREATE TABLE [dbo].[Employees] (
    [Id] uniqueidentifier  NOT NULL,
    [PolicyId] uniqueidentifier  NOT NULL,
    [EndorseId] uniqueidentifier  NULL,
    [FirstName] nvarchar(max)  NOT NULL,
    [LastName] nvarchar(max)  NOT NULL,
    [BirthDate] datetime  NOT NULL,
    [DNI] nvarchar(max)  NOT NULL,
    [CUIT] nvarchar(max)  NOT NULL,
    [IsRemoved] bit  NULL,
    [InsuranceAmount] decimal(18,0)  NOT NULL
);
GO

-- Creating table 'Assets'
CREATE TABLE [dbo].[Assets] (
    [Id] uniqueidentifier  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Amount] decimal(18,0)  NOT NULL
);
GO

-- Creating table 'Liquidations'
CREATE TABLE [dbo].[Liquidations] (
    [Id] uniqueidentifier  NOT NULL,
    [Date] datetime  NOT NULL,
    [Total] decimal(18,0)  NOT NULL,
    [ReceptionDate] datetime  NULL,
    [Registered] bit  NOT NULL,
    [Notes] nvarchar(max)  NULL,
    [CompanyId] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'VehicleTypes'
CREATE TABLE [dbo].[VehicleTypes] (
    [Id] uniqueidentifier  NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Integrals'
CREATE TABLE [dbo].[Integrals] (
    [Id] uniqueidentifier  NOT NULL,
    [PolicyId] uniqueidentifier  NULL,
    [EndorseId] uniqueidentifier  NULL
);
GO

-- Creating table 'Contacts'
CREATE TABLE [dbo].[Contacts] (
    [Id] uniqueidentifier  NOT NULL,
    [FirstName] nvarchar(max)  NOT NULL,
    [LastName] nvarchar(max)  NOT NULL,
    [Phone] nvarchar(max)  NOT NULL,
    [Mail] nvarchar(max)  NULL,
    [Notes] nvarchar(max)  NULL,
    [CompanyId] uniqueidentifier  NULL,
    [Bussiness] nvarchar(max)  NULL
);
GO

-- Creating table 'VehicleModels'
CREATE TABLE [dbo].[VehicleModels] (
    [Id] uniqueidentifier  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Origin] smallint  NOT NULL,
    [BrandId] uniqueidentifier  NOT NULL,
    [VehicleTypeId] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'FeeSelections'
CREATE TABLE [dbo].[FeeSelections] (
    [Id] uniqueidentifier  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Total] decimal(18,0)  NOT NULL,
    [LiquidationId] uniqueidentifier  NOT NULL,
    [Notes] nvarchar(max)  NULL
);
GO

-- Creating table 'Districts'
CREATE TABLE [dbo].[Districts] (
    [Id] uniqueidentifier  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [ProvinceId] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'AttachedFiles'
CREATE TABLE [dbo].[AttachedFiles] (
    [Id] uniqueidentifier  NOT NULL,
    [EndorseId] uniqueidentifier  NULL,
    [FilePath] nvarchar(max)  NOT NULL,
    [PolicyId] uniqueidentifier  NULL,
    [CasualtyId] uniqueidentifier  NULL,
    [CashAccountId] uniqueidentifier  NULL
);
GO

-- Creating table 'CoveragesPacks'
CREATE TABLE [dbo].[CoveragesPacks] (
    [Id] uniqueidentifier  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [RiskId] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [Id] uniqueidentifier  NOT NULL,
    [Username] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [Role] smallint  NOT NULL
);
GO

-- Creating table 'CreditCardCompany'
CREATE TABLE [dbo].[CreditCardCompany] (
    [CreditCards_Id] uniqueidentifier  NOT NULL,
    [Companies_Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'VehicleTypeUse'
CREATE TABLE [dbo].[VehicleTypeUse] (
    [VehicleType_Id] uniqueidentifier  NOT NULL,
    [Uses_Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'BodyworkVehicleType'
CREATE TABLE [dbo].[BodyworkVehicleType] (
    [Bodyworks_Id] uniqueidentifier  NOT NULL,
    [VehicleTypes_Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'IntegralCoverage'
CREATE TABLE [dbo].[IntegralCoverage] (
    [Integrals_Id] uniqueidentifier  NOT NULL,
    [Coverages_Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'EmployeeCoverage'
CREATE TABLE [dbo].[EmployeeCoverage] (
    [Employees_Id] uniqueidentifier  NOT NULL,
    [Coverages_Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'VehicleCoverage'
CREATE TABLE [dbo].[VehicleCoverage] (
    [Vehicles_Id] uniqueidentifier  NOT NULL,
    [Coverages_Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'CoveragesPackCoverage'
CREATE TABLE [dbo].[CoveragesPackCoverage] (
    [CoveragesPacks_Id] uniqueidentifier  NOT NULL,
    [Coverages_Id] uniqueidentifier  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Localities'
ALTER TABLE [dbo].[Localities]
ADD CONSTRAINT [PK_Localities]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Provinces'
ALTER TABLE [dbo].[Provinces]
ADD CONSTRAINT [PK_Provinces]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Addresses'
ALTER TABLE [dbo].[Addresses]
ADD CONSTRAINT [PK_Addresses]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Clients'
ALTER TABLE [dbo].[Clients]
ADD CONSTRAINT [PK_Clients]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Policies'
ALTER TABLE [dbo].[Policies]
ADD CONSTRAINT [PK_Policies]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Endorses'
ALTER TABLE [dbo].[Endorses]
ADD CONSTRAINT [PK_Endorses]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Risks'
ALTER TABLE [dbo].[Risks]
ADD CONSTRAINT [PK_Risks]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Vehicles'
ALTER TABLE [dbo].[Vehicles]
ADD CONSTRAINT [PK_Vehicles]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Brands'
ALTER TABLE [dbo].[Brands]
ADD CONSTRAINT [PK_Brands]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Companies'
ALTER TABLE [dbo].[Companies]
ADD CONSTRAINT [PK_Companies]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CasualtyTypes'
ALTER TABLE [dbo].[CasualtyTypes]
ADD CONSTRAINT [PK_CasualtyTypes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Casualties'
ALTER TABLE [dbo].[Casualties]
ADD CONSTRAINT [PK_Casualties]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AccessoryTypes'
ALTER TABLE [dbo].[AccessoryTypes]
ADD CONSTRAINT [PK_AccessoryTypes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Accessories'
ALTER TABLE [dbo].[Accessories]
ADD CONSTRAINT [PK_Accessories]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CreditCards'
ALTER TABLE [dbo].[CreditCards]
ADD CONSTRAINT [PK_CreditCards]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Banks'
ALTER TABLE [dbo].[Banks]
ADD CONSTRAINT [PK_Banks]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Producers'
ALTER TABLE [dbo].[Producers]
ADD CONSTRAINT [PK_Producers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ClientCreditCards'
ALTER TABLE [dbo].[ClientCreditCards]
ADD CONSTRAINT [PK_ClientCreditCards]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Bodyworks'
ALTER TABLE [dbo].[Bodyworks]
ADD CONSTRAINT [PK_Bodyworks]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Uses'
ALTER TABLE [dbo].[Uses]
ADD CONSTRAINT [PK_Uses]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [ProducerId], [CompanyId] in table 'ProducerCodes'
ALTER TABLE [dbo].[ProducerCodes]
ADD CONSTRAINT [PK_ProducerCodes]
    PRIMARY KEY CLUSTERED ([ProducerId], [CompanyId] ASC);
GO

-- Creating primary key on [Id] in table 'Cheques'
ALTER TABLE [dbo].[Cheques]
ADD CONSTRAINT [PK_Cheques]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'LedgerAccounts'
ALTER TABLE [dbo].[LedgerAccounts]
ADD CONSTRAINT [PK_LedgerAccounts]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CashAccounts'
ALTER TABLE [dbo].[CashAccounts]
ADD CONSTRAINT [PK_CashAccounts]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Fees'
ALTER TABLE [dbo].[Fees]
ADD CONSTRAINT [PK_Fees]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Coverages'
ALTER TABLE [dbo].[Coverages]
ADD CONSTRAINT [PK_Coverages]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Employees'
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT [PK_Employees]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Assets'
ALTER TABLE [dbo].[Assets]
ADD CONSTRAINT [PK_Assets]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Liquidations'
ALTER TABLE [dbo].[Liquidations]
ADD CONSTRAINT [PK_Liquidations]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'VehicleTypes'
ALTER TABLE [dbo].[VehicleTypes]
ADD CONSTRAINT [PK_VehicleTypes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Integrals'
ALTER TABLE [dbo].[Integrals]
ADD CONSTRAINT [PK_Integrals]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Contacts'
ALTER TABLE [dbo].[Contacts]
ADD CONSTRAINT [PK_Contacts]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'VehicleModels'
ALTER TABLE [dbo].[VehicleModels]
ADD CONSTRAINT [PK_VehicleModels]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'FeeSelections'
ALTER TABLE [dbo].[FeeSelections]
ADD CONSTRAINT [PK_FeeSelections]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Districts'
ALTER TABLE [dbo].[Districts]
ADD CONSTRAINT [PK_Districts]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AttachedFiles'
ALTER TABLE [dbo].[AttachedFiles]
ADD CONSTRAINT [PK_AttachedFiles]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CoveragesPacks'
ALTER TABLE [dbo].[CoveragesPacks]
ADD CONSTRAINT [PK_CoveragesPacks]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [CreditCards_Id], [Companies_Id] in table 'CreditCardCompany'
ALTER TABLE [dbo].[CreditCardCompany]
ADD CONSTRAINT [PK_CreditCardCompany]
    PRIMARY KEY CLUSTERED ([CreditCards_Id], [Companies_Id] ASC);
GO

-- Creating primary key on [VehicleType_Id], [Uses_Id] in table 'VehicleTypeUse'
ALTER TABLE [dbo].[VehicleTypeUse]
ADD CONSTRAINT [PK_VehicleTypeUse]
    PRIMARY KEY CLUSTERED ([VehicleType_Id], [Uses_Id] ASC);
GO

-- Creating primary key on [Bodyworks_Id], [VehicleTypes_Id] in table 'BodyworkVehicleType'
ALTER TABLE [dbo].[BodyworkVehicleType]
ADD CONSTRAINT [PK_BodyworkVehicleType]
    PRIMARY KEY CLUSTERED ([Bodyworks_Id], [VehicleTypes_Id] ASC);
GO

-- Creating primary key on [Integrals_Id], [Coverages_Id] in table 'IntegralCoverage'
ALTER TABLE [dbo].[IntegralCoverage]
ADD CONSTRAINT [PK_IntegralCoverage]
    PRIMARY KEY CLUSTERED ([Integrals_Id], [Coverages_Id] ASC);
GO

-- Creating primary key on [Employees_Id], [Coverages_Id] in table 'EmployeeCoverage'
ALTER TABLE [dbo].[EmployeeCoverage]
ADD CONSTRAINT [PK_EmployeeCoverage]
    PRIMARY KEY CLUSTERED ([Employees_Id], [Coverages_Id] ASC);
GO

-- Creating primary key on [Vehicles_Id], [Coverages_Id] in table 'VehicleCoverage'
ALTER TABLE [dbo].[VehicleCoverage]
ADD CONSTRAINT [PK_VehicleCoverage]
    PRIMARY KEY CLUSTERED ([Vehicles_Id], [Coverages_Id] ASC);
GO

-- Creating primary key on [CoveragesPacks_Id], [Coverages_Id] in table 'CoveragesPackCoverage'
ALTER TABLE [dbo].[CoveragesPackCoverage]
ADD CONSTRAINT [PK_CoveragesPackCoverage]
    PRIMARY KEY CLUSTERED ([CoveragesPacks_Id], [Coverages_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [LocalityId] in table 'Addresses'
ALTER TABLE [dbo].[Addresses]
ADD CONSTRAINT [FK_LocalityAddress]
    FOREIGN KEY ([LocalityId])
    REFERENCES [dbo].[Localities]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_LocalityAddress'
CREATE INDEX [IX_FK_LocalityAddress]
ON [dbo].[Addresses]
    ([LocalityId]);
GO

-- Creating foreign key on [ClientId] in table 'Policies'
ALTER TABLE [dbo].[Policies]
ADD CONSTRAINT [FK_ClientPolicy]
    FOREIGN KEY ([ClientId])
    REFERENCES [dbo].[Clients]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ClientPolicy'
CREATE INDEX [IX_FK_ClientPolicy]
ON [dbo].[Policies]
    ([ClientId]);
GO

-- Creating foreign key on [CasualtyTypeId] in table 'Casualties'
ALTER TABLE [dbo].[Casualties]
ADD CONSTRAINT [FK_CasualtyTypeCasualty]
    FOREIGN KEY ([CasualtyTypeId])
    REFERENCES [dbo].[CasualtyTypes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CasualtyTypeCasualty'
CREATE INDEX [IX_FK_CasualtyTypeCasualty]
ON [dbo].[Casualties]
    ([CasualtyTypeId]);
GO

-- Creating foreign key on [ClientId] in table 'ClientCreditCards'
ALTER TABLE [dbo].[ClientCreditCards]
ADD CONSTRAINT [FK_ClientClientCreditCard]
    FOREIGN KEY ([ClientId])
    REFERENCES [dbo].[Clients]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ClientClientCreditCard'
CREATE INDEX [IX_FK_ClientClientCreditCard]
ON [dbo].[ClientCreditCards]
    ([ClientId]);
GO

-- Creating foreign key on [CreditCardId] in table 'ClientCreditCards'
ALTER TABLE [dbo].[ClientCreditCards]
ADD CONSTRAINT [FK_ClientCreditCardCreditCard]
    FOREIGN KEY ([CreditCardId])
    REFERENCES [dbo].[CreditCards]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ClientCreditCardCreditCard'
CREATE INDEX [IX_FK_ClientCreditCardCreditCard]
ON [dbo].[ClientCreditCards]
    ([CreditCardId]);
GO

-- Creating foreign key on [BankId] in table 'ClientCreditCards'
ALTER TABLE [dbo].[ClientCreditCards]
ADD CONSTRAINT [FK_BankClientCreditCard]
    FOREIGN KEY ([BankId])
    REFERENCES [dbo].[Banks]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BankClientCreditCard'
CREATE INDEX [IX_FK_BankClientCreditCard]
ON [dbo].[ClientCreditCards]
    ([BankId]);
GO

-- Creating foreign key on [AccessoryTypeId] in table 'Accessories'
ALTER TABLE [dbo].[Accessories]
ADD CONSTRAINT [FK_AccessoryTypeAccessory]
    FOREIGN KEY ([AccessoryTypeId])
    REFERENCES [dbo].[AccessoryTypes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AccessoryTypeAccessory'
CREATE INDEX [IX_FK_AccessoryTypeAccessory]
ON [dbo].[Accessories]
    ([AccessoryTypeId]);
GO

-- Creating foreign key on [ProducerId] in table 'ProducerCodes'
ALTER TABLE [dbo].[ProducerCodes]
ADD CONSTRAINT [FK_ProducerProducerCode]
    FOREIGN KEY ([ProducerId])
    REFERENCES [dbo].[Producers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [CompanyId] in table 'ProducerCodes'
ALTER TABLE [dbo].[ProducerCodes]
ADD CONSTRAINT [FK_CompanyProducerCode]
    FOREIGN KEY ([CompanyId])
    REFERENCES [dbo].[Companies]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CompanyProducerCode'
CREATE INDEX [IX_FK_CompanyProducerCode]
ON [dbo].[ProducerCodes]
    ([CompanyId]);
GO

-- Creating foreign key on [BankId] in table 'Cheques'
ALTER TABLE [dbo].[Cheques]
ADD CONSTRAINT [FK_BankCheque]
    FOREIGN KEY ([BankId])
    REFERENCES [dbo].[Banks]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BankCheque'
CREATE INDEX [IX_FK_BankCheque]
ON [dbo].[Cheques]
    ([BankId]);
GO

-- Creating foreign key on [LedgerAccountId] in table 'CashAccounts'
ALTER TABLE [dbo].[CashAccounts]
ADD CONSTRAINT [FK_LedgerAccountCashAccount]
    FOREIGN KEY ([LedgerAccountId])
    REFERENCES [dbo].[LedgerAccounts]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_LedgerAccountCashAccount'
CREATE INDEX [IX_FK_LedgerAccountCashAccount]
ON [dbo].[CashAccounts]
    ([LedgerAccountId]);
GO

-- Creating foreign key on [PolicyId] in table 'Fees'
ALTER TABLE [dbo].[Fees]
ADD CONSTRAINT [FK_PolicyFee]
    FOREIGN KEY ([PolicyId])
    REFERENCES [dbo].[Policies]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PolicyFee'
CREATE INDEX [IX_FK_PolicyFee]
ON [dbo].[Fees]
    ([PolicyId]);
GO

-- Creating foreign key on [CreditCards_Id] in table 'CreditCardCompany'
ALTER TABLE [dbo].[CreditCardCompany]
ADD CONSTRAINT [FK_CreditCardCompany_CreditCard]
    FOREIGN KEY ([CreditCards_Id])
    REFERENCES [dbo].[CreditCards]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Companies_Id] in table 'CreditCardCompany'
ALTER TABLE [dbo].[CreditCardCompany]
ADD CONSTRAINT [FK_CreditCardCompany_Company]
    FOREIGN KEY ([Companies_Id])
    REFERENCES [dbo].[Companies]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CreditCardCompany_Company'
CREATE INDEX [IX_FK_CreditCardCompany_Company]
ON [dbo].[CreditCardCompany]
    ([Companies_Id]);
GO

-- Creating foreign key on [ProducerId] in table 'CashAccounts'
ALTER TABLE [dbo].[CashAccounts]
ADD CONSTRAINT [FK_ProducerCashAccount]
    FOREIGN KEY ([ProducerId])
    REFERENCES [dbo].[Producers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProducerCashAccount'
CREATE INDEX [IX_FK_ProducerCashAccount]
ON [dbo].[CashAccounts]
    ([ProducerId]);
GO

-- Creating foreign key on [PolicyId] in table 'Casualties'
ALTER TABLE [dbo].[Casualties]
ADD CONSTRAINT [FK_PolicyCasualty]
    FOREIGN KEY ([PolicyId])
    REFERENCES [dbo].[Policies]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PolicyCasualty'
CREATE INDEX [IX_FK_PolicyCasualty]
ON [dbo].[Casualties]
    ([PolicyId]);
GO

-- Creating foreign key on [AssetId] in table 'CashAccounts'
ALTER TABLE [dbo].[CashAccounts]
ADD CONSTRAINT [FK_AssetCashAccount]
    FOREIGN KEY ([AssetId])
    REFERENCES [dbo].[Assets]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AssetCashAccount'
CREATE INDEX [IX_FK_AssetCashAccount]
ON [dbo].[CashAccounts]
    ([AssetId]);
GO

-- Creating foreign key on [VehicleType_Id] in table 'VehicleTypeUse'
ALTER TABLE [dbo].[VehicleTypeUse]
ADD CONSTRAINT [FK_VehicleTypeUse_VehicleType]
    FOREIGN KEY ([VehicleType_Id])
    REFERENCES [dbo].[VehicleTypes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Uses_Id] in table 'VehicleTypeUse'
ALTER TABLE [dbo].[VehicleTypeUse]
ADD CONSTRAINT [FK_VehicleTypeUse_Use]
    FOREIGN KEY ([Uses_Id])
    REFERENCES [dbo].[Uses]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_VehicleTypeUse_Use'
CREATE INDEX [IX_FK_VehicleTypeUse_Use]
ON [dbo].[VehicleTypeUse]
    ([Uses_Id]);
GO

-- Creating foreign key on [VehicleId] in table 'Accessories'
ALTER TABLE [dbo].[Accessories]
ADD CONSTRAINT [FK_VehicleAccessory]
    FOREIGN KEY ([VehicleId])
    REFERENCES [dbo].[Vehicles]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_VehicleAccessory'
CREATE INDEX [IX_FK_VehicleAccessory]
ON [dbo].[Accessories]
    ([VehicleId]);
GO

-- Creating foreign key on [PolicyId] in table 'Employees'
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT [FK_PolicyEmployee]
    FOREIGN KEY ([PolicyId])
    REFERENCES [dbo].[Policies]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PolicyEmployee'
CREATE INDEX [IX_FK_PolicyEmployee]
ON [dbo].[Employees]
    ([PolicyId]);
GO

-- Creating foreign key on [FeeId] in table 'CashAccounts'
ALTER TABLE [dbo].[CashAccounts]
ADD CONSTRAINT [FK_FeeCashAccount]
    FOREIGN KEY ([FeeId])
    REFERENCES [dbo].[Fees]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FeeCashAccount'
CREATE INDEX [IX_FK_FeeCashAccount]
ON [dbo].[CashAccounts]
    ([FeeId]);
GO

-- Creating foreign key on [Bodyworks_Id] in table 'BodyworkVehicleType'
ALTER TABLE [dbo].[BodyworkVehicleType]
ADD CONSTRAINT [FK_BodyworkVehicleType_Bodywork]
    FOREIGN KEY ([Bodyworks_Id])
    REFERENCES [dbo].[Bodyworks]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [VehicleTypes_Id] in table 'BodyworkVehicleType'
ALTER TABLE [dbo].[BodyworkVehicleType]
ADD CONSTRAINT [FK_BodyworkVehicleType_VehicleType]
    FOREIGN KEY ([VehicleTypes_Id])
    REFERENCES [dbo].[VehicleTypes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BodyworkVehicleType_VehicleType'
CREATE INDEX [IX_FK_BodyworkVehicleType_VehicleType]
ON [dbo].[BodyworkVehicleType]
    ([VehicleTypes_Id]);
GO

-- Creating foreign key on [PolicyId] in table 'Vehicles'
ALTER TABLE [dbo].[Vehicles]
ADD CONSTRAINT [FK_PolicyVehicle]
    FOREIGN KEY ([PolicyId])
    REFERENCES [dbo].[Policies]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PolicyVehicle'
CREATE INDEX [IX_FK_PolicyVehicle]
ON [dbo].[Vehicles]
    ([PolicyId]);
GO

-- Creating foreign key on [PolicyId] in table 'Endorses'
ALTER TABLE [dbo].[Endorses]
ADD CONSTRAINT [FK_PolicyEndorse]
    FOREIGN KEY ([PolicyId])
    REFERENCES [dbo].[Policies]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PolicyEndorse'
CREATE INDEX [IX_FK_PolicyEndorse]
ON [dbo].[Endorses]
    ([PolicyId]);
GO

-- Creating foreign key on [EndorseId] in table 'Employees'
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT [FK_EndorseEmployee]
    FOREIGN KEY ([EndorseId])
    REFERENCES [dbo].[Endorses]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EndorseEmployee'
CREATE INDEX [IX_FK_EndorseEmployee]
ON [dbo].[Employees]
    ([EndorseId]);
GO

-- Creating foreign key on [EndorseId] in table 'Vehicles'
ALTER TABLE [dbo].[Vehicles]
ADD CONSTRAINT [FK_EndorseVehicle]
    FOREIGN KEY ([EndorseId])
    REFERENCES [dbo].[Endorses]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EndorseVehicle'
CREATE INDEX [IX_FK_EndorseVehicle]
ON [dbo].[Vehicles]
    ([EndorseId]);
GO

-- Creating foreign key on [ClientId] in table 'Endorses'
ALTER TABLE [dbo].[Endorses]
ADD CONSTRAINT [FK_ClientEndorse]
    FOREIGN KEY ([ClientId])
    REFERENCES [dbo].[Clients]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ClientEndorse'
CREATE INDEX [IX_FK_ClientEndorse]
ON [dbo].[Endorses]
    ([ClientId]);
GO

-- Creating foreign key on [CompanyId] in table 'Contacts'
ALTER TABLE [dbo].[Contacts]
ADD CONSTRAINT [FK_CompanyContact]
    FOREIGN KEY ([CompanyId])
    REFERENCES [dbo].[Companies]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CompanyContact'
CREATE INDEX [IX_FK_CompanyContact]
ON [dbo].[Contacts]
    ([CompanyId]);
GO

-- Creating foreign key on [CompanyId] in table 'Risks'
ALTER TABLE [dbo].[Risks]
ADD CONSTRAINT [FK_CompanyRisk]
    FOREIGN KEY ([CompanyId])
    REFERENCES [dbo].[Companies]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CompanyRisk'
CREATE INDEX [IX_FK_CompanyRisk]
ON [dbo].[Risks]
    ([CompanyId]);
GO

-- Creating foreign key on [ProducerId] in table 'Policies'
ALTER TABLE [dbo].[Policies]
ADD CONSTRAINT [FK_ProducerPolicy]
    FOREIGN KEY ([ProducerId])
    REFERENCES [dbo].[Producers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProducerPolicy'
CREATE INDEX [IX_FK_ProducerPolicy]
ON [dbo].[Policies]
    ([ProducerId]);
GO

-- Creating foreign key on [BrandId] in table 'VehicleModels'
ALTER TABLE [dbo].[VehicleModels]
ADD CONSTRAINT [FK_BrandVehicleModel]
    FOREIGN KEY ([BrandId])
    REFERENCES [dbo].[Brands]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BrandVehicleModel'
CREATE INDEX [IX_FK_BrandVehicleModel]
ON [dbo].[VehicleModels]
    ([BrandId]);
GO

-- Creating foreign key on [VehicleTypeId] in table 'VehicleModels'
ALTER TABLE [dbo].[VehicleModels]
ADD CONSTRAINT [FK_VehicleTypeVehicleModel]
    FOREIGN KEY ([VehicleTypeId])
    REFERENCES [dbo].[VehicleTypes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_VehicleTypeVehicleModel'
CREATE INDEX [IX_FK_VehicleTypeVehicleModel]
ON [dbo].[VehicleModels]
    ([VehicleTypeId]);
GO

-- Creating foreign key on [VehicleModelId] in table 'Vehicles'
ALTER TABLE [dbo].[Vehicles]
ADD CONSTRAINT [FK_VehicleModelVehicle]
    FOREIGN KEY ([VehicleModelId])
    REFERENCES [dbo].[VehicleModels]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_VehicleModelVehicle'
CREATE INDEX [IX_FK_VehicleModelVehicle]
ON [dbo].[Vehicles]
    ([VehicleModelId]);
GO

-- Creating foreign key on [UseId] in table 'Vehicles'
ALTER TABLE [dbo].[Vehicles]
ADD CONSTRAINT [FK_UseVehicle]
    FOREIGN KEY ([UseId])
    REFERENCES [dbo].[Uses]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UseVehicle'
CREATE INDEX [IX_FK_UseVehicle]
ON [dbo].[Vehicles]
    ([UseId]);
GO

-- Creating foreign key on [BodyworkId] in table 'Vehicles'
ALTER TABLE [dbo].[Vehicles]
ADD CONSTRAINT [FK_BodyworkVehicle]
    FOREIGN KEY ([BodyworkId])
    REFERENCES [dbo].[Bodyworks]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BodyworkVehicle'
CREATE INDEX [IX_FK_BodyworkVehicle]
ON [dbo].[Vehicles]
    ([BodyworkId]);
GO

-- Creating foreign key on [LiquidationId] in table 'FeeSelections'
ALTER TABLE [dbo].[FeeSelections]
ADD CONSTRAINT [FK_LiquidationFeeSelection]
    FOREIGN KEY ([LiquidationId])
    REFERENCES [dbo].[Liquidations]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_LiquidationFeeSelection'
CREATE INDEX [IX_FK_LiquidationFeeSelection]
ON [dbo].[FeeSelections]
    ([LiquidationId]);
GO

-- Creating foreign key on [FeeSelectionId] in table 'Fees'
ALTER TABLE [dbo].[Fees]
ADD CONSTRAINT [FK_FeeSelectionFee]
    FOREIGN KEY ([FeeSelectionId])
    REFERENCES [dbo].[FeeSelections]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FeeSelectionFee'
CREATE INDEX [IX_FK_FeeSelectionFee]
ON [dbo].[Fees]
    ([FeeSelectionId]);
GO

-- Creating foreign key on [CompanyId] in table 'Liquidations'
ALTER TABLE [dbo].[Liquidations]
ADD CONSTRAINT [FK_CompanyLiquidation]
    FOREIGN KEY ([CompanyId])
    REFERENCES [dbo].[Companies]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CompanyLiquidation'
CREATE INDEX [IX_FK_CompanyLiquidation]
ON [dbo].[Liquidations]
    ([CompanyId]);
GO

-- Creating foreign key on [EndorseId] in table 'Fees'
ALTER TABLE [dbo].[Fees]
ADD CONSTRAINT [FK_EndorseFee]
    FOREIGN KEY ([EndorseId])
    REFERENCES [dbo].[Endorses]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EndorseFee'
CREATE INDEX [IX_FK_EndorseFee]
ON [dbo].[Fees]
    ([EndorseId]);
GO

-- Creating foreign key on [CollectorId] in table 'Policies'
ALTER TABLE [dbo].[Policies]
ADD CONSTRAINT [FK_ProducerPolicyCollector]
    FOREIGN KEY ([CollectorId])
    REFERENCES [dbo].[Producers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProducerPolicyCollector'
CREATE INDEX [IX_FK_ProducerPolicyCollector]
ON [dbo].[Policies]
    ([CollectorId]);
GO

-- Creating foreign key on [ProvinceId] in table 'Districts'
ALTER TABLE [dbo].[Districts]
ADD CONSTRAINT [FK_ProvinceDistrict]
    FOREIGN KEY ([ProvinceId])
    REFERENCES [dbo].[Provinces]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProvinceDistrict'
CREATE INDEX [IX_FK_ProvinceDistrict]
ON [dbo].[Districts]
    ([ProvinceId]);
GO

-- Creating foreign key on [DistrictId] in table 'Localities'
ALTER TABLE [dbo].[Localities]
ADD CONSTRAINT [FK_DistrictLocality]
    FOREIGN KEY ([DistrictId])
    REFERENCES [dbo].[Districts]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DistrictLocality'
CREATE INDEX [IX_FK_DistrictLocality]
ON [dbo].[Localities]
    ([DistrictId]);
GO

-- Creating foreign key on [EndorseId] in table 'AttachedFiles'
ALTER TABLE [dbo].[AttachedFiles]
ADD CONSTRAINT [FK_EndorseAttachedFile]
    FOREIGN KEY ([EndorseId])
    REFERENCES [dbo].[Endorses]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EndorseAttachedFile'
CREATE INDEX [IX_FK_EndorseAttachedFile]
ON [dbo].[AttachedFiles]
    ([EndorseId]);
GO

-- Creating foreign key on [PolicyId] in table 'AttachedFiles'
ALTER TABLE [dbo].[AttachedFiles]
ADD CONSTRAINT [FK_PolicyAttachedFile]
    FOREIGN KEY ([PolicyId])
    REFERENCES [dbo].[Policies]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PolicyAttachedFile'
CREATE INDEX [IX_FK_PolicyAttachedFile]
ON [dbo].[AttachedFiles]
    ([PolicyId]);
GO

-- Creating foreign key on [CasualtyId] in table 'AttachedFiles'
ALTER TABLE [dbo].[AttachedFiles]
ADD CONSTRAINT [FK_CasualtyAttachedFile]
    FOREIGN KEY ([CasualtyId])
    REFERENCES [dbo].[Casualties]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CasualtyAttachedFile'
CREATE INDEX [IX_FK_CasualtyAttachedFile]
ON [dbo].[AttachedFiles]
    ([CasualtyId]);
GO

-- Creating foreign key on [CashAccountId] in table 'AttachedFiles'
ALTER TABLE [dbo].[AttachedFiles]
ADD CONSTRAINT [FK_CashAccountAttachedFile]
    FOREIGN KEY ([CashAccountId])
    REFERENCES [dbo].[CashAccounts]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CashAccountAttachedFile'
CREATE INDEX [IX_FK_CashAccountAttachedFile]
ON [dbo].[AttachedFiles]
    ([CashAccountId]);
GO

-- Creating foreign key on [Integrals_Id] in table 'IntegralCoverage'
ALTER TABLE [dbo].[IntegralCoverage]
ADD CONSTRAINT [FK_IntegralCoverage_Integral]
    FOREIGN KEY ([Integrals_Id])
    REFERENCES [dbo].[Integrals]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Coverages_Id] in table 'IntegralCoverage'
ALTER TABLE [dbo].[IntegralCoverage]
ADD CONSTRAINT [FK_IntegralCoverage_Coverage]
    FOREIGN KEY ([Coverages_Id])
    REFERENCES [dbo].[Coverages]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_IntegralCoverage_Coverage'
CREATE INDEX [IX_FK_IntegralCoverage_Coverage]
ON [dbo].[IntegralCoverage]
    ([Coverages_Id]);
GO

-- Creating foreign key on [Employees_Id] in table 'EmployeeCoverage'
ALTER TABLE [dbo].[EmployeeCoverage]
ADD CONSTRAINT [FK_EmployeeCoverage_Employee]
    FOREIGN KEY ([Employees_Id])
    REFERENCES [dbo].[Employees]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Coverages_Id] in table 'EmployeeCoverage'
ALTER TABLE [dbo].[EmployeeCoverage]
ADD CONSTRAINT [FK_EmployeeCoverage_Coverage]
    FOREIGN KEY ([Coverages_Id])
    REFERENCES [dbo].[Coverages]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EmployeeCoverage_Coverage'
CREATE INDEX [IX_FK_EmployeeCoverage_Coverage]
ON [dbo].[EmployeeCoverage]
    ([Coverages_Id]);
GO

-- Creating foreign key on [Vehicles_Id] in table 'VehicleCoverage'
ALTER TABLE [dbo].[VehicleCoverage]
ADD CONSTRAINT [FK_VehicleCoverage_Vehicle]
    FOREIGN KEY ([Vehicles_Id])
    REFERENCES [dbo].[Vehicles]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Coverages_Id] in table 'VehicleCoverage'
ALTER TABLE [dbo].[VehicleCoverage]
ADD CONSTRAINT [FK_VehicleCoverage_Coverage]
    FOREIGN KEY ([Coverages_Id])
    REFERENCES [dbo].[Coverages]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_VehicleCoverage_Coverage'
CREATE INDEX [IX_FK_VehicleCoverage_Coverage]
ON [dbo].[VehicleCoverage]
    ([Coverages_Id]);
GO

-- Creating foreign key on [RiskId] in table 'CoveragesPacks'
ALTER TABLE [dbo].[CoveragesPacks]
ADD CONSTRAINT [FK_RiskCoveragesPack]
    FOREIGN KEY ([RiskId])
    REFERENCES [dbo].[Risks]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RiskCoveragesPack'
CREATE INDEX [IX_FK_RiskCoveragesPack]
ON [dbo].[CoveragesPacks]
    ([RiskId]);
GO

-- Creating foreign key on [RiskId] in table 'Policies'
ALTER TABLE [dbo].[Policies]
ADD CONSTRAINT [FK_RiskPolicy]
    FOREIGN KEY ([RiskId])
    REFERENCES [dbo].[Risks]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RiskPolicy'
CREATE INDEX [IX_FK_RiskPolicy]
ON [dbo].[Policies]
    ([RiskId]);
GO

-- Creating foreign key on [RiskId] in table 'Coverages'
ALTER TABLE [dbo].[Coverages]
ADD CONSTRAINT [FK_RiskCoverage]
    FOREIGN KEY ([RiskId])
    REFERENCES [dbo].[Risks]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RiskCoverage'
CREATE INDEX [IX_FK_RiskCoverage]
ON [dbo].[Coverages]
    ([RiskId]);
GO

-- Creating foreign key on [CoveragesPacks_Id] in table 'CoveragesPackCoverage'
ALTER TABLE [dbo].[CoveragesPackCoverage]
ADD CONSTRAINT [FK_CoveragesPackCoverage_CoveragesPack]
    FOREIGN KEY ([CoveragesPacks_Id])
    REFERENCES [dbo].[CoveragesPacks]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Coverages_Id] in table 'CoveragesPackCoverage'
ALTER TABLE [dbo].[CoveragesPackCoverage]
ADD CONSTRAINT [FK_CoveragesPackCoverage_Coverage]
    FOREIGN KEY ([Coverages_Id])
    REFERENCES [dbo].[Coverages]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CoveragesPackCoverage_Coverage'
CREATE INDEX [IX_FK_CoveragesPackCoverage_Coverage]
ON [dbo].[CoveragesPackCoverage]
    ([Coverages_Id]);
GO

-- Creating foreign key on [ClientId] in table 'Addresses'
ALTER TABLE [dbo].[Addresses]
ADD CONSTRAINT [FK_ClientAddress]
    FOREIGN KEY ([ClientId])
    REFERENCES [dbo].[Clients]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ClientAddress'
CREATE INDEX [IX_FK_ClientAddress]
ON [dbo].[Addresses]
    ([ClientId]);
GO

-- Creating foreign key on [PolicyId] in table 'Integrals'
ALTER TABLE [dbo].[Integrals]
ADD CONSTRAINT [FK_PolicyIntegral]
    FOREIGN KEY ([PolicyId])
    REFERENCES [dbo].[Policies]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PolicyIntegral'
CREATE INDEX [IX_FK_PolicyIntegral]
ON [dbo].[Integrals]
    ([PolicyId]);
GO

-- Creating foreign key on [EndorseId] in table 'Integrals'
ALTER TABLE [dbo].[Integrals]
ADD CONSTRAINT [FK_EndorseIntegral]
    FOREIGN KEY ([EndorseId])
    REFERENCES [dbo].[Endorses]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EndorseIntegral'
CREATE INDEX [IX_FK_EndorseIntegral]
ON [dbo].[Integrals]
    ([EndorseId]);
GO

-- Creating foreign key on [Integral_Id] in table 'Addresses'
ALTER TABLE [dbo].[Addresses]
ADD CONSTRAINT [FK_IntegralAddress]
    FOREIGN KEY ([Integral_Id])
    REFERENCES [dbo].[Integrals]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_IntegralAddress'
CREATE INDEX [IX_FK_IntegralAddress]
ON [dbo].[Addresses]
    ([Integral_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------