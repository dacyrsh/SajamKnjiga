using System;
using System.Collections.Generic;
using System.Text;
using Core.Models;

namespace Core.DAO
{
    public class KupovinaDAO : GenericDAO<Kupovina>
    {
        public KupovinaDAO(): base("kupovina.csv")
        {

        }
    }
}
