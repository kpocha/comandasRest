using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web
{
    public static class HTMLHelperExtensions
    {
        public static string isActive(this HtmlHelper html, string controller = null, string action = null)
        {
            string activeClass = "active"; // change here if you another name to activate sidebar items
            // detect current app state
            string actualAction = (string) html.ViewContext.RouteData.Values["action"];
            string actualController = (string) html.ViewContext.RouteData.Values["controller"];

            if (String.IsNullOrEmpty(controller))
                controller = actualController;

            if (String.IsNullOrEmpty(action))
                action = actualAction;

            return (controller == actualController && action == actualAction) ? activeClass : String.Empty;
        }

        public static string isActive(this HtmlHelper html, string[] controllers = null, string[] actions = null)
        {
            string activeController = string.Empty;
            string activeAction = string.Empty;
            string activeClass = "active"; // change here if you another name to activate sidebar items
            // detect current app state
            string actualAction = (string)html.ViewContext.RouteData.Values["action"];
            string actualController = (string)html.ViewContext.RouteData.Values["controller"];

            if (controllers != null && controllers.Length > 0)
                activeController = controllers.Contains(actualController) ? actualController : string.Empty;

            if (actions != null && actions.Length > 0)
                activeAction = actions.Contains(actualAction) ? actualAction : string.Empty;

            return (activeController == actualController && activeAction == actualAction) ? activeClass : String.Empty;
        }

        public static string isActive(this HtmlHelper html, string controller = null, string[] actions = null)
        {
            string activeAction = string.Empty;
            string activeClass = "active"; // change here if you another name to activate sidebar items
            // detect current app state
            string actualAction = (string)html.ViewContext.RouteData.Values["action"];
            string actualController = (string)html.ViewContext.RouteData.Values["controller"];

            if (String.IsNullOrEmpty(controller))
                controller = actualController;

            if (actions != null && actions.Length > 0)
                activeAction = actions.Contains(actualAction) ? actualAction : string.Empty;

            return (controller == actualController && activeAction == actualAction) ? activeClass : String.Empty;
        }
    }
}
