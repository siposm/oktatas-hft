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

        public List<Avenger> GetAvengers()
        {
            return repo.GetAvengers();
        }

        public List<Avenger> SelectAvengersByGender(bool gender)
        {
            return repo.GetAvengers().Where( x => x.Gender == gender).ToList();
        }

        public int AddAvenger(Avenger avenger)
        {
            // szűrés / vizsgálat / validálás stb. (ezt most kihagyjuk)
            return repo.AddAvenger(avenger);
        }

        public void AddAvengerROSSZ(Avenger avenger)
        {
            // nem csinálunk semmit >> hibát okozva ezzel
        }

        public Avenger SelectAvengerByIndex(int index)
        {
            // itt is lehetne +1 réteget rárakni
            // illetve szebb ha a repo 1 metódusát hívjuk, nem így direktben a listát!
            return repo.Avengers[index];
        }
    }
}
