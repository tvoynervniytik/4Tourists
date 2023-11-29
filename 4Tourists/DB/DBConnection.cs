using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4Tourists.DB
{
    internal class DBConnection
    {
        public static ToristsGOEntities1 TouristsGo = new ToristsGOEntities1();
        public static Employee loginedUser;
    }
}
