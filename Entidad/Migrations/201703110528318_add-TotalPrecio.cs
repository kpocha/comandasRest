namespace Entidad.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTotalPrecio : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comandas", "precioTotal", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Comandas", "precioTotal");
        }
    }
}
