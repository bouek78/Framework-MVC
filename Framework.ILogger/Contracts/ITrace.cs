using Framework.ILogger.Models;
using System;

namespace Framework.ILogger.Contracts
{
    /// <summary>
    /// Definit le compotement du tracer (logger).
    /// </summary>
    public interface ITrace
    {
        /// <summary>
        /// Initialise le wrapper.
        /// </summary>
        void Initialise();
        /// <summary>
        /// Initialise le wrapper.
        /// </summary>
        /// <param name="loggerName">Nom du logger.</param>
        void Initialise(string loggerName);
        /// <summary>
        /// Initialise le wrapper.
        /// </summary>
        /// <param name="loggerName">Nom du logger.</param>
        /// <param name="configFile">Fichier de configuration.</param>
        void Initialise(string loggerName, string configFile);
        /// <summary>
        /// Initialise le wrapper.
        /// </summary>
        /// <param name="type">Type du déclarant du logger.</param>
        void Initialise(Type type);
        /// <summary>
        /// Initialise le wrapper.
        /// </summary>
        /// <param name="type">Type du déclarant du logger.</param>
        /// <param name="configFile">Fichier de configuration.</param>
        void Initialise(Type type, string configFile);
        /// <summary>
        /// Indique si le niveau de trace "debug" est activé.
        /// </summary>
        bool CanLogDebug { get; }
        /// <summary>
        /// Indique si le niveau de trace "verbose" est activé.
        /// </summary>
        bool CanLogVerbose { get; }
        /// <summary>
        /// Indique si le niveau de trace "audit" est activé.
        /// </summary>
        bool CanLogAudit { get; }
        /// <summary>
        /// Indique si le niveau de trace "info" est activé.
        /// </summary>
        bool CanLogInfo { get; }
        /// <summary>
        /// Indique si le niveau de trace "warning" est activé.
        /// </summary>
        bool CanLogWarning { get; }
        /// <summary>
        /// Indique si le niveau de trace "error" est activé.
        /// </summary>
        bool CanLogError { get; }
        /// <summary>
        /// Indique si le niveau de trace "fatal" est activé.
        /// </summary>
        bool CanLogFatal { get; }
        /// <summary>
        /// Enregistre une trace de niveau debug.
        /// </summary>
        /// <param name="message">Message à tracer.</param>
        /// <param name="args">Argument contenant zero ou n objets à formatter.</param>
        void LogDebug(string message, params object[] args);
        /// <summary>
        /// Enregistre une trace de niveau debug.
        /// </summary>
        /// <param name="message">Message à tracer.</param>
        /// <param name="context">Context applicatif a inclure.</param>
        /// <param name="args">Argument contenant zero ou n objets à formatter.</param>
        void LogDebug(string message, ApplicativeContext context, params object[] args);
        /// <summary>
        /// Enregistre une trace de niveau debug.
        /// </summary>
        /// <param name="exception">Exception à tracer.</param>
        void LogDebug(System.Exception exception);
        /// <summary>
        /// Enregistre une trace de niveau debug.
        /// </summary>
        /// <param name="exception">Exception à tracer.</param>
        /// <param name="context">Context applicatif a inclure.</param>
        void LogDebug(System.Exception exception, ApplicativeContext context);
        /// <summary>
        /// Enregistre une trace de niveau debug.
        /// </summary>
        /// <param name="message">Message à tracer.</param>
        /// <param name="exception">Exception à tracer.</param>
        /// <param name="context">Context applicatif a inclure.</param>
        /// <param name="args">Argument contenant zero ou n objets à formatter.</param>
        void LogDebug(string message, System.Exception exception, ApplicativeContext context, params object[] args);
        /// <summary>
        /// Enregistre une trace de niveau Verbose.
        /// </summary>
        /// <param name="message">Message à tracer.</param>
        /// <param name="args">Argument contenant zero ou n objets à formatter.</param>
        void LogVerbose(string message, params object[] args);
        /// <summary>
        /// Enregistre une trace de niveau Verbose.
        /// </summary>
        /// <param name="message">Message à tracer.</param>
        /// <param name="context">Context applicatif a inclure.</param>
        /// <param name="args">Argument contenant zero ou n objets à formatter.</param>
        void LogVerbose(string message, ApplicativeContext context, params object[] args);
        /// <summary>
        /// Enregistre une trace de niveau Verbose.
        /// </summary>
        /// <param name="exception">Exception à tracer.</param>
        void LogVerbose(System.Exception exception);
        /// <summary>
        /// Enregistre une trace de niveau Verbose.
        /// </summary>
        /// <param name="exception">Exception à tracer.</param>
        /// <param name="context">Context applicatif a inclure.</param>
        void LogVerbose(System.Exception exception, ApplicativeContext context);
        /// <summary>
        /// Enregistre une trace de niveau Verbose.
        /// </summary>
        /// <param name="message">Message à tracer.</param>
        /// <param name="exception">Exception à tracer.</param>
        /// <param name="context">Context applicatif a inclure.</param>
        /// <param name="args">Argument contenant zero ou n objets à formatter.</param>
        void LogVerbose(string message, System.Exception exception, ApplicativeContext context, params object[] args);
        /// <summary>
        /// Enregistre une trace de niveau Audit.
        /// </summary>
        /// <param name="message">Message à tracer.</param>
        /// <param name="args">Argument contenant zero ou n objets à formatter.</param>
        void LogAudit(string message, params object[] args);
        /// <summary>
        /// Enregistre une trace de niveau Audit.
        /// </summary>
        /// <param name="message">Message à tracer.</param>
        /// <param name="context">Context applicatif a inclure.</param>
        /// <param name="args">Argument contenant zero ou n objets à formatter.</param>
        void LogAudit(string message, ApplicativeContext context, params object[] args);
        /// <summary>
        /// Enregistre une trace de niveau Audit.
        /// </summary>
        /// <param name="exception">Exception à tracer.</param>
        void LogAudit(System.Exception exception);
        /// <summary>
        /// Enregistre une trace de niveau Audit.
        /// </summary>
        /// <param name="exception">Exception à tracer.</param>
        /// <param name="context">Context applicatif a inclure.</param>
        void LogAudit(System.Exception exception, ApplicativeContext context);
        /// <summary>
        /// Enregistre une trace de niveau Audit.
        /// </summary>
        /// <param name="message">Message à tracer.</param>
        /// <param name="exception">Exception à tracer.</param>
        /// <param name="context">Context applicatif a inclure.</param>
        /// <param name="args">Argument contenant zero ou n objets à formatter.</param>
        void LogAudit(string message, System.Exception exception, ApplicativeContext context, params object[] args);
        /// <summary>
        /// Enregistre une trace de niveau Info.
        /// </summary>
        /// <param name="message">Message à tracer.</param>
        /// <param name="args">Argument contenant zero ou n objets à formatter.</param>
        void LogInfo(string message, params object[] args);
        /// <summary>
        /// Enregistre une trace de niveau Info.
        /// </summary>
        /// <param name="message">Message à tracer.</param>
        /// <param name="context">Context applicatif a inclure.</param>
        /// <param name="args">Argument contenant zero ou n objets à formatter.</param>
        void LogInfo(string message, ApplicativeContext context, params object[] args);
        /// <summary>
        /// Enregistre une trace de niveau Info.
        /// </summary>
        /// <param name="exception">Exception à tracer.</param>
        void LogInfo(System.Exception exception);
        /// <summary>
        /// Enregistre une trace de niveau Info.
        /// </summary>
        /// <param name="exception">Exception à tracer.</param>
        /// <param name="context">Context applicatif a inclure.</param>
        void LogInfo(System.Exception exception, ApplicativeContext context);
        /// <summary>
        /// Enregistre une trace de niveau Info.
        /// </summary>
        /// <param name="message">Message à tracer.</param>
        /// <param name="exception">Exception à tracer.</param>
        /// <param name="context">Context applicatif a inclure.</param>
        /// <param name="args">Argument contenant zero ou n objets à formatter.</param>
        void LogInfo(string message, System.Exception exception, ApplicativeContext context, params object[] args);
        /// <summary>
        /// Enregistre une trace de niveau Warning.
        /// </summary>
        /// <param name="message">Message à tracer.</param>
        /// <param name="args">Argument contenant zero ou n objets à formatter.</param>
        void LogWarning(string message, params object[] args);
        /// <summary>
        /// Enregistre une trace de niveau Warning.
        /// </summary>
        /// <param name="message">Message à tracer.</param>
        /// <param name="context">Context applicatif a inclure.</param>
        /// <param name="args">Argument contenant zero ou n objets à formatter.</param>
        void LogWarning(string message, ApplicativeContext context, params object[] args);
        /// <summary>
        /// Enregistre une trace de niveau Warning.
        /// </summary>
        /// <param name="exception">Exception à tracer.</param>
        void LogWarning(System.Exception exception);
        /// <summary>
        /// Enregistre une trace de niveau Warning.
        /// </summary>
        /// <param name="exception">Exception à tracer.</param>
        /// <param name="context">Context applicatif a inclure.</param>
        void LogWarning(System.Exception exception, ApplicativeContext context);
        /// <summary>
        /// Enregistre une trace de niveau Warning.
        /// </summary>
        /// <param name="message">Message à tracer.</param>
        /// <param name="exception">Exception à tracer.</param>
        /// <param name="context">Context applicatif a inclure.</param>
        /// <param name="args">Argument contenant zero ou n objets à formatter.</param>
        void LogWarning(string message, System.Exception exception, ApplicativeContext context, params object[] args);
        /// <summary>
        /// Enregistre une trace de niveau Error.
        /// </summary>
        /// <param name="message">Message à tracer.</param>
        /// <param name="exception">Exception à tracer.</param>
        void LogError(string message, System.Exception exception);
        /// <summary>
        /// Enregistre une trace de niveau Error.
        /// </summary>
        /// <param name="message">Message à tracer.</param>
        /// <param name="args">Argument contenant zero ou n objets à formatter.</param>
        void LogError(string message, params object[] args);
        /// <summary>
        /// Enregistre une trace de niveau Error.
        /// </summary>
        /// <param name="message">Message à tracer.</param>
        /// <param name="context">Context applicatif a inclure.</param>
        /// <param name="args">Argument contenant zero ou n objets à formatter.</param>
        void LogError(string message, ApplicativeContext context, params object[] args);
        /// <summary>
        /// Enregistre une trace de niveau Error.
        /// </summary>
        /// <param name="exception">Exception à tracer.</param>
        void LogError(System.Exception exception);
        /// <summary>
        /// Enregistre une trace de niveau Error.
        /// </summary>
        /// <param name="exception">Exception à tracer.</param>
        /// <param name="context">Context applicatif a inclure.</param>
        void LogError(System.Exception exception, ApplicativeContext context);
        /// <summary>
        /// Enregistre une trace de niveau Error.
        /// </summary>
        /// <param name="message">Message à tracer.</param>
        /// <param name="exception">Exception à tracer.</param>
        /// <param name="context">Context applicatif a inclure.</param>
        /// <param name="args">Argument contenant zero ou n objets à formatter.</param>
        void LogError(string message, System.Exception exception, ApplicativeContext context, params object[] args);
        /// <summary>
        /// Enregistre une trace de niveau Fatal.
        /// </summary>
        /// <param name="message">Message à tracer.</param>
        /// <param name="args">Argument contenant zero ou n objets à formatter.</param>
        void LogFatal(string message, params object[] args);
        /// <summary>
        /// Enregistre une trace de niveau Fatal.
        /// </summary>
        /// <param name="message">Message à tracer.</param>
        /// <param name="context">Context applicatif a inclure.</param>
        /// <param name="args">Argument contenant zero ou n objets à formatter.</param>
        void LogFatal(string message, ApplicativeContext context, params object[] args);
        /// <summary>
        /// Enregistre une trace de niveau Fatal.
        /// </summary>
        /// <param name="exception">Exception à tracer.</param>
        void LogFatal(System.Exception exception);
        /// <summary>
        /// Enregistre une trace de niveau Fatal.
        /// </summary>
        /// <param name="exception">Exception à tracer.</param>
        /// <param name="context">Context applicatif a inclure.</param>
        void LogFatal(System.Exception exception, ApplicativeContext context);
        /// <summary>
        /// Enregistre une trace de niveau Fatal.
        /// </summary>
        /// <param name="message">Message à tracer.</param>
        /// <param name="exception">Exception à tracer.</param>
        /// <param name="context">Context applicatif a inclure.</param>
        /// <param name="args">Argument contenant zero ou n objets à formatter.</param>
        void LogFatal(string message, System.Exception exception, ApplicativeContext context, params object[] args);
    }
}
