namespace YachmanAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCapacitytoShipsCruiseMembersDBinitialization : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CruiseMembers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CruiseId = c.Int(),
                        UserId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cruises", t => t.CruiseId)
                .ForeignKey("dbo.AppUsers", t => t.UserId)
                .Index(t => t.CruiseId)
                .Index(t => t.UserId);
            
            AddColumn("dbo.Ships", "Capacity", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CruiseMembers", "UserId", "dbo.AppUsers");
            DropForeignKey("dbo.CruiseMembers", "CruiseId", "dbo.Cruises");
            DropIndex("dbo.CruiseMembers", new[] { "UserId" });
            DropIndex("dbo.CruiseMembers", new[] { "CruiseId" });
            DropColumn("dbo.Ships", "Capacity");
            DropTable("dbo.CruiseMembers");
        }
    }
}
