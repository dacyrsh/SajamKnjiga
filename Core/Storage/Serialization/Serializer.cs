using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Storage.Serialization
{
    public class Serializer<T> where T : ISerializable, new()
    {

        // Serializer baziran na vezbama 3
        private const char Delimiter = '|';

        public string ToCSV(List<T> objs)
        {
            StringBuilder sb = new StringBuilder();

            foreach(ISerializable obj in objs)
            {
                string line = string.Join(Delimiter.ToString(), obj.ToCSV());
                sb.AppendLine(line);
            }

            return sb.ToString();
        }

        public List<T> FromCSV(IEnumerable<string> lines)
        {
            List<T> objs = new List<T>();

            foreach(string line in lines)
            {
                string[] csvValues = line.Split(Delimiter);
                T obj = new T();
                obj.FromCSV(csvValues);
                objs.Add(obj);
            }

            return objs;
        }
    }
}
