using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Entidad;
using Web.Entidad.Models;

namespace Servicio
{
    public class Estadisticas
    {
        IUnitOfWork unitOfWork;

        public Estadisticas() : this(new UnitOfWork()) { }

        public Estadisticas(IUnitOfWork uow)
        {
            unitOfWork = uow;
        }
        /// <summary>
        /// Encuentra las comandas que se hicieron en el dia de la fecha.
        /// </summary>
        /// <returns>Lista de comandas</returns>
        public List<Comandas> ListComandaDay()
        {
            DateTime today = new DateTime();
            var comandasToday = unitOfWork.ComandasRepository.Filter(a => a.fecha.Day == today.Day);

            return comandasToday.ToList();
        }
        /// <summary>
        /// Lista las comandas que se hicieron en corriente mes.
        /// </summary>
        /// <returns>Lista de comandas</returns>
        public List<Comandas> ListComandasMonth()
        {
            DateTime today = new DateTime();
            var comandasToday = unitOfWork.ComandasRepository.Filter(a => a.fecha.Month == today.Month);
            
            return comandasToday.ToList();
        }
        
    }
}
