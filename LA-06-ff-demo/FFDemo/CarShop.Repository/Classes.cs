using System;
using System.Data.Entity;
using System.Linq;

using CarShop.Data;

namespace CarShop.Repository
{
    public interface IRepository <T> where T : class
    {
        T GetOne(int id);
        IQueryable<T> GetAll();
    }

    public interface ICarRepository : IRepository<cars> // using Carshop.Data-ból
    {
        void ChangePrice(int id, int newprice);
    }

    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected DbContext context; // using System.Data.Entity
        public Repository(DbContext ctx)
        {
            this.context = ctx;
        }

        public IQueryable<T> GetAll()
        {
            return context.Set<T>(); // set mint halmaz
        }

        public abstract T GetOne(int id);
    }

    public class CarRepository : Repository<cars>, ICarRepository
    {
        public CarRepository(DbContext ctx) : base(ctx) { }


        public void ChangePrice(int id, int newprice)
        {
            var car = GetOne(id);
            car.car_baseprice = newprice;
            context.SaveChanges();
        }

        public override cars GetOne(int id)
        {
            return GetAll().SingleOrDefault(x => x.car_id == id);
        }
    }
}
