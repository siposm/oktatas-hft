using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CarShop.Data; // saját using

namespace CarShop.Repository
{
    public interface IRepository<T> where T : class
    {
        T GetOne(int id);
        IQueryable<T> GetAll(); // sql kiszolgáló lerendezi és csak a result-ot küldi meg
    }




    public interface ICarRepository : IRepository<cars>
    {
        void ChangePrice(int id, int newprice);
    }




    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected DbContext ctx;

        public Repository(DbContext ctx)
        {
            this.ctx = ctx;
        }

        public IQueryable<T> GetAll()
        {
            return ctx.Set<T>(); // set mint halmaz
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
            ctx.SaveChanges();
        }

        public override cars GetOne(int id)
        {
            return GetAll().SingleOrDefault(x => x.car_id == id);
        }
    }
}
