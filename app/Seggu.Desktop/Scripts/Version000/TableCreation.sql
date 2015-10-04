-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'CoveragesPacks'
CREATE TABLE CoveragesPacks (
    Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    Name text  NOT NULL,
    RiskId int  NOT NULL
);


-- Creating table 'AccessoryTypes'
CREATE TABLE AccessoryTypes (
    Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    Name nvarchar(50)  NOT NULL
);


-- Creating table 'CreditCards'
CREATE TABLE CreditCards (
    Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    Name nvarchar(15)  NOT NULL
);


-- Creating table 'Banks'
CREATE TABLE Banks (
    Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    Number text  NOT NULL,
    Name nvarchar(15)  NOT NULL
);


-- Creating table 'LedgerAccounts'
CREATE TABLE LedgerAccounts (
    Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    Name text  NOT NULL
);



-- Creating table 'VehicleTypes'
CREATE TABLE VehicleTypes (
    Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    Name text  NOT NULL
);


-- Creating table 'Bodyworks'
CREATE TABLE Bodyworks (
    Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    Name text  NOT NULL
);


-- Creating table 'Uses'
CREATE TABLE Uses (
    Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    Name text  NOT NULL
);


-- Creating table 'Provinces'
CREATE TABLE Provinces (
    Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    Name nvarchar(40)  NOT NULL
);


-- Creating table 'Brands'
CREATE TABLE Brands (
    Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    Name text  NOT NULL
);


-- Creating table 'VehicleModels'
CREATE TABLE VehicleModels (
    Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    Name text  NOT NULL,
    Origin smallint  NOT NULL,
    BrandId int  NOT NULL,
    VehicleTypeId int  NOT NULL,
    foreign key(BrandId) references Brands(Id),
    foreign key(VehicleTypeId) references VehicleTypes(Id)
);


-- Creating table 'Producers'
CREATE TABLE Producers (
    Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    Name text  NOT NULL,
    RegistrationNumber text  NOT NULL,
    IsCollector bit  NOT NULL
);


-- Creating table 'Clients'
CREATE TABLE Clients (
    Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    FirstName text  NOT NULL,
    LastName text  NOT NULL,
    CellPhone text  NULL,
    Mail text  NULL,
    Document text  NOT NULL,
    BirthDate datetime  NULL,
    Cuit text  NULL,
    IngresosBrutos text  NULL,
    CollectionTimeRange text  NULL,
    BankingCode text  NULL,
    Notes text  NULL,
    IsSmoker bit  NOT NULL,
    Sex int  NOT NULL,
    IVA int  NOT NULL,
    MaritalStatus int  NOT NULL,
    DocumentType int  NOT NULL,
    Occupation text  NULL
);


-- Creating table 'Companies'
CREATE TABLE Companies (
    Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    Name text  NOT NULL,
    Phone text  NOT NULL,
    Notes text  NULL,
    Active bit  NOT NULL,
    EMail text  NOT NULL,
    CUIT text  NULL,
    LiqDay1 smallint  NULL,
    LiqDay2 smallint  NULL,
    PaymentDay1 smallint  NOT NULL,
    PaymentDay2 smallint  NOT NULL
);


-- Creating table 'Assets'
CREATE TABLE Assets (
    Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    Name text  NOT NULL,
    Amount decimal(18,0)  NOT NULL
);


-- Creating table 'Liquidations'
CREATE TABLE Liquidations (
    Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    Date datetime  NOT NULL,
    Total decimal(18,0)  NOT NULL,
    ReceptionDate datetime  NULL,
    Registered bit  NOT NULL,
    Notes text  NULL,
    CompanyId int  NOT NULL,
    foreign key(CompanyId) references Companies(Id)
);


-- Creating table 'Contacts'
CREATE TABLE Contacts (
    Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    FirstName text  NOT NULL,
    LastName text  NOT NULL,
    Phone text  NOT NULL,
    Mail text  NULL,
    Notes text  NULL,
    CompanyId int  NULL,
    Bussiness text  NULL,
    foreign key(CompanyId) references Companies(Id)
);


-- Creating table 'CasualtyTypes'
CREATE TABLE CasualtyTypes (
    Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    Name text  NOT NULL
);


