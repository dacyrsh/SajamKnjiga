using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;
using Core.Storage;
using Core.Storage.Serialization;
using Core.Interfaces;
using System.Xml.Linq;

namespace Core.DAO
{
    internal abstract class GenericDAO<T> where T: class, ISerializable, I_ID, new()
    {
        // Bazirano na vezbama 3!
        private readonly List<T> _objs;
        private readonly Storage<T> _storage;

        protected GenericDAO(string fileName)
        {
            _storage = new Storage<T>(fileName);
            _objs = _storage.Load();
        }

        private int GenerateId()
        {
            if (_objs.Count == 0) return 0;
            return _objs[^1].Id + 1;
        }

        public T Add(T obj)
        {
            obj.Id = GenerateId();
            _objs.Add(obj);
            _storage.Save(_objs);
            return obj;
        }

        public T Update(T obj)
        {
            T oldObj = GetById(obj.Id);
            if (oldObj == null) return null;



            obj = oldObj;
            _storage.Save(_objs);
            return oldObj;
        }

        public T Remove(int id)
        {
            T obj = GetById(id);
            if(obj == null) return null;

            _objs.Remove(obj);
            _storage.Save(_objs);
            return obj;
        }

        public List<T> GetAll()
        {
            return _objs;
        }

        public T GetById(int id)
        {
            return _objs.Find(obj => obj.Id == id);
        }
    }
}
