using log4net.ObjectRenderer;
using System;

namespace Framework.Logger.Trace
{
    /// <summary>
    /// Classe permettant de tracer les exceptions.
    /// </summary>
    public class ExceptionRenderer : IObjectRenderer
    {

        /// <summary>
        /// Méthode permettant le rendu des exception.
        /// </summary>
        /// <param name="rendererMap">Objet RenderMap.</param>
        /// <param name="obj">Objet source du rendu.</param>
        /// <param name="writer">Flux cible du rendu.</param>
        public void RenderObject(RendererMap rendererMap, object obj, System.IO.TextWriter writer)
        {
            // Vérification des paramètres.
            if (rendererMap == null)
                throw new ArgumentNullException("rendererMap");
            if (obj == null)
                throw new ArgumentNullException("obj");
            if (writer == null)
                throw new ArgumentNullException("writer");

            try
            {
                RenderException((Exception)obj, writer);

                if (System.Web.HttpContext.Current != null)
                {
                    RenderHttpContext(System.Web.HttpContext.Current, writer);
                }
            }
            catch (Exception ex)
            {
                writer.WriteLine("Une erreur est survenue pendant le Render d'une exception: " + ex.ToString());
            }
        }

        /// <summary>
        /// Méthode permettant le rendu de l'execption dans le flux.
        /// </summary>
        /// <param name="exception">Exception à rendre.</param>
        /// <param name="writer">Flux.</param>
        private static void RenderException(Exception exception, System.IO.TextWriter writer)
        {
            writer.WriteLine(exception.ToString());
        }

        /// <summary>
        /// Méthode permettant le rendu du context HTTP dans le flux.
        /// </summary>
        /// <param name="httpContext">Context http à rendre.</param>
        /// <param name="writer">Flux.</param>
        private static void RenderHttpContext(System.Web.HttpContext httpContext, System.IO.TextWriter writer)
        {
            writer.WriteLine();
            writer.WriteLine("--------------------------------------------------------------");
            writer.WriteLine(" HTTP Context");
            writer.WriteLine("--------------------------------------------------------------");

            // User Logged.
            string monUser = httpContext.User != null && !string.IsNullOrEmpty(httpContext.User.Identity.Name) ? httpContext.User.Identity.Name : "-";
            writer.WriteLine(string.Format("User Logged: {0}", monUser));
            writer.WriteLine(string.Format("User Host Adress: {0}", httpContext.Request.UserHostAddress));
            writer.WriteLine(string.Format("Application Path: {0}", httpContext.Request.ApplicationPath));
            writer.WriteLine(string.Format("Page Path: {0}", httpContext.Request.Path));
            writer.WriteLine(string.Format("Query String: {0}", httpContext.Request.QueryString));
            writer.WriteLine(string.Format("Session ID: {0}", httpContext.Session != null ? httpContext.Session.SessionID : "Erreur !"));
            writer.WriteLine(string.Format("User Agent: {0}", httpContext.Request.UserAgent));
            writer.WriteLine(string.Format("HTTP Methode: {0}", httpContext.Request.HttpMethod));

            // Headers.
            string mesHeaders = null;
            if (httpContext.Request.Headers != null)
            {
                foreach (string key in httpContext.Request.Headers.AllKeys)
                {
                    if (string.IsNullOrEmpty(mesHeaders))
                    {
                        mesHeaders = string.Format("{0}={1}{2}", key, httpContext.Request.Headers[key], Environment.NewLine);
                    }
                    else
                    {
                        mesHeaders = string.Format("{0}         {1}={2}{3}", mesHeaders, key, httpContext.Request.Headers[key], Environment.NewLine);
                    }
                }
            }
            else
            {
                mesHeaders = "none";
            }

            writer.WriteLine(string.Format("Headers: {0}", mesHeaders));
            writer.WriteLine(string.Format("Content Type: {0}", httpContext.Request.ContentType));
            writer.WriteLine(string.Format("Total Bytes: {0}", httpContext.Request.TotalBytes));

            // Cookies - Utilisation de la Clé du cookie.
            string mesCookiesString = null;
            if (httpContext.Request.Cookies != null)
            {
                foreach (string maKey in httpContext.Request.Cookies.AllKeys)
                {
                    if (string.IsNullOrEmpty(mesCookiesString))
                    {
                        mesCookiesString = string.Format("{0}={1}{2}", maKey, httpContext.Request.Cookies[maKey].Value, Environment.NewLine);
                    }
                    else
                    {
                        mesCookiesString = string.Format("{0}         {1}={2}{3}", mesCookiesString, maKey, httpContext.Request.Cookies[maKey].Value, Environment.NewLine);
                    }
                }
            }
            else
            {
                mesCookiesString = "none";
            }

            writer.WriteLine(string.Format("Cookies: {0}", mesCookiesString));
            writer.WriteLine("--------------------------------------------------------------");
            writer.WriteLine();
        }

    }

}
