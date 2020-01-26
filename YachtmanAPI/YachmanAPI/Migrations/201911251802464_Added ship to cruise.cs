namespace YachmanAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addedshiptocruise : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cruises", "ShipId", c => c.Int(nullable: false));
            CreateIndex("dbo.Cruises", "ShipId");
            AddForeignKey("dbo.Cruises", "ShipId", "dbo.Ships", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cruises", "ShipId", "dbo.Ships");
            DropIndex("dbo.Cruises", new[] { "ShipId" });
            DropColumn("dbo.Cruises", "ShipId");
        }
    }
}
