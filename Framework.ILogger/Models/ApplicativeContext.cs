using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Framework.ILogger.Models
{
    /// <summary>
    /// Définit les informations du context applicatif à un instant T.
    /// </summary>
    public class ApplicativeContext
    { 
        #region "Constructeur privé"

        /// <summary>
        /// Constructeur.
        /// </summary>
        private ApplicativeContext()
        {
            // Récupération de la date.
            _dateTime = System.DateTime.Now;

            if (HttpContext.Current != null)
            {
                // Récupération du nom de l'utilisateur.
                if (HttpContext.Current.User != null && HttpContext.Current.User.Identity != null)
                {
                    _userName = HttpContext.Current.User.Identity.Name;              
                }

                if (HttpContext.Current.Request != null)
                {
                    // Récupération des informations sur le navigateur.
                    if (HttpContext.Current.Request.Browser != null)
                    {
                        _browserName = HttpContext.Current.Request.Browser.Browser;
                        _browserVersion = HttpContext.Current.Request.Browser.Version;
                    }

                    // Récupération de l'adresse ip du poste.
                    if (HttpContext.Current.Request.ServerVariables.AllKeys.Contains("REMOTE_ADDR"))
                    {
                        _ip = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                    }
                }

                // Récupération de l'identifiant de la session.
                if (HttpContext.Current.Session != null)
                {
                    _sessionId = HttpContext.Current.Session.SessionID;
                }
            }

            try
            {
                StackTrace stack = new StackTrace(true);
                StackFrame frame = null;

                // Récupération de la pile à l'endroit où s'est produit l'appel.
                for (int i = 0; i <= stack.FrameCount - 1; i++)
                {
                    frame = stack.GetFrame(i);

                    if (!frame.GetMethod().DeclaringType.Assembly.Equals(Assembly.GetExecutingAssembly()))
                    {
                        break;
                    }
                }

                // Récupération de la méthode.
                MethodBase method = frame.GetMethod();

                // Récupération des informations .
                _callingFilePath = frame.GetFileName();
                _callingFileLine = frame.GetFileLineNumber().ToString(System.Globalization.NumberFormatInfo.InvariantInfo);
                _callingClassName = method.DeclaringType.FullName;
                _callingMethodName = method.Name;

                // Récupération des informations sur l'assembly.
                AssemblyName assemblyInfo = method.DeclaringType.Assembly.GetName();


                if (assemblyInfo != null)
                {
                    _assemblyName = assemblyInfo.Name;
                    _assemblyVersion = assemblyInfo.Version.ToString();

                }
            }
            catch
            {
                _callingFilePath = "UnknownFilePath";
                _callingFileLine = "UnknownFileLine";
                _callingClassName = "UnknownClass";
                _callingMethodName = "UnknownMethod";
            }
        }

        #endregion

        #region "Propriétés"

        /// <summary>
        /// Représente un context applicatif vide.
        /// </summary>
        /// <remarks>Champs en lecture seule.</remarks>
        private static ApplicativeContext _empty = null;
        public static ApplicativeContext Empty
        {
            get { return _empty; }
        }

        /// <summary>
        /// Obtient la date et l'heure de la récupération du context.
        /// </summary>
        private System.DateTime _dateTime;
        public System.DateTime DateTime
        {
            get { return _dateTime; }
        }

        /// <summary>
        /// Obtient le nom de l'utilisateur.
        /// </summary>
        private string _userName;
        public string UserName
        {
            get { return _userName; }
        }

        /// <summary>
        /// Obtient l'adresse Ip du poste.
        /// </summary>
        private string _ip;
        public string IP
        {
            get { return _ip; }
        }

        /// <summary>
        /// Obtient le nom du navigateur.
        /// </summary>
        private string _browserName;
        public string BrowserName
        {
            get { return _browserName; }
        }

        /// <summary>
        /// Obtient la version du navigateur.
        /// </summary>
        private string _browserVersion;
        public string BrowserVersion
        {
            get { return _browserVersion; }
        }

        /// <summary>
        /// Obtient l'identifiant de la session.
        /// </summary>
        private string _sessionId;
        public string SessionId
        {
            get { return _sessionId; }
        }

        /// <summary>
        /// Obtient le nom de l'assembly à l'origine de l'appel.
        /// </summary>

        private string _assemblyName;
        public string AssemblyName
        {
            get { return _assemblyName; }
        }

        /// <summary>
        /// Obtient la version de l'assembly à l'origine de l'appel.
        /// </summary>
        private string _assemblyVersion;
        public string AssemblyVersion
        {
            get { return _assemblyVersion; }
        }

        /// <summary>
        /// Obtient le chemin du fichier contenant la méthode à l'origine de l'appel.
        /// </summary>
        private string _callingFilePath;
        public string CallingFilePath
        {
            get { return _callingFilePath; }
        }

        /// <summary>
        /// Obtient le numéro de la ligne dans le fichier de la méthode à l'origine de l'appel.
        /// </summary>
        private string _callingFileLine;
        public string CallingFileLine
        {
            get { return _callingFileLine; }
        }

        /// <summary>
        /// Obtient le nom de la classe de la méthode à l'origine de l'appel.
        /// </summary>
        private string _callingClassName;
        public string CallingClassName
        {
            get { return _callingClassName; }
        }

        /// <summary>
        /// Obtient le nom de la méthode à l'origine de l'appel.
        /// </summary>
        private string _callingMethodName;
        public string CallingMethodName
        {
            get { return _callingMethodName; }
        }

        #endregion

        #region "Surcharges"

        /// <summary>
        /// Retourne un <see cref="T:System.String" /> qui représente le <see cref="T:System.Object" /> actuel.
        /// </summary>
        /// <returns>
        /// <see cref="T:System.String" /> qui représente le <see cref="T:System.Object" /> actuel.
        /// </returns>
        public override string ToString()
        {
            return string.Format(string.Concat("Date: {0}\\r\\n", "UserName: {1}\\r\\n", "Ip: {2}\\r\\n", "Browser: {3} {4}\\r\\n", "Session Id: {5}\\r\\n", "AssemblyName: {6}\\r\\n", "AssemblyVersion: {7}\\r\\n", "CallingFilePath: {8}\\r\\n", "CallingFileLine: {9}\\r\\n", "CallingClassName: {10}\\r\\n",
            "CallingMethodName: {11}\\r\\n"), _dateTime, _userName, _ip, _browserName, _browserVersion, _sessionId, _assemblyName, _assemblyVersion, _callingFilePath,
            _callingFileLine, _callingClassName, _callingMethodName);

        }

        #endregion

        #region "Méthodes internes statiques"

        /// <summary>
        /// Retourne le context applicatif courant.
        /// </summary>
        /// <returns>Le context applicatif courant.</returns>
        static internal ApplicativeContext GetCurrent()
        {
            return new ApplicativeContext();
        }

        #endregion

    }
}
