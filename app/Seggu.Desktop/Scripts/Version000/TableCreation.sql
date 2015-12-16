-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'CoveragesPacks'
CREATE TABLE CoveragesPacks (
    Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    Name TEXT  NOT NULL,
    RiskId INTEGER  NOT NULL
);


-- Creating table 'AccessoryTypes'
CREATE TABLE AccessoryTypes (
    Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    Name TEXT  NOT NULL
);


-- Creating table 'CreditCards'
CREATE TABLE CreditCards (
    Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    Name TEXT  NOT NULL
);


-- Creating table 'Banks'
CREATE TABLE Banks (
    Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    Number TEXT  NOT NULL,
    Name TEXT  NOT NULL
);


-- Creating table 'LedgerAccounts'
CREATE TABLE LedgerAccounts (
    Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    Name TEXT  NOT NULL
);



-- Creating table 'VehicleTypes'
CREATE TABLE VehicleTypes (
    Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    Name TEXT  NOT NULL
);


-- Creating table 'Bodyworks'
CREATE TABLE Bodyworks (
    Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    Name TEXT  NOT NULL
);


-- Creating table 'Uses'
CREATE TABLE Uses (
    Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    Name TEXT  NOT NULL
);


-- Creating table 'Provinces'
CREATE TABLE Provinces (
    Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    Name TEXT  NOT NULL
);


-- Creating table 'Brands'
CREATE TABLE Brands (
    Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    Name TEXT  NOT NULL
);


-- Creating table 'VehicleModels'
CREATE TABLE VehicleModels (
    Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    Name TEXT  NOT NULL,
    Origin INTEGER  NOT NULL,
    BrandId INTEGER  NOT NULL,
    VehicleTypeId INTEGER  NOT NULL,
    foreign key(BrandId) references Brands(Id),
    foreign key(VehicleTypeId) references VehicleTypes(Id)
);


-- Creating table 'Producers'
CREATE TABLE Producers (
    Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    Name TEXT  NOT NULL,
    RegistrationNumber TEXT  NOT NULL,
    IsCollector INTEGER  NOT NULL
);


-- Creating table 'Clients'
CREATE TABLE Clients (
    Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    FirstName TEXT  NOT NULL,
    LastName TEXT  NOT NULL,
    CellPhone TEXT  NULL,
    Mail TEXT  NULL,
    Document TEXT  NOT NULL,
    BirthDate TEXT  NULL,
    Cuit TEXT  NULL,
    IngresosBrutos TEXT  NULL,
    CollectionTimeRange TEXT  NULL,
    BankingCode TEXT  NULL,
    Notes TEXT  NULL,
    IsSmoker INTEGER  NOT NULL,
    Sex INTEGER  NOT NULL,
    IVA INTEGER  NOT NULL,
    MaritalStatus INTEGER  NOT NULL,
    DocumentType INTEGER  NOT NULL,
    Occupation TEXT  NULL
);


-- Creating table 'Companies'
CREATE TABLE Companies (
    Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    Name TEXT  NOT NULL,
    Phone TEXT  NOT NULL,
    Notes TEXT  NULL,
    Active INTEGER  NOT NULL,
    EMail TEXT  NOT NULL,
    CUIT TEXT  NULL,
    LiqDay1 INTEGER  NULL,
    LiqDay2 INTEGER  NULL,
    PaymentDay1 INTEGER  NOT NULL,
    PaymentDay2 INTEGER  NOT NULL
);


-- Creating table 'Assets'
CREATE TABLE Assets (
    Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    Name TEXT  NOT NULL,
    Amount NUMERIC  NOT NULL
);


-- Creating table 'Liquidations'
CREATE TABLE Liquidations (
    Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    Date TEXT  NOT NULL,
    Total NUMERIC  NOT NULL,
    ReceptionDate TEXT  NULL,
    Registered INTEGER  NOT NULL,
    Notes TEXT  NULL,
    CompanyId INTEGER  NOT NULL,
    foreign key(CompanyId) references Companies(Id)
);


-- Creating table 'Contacts'
CREATE TABLE Contacts (
    Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    FirstName TEXT  NOT NULL,
    LastName TEXT  NOT NULL,
    Phone TEXT  NOT NULL,
    Mail TEXT  NULL,
    Notes TEXT  NULL,
    CompanyId INTEGER  NULL,
    Bussiness TEXT  NULL,
    foreign key(CompanyId) references Companies(Id)
);


