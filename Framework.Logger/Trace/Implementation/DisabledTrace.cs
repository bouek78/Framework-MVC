using Framework.ILogger.Contracts;
using Framework.ILogger.Models;

namespace Framework.Logger.Trace.Implementation
{
    /// <summary>
    /// Implémentation d'ITrace pour ne pas avoir de traces.
    /// </summary>
    /// <seealso cref="Trace.ITrace" />
    public class DisabledTrace : ITrace
    {

        /// <summary>
        /// Indique si le niveau de trace "audit" est activé.
        /// </summary>
        public bool CanLogAudit
        {
            get { return false; }
        }

        /// <summary>
        /// Indique si le niveau de trace "debug" est activé.
        /// </summary>
        public bool CanLogDebug
        {
            get { return false; }
        }

        /// <summary>
        /// Indique si le niveau de trace "error" est activé.
        /// </summary>
        public bool CanLogError
        {
            get { return false; }
        }

        /// <summary>
        /// Indique si le niveau de trace "fatal" est activé.
        /// </summary>
        public bool CanLogFatal
        {
            get { return false; }
        }

        /// <summary>
        /// Indique si le niveau de trace "info" est activé.
        /// </summary>
        public bool CanLogInfo
        {
            get { return false; }
        }

        /// <summary>
        /// Indique si le niveau de trace "verbose" est activé.
        /// </summary>
        public bool CanLogVerbose
        {
            get { return false; }
        }

        /// <summary>
        /// Indique si le niveau de trace "warning" est activé.
        /// </summary>
        public bool CanLogWarning
        {
            get { return false; }
        }

        /// <summary>
        /// Initialise le wrapper.
        /// </summary>

        public void Initialise()
        {
        }

        /// <summary>
        /// Initialise le wrapper.
        /// </summary>
        /// <param name="loggerName">Nom du logger.</param>

        public void Initialise(string loggerName)
        {
        }

        /// <summary>
        /// Initialise le wrapper.
        /// </summary>
        /// <param name="loggerName">Nom du logger.</param>
        /// <param name="configFile">Fichier de configuration.</param>

        public void Initialise(string loggerName, string configFile)
        {
        }

        /// <summary>
        /// Initialise le wrapper.
        /// </summary>
        /// <param name="type">Type du déclarant du logger.</param>

        public void Initialise(System.Type type)
        {
        }

        /// <summary>
        /// Initialise le wrapper.
        /// </summary>
        /// <param name="type">Type du déclarant du logger.</param>
        /// <param name="configFile">Fichier de configuration.</param>

        public void Initialise(System.Type type, string configFile)
        {
        }

        /// <summary>
        /// Enregistre une trace de niveau Audit.
        /// </summary>
        /// <param name="message">Message à tracer.</param>
        /// <param name="context">Context applicatif a inclure.</param>
        /// <param name="args">Argument contenant zero ou n objets à formatter.</param>

        public void LogAudit(string message, ApplicativeContext context, params object[] args)
        {
        }

        /// <summary>
        /// Enregistre une trace de niveau Audit.
        /// </summary>
        /// <param name="message">Message à tracer.</param>
        /// <param name="args">Argument contenant zero ou n objets à formatter.</param>

        public void LogAudit(string message, params object[] args)
        {
        }

        /// <summary>
        /// Enregistre une trace de niveau Audit.
        /// </summary>
        /// <param name="message">Message à tracer.</param>
        /// <param name="exception">Exception à tracer.</param>
        /// <param name="context">Context applicatif a inclure.</param>
        /// <param name="args">Argument contenant zero ou n objets à formatter.</param>

        public void LogAudit(string message, System.Exception exception, ApplicativeContext context, params object[] args)
        {
        }

        /// <summary>
        /// Enregistre une trace de niveau Audit.
        /// </summary>
        /// <param name="exception">Exception à tracer.</param>

        public void LogAudit(System.Exception exception)
        {
        }

        /// <summary>
        /// Enregistre une trace de niveau Audit.
        /// </summary>
        /// <param name="exception">Exception à tracer.</param>
        /// <param name="context">Context applicatif a inclure.</param>

        public void LogAudit(System.Exception exception, ApplicativeContext context)
        {
        }

        /// <summary>
        /// Enregistre une trace de niveau debug.
        /// </summary>
        /// <param name="message">Message à tracer.</param>
        /// <param name="context">Context applicatif a inclure.</param>
        /// <param name="args">Argument contenant zero ou n objets à formatter.</param>

        public void LogDebug(string message, ApplicativeContext context, params object[] args)
        {
        }

