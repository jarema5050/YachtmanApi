namespace YachmanAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Cruisesadded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cruises",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DepartureHarborId = c.Int(),
                        ArrivalHarborId = c.Int(),
                        DepartureDate = c.DateTime(nullable: false),
                        ArrivalDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Harbors", t => t.ArrivalHarborId)
                .ForeignKey("dbo.Harbors", t => t.DepartureHarborId)
                .Index(t => t.DepartureHarborId)
                .Index(t => t.ArrivalHarborId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cruises", "DepartureHarborId", "dbo.Harbors");
            DropForeignKey("dbo.Cruises", "ArrivalHarborId", "dbo.Harbors");
            DropIndex("dbo.Cruises", new[] { "ArrivalHarborId" });
            DropIndex("dbo.Cruises", new[] { "DepartureHarborId" });
            DropTable("dbo.Cruises");
        }
    }
}
