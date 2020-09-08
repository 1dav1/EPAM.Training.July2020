using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SessionClassLibrary.Helpers
{
    /// <include file='docs.xml' path='docs/members[@name="queryhelper"]/QueryHelper/*'/>
    public static class QueryHelper
    {
        /// <include file='docs.xml' path='docs/members[@name="queryhelper"]/GetParameters/*'/>
        public static string GetParameters(this IEnumerable<string> fields)
        {
            var notIdFields = (from f in fields
                               where f != "Id"
                               select f).ToArray();

            StringBuilder paramsBuilder = new StringBuilder($"@{notIdFields.First()}");
            notIdFields = notIdFields.Skip(1).ToArray();
            foreach (var field in notIdFields)
            {
                paramsBuilder.Append($",@{field}");
            }

            return paramsBuilder.ToString();
        }

        /// <include file='docs.xml' path='docs/members[@name="queryhelper"]/ValuesToParams/*'/>
        public static string ValuesToParams(this IEnumerable<string> fields)
        {
            var notIdFields = (from f in fields
                               where f != "Id"
                               select f).ToArray();
            StringBuilder builder = new StringBuilder($"[{notIdFields.First()}]=@{notIdFields.First()}");
            notIdFields = notIdFields.Skip(1).ToArray();
            foreach (var field in notIdFields)
            {
                builder.Append($",[{field}]=@{field}");
            }

            return builder.ToString();
        }

        /// <include file='docs.xml' path='docs/members[@name="queryhelper"]/GetFields/*'/>
        public static string GetFields(this IEnumerable<string> fields)
        {
            StringBuilder builder = new StringBuilder($"[{fields.ToArray().First()}]");

            for (int i = 1; i < fields.Count(); i++)
            {
                builder.Append($",[{fields.ToArray()[i]}]");
            }
            return builder.ToString();
        }
    }
}
