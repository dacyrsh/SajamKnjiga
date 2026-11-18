using System;
using System.Collections.Generic;
using System.Text;
using Core.Models;

namespace Core.DAO
{
    internal class PosetilacDAO : GenericDAO<Posetilac>
    {
        public PosetilacDAO() : base("posetioci.txt")
        {

        }
    }
}
