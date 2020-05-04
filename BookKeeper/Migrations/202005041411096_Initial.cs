namespace BookKeeper.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StreetId = c.Int(nullable: false),
                        LocationId = c.Int(nullable: false),
                        Account = c.Long(nullable: false),
                        AccountCreationDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        AccountType = c.Int(nullable: false),
                        IsEmpty = c.Boolean(nullable: false),
                        IsArchive = c.Boolean(nullable: false),
                        IsEmptyAgain = c.Boolean(nullable: false),
                        IsNew = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        LastSaveDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Locations", t => t.LocationId, cascadeDelete: true)
                .Index(t => t.LocationId);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StreetId = c.Int(nullable: false),
                        HouseNumber = c.String(),
                        BuildingCorpus = c.String(),
                        ApartmentNumber = c.String(),
                        CreatedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        LastSaveDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Streets", t => t.StreetId, cascadeDelete: true)
                .Index(t => t.StreetId);
            
            CreateTable(
                "dbo.Streets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DistrictId = c.Int(nullable: false),
                        StreetName = c.String(),
                        CreatedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        LastSaveDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Districts", t => t.DistrictId, cascadeDelete: true)
                .Index(t => t.DistrictId);
            
            CreateTable(
                "dbo.Districts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.Int(nullable: false),
                        Name = c.String(),
                        CreatedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        LastSaveDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Rates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsDefault = c.Boolean(nullable: false),
                        IsArchive = c.Boolean(nullable: false),
                        StartDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        EndDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Description = c.String(),
                        CreatedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        LastSaveDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        IsDeleted = c.Boolean(nullable: false),
                        StreetEntity_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Streets", t => t.StreetEntity_Id)
                .Index(t => t.StreetEntity_Id);
            
            CreateTable(
                "dbo.RateDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LocationRefId = c.Int(nullable: false),
                        StreetId = c.Int(nullable: false),
                        HouseNumber = c.String(),
                        BuildingNumber = c.String(),
                        CreatedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        LastSaveDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        IsDeleted = c.Boolean(nullable: false),
                        RateEntity_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Locations", t => t.LocationRefId, cascadeDelete: true)
                .ForeignKey("dbo.Rates", t => t.RateEntity_Id)
                .Index(t => t.LocationRefId)
                .Index(t => t.RateEntity_Id);
            
            CreateTable(
                "dbo.PaymentDocuments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AccountId = c.Int(nullable: false),
                        Accrued = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Received = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PaymentDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        CreatedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        LastSaveDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.AccountId, cascadeDelete: true)
                .Index(t => t.AccountId);
            
            CreateTable(
                "dbo.Discounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AccountId = c.Int(nullable: false),
                        Type = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        EndDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Percent = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(),
                        IsArchive = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        LastSaveDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        IsDeleted = c.Boolean(nullable: false),
                        PaymentDocumentEntity_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.AccountId, cascadeDelete: true)
                .ForeignKey("dbo.PaymentDocuments", t => t.PaymentDocumentEntity_Id)
                .Index(t => t.AccountId)
                .Index(t => t.PaymentDocumentEntity_Id);
            
            CreateTable(
                "dbo.Occupants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DiscountId = c.Int(nullable: false),
                        Type = c.Int(nullable: false),
                        AccountId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        LastSaveDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Discounts", t => t.DiscountId, cascadeDelete: true)
                .Index(t => t.DiscountId);
            
            CreateTable(
                "dbo.DiscountDescriptions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        CreatedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        LastSaveDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DiscountPercents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Percent = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreatedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        LastSaveDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Discounts", "PaymentDocumentEntity_Id", "dbo.PaymentDocuments");
            DropForeignKey("dbo.Occupants", "DiscountId", "dbo.Discounts");
            DropForeignKey("dbo.Discounts", "AccountId", "dbo.Accounts");
            DropForeignKey("dbo.PaymentDocuments", "AccountId", "dbo.Accounts");
            DropForeignKey("dbo.Accounts", "LocationId", "dbo.Locations");
            DropForeignKey("dbo.Rates", "StreetEntity_Id", "dbo.Streets");
            DropForeignKey("dbo.RateDetails", "RateEntity_Id", "dbo.Rates");
            DropForeignKey("dbo.RateDetails", "LocationRefId", "dbo.Locations");
            DropForeignKey("dbo.Locations", "StreetId", "dbo.Streets");
            DropForeignKey("dbo.Streets", "DistrictId", "dbo.Districts");
            DropIndex("dbo.Occupants", new[] { "DiscountId" });
            DropIndex("dbo.Discounts", new[] { "PaymentDocumentEntity_Id" });
            DropIndex("dbo.Discounts", new[] { "AccountId" });
            DropIndex("dbo.PaymentDocuments", new[] { "AccountId" });
            DropIndex("dbo.RateDetails", new[] { "RateEntity_Id" });
            DropIndex("dbo.RateDetails", new[] { "LocationRefId" });
            DropIndex("dbo.Rates", new[] { "StreetEntity_Id" });
            DropIndex("dbo.Streets", new[] { "DistrictId" });
            DropIndex("dbo.Locations", new[] { "StreetId" });
            DropIndex("dbo.Accounts", new[] { "LocationId" });
            DropTable("dbo.DiscountPercents");
            DropTable("dbo.DiscountDescriptions");
            DropTable("dbo.Occupants");
            DropTable("dbo.Discounts");
            DropTable("dbo.PaymentDocuments");
            DropTable("dbo.RateDetails");
            DropTable("dbo.Rates");
            DropTable("dbo.Districts");
            DropTable("dbo.Streets");
            DropTable("dbo.Locations");
            DropTable("dbo.Accounts");
        }
    }
}
