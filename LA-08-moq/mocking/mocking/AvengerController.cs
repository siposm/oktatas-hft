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

        public void AddAvenger(Avenger avenger)
        {
            // vizsgálat
            bool exist = false;
            if(avenger != null)
            {
                foreach (Avenger item in repo.GetAvengers())
                    if (item.Name == avenger.Name)
                        exist = true;

                if (!exist)
                    repo.AddAvenger(avenger);
                else
                    throw new AvengerExistsException("This Avenger already exists in the database.");
            }
            else
                throw new NullReferenceException("Null reference was caused from AddAvenger.");
        }

        public Avenger SelectAvengerByIndex(int index)
        {
            if(index >= 0) // vizsgálat
                if (index < repo.GetAvengers().Count)
                    return repo.GetAvengers()[index]; // hívás

            throw new IndexOutOfRangeException("Not valid index was given.");
        }

        public Avenger GetStrongestAvenger()
        {
            if(repo.GetAvengers().Count > 0)
                return repo.GetAvengers().Where(x => x.Name == "Thor").FirstOrDefault();
            else
                throw new Exception("Avengers list is empty.");
        }

        public List<Avenger> AvengersAssemble()
        {
            if (repo.GetAvengers().Count > 0)
                return repo.GetAvengers().Where( x => x.Superpower == true).ToList();
            else
                throw new Exception("Avengers list is empty.");
        }

        public List<Avenger> GetStrongestAvengers(int number)
        {
            if (repo.GetAvengers().Count > 0)
                return repo.GetAvengers().OrderByDescending( x => x.Strength).Take(number).ToList();
            else
                throw new Exception("Avengers list is empty.");
        }

        public int GetRecursiveMethod(int number)
        {
            for (int i = 0; i < number; i++)
                repo.GetRecursivelySomething();

            return new Random().Next(100);
        }
    }
}
