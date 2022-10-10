using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElsaDashboardTest.Extensions
{
    public static class StringExtension
    {
        public static bool HasValue(this object obj)
        {
            if (obj is string)
            {
                return !string.IsNullOrEmpty(obj.ToString());
            }
            else
            {
                return obj != null;
            }
        }

        public static Guid ToGuid(this string str, Guid? defaultValue = null)
        {
            return str.HasValue()
                    ? Guid.Parse(str)
                    : defaultValue ?? Guid.Empty;
        }
    }
}