-- Creating table 'CasualtyTypes'
CREATE TABLE CasualtyTypes (
    Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    Name TEXT  NOT NULL
);


-- Creating table 'Districts'
CREATE TABLE Districts (
    Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    Name TEXT  NOT NULL,
    ProvinceId INTEGER  NOT NULL,
    FOREIGN KEY(ProvinceId) REFERENCES Provinces(Id)
);


-- Creating table 'Localities'
CREATE TABLE Localities (
    Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    Name TEXT  NOT NULL,
    DistrictId INTEGER  NOT NULL,
    foreign key(DistrictId) references Districts(Id)
);


-- Creating table 'Risks'
CREATE TABLE Risks (
    Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    Name TEXT  NOT NULL,
    RiskType INTEGER  NOT NULL,
    CompanyId INTEGER  NOT NULL,
    foreign key(CompanyId) references Companies(Id)
);


-- Creating table 'Policies'
CREATE TABLE Policies (
    Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    PreviousNumber TEXT  NULL,
    ClientId INTEGER  NOT NULL,
    Period INTEGER  NOT NULL,
    StartDate TEXT  NOT NULL,
    EndDate TEXT  NOT NULL,
    RequestDate TEXT  NOT NULL,
    ReceptionDate TEXT  NULL,
    EmissionDate TEXT  NULL,
    Prima NUMERIC  NOT NULL,
    Premium NUMERIC  NOT NULL,
    Surcharge NUMERIC  NOT NULL,
    Bonus NUMERIC  NULL,
    Value NUMERIC  NOT NULL,
    Notes TEXT  NULL,
    Number TEXT  NULL,
    IsRenovated INTEGER  NOT NULL,
    IsAnnulled INTEGER  NOT NULL,
    AnnulationDate TEXT  NULL,
    IsRemoved INTEGER  NOT NULL,
    ProducerId INTEGER  NOT NULL,
    CollectorId INTEGER  NULL,
    RiskId INTEGER  NOT NULL,
    foreign key(ClientId) references Clients(Id),
    foreign key(ProducerId) references Producers(Id),
    foreign key(CollectorId) references Producers(Id),
    foreign key(RiskId) references Risks(Id)
);


-- Creating table 'Endorses'
CREATE TABLE Endorses (
    Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    EndorseType INTEGER  NOT NULL,
    Number TEXT  NULL,
    Cause TEXT  NOT NULL,
    PolicyId INTEGER  NOT NULL,
    ClientId INTEGER  NULL,
    StartDate TEXT  NOT NULL,
    EndDate TEXT  NOT NULL,
    RequestDate TEXT  NOT NULL,
    ReceptionDate TEXT  NULL,
    EmissionDate TEXT  NULL,
    Prima NUMERIC  NULL,
    Premium NUMERIC  NULL,
    Surcharge NUMERIC  NULL,
    Value NUMERIC  NULL,
    Notes TEXT  NULL,
    IsAnnulled INTEGER  NULL,
    AnnulationDate TEXT  NULL,
    IsRemoved INTEGER  NULL,
    foreign key(PolicyId) references Policies(Id),
    foreign key(ClientId) references Clients(Id)
);


-- Creating table 'Integrals'
CREATE TABLE Integrals (
    Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    PolicyId INTEGER  NULL,
    EndorseId INTEGER  NULL,
    foreign key(PolicyId) references Policies(Id),
    foreign key(EndorseId) references Endorses(Id)
);


-- Creating table 'Addresses'
CREATE TABLE Addresses (
    Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    Street TEXT  NOT NULL,
    Phone TEXT  NULL,
    Number TEXT  NOT NULL,
    Floor TEXT  NULL,
    Appartment TEXT  NULL,
    LocalityId INTEGER  NULL,
    PostalCode TEXT  NULL,
    AddressType INTEGER  NOT NULL,
    ClientId INTEGER  NULL,
    Integral_Id INTEGER  NULL,
    foreign key(LocalityId) references Localities(Id),
    foreign key(ClientId) references Clients(Id),
    foreign key(Integral_Id) references Integrals(Id)
);


-- Creating table 'Vehicles'
CREATE TABLE Vehicles (
    Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    Plate TEXT  NOT NULL,
    Engine TEXT  NOT NULL,
    Year TEXT  NOT NULL,
    Chassis TEXT  NOT NULL,
    PolicyId INTEGER  NOT NULL,
    EndorseId INTEGER  NULL,
    VehicleModelId INTEGER  NOT NULL,
    UseId INTEGER  NOT NULL,
    BodyworkId INTEGER  NOT NULL,
    IsRemoved INTEGER  NULL,
    foreign key(PolicyId) references Policies(Id),
    foreign key(EndorseId) references Endorses(Id),
    foreign key(UseId) references Uses(Id),
    foreign key(BodyworkId) references Bodyworks(Id),
    foreign key(VehicleModelId) references VehicleModels(Id)
);


