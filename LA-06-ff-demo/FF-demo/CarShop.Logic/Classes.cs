using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CarShop.Data;
using CarShop.Repository;

namespace CarShop.Logic
{
    public class AveragesResult
    {
        public string BrandName { get; set; }
        public double AveragePrice { get; set; }
        public override string ToString()
        {
            return $"BRAND = {BrandName}, AVG = {AveragePrice}";
        }
    }
    // Should add DTO instead of Entities => SKIP for this semester
    // This is a SERIOUS security hole!
    // var car = logic.GetOneCar(40);
    // car.car_model = "NEWBRAND"; // Shouldn't be able to do this.
    // logic.ChangeCarPrice(40, car.car_baseprice); // saves new brand name too!!!

    public interface ICarLogic // veszélyes: túl sok felelősséggel rendelkező osztály (kerülendő)
    {
        cars GetOneCar(int id);
        void ChangeCarPrice(int id, int newprice);
        IList<cars> GetAllCars();
        IList<AveragesResult> GetBrandAverages();
    }

    public class CarLogic
    {
        ICarRepository carRepo;

        public CarLogic()
        {
            carRepo = new CarRepository(new CarDatabaseEntities());
        }

        public CarLogic(ICarRepository repo)
        {
            this.carRepo = repo;
        }

        public void ChangeCarPrice(int id, int newprice)
        {
            carRepo.ChangePrice(id, newprice);
        }

        public IList<cars> GetAllCars()
        {
            return carRepo.GetAll().ToList();
        }

        public IList<AveragesResult> GetBrandAverages()
        {
            var q = from car in carRepo.GetAll()
                    group car by car.brands into grp
                    select new AveragesResult()
                    {
                        BrandName = grp.Key.brand_name,
                        AveragePrice = grp.Average(car => car.car_baseprice) ?? 0
                    };

            return q.ToList();
        }

        public cars GetOneCar(int id)
        {
            return carRepo.GetOne(id);
        }
    }
}
