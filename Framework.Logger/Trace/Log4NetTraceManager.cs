using Framework.ILogger.Contracts;
using Framework.Logger.Trace.Configuration;
using Framework.Logger.Trace.Implementation;
using System;

namespace Framework.Logger.Trace
{
    /// <summary>
    /// Gestionnaire de trace. C'est le point d'accès central vous permettant d'obtenir une instance de ILogger selon vos besoins.
    /// </summary>
    public class Log4NetTraceManager : ILog4NetTraceManager
    {

        #region "Attributs"

        /// <summary>
        /// Nom du fichier de configuration par défaut.
        /// </summary>

        private const string DEFAUT_CONFIG_FILE = "~/log4net.config";
        /// <summary>
        /// Nom du logger par défaut.
        /// </summary>

        private const string DEFAULT_LOGGER_NAME = "Logger";
        #endregion

        #region "Méthodes publiques"

        /// <summary>
        /// Charge le wrapper de trace.
        /// </summary>
        /// <returns>Un wrapper de trace.</returns>
        /// <remarks>WrapperName peut être nul, auquel cas le wrapper par défaut est utilisé. Si loggerName est nul, "Logger.Trace" est utilisé.</remarks>
        public ITrace GetLogger()
        {
            return GetInternalLogger(null, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        }

        /// <summary>
        /// Charge le wrapper de trace.
        /// </summary>
        /// <param name="loggerName">Nom du logger à utiliser.</param>
        /// <returns>Un wrapper de trace.</returns>
        /// <remarks>WrapperName peut être nul, auquel cas le wrapper par défaut est utilisé. Si loggerName est nul, "Logger.Trace" est utilisé.</remarks>
        public ITrace GetLogger(string loggerName)
        {
            return GetInternalLogger(string.Empty, loggerName);
        }

        /// <summary>
        /// Charge le wrapper de trace.
        /// </summary>
        /// <param name="type">Type du logger à utiliser.</param>
        /// <returns>Un wrapper de trace.</returns>
        /// <remarks>WrapperName peut être nul, auquel cas le wrapper par défaut est utilisé. Si loggerName est nul, "Logger.Trace" est utilisé.</remarks>
        public ITrace GetLogger(Type type)
        {
            return GetInternalLogger(string.Empty, type);
        }

        /// <summary>
        /// Charge le wrapper de trace.
        /// </summary>
        /// <param name="wrapperName">Nom du wrapper à utiliser.</param>
        /// <param name="loggerName">Nom du logger à utiliser.</param>
        /// <returns>Un wrapper de trace.</returns>
        /// <remarks>WrapperName peut être nul, auquel cas le wrapper par défaut est utilisé. Si loggerName est nul, "Logger.Trace" est utilisé.</remarks>
        public ITrace GetLogger(string wrapperName, string loggerName)
        {
            return GetInternalLogger(wrapperName, loggerName);
        }

        /// <summary>
        /// Charge le wrapper de trace.
        /// </summary>
        /// <param name="wrapperName">Nom du wrapper à utiliser.</param>
        /// <param name="type">Type du logger à utiliser.</param>
        /// <returns>Un wrapper de trace.</returns>
        /// <remarks>WrapperName peut être nul, auquel cas le wrapper par défaut est utilisé. Si loggerName est nul, "Logger.Trace" est utilisé.</remarks>
        public ITrace GetLogger(string wrapperName, Type type)
        {
            return GetInternalLogger(wrapperName, type);
        }

        #endregion


        #region "Méthodes privées"          

        /// <summary>
        /// Charge le wrapper de trace.
        /// </summary>
        /// <param name="wrapperName">Nom du wrapper à utiliser.</param>
        /// <param name="loggerName">Nom du logger à utiliser.</param>
        /// <returns>Un wrapper de trace.</returns>
        /// <remarks>WrapperName peut être nul, auquel cas le wrapper par défaut est utilisé. Si loggerName est nul, "Logger.Trace" est utilisé.</remarks>
        private ITrace GetInternalLogger(string wrapperName, string loggerName)
        {
            ITrace result = null;

            try
            {
                // Utilisation du wrapper par défaut si aucun n'est fourni.
                if (string.IsNullOrEmpty(wrapperName))
                {
                    wrapperName = TraceConfiguration.Current.DefaultWrapper;
                }

                // Utilisation d'un logger par défaut si aucun n'est fourni.
                if (string.IsNullOrEmpty(loggerName))
                {
                    loggerName = DEFAULT_LOGGER_NAME;
                }

                // Récupération du FQN du wrapper à utiliser.
                Type traceWrapperType = Type.GetType(TraceConfiguration.Current.Wrappers[wrapperName].Type, true, true);

                // Réccupération du fichier de configuration.
                string configFile = TraceConfiguration.Current.Wrappers[wrapperName].ConfigFile;

                // Si aucun fichier de config n'est spécifié ou utilisé le chemin par défaut.
                if (string.IsNullOrEmpty(configFile))
                    configFile = DEFAUT_CONFIG_FILE;

                // Instanciation du wrapper.
                result = (ITrace)Activator.CreateInstance(traceWrapperType);
                result.Initialise(loggerName, configFile);
            }
            catch (System.Exception ex)
            {
                Type traceWrapperType = typeof(Log4NetTrace);

                // Instanciation du wrapper.
                result = (ITrace)Activator.CreateInstance(traceWrapperType);
                result.Initialise(DEFAULT_LOGGER_NAME, DEFAUT_CONFIG_FILE);
            }

            // Retourne le wrapper configuré.
            return result;
        }

        /// <summary>
        /// Charge le wrapper de trace.
        /// </summary>
        /// <param name="wrapperName">Nom du wrapper à utiliser.</param>
        /// <param name="type">Type du logger à utiliser.</param>
        /// <returns>Un wrapper de trace.</returns>
        /// <remarks>WrapperName peut être nul, auquel cas le wrapper par défaut est utilisé. Si loggerName est nul, "Logger.Trace" est utilisé.</remarks>
        private ITrace GetInternalLogger(string wrapperName, Type type)
        {
            ITrace result = null;

            try
            {
                // Utilisation du wrapper par défaut si aucun n'est fourni.
                if (string.IsNullOrEmpty(wrapperName))
                {
                    wrapperName = TraceConfiguration.Current.DefaultWrapper;
                }

                // Utilisation d'un logger par défaut si aucun n'est fourni.
                if (type == null)
                {
                    type = typeof(Log4NetTraceManager);
                }

                // Récupération du FQN du wrapper à utiliser.
                Type traceWrapperType = Type.GetType(TraceConfiguration.Current.Wrappers[wrapperName].Type, true, true);

                // Réccupération du fichier de configuration.
                string configFile = TraceConfiguration.Current.Wrappers[wrapperName].ConfigFile;

                // Instanciation du wrapper.
                result = (ITrace)Activator.CreateInstance(traceWrapperType);
                result.Initialise(type, configFile);
            }
            catch (System.Exception ex)
            {
                Type traceWrapperType = typeof(Log4NetTrace);

                // Instanciation du wrapper.
                result = (ITrace)Activator.CreateInstance(traceWrapperType);
                result.Initialise(typeof(Log4NetTraceManager), DEFAUT_CONFIG_FILE);
            }

            // Retourne le wrapper configuré.
            return result;
        }

        #endregion
    }
}

