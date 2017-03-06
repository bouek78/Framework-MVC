using System.Configuration;

namespace Framework.Logger.Trace.Configuration
{
        /// <summary>
        /// Définit une collection de wrappers de trace.
        /// </summary>
        public class TraceElementCollection : ConfigurationElementCollection
        {
            /// <summary>
            /// En cas de substitution dans une classe dérivée, crée <see cref="T:System.Configuration.ConfigurationElement" />.
            /// </summary>
            /// <returns>
            /// Nouveau <see cref="T:System.Configuration.ConfigurationElement" />.
            /// </returns>
            protected override System.Configuration.ConfigurationElement CreateNewElement()
            {
                return new TraceElement();
            }

            /// <summary>
            /// Obtient la clé d'élément pour un élément de configuration spécifié en cas de substitution dans une classe dérivée.
            /// </summary>
            /// <param name="element"><see cref="T:System.Configuration.ConfigurationElement" /> pour lequel retourner la clé.</param>
            /// <returns>
            ///   <see cref="T:System.Object" /> qui agit comme clé pour le <see cref="T:System.Configuration.ConfigurationElement" /> spécifié.
            /// </returns>
            protected override object GetElementKey(System.Configuration.ConfigurationElement element)
            {
                return ((TraceElement)element).Name;
            }

            /// <summary>
            /// Collection de wrappers.
            /// </summary>
            public new TraceElement this[string name]
            {
                get { return (TraceElement)this.BaseGet(name); }
            }

        }

    }

