using Core.Storage.Serialization;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using Core.Storage.Serialization;

namespace Core.Storage
{
    public class Storage<T> where T : Serialization.ISerializable, new()
    {

        // bazirano na vezbama 3!
        private readonly string _filePath = $"..{Path.DirectorySeparatorChar}..{Path.DirectorySeparatorChar}..{Path.DirectorySeparatorChar}..{Path.DirectorySeparatorChar}Core{Path.DirectorySeparatorChar}Data{Path.DirectorySeparatorChar}{{0}}";
        private readonly Serializer<T> _serializer = new();

        public Storage(string fileName)
        {
            _filePath = string.Format(_filePath, fileName);
        }

        public List<T> Load()
        {
            if(!File.Exists(_filePath))
            {
                FileStream fileStream = File.Create(_filePath);
                fileStream.Close();
            }

            IEnumerable<string> lines = File.ReadLines(_filePath);
            List<T> objs = _serializer.FromCSV(lines);
            return objs;
        }

        public void Save(List<T> objs)
        {
            string serializedObjs = _serializer.ToCSV(objs);
            using(StreamWriter streamWriter = new StreamWriter(_filePath))
            {
                streamWriter.Write(serializedObjs);
            }
        }

    }
}
