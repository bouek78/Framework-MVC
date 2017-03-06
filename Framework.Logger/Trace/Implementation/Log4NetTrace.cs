using Framework.ILogger.Contracts;
using Framework.ILogger.Models;
using log4net;
using log4net.Core;
using System;

[assembly: log4net.Config.XmlConfigurator()]
namespace Framework.Logger.Trace.Implementation
{
    /// <summary>
    /// Wrapper du logger Log4Net.
    /// </summary>
    public class Log4NetTrace : ITrace
    {
        #region "Attributs"

        /// <summary>
        /// Instance du logger Log4Net.
        /// </summary>

        private ILog _logger;
        /// <summary>
        /// Niveau Audit.
        /// </summary>

        private Level _auditLevel;
        /// <summary>
        /// Indique si la configuration a été chargée.
        /// </summary>

        private static bool _configLoaded;
        /// <summary>
        /// Objet lock pour la synchro.
        /// </summary>

        private static object _lock = new object();

        protected const int AuditLevelValue = 3500;
        #endregion

        #region "Propriétés"

        /// <summary>
        /// Indique si le niveau de trace "audit" est activé.
        /// </summary>
        public bool CanLogAudit
        {
            get { return _logger.Logger.IsEnabledFor(_auditLevel); }
        }

        /// <summary>
        /// Indique si le niveau de trace "verbose" est activé.
        /// </summary>
        public bool CanLogVerbose
        {
            get { return _logger.Logger.IsEnabledFor(Level.Verbose); }
        }

        /// <summary>
        /// Indique si le niveau de trace "debug" est activé.
        /// </summary>
        public bool CanLogDebug
        {
            get { return _logger.IsDebugEnabled; }
        }

        /// <summary>
        /// Indique si le niveau de trace "error" est activé.
        /// </summary>
        public bool CanLogError
        {
            get { return _logger.IsErrorEnabled; }
        }

        /// <summary>
        /// Indique si le niveau de trace "fatal" est activé.
        /// </summary>
        public bool CanLogFatal
        {
            get { return _logger.IsFatalEnabled; }
        }

        /// <summary>
        /// Indique si le niveau de trace "info" est activé.
        /// </summary>
        public bool CanLogInfo
        {
            get { return _logger.IsInfoEnabled; }
        }

        /// <summary>
        /// Indique si le niveau de trace "warning" est activé.
        /// </summary>
        public bool CanLogWarning
        {
            get { return _logger.IsWarnEnabled; }
        }

        #endregion

        #region "Constructeurs"

        /// <summary>
        /// Constructeur.
        /// </summary>

        public Log4NetTrace() { }

        #endregion

        #region "Méthodes publiques"

        /// <summary>
        /// Enregistre une trace de niveau Audit.
        /// </summary>
        /// <param name="message">Message à tracer.</param>
        /// <param name="context">Context applicatif a inclure.</param>
        /// <param name="args">Argument contenant zero ou n objets à formatter.</param>
        public void LogAudit(string message, ApplicativeContext context, params object[] args)
        {
            if (CanLogAudit)
            {
                if (string.IsNullOrEmpty(message))
                    throw new ArgumentNullException("message");
                if (context != null)
                {
                    this.AddContext(context);
                }

                string finalMessage = args != null && args.Length > 0 ? string.Format(message, args) : message;
                _logger.Logger.Log(typeof(Log4NetTrace), _auditLevel, finalMessage, null);
            }
        }

        /// <summary>
        /// Enregistre une trace de niveau Audit.
        /// </summary>
        /// <param name="message">Message à tracer.</param>
        /// <param name="args">Argument contenant zero ou n objets à formatter.</param>
        public void LogAudit(string message, params object[] args)
        {
            if (CanLogAudit)
            {
                if (string.IsNullOrEmpty(message))
                    throw new ArgumentNullException("message");
                string finalMessage = args != null && args.Length > 0 ? string.Format(message, args) : message;
                _logger.Logger.Log(typeof(Log4NetTrace), _auditLevel, finalMessage, null);
            }
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
            if (CanLogAudit)
            {
                if (string.IsNullOrEmpty(message))
                    throw new ArgumentNullException("message");
                if (exception == null)
                    throw new ArgumentNullException("exception");
                if (context != null)
                {
                    this.AddContext(context);
                }

                string finalMessage = args != null && args.Length > 0 ? string.Format(message, args) : message;
                _logger.Logger.Log(typeof(Log4NetTrace), _auditLevel, finalMessage, exception);
            }
        }