-- Creating table 'Casualties'
CREATE TABLE Casualties (
    Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    PolicyId INTEGER  NOT NULL,
    Number INTEGER  NOT NULL,
    CasualtyTypeId INTEGER  NOT NULL,
    OurCharge INTEGER  NOT NULL,
    OccurredDate TEXT  NOT NULL,
    ReceiveDate TEXT  NOT NULL,
    PoliceReportDate TEXT  NULL,
    EstimatedCompensation NUMERIC  NOT NULL,
    DefinedCompensation NUMERIC  NOT NULL,
    Notes TEXT  NULL,
    foreign key(PolicyId) references Policies(Id),
    foreign key(CasualtyTypeId) references CasualtyTypes(Id)
);


-- Creating table 'Accessories'
CREATE TABLE Accessories (
    Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    Name TEXT  NOT NULL,
    Stamp TEXT  NOT NULL,
    ExpirationDate TEXT  NOT NULL,
    AccessoryTypeId INTEGER  NOT NULL,
    Value NUMERIC  NOT NULL,
    VehicleId INTEGER  NOT NULL,
    foreign key(VehicleId) references Vehicles(Id)
);


-- Creating table 'ClientCreditCards'
CREATE TABLE ClientCreditCards (
    Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    Number bigint  NULL,
    ClientId INTEGER  NOT NULL,
    CreditCardId INTEGER  NOT NULL,
    BankId INTEGER  NOT NULL,
    ExpirationDate TEXT  NULL,
    foreign key(BankId) references Banks(Id)
);


-- Creating table 'ProducerCodes'
CREATE TABLE ProducerCodes (
    ProducerId INTEGER  NOT NULL,
    CompanyId INTEGER  NOT NULL,
    Code TEXT  NOT NULL,
    PRIMARY KEY (ProducerId, CompanyId),
    foreign key(ProducerId) references Producers(Id),
    foreign key(CompanyId) references Companies(Id)
);


-- Creating table 'Cheques'
CREATE TABLE Cheques (
    Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    Number TEXT  NOT NULL,
    BankId INTEGER  NOT NULL,
    Value NUMERIC  NOT NULL,
    Date TEXT  NOT NULL,
    foreign key(BankId) references Banks(Id)
);


-- Creating table 'FeeSelections'
CREATE TABLE FeeSelections (
    Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    Name TEXT  NOT NULL,
    Total NUMERIC  NOT NULL,
    LiquidationId INTEGER  NOT NULL,
    Notes TEXT  NULL,
    foreign key(LiquidationId) references Liquidations(Id)
);


-- Creating table 'Fees'
CREATE TABLE Fees (
    Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    PolicyId INTEGER  NOT NULL,
    ExpirationDate TEXT  NOT NULL,
    Number INTEGER  NOT NULL,
    Value NUMERIC  NOT NULL,
    Balance NUMERIC  NOT NULL,
    CompanyPayment NUMERIC  NOT NULL,
    Annulated INTEGER  NOT NULL,
    FeeSelectionId INTEGER  NULL,
    State INTEGER  NOT NULL,
    EndorseId INTEGER  NULL,
    RegisteredLiqDate TEXT  NULL,
    foreign key(PolicyId) references Policies(Id),
    foreign key(FeeSelectionId) references FeeSelections(Id),
    foreign key(EndorseId) references Endorses(Id)
);


-- Creating table 'CashAccounts'
CREATE TABLE CashAccounts (
    Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    AssetId INTEGER  NOT NULL,
    LedgerAccountId INTEGER  NOT NULL,
    Date TEXT  NOT NULL,
    Description TEXT  NOT NULL,
    Amount NUMERIC  NOT NULL,
    Balance NUMERIC  NOT NULL,
    ProducerId INTEGER  NOT NULL,
    FeeId INTEGER  NULL,
    ReceiptNumber TEXT  NULL,
    foreign key(AssetId) references Assets(Id),
    foreign key(LedgerAccountId) references LedgerAccounts(Id),
    foreign key(ProducerId) references Producers(Id),
    foreign key(FeeId) references Fees(Id)
);


