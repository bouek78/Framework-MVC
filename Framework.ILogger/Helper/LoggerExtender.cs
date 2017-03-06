using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace System
{
    /// <summary>
    /// Classe d'extension apportant des Helper pour le log
    /// </summary>
    [DebuggerStepThrough()]
    public static class LoggerExtender
    {
        /// <summary>
        /// Obtient une représentation JSon d'un objet
        /// </summary>
        /// <param name="item">Objet à représenter en JSon</param>
        /// <returns>Une chaine string représentant l'objet passé en paramètre</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "0")]
        public static string GetTraceJson(this object item)
        {
            if (item == null)
                return "'null'";

            var itemType = item.GetType();
            var strBValue = new StringBuilder();

            if (itemType.IsPrimitive || itemType == typeof(string) || itemType == typeof(Guid))
            {
                strBValue.Append(String.Format("'{0}'", item));
            }
            else if (itemType.IsEnum)
            {
                strBValue.Append(String.Format("'{0} - {1}'", item.GetHashCode(), item.ToString()));
            }
            else if (itemType == typeof(Exception))
            {
                var exc = (Exception)item;
                strBValue.Append("{" + item.FormatObjectToJson(false) + (exc.InnerException != null ? ", InnerException:" + exc.InnerException.GetTraceJson() : "(null)") + "}");
            }
            else if (itemType == typeof(TimeSpan))
            {
                strBValue.Append(String.Format("'{0:dd\\.hh\\:mm\\:ss} days'", item));
            }
            else if (itemType.BaseType != null && itemType.BaseType == typeof(MulticastDelegate))
            {
                strBValue.Append("'(lambda expression)'");
            }
            else if (item is IEnumerable)
            {
                var first = true;
                foreach (var element in (IEnumerable)item)
                {
                    if (!first)
                        strBValue.Append(",");
                    else
                        first = false;

                    strBValue.Append(element.GetTraceJson());
                }
            }
            else
            {
                strBValue.Append(item.FormatObjectToJson());
            }

            return String.Format("{{ Type:'{0}{1}', Value:{2} }}", itemType.IsEnum ? "[Enum]" : String.Empty, itemType.FullName, strBValue);
        }


        private static string FormatObjectToJson(this object item, bool withCloseBraket = true)
        {
            var strB = new StringBuilder(withCloseBraket ? "{" : String.Empty);
            var first = true;
            foreach (var proprety in item.GetType().GetProperties().Where(p => (p.PropertyType.IsPrimitive || p.PropertyType == typeof(string)) && p.CanRead))
            {
                var value = proprety.GetValue(item);
                if (!first)
                {
                    strB.Append(",");

                }
                else
                    first = false;

                if (value == null)
                {
                    strB.Append(String.Format("{0}:'null'", proprety.Name));
                }
                else
                {
                    strB.Append(String.Format("{0}:'{1}'", proprety.Name, value));
                }
            }

            if (withCloseBraket)
                strB.Append("}");

            return strB.ToString();
        }
    }
}
