using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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