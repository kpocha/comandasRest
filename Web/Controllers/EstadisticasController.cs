using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Entidad;
using Web.Entidad.Models;
using Web.Helpers;
using Estadisticas = Servicio.Estadisticas;

namespace Web.Controllers
{
    [AuthLog(Roles = "Admin")]
    public class EstadisticasController : CommonController
    {
        Estadisticas e;
        IUnitOfWork unitOfWork;

        public EstadisticasController() : this(new UnitOfWork()) { }

        public EstadisticasController(IUnitOfWork uow)
        {
            e = new Estadisticas();
            unitOfWork = uow;
        }
        
        public String ListComandaDay()
        {
            DateTime today = new DateTime();
            var comandasToday = e.ListComandaDay();
            //List<Categorias> comandasToday = unitOfWork.CategoriasRepository.All().ToList();
            //example how to use helper json
            JsonHelper helper = new JsonHelper();
            String jsonResult = helper.ConvertObjectToJSon(comandasToday);
            return jsonResult;
        }

        
    }
}