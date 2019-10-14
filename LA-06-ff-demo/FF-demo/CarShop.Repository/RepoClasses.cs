using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CarShop.Data; // saját using

namespace CarShop.Repository
{
    public interface ICarRepository
    {
        // CRUD - create, read, update, delete

        //create
        void CreateCar(CAR car);

        // read
        CAR GetOne(int id);
        IQueryable<CAR> GetAll(); // sql intézi a munkát (ha szükséges)

        // update
        void UpdatePrice(int id, int newPrice);
        void UpdateName(int id, string newName);

        // delete
        void Deletecar(int id);
    }

    // --------------------------------------------------------------------------------------------------------

    public class CarRepository : ICarRepository
    {
        private CarDatabaseEntities db;
        public CarRepository(CarDatabaseEntities db) { this.db = db; }


        public CAR GetOne(int id)
        {
            return db.CAR.Where(x => x.car_id == id).FirstOrDefault();
        }

        public void UpdateName(int id, string newName)
        {
            var car = GetOne(id);
            car.car_model = newName;
            db.SaveChanges();
        }

        public void UpdatePrice(int id, int newPrice)
        {
            var car = GetOne(id);
            car.car_baseprice = newPrice;
            db.SaveChanges();
        }

        public void CreateCar(CAR car)
        {
            db.CAR.Add(car);
            db.SaveChanges();
        }

        public void Deletecar(int id)
        {
            db.CAR.Remove(this.GetOne(id));
            db.SaveChanges();
        }

        public IQueryable<CAR> GetAll()
        {
            return db.CAR;
        }
    }
}
