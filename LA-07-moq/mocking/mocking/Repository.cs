using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mocking
{
    public class Repository : IRepository
    {
        AvengerDatabaseEntities db;

        public Repository()
        {
            db = new AvengerDatabaseEntities();
        }

        public List<Avenger> GetAvengers()
        {
            return db.Avenger.ToList();
        }

        public void AddAvenger(Avenger avenger)
        {
            db.Avenger.Add(avenger);
            db.SaveChanges();
        }
    }
}
