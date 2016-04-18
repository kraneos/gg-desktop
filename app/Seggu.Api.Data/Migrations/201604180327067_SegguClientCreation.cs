namespace Seggu.Api.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SegguClientCreation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SegguClients",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        SegguClientId = c.Guid(nullable: false),
                        CreatedBy = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Accessories", "SegguClientId", c => c.Guid(nullable: false));
            AddColumn("dbo.AccessoryTypes", "SegguClientId", c => c.Guid(nullable: false));
            AddColumn("dbo.Vehicles", "SegguClientId", c => c.Guid(nullable: false));
            AddColumn("dbo.Bodyworks", "SegguClientId", c => c.Guid(nullable: false));
            AddColumn("dbo.VehicleTypes", "SegguClientId", c => c.Guid(nullable: false));
            AddColumn("dbo.Uses", "SegguClientId", c => c.Guid(nullable: false));
            AddColumn("dbo.VehicleModels", "SegguClientId", c => c.Guid(nullable: false));
            AddColumn("dbo.Brands", "SegguClientId", c => c.Guid(nullable: false));
            AddColumn("dbo.Coverages", "SegguClientId", c => c.Guid(nullable: false));
            AddColumn("dbo.CoveragesPacks", "SegguClientId", c => c.Guid(nullable: false));
            AddColumn("dbo.Risks", "SegguClientId", c => c.Guid(nullable: false));
            AddColumn("dbo.Companies", "SegguClientId", c => c.Guid(nullable: false));
            AddColumn("dbo.Contacts", "SegguClientId", c => c.Guid(nullable: false));
            AddColumn("dbo.CreditCards", "SegguClientId", c => c.Guid(nullable: false));
            AddColumn("dbo.ClientCreditCards", "SegguClientId", c => c.Guid(nullable: false));
            AddColumn("dbo.Banks", "SegguClientId", c => c.Guid(nullable: false));
            AddColumn("dbo.Cheques", "SegguClientId", c => c.Guid(nullable: false));
            AddColumn("dbo.Clients", "SegguClientId", c => c.Guid(nullable: false));
            AddColumn("dbo.Addresses", "SegguClientId", c => c.Guid(nullable: false));
            AddColumn("dbo.Integrals", "SegguClientId", c => c.Guid(nullable: false));
            AddColumn("dbo.Endorses", "SegguClientId", c => c.Guid(nullable: false));
            AddColumn("dbo.AttachedFiles", "SegguClientId", c => c.Guid(nullable: false));
            AddColumn("dbo.CashAccounts", "SegguClientId", c => c.Guid(nullable: false));
            AddColumn("dbo.Assets", "SegguClientId", c => c.Guid(nullable: false));
            AddColumn("dbo.Fees", "SegguClientId", c => c.Guid(nullable: false));
            AddColumn("dbo.FeeSelections", "SegguClientId", c => c.Guid(nullable: false));
            AddColumn("dbo.Liquidations", "SegguClientId", c => c.Guid(nullable: false));
            AddColumn("dbo.Policies", "SegguClientId", c => c.Guid(nullable: false));
            AddColumn("dbo.Casualties", "SegguClientId", c => c.Guid(nullable: false));
            AddColumn("dbo.CasualtyTypes", "SegguClientId", c => c.Guid(nullable: false));
            AddColumn("dbo.Producers", "SegguClientId", c => c.Guid(nullable: false));
            AddColumn("dbo.ProducerCodes", "SegguClientId", c => c.Guid(nullable: false));
            AddColumn("dbo.Employees", "SegguClientId", c => c.Guid(nullable: false));
            AddColumn("dbo.LedgerAccounts", "SegguClientId", c => c.Guid(nullable: false));
            AddColumn("dbo.Localities", "SegguClientId", c => c.Guid(nullable: false));
            AddColumn("dbo.Districts", "SegguClientId", c => c.Guid(nullable: false));
            AddColumn("dbo.Provinces", "SegguClientId", c => c.Guid(nullable: false));
            AddColumn("dbo.AspNetUsers", "SegguClientId", c => c.Guid(nullable: false));
            CreateIndex("dbo.AspNetUsers", "SegguClientId");
            AddForeignKey("dbo.AspNetUsers", "SegguClientId", "dbo.SegguClients", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "SegguClientId", "dbo.SegguClients");
            DropIndex("dbo.AspNetUsers", new[] { "SegguClientId" });
            DropColumn("dbo.AspNetUsers", "SegguClientId");
            DropColumn("dbo.Provinces", "SegguClientId");
            DropColumn("dbo.Districts", "SegguClientId");
            DropColumn("dbo.Localities", "SegguClientId");
            DropColumn("dbo.LedgerAccounts", "SegguClientId");
            DropColumn("dbo.Employees", "SegguClientId");
            DropColumn("dbo.ProducerCodes", "SegguClientId");
            DropColumn("dbo.Producers", "SegguClientId");
            DropColumn("dbo.CasualtyTypes", "SegguClientId");
            DropColumn("dbo.Casualties", "SegguClientId");
            DropColumn("dbo.Policies", "SegguClientId");
            DropColumn("dbo.Liquidations", "SegguClientId");
            DropColumn("dbo.FeeSelections", "SegguClientId");
            DropColumn("dbo.Fees", "SegguClientId");
            DropColumn("dbo.Assets", "SegguClientId");
            DropColumn("dbo.CashAccounts", "SegguClientId");
            DropColumn("dbo.AttachedFiles", "SegguClientId");
            DropColumn("dbo.Endorses", "SegguClientId");
            DropColumn("dbo.Integrals", "SegguClientId");
            DropColumn("dbo.Addresses", "SegguClientId");
            DropColumn("dbo.Clients", "SegguClientId");
            DropColumn("dbo.Cheques", "SegguClientId");
            DropColumn("dbo.Banks", "SegguClientId");
            DropColumn("dbo.ClientCreditCards", "SegguClientId");
            DropColumn("dbo.CreditCards", "SegguClientId");
            DropColumn("dbo.Contacts", "SegguClientId");
            DropColumn("dbo.Companies", "SegguClientId");
            DropColumn("dbo.Risks", "SegguClientId");
            DropColumn("dbo.CoveragesPacks", "SegguClientId");
            DropColumn("dbo.Coverages", "SegguClientId");
            DropColumn("dbo.Brands", "SegguClientId");
            DropColumn("dbo.VehicleModels", "SegguClientId");
            DropColumn("dbo.Uses", "SegguClientId");
            DropColumn("dbo.VehicleTypes", "SegguClientId");
            DropColumn("dbo.Bodyworks", "SegguClientId");
            DropColumn("dbo.Vehicles", "SegguClientId");
            DropColumn("dbo.AccessoryTypes", "SegguClientId");
            DropColumn("dbo.Accessories", "SegguClientId");
            DropTable("dbo.SegguClients");
        }
    }
}
