using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utils
{
    internal static class CsvConversion
    {
        public static string ListDelimiter = ",";
        public static List<int> ToIds(string value)
        {
            return value.Split(ListDelimiter, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
        }

        public static string FromIds(IEnumerable<int> ids)
        {
            return string.Join(ListDelimiter, ids);
        }
    }
}
