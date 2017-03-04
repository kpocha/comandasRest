using Web.Entidad.Repository.Interface;
using Web.Entidad.Models;

namespace Web.Entidad
{
    public interface IUnitOfWork
	{
		IRepository<Productos> ProductosRepository {get;}
		IRepository<Comandas> ComandasRepository {get;}
		IRepository<DetalleComandas> DetalleComandasRepository {get;}
		IRepository<Categorias> CategoriasRepository {get;}
				int Save();
	}
}