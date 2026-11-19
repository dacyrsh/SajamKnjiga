using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace Core.Utils
{
    public static class CsvConversion
    {
        private const string ListDelimiter = ",";
        private const string DateFormat = "yyyy-MM-dd";

        public static List<int> ToIds(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return new List<int>();

            return value.Split(ListDelimiter, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
        }

        public static string FromIds(IEnumerable<int> ids)
        {
            return string.Join(ListDelimiter, ids);
        }

        public static string  FromDate(DateOnly date)
        {
            return date.ToString(DateFormat, CultureInfo.InvariantCulture);
        }

        public static DateOnly ToDate(string date)
        {
            return DateOnly.ParseExact(date, DateFormat, CultureInfo.InvariantCulture);
        }


    }
}
