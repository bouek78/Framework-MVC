using Framework.ILogger.Contracts;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;


namespace Framework_MVC.Filter
{
    public class LogFilterAttribute : ActionFilterAttribute
    {
        #region Property

        /// <summary>
        /// Logger
        /// </summary>
        public static ITrace Logger { get; private set; }        

        #endregion

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext == null) throw new ArgumentNullException("filterContext est null dans OnActionExecuting");

            // TODO : Niveau du log en variable ?
            // Log Info VERB + URL  
            Logger.LogInfo(String.Format("{0} : {1}", filterContext.RequestContext.HttpContext.Request.HttpMethod, filterContext.RequestContext.HttpContext.Request.Url.AbsoluteUri));

            // Log les clés paramètres/valeur
            StringBuilder sb = new StringBuilder();
            foreach (var item in filterContext.ActionParameters)
            {
                sb.AppendFormat("{0} : {1}", item.Key, item.Value);
            }

            if (sb.Length == 0)
            {
                sb.Append("pas de paramètre");
            }

            // Log Info Controller / Action
            Logger.LogInfo(String.Format("Entrée dans controller[{0}] et action[{1}] avec {2}",
                                        filterContext.ActionDescriptor.ControllerDescriptor.ControllerName,
                                        filterContext.ActionDescriptor.ActionName
                                      )
                        );

            base.OnActionExecuting(filterContext);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (filterContext == null) throw new ArgumentNullException("filterContext est null dans OnActionExecuting");

            base.OnActionExecuted(filterContext);
        }
    }
}
