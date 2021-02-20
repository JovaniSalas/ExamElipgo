namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InicialTwoDbContextv2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Articles", "descuento", c => c.Decimal(nullable: false, precision: 18, scale: 2));            
        }
        
        public override void Down()
        {            
            DropColumn("dbo.Articles", "descuento");
        }
    }
}
