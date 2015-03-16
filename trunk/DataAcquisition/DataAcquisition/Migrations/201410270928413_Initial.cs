namespace DataAcquisition.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DriverType = c.Int(nullable: false),
                        DriverPort = c.Int(nullable: false),
                        ServiceInfoId = c.Int(),
                        IsActive = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(),
                        UpdatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 100),
                        UpdatedBy = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceInfoes", t => t.ServiceInfoId)
                .Index(t => t.ServiceInfoId);
            
            CreateTable(
                "dbo.ServiceInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServerIP = c.String(nullable: false, maxLength: 50),
                        VDKServicePort = c.Int(nullable: false),
                        OPCServicePort = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(),
                        UpdatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 100),
                        UpdatedBy = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ports", "ServiceInfoId", "dbo.ServiceInfoes");
            DropIndex("dbo.Ports", new[] { "ServiceInfoId" });
            DropTable("dbo.ServiceInfoes");
            DropTable("dbo.Ports");
        }
    }
}