        /// <summary>
        /// Enregistre une trace de niveau Audit.
        /// </summary>
        /// <param name="exception">Exception à tracer.</param>
        public void LogAudit(System.Exception exception)
        {
            if (CanLogAudit)
            {
                if (exception == null)
                    throw new ArgumentNullException("exception");
                _logger.Logger.Log(typeof(Log4NetTrace), _auditLevel, exception.Message, exception);
            }
        }

        /// <summary>
        /// Enregistre une trace de niveau Audit.
        /// </summary>
        /// <param name="exception">Exception à tracer.</param>
        /// <param name="context">Context applicatif a inclure.</param>
        public void LogAudit(System.Exception exception, ApplicativeContext context)
        {
            if (CanLogAudit)
            {
                if (exception == null)
                    throw new ArgumentNullException("exception");
                if (context != null)
                {
                    this.AddContext(context);
                }
                _logger.Logger.Log(typeof(Log4NetTrace), _auditLevel, exception.Message, exception);
            }
        }

        /// <summary>
        /// Enregistre une trace de niveau debug.
        /// </summary>
        /// <param name="message">Message à tracer.</param>
        /// <param name="context">Context applicatif a inclure.</param>
        /// <param name="args">Argument contenant zero ou n objets à formatter.</param>
        public void LogDebug(string message, ApplicativeContext context, params object[] args)
        {
            if (CanLogDebug)
            {
                if (string.IsNullOrEmpty(message))
                    throw new ArgumentNullException("message");
                if (context != null)
                {
                    this.AddContext(context);
                }

                string finalMessage = args != null && args.Length > 0 ? string.Format(message, args) : message;
                _logger.Logger.Log(typeof(Log4NetTrace), Level.Debug, finalMessage, null);
            }
        }

        /// <summary>
        /// Enregistre une trace de niveau debug.
        /// </summary>
        /// <param name="message">Message à tracer.</param>
        /// <param name="args">Argument contenant zero ou n objets à formatter.</param>
        public void LogDebug(string message, params object[] args)
        {
            if (CanLogDebug)
            {
                if (string.IsNullOrEmpty(message))
                    throw new ArgumentNullException("message");
                string finalMessage = args != null && args.Length > 0 ? string.Format(message, args) : message;
                _logger.Logger.Log(typeof(Log4NetTrace), Level.Debug, finalMessage, null);
            }
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
            if (CanLogDebug)
            {
                if (string.IsNullOrEmpty(message))
                    throw new ArgumentNullException("message");
                if (exception == null)
                    throw new ArgumentNullException("exception");
                if (context != null)
                {
                    this.AddContext(context);
                }

                string finalMessage = args != null && args.Length > 0 ? string.Format(message, args) : message;
                _logger.Logger.Log(typeof(Log4NetTrace), Level.Debug, finalMessage, exception);
            }
        }

        /// <summary>
        /// Enregistre une trace de niveau debug.
        /// </summary>
        /// <param name="exception">Exception à tracer.</param>
        public void LogDebug(System.Exception exception)
        {
            if (CanLogDebug)
            {
                if (exception == null)
                    throw new ArgumentNullException("exception");
                _logger.Logger.Log(typeof(Log4NetTrace), Level.Debug, exception.Message, exception);
            }
        }

        /// <summary>
        /// Enregistre une trace de niveau debug.
        /// </summary>
        /// <param name="exception">Exception à tracer.</param>
        /// <param name="context">Context applicatif a inclure.</param>
        public void LogDebug(System.Exception exception, ApplicativeContext context)
        {
            if (CanLogDebug)
            {
                if (exception == null)
                    throw new ArgumentNullException("exception");
                if (context != null)
                {
                    this.AddContext(context);
                }

                _logger.Logger.Log(typeof(Log4NetTrace), Level.Debug, exception.Message, exception);
            }
        }

        /// <summary>
        /// Enregistre une trace de niveau Error.
        /// </summary>
        /// <param name="message">Message à tracer.</param>
        /// <param name="context">Context applicatif a inclure.</param>
        /// <param name="args">Argument contenant zero ou n objets à formatter.</param>
        public void LogError(string message, ApplicativeContext context, params object[] args)
        {
            if (CanLogError)
            {
                if (string.IsNullOrEmpty(message))
                    throw new ArgumentNullException("message");
                if (context != null)
                {
                    this.AddContext(context);
                }

                string finalMessage = args != null && args.Length > 0 ? string.Format(message, args) : message;
                _logger.Logger.Log(typeof(Log4NetTrace), Level.Error, finalMessage, null);
            }
        }