-- Creating table 'Districts'
CREATE TABLE Districts (
    Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    Name text  NOT NULL,
    ProvinceId int  NOT NULL,
    FOREIGN KEY(ProvinceId) REFERENCES Provinces(Id)
);


-- Creating table 'Localities'
CREATE TABLE Localities (
    Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    Name nvarchar(50)  NOT NULL,
    DistrictId int  NOT NULL,
    foreign key(DistrictId) references Districts(Id)
);


-- Creating table 'Risks'
CREATE TABLE Risks (
    Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    Name text  NOT NULL,
    RiskType int  NOT NULL,
    CompanyId int  NOT NULL,
    foreign key(CompanyId) references Companies(Id)
);


-- Creating table 'Policies'
CREATE TABLE Policies (
    Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    PreviousNumber text  NULL,
    ClientId int  NOT NULL,
    Period int  NOT NULL,
    StartDate datetime  NOT NULL,
    EndDate datetime  NOT NULL,
    RequestDate datetime  NOT NULL,
    ReceptionDate datetime  NULL,
    EmissionDate datetime  NULL,
    Prima decimal(18,0)  NOT NULL,
    Premium decimal(18,0)  NOT NULL,
    Surcharge decimal(18,0)  NOT NULL,
    Bonus decimal(18,0)  NULL,
    Value decimal(18,0)  NOT NULL,
    Notes text  NULL,
    Number text  NULL,
    IsRenovated bit  NOT NULL,
    IsAnnulled bit  NOT NULL,
    AnnulationDate datetime  NULL,
    IsRemoved bit  NOT NULL,
    ProducerId int  NOT NULL,
    CollectorId int  NULL,
    RiskId int  NOT NULL,
    foreign key(ClientId) references Clients(Id),
    foreign key(ProducerId) references Producers(Id),
    foreign key(CollectorId) references Producers(Id),
    foreign key(RiskId) references Risks(Id)
);


-- Creating table 'Endorses'
CREATE TABLE Endorses (
    Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    EndorseType smallint  NOT NULL,
    Number text  NULL,
    Cause text  NOT NULL,
    PolicyId int  NOT NULL,
    ClientId int  NULL,
    StartDate datetime  NOT NULL,
    EndDate datetime  NOT NULL,
    RequestDate datetime  NOT NULL,
    ReceptionDate datetime  NULL,
    EmissionDate datetime  NULL,
    Prima decimal(18,0)  NULL,
    Premium decimal(18,0)  NULL,
    Surcharge decimal(18,0)  NULL,
    Value decimal(18,0)  NULL,
    Notes text  NULL,
    IsAnnulled bit  NULL,
    AnnulationDate datetime  NULL,
    IsRemoved bit  NULL,
    foreign key(PolicyId) references Policies(Id),
    foreign key(ClientId) references Clients(Id)
);


-- Creating table 'Integrals'
CREATE TABLE Integrals (
    Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    PolicyId int  NULL,
    EndorseId int  NULL,
    foreign key(PolicyId) references Policies(Id),
    foreign key(EndorseId) references Endorses(Id)
);


-- Creating table 'Addresses'
CREATE TABLE Addresses (
    Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    Street text  NOT NULL,
    Phone text  NULL,
    Number text  NOT NULL,
    Floor text  NULL,
    Appartment text  NULL,
    LocalityId int  NULL,
    PostalCode text  NULL,
    AddressType int  NOT NULL,
    ClientId int  NULL,
    Integral_Id int  NULL,
    foreign key(LocalityId) references Localities(Id),
    foreign key(ClientId) references Clients(Id),
    foreign key(Integral_Id) references Integrals(Id)
);


-- Creating table 'Vehicles'
CREATE TABLE Vehicles (
    Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    Plate text  NOT NULL,
    Engine text  NOT NULL,
    Year text  NOT NULL,
    Chassis text  NOT NULL,
    PolicyId int  NOT NULL,
    EndorseId int  NULL,
    VehicleModelId int  NOT NULL,
    UseId int  NOT NULL,
    BodyworkId int  NOT NULL,
    IsRemoved bit  NULL,
    foreign key(PolicyId) references Policies(Id),
    foreign key(EndorseId) references Endorses(Id),
    foreign key(UseId) references Uses(Id),
    foreign key(BodyworkId) references Bodyworks(Id),
    foreign key(VehicleModelId) references VehicleModels(Id)
);


