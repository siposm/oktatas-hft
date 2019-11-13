using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mocking
{
    public interface IRepository
    {
        // itt kéne előírni minden CRUD műveletet ideális esetben

        List<Avenger> GetAvengers();
        void AddAvenger(Avenger avenger);
        void GetRecursivelySomething();
        IEnumerable<Avenger> GetRealDatabaseRecords();
    }
}
