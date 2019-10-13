using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// teljes projekt hozzáadása a referenciákhoz
using CarShop.Data;

namespace FF_demo
{
    class Program
    {
        static void Main(string[] args)
        {
            // add connection string!
            CarDatabaseEntities db = new CarDatabaseEntities();
            Console.WriteLine(db.cars.Count());

            
        }
    }
}
