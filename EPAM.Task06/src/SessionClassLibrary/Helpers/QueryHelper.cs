using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SessionClassLibrary.Helpers
{
    public static class QueryHelper
    {
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
