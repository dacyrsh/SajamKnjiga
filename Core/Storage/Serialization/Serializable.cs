using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Storage.Serialization
{
    internal interface ISerializable
    {
        string[] ToCSV();

        void FromCSV(string[] vvalues);
    }
}