        /// <summary>
        /// Enregistre une trace de niveau Error.
        /// </summary>
        /// <param name="message">Message à tracer.</param>
        /// <param name="exception">Exception à tracer.</param>
        public void LogError(string message, System.Exception exception)
        {
            if (CanLogError)
            {
                if (string.IsNullOrEmpty(message))
                    throw new ArgumentNullException("message");
                _logger.Logger.Log(typeof(Log4NetTrace), Level.Error, message, exception);
                if (exception == null)
                    throw new ArgumentNullException("exception");
            }
        }

        /// <summary>
        /// Enregistre une trace de niveau Error.
        /// </summary>
        /// <param name="message">Message à tracer.</param>
        /// <param name="args">Argument contenant zero ou n objets à formatter.</param>
        public void LogError(string message, params object[] args)
        {
            if (CanLogError)
            {
                if (string.IsNullOrEmpty(message))
                    throw new ArgumentNullException("message");
                string finalMessage = args != null && args.Length > 0 ? string.Format(message, args) : message;
                _logger.Logger.Log(typeof(Log4NetTrace), Level.Error, finalMessage, null);
            }
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
            if (CanLogError)
            {
                if (string.IsNullOrEmpty(message))
                    throw new ArgumentNullException("message");
                if (exception == null)
                    throw new ArgumentNullException("exception");
                if (context != null)
                {
                    this.AddContext(context);
                }

                string finalMessage = args != null && args.Length > 0 ? string.Format(message, args) : message;
                _logger.Logger.Log(typeof(Log4NetTrace), Level.Error, finalMessage, exception);
            }
        }

        /// <summary>
        /// Enregistre une trace de niveau Error.
        /// </summary>
        /// <param name="exception">Exception à tracer.</param>
        public void LogError(System.Exception exception)
        {
            if (CanLogError)
            {
                if (exception == null)
                    throw new ArgumentNullException("exception");
                _logger.Logger.Log(typeof(Log4NetTrace), Level.Error, exception.Message, exception);
            }
        }

        /// <summary>
        /// Enregistre une trace de niveau Error.
        /// </summary>
        /// <param name="exception">Exception à tracer.</param>
        /// <param name="context">Context applicatif a inclure.</param>
        public void LogError(System.Exception exception, ApplicativeContext context)
        {
            if (CanLogError)
            {
                if (exception == null)
                    throw new ArgumentNullException("exception");
                if (context != null)
                {
                    this.AddContext(context);
                }

                _logger.Logger.Log(typeof(Log4NetTrace), Level.Error, exception.Message, exception);
            }
        }

        /// <summary>
        /// Enregistre une trace de niveau Info.
        /// </summary>
        /// <param name="message">Message à tracer.</param>
        /// <param name="context">Context applicatif a inclure.</param>
        /// <param name="args">Argument contenant zero ou n objets à formatter.</param>
        public void LogInfo(string message, ApplicativeContext context, params object[] args)
        {
            if (CanLogInfo)
            {
                if (string.IsNullOrEmpty(message))
                    throw new ArgumentNullException("message");
                if (context != null)
                {
                    this.AddContext(context);
                }

                string finalMessage = args != null && args.Length > 0 ? string.Format(message, args) : message;
                _logger.Logger.Log(typeof(Log4NetTrace), Level.Info, finalMessage, null);
            }
        }

        /// <summary>
        /// Enregistre une trace de niveau Info.
        /// </summary>
        /// <param name="message">Message à tracer.</param>
        /// <param name="args">Argument contenant zero ou n objets à formatter.</param>
        public void LogInfo(string message, params object[] args)
        {
            if (CanLogInfo)
            {
                if (string.IsNullOrEmpty(message))
                    throw new ArgumentNullException("message");
                _logger.Logger.Log(typeof(Log4NetTrace), Level.Info, string.Format(message, args), null);
            }
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
            if (CanLogInfo)
            {
                if (string.IsNullOrEmpty(message))
                    throw new ArgumentNullException("message");
                if (exception == null)
                    throw new ArgumentNullException("exception");
                if (context != null)
                {
                    this.AddContext(context);
                }

                string finalMessage = args != null && args.Length > 0 ? string.Format(message, args) : message;
                _logger.Logger.Log(typeof(Log4NetTrace), Level.Info, finalMessage, exception);
            }
        }

