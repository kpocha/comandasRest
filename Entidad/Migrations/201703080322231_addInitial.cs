namespace Entidad.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addInitial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        categoriaId = c.Int(nullable: false, identity: true),
                        detalle = c.String(),
                    })
                .PrimaryKey(t => t.categoriaId);
            
            CreateTable(
                "dbo.Comandas",
                c => new
                    {
                        comandasId = c.Int(nullable: false, identity: true),
                        fecha = c.DateTime(nullable: false),
                        nombreUsuario = c.String(),
                    })
                .PrimaryKey(t => t.comandasId);
            
            CreateTable(
                "dbo.DetalleComandas",
                c => new
                    {
                        detalleComandasId = c.Int(nullable: false, identity: true),
                        nombreComida = c.String(),
                        cantidad = c.Int(nullable: false),
                        precio = c.Single(nullable: false),
                        comandasId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.detalleComandasId)
                .ForeignKey("dbo.Comandas", t => t.comandasId)
                .Index(t => t.comandasId);
            
            CreateTable(
                "dbo.Productos",
                c => new
                    {
                        productosId = c.Int(nullable: false, identity: true),
                        detalle = c.String(),
                        precio = c.Single(nullable: false),
                        categoriaId = c.Int(nullable: false),
                        hay = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.productosId)
                .ForeignKey("dbo.Categorias", t => t.categoriaId)
                .Index(t => t.categoriaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Productos", "categoriaId", "dbo.Categorias");
            DropForeignKey("dbo.DetalleComandas", "comandasId", "dbo.Comandas");
            DropIndex("dbo.Productos", new[] { "categoriaId" });
            DropIndex("dbo.DetalleComandas", new[] { "comandasId" });
            DropTable("dbo.Productos");
            DropTable("dbo.DetalleComandas");
            DropTable("dbo.Comandas");
            DropTable("dbo.Categorias");
        }
    }
}