-- Creating table 'Coverages'
CREATE TABLE Coverages (
    Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    Name TEXT  NOT NULL,
    Description TEXT  NOT NULL,
    RiskId INTEGER  NOT NULL,
    foreign key(RiskId) references Risks(Id)
);


-- Creating table 'Employees'
CREATE TABLE Employees (
    Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    PolicyId INTEGER  NOT NULL,
    EndorseId INTEGER  NULL,
    FirstName TEXT  NOT NULL,
    LastName TEXT  NOT NULL,
    BirthDate TEXT  NOT NULL,
    DNI TEXT  NOT NULL,
    CUIT TEXT  NOT NULL,
    IsRemoved INTEGER  NULL,
    InsuranceAmount NUMERIC  NOT NULL,
    foreign key(PolicyId) references Policies(Id),
    foreign key(EndorseId) references Endorses(Id)
);


-- Creating table 'AttachedFiles'
CREATE TABLE AttachedFiles (
    Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    EndorseId INTEGER  NULL,
    FilePath TEXT  NOT NULL,
    PolicyId INTEGER  NULL,
    CasualtyId INTEGER  NULL,
    CashAccountId INTEGER  NULL,
    foreign key(EndorseId) references Endorses(Id),
    foreign key(PolicyId) references Policies(Id),
    foreign key(CasualtyId) references Casualties(Id),
    foreign key(CashAccountId) references CashAccounts(Id)
);


-- Creating table 'CreditCardCompany'
CREATE TABLE CreditCardCompany (
    CreditCards_Id INTEGER  NOT NULL,
    Companies_Id INTEGER  NOT NULL,
    PRIMARY KEY (CreditCards_Id, Companies_Id),
    foreign key(CreditCards_Id) references CreditCards(Id),
    foreign key(Companies_Id) references Companies(Id)
);


-- Creating table 'VehicleTypeUse'
CREATE TABLE VehicleTypeUse (
    VehicleType_Id INTEGER  NOT NULL,
    Uses_Id INTEGER  NOT NULL,
    PRIMARY KEY (VehicleType_Id, Uses_Id),
    foreign key(VehicleType_Id) references VehicleTypes(Id),
    foreign key(Uses_Id) references Uses(Id)
);


-- Creating table 'BodyworkVehicleType'
CREATE TABLE BodyworkVehicleType (
    Bodyworks_Id INTEGER  NOT NULL,
    VehicleTypes_Id INTEGER  NOT NULL,
    PRIMARY KEY (Bodyworks_Id, VehicleTypes_Id),
    foreign key(Bodyworks_Id) references Bodyworks(Id),
    foreign key(VehicleTypes_Id) references VehicleTypes(Id)
);


-- Creating table 'IntegralCoverage'
CREATE TABLE IntegralCoverage (
    Integrals_Id INTEGER  NOT NULL,
    Coverages_Id INTEGER  NOT NULL,
    PRIMARY KEY (Integrals_Id, Coverages_Id),
    foreign key(Integrals_Id) references Integrals(Id),
    foreign key(Coverages_Id) references Coverages(Id)
);


-- Creating table 'EmployeeCoverage'
CREATE TABLE EmployeeCoverage (
    Employees_Id INTEGER  NOT NULL,
    Coverages_Id INTEGER  NOT NULL,
    PRIMARY KEY (Employees_Id, Coverages_Id),
    foreign key(Employees_Id) references Employees(Id),
    foreign key(Coverages_Id) references Coverages(Id)
);


-- Creating table 'VehicleCoverage'
CREATE TABLE VehicleCoverage (
    Vehicles_Id INTEGER  NOT NULL,
    Coverages_Id INTEGER  NOT NULL,
    PRIMARY KEY (Vehicles_Id, Coverages_Id),
    foreign key(Vehicles_Id) references Vehicles(Id),
    foreign key(Coverages_Id) references Coverages(Id)
);


-- Creating table 'CoveragesPackCoverages'
CREATE TABLE CoveragesPackCoverages (
    CoveragesPack_Id INTEGER  NOT NULL,
    Coverage_Id INTEGER  NOT NULL,
    PRIMARY KEY (CoveragesPack_Id, Coverage_Id),
    foreign key(CoveragesPack_Id) references CoveragesPacks(Id),
    foreign key(Coverage_Id) references Coverages(Id)
);

-- Creating table 'ImplementedVersions'
CREATE TABLE ImplementedVersions (
    Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    Name TEXT NOT NULL
);
