using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mocking
{
    class AvengerController
    {
        IRepository repo;

        public AvengerController(IRepository repo)
        {
            this.repo = repo;
        }

        public void WriteAvengers()
        {
            List<Avenger> avengers = repo.GetAvengers();

            foreach (Avenger ave in avengers)
            {
                Console.WriteLine(ave.Name);
            }
        }
    }
}
