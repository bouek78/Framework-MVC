using Elmah;
using System;
using System.Linq;
using System.Web;

namespace Framework.Logger.Appender
{
    public class ELMAHAppender : log4net.Appender.AppenderSkeleton
    {
        private readonly static Type _DeclaringType = typeof(ELMAHAppender);
        private string _HostName;
        private ErrorLog _ErrorLog;

        public bool UseNullContext { get; set; }

        public override void ActivateOptions()
        {
            base.ActivateOptions();
            _HostName = Environment.MachineName;
            try
            {
                if (UseNullContext)
                {
                    this._ErrorLog = ErrorLog.GetDefault(null);
                }
                else
                {
                    this._ErrorLog = ErrorLog.GetDefault(HttpContext.Current);
                }
            }
            catch (Exception ex)
            {
                this.ErrorHandler.Error("Ne peux pas créer de log sur ELMAH", ex);
            }
        }


        protected override void Append(log4net.Core.LoggingEvent loggingEvent)
        {
            if (HttpContext.Current != null && this._ErrorLog == null)
            {
                this._ErrorLog = ErrorLog.GetDefault(HttpContext.Current);
            }

            if (this._ErrorLog != null)
            {
                Error error;
                if (loggingEvent.ExceptionObject != null)
                {
                    error = new Error(loggingEvent.ExceptionObject);
                }
                else
                {
                    error = new Error();
                }
                error.Time = DateTime.Now;
                if (loggingEvent.MessageObject != null)
                {
                    error.Message = loggingEvent.MessageObject.ToString();
                }
                error.Detail = base.RenderLoggingEvent(loggingEvent);
                error.HostName = this._HostName;
                error.User = loggingEvent.Identity;
                error.Type = loggingEvent.Level.ToString();
                // Si log depuis le web, on peux ajouter toutes les traces du HttpContext
                if (HttpContext.Current != null)
                {
                    // Server variables
                    error.ServerVariables.Add(HttpContext.Current.Request.ServerVariables);

                    // Patch GEM : à retirer si implémentation de IIdentity 
                    if (HttpContext.Current.Request.ServerVariables.AllKeys.Contains("HTTP_USER_KEY") && String.IsNullOrEmpty(error.User))
                    {
                        error.User = HttpContext.Current.Request.ServerVariables["HTTP_USER_KEY"];
                    }
                }

                this._ErrorLog.Log(error);
            }
        }
    }
}
