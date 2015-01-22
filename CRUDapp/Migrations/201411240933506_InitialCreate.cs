namespace CRUDapp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Restaurants",
                c => new
                    {
                        RestaurantsId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DueDate = c.String(),
                        Adress = c.String(),
                    })
                .PrimaryKey(t => t.RestaurantsId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Restaurants");
        }
    }
}