        /// <summary>
        /// Enregistre une trace de niveau Info.
        /// </summary>
        /// <param name="exception">Exception à tracer.</param>
        public void LogInfo(System.Exception exception)
        {
            if (CanLogInfo)
            {
                if (exception == null)
                    throw new ArgumentNullException("exception");
                _logger.Logger.Log(typeof(Log4NetTrace), Level.Info, exception.Message, exception);
            }
        }

        /// <summary>
        /// Enregistre une trace de niveau Info.
        /// </summary>
        /// <param name="exception">Exception à tracer.</param>
        /// <param name="context">Context applicatif a inclure.</param>
        public void LogInfo(System.Exception exception, ApplicativeContext context)
        {
            if (CanLogInfo)
            {
                if (exception == null)
                    throw new ArgumentNullException("exception");
                if (context != null)
                {
                    this.AddContext(context);
                }

                _logger.Logger.Log(typeof(Log4NetTrace), Level.Info, exception.Message, exception);
            }
        }

        /// <summary>
        /// Enregistre une trace de niveau Fatal.
        /// </summary>
        /// <param name="message">Message à tracer.</param>
        /// <param name="context">Context applicatif a inclure.</param>
        /// <param name="args">Argument contenant zero ou n objets à formatter.</param>
        public void LogFatal(string message, ApplicativeContext context, params object[] args)
        {
            if (CanLogFatal)
            {
                if (string.IsNullOrEmpty(message))
                    throw new ArgumentNullException("message");
                if (context != null)
                {
                    this.AddContext(context);
                }

                string finalMessage = args != null && args.Length > 0 ? string.Format(message, args) : message;
                _logger.Logger.Log(typeof(Log4NetTrace), Level.Fatal, finalMessage, null);
            }
        }

        /// <summary>
        /// Enregistre une trace de niveau Fatal.
        /// </summary>
        /// <param name="message">Message à tracer.</param>
        /// <param name="args">Argument contenant zero ou n objets à formatter.</param>
        public void LogFatal(string message, params object[] args)
        {
            if (CanLogFatal)
            {
                string finalMessage = args != null && args.Length > 0 ? string.Format(message, args) : message;
                _logger.Logger.Log(typeof(Log4NetTrace), Level.Fatal, finalMessage, null);
            }
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
            if (CanLogFatal)
            {
                if (string.IsNullOrEmpty(message))
                    throw new ArgumentNullException("message");
                if (exception == null)
                    throw new ArgumentNullException("exception");
                if (context != null)
                {
                    this.AddContext(context);
                }

                string finalMessage = args != null && args.Length > 0 ? string.Format(message, args) : message;
                _logger.Logger.Log(typeof(Log4NetTrace), Level.Fatal, finalMessage, exception);
            }
        }

        /// <summary>
        /// Enregistre une trace de niveau Fatal.
        /// </summary>
        /// <param name="exception">Exception à tracer.</param>
        public void LogFatal(System.Exception exception)
        {
            if (CanLogFatal)
            {
                if (exception == null)
                    throw new ArgumentNullException("exception");
                _logger.Logger.Log(typeof(Log4NetTrace), Level.Fatal, exception.Message, exception);
            }
        }

        /// <summary>
        /// Enregistre une trace de niveau Fatal.
        /// </summary>
        /// <param name="exception">Exception à tracer.</param>
        /// <param name="context">Context applicatif a inclure.</param>
        public void LogFatal(System.Exception exception, ApplicativeContext context)
        {
            if (CanLogFatal)
            {
                if (exception == null)
                    throw new ArgumentNullException("exception");
                if (context != null)
                {
                    this.AddContext(context);
                }

                _logger.Logger.Log(typeof(Log4NetTrace), Level.Fatal, exception.Message, exception);
            }
        }

        /// <summary>
        /// Enregistre une trace de niveau Verbose.
        /// </summary>
        /// <param name="message">Message à tracer.</param>
        /// <param name="context">Context applicatif a inclure.</param>
        /// <param name="args">Argument contenant zero ou n objets à formatter.</param>
        public void LogVerbose(string message, ApplicativeContext context, params object[] args)
        {
            if (CanLogVerbose)
            {
                if (string.IsNullOrEmpty(message))
                    throw new ArgumentNullException("message");
                if (context != null)
                {
                    this.AddContext(context);
                }

                string finalMessage = args != null && args.Length > 0 ? string.Format(message, args) : message;
                _logger.Logger.Log(typeof(Log4NetTrace), Level.Verbose, finalMessage, null);
            }
        }

