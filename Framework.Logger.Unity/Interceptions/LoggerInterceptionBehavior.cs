using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Unity.InterceptionExtension;
using System.Diagnostics;
using Framework.ILogger.Contracts;
using Framework.Logger.Trace;

namespace Framework.Logger.Unity
{
    //[System.Diagnostics.DebuggerStepThrough]
    public class LoggerInterceptionBehavior : IInterceptionBehavior
    {
        private ITraceManager _logManager;

        public LoggerInterceptionBehavior(ITraceManager logManager)
        {
            this._logManager = logManager;
        }

        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return Type.EmptyTypes;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods")]
        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            var result = getNext()(input, getNext);
            stopwatch.Stop();

            var loggerName = input.MethodBase.DeclaringType.Assembly.ManifestModule.Name;
            var logger = this._logManager.GetLogger(loggerName);

            if (!logger.CanLogVerbose)
            {
                logger.LogInfo(GetTextFormatted(input, string.Format(" {1}(ms)-{0} ", "Method Called", stopwatch.ElapsedMilliseconds)));
            }
            else
            {
                logger.LogVerbose(GetTextFormatted(input, "Enter method"));

                if (input.Arguments.Count > 0)
                {
                    var strB = new StringBuilder();
                    var i = 1;
                    foreach (var item in input.Arguments)
                    {
                        strB.AppendLine();
                        strB.Append(String.Format("Parameter {0}: {1}", i, item.GetTraceJson()));
                        i += 1;
                    }

                    logger.LogVerbose(String.Format("{0} - {1}", GetTextFormatted(input, "Parameters"), strB));
                }

                result = getNext()(input, getNext);

                if (result.ReturnValue != null)
                {
                    logger.LogVerbose(String.Format("{0} - {1}", GetTextFormatted(input, String.Format("{1}(ms)-{0}","Returned value", stopwatch.ElapsedMilliseconds)), result.ReturnValue.GetTraceJson()));
                }
            }

            // var result = getNext()(input, getNext);

            if (result.Exception != null)
            {
                logger.LogFatal(String.Format("{0} - {1}", GetTextFormatted(input,String.Format("{1}(ms)-{0}","An exception has occurred",stopwatch.ElapsedMilliseconds)), result.Exception.GetTraceJson()));
            }

            if (logger.CanLogVerbose)
                logger.LogVerbose(GetTextFormatted(input, "Exit method"));

            return result;
        }

        public bool WillExecute
        {
            get { return true; }
        }

        private string GetTextFormatted(IMethodInvocation methodInfo, string text)
        {
            var methodName = methodInfo.MethodBase.Name;

            var paramsType = new StringBuilder();
            var sentinelle = false;
            foreach (var item in methodInfo.Arguments)
            {
                if (item == null)
                    continue;

                if (!sentinelle)
                {
                    sentinelle = true;
                }
                else
                {
                    paramsType.Append(", ");
                }
                paramsType.Append(item.GetType().FullName);
            }

            return String.Format(
                "[{0}.{1}{3}] - {2}"
                , methodInfo.MethodBase.DeclaringType.FullName
                , methodName.Replace("get_", "")
                , text
                , methodName.Contains("get_") ? String.Empty : string.Format("({0})", paramsType));
        }
    }
}