        /// <summary>
        /// Enregistre une trace de niveau debug.
        /// </summary>
        /// <param name="message">Message à tracer.</param>
        /// <param name="args">Argument contenant zero ou n objets à formatter.</param>

        public void LogDebug(string message, params object[] args)
        {
        }

        /// <summary>
        /// Enregistre une trace de niveau debug.
        /// </summary>
        /// <param name="message">Message à tracer.</param>
        /// <param name="exception">Exception à tracer.</param>
        /// <param name="context">Context applicatif a inclure.</param>
        /// <param name="args">Argument contenant zero ou n objets à formatter.</param>

        public void LogDebug(string message, System.Exception exception, ApplicativeContext context, params object[] args)
        {
        }

        /// <summary>
        /// Enregistre une trace de niveau debug.
        /// </summary>
        /// <param name="exception">Exception à tracer.</param>

        public void LogDebug(System.Exception exception)
        {
        }

        /// <summary>
        /// Enregistre une trace de niveau debug.
        /// </summary>
        /// <param name="exception">Exception à tracer.</param>
        /// <param name="context">Context applicatif a inclure.</param>

        public void LogDebug(System.Exception exception, ApplicativeContext context)
        {
        }

        /// <summary>
        /// Enregistre une trace de niveau Error.
        /// </summary>
        /// <param name="message">Message à tracer.</param>
        /// <param name="context">Context applicatif a inclure.</param>
        /// <param name="args">Argument contenant zero ou n objets à formatter.</param>

        public void LogError(string message, ApplicativeContext context, params object[] args)
        {
        }

        /// <summary>
        /// Enregistre une trace de niveau Error.
        /// </summary>
        /// <param name="message">Message à tracer.</param>
        /// <param name="args">Argument contenant zero ou n objets à formatter.</param>

        public void LogError(string message, params object[] args)
        {
        }

        /// <summary>
        /// Enregistre une trace de niveau Error.
        /// </summary>
        /// <param name="message">Message à tracer.</param>
        /// <param name="exception">Exception à tracer.</param>

        public void LogError(string message, System.Exception exception)
        {
        }

        /// <summary>
        /// Enregistre une trace de niveau Error.
        /// </summary>
        /// <param name="message">Message à tracer.</param>
        /// <param name="exception">Exception à tracer.</param>
        /// <param name="context">Context applicatif a inclure.</param>
        /// <param name="args">Argument contenant zero ou n objets à formatter.</param>

        public void LogError(string message, System.Exception exception, ApplicativeContext context, params object[] args)
        {
        }

        /// <summary>
        /// Enregistre une trace de niveau Error.
        /// </summary>
        /// <param name="exception">Exception à tracer.</param>

        public void LogError(System.Exception exception)
        {
        }

        /// <summary>
        /// Enregistre une trace de niveau Error.
        /// </summary>
        /// <param name="exception">Exception à tracer.</param>
        /// <param name="context">Context applicatif a inclure.</param>

        public void LogError(System.Exception exception, ApplicativeContext context)
        {
        }

        /// <summary>
        /// Enregistre une trace de niveau Fatal.
        /// </summary>
        /// <param name="message">Message à tracer.</param>
        /// <param name="context">Context applicatif a inclure.</param>
        /// <param name="args">Argument contenant zero ou n objets à formatter.</param>

        public void LogFatal(string message, ApplicativeContext context, params object[] args)
        {
        }

        /// <summary>
        /// Enregistre une trace de niveau Fatal.
        /// </summary>
        /// <param name="message">Message à tracer.</param>
        /// <param name="args">Argument contenant zero ou n objets à formatter.</param>

        public void LogFatal(string message, params object[] args)
        {
        }

        /// <summary>
        /// Enregistre une trace de niveau Fatal.
        /// </summary>
        /// <param name="message">Message à tracer.</param>
        /// <param name="exception">Exception à tracer.</param>
        /// <param name="context">Context applicatif a inclure.</param>
        /// <param name="args">Argument contenant zero ou n objets à formatter.</param>

        public void LogFatal(string message, System.Exception exception, ApplicativeContext context, params object[] args)
        {
        }

        /// <summary>
        /// Enregistre une trace de niveau Fatal.
        /// </summary>
        /// <param name="exception">Exception à tracer.</param>

        public void LogFatal(System.Exception exception)
        {
        }

        /// <summary>
        /// Enregistre une trace de niveau Fatal.
        /// </summary>
        /// <param name="exception">Exception à tracer.</param>
        /// <param name="context">Context applicatif a inclure.</param>

        public void LogFatal(System.Exception exception, ApplicativeContext context)
        {
        }

