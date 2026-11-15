using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Storage.Serialization
{
    public interface ISerializable
    {
        // Serializer baziran na Vezbama 3 
        string[] ToCSV();

        void FromCSV(string[] values);
    }
}
