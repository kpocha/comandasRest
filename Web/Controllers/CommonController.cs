using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class CommonController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();

        /// <summary>
        /// Método útil para setear un par de tempData comunmente usado para enviar mensajes a la vista luego de un redirect.
        /// </summary>
        /// <param name="msg">Mensaje</param>
        /// <param name="type">tipo, usar:  success, error</param>
        ///     
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

        public bool isAdminUser()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                var s = UserManager.GetRoles(user.GetUserId());
                if (s[0].ToString() == "Admin")
                {
                    return true;
                }
            }
            return false;
        }
        public bool isMozoUser()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                var s = UserManager.GetRoles(user.GetUserId());
                if (s[0].ToString() == "Mozo")
                {
                    return true;
                }                    
            }
            return false;
        }
    }
}