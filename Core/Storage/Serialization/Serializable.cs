using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Storage.Serialization
{
    internal interface ISerializable
    {
        // Serializer baziran na Vezbama 3 
        string[] ToCSV();

        void FromCSV(string[] vvalues);
    }
}
