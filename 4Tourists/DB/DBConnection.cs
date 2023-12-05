using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4Tourists.DB
{
    internal class DBConnection
    {
        public static TouristsGo1Entities TouristsGo = new TouristsGo1Entities();
        public static Employee loginedUser;
    }
}
