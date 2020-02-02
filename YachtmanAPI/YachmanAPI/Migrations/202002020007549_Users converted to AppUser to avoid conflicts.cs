namespace YachmanAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UsersconvertedtoAppUsertoavoidconflicts : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Users", newName: "AppUsers");
            AddColumn("dbo.AppUsers", "Email", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AppUsers", "Email");
            RenameTable(name: "dbo.AppUsers", newName: "Users");
        }
    }
}