        /// <summary>
        /// Enregistre une trace de niveau Verbose.
        /// </summary>
        /// <param name="message">Message à tracer.</param>
        /// <param name="args">Argument contenant zero ou n objets à formatter.</param>
        public void LogVerbose(string message, params object[] args)
        {
            if (CanLogVerbose)
            {
                if (string.IsNullOrEmpty(message))
                    throw new ArgumentNullException("message");
                string finalMessage = args != null && args.Length > 0 ? string.Format(message, args) : message;
                _logger.Logger.Log(typeof(Log4NetTrace), Level.Verbose, finalMessage, null);
            }
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
            if (CanLogVerbose)
            {
                if (string.IsNullOrEmpty(message))
                    throw new ArgumentNullException("message");
                if (exception == null)
                    throw new ArgumentNullException("exception");
                if (context != null)
                {
                    this.AddContext(context);
                }

                string finalMessage = args != null && args.Length > 0 ? string.Format(message, args) : message;
                _logger.Logger.Log(typeof(Log4NetTrace), Level.Verbose, finalMessage, exception);
            }
        }

        /// <summary>
        /// Enregistre une trace de niveau Verbose.
        /// </summary>
        /// <param name="exception">Exception à tracer.</param>
        public void LogVerbose(System.Exception exception)
        {
            if (CanLogVerbose)
            {
                if (exception == null)
                    throw new ArgumentNullException("exception");
                _logger.Logger.Log(typeof(Log4NetTrace), Level.Verbose, exception.Message, exception);
            }
        }

        /// <summary>
        /// Enregistre une trace de niveau Verbose.
        /// </summary>
        /// <param name="exception">Exception à tracer.</param>
        /// <param name="context">Context applicatif a inclure.</param>
        public void LogVerbose(System.Exception exception, ApplicativeContext context)
        {
            if (CanLogVerbose)
            {
                if (exception == null)
                    throw new ArgumentNullException("exception");
                if (context != null)
                {
                    this.AddContext(context);
                }

                _logger.Logger.Log(typeof(Log4NetTrace), Level.Verbose, exception.Message, exception);
            }
        }

        /// <summary>
        /// Enregistre une trace de niveau Warning.
        /// </summary>
        /// <param name="message">Message à tracer.</param>
        /// <param name="context">Context applicatif a inclure.</param>
        /// <param name="args">Argument contenant zero ou n objets à formatter.</param>
        public void LogWarning(string message, ApplicativeContext context, params object[] args)
        {
            if (CanLogWarning)
            {
                if (string.IsNullOrEmpty(message))
                    throw new ArgumentNullException("message");
                if (context != null)
                {
                    this.AddContext(context);
                }

                string finalMessage = args != null && args.Length > 0 ? string.Format(message, args) : message;
                _logger.Logger.Log(typeof(Log4NetTrace), Level.Warn, finalMessage, null);
            }
        }

        /// <summary>
        /// Enregistre une trace de niveau Warning.
        /// </summary>
        /// <param name="message">Message à tracer.</param>
        /// <param name="args">Argument contenant zero ou n objets à formatter.</param>
        public void LogWarning(string message, params object[] args)
        {
            if (CanLogWarning)
            {
                if (string.IsNullOrEmpty(message))
                    throw new ArgumentNullException("message");

                string finalMessage = args != null && args.Length > 0 ? string.Format(message, args) : message;
                _logger.Logger.Log(typeof(Log4NetTrace), Level.Warn, finalMessage, null);
            }
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
            if (CanLogWarning)
            {
                if (exception == null)
                    throw new ArgumentNullException("exception");
                if (context != null)
                {
                    this.AddContext(context);
                }

                if (string.IsNullOrEmpty(message))
                    throw new ArgumentNullException("message");
                string finalMessage = args != null && args.Length > 0 ? string.Format(message, args) : message;
                _logger.Logger.Log(typeof(Log4NetTrace), Level.Warn, finalMessage, null);
            }
        }

        /// <summary>
        /// Enregistre une trace de niveau Warning.
        /// </summary>
        /// <param name="exception">Exception à tracer.</param>
        public void LogWarning(System.Exception exception)
        {
            if (CanLogWarning)
            {
                if (exception == null)
                    throw new ArgumentNullException("exception");
                _logger.Logger.Log(typeof(Log4NetTrace), Level.Warn, exception.Message, exception);
            }
        }

