using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
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

        public ActionResult ListComandaDay()
        {
            return View();
        }

        public string datosEstadisticos()
        {
            var comandasToday = e.ListComandaDay();
            JavaScriptSerializer js = new JavaScriptSerializer();
            //string jsonResult = js.Serialize(comandasToday);
            // var jsonResult = Json(comandasToday, JsonRequestBehavior.AllowGet);
            var list = JsonConvert.SerializeObject(comandasToday,
             Formatting.None,
             new JsonSerializerSettings()
             {
                 ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
             });
            return list;
        }
    }
}