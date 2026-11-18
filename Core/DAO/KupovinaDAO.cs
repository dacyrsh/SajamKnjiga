using System;
using System.Collections.Generic;
using System.Text;
using Core.Models;

namespace Core.DAO
{
    internal class KupovinaDAO : GenericDAO<Kupovina>
    {
        public KupovinaDAO(): base("kupovina.txt")
        {

        }
    }
}