-- Creating table 'Casualties'
CREATE TABLE Casualties (
    Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    PolicyId int  NOT NULL,
    Number smallint  NOT NULL,
    CasualtyTypeId int  NOT NULL,
    OurCharge bit  NOT NULL,
    OccurredDate datetime  NOT NULL,
    ReceiveDate datetime  NOT NULL,
    PoliceReportDate datetime  NULL,
    EstimatedCompensation decimal(18,0)  NOT NULL,
    DefinedCompensation decimal(18,0)  NOT NULL,
    Notes text  NULL,
    foreign key(PolicyId) references Policies(Id),
    foreign key(CasualtyTypeId) references CasualtyTypes(Id)
);


-- Creating table 'Accessories'
CREATE TABLE Accessories (
    Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    Name text  NOT NULL,
    Stamp nvarchar(50)  NOT NULL,
    ExpirationDate datetime  NOT NULL,
    AccessoryTypeId int  NOT NULL,
    Value decimal(18,0)  NOT NULL,
    VehicleId int  NOT NULL,
    foreign key(VehicleId) references Vehicles(Id)
);


-- Creating table 'ClientCreditCards'
CREATE TABLE ClientCreditCards (
    Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    Number bigint  NULL,
    ClientId int  NOT NULL,
    CreditCardId int  NOT NULL,
    BankId int  NOT NULL,
    ExpirationDate datetime  NULL,
    foreign key(BankId) references Banks(Id)
);


-- Creating table 'ProducerCodes'
CREATE TABLE ProducerCodes (
    ProducerId INTEGER  NOT NULL,
    CompanyId INTEGER  NOT NULL,
    Code text  NOT NULL,
    PRIMARY KEY (ProducerId, CompanyId),
    foreign key(ProducerId) references Producers(Id),
    foreign key(CompanyId) references Companies(Id)
);


-- Creating table 'Cheques'
CREATE TABLE Cheques (
    Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    Number text  NOT NULL,
    BankId int  NOT NULL,
    Value decimal(18,0)  NOT NULL,
    Date datetime  NOT NULL,
    foreign key(BankId) references Banks(Id)
);


-- Creating table 'FeeSelections'
CREATE TABLE FeeSelections (
    Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    Name text  NOT NULL,
    Total decimal(18,0)  NOT NULL,
    LiquidationId int  NOT NULL,
    Notes text  NULL,
    foreign key(LiquidationId) references Liquidations(Id)
);


-- Creating table 'Fees'
CREATE TABLE Fees (
    Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    PolicyId int  NOT NULL,
    ExpirationDate datetime  NOT NULL,
    Number smallint  NOT NULL,
    Value decimal(18,0)  NOT NULL,
    Balance decimal(18,0)  NOT NULL,
    CompanyPayment decimal(18,0)  NOT NULL,
    Annulated bit  NOT NULL,
    FeeSelectionId int  NULL,
    State smallint  NOT NULL,
    EndorseId int  NULL,
    RegisteredLiqDate text  NULL,
    foreign key(PolicyId) references Policies(Id),
    foreign key(FeeSelectionId) references FeeSelections(Id),
    foreign key(EndorseId) references Endorses(Id)
);


-- Creating table 'CashAccounts'
CREATE TABLE CashAccounts (
    Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    AssetId int  NOT NULL,
    LedgerAccountId int  NOT NULL,
    Date datetime  NOT NULL,
    Description text  NOT NULL,
    Amount decimal(18,0)  NOT NULL,
    Balance decimal(18,0)  NOT NULL,
    ProducerId int  NOT NULL,
    FeeId int  NULL,
    ReceiptNumber text  NULL,
    foreign key(AssetId) references Assets(Id),
    foreign key(LedgerAccountId) references LedgerAccounts(Id),
    foreign key(ProducerId) references Producers(Id),
    foreign key(FeeId) references Fees(Id)
);


