using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CarShop.Data;
using CarShop.Repository;

namespace CarShop.Logic
{
    public class AverageResult
    {
        public string BrandName { get; set; }
        public double AveragePrice { get; set; }
        public override string ToString()
        {
            return $"BRAND = {BrandName}, AVG = {AveragePrice}";
        }
    }

    // https://www.driver733.com/2018/10/08/entity-and-dto.html
    //
    // Should add DTO instead of Entities => SKIP for this semester
    // This is a SERIOUS security hole!
    // var car = logic.GetOneCar(40);
    // car.car_model = "NEWBRAND"; // Shouldn't be able to do this.
    // logic.ChangeCarPrice(40, car.car_baseprice); // saves new brand name too!!!

    public interface ICarLogic // veszélyes: túl sok felelősséggel rendelkező osztály (kerülendő)
    {
        CAR GetOneCar(int id);
        void ChangeCarPrice(int id, int newprice);
        IList<CAR> GetAllCars();
        IList<AverageResult> GetBrandAverages();
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

        // --------------------------------------------------------------------------------------------------------

        public void ChangeCarPrice(int id, int newprice)
        {
            carRepo.UpdatePrice(id, newprice);
        }

        public CAR GetOneCar(int id)
        {
            return carRepo.GetOne(id);
        }

        public List<CAR> GetAll()
        {
            return carRepo.GetAll().ToList();
        }

        public void InsertCar(CAR car)
        {
            carRepo.CreateCar(car);
        }

        public void DeleteCar(int id)
        {
            carRepo.Deletecar(id);
        }

        public IEnumerable<string> GetCarsWithLetter(char param, bool caseSensitive)
        {
            if (caseSensitive)
                return (from x in carRepo.GetAll().ToList()
                        where x.car_model.Contains(param)
                        select x.car_model);
            else
                return (from x in carRepo.GetAll().ToList()
                        where x.car_model.ToUpper().Contains(char.ToUpper(param))
                        select x.car_model);
        }


        // Megjegyzés:
        // https://stackoverflow.com/questions/376708/ilist-vs-ienumerable-for-collections-on-entities
        // https://stackoverflow.com/questions/3228708/what-should-i-use-an-ienumerable-or-ilist

        public IList<AverageResult> GetBrandAverages()
        {
            var q = from car in carRepo.GetAll()
                    group car by car.BRAND into grp
                    select new AverageResult()
                    {
                        BrandName = grp.Key.brand_name,
                        AveragePrice = grp.Average(car => car.car_baseprice) ?? 0 // if not null
                    };

            return q.ToList();
        }

        public string GetCheapestCarModel()
        {
            var q = from x in carRepo.GetAll()
                    orderby x.car_baseprice ascending
                    select x.car_model;

            return q.First().ToString();
        }
    }
}
