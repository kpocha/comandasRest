using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class CommonController : Controller
    {
        /// <summary>
        /// Método útil para setear un par de tempData comunmente usado para enviar mensajes a la vista luego de un redirect.
        /// </summary>
        /// <param name="msg">Mensaje</param>
        /// <param name="type">tipo, usar:  success, error</param>
        public void SetTempData(string msg, string type = "success")
        {
            TempData["message"] = msg;
            TempData["type"] = type;
        }
        public void MessageSuccess(string msg)
        {
            SetTempData(msg);
        }
        public void MessageError(string errorMessage, Exception e = null)
        {
#if DEBUG
            SetTempData(e != null ? e.Message : errorMessage, "error");
#else
            SetTempData(errorMessage,"error");
#endif
        }
    }
}