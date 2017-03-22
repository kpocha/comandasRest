using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Web.Entidad.Models;

namespace Web.Entidad
{
    public class WebContext : DbContext
    {
        public WebContext() : base("DefaultConnection")
        {
            Database.SetInitializer<WebContext>(new WebInitializer());
            //Configuration.LazyLoadingEnabled = false;
            //Configuration.ProxyCreationEnabled = false;
        }


        //Tablas
        public DbSet<Productos> Productos { get; set; }
        public DbSet<Comandas> Comandas { get; set; }
        public DbSet<DetalleComandas> DetalleComandas { get; set; }
        public DbSet<Categorias> Categorias { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Convierte tipo de dato del archivo
            //modelBuilder.Entity<Archivo>()
            //.Property(e => e.contenido)
            //.HasColumnName("contenido")
            //.HasColumnType("image");

            modelBuilder.Entity<Comandas>().Ignore(a => a.timeAgo);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

        }
    }
}
