using System.Configuration;

namespace Framework.Logger.Trace.Configuration
{
    /// <summary>
    /// Définit le gestionnaire de configuration pour les traces.
    /// </summary>
    /// <remarks>La section doit se nommer "Logger.Trace".</remarks>
    public class TraceConfiguration : ConfigurationSection
    {
        #region "Attributs"

        /// <summary>
        /// Instance singleton de la configuration.
        /// </summary>

        private static TraceConfiguration _current;
        #endregion

        #region "Constructeur"

        /// <summary>
        /// Constructeur.
        /// </summary>

        private TraceConfiguration()
        {
        }

        #endregion

        #region "Propriétés"

        /// <summary>
        /// Obtient le nom du wrapper de trace par défaut.
        /// </summary>
        [ConfigurationProperty("default", IsRequired = true)]
        public string DefaultWrapper
        {
            get { return this["default"].ToString(); }
        }

        /// <summary>
        /// Obtient la collection de wrappers définis.
        /// </summary>
        [ConfigurationProperty("", IsDefaultCollection = true)]
        [ConfigurationCollection(typeof(TraceElement))]
        public TraceElementCollection Wrappers
        {
            get { return (TraceElementCollection)this[""]; }
        }

        /// <summary>
        /// Obtient la configuration courante.
        /// </summary>
        public static TraceConfiguration Current
        {
            get
            {
                if (_current == null)
                {
                    _current = (TraceConfiguration)ConfigurationManager.GetSection("Logger.Trace");
                }

                return _current;
            }
        }

        #endregion

    }
}