        /// <summary>
        /// Enregistre une trace de niveau Warning.
        /// </summary>
        /// <param name="exception">Exception à tracer.</param>
        /// <param name="context">Context applicatif a inclure.</param>
        public void LogWarning(System.Exception exception, ApplicativeContext context)
        {
            if (CanLogWarning)
            {
                if (exception == null)
                    throw new ArgumentNullException("exception");
                if (context != null)
                {
                    this.AddContext(context);
                }

                _logger.Logger.Log(typeof(Log4NetTrace), Level.Warn, exception.Message, exception);
            }
        }

        /// <summary>
        /// Initialise le wrapper.
        /// </summary>
        public void Initialise()
        {
            Initialise("GEM.Logger");
        }

        /// <summary>
        /// Initialise le wrapper.
        /// </summary>
        /// <param name="loggerName">Nom du logger.</param>
        public void Initialise(string loggerName)
        {
            Initialise(loggerName, null);
        }

        /// <summary>
        /// Initialise le wrapper.
        /// </summary>
        /// <param name="loggerName">Nom du logger.</param>
        /// <param name="configFile">Fichier de configuration.</param>
        public void Initialise(string loggerName, string configFile)
        {
            // Chargement du fichier de configuration si spécifié
            // 1ère vérification de la confiuration du logger.
            if (!_configLoaded && !string.IsNullOrEmpty(configFile))
            {
                lock (_lock)
                {
                    // Deuxième vérif de la configuration du logger pour être sûr
                    // qu'il n'y aura qu'un appel à la config et minimiser le synclock.
                    if (!_configLoaded)
                    {
                        log4net.Config.XmlConfigurator.ConfigureAndWatch(new System.IO.FileInfo(configFile));
                        _configLoaded = true;
                    }
                }
            }

            // Création du niveau d'audit.
            _auditLevel = new Level(AuditLevelValue, "AUDIT");

            // Ajout du niveau d'audit.
            LogManager.GetRepository().LevelMap.Add(_auditLevel);

            // Récupération du logger.
            _logger = LogManager.GetLogger(loggerName);
        }

        /// <summary>
        /// Initialise le wrapper.
        /// </summary>
        /// <param name="type">Type du déclarant du logger.</param>
        public void Initialise(System.Type type)
        {
            Initialise(type, null);
        }

        /// <summary>
        /// Initialise le wrapper.
        /// </summary>
        /// <param name="type">Type du déclarant du logger.</param>
        /// <param name="configFile">Fichier de configuration.</param>
        public void Initialise(System.Type type, string configFile)
        {
            // Chargement du fichier de configuration si spécifié
            // 1ère vérification de la confiuration du logger.
            if (!_configLoaded && !string.IsNullOrEmpty(configFile))
            {
                lock (_lock)
                {
                    // Deuxième vérif de la configuration du logger pour être sur
                    // qu'il n'y aura qu'un appel à la config et minimiser le synclock.
                    if (!_configLoaded)
                    {
                        log4net.Config.XmlConfigurator.ConfigureAndWatch(new System.IO.FileInfo(configFile));
                        _configLoaded = true;
                    }
                }
            }

            // Création du niveau d'audit.
            _auditLevel = new Level(AuditLevelValue, "AUDIT");

            // Ajout du niveau d'audit.
            LogManager.GetRepository().LevelMap.Add(_auditLevel);

            // Récupération du logger.
            _logger = LogManager.GetLogger(type);
        }

        #endregion

        #region "Méthodes privées"

        /// <summary>
        /// Ajoute des informations de context dans le logger.
        /// </summary>
        /// <param name="context">Context applicatif.</param>
        protected void AddContext(ApplicativeContext context)
        {
            if (context != null)
            {
                MDC.Set("userName", context.UserName);
                MDC.Set("ip", context.IP);
                MDC.Set("browserName", context.BrowserName);
                MDC.Set("browserVersion", context.BrowserVersion);
                MDC.Set("sessionId", context.SessionId);
                MDC.Set("assemblyName", context.AssemblyName);
                MDC.Set("assemblyVersion", context.AssemblyVersion);
                MDC.Set("callingFilePath", context.CallingFilePath);
                MDC.Set("callingFileLine", context.CallingFileLine);
                MDC.Set("callingClassName", context.CallingClassName);
                MDC.Set("callingMethodName", context.CallingMethodName);
            }
        }

        #endregion
    }
}



