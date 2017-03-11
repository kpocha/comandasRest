using System;
using Web.Entidad.Repository;
using Web.Entidad.Models;
using Web.Entidad.Repository.Interface;

namespace Web.Entidad
{
    public class UnitOfWork: IUnitOfWork, IDisposable
	{
		private WebContext context = new WebContext();
						private Repository<Productos> productosRepository;
		public IRepository<Productos> ProductosRepository
		{
			get
			{
				if (this.productosRepository == null)
				{
					this.productosRepository = new Repository<Productos>(context);
				}
				return productosRepository;
			}
		}
						private Repository<Comandas> comandasRepository;
		public IRepository<Comandas> ComandasRepository
		{
			get
			{
				if (this.comandasRepository == null)
				{
					this.comandasRepository = new Repository<Comandas>(context);
				}
				return comandasRepository;
			}
		}
						private Repository<DetalleComandas> detalleComandasRepository;
		public IRepository<DetalleComandas> DetalleComandasRepository
		{
			get
			{
				if (this.detalleComandasRepository == null)
				{
					this.detalleComandasRepository = new Repository<DetalleComandas>(context);
				}
				return detalleComandasRepository;
			}
		}
						private Repository<Categorias> categoriasRepository;
		public IRepository<Categorias> CategoriasRepository
		{
			get
			{
				if (this.categoriasRepository == null)
				{
					this.categoriasRepository = new Repository<Categorias>(context);
				}
				return categoriasRepository;
			}
		}
		
        public int Save()
		{
			return context.SaveChanges();
		}

		private bool disposed = false;

		protected virtual void Dispose(bool disposing)
		{
			if (!this.disposed)
			{
				if (disposing)
				{
					context.Dispose();
				}
			}
			this.disposed = true;
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

	}
}
