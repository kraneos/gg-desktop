namespace Seggu.Api.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accessories",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Stamp = c.String(),
                        ExpirationDate = c.DateTime(nullable: false),
                        AccessoryTypeId = c.Guid(nullable: false),
                        Value = c.Decimal(nullable: false, precision: 18, scale: 2),
                        VehicleId = c.Guid(nullable: false),
                        Name = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        CreatedBy = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AccessoryTypes", t => t.AccessoryTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Vehicles", t => t.VehicleId, cascadeDelete: true)
                .Index(t => t.AccessoryTypeId)
                .Index(t => t.VehicleId);
            
            CreateTable(
                "dbo.AccessoryTypes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        CreatedBy = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Plate = c.String(),
                        Engine = c.String(),
                        Year = c.String(),
                        Chassis = c.String(),
                        PolicyId = c.Guid(nullable: false),
                        EndorseId = c.Guid(),
                        VehicleModelId = c.Guid(nullable: false),
                        UseId = c.Guid(nullable: false),
                        BodyworkId = c.Guid(nullable: false),
                        IsRemoved = c.Boolean(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        CreatedBy = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Bodyworks", t => t.BodyworkId, cascadeDelete: true)
                .ForeignKey("dbo.Uses", t => t.UseId, cascadeDelete: true)
                .ForeignKey("dbo.VehicleModels", t => t.VehicleModelId, cascadeDelete: true)
                .ForeignKey("dbo.Policies", t => t.PolicyId, cascadeDelete: true)
                .ForeignKey("dbo.Endorses", t => t.EndorseId)
                .Index(t => t.PolicyId)
                .Index(t => t.EndorseId)
                .Index(t => t.VehicleModelId)
                .Index(t => t.UseId)
                .Index(t => t.BodyworkId);
            
            CreateTable(
                "dbo.Bodyworks",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        CreatedBy = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.VehicleTypes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        CreatedBy = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Uses",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        CreatedBy = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.VehicleModels",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Origin = c.Int(nullable: false),
                        BrandId = c.Guid(nullable: false),
                        VehicleTypeId = c.Guid(nullable: false),
                        Name = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        CreatedBy = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Brands", t => t.BrandId, cascadeDelete: true)
                .ForeignKey("dbo.VehicleTypes", t => t.VehicleTypeId, cascadeDelete: true)
                .Index(t => t.BrandId)
                .Index(t => t.VehicleTypeId);
            
            CreateTable(
                "dbo.Brands",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        CreatedBy = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Coverages",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Description = c.String(),
                        RiskId = c.Guid(nullable: false),
                        Name = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        CreatedBy = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Risks", t => t.RiskId, cascadeDelete: true)
                .Index(t => t.RiskId);
            
            CreateTable(
                "dbo.CoveragesPacks",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        RiskId = c.Guid(nullable: false),
                        Name = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        CreatedBy = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Risks", t => t.RiskId, cascadeDelete: true)
                .Index(t => t.RiskId);
            
            CreateTable(
                "dbo.Risks",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        RiskType = c.Int(nullable: false),
                        CompanyId = c.Guid(nullable: false),
                        Name = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        CreatedBy = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.CompanyId, cascadeDelete: true)
                .Index(t => t.CompanyId);
            
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Phone = c.String(),
                        Notes = c.String(),
                        Active = c.Boolean(nullable: false),
                        EMail = c.String(),
                        CUIT = c.String(),
                        LiqDay1 = c.Int(nullable: false),
                        LiqDay2 = c.Int(nullable: false),
                        PaymentDay1 = c.Int(nullable: false),
                        PaymentDay2 = c.Int(nullable: false),
                        Name = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        CreatedBy = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Phone = c.String(),
                        Mail = c.String(),
                        Notes = c.String(),
                        CompanyId = c.Guid(),
                        Bussiness = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        CreatedBy = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.CompanyId)
                .Index(t => t.CompanyId);
            
            CreateTable(
                "dbo.CreditCards",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        CreatedBy = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ClientCreditCards",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Number = c.Long(),
                        ClientId = c.Guid(nullable: false),
                        CreditCardId = c.Guid(nullable: false),
                        BankId = c.Guid(nullable: false),
                        ExpirationDate = c.DateTime(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        CreatedBy = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Banks", t => t.BankId, cascadeDelete: true)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .ForeignKey("dbo.CreditCards", t => t.CreditCardId, cascadeDelete: true)
                .Index(t => t.ClientId)
                .Index(t => t.CreditCardId)
                .Index(t => t.BankId);
            
            CreateTable(
                "dbo.Banks",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Number = c.String(),
                        Name = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        CreatedBy = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Cheques",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Number = c.String(),
                        BankId = c.Guid(nullable: false),
                        Value = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Date = c.DateTime(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        CreatedBy = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Banks", t => t.BankId, cascadeDelete: true)
                .Index(t => t.BankId);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        CellPhone = c.String(),
                        Mail = c.String(),
                        Document = c.String(),
                        BirthDate = c.DateTime(),
                        Cuit = c.String(),
                        IngresosBrutos = c.String(),
                        CollectionTimeRange = c.String(),
                        BankingCode = c.String(),
                        Notes = c.String(),
                        IsSmoker = c.Boolean(nullable: false),
                        Sex = c.Int(nullable: false),
                        IVA = c.Int(nullable: false),
                        MaritalStatus = c.Int(nullable: false),
                        DocumentType = c.Int(nullable: false),
                        Occupation = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        CreatedBy = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Street = c.String(),
                        Phone = c.String(),
                        Number = c.String(),
                        Floor = c.String(),
                        Appartment = c.String(),
                        LocalityId = c.Guid(),
                        PostalCode = c.String(),
                        AddressType = c.Int(nullable: false),
                        ClientId = c.Guid(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        CreatedBy = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.ClientId)
                .ForeignKey("dbo.Localities", t => t.LocalityId)
                .Index(t => t.LocalityId)
                .Index(t => t.ClientId);
            
            CreateTable(
                "dbo.Integrals",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        PolicyId = c.Guid(),
                        EndorseId = c.Guid(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        CreatedBy = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.Id)
                .ForeignKey("dbo.Policies", t => t.PolicyId)
                .ForeignKey("dbo.Endorses", t => t.EndorseId)
                .Index(t => t.Id)
                .Index(t => t.PolicyId)
                .Index(t => t.EndorseId);
            
            CreateTable(
                "dbo.Endorses",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        EndorseType = c.Int(nullable: false),
                        Number = c.String(),
                        Cause = c.String(),
                        PolicyId = c.Guid(nullable: false),
                        ClientId = c.Guid(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        RequestDate = c.DateTime(nullable: false),
                        ReceptionDate = c.DateTime(),
                        EmissionDate = c.DateTime(),
                        Prima = c.Decimal(precision: 18, scale: 2),
                        Premium = c.Decimal(precision: 18, scale: 2),
                        Surcharge = c.Decimal(precision: 18, scale: 2),
                        Value = c.Decimal(precision: 18, scale: 2),
                        Notes = c.String(),
                        IsAnnulled = c.Boolean(),
                        AnnulationDate = c.DateTime(),
                        IsRemoved = c.Boolean(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        CreatedBy = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Policies", t => t.PolicyId, cascadeDelete: true)
                .ForeignKey("dbo.Clients", t => t.ClientId)
                .Index(t => t.PolicyId)
                .Index(t => t.ClientId);
            
            CreateTable(
                "dbo.AttachedFiles",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        EndorseId = c.Guid(),
                        FilePath = c.String(),
                        PolicyId = c.Guid(),
                        CasualtyId = c.Guid(),
                        CashAccountId = c.Guid(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        CreatedBy = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CashAccounts", t => t.CashAccountId)
                .ForeignKey("dbo.Policies", t => t.PolicyId)
                .ForeignKey("dbo.Casualties", t => t.CasualtyId)
                .ForeignKey("dbo.Endorses", t => t.EndorseId)
                .Index(t => t.EndorseId)
                .Index(t => t.PolicyId)
                .Index(t => t.CasualtyId)
                .Index(t => t.CashAccountId);
            
            CreateTable(
                "dbo.CashAccounts",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        AssetId = c.Guid(nullable: false),
                        LedgerAccountId = c.Guid(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Description = c.String(),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Balance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ProducerId = c.Guid(nullable: false),
                        FeeId = c.Guid(),
                        ReceiptNumber = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        CreatedBy = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Assets", t => t.AssetId, cascadeDelete: true)
                .ForeignKey("dbo.Fees", t => t.FeeId)
                .ForeignKey("dbo.Producers", t => t.ProducerId, cascadeDelete: true)
                .ForeignKey("dbo.LedgerAccounts", t => t.LedgerAccountId, cascadeDelete: true)
                .Index(t => t.AssetId)
                .Index(t => t.LedgerAccountId)
                .Index(t => t.ProducerId)
                .Index(t => t.FeeId);
            
            CreateTable(
                "dbo.Assets",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Name = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        CreatedBy = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Fees",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        PolicyId = c.Guid(nullable: false),
                        ExpirationDate = c.DateTime(nullable: false),
                        Number = c.Int(nullable: false),
                        Value = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Balance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CompanyPayment = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Annulated = c.Boolean(nullable: false),
                        FeeSelectionId = c.Guid(),
                        State = c.Int(nullable: false),
                        EndorseId = c.Guid(),
                        RegisteredLiqDate = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        CreatedBy = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Endorses", t => t.EndorseId)
                .ForeignKey("dbo.FeeSelections", t => t.FeeSelectionId)
                .ForeignKey("dbo.Policies", t => t.PolicyId, cascadeDelete: true)
                .Index(t => t.PolicyId)
                .Index(t => t.FeeSelectionId)
                .Index(t => t.EndorseId);
            
            CreateTable(
                "dbo.FeeSelections",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LiquidationId = c.Guid(nullable: false),
                        Notes = c.String(),
                        Name = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        CreatedBy = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Liquidations", t => t.LiquidationId, cascadeDelete: true)
                .Index(t => t.LiquidationId);
            
            CreateTable(
                "dbo.Liquidations",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ReceptionDate = c.DateTime(),
                        Registered = c.Boolean(nullable: false),
                        Notes = c.String(),
                        CompanyId = c.Guid(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        CreatedBy = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.CompanyId, cascadeDelete: true)
                .Index(t => t.CompanyId);
            
            CreateTable(
                "dbo.Policies",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        PreviousNumber = c.String(),
                        ClientId = c.Guid(nullable: false),
                        Period = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        RequestDate = c.DateTime(nullable: false),
                        ReceptionDate = c.DateTime(),
                        EmissionDate = c.DateTime(),
                        Prima = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Premium = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Surcharge = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Bonus = c.Decimal(precision: 18, scale: 2),
                        Value = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Notes = c.String(),
                        Number = c.String(),
                        IsRenovated = c.Boolean(nullable: false),
                        IsAnnulled = c.Boolean(nullable: false),
                        AnnulationDate = c.DateTime(),
                        IsRemoved = c.Boolean(nullable: false),
                        ProducerId = c.Guid(nullable: false),
                        CollectorId = c.Guid(),
                        RiskId = c.Guid(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        CreatedBy = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .ForeignKey("dbo.Producers", t => t.CollectorId)
                .ForeignKey("dbo.Producers", t => t.ProducerId, cascadeDelete: true)
                .ForeignKey("dbo.Risks", t => t.RiskId, cascadeDelete: true)
                .Index(t => t.ClientId)
                .Index(t => t.ProducerId)
                .Index(t => t.CollectorId)
                .Index(t => t.RiskId);
            
            CreateTable(
                "dbo.Casualties",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        PolicyId = c.Guid(nullable: false),
                        Number = c.Int(nullable: false),
                        CasualtyTypeId = c.Guid(nullable: false),
                        OurCharge = c.Boolean(nullable: false),
                        OccurredDate = c.DateTime(nullable: false),
                        ReceiveDate = c.DateTime(nullable: false),
                        PoliceReportDate = c.DateTime(),
                        EstimatedCompensation = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DefinedCompensation = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Notes = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        CreatedBy = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CasualtyTypes", t => t.CasualtyTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Policies", t => t.PolicyId, cascadeDelete: true)
                .Index(t => t.PolicyId)
                .Index(t => t.CasualtyTypeId);
            
            CreateTable(
                "dbo.CasualtyTypes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        CreatedBy = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Producers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        RegistrationNumber = c.String(),
                        IsCollector = c.Boolean(nullable: false),
                        Name = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        CreatedBy = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProducerCodes",
                c => new
                    {
                        CompanyId = c.Guid(nullable: false),
                        ProducerId = c.Guid(nullable: false),
                        Code = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        CreatedBy = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.CompanyId, t.ProducerId })
                .ForeignKey("dbo.Companies", t => t.CompanyId, cascadeDelete: true)
                .ForeignKey("dbo.Producers", t => t.ProducerId, cascadeDelete: true)
                .Index(t => t.CompanyId)
                .Index(t => t.ProducerId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        PolicyId = c.Guid(nullable: false),
                        EndorseId = c.Guid(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        DNI = c.String(),
                        CUIT = c.String(),
                        IsRemoved = c.Boolean(),
                        InsuranceAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        CreatedBy = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Endorses", t => t.EndorseId)
                .ForeignKey("dbo.Policies", t => t.PolicyId, cascadeDelete: true)
                .Index(t => t.PolicyId)
                .Index(t => t.EndorseId);
            
            CreateTable(
                "dbo.LedgerAccounts",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        CreatedBy = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Localities",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        DistrictId = c.Guid(nullable: false),
                        Name = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        CreatedBy = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Districts", t => t.DistrictId, cascadeDelete: true)
                .Index(t => t.DistrictId);
            
            CreateTable(
                "dbo.Districts",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ProvinceId = c.Guid(nullable: false),
                        Name = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        CreatedBy = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Provinces", t => t.ProvinceId, cascadeDelete: true)
                .Index(t => t.ProvinceId);
            
            CreateTable(
                "dbo.Provinces",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        CreatedBy = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.VehicleTypeUse",
                c => new
                    {
                        VehicleType_Id = c.Guid(nullable: false),
                        Uses_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.VehicleType_Id, t.Uses_Id })
                .ForeignKey("dbo.VehicleTypes", t => t.VehicleType_Id)
                .ForeignKey("dbo.Uses", t => t.Uses_Id)
                .Index(t => t.VehicleType_Id)
                .Index(t => t.Uses_Id);
            
            CreateTable(
                "dbo.BodyworkVehicleType",
                c => new
                    {
                        Bodyworks_Id = c.Guid(nullable: false),
                        VehicleTypes_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Bodyworks_Id, t.VehicleTypes_Id })
                .ForeignKey("dbo.Bodyworks", t => t.Bodyworks_Id)
                .ForeignKey("dbo.VehicleTypes", t => t.VehicleTypes_Id)
                .Index(t => t.Bodyworks_Id)
                .Index(t => t.VehicleTypes_Id);
            
            CreateTable(
                "dbo.CoveragesPacksCoverages",
                c => new
                    {
                        CoveragesPackId = c.Guid(nullable: false),
                        CoverageId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.CoveragesPackId, t.CoverageId })
                .ForeignKey("dbo.CoveragesPacks", t => t.CoveragesPackId)
                .ForeignKey("dbo.Coverages", t => t.CoverageId)
                .Index(t => t.CoveragesPackId)
                .Index(t => t.CoverageId);
            
            CreateTable(
                "dbo.IntegralCoverage",
                c => new
                    {
                        Integrals_Id = c.Guid(nullable: false),
                        Coverages_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Integrals_Id, t.Coverages_Id })
                .ForeignKey("dbo.Integrals", t => t.Integrals_Id)
                .ForeignKey("dbo.Coverages", t => t.Coverages_Id)
                .Index(t => t.Integrals_Id)
                .Index(t => t.Coverages_Id);
            
            CreateTable(
                "dbo.EmployeeCoverage",
                c => new
                    {
                        Employees_Id = c.Guid(nullable: false),
                        Coverages_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Employees_Id, t.Coverages_Id })
                .ForeignKey("dbo.Employees", t => t.Employees_Id)
                .ForeignKey("dbo.Coverages", t => t.Coverages_Id)
                .Index(t => t.Employees_Id)
                .Index(t => t.Coverages_Id);
            
            CreateTable(
                "dbo.CreditCardCompanies",
                c => new
                    {
                        CreditCard_Id = c.Guid(nullable: false),
                        Company_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.CreditCard_Id, t.Company_Id })
                .ForeignKey("dbo.CreditCards", t => t.CreditCard_Id)
                .ForeignKey("dbo.Companies", t => t.Company_Id)
                .Index(t => t.CreditCard_Id)
                .Index(t => t.Company_Id);
            
            CreateTable(
                "dbo.VehicleCoverage",
                c => new
                    {
                        Vehicles_Id = c.Guid(nullable: false),
                        Coverages_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Vehicles_Id, t.Coverages_Id })
                .ForeignKey("dbo.Vehicles", t => t.Vehicles_Id)
                .ForeignKey("dbo.Coverages", t => t.Coverages_Id)
                .Index(t => t.Vehicles_Id)
                .Index(t => t.Coverages_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.VehicleCoverage", "Coverages_Id", "dbo.Coverages");
            DropForeignKey("dbo.VehicleCoverage", "Vehicles_Id", "dbo.Vehicles");
            DropForeignKey("dbo.CoveragesPacks", "RiskId", "dbo.Risks");
            DropForeignKey("dbo.Coverages", "RiskId", "dbo.Risks");
            DropForeignKey("dbo.Risks", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.CreditCardCompanies", "Company_Id", "dbo.Companies");
            DropForeignKey("dbo.CreditCardCompanies", "CreditCard_Id", "dbo.CreditCards");
            DropForeignKey("dbo.ClientCreditCards", "CreditCardId", "dbo.CreditCards");
            DropForeignKey("dbo.ClientCreditCards", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.Districts", "ProvinceId", "dbo.Provinces");
            DropForeignKey("dbo.Localities", "DistrictId", "dbo.Districts");
            DropForeignKey("dbo.Addresses", "LocalityId", "dbo.Localities");
            DropForeignKey("dbo.Vehicles", "EndorseId", "dbo.Endorses");
            DropForeignKey("dbo.Integrals", "EndorseId", "dbo.Endorses");
            DropForeignKey("dbo.Endorses", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.AttachedFiles", "EndorseId", "dbo.Endorses");
            DropForeignKey("dbo.CashAccounts", "LedgerAccountId", "dbo.LedgerAccounts");
            DropForeignKey("dbo.Vehicles", "PolicyId", "dbo.Policies");
            DropForeignKey("dbo.Policies", "RiskId", "dbo.Risks");
            DropForeignKey("dbo.Policies", "ProducerId", "dbo.Producers");
            DropForeignKey("dbo.Integrals", "PolicyId", "dbo.Policies");
            DropForeignKey("dbo.Fees", "PolicyId", "dbo.Policies");
            DropForeignKey("dbo.Endorses", "PolicyId", "dbo.Policies");
            DropForeignKey("dbo.Employees", "PolicyId", "dbo.Policies");
            DropForeignKey("dbo.Employees", "EndorseId", "dbo.Endorses");
            DropForeignKey("dbo.EmployeeCoverage", "Coverages_Id", "dbo.Coverages");
            DropForeignKey("dbo.EmployeeCoverage", "Employees_Id", "dbo.Employees");
            DropForeignKey("dbo.Policies", "CollectorId", "dbo.Producers");
            DropForeignKey("dbo.ProducerCodes", "ProducerId", "dbo.Producers");
            DropForeignKey("dbo.ProducerCodes", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.CashAccounts", "ProducerId", "dbo.Producers");
            DropForeignKey("dbo.Policies", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.Casualties", "PolicyId", "dbo.Policies");
            DropForeignKey("dbo.Casualties", "CasualtyTypeId", "dbo.CasualtyTypes");
            DropForeignKey("dbo.AttachedFiles", "CasualtyId", "dbo.Casualties");
            DropForeignKey("dbo.AttachedFiles", "PolicyId", "dbo.Policies");
            DropForeignKey("dbo.FeeSelections", "LiquidationId", "dbo.Liquidations");
            DropForeignKey("dbo.Liquidations", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.Fees", "FeeSelectionId", "dbo.FeeSelections");
            DropForeignKey("dbo.Fees", "EndorseId", "dbo.Endorses");
            DropForeignKey("dbo.CashAccounts", "FeeId", "dbo.Fees");
            DropForeignKey("dbo.AttachedFiles", "CashAccountId", "dbo.CashAccounts");
            DropForeignKey("dbo.CashAccounts", "AssetId", "dbo.Assets");
            DropForeignKey("dbo.IntegralCoverage", "Coverages_Id", "dbo.Coverages");
            DropForeignKey("dbo.IntegralCoverage", "Integrals_Id", "dbo.Integrals");
            DropForeignKey("dbo.Integrals", "Id", "dbo.Addresses");
            DropForeignKey("dbo.Addresses", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.ClientCreditCards", "BankId", "dbo.Banks");
            DropForeignKey("dbo.Cheques", "BankId", "dbo.Banks");
            DropForeignKey("dbo.Contacts", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.CoveragesPacksCoverages", "CoverageId", "dbo.Coverages");
            DropForeignKey("dbo.CoveragesPacksCoverages", "CoveragesPackId", "dbo.CoveragesPacks");
            DropForeignKey("dbo.BodyworkVehicleType", "VehicleTypes_Id", "dbo.VehicleTypes");
            DropForeignKey("dbo.BodyworkVehicleType", "Bodyworks_Id", "dbo.Bodyworks");
            DropForeignKey("dbo.VehicleModels", "VehicleTypeId", "dbo.VehicleTypes");
            DropForeignKey("dbo.Vehicles", "VehicleModelId", "dbo.VehicleModels");
            DropForeignKey("dbo.VehicleModels", "BrandId", "dbo.Brands");
            DropForeignKey("dbo.VehicleTypeUse", "Uses_Id", "dbo.Uses");
            DropForeignKey("dbo.VehicleTypeUse", "VehicleType_Id", "dbo.VehicleTypes");
            DropForeignKey("dbo.Vehicles", "UseId", "dbo.Uses");
            DropForeignKey("dbo.Vehicles", "BodyworkId", "dbo.Bodyworks");
            DropForeignKey("dbo.Accessories", "VehicleId", "dbo.Vehicles");
            DropForeignKey("dbo.Accessories", "AccessoryTypeId", "dbo.AccessoryTypes");
            DropIndex("dbo.VehicleCoverage", new[] { "Coverages_Id" });
            DropIndex("dbo.VehicleCoverage", new[] { "Vehicles_Id" });
            DropIndex("dbo.CreditCardCompanies", new[] { "Company_Id" });
            DropIndex("dbo.CreditCardCompanies", new[] { "CreditCard_Id" });
            DropIndex("dbo.EmployeeCoverage", new[] { "Coverages_Id" });
            DropIndex("dbo.EmployeeCoverage", new[] { "Employees_Id" });
            DropIndex("dbo.IntegralCoverage", new[] { "Coverages_Id" });
            DropIndex("dbo.IntegralCoverage", new[] { "Integrals_Id" });
            DropIndex("dbo.CoveragesPacksCoverages", new[] { "CoverageId" });
            DropIndex("dbo.CoveragesPacksCoverages", new[] { "CoveragesPackId" });
            DropIndex("dbo.BodyworkVehicleType", new[] { "VehicleTypes_Id" });
            DropIndex("dbo.BodyworkVehicleType", new[] { "Bodyworks_Id" });
            DropIndex("dbo.VehicleTypeUse", new[] { "Uses_Id" });
            DropIndex("dbo.VehicleTypeUse", new[] { "VehicleType_Id" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Districts", new[] { "ProvinceId" });
            DropIndex("dbo.Localities", new[] { "DistrictId" });
            DropIndex("dbo.Employees", new[] { "EndorseId" });
            DropIndex("dbo.Employees", new[] { "PolicyId" });
            DropIndex("dbo.ProducerCodes", new[] { "ProducerId" });
            DropIndex("dbo.ProducerCodes", new[] { "CompanyId" });
            DropIndex("dbo.Casualties", new[] { "CasualtyTypeId" });
            DropIndex("dbo.Casualties", new[] { "PolicyId" });
            DropIndex("dbo.Policies", new[] { "RiskId" });
            DropIndex("dbo.Policies", new[] { "CollectorId" });
            DropIndex("dbo.Policies", new[] { "ProducerId" });
            DropIndex("dbo.Policies", new[] { "ClientId" });
            DropIndex("dbo.Liquidations", new[] { "CompanyId" });
            DropIndex("dbo.FeeSelections", new[] { "LiquidationId" });
            DropIndex("dbo.Fees", new[] { "EndorseId" });
            DropIndex("dbo.Fees", new[] { "FeeSelectionId" });
            DropIndex("dbo.Fees", new[] { "PolicyId" });
            DropIndex("dbo.CashAccounts", new[] { "FeeId" });
            DropIndex("dbo.CashAccounts", new[] { "ProducerId" });
            DropIndex("dbo.CashAccounts", new[] { "LedgerAccountId" });
            DropIndex("dbo.CashAccounts", new[] { "AssetId" });
            DropIndex("dbo.AttachedFiles", new[] { "CashAccountId" });
            DropIndex("dbo.AttachedFiles", new[] { "CasualtyId" });
            DropIndex("dbo.AttachedFiles", new[] { "PolicyId" });
            DropIndex("dbo.AttachedFiles", new[] { "EndorseId" });
            DropIndex("dbo.Endorses", new[] { "ClientId" });
            DropIndex("dbo.Endorses", new[] { "PolicyId" });
            DropIndex("dbo.Integrals", new[] { "EndorseId" });
            DropIndex("dbo.Integrals", new[] { "PolicyId" });
            DropIndex("dbo.Integrals", new[] { "Id" });
            DropIndex("dbo.Addresses", new[] { "ClientId" });
            DropIndex("dbo.Addresses", new[] { "LocalityId" });
            DropIndex("dbo.Cheques", new[] { "BankId" });
            DropIndex("dbo.ClientCreditCards", new[] { "BankId" });
            DropIndex("dbo.ClientCreditCards", new[] { "CreditCardId" });
            DropIndex("dbo.ClientCreditCards", new[] { "ClientId" });
            DropIndex("dbo.Contacts", new[] { "CompanyId" });
            DropIndex("dbo.Risks", new[] { "CompanyId" });
            DropIndex("dbo.CoveragesPacks", new[] { "RiskId" });
            DropIndex("dbo.Coverages", new[] { "RiskId" });
            DropIndex("dbo.VehicleModels", new[] { "VehicleTypeId" });
            DropIndex("dbo.VehicleModels", new[] { "BrandId" });
            DropIndex("dbo.Vehicles", new[] { "BodyworkId" });
            DropIndex("dbo.Vehicles", new[] { "UseId" });
            DropIndex("dbo.Vehicles", new[] { "VehicleModelId" });
            DropIndex("dbo.Vehicles", new[] { "EndorseId" });
            DropIndex("dbo.Vehicles", new[] { "PolicyId" });
            DropIndex("dbo.Accessories", new[] { "VehicleId" });
            DropIndex("dbo.Accessories", new[] { "AccessoryTypeId" });
            DropTable("dbo.VehicleCoverage");
            DropTable("dbo.CreditCardCompanies");
            DropTable("dbo.EmployeeCoverage");
            DropTable("dbo.IntegralCoverage");
            DropTable("dbo.CoveragesPacksCoverages");
            DropTable("dbo.BodyworkVehicleType");
            DropTable("dbo.VehicleTypeUse");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Provinces");
            DropTable("dbo.Districts");
            DropTable("dbo.Localities");
            DropTable("dbo.LedgerAccounts");
            DropTable("dbo.Employees");
            DropTable("dbo.ProducerCodes");
            DropTable("dbo.Producers");
            DropTable("dbo.CasualtyTypes");
            DropTable("dbo.Casualties");
            DropTable("dbo.Policies");
            DropTable("dbo.Liquidations");
            DropTable("dbo.FeeSelections");
            DropTable("dbo.Fees");
            DropTable("dbo.Assets");
            DropTable("dbo.CashAccounts");
            DropTable("dbo.AttachedFiles");
            DropTable("dbo.Endorses");
            DropTable("dbo.Integrals");
            DropTable("dbo.Addresses");
            DropTable("dbo.Clients");
            DropTable("dbo.Cheques");
            DropTable("dbo.Banks");
            DropTable("dbo.ClientCreditCards");
            DropTable("dbo.CreditCards");
            DropTable("dbo.Contacts");
            DropTable("dbo.Companies");
            DropTable("dbo.Risks");
            DropTable("dbo.CoveragesPacks");
            DropTable("dbo.Coverages");
            DropTable("dbo.Brands");
            DropTable("dbo.VehicleModels");
            DropTable("dbo.Uses");
            DropTable("dbo.VehicleTypes");
            DropTable("dbo.Bodyworks");
            DropTable("dbo.Vehicles");
            DropTable("dbo.AccessoryTypes");
            DropTable("dbo.Accessories");
        }
    }
}
