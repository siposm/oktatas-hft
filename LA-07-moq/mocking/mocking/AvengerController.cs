using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mocking
{
    public class AvengerController
    {
        IRepository repo;

        // dependency !!!
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

        public void AddAvenger(Avenger avenger)
        {
            // szűrés / vizsgálat / validálás stb. (ezt most kihagyjuk)
            repo.AddAvenger(avenger);
        }

        public void AddAvengerROSSZ(Avenger avenger)
        {
            // nem csinálunk semmit >> hibát okozva ezzel
        }
    }
}
