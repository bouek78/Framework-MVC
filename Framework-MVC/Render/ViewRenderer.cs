using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Framework_MVC.Render
{
    public sealed class ViewRenderer
    {
        private ControllerContext _controllerContext;

        public ViewRenderer(ControllerContext context)
        {
            _controllerContext = context;
        }

        private ViewRenderer() { }

        public string RenderView (string viewPath, object model)
        {
            return RenderViewToStringInternal(viewPath, model, false);
        }

        /// <summary>
        /// Rendu d'une vue sous la forme de chaine de caractère 
        /// </summary>
        /// <param name="viewPath"></param>
        /// <param name="model"></param>
        /// <param name="isPartial"></param>
        /// <returns></returns>
        private string RenderViewToStringInternal(string viewPath, object model, bool isPartial)
        {
            ViewEngineResult viewEngineResult = null;

            viewEngineResult = (isPartial ?
                  ViewEngines.Engines.FindPartialView(_controllerContext, viewPath) :
                  ViewEngines.Engines.FindView(_controllerContext, viewPath, null));
                       
            if (viewEngineResult == null)
            {
                throw new FileNotFoundException("Impossible de trouver la vue demandée");
            }



            throw new NotImplementedException();


        }
    }
}