        /// <summary>
        /// Enregistre une trace de niveau Info.
        /// </summary>
        /// <param name="message">Message à tracer.</param>
        /// <param name="context">Context applicatif a inclure.</param>
        /// <param name="args">Argument contenant zero ou n objets à formatter.</param>

        public void LogInfo(string message, ApplicativeContext context, params object[] args)
        {
        }

        /// <summary>
        /// Enregistre une trace de niveau Info.
        /// </summary>
        /// <param name="message">Message à tracer.</param>
        /// <param name="args">Argument contenant zero ou n objets à formatter.</param>

        public void LogInfo(string message, params object[] args)
        {
        }

        /// <summary>
        /// Enregistre une trace de niveau Info.
        /// </summary>
        /// <param name="message">Message à tracer.</param>
        /// <param name="exception">Exception à tracer.</param>
        /// <param name="context">Context applicatif a inclure.</param>
        /// <param name="args">Argument contenant zero ou n objets à formatter.</param>

        public void LogInfo(string message, System.Exception exception, ApplicativeContext context, params object[] args)
        {
        }

        /// <summary>
        /// Enregistre une trace de niveau Info.
        /// </summary>
        /// <param name="exception">Exception à tracer.</param>

        public void LogInfo(System.Exception exception)
        {
        }

        /// <summary>
        /// Enregistre une trace de niveau Info.
        /// </summary>
        /// <param name="exception">Exception à tracer.</param>
        /// <param name="context">Context applicatif a inclure.</param>

        public void LogInfo(System.Exception exception, ApplicativeContext context)
        {
        }

        /// <summary>
        /// Enregistre une trace de niveau Verbose.
        /// </summary>
        /// <param name="message">Message à tracer.</param>
        /// <param name="context">Context applicatif a inclure.</param>
        /// <param name="args">Argument contenant zero ou n objets à formatter.</param>

        public void LogVerbose(string message, ApplicativeContext context, params object[] args)
        {
        }

        /// <summary>
        /// Enregistre une trace de niveau Verbose.
        /// </summary>
        /// <param name="message">Message à tracer.</param>
        /// <param name="args">Argument contenant zero ou n objets à formatter.</param>

        public void LogVerbose(string message, params object[] args)
        {
        }

        /// <summary>
        /// Enregistre une trace de niveau Verbose.
        /// </summary>
        /// <param name="message">Message à tracer.</param>
        /// <param name="exception">Exception à tracer.</param>
        /// <param name="context">Context applicatif a inclure.</param>
        /// <param name="args">Argument contenant zero ou n objets à formatter.</param>

        public void LogVerbose(string message, System.Exception exception, ApplicativeContext context, params object[] args)
        {
        }

        /// <summary>
        /// Enregistre une trace de niveau Verbose.
        /// </summary>
        /// <param name="exception">Exception à tracer.</param>

        public void LogVerbose(System.Exception exception)
        {
        }

        /// <summary>
        /// Enregistre une trace de niveau Verbose.
        /// </summary>
        /// <param name="exception">Exception à tracer.</param>
        /// <param name="context">Context applicatif a inclure.</param>

        public void LogVerbose(System.Exception exception, ApplicativeContext context)
        {
        }

        /// <summary>
        /// Enregistre une trace de niveau Warning.
        /// </summary>
        /// <param name="message">Message à tracer.</param>
        /// <param name="context">Context applicatif a inclure.</param>
        /// <param name="args">Argument contenant zero ou n objets à formatter.</param>

        public void LogWarning(string message, ApplicativeContext context, params object[] args)
        {
        }

        /// <summary>
        /// Enregistre une trace de niveau Warning.
        /// </summary>
        /// <param name="message">Message à tracer.</param>
        /// <param name="args">Argument contenant zero ou n objets à formatter.</param>

        public void LogWarning(string message, params object[] args)
        {
        }

        /// <summary>
        /// Enregistre une trace de niveau Warning.
        /// </summary>
        /// <param name="message">Message à tracer.</param>
        /// <param name="exception">Exception à tracer.</param>
        /// <param name="context">Context applicatif a inclure.</param>
        /// <param name="args">Argument contenant zero ou n objets à formatter.</param>

        public void LogWarning(string message, System.Exception exception, ApplicativeContext context, params object[] args)
        {
        }

        /// <summary>
        /// Enregistre une trace de niveau Warning.
        /// </summary>
        /// <param name="exception">Exception à tracer.</param>

        public void LogWarning(System.Exception exception)
        {
        }

        /// <summary>
        /// Enregistre une trace de niveau Warning.
        /// </summary>
        /// <param name="exception">Exception à tracer.</param>
        /// <param name="context">Context applicatif a inclure.</param>

        public void LogWarning(System.Exception exception, ApplicativeContext context)
        {
        }
    }
}

