using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.ILogger.Contracts
{
    public interface ITraceManager
    {
        /// <summary>
        /// Charge le wrapper de trace.
        /// </summary>
        /// <returns>Un wrapper de trace.</returns>
        /// <remarks>WrapperName peut être nul, auquel cas le wrapper par défaut est utilisé. Si loggerName est nul, "Logger.Trace" est utilisé.</remarks>
        ITrace GetLogger();

        /// <summary>
        /// Charge le wrapper de trace.
        /// </summary>
        /// <param name="loggerName">Nom du logger à utiliser.</param>
        /// <returns>Un wrapper de trace.</returns>
        /// <remarks>WrapperName peut être nul, auquel cas le wrapper par défaut est utilisé. Si loggerName est nul, "Logger.Trace" est utilisé.</remarks>
        ITrace GetLogger(string loggerName);

        /// <summary>
        /// Charge le wrapper de trace.
        /// </summary>
        /// <param name="type">Type du logger à utiliser.</param>
        /// <returns>Un wrapper de trace.</returns>
        /// <remarks>WrapperName peut être nul, auquel cas le wrapper par défaut est utilisé. Si loggerName est nul, "Logger.Trace" est utilisé.</remarks>
        ITrace GetLogger(Type type);

        /// <summary>
        /// Charge le wrapper de trace.
        /// </summary>
        /// <param name="wrapperName">Nom du wrapper à utiliser.</param>
        /// <param name="loggerName">Nom du logger à utiliser.</param>
        /// <returns>Un wrapper de trace.</returns>
        /// <remarks>WrapperName peut être nul, auquel cas le wrapper par défaut est utilisé. Si loggerName est nul, "Logger.Trace" est utilisé.</remarks>
        ITrace GetLogger(string wrapperName, string loggerName);

        /// <summary>
        /// Charge le wrapper de trace.
        /// </summary>
        /// <param name="wrapperName">Nom du wrapper à utiliser.</param>
        /// <param name="type">Type du logger à utiliser.</param>
        /// <returns>Un wrapper de trace.</returns>
        /// <remarks>WrapperName peut être nul, auquel cas le wrapper par défaut est utilisé. Si loggerName est nul, "Logger.Trace" est utilisé.</remarks>
        ITrace GetLogger(string wrapperName, Type type);
    }
}
