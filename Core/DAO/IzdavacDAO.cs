using System;
using System.Collections.Generic;
using System.Text;
using Core.Models;

namespace Core.DAO
{
    public class IzdavacDAO : GenericDAO<Izdavac>
    {
        public IzdavacDAO():base("izdavac.txt")
        {
        }
    }
}
