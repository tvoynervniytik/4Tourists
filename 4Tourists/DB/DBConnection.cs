using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4Tourists.DB
{
    internal class DBConnection
    {
        public static ToristsGoEntities TouristsGo = new ToristsGoEntities();
        public static Employee loginedUser;
    }
}
