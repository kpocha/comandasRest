namespace Entidad.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
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
                        comandaId = c.Int(nullable: false, identity: true),
                        userId = c.Int(nullable: false),
                        fecha = c.DateTime(nullable: false),
                        user_userId = c.Int(nullable: false),
                        user_userName = c.String(),
                    })
                .PrimaryKey(t => t.comandaId);
            
            CreateTable(
                "dbo.DetalleComandas",
                c => new
                    {
                        detalleComandaId = c.Int(nullable: false, identity: true),
                        comandaId = c.String(),
                        cantidad = c.Int(nullable: false),
                        comanda_comandaId = c.Int(),
                        producto_productosId = c.Int(),
                    })
                .PrimaryKey(t => t.detalleComandaId)
                .ForeignKey("dbo.Comandas", t => t.comanda_comandaId)
                .ForeignKey("dbo.Productos", t => t.producto_productosId)
                .Index(t => t.comanda_comandaId)
                .Index(t => t.producto_productosId);
            
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
            DropForeignKey("dbo.DetalleComandas", "producto_productosId", "dbo.Productos");
            DropForeignKey("dbo.Productos", "categoriaId", "dbo.Categorias");
            DropForeignKey("dbo.DetalleComandas", "comanda_comandaId", "dbo.Comandas");
            DropIndex("dbo.Productos", new[] { "categoriaId" });
            DropIndex("dbo.DetalleComandas", new[] { "producto_productosId" });
            DropIndex("dbo.DetalleComandas", new[] { "comanda_comandaId" });
            DropTable("dbo.Productos");
            DropTable("dbo.DetalleComandas");
            DropTable("dbo.Comandas");
            DropTable("dbo.Categorias");
        }
    }
}
