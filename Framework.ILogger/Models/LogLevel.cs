using System;

namespace Framework.ILogger.Models
{
    /// <summary>
    /// Enumération des niveaux de log utilisé dans les traces.
    /// </summary>
    [Flags()]
    public enum LogLevel
    {
        /// <summary>
        /// Tout.
        /// </summary>
        All = 0,
        /// <summary>
        /// Debug.
        /// </summary>
        Debug = 1 << 0,
        /// <summary>
        /// Verbose (détaillé).
        /// </summary>
        Verbose = 1 << 1,
        /// <summary>
        /// Audit (perfomances).
        /// </summary>
        Audit = 1 << 2,
        /// <summary>
        /// Information.
        /// </summary>
        Info = 1 << 3,
        /// <summary>
        /// Avertissement.
        /// </summary>
        Warning = 1 << 4,
        /// <summary>
        /// Erreur.
        /// </summary>
        Error = 1 << 5,
        /// <summary>
        /// Fatal.
        /// </summary>
        Fatal = 1 << 6,

        /// <summary>
        /// Si le log est de type info ou + grave.
        /// </summary>
        InfoAndUpper = Info | Warning | Error | Fatal,

        /// <summary>
        /// Si le log est en mode test.
        /// </summary>
        TestPurpose = Verbose | Audit | Debug | All
    }
}

