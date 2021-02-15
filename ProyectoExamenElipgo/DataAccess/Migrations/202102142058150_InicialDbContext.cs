namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InicialDbContext : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Articles",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        description = c.String(),
                        price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        total_in_shelf = c.Int(nullable: false),
                        total_in_vault = c.Int(nullable: false),
                        store_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Stores", t => t.store_id)
                .Index(t => t.store_id);
            
            CreateTable(
                "dbo.Stores",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        address = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Articles", "store_id", "dbo.Stores");
            DropIndex("dbo.Articles", new[] { "store_id" });
            DropTable("dbo.Stores");
            DropTable("dbo.Articles");
        }
    }
}
