using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// teljes projekt hozzáadása a referenciákhoz
using CarShop.Data;
using CarShop.Logic;

namespace FF_demo
{
    class Program
    {
        static void Main(string[] args)
        {
            // add connection string!
            CarDatabaseEntities db = new CarDatabaseEntities();
            Console.WriteLine(db.cars.Count());

            var q = from car in db.cars
                    group car by car.brands into grp
                    select new
                    {
                        Brand = grp.Key.brand_name,
                        AvgPrice = grp.Average(car => car.car_baseprice)
                    };

            foreach (var item in q) Console.WriteLine(item);


            // ----


            CarLogic cl = new CarLogic();
            Console.WriteLine("----");
            foreach (var item in cl.GetBrandAverages()) Console.WriteLine(item);

            Console.WriteLine("----");
            foreach (var item in cl.GetCarsWithLetter('A')) Console.WriteLine(item);
        }
    }
}
