using System.Configuration;
using System.Web;

namespace Framework.Logger.Trace.Configuration
{

    /// <summary>
    /// Définit un élément de configuration d'un wrapper de trace.
    /// </summary>
    public class TraceElement : ConfigurationElement
    {
        #region "Propriétés"

        /// <summary>
        /// Obtient le nom du wrapper de trace.
        /// </summary>
        [ConfigurationProperty("name", IsKey = true, IsRequired = true)]
        public string Name
        {
            get { return this["name"].ToString(); }
        }

        /// <summary>
        /// Obtient le type du wrapper de trace.
        /// </summary>
        [ConfigurationProperty("type", IsRequired = true)]
        public string Type
        {
            get { return this["type"].ToString(); }
        }

        /// <summary>
        /// Obtient le nom du fichier de configuration.
        /// </summary>
        [ConfigurationProperty("FileConfiguration", IsRequired = false)]
        public string ConfigFile
        {
            get
            {
                dynamic monPath = this["FileConfiguration"].ToString();
                if (!string.IsNullOrEmpty(monPath))
                {
                    if (!System.IO.Path.IsPathRooted(monPath) && HttpContext.Current != null)
                    {
                        monPath = HttpContext.Current.Server.MapPath(monPath);
                    }
                }

                return monPath;
            }
        }

        #endregion

    }
}

