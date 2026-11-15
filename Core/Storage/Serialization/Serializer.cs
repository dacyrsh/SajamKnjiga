using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Storage.Serialization
{
    internal class Serializer<T> where T : ISerializable, new()
    {

        // Serializer baziran na vezbama 3
        private const char Rastavljac = ',';

        public string ToCSV(List<T> objs)
        {
            StringBuilder sb = new StringBuilder();

            foreach(ISerializable obj in objs)
            {
                string linija = string.Join(Rastavljac.ToString(), obj.ToCSV());
            }

            return sb.ToString();
        }

        public List<T> FromCSV(IEnumerable<string> linije)
        {
            List<T> objs = new List<T>();

            foreach(string linija in linije)
            {
                string[] csvVrednosti = linija.Split(Rastavljac);
                T obj = new T();
                obj.FromCSV(csvVrednosti);
                objs.Add(obj);
            }

            return objs;
        }
    }
}