-- Creating table 'Coverages'
CREATE TABLE Coverages (
    Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    Name text  NOT NULL,
    Description text  NOT NULL,
    RiskId int  NOT NULL,
    foreign key(RiskId) references Risks(Id)
);


-- Creating table 'Employees'
CREATE TABLE Employees (
    Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    PolicyId int  NOT NULL,
    EndorseId int  NULL,
    FirstName text  NOT NULL,
    LastName text  NOT NULL,
    BirthDate datetime  NOT NULL,
    DNI text  NOT NULL,
    CUIT text  NOT NULL,
    IsRemoved bit  NULL,
    InsuranceAmount decimal(18,0)  NOT NULL,
    foreign key(PolicyId) references Policies(Id),
    foreign key(EndorseId) references Endorses(Id)
);


-- Creating table 'AttachedFiles'
CREATE TABLE AttachedFiles (
    Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    EndorseId int  NULL,
    FilePath text  NOT NULL,
    PolicyId int  NULL,
    CasualtyId int  NULL,
    CashAccountId int  NULL,
    foreign key(EndorseId) references Endorses(Id),
    foreign key(PolicyId) references Policies(Id),
    foreign key(CasualtyId) references Casualties(Id),
    foreign key(CashAccountId) references CashAccounts(Id)
);


-- Creating table 'CreditCardCompany'
CREATE TABLE CreditCardCompany (
    CreditCards_Id int  NOT NULL,
    Companies_Id int  NOT NULL,
    PRIMARY KEY (CreditCards_Id, Companies_Id),
    foreign key(CreditCards_Id) references CreditCards(Id),
    foreign key(Companies_Id) references Companies(Id)
);


-- Creating table 'VehicleTypeUse'
CREATE TABLE VehicleTypeUse (
    VehicleType_Id int  NOT NULL,
    Uses_Id int  NOT NULL,
    PRIMARY KEY (VehicleType_Id, Uses_Id),
    foreign key(VehicleType_Id) references VehicleTypes(Id),
    foreign key(Uses_Id) references Uses(Id)
);


-- Creating table 'BodyworkVehicleType'
CREATE TABLE BodyworkVehicleType (
    Bodyworks_Id int  NOT NULL,
    VehicleTypes_Id int  NOT NULL,
    PRIMARY KEY (Bodyworks_Id, VehicleTypes_Id),
    foreign key(Bodyworks_Id) references Bodyworks(Id),
    foreign key(VehicleTypes_Id) references VehicleTypes(Id)
);


-- Creating table 'IntegralCoverage'
CREATE TABLE IntegralCoverage (
    Integrals_Id int  NOT NULL,
    Coverages_Id int  NOT NULL,
    PRIMARY KEY (Integrals_Id, Coverages_Id),
    foreign key(Integrals_Id) references Integrals(Id),
    foreign key(Coverages_Id) references Coverages(Id)
);


-- Creating table 'EmployeeCoverage'
CREATE TABLE EmployeeCoverage (
    Employees_Id int  NOT NULL,
    Coverages_Id int  NOT NULL,
    PRIMARY KEY (Employees_Id, Coverages_Id),
    foreign key(Employees_Id) references Employees(Id),
    foreign key(Coverages_Id) references Coverages(Id)
);


-- Creating table 'VehicleCoverage'
CREATE TABLE VehicleCoverage (
    Vehicles_Id int  NOT NULL,
    Coverages_Id int  NOT NULL,
    PRIMARY KEY (Vehicles_Id, Coverages_Id),
    foreign key(Vehicles_Id) references Vehicles(Id),
    foreign key(Coverages_Id) references Coverages(Id)
);


-- Creating table 'CoveragesPackCoverages'
CREATE TABLE CoveragesPackCoverages (
    CoveragesPack_Id int  NOT NULL,
    Coverage_Id int  NOT NULL,
    PRIMARY KEY (CoveragesPack_Id, Coverage_Id),
    foreign key(CoveragesPack_Id) references CoveragesPacks(Id),
    foreign key(Coverage_Id) references Coverages(Id)
);

-- Creating table 'ImplementedVersions'
CREATE TABLE ImplementedVersions (
    Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    Name TEXT NOT NULL
);
