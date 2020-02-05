namespace YachmanAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Completecode : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO [dbo].[Harbors] ([City], [Latitude], [Longitude], [Country]) VALUES (N'Stockholm', 59.33459, 18.06324, N'Sweden'); INSERT INTO[dbo].[Harbors]([City], [Latitude], [Longitude], [Country]) VALUES(N'Œwinoujœcie', 53.91053, 14.24712, N'Poland'); INSERT INTO[dbo].[Harbors]([City], [Latitude], [Longitude], [Country]) VALUES(N'Ponta Delgada', 37.74283, -25.68059, N'Portugal'); INSERT INTO[dbo].[Harbors] ([City], [Latitude], [Longitude], [Country]) VALUES(N'London', 51.50986, -0.118092, N'UK')");
        }
        
        public override void Down()
        {
        }
    }
}